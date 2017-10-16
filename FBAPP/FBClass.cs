using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;

namespace FBAPP
{
    class FBClass
    {
        public static string GetUserID(string AccessToken)
        {
            FacebookClient fb = new FacebookClient(AccessToken);
            fb.AppId = AppSettings.Default.AppID;
            fb.AppSecret = AppSettings.Default.AppSecret;
            dynamic data = fb.Get("/me");
            return data.id;
        }

        public static string GetUserName(string AccessToken)
        {
            FacebookClient fb = new FacebookClient(AccessToken);
            fb.AppId = AppSettings.Default.AppID;
            fb.AppSecret = AppSettings.Default.AppSecret;
            dynamic data = fb.Get("/me");
            return data.name;
        }

        public static bool Post(string AccessToken, string Status)
        {
            try
            {
                FacebookClient fb = new FacebookClient(AccessToken);
                Dictionary<string, object> PostArgs = new Dictionary<string, object>();
                PostArgs["message"] = Status;

                fb.Post("me/feed", PostArgs);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
