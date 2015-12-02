using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordPressSharp;
using WordPressSharp.Models;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Threading;

// http://stackoverflow.com/questions/1766610/how-to-store-int-array-in-application-settings

namespace WPUpCheck
{
    public partial class Form1 : Form
    {
        private double timerTickCount = 0;
        private DispatcherTimer timer;

        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("1");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("12");
            comboBox1.Items.Add("24");

            // Set the images to blank
            imgCore.Visible = false;
            imgPlugins.Visible = false;
            imgThemes.Visible = false;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1); // will 'tick' once every second
            timer.Tick += new EventHandler(Timer_Tick);

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            Debug.Write("Local user config path: {0}", config.FilePath);
            Debug.Write("Config file: " + AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.ToString() + "\n");

            if (Properties.Settings.Default["waittime"].ToString() != "0") // FIXME: how to test to see if waittime is set for first run?
            {
                Debug.Write("Wait time loaded from properties: " + Properties.Settings.Default["waittime"].ToString() + "\n");
                comboBox1.SelectedItem = Properties.Settings.Default["waittime"].ToString();
            }
            else
            {
                Debug.Write("Setting default waittime\n");
                comboBox1.SelectedItem = "24";
            }

            if (Properties.Settings.Default.sitesList == null)
            {
                Debug.Write("BaseURL not set, aborting!\n");
                button1.Enabled = false;
                MessageBox.Show("Can't proceed until you've set a site - see Options menu");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkUpdates();
        }

        private Int32 getWaitTime()
        {
            var waittime = Int32.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));
            
            return waittime;
        }

        async private void checkUpdates()
        {
            timer.Start();

            // Set the images to blank
            imgCore.Visible = false;
            imgPlugins.Visible = false;
            imgThemes.Visible = false;

            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.Maximum = 100;
            progressBar.Value = 5;

            string BaseUrl = Properties.Settings.Default.sitesList[0].BaseUrl.ToString();
            string Username = Properties.Settings.Default.sitesList[0].Username.ToString();
            string Password = Properties.Settings.Default.sitesList[0].Password.ToString();

            corecheck.Text = plugincheck.Text = themecheck.Text = "Checking...";

            FormOptions Options = new FormOptions();

            // WordPressSharp: https://github.com/abrudtkuhl/WordPressSharp
            using (var client = new WordPressClient(new WordPressSiteConfig
            {
                BaseUrl = BaseUrl,
                Username = Username,
                Password =  Options.DecryptString(Password),
                BlogId = 1
            }))
            {

                //var id = Convert.ToInt32(client.NewPost(post));
                //var username = Convert.ToString(client.GetUser(1).Nicename);
                //var plugins = Convert.ToString(client.GetPluginUpdateCheck());

                // Close off the Options object, only needed to Decrypt Password
                Options = null;

                var thereAreUpdates = false;

                progressBar.Value = 40;

                var response = client.GetAllUpdatesCheck();

                if (response.core)
                {
                    corecheck.Text = "Core updates!";
                    thereAreUpdates = true;
                    imgCore.Image = Properties.Resources.error;
                    imgCore.Visible = true;
                }
                else
                {
                    corecheck.Text = "No updates for Core.";
                    imgCore.Image = Properties.Resources.check;
                    imgCore.Visible = true;
                }

                if (response.plugins)
                {
                    plugincheck.Text = "Plugin Updates!";
                    thereAreUpdates = true;
                    imgPlugins.Image = Properties.Resources.error;
                    imgPlugins.Visible = true;
                }
                else
                {
                    plugincheck.Text = "No updates for Plugins.";
                    imgPlugins.Image = Properties.Resources.check;
                    imgPlugins.Visible = true;
                }

                if (response.themes)
                {
                    themecheck.Text = "Theme updates!";
                    thereAreUpdates = true;
                    imgThemes.Image = Properties.Resources.error;
                    imgThemes.Visible = true;
                }
                else
                {
                    themecheck.Text = "No updates for Themes.";
                    imgThemes.Image = Properties.Resources.check;
                    imgThemes.Visible = true;
                }

                if (thereAreUpdates == true)
                {
                    //if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.notifyIcon1.BalloonTipText = "There are some updates! Double click me to check the details.";
                        this.notifyIcon1.BalloonTipTitle = "Updates!";
                        this.notifyIcon1.Visible = true;
                        this.notifyIcon1.ShowBalloonTip(3000);
                    }
                }

                progressBar.Value = 100;

                //var plugins = Convert.ToString(client.GetAllUpdatesCheck());

                //plugincheck.Text = username;
                //plugincheck.Text = plugins;

                // Figure out next run time

                var numHours = Int32.Parse(comboBox1.GetItemText(comboBox1.SelectedItem));
                var nextTime = DateTime.Now.AddHours(numHours);
                //var nextTime = DateTime.Now.AddMinutes(numHours); // FIXME!! should be hours

                labelNextRun.Text = nextTime.ToString();

                timerTickCount = DateTimeToUnixTimestamp(nextTime) - DateTimeToUnixTimestamp(DateTime.Now);
                
                await Task.Delay(getWaitTime() * 3600 * 1000);
                //await Task.Delay(getWaitTime() * 60 * 1000);
                checkUpdates();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timerTickCount = timerTickCount - 1;
            countdownBox.Text = "Next run in: " + Math.Round(timerTickCount).ToString() + " seconds.";
        }

        // http://stackoverflow.com/questions/249760/how-to-convert-unix-timestamp-to-datetime-and-vice-versa
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // http://stackoverflow.com/questions/453161/best-practice-to-save-application-settings-in-a-windows-forms-application
            Properties.Settings.Default["waittime"] = getWaitTime();
            Properties.Settings.Default.Save();

            Debug.Write("Saved waittime default to " + getWaitTime() + "\n");
        }

        private void wordPressSitesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions Options = new FormOptions();
            Options.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // http://stackoverflow.com/questions/7625421/minimize-app-to-system-tray
            
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;

                // http://stackoverflow.com/questions/3181594/handling-a-click-over-a-balloon-tip-displayed-with-trayicons-showballoontip
                notifyIcon1.BalloonTipClicked += new EventHandler(notifyIcon_BalloonTipClicked);
            }
        }

        void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Show(); 
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.sitesList != null && Properties.Settings.Default.sitesList.Count() > 0)
            {
                /*
                targetSiteLabel.Text = Properties.Settings.Default["wpUrl"].ToString();
                LinkLabel.Link link = new LinkLabel.Link();
                link.LinkData = Properties.Settings.Default["wpUrl"].ToString();
                targetSiteLabel.Links.Add(link);
                 */

                UpdateCurrentSiteLabel(Properties.Settings.Default.sitesList[0].BaseUrl.ToString(), Properties.Settings.Default.sitesList[0].BaseUrl.ToString());
            }
        }

        private void targetSiteLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url;
            if (e.Link.LinkData != null)
            {
                url = e.Link.LinkData.ToString();
                Debug.Write("Opening URL" + url + "\n");
                ProcessStartInfo sInfo = new ProcessStartInfo(url);
                Process.Start(sInfo);
            }
        }

        public void UpdateCurrentSiteLabel(string txt, string url)
        {
            if (txt != "")
            {
                targetSiteLabel.Text = txt;
                //targetSiteLabel.Text = "http://example.com";
                LinkLabel.Link link = new LinkLabel.Link();
                link.LinkData = url + "/wp-admin/";
                targetSiteLabel.Links.RemoveAt(0); // FIXME: leaving this out causes a weird exception.
                targetSiteLabel.Links.Add(link);
            }
        }

        private void optionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormOptions Options = new FormOptions();
            Options.FormClosing += new FormClosingEventHandler(FormOptions_Close);
            Options.ShowDialog();
        }

        void FormOptions_Close(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.sitesList != null && Properties.Settings.Default.sitesList.Count() > 0)
            {
                UpdateCurrentSiteLabel(Properties.Settings.Default.sitesList[0].BaseUrl.ToString(), Properties.Settings.Default.sitesList[0].BaseUrl.ToString());
                button1.Enabled = true;
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormOptions Options = new FormOptions();
            Options.FormClosing += new FormClosingEventHandler(FormOptions_Close);
            Options.ShowDialog();
        }

        private void imgCore_Click(object sender, EventArgs e)
        {
            //Debug.Write(
            //imgCore.Image = Properties.Resources.check;
        }

    }
}
