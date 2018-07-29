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
    public partial class frmChangePassword : System.Web.UI.Page
    {
        #region Handler
        int tmpSessionUserID = 0;
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Convert.ToInt32(Session["UserID"]) == 0)
            {
                Response.Redirect("frmLogin.aspx");
            }
            else
            {
                tmpSessionUserID = Convert.ToInt32(Session["UserID"].ToString());                
            }

            if (!IsPostBack)
            {
            }
            
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string query1 = "select password from registration where id='" + tmpSessionUserID.ToString() + "'";
            string tmpCurrentPSW = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, query1));

            if (tmpCurrentPSW == txtCurrentPSW.Text.ToString())
            {
                int tmpChangePSW = new DBConnection().UpdatePassword((Convert.ToInt32(Session["UserID"].ToString())), txtNewPSW.Text.ToString());
                if (tmpChangePSW == 1)
                {
                    convert2_xbrl.Show("Password is Successfully Change", this);
                    Response.Redirect("frmLogin.aspx");
                }
                else
                {
                    convert2_xbrl.Show("Password is not Changed", this);
                }
            }
            else
            {
                convert2_xbrl.Show("You Enter Wrong Current Password", this);
            }
        }
        #endregion
    }
}