namespace GregoryFamilyStudio
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picResizer = new System.Windows.Forms.PictureBox();
            this.lblAppTitle = new System.Windows.Forms.Label();
            this.lvMain = new System.Windows.Forms.ListView();
            this.mediaName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.runTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCurRunTime = new System.Windows.Forms.Label();
            this.tmrShowRuntime = new System.Windows.Forms.Timer(this.components);
            this.tmrEndReached = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picResizer)).BeginInit();
            this.SuspendLayout();
            // 
            // picResizer
            // 
            this.picResizer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picResizer.BackColor = System.Drawing.Color.Transparent;
            this.picResizer.Location = new System.Drawing.Point(31, 18);
            this.picResizer.Name = "picResizer";
            this.picResizer.Size = new System.Drawing.Size(1218, 684);
            this.picResizer.TabIndex = 0;
            this.picResizer.TabStop = false;
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.AutoSize = true;
            this.lblAppTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(25)))), ((int)(((byte)(42)))));
            this.lblAppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppTitle.ForeColor = System.Drawing.Color.Yellow;
            this.lblAppTitle.Location = new System.Drawing.Point(46, 28);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(364, 37);
            this.lblAppTitle.TabIndex = 1;
            this.lblAppTitle.Text = "Gregory Family Library";
            // 
            // lvMain
            // 
            this.lvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.lvMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mediaName,
            this.runTime});
            this.lvMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMain.ForeColor = System.Drawing.Color.White;
            this.lvMain.FullRowSelect = true;
            this.lvMain.HideSelection = false;
            this.lvMain.Location = new System.Drawing.Point(47, 76);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(1184, 601);
            this.lvMain.TabIndex = 2;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            // 
            // mediaName
            // 
            this.mediaName.Text = "Name";
            this.mediaName.Width = 980;
            // 
            // runTime
            // 
            this.runTime.Text = "Run Time";
            this.runTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.runTime.Width = 140;
            // 
            // lblCurRunTime
            // 
            this.lblCurRunTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurRunTime.AutoSize = true;
            this.lblCurRunTime.BackColor = System.Drawing.Color.Transparent;
            this.lblCurRunTime.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurRunTime.ForeColor = System.Drawing.Color.Yellow;
            this.lblCurRunTime.Location = new System.Drawing.Point(798, 641);
            this.lblCurRunTime.Name = "lblCurRunTime";
            this.lblCurRunTime.Size = new System.Drawing.Size(433, 36);
            this.lblCurRunTime.TabIndex = 3;
            this.lblCurRunTime.Text = "Gregory Family Library";
            this.lblCurRunTime.Visible = false;
            // 
            // tmrShowRuntime
            // 
            this.tmrShowRuntime.Tick += new System.EventHandler(this.tmrShowRuntime_Tick);
            // 
            // tmrEndReached
            // 
            this.tmrEndReached.Interval = 250;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(25)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.lblCurRunTime);
            this.Controls.Add(this.lvMain);
            this.Controls.Add(this.lblAppTitle);
            this.Controls.Add(this.picResizer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picResizer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picResizer;
        private System.Windows.Forms.Label lblAppTitle;
        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.ColumnHeader mediaName;
        private System.Windows.Forms.ColumnHeader runTime;
        private System.Windows.Forms.Label lblCurRunTime;
        private System.Windows.Forms.Timer tmrShowRuntime;
        private System.Windows.Forms.Timer tmrEndReached;
    }
}

