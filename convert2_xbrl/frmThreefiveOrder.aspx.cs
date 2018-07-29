using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATSQL;

namespace convert2_xbrl
{
    public partial class frmThreefiveOrder : System.Web.UI.Page
    {
        #region Handler
        int tmpPaymentID = 0;
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
                if (Request.QueryString.Count > 0)
                {
                    tmpPaymentID = Convert.ToInt32(Request.QueryString["id"].ToString());
                    AssignDataValue();
                }
                else
                {
                    Response.Redirect("frmCart.aspx");
                }
            }
        }
        #endregion

        #region Method
        public void AssignDataValue()
        {
            lblOrderID.Text = tmpPaymentID.ToString();

            lblAddedDate.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select added_date from order_info where order_id='" + tmpPaymentID + "'"));
            lblQuentity.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select quantity from order_info where order_id='" + tmpPaymentID + "'"));
            lblAmount.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select amount from order_info where order_id='" + tmpPaymentID + "'"));
            lblTax.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select tax1 from order_info where order_id='" + tmpPaymentID + "'"));
            lblTotalAmount.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select totalamt from order_info where order_id='" + tmpPaymentID + "'"));

            lblName.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select name from billing_information where order_id='" + tmpPaymentID + "'"));
            lblAddress.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select address from billing_information where order_id='" + tmpPaymentID + "'"));
            lblCity.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select city from billing_information where order_id='" + tmpPaymentID + "'"));
            lblState.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select state from billing_information where order_id='" + tmpPaymentID + "'"));
            lblZip.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select zip from billing_information where order_id='" + tmpPaymentID + "'"));
            lblPhone.Text = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select email from billing_information where order_id='" + tmpPaymentID + "'"));
        }
        #endregion
    }
}