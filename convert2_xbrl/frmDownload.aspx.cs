using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmDownload : System.Web.UI.Page
    {
        #region Handler
        int tmpSessionUserID = 0;

        int tmpCartSelect = 0;
        int tmpCartInsert = 0;
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
        protected void btnFinanceCart_Click(object sender, EventArgs e)
        {
            tmpSessionUserID = Convert.ToInt32(Session["UserID"].ToString());

            tmpCartSelect = new clsCart().FinanceCartProcessSelect(tmpSessionUserID);
            if (tmpCartSelect == 1)
            {
                //--- Delete Finance Cart Record
                new clsCart().FinanceCartDelete(tmpSessionUserID);

                //--- Insert New Finance Cart Record
                tmpCartInsert = new clsCart().FinanceCartProcessInsert(tmpSessionUserID);
                if (tmpCartInsert == 1)
                {
                    Response.Redirect("frmFinanceCart.aspx");
                }
            }
            else
            {
                //--- Insert New Finance Cart Record
                tmpCartInsert = new clsCart().FinanceCartProcessInsert(tmpSessionUserID);
                if (tmpCartInsert == 1)
                {
                    Response.Redirect("frmFinanceCart.aspx");
                }
            }
        }
        protected void btnCostingCart_Click(object sender, EventArgs e)
        {
            tmpSessionUserID = Convert.ToInt32(Session["UserID"].ToString());

            tmpCartSelect = new clsCart().CartProcessSelect(tmpSessionUserID);
            if (tmpCartSelect == 1)
            {
                //--- Delete Cart Record
                new clsCart().CartProcessDelete(tmpSessionUserID);

                //--- Insert New Cart Record
                tmpCartInsert = new clsCart().CartProcessInsert(tmpSessionUserID);
                if (tmpCartInsert == 1)
                {
                    Response.Redirect("frmCart.aspx");
                }
            }
            else
            {
                //--- Insert New Cart Record
                tmpCartInsert = new clsCart().CartProcessInsert(tmpSessionUserID);
                if (tmpCartInsert == 1)
                {
                    Response.Redirect("frmCart.aspx");
                }
            }
        }
        #endregion
    }
}