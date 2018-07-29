using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmFinanceCheckout : System.Web.UI.Page
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
            }

            if (!IsPostBack)
            {
            }
        }
        protected void chkCopy_CheckedChanged(object sender, EventArgs e)
        {
            txtShipName.Text = txtBillingName.Text;
            txtShipAddress.Text = txtBillingAddress.Text;
            txtShipCity.Text = txtBillingCity.Text;
            txtShipPostalCode.Text = txtBillingPostalCode.Text;
            txtShipPhone.Text = txtBillingPhone.Text;
            txtShipState.Text = txtBilligState.Text;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtBillingName.Text = "";
            txtBillingAddress.Text = "";
            txtBillingCity.Text = "";
            txtBillingPostalCode.Text = "";            
            txtBillingPhone.Text = "";

            txtShipName.Text = "";
            txtShipAddress.Text = "";
            txtShipCity.Text = "";
            txtShipPostalCode.Text = "";            
            txtShipPhone.Text = "";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (TandC.Checked)
            {
                tmp = new clsCart().InsFinanceCheckoutEntry(tmpSessionUserID, txtBillingName.Text.ToString().Trim(), txtBillingAddress.Text.ToString().Trim(), txtBillingCity.Text.ToString().Trim(), txtBilligState.Text.ToString().Trim(), txtBillingPostalCode.Text.ToString().Trim(), "India", txtEmail.Text.ToString().Trim(), txtBillingPhone.Text.ToString().Trim(), txtShipName.Text.ToString().Trim(), txtShipAddress.Text.ToString().Trim(), txtShipCity.Text.ToString().Trim(), txtShipState.Text.ToString().Trim(), txtShipPostalCode.Text.ToString().Trim(), "India", txtShipPhone.Text.ToString().Trim(), txtReferedBy.Text.ToString().Trim());

                DataTable dt = new DataTable();
                dt = new clsCart().GetTopMostFID();

                int tmpID = Convert.ToInt32(dt.Rows[0]["id"].ToString());

                if (tmp == 1)
                {
                    Response.Redirect("frmFinanceProcess.aspx?id=" + tmpID);
                }
                else
                {
                    convert2_xbrl.Show("Error in Checkout", this);
                }
            }
            else
            {
                convert2_xbrl.Show("Please Accept Terms and Condition", this);
            }
        }
        #endregion
    }
}