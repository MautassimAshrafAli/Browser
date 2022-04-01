using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace we_browser_
{
    public partial class youtube_v : Form
    {
        public youtube_v()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }

        string _yUrl;
        public string VideoID
        {
            get
            {
                var yMatch = new Regex(@"http(?:s?)://(?:www\.)?youtu(?:be\.com/watch\?v=|\.be/)([\w\-]+)(&(amp;)?[\w\?=]*)?").Match(_yUrl);
                return yMatch.Success ? yMatch.Groups[1].Value : string.Empty;
            }
        }

        private void youtube_v_Load(object sender, EventArgs e)
        {

            try
            {

                Rectangle desktoparea = Screen.PrimaryScreen.WorkingArea;
                this.Location = new Point(desktoparea.Width - this.Width, 300);

                Guna.UI.Lib.GraphicsHelper.ShadowForm(this);

                _yUrl = Near_Browser.turl;
                webBrowser1.DocumentText = String.Format(
                    "<meta http-equiv='X-UA-Compatible' content='IE=Edge'/>" +
                  "<iframe width=\"{1}\" height=\"{2}\"" +
                  " src=\"https://www.youtube.com/embed/{0}?autoplay=1\" title = \"YouTube video player\" frameborder=\"0\" allow = \"accelerometer; autoplay; clipboard - write; encrypted - media; gyroscope; picture -in-picture\" allowfullscreen scrolling='no'; encrypted-media; gyroscope;></iframe>", VideoID, webBrowser1.Width - 25, webBrowser1.Height - 20);


            }
            catch (Exception)
            {


            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {

                timer4.Stop();

            }

            if (this.Opacity < 1)
            {

                this.Opacity += .1;
            }
            else
            {
                timer4.Stop();


            }
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.Document.Body.Style = "overflow:hidden";
        }
    }
}
