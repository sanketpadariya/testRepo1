using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace convert2_xbrl
{
    public partial class frmThankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int tmp = Convert.ToInt32(Request.QueryString["id"].ToString());

            if (tmp == 1)
            {
                lblMessage.Text = "We have received your email, Our support team will respond you within next 24hours.";
            }
            if (tmp == 3)
            {
                lblMessage.Text = "Thank you for Issuing ticket. Our support team will respond you within next 24hours.";
            }
        }
    }
}