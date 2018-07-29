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
    public partial class frmSubmitTicket : System.Web.UI.Page
    {
        #region Handler
        int tmpSessionUserID = 0;
        int uniqueID = 0;
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
            int tmp = new clsTicket().SubmitTicket(txtName.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), txtPhoneNo.Text.ToString().Trim(), txtQueryTitle.Text.ToString().Trim(), txtDescription.Text.ToString().Trim(), tmpSessionUserID);
            if (tmp == 1)
            {
                string tmpbody = "<table><tr><td>Name</td><td>" + txtName.Text + "</td></tr><tr><td>Email</td><td>" + txtEmail.Text + "</td></tr><tr><td>Phone</td><td>" + txtPhoneNo.Text + "</td></tr>";
                tmpbody += "<tr><td>Query Title</td><td>" + txtQueryTitle.Text + "</td></tr><tr><tr><td>Query Description</td><td>" + txtDescription.Text + "</td></tr></table>";

                GetTicketID();
                string tmpSub = "Convert2xbrl Ticket " + uniqueID + " issued";

                //string to = "malav.dalwadi@gmail.com";
                //string too = "support@microvistatech.com";

                string to = "padariyasanket@gmail.com";
                string too = "patelsignal@gmail.com";

                new DBConnection().SendMail(to, tmpSub, tmpbody);
                new DBConnection().SendMail(too, tmpSub, tmpbody);
                new DBConnection().SendMail(txtEmail.Text, tmpSub, tmpbody);

                Clear();
                Response.Redirect("frmThankyou.aspx?id=3");
            }
            else
            {
                convert2_xbrl.Show("Error While Submitting Ticket", this);
            }
        }
        #endregion

        #region Metod
        public void GetTicketID()
        {
            string Query1 = "select id from cart where user_id='" + tmpSessionUserID + "'";
            uniqueID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query1));
        }
        public void Clear()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            txtQueryTitle.Text = "";
            txtDescription.Text = "";
        }
        #endregion
    }
}