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
    public partial class frmFinanceCart : System.Web.UI.Page
    {
        #region Handler
        int tmpSessionUserID = 0;

        int tmpFinanceCartUpdate = 0;
        int tmpFinanceCartDelete = 0;

        int tmpAmount = 0;
        int tmpTex = 0;
        int tmpTotalAmount = 0;
        int tmpQuentity = 0;
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
                Bind();
            }
        }
        protected void btnCartSubmit_Click(object sender, EventArgs e)
        {
            tmpQuentity = Convert.ToInt32(txtQuentity.Text.ToString().Trim());
            if (tmpQuentity == 1)
            {
                tmpAmount = 4500;
            }
            else if (tmpQuentity == 2)
            {
                tmpAmount = 7500;
            }
            else if (tmpQuentity >= 3)
            {
                tmpAmount = tmpQuentity * 3000;
            }
            else
            {
                tmpAmount = 0;
            }

            tmpTex = (tmpAmount * 14) / 100;
            tmpTotalAmount = tmpAmount + tmpTex;

            tmpFinanceCartUpdate = new clsCart().FinanceCartUpdate(Convert.ToInt32(txtQuentity.Text.ToString().Trim()), tmpAmount, tmpTex, tmpTotalAmount, tmpSessionUserID);
            if (tmpFinanceCartUpdate == 1)
            {
                Bind();
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            tmpFinanceCartDelete = new clsCart().FinanceCartDelete(tmpSessionUserID);
            if (tmpFinanceCartDelete == 1)
            {
                convert2_xbrl.Show("Cart is deleted successfully", this);
                Response.Redirect("frmDownload.aspx");
            }
            else
            {
                convert2_xbrl.Show("Errorr while deleting Cart", this);
            }
        }
        #endregion

        #region Method
        public void Bind()
        {
            DataTable dt = new DataTable();
            dt = new clsCart().GetFCartContentbyID(tmpSessionUserID);

            txtQuentity.Text = dt.Rows[0]["quantity"].ToString();
            lblAmount.Text = dt.Rows[0]["amount"].ToString();
            lblText.Text = dt.Rows[0]["tax1"].ToString();
            lblTotalAmount.Text = dt.Rows[0]["totalamt"].ToString();

            //string Query1 = "select quantity from finance_cart where user_id='" + tmpSessionUserID + "'";
            //int Quentity = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query1));
            //txtQuentity.Text = Quentity.ToString();

            //string Query2 = "select amount from finance_cart where user_id='" + tmpSessionUserID + "'";
            //int Amount = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query2));
            //lblAmount.Text = Amount.ToString();

            //string Query3 = "select tax1 from finance_cart where user_id='" + tmpSessionUserID + "'";
            //int tax = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query3));
            //lblText.Text = tax.ToString();

            //string Query4 = "select totalamt from finance_cart where user_id='" + tmpSessionUserID + "'";
            //int TotalAmt = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query4));
            //lblTotalAmount.Text = TotalAmt.ToString();
        }
        #endregion
    }
}