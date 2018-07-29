using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATSQL;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmForgotPassword : System.Web.UI.Page
    {
        #region Handler
        string tmpHtml;
        string body;
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string query1 = "select id from registration where Email='" + txtEmailID.Text.ToString().Trim() + "'";
            int tmpEmailVerify = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, query1));

            if (tmpEmailVerify == 0)
            {
                convert2_xbrl.Show("Email is not registered", this);
            }
            else
            {
                string tmpUserName = "select username from registration where email='" + txtEmailID.Text.ToString().Trim() + "'";
                string UserName = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, tmpUserName));

                string tmpPassword = "select password from registration where email='" + txtEmailID.Text.ToString().Trim() + "'";
                string psw = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, tmpPassword));

                string tmpbody = "Hi,<br/><br/> Your Username: '" + UserName.ToString() + "'. <br/> Your Password: '" + psw.ToString() + "'. <br/><br/> Please login using your User Name and Password. <br/><br/> Thank You";
                string tmpSub = "Login Details";

                int objtmp = new DBConnection().SendMail(txtEmailID.Text.ToString().Trim(), tmpSub, tmpbody.ToString());

                if (objtmp == 0)
                {
                    convert2_xbrl.Show("Your Email ID is not Registered", this);
                }
                else if (objtmp > 0)
                {
                    convert2_xbrl.Show("User Name and Password succesfully send to your Email ID", this);
                    txtEmailID.Text = "";
                    //Response.Redirect("frmLogin.aspx");
                }
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }
        #endregion        
    }
}