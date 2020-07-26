using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;

namespace ProcessImprovement.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private const string V = @" select * from users where username='";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Helps to open the Root level web.config file.
            Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
            //Modifying the AppKey from AppValue to AppValue1
            //webConfigApp.GetSection().AppSettings.Settings["AppKey"].Value = "AppValue1";

            //Save the Modified settings of AppSettings.
            webConfigApp.Save();

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            DoLogin();
            //DoLogin_BCrypt();
        }

        protected void DoLogin()
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();

                const string V1 = @" select * from users where username=@username";
                using (SqlCommand cmd = new SqlCommand(cmdText: V1, connection: conn))
                {
                    cmd.Parameters.AddWithValue("username", Username.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows && dr.Read())
                    {
                        String passwordFromDatabase = dr["password"].ToString();
                        if (String.Equals(passwordFromDatabase, Password.Text))
                        {
                            Session["isLoggedIn"] = 1;
                            Session["username"] = Username.Text;
                            Session["user_id"] = dr["id"];
                            Response.Write(dr["id"]);
                            RedirectionAfterLogin();
                            //RedirectionAfterLogin_Fixed();
                        }
                        else
                        {
                            html.Append("<b style='color:red'>Invalid credentials</b>");
                            LoginFormPage.Controls.Add(new Literal { Text = html.ToString() });
                            return;
                        }

                    }
                    else
                    {
                        html.Append("<b style='color:red'>Invalid credentials</b>");
                        LoginFormPage.Controls.Add(new Literal { Text = html.ToString() });
                        return;
                    }

                }
            }
        }

        protected void DoLogin_BCrypt()
        {
            StringBuilder html = new StringBuilder();

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (var conn = new SqlConnection(constr))
            {
                conn.Open();

                using (var cmd = new SqlCommand(V + Username.Text + "' ", conn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.HasRows && dr.Read())
                    {
                        String hashFromDatabase = dr["password"].ToString();
                        if (BCrypt.Net.BCrypt.Verify(Password.Text, hashFromDatabase))
                        {
                            Session["isLoggedIn"] = 1;
                            Session["username"] = Username.Text;
                            Session["user_id"] = dr["id"];
                            RedirectionAfterLogin();
                            //RedirectionAfterLogin_Fixed();
                        }
                        else
                        {
                            html.Append("<b style='color:red'>Invalid credentials</b>");
                            LoginFormPage.Controls.Add(new Literal { Text = html.ToString() });
                            return;
                        }

                    }
                    else
                    {
                        html.Append("<b style='color:red'>Invalid credentials</b>");
                        LoginFormPage.Controls.Add(new Literal { Text = html.ToString() });
                        return;
                    }
                    
                }
            }
        }

        public void RedirectionAfterLogin()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
            {
                Response.Redirect(Request.QueryString["returnUrl"]);
            }
            else
            {
                Response.Redirect("~/");
            }
        }

        public void RedirectionAfterLogin_Fixed()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]) && IsLocalUrl(Request.QueryString["returnUrl"]))
            {
                Response.Redirect(Request.QueryString["returnUrl"]);
            }
            else
            {
                Response.Redirect("~/");
            }
        }

        private bool IsLocalUrl(string url)
        {
            /**
             * Validating URL & allowing only local redirection
             */
 
            // From: https://docs.microsoft.com/en-us/aspnet/mvc/overview/security/preventing-open-redirection-attacks

            if (string.IsNullOrEmpty(url))
            {
                return false;
            }
            else
            {
                return ((url[0] == '/' && (url.Length == 1 ||
                        (url[1] != '/' && url[1] != '\\'))) ||   // "/" or "/foo" but not "//" or "/\"
                        (url.Length > 1 &&
                         url[0] == '~' && url[1] == '/'));   // "~/" or "~/foo"
            }
        }
    }
}