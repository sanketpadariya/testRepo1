using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.QueryString.Count > 0)
            //{
            //    string tmpVerifyID = Request.QueryString["verify_id"].ToString();

            //    int tmpVID = new DBConnection().CheckVerifyID(tmpVerifyID);

            //    if (tmpVID == 1)
            //    {
            //        int tmpUpdate = new DBConnection().UpdateRegistration(tmpVerifyID);
            //        if (tmpUpdate == 1)
            //        {
            //            Response.Redirect("frmLogin.aspx");
            //        }
            //    }
            //}
        }
    }
}