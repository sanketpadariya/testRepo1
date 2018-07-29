using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace convert2_xbrl
{
    public partial class convert2_xbrl : System.Web.UI.MasterPage
    {
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    aCahangePSW.Style.Add("display", "normal");
                    //aCahangePSW.Visible = true;
                    aRegistration.Visible = false;
                    aLogin.Visible = false;
                    //aLogout.Visible = true;
                    aLogout.Style.Add("display", "normal");

                    lblWelcome.Visible = true;
                    lblWelcomeUser.Visible = true;
                    lblWelcomeUser.Text = Session["UserName"].ToString();

                    aSubmitTicket.Visible = true;
                    aViewTicket.Visible = true;
                }
                else
                {
                    aRegistration.Visible = true;
                    aLogin.Visible = true;
                    aSubmitTicket.Visible = false;
                    aViewTicket.Visible = false;
                }
            }
        }
#endregion

        #region Method
        public static void Show(string Message, Page pageinstance)
        {
            string script = "alert('" + Message + "');\n";
            ScriptManager.RegisterStartupScript(pageinstance, pageinstance.GetType(), "MCMS", script, true);
            //pageinstance.ClientScript.RegisterStartupScript(pageinstance.GetType(), "msgbox", script, true);
        }
        #endregion   
    }
}