# Gregory Family Studio

A Custom User Interface for coordinating VLC with FLIRC (USB/Remote) for an easy to use home entertainment system.

When used with the FLIRC device, a user can access a home library of movies (in MP4 format) on a regular tv hooked to a computer with a videos directory all with  an old remote controller using the FLIRC USB device (available here https://flirc.tv/). 

ANY Remote Control ---> FLIRC USB on a PC (HDMI) ---> TV

Prerequisites:
◘ VLC Controls installed through NUGET<br/>
  https://github-wiki-see.page/m/ZeBobo5/Vlc.DotNet/wiki/Using-Vlc.DotNet-in-WinForms<br/>
◘ 64 bit VLC installed on host PC: <br/>
  https://www.videolan.org/vlc/download-windows.html<br/>

Things to know:
In FORM1.CS<br/>

<code>// Modify these to change title and initial directory. <br/>
        private string startDirectory = "e:\\videos";<br/>
        private string sAppTitle = "Gregory Family Library";<br/>
</code>
<br/>
Application Screenshot:<br/>
<img src="https://github.com/TimelordQ/GregoryFamilyStudio/blob/main/GregoryFamilyStudio.jpg">
