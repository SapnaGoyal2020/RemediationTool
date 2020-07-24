using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcessImprovement.Vulnerabilities.SDE
{
    public partial class Demo1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayPage();
            //DisplayPage_Fixed();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        protected void DisplayPage()
        {
            StringBuilder html = new StringBuilder();

            int i;
            i = Int32.Parse(Request.QueryString["id"].ToString());
            //Int32.TryParse(Request.QueryString["id"].ToString(), out i);
#pragma warning disable CS0219 // The variable 'dbPassword' is assigned but its value is never used
            String dbPassword = "DbSecurePassword:(";
#pragma warning restore CS0219 // The variable 'dbPassword' is assigned but its value is never used
            html.Append("Given Input: " + i);

            SecMisConfig1.Controls.Add(new Literal { Text = html.ToString() });
        }

        protected void DisplayPage_Fixed()
        {
            StringBuilder html = new StringBuilder();
            /*
             * * Catching all exceptions
             * * Using "TryParse" method instead of Parse
             */

            try
            {
                int i;
                if (Int32.TryParse(Request.QueryString["id"].ToString(), out i))
                {

                    html.Append("Given Input: " + i);
                }
                else
                {
                    html.Append("Invalid Input given");
                }
#pragma warning disable CS0219 // The variable 'dbPassword' is assigned but its value is never used
                String dbPassword = "DbSecurePassword:)";
#pragma warning restore CS0219 // The variable 'dbPassword' is assigned but its value is never used
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (NullReferenceException e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                html.Append("Invalid Input");
            }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
            catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
            {
                html.Append("Error Occurred");
            }

            SecMisConfig1.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}