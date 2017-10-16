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

namespace FBAPP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        public static bool isLogin = false;
        public static bool isbackfromlogin = false;
        OpenFileDialog openFile = new OpenFileDialog();

        private void frmMain_Load(object sender, EventArgs e)
        {
            btnLogin.PerformClick();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isLogin != true)
            {
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
            }
            else
            {
                lblAccountName.Text = FBClass.GetUserName(AppSettings.Default.AccessToken);
                string imgURL = String.Format("http://graph.facebook.com/{0}/picture", FBClass.GetUserID(AppSettings.Default.AccessToken));
                imgAccount.ImageLocation = imgURL;
            }
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            if (isbackfromlogin == true)
            {
                btnLogin_Click(null, null);
                isbackfromlogin = false;
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (FBClass.Post(AppSettings.Default.AccessToken, Postuj()))
            {
                MessageBox.Show("Wysłano");
            }
        }

        public string Postuj()
        {
            openFile.Filter = "Plik tekstowy (.txt)| *.txt";
            string line = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFile.FileName);
                while (!sr.EndOfStream)
                {
                    line += sr.ReadLine();
                }
                sr.Close();
                return line;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
