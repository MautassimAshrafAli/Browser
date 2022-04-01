using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using System.Security.Policy;
using System.Diagnostics;
using valuse__;
using System.Threading;

namespace we_browser_
{
    public partial class Near_Browser : Form
    {

        ChromiumWebBrowser chrom;
        public string url_search;

        public Near_Browser()
        {
            InitializeComponent();


            if (!Directory.Exists(@"C:\NEAR_OS\Default\Cache"))
            {
                Directory.CreateDirectory(@"C:\NEAR_OS\Default\Cache");
            }

            //Initialized cef
            Task.Factory.StartNew(() =>
            {
                if (Cef.IsInitialized == false)
                {
                    CefSettings settings = new CefSettings();
                    settings.UserAgent = "Mozilla/5.0(Macintosh; Intel Mac OS X 12_0_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.78 Safari/537.36";
                    settings.CachePath = @"C:\NEAR_OS\Default\Cache";
                    settings.CefCommandLineArgs.Add("disable-gpu", "1");
                    Cef.Initialize(settings);
                }
            }).Wait();

            #region SetDoubleBuffering
            SetDoubleBuffering.SetDoubleBuffering_(my_site, true);
            SetDoubleBuffering.SetDoubleBuffering_(close_p, true);
            SetDoubleBuffering.SetDoubleBuffering_(min_nor_p, true);
            SetDoubleBuffering.SetDoubleBuffering_(min_p, true);
            SetDoubleBuffering.SetDoubleBuffering_(panel5, true);
            SetDoubleBuffering.SetDoubleBuffering_(panel6, true);
            SetDoubleBuffering.SetDoubleBuffering_(panel7, true);
            SetDoubleBuffering.SetDoubleBuffering_(panel1, true);
            SetDoubleBuffering.SetDoubleBuffering_(panel9, true);
            SetDoubleBuffering.SetDoubleBuffering_(panel10, true);
            SetDoubleBuffering.SetDoubleBuffering_(Messenger_p, true);
            SetDoubleBuffering.SetDoubleBuffering_(Whatsapp_p, true);
            SetDoubleBuffering.SetDoubleBuffering_(Facrbook_p, true);
            SetDoubleBuffering.SetDoubleBuffering_(Youtube_p, true);
            SetDoubleBuffering.SetDoubleBuffering_(user_img_, true);

            #endregion

            this.TopMost = true;
            this.KeyPreview = true;
            this.CenterToScreen();

            statuse.Text = char.ConvertFromUtf32(0xE001);
            statuse.ForeColor = Color.GreenYellow;

            Guna.UI.Lib.GraphicsHelper.ShadowForm(this);
        }

        #region search

        private void search()
        {
            GoHome = false;

            if (my_site.Visible != true)
            {
                chrom = new ChromiumWebBrowser(url_search);
                my_site.BackColor = Color.FromArgb(21, 21, 21);
                my_site.Visible = true;
                my_site.Controls.Clear();
                my_site.Controls.Add(chrom);
                chrom.Dock = DockStyle.Fill;
            }
            else
            {
                chrom.Load(url_search);
            }

        }

        #endregion
        
        private void Near_Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == CloseReason.UserClosing;

            if(e.CloseReason == CloseReason.UserClosing)
            {

                Process currentProcess = Process.GetCurrentProcess();
                string pid = (currentProcess.Id).ToString();

                kill_procces.kill_pro_by_id(pid);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();
            string pid = (currentProcess.Id).ToString();

            kill_procces.kill_pro_by_id(pid);
        }

        private void max_nor_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {

                this.WindowState = FormWindowState.Maximized;
                max_nor.Image = Properties.Resources.icons8_restore_down_32px;

            }
            else
            {

                this.WindowState = FormWindowState.Normal;
                max_nor.Image = Properties.Resources.icons8_maximize_button_32px_1;

            }
        }

        private void min_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;

        }

        private void url_check()
        {
            Task.Delay(5);

            url_image_IsStart = true;

            Task.Factory.StartNew(() =>
            {
                GoHome = true;
                url_img_Tick();
                load_Tick();

                user_img_.ImageLocation = @"C:\ProgramData\Microsoft\User Account Pictures\user.png";

            }).Wait();

            gunaResizeControl1.Invoke((MethodInvoker)delegate
            {
                gunaResizeControl1.Visible = true;
            });

            string[] args_ = Environment.GetCommandLineArgs();
            foreach (string a in args_)
            {

                switch (a)
                {
                    case "https://www.youtube.com/":
                    case "www.youtube.com/":
                    case "https://web.whatsapp.com/":
                    case "https://www.facebook.com/":
                    case "https://www.messenger.com/":
                    case "https://www.google.com/":
                    case "https://www.google.com/gmail/":
                    case "https://www.youtube.com":
                    case "www.facebook.com/":
                    case "www.messenger.com/":
                    case "www.google.com/":
                    case "www.google.com/gmail/":
                    case "www.youtube.com":
                    case "https://calendar.google.com/calendar/r?tab=rc&pli=1":
                    case "https://drive.google.com/drive/my-drive":
                    case "https://www.google.com/earth/":
                    case "https://www.google.com/maps":
                    case "www.google.com/earth/":
                    case "www.google.com/maps":
                    case "https://photos.google.com/?tab=lq&pageId=none":
                    case "https://play.google.com/store?hl=en&tab=q8":
                    case "https://translate.google.com.eg/?hl=en&tab=8T":
                    case "https://twitter.com/":
                    case "https://soundcloud.com/":
                    case "https://www.instagram.com/?hl=en":
                    case "https://www.spotify.com/us/":
                    case "www.mixcloud.com/":
                    case "www.instagram.com/?hl=en":
                    case "www.spotify.com/us/":
                    case "https://audiomack.com/":
                    case "https://tidal.com/featured":
                    case "https://myaccount.google.com/lesssecureapps":
                    case string x when x.Contains("https://www.google.com/search?q="):
                    case string x2 when x2.Contains("www.google.com/search?q="):
                    case "https://www.google.com/webhp?hl=en&sa=X&ved=0ahUKEwjLhJrixInvAhWNyYUKHSZdBJoQPAgI":
                    case "www.google.com/webhp?hl=en&sa=X&ved=0ahUKEwjLhJrixInvAhWNyYUKHSZdBJoQPAgI":

                        url_search = a;
                        search();

                        break;

                    default:

                        url_top.Text = "Search or type a Url";

                        break;
                }



            }
        }

        #region enum chrome op
        private enum chrome_button_switch{

            back,
            forward,
            reload

        }

        private chrome_button_switch chrom_chose(chrome_button_switch type) {

            switch (type)
            {
                case chrome_button_switch.back:
                    if (chrom.IsBrowserInitialized)
                    {
                        chrom.Back();
                    }
                    break;
                case chrome_button_switch.forward:
                    if (chrom.IsBrowserInitialized)
                    {
                        chrom.Forward();
                    }
                    break;
                case chrome_button_switch.reload:
                    if (chrom.IsBrowserInitialized)
                    {
                        chrom.Reload();
                    }
                    break;
                default:
                    break;
            }

            return type;

        }

        #endregion

        #region chrom op

        private void back_Click(object sender, EventArgs e)
        {

            try
            {
                chrom_chose(chrome_button_switch.back);
            }
            catch (Exception)
            {}

        }

        private void forward_Click(object sender, EventArgs e)
        {

            try
            {
                chrom_chose(chrome_button_switch.forward);
            }
            catch (Exception)
            {}

           
        }

        private void refrech_Click(object sender, EventArgs e)
        {

            try
            {
                chrom_chose(chrome_button_switch.reload);
            }
            catch (Exception)
            { 
            }

          
        }

        #endregion

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
                Application.OpenForms[this.Name].Focus();
                TopMost = false;    

                url_check();
                timer4.Stop();
            }
        }

        private void a_h_Tick(object sender, EventArgs e)
        {
            this.Opacity -= .1;

            if (this.Opacity < .90)
            {

                a_h.Stop();

            }
        }

        private void browser_MouseDown(object sender, MouseEventArgs e)
        {
            a_h.Start();
        }

        private void browser_MouseUp(object sender, MouseEventArgs e)
        {

            timer4.Start();

        }

        #region home
        bool GoHome;
        private void home_Click(object sender, EventArgs e)
        {
            GoHome = true;
            chrom.Reload();
            chrom.Controls.Clear();
            my_site.Controls.Clear();
            my_site.Visible = false;

        }
        #endregion

        #region browser op

        private void Facrbook_btn_MouseEnter(object sender, EventArgs e)
        {
            l_f.ForeColor = Color.White;
        }

        private void Facrbook_btn_MouseLeave(object sender, EventArgs e)
        {
            l_f.ForeColor = Color.DimGray;
        }

        private void Messenger_btn_MouseEnter(object sender, EventArgs e)
        {
            l_m.ForeColor = Color.White;
        }

        private void Messenger_btn_MouseLeave(object sender, EventArgs e)
        {
            l_m.ForeColor = Color.DimGray;
        }

        private void Whatsapp_btn_MouseEnter(object sender, EventArgs e)
        {
            l_w.ForeColor = Color.White;
        }

        private void Whatsapp_btn_MouseLeave(object sender, EventArgs e)
        {
            l_w.ForeColor = Color.DimGray;
        }

        private void Youtube_btn_MouseEnter(object sender, EventArgs e)
        {
            l_y.ForeColor = Color.White;
        }

        private void Youtube_btn_MouseLeave(object sender, EventArgs e)
        {
            l_y.ForeColor = Color.DimGray;
        }

        private void Facrbook_btn_Click(object sender, EventArgs e)
        {

            if (Cef.IsInitialized == true)
            {
                url_search = "https://www.facebook.com/";
                search();
            }

        }
        
        private void Messenger_btn_Click(object sender, EventArgs e)
        {

            if (Cef.IsInitialized == true)
            {
                
                url_search = "https://www.messenger.com/";
                search();
            }

        }

        private void Whatsapp_btn_Click(object sender, EventArgs e)
        {
            if (Cef.IsInitialized == true)
            {
                url_search = "https://web.whatsapp.com/";
                search();
            }
        }

        private void Youtube_btn_Click(object sender, EventArgs e)
        {
            if (Cef.IsInitialized == true)
            {
                url_search = "https://www.youtube.com/";
                search();
            }
        }

        #endregion

        #region search no link
        private void url_in_MouseEnter(object sender, EventArgs e)
        {
            if (url_in.Text == "Search")
            {
                url_in.Text = string.Empty;
                url_in.ForeColor = Color.Black;

            }

        }

        private void url_in_MouseLeave(object sender, EventArgs e)
        {

            if (url_in.Text == string.Empty)
            {

                url_in.Text = "Search";
                url_in.ForeColor = Color.DimGray;

            }
        }

        private void url_in_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (Cef.IsInitialized == true)
                {
                    url_search = "https://www.google.com/search?q=" + url_in.Text;
                    search();
                }
            }
        }
       
        private void url_in_MouseUp(object sender, MouseEventArgs e)
        {
            if (url_top.Text == string.Empty)
            {

                url_top.ForeColor = Color.DarkGray;
                url_top.Text = "Search";

            }
            else
            {

                url_top.ForeColor = Color.DarkGray;

            }
        }

        #endregion

        #region image search
  
        private void search_image_MouseEnter(object sender, EventArgs e)
        {
            search_img.ForeColor = Color.White;
        }

        private void search_image_MouseLeave(object sender, EventArgs e)
        {
            search_img.ForeColor = Color.DimGray;
        }

        #endregion

        #region gmail

        private void gmail_MouseEnter(object sender, EventArgs e)
        {
            gmail.ForeColor = Color.White;
        }

        private void gmail_MouseLeave(object sender, EventArgs e)
        {
            gmail.ForeColor = Color.DimGray;
        }
        
        private void gmail_Click(object sender, EventArgs e)
        {

            if (Cef.IsInitialized == true)
            {
                url_search = "https://accounts.google.com/";
                search();
            }

        }
     

        #endregion

        private void youtube_IsOpen() {
            Task.Factory.StartNew(() =>
            {

                if ((url_top.Text.Contains("https://www.youtube.com/watch?v="))
                || (url_top.Text.Contains("www.youtube.com/watch?v=")))
                {
                    youtube_popup_p.Invoke((MethodInvoker)delegate { 

                    youtube_popup_p.Visible = true;

                    });
                }
                else
                {
                    youtube_popup_p.Invoke((MethodInvoker)delegate
                    {
                        youtube_popup_p.Visible = false;
                    });
                }
            });
        }

        #region url by link / search

        private void url_top_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                e.SuppressKeyPress = true;


                if (Cef.IsInitialized == true)
                {
                    if (url_top.Text.Contains("https://soundcloud.com/"))
                    {
                        url_search = "https://soundcloud.com/search?q=" + url_top.Text.Replace("https://soundcloud.com/", "");
                        search();

                    }
                    else if ((!url_top.Text.Contains("https://www."))
                        || (!url_top.Text.Contains("www.")))
                    {


                        if (url_top.Text.Contains("https://web."))
                        {

                            url_search = url_top.Text;
                            search();

                        }

                        else if (url_top.Text.Contains("https://calendar.google.com"))
                        {
                            url_search = url_top.Text;
                            search();

                        }
                        else if (url_top.Text.Contains("https://drive.google.com"))
                        {
                            url_search = url_top.Text;
                            search();

                        }
                        else if (url_top.Text.Contains("https://photos.google.com"))
                        {

                            url_search = url_top.Text;
                            search();

                        }
                        else if (url_top.Text.Contains("https://play.google.com"))
                        {

                            url_search = url_top.Text;
                            search();

                        }
                        else if (url_top.Text.Contains("https://translate.google.com.eg"))
                        {

                            url_search = url_top.Text;
                            search();

                        }
                        else if (url_top.Text.Contains("https://myaccount.google.com/lesssecureapps"))
                        {

                            url_search = url_top.Text;
                            search();

                        }
                        else
                        {
                            url_search = "https://www.google.com/search?q=" + url_top.Text;
                            search();

                        }
                    }
                    else
                    {
                        if ((url_top.Text.Contains("https://www.google.com/earth/"))
                             || (url_top.Text.Contains("www.google.com/earth/")))
                        {

                            url_search = url_top.Text;
                            search();

                        }
                        else if ((url_top.Text.Contains("https://www.google.com/maps"))
                            || (url_top.Text.Contains("www.google.com/maps")))
                        {

                            url_search = url_top.Text;
                            search();

                        }
                        else if ((url_top.Text.Contains("https://www.google.com"))
                            || (url_top.Text.Contains("www.google.com")))
                        {

                            url_search = url_top.Text;
                            search();

                        }
                    }
                }

            }


        }
        
        private void url_top_MouseEnter(object sender, EventArgs e)
        {
            if (url_top.Text == "Search or type a Url")
            {
                url_top.Text = string.Empty;
                url_top.ForeColor = Color.White;
            }
        }

        private void url_top_MouseLeave(object sender, EventArgs e)
        {
            if (url_top.Text == string.Empty)
            {
                url_top.Text = "Search or type a Url";
                url_top.ForeColor = Color.DimGray;
            }

        }
 
        private void url_top_MouseUp(object sender, MouseEventArgs e)
        {
            if (url_in.Text == string.Empty)
            {

                url_in.ForeColor = Color.FromArgb(117, 117, 117);
                url_in.Text = "Search";

            }
            else
            {
                url_in.ForeColor = Color.FromArgb(117, 117, 117);
            }
        }

        #endregion

        #region chrome icon / title / stause / addres

        bool url_image_IsStart;
      
        private void url_img_Tick()
        {
            Task.Factory.StartNew(() =>
            {
                while (url_image_IsStart)
                {
                    Thread.Sleep(100);

                    try
                    {
                        if (GoHome != true)
                        {
                            if (chrom.IsBrowserInitialized)
                            {
                                youtube_IsOpen();

                                icon.ImageLocation = "http://" + new Uri(chrom.Address.ToString()).Host + "/favicon.ico";
                                icon.ErrorImage = Properties.Resources.icons8_globe_20px_1;
                                icon.InitialImage = Properties.Resources.icons8_globe_20px_1;

                                chrom.FrameLoadStart += OnFrameLoadStart;
                                chrom.FrameLoadEnd += endFrameLoadStart;
                                chrom.LoadError += error_load;
                                chrom.TitleChanged += titel_;
                            }
                        }
                        else
                        {
                            icon.ImageLocation = null;
                            icon.Image = Properties.Resources.icons8_home_32px;

                        }
                        Thread.Sleep(1);

                    }
                    catch (Exception)
                    { }

                }


            });
        }

        private void titel_(object sender, TitleChangedEventArgs e)
        {
                if (GoHome != true)
                {
                this.Invoke((MethodInvoker)delegate
                {

                    url_top.Text = chrom.Address;



                    if (e.Title.Length >= 12)
                    {

                        panel13.Dock = DockStyle.Fill;
                        title.Text = e.Title;
                    }
                    else
                    {

                        panel13.Dock = DockStyle.None;
                        panel13.Anchor = AnchorStyles.None;
                        title.Text = e.Title;
                    }
                });
                }
                else {

                this.Invoke((MethodInvoker)delegate
                {
                    url_top.Text = "Search or type a Url";
                    url_in.Text = "Search";
                    url_in.ForeColor = Color.DimGray;
                    title.Text = "Home";
                    panel13.Dock = DockStyle.None;
                    panel13.Anchor = AnchorStyles.None;

                });

                }
        }
     
        private void endFrameLoadStart(object sender, FrameLoadEndEventArgs e)
        {
            statuse.Invoke((MethodInvoker)delegate{

            statuse.Text = char.ConvertFromUtf32(0xE001);
            statuse.ForeColor = Color.GreenYellow;

            });
        }

        private void OnFrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            statuse.Invoke((MethodInvoker)delegate
            {

                statuse.Text = char.ConvertFromUtf32(0xE2AD);
                statuse.ForeColor = Color.Gold;
            });

        }
      
        private void error_load(object sender, LoadErrorEventArgs e)
        {

            statuse.Invoke((MethodInvoker)delegate
            {

                statuse.Text = char.ConvertFromUtf32(0xEB90);
                statuse.ForeColor = Color.Firebrick;
            });
        }

        private void load_Tick()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(100);
                    if(url_top.Text != "Search or type a Url")
                    {
                        url_top.ForeColor = Color.White;
                    }
                    else
                    {
                        youtube_popup_p.Invoke((MethodInvoker)delegate
                        {
                            youtube_popup_p.Visible = false;
                        });

                        url_top.ForeColor = Color.DimGray;
                    }

                }
            });
        }

        #endregion

        #region keyboard

        private void p_key_MouseEnter(object sender, EventArgs e)
        {
            p_key.BaseColor = Color.FromArgb(58, 58, 58);
        }

        private void p_key_MouseLeave(object sender, EventArgs e)
        {
            p_key.BaseColor = Color.Transparent;
        }

        private void keyboard_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(V.keyboard_path());
        }

        #endregion

        #region new browser

        private void new_web_p_MouseEnter(object sender, EventArgs e)
        {
            new_web_p.BaseColor = Color.FromArgb(58, 58, 58);
        }

        private void new_web_p_MouseLeave(object sender, EventArgs e)
        {
            new_web_p.BaseColor = Color.Transparent;
        }

        private void new_web_Click(object sender, EventArgs e)
        {
            V.new_web_t();
        }

        #endregion

        #region exit

        private void exit_p_MouseEnter(object sender, EventArgs e)
        {
            exit_p.BaseColor = Color.FromArgb(58, 58, 58);
        }

        private void exit_p_MouseLeave(object sender, EventArgs e)
        {
            exit_p.BaseColor = Color.Transparent;
        }
    
        private void exit_Click(object sender, EventArgs e)
        {
            try
            {
                chrom_chose(chrome_button_switch.reload);
            }
            catch (Exception)
            { }

            Process currentProcess = Process.GetCurrentProcess();
            string pid = (currentProcess.Id).ToString();

            kill_procces.kill_pro_by_id(pid);

        }

        #endregion

        private void label6_Click(object sender, EventArgs e)
        {
            V.new_web_t();

        }
        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            open_google_p.BaseColor = Color.FromArgb(58, 58, 58);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            open_google_p.BaseColor = Color.Transparent;
        }

        #region open chrome browser

        private void open_google_Click(object sender, EventArgs e)
        {
            if (url_top.Text != "Search or type a Url")
            {
                System.Diagnostics.Process.Start("chrome.exe", url_top.Text);

            }
        }

        #endregion

        private void Near_Browser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.M)
            {
                e.SuppressKeyPress = true;

                this.WindowState = FormWindowState.Minimized;

            }
        }
      
        #region youtube popup not work
       
        public static string turl;
     
        private void youtube_popup_btn_Click(object sender, EventArgs e)
        {
            try
            {

                turl = url_top.Text;

            }
            catch (Exception)
            {
            }

            if ((url_top.Text.Contains("https://www.youtube.com/watch?v="))
                || (url_top.Text.Contains("www.youtube.com/watch?v=")))
            {

                invoke_key.KeyDown_(Keys.K);
                invoke_key.KeyUp_(Keys.K);

                Task.Delay(3);

                bool y_v = false;

                for (int i = 0; i < Application.OpenForms.Count; i++)
                {

                    Form n = Application.OpenForms[i];
                    if ((n.Name == "youtube_v"))
                    {
                        n.Close();
                        youtube_v yv = new youtube_v();
                        yv.Show();
                        y_v = true;

                    }

                    System.Threading.Thread.Sleep(1);
                }
                if (!y_v)
                {

                    youtube_v yv = new youtube_v();
                    yv.Show();


                }

                Task.Delay(3);

                WindowState = FormWindowState.Minimized;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        #endregion

    }
}
