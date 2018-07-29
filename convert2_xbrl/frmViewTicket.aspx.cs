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
    public partial class frmViewTicket : System.Web.UI.Page
    {
        #region Handler
        int tmpSessionUserID = 0;
        int tmp = 0;
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
                tmp = new clsTicket().ViewTicket(tmpSessionUserID);
                if (tmp == 1)
                {
                    ViewTicket();
                }
                else
                {
                    convert2_xbrl.Show("No records found", this);
                }
            }

            if (!IsPostBack)
            {
            }
        }
        #endregion

        #region Method
        public void ViewTicket()
        {
            string Query1 = "Select name from ticket where user_id='" + tmpSessionUserID + "' and status='1'";
            string Name = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query1));
            lblName.Text = Name;

            string Query2 = "Select id from ticket where user_id='" + tmpSessionUserID + "' and status='1'";
            int ID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query2));
            lblNumber.Text = ID.ToString();

            string Query3 = "Select q_title from ticket where user_id='" + tmpSessionUserID + "' and status='1'";
            string qTitle = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query3));
            lblQueryTitle.Text = qTitle;
        }
        #endregion
    }
}