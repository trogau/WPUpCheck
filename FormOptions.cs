using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using WordPressSharp;

namespace WPUpCheck
{
    public partial class FormOptions : Form
    {
        BindingList<string> _sites = new BindingList<string>();

        // http://weblogs.asp.net/jongalloway/encrypting-passwords-in-a-net-app-config-file
        static byte[] entropy = System.Text.Encoding.Unicode.GetBytes("fam4kjfa,mndfaklj4k2jfkdsjfkdl");

        public FormOptions()
        {
            InitializeComponent();

            if (Properties.Settings.Default.sitesList != null)
            {
                //credentialsList[0, 0].Value = Properties.Settings.Default.sitesList.BaseUrl.ToString();
            }

            /*if (Properties.Settings.Default["wpURL"].ToString() != "")
            {
                optionWordPressURL.Text = Properties.Settings.Default["wpURL"].ToString();
                optionWordPressUsername.Text = Properties.Settings.Default["wpUsername"].ToString();

                Debug.Print("Saved Pass: " + Properties.Settings.Default["wpPassword"].ToString());

                var cptext = Properties.Settings.Default["wpPassword"].ToString();

                optionWordPressPassword.Text = DecryptString(cptext);
            }
             */

        }

        public String DecryptString(String ciphertext)
        {
            byte[] cryptedtext = System.Convert.FromBase64String(ciphertext);
            byte[] plaintextbytes = ProtectedData.Unprotect(cryptedtext, entropy, DataProtectionScope.CurrentUser);

            // Convert byte[] back to string - http://stackoverflow.com/questions/1003275/how-to-convert-byte-to-string
            String plaintext = System.Text.Encoding.UTF8.GetString(plaintextbytes);
            return plaintext;
        }


        private void OptionsSave_Click(object sender, EventArgs e)
        {
            // Encrypt the password - http://stackoverflow.com/questions/12657792/how-to-securely-save-username-password-local
            byte[] clearPassword = Encoding.UTF8.GetBytes(optionWordPressPassword.Text);
            byte[] ciphertext = ProtectedData.Protect(clearPassword, entropy, DataProtectionScope.CurrentUser);

            WordPressSiteConfig config = new WordPressSiteConfig();

            config.BaseUrl = optionWordPressURL.Text;
            config.Username = optionWordPressUsername.Text;
            config.Password = System.Convert.ToBase64String(ciphertext);
            config.BlogId = 1;

            if (Properties.Settings.Default.sitesList == null)
            { 
                Properties.Settings.Default.sitesList = new List<WordPressSiteConfig>();
            }
            Properties.Settings.Default.sitesList.Add(config);

            Debug.Write(config.BaseUrl.ToString() + "\n");

            Properties.Settings.Default.Save();

            _sites.Add(optionWordPressURL.Text);
            siteListBox.DataSource = _sites;
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.sitesList != null && Properties.Settings.Default.sitesList.Count() > 0)
            {
                Debug.Write("Count: " + Properties.Settings.Default.sitesList.Count());
                Debug.Write(Properties.Settings.Default.sitesList[0].BaseUrl.ToString());
                //return;
                foreach (WordPressSiteConfig site in Properties.Settings.Default.sitesList)
                {
                    Debug.Write("Site:" + site.BaseUrl.ToString());
                    _sites.Add(site.BaseUrl.ToString());
                    siteListBox.DataSource = _sites;
                }
            }
            else { Debug.Write("No site configs at the moment\n");  }
        }

        private void editSiteButton_Click(object sender, EventArgs e)
        {
            optionWordPressURL.Text = Properties.Settings.Default.sitesList[0].BaseUrl.ToString();
            optionWordPressUsername.Text = Properties.Settings.Default.sitesList[0].Username.ToString();
            optionWordPressPassword.Text = DecryptString(Properties.Settings.Default.sitesList[0].Password.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Remove from settings first, otherwise the selected index updates in the listbox when it's removed, removing
            // the wrong one (maybe?)
            int idx = 0;

            foreach (WordPressSiteConfig site in Properties.Settings.Default.sitesList)
            {
                Debug.Write("IDX: " + idx.ToString() + "| Comparing " + site.BaseUrl.ToString() + "with" + siteListBox.GetItemText(siteListBox.SelectedItem) + "\n");

                if (site.BaseUrl.ToString() == siteListBox.GetItemText(siteListBox.SelectedItem))
                {
                    Debug.Write("FOUND: " + site.BaseUrl.ToString() + "\n");
                    Properties.Settings.Default.sitesList.RemoveAt(idx);
                    break;
                }
                idx++;
            }

            //_sites.Remove(Properties.Settings.Default.sitesList.BaseUrl.ToString());
            _sites.RemoveAt(siteListBox.SelectedIndex);
            siteListBox.DataSource = _sites;

            //Properties.Settings.Default.sitesList[0].BaseUrl.ToString();


            Properties.Settings.Default.Save();
        }



        /*
 *      private void SaveCellData(object sender, DataGridViewCellEventArgs e)
        {
            Debug.Write("* Col: " + e.ColumnIndex.ToString() + "Row: " + e.RowIndex.ToString() + " VALUE: " + credentialsList[e.ColumnIndex, e.RowIndex].Value.ToString() + "\n");
            WordPressSiteConfig config = new WordPressSiteConfig();

            if (e.ColumnIndex == 0)
            {
                Debug.Write("Saved URL\n");
                config.BaseUrl = credentialsList[0, 0].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                Debug.Write("Saved username\n");
                config.Username = credentialsList[1, 0].Value.ToString();
            }
            if (e.ColumnIndex == 2)
            {
                Debug.Write("Saved password\n");
                config.Password = credentialsList[2, 0].Value.ToString();
            }

            config.BlogId = 1;
            Properties.Settings.Default["sitesList"] = config;
            Debug.Write(config.BaseUrl + "------------\n");
            Properties.Settings.Default.Save();
        }
 */
    }
}
