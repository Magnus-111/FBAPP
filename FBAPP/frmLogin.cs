using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FBAPP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string access_token;

        private void webFacebook_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webFacebook.Url.AbsoluteUri.Contains("access_token")) {
                string url1 = webFacebook.Url.AbsoluteUri;
                string url2 = url1.Substring(url1.IndexOf("access_token") + 13);
                access_token = url2.Substring(0, url2.IndexOf("&"));
                AppSettings.Default.AccessToken = access_token;

                frmMain.isLogin = true;
                frmMain.isbackfromlogin = true;

                this.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string OAuthURL = @"https://www.facebook.com/dialog/oauth?client_id="+AppSettings.Default.AppID+ "&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token&scope=" + AppSettings.Default.Scope;
            webFacebook.Navigate(OAuthURL);
        }
    }
}
