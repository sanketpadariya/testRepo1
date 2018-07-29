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
    public partial class frmLogin : System.Web.UI.Page
    {
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                string tmpVerifyID = Request.QueryString["verify_id"].ToString();

                int tmpVID = new DBConnection().CheckVerifyID(tmpVerifyID);

                if (tmpVID == 1)
                {
                    int tmpUpdate = new DBConnection().UpdateRegistration(tmpVerifyID);
                    if (tmpUpdate == 1)
                    {
                        Clear();
                        Response.Redirect("frmLogin.aspx");
                    }
                }
            }
            else
            {
                DBConnection nd = new DBConnection();
                int objLogin = nd.CheckAuthentication(txtUserName.Text.ToString().Trim(), txtPWD.Text.ToString().Trim());

                if (objLogin == 1)
                {
                    string query = "select id from registration where username=" + "'" + txtUserName.Text.ToString().Trim() + "' AND password=" + "'" + txtPWD.Text.ToString().Trim() + "'";
                    int objUserID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, query));
                    Session["UserID"] = objUserID;
                    Session["UserName"] = txtUserName.Text;
                    Clear();
                    Response.Redirect("frmDownload.aspx");
                }
                else
                {
                    convert2_xbrl.Show("Invalid username and password", this);
                    Clear();
                }
            }
        }
        #endregion

        #region Method
        public void Clear()
        {
            txtUserName.Text = "";
            txtPWD.Text = "";
        }
        #endregion
    }
}