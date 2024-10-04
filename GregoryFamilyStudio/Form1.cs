using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Vlc.DotNet.Forms;
using System.Drawing.Text;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Globalization;
using System.Reflection.Emit;
using Microsoft.Win32;
using System.Reflection;
using System.Runtime.InteropServices;

namespace GregoryFamilyStudio
{
    public partial class Form1 : Form
    {
        private string startDirectory;
        private const string PATHCONSTANT = "-";
        private string sCurDir = "";
        private String vlcInstallDirectory;
        private VlcControl vlcControl1;
        private enum MovieState { Stopped = 0, Stop = 1, Play = 2, Playing = 3, Pause = 4, Paused = 5, End = 6 };
        private MovieState curMovieState;
        private string sCurRunTime;
        private bool m_bShowRunTime = false;

        public Form1()
        {
            vlcInstallDirectory = GetPathForExe("VLC.EXE");
            vlcInstallDirectory = vlcInstallDirectory.Substring(0, vlcInstallDirectory.LastIndexOf("\\"));
            /*
            int nExeNameEnd = Application.ExecutablePath.LastIndexOf('.');
            string sININame = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - (Application.ExecutablePath.Length - nExeNameEnd )) + ".ini";
            var MyIni = new IniFile(@sININame);
            if (!MyIni.KeyExists("StartDirectory", "Main"))
                startDirectory = MyIni.Read("StartDirectory", "Main");
            */
            if (System.Environment.MachineName == "GREGORY-PC")
            {
                startDirectory = "c:\\videos";
            }
            else
            {
                startDirectory = "e:\\videos";
            }

            vlcControl1 = new VlcControl();
            InitializeComponent();

            sCurDir = startDirectory;
            refreshFiles();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vlcControl1.BeginInit();
            var libDirectory = new DirectoryInfo(vlcInstallDirectory);
            vlcControl1 = new Vlc.DotNet.Forms.VlcControl();
            vlcControl1.VlcLibDirectory = libDirectory;
            //vlcControl1.EndReached += new System.EventHandler( _OnEndReached );
            vlcControl1.EndReached += VlcControl1_EndReached;
            vlcControl1.EndInit();
            this.Controls.Add(vlcControl1); //Add the control to your container
            vlcControl1.Dock = DockStyle.Fill; //Optional

            this.Top = 0;
            //picResizer.Height = 684; // Screen.PrimaryScreen.WorkingArea.Height;
            //picResizer.Top = ((Screen.PrimaryScreen.WorkingArea.Height - picResizer.Height) / 2);
            this.Left = 0;
            //picResizer.Width = 1218; // Screen.PrimaryScreen.WorkingArea.Width;
            //picResizer.Left = ((Screen.PrimaryScreen.WorkingArea.Width - picResizer.Width) / 2);
            
        }

        private void VlcControl1_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                setMovieState(MovieState.End);
            }));
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                if (curMovieState == MovieState.Playing)
                    setMovieState(MovieState.Stop);
                else
                    Application.Exit();
            }

            if (e.KeyChar == Convert.ToChar(Keys.Space) && 
                ( ( curMovieState == MovieState.Playing ) || curMovieState == MovieState.Paused ) )
            {
                if (curMovieState == MovieState.Playing)
                    setMovieState(MovieState.Pause);
                else
                    setMovieState(MovieState.Play);
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (lvMain.SelectedItems[0].Tag != null && lvMain.SelectedItems[0].Tag.ToString() == PATHCONSTANT)
                {
                    if (lvMain.SelectedItems[0].SubItems[0].Text == "..")
                        sCurDir = sCurDir.Substring(0, sCurDir.LastIndexOf('\\'));
                    else
                        sCurDir = sCurDir + '\\' + lvMain.SelectedItems[0].SubItems[0].Text;

                    refreshFiles();
                }
                else
                {
                    String sCurFile = sCurDir + '\\' + lvMain.SelectedItems[0].SubItems[0].Text;
                    vlcControl1.SetMedia(new FileInfo(sCurFile));
                    sCurRunTime = lvMain.SelectedItems[0].SubItems[1].Text;
                    setMovieState(MovieState.Play);
                }
            }
        }

        private void setMovieState(MovieState movieState)
        {
            if (movieState == MovieState.Play && curMovieState == MovieState.Paused)
            {
                showRunTime(false);
                vlcControl1.Play();
            }
            if (movieState == MovieState.Play)
            {
                curMovieState = MovieState.Playing;
                picResizer.Visible = lblSize.Visible = lvMain.Visible = false;
                vlcControl1.Play();
            }
            else if (movieState == MovieState.End )
            {
                curMovieState = MovieState.Stopped;
                picResizer.Visible = lblSize.Visible = lvMain.Visible = true;
                lvMain.Focus();
            }
            else if (movieState == MovieState.Stop)
            {
                vlcControl1.Stop();
                curMovieState = MovieState.Stopped;
                picResizer.Visible = lblSize.Visible = lvMain.Visible = true;
                lvMain.Focus();
            }
            else if (movieState == MovieState.Pause)
            {
                showRunTime(true);
                curMovieState = MovieState.Paused;
                vlcControl1.Pause();
            }
        }

        private void showRunTime(bool v)
        {
            if (v)
            {
                DateTime totalTime = DateTime.ParseExact(sCurRunTime, "HH:mm:ss", CultureInfo.InvariantCulture);
                var timeSpan = TimeSpan.FromSeconds(totalTime.TimeOfDay.TotalSeconds * vlcControl1.Position);
                timeSpan = TimeSpan.FromSeconds(totalTime.TimeOfDay.TotalSeconds - timeSpan.TotalSeconds);
                DateTime curTime = totalTime.Subtract(timeSpan);
                lblCurRunTime.Text = String.Format("{0:HH:mm:ss} of {1:HH:mm:ss}", curTime, totalTime);
            }
            lblCurRunTime.Visible = v;
            m_bShowRunTime = v;
        }

    private void refreshFiles()
    {
        lvMain.Items.Clear();
        if (sCurDir != startDirectory)
        {
            ListViewItem lvi = lvMain.Items.Add("..");
            lvi.ForeColor = Color.Green;
            lvi.Tag = PATHCONSTANT;
        }

        // Directories
        foreach( String sElement in Directory.GetDirectories( sCurDir ) )
        {
            String sCur = sElement.ToUpper().Substring(sElement.ToUpper().LastIndexOf('\\') + 1, sElement.Length - sElement.ToUpper().LastIndexOf('\\')-1);
            ListViewItem lvi = lvMain.Items.Add( sCur );
            lvi.ForeColor = Color.LightGreen;
            lvi.Tag = PATHCONSTANT;
        }
    
        foreach( String sElement in Directory.GetFiles( sCurDir, "*.mp4"  ) )
        {
            String sCur = sElement.Substring(sElement.ToUpper().LastIndexOf('\\') + 1, sElement.Length - sElement.ToUpper().LastIndexOf('\\')-1);
            String[] sAllItems = new String[2];
            sAllItems[0] = sCur;

            dynamic shellApp = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            var folder = shellApp.NameSpace(Path.GetDirectoryName(sElement));
            var file = folder.ParseName(Path.GetFileName(sElement));
            string propertyValue = folder.GetDetailsOf(file, 27); // 27 represents a specific property, adjust as needed

            sAllItems[1] = propertyValue;
            ListViewItem lvi = new ListViewItem( sAllItems );
            lvMain.Items.Add(lvi);
            lvi.ForeColor = Color.White;
                //lvi.Tag = PATHCONSTANT;
        }

        lvMain.Items[0].Selected = true;
        lvMain.Focus();
    }

        private void tmrShowRuntime_Tick(object sender, EventArgs e)
        {
            if (m_bShowRunTime)
            {
                showRunTime(m_bShowRunTime);
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete &&
                ((Control.ModifierKeys & Keys.Control) == Keys.Control))
            {
                if (lvMain.SelectedItems[0].Tag == null || lvMain.SelectedItems[0].Tag.ToString() != PATHCONSTANT)
                {
                    String sCurFile = sCurDir + '\\' + lvMain.SelectedItems[0].SubItems[0].Text;
                    File.Delete(sCurFile);
                    refreshFiles();
                }
            }
            return;
        }

        private const string keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
        private string GetPathForExe(string fileName)
        {
            RegistryKey localMachine = Registry.LocalMachine;
            RegistryKey fileKey = localMachine.OpenSubKey(string.Format(@"{0}\{1}", keyBase, fileName));
            object result = null;
            if (fileKey != null)
            {
                result = fileKey.GetValue(string.Empty);
                fileKey.Close();
            }

            return (string)result;
        }
    }

    class IniFile   // revision 11
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public string Read(string Key, string Section = null)
        {
            StringBuilder RetVal = new StringBuilder(1000);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 1000, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
