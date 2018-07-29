using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmContact : System.Web.UI.Page
    {
        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCapctha();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["captcha"].ToString() != txtCapcha.Text.ToString())
            {
                convert2_xbrl.Show("Invalid Captcha Code", this);
            }
            //FillCapctha();

            string tmpMailBody = "<table><tr><td>First Name</td><td>" + txtFName.Text.ToString() + "</td></tr><tr><td>Last Name</td><td>" + txtLName.Text.ToString() + "</td></tr><tr><td>Email</td><td>" + txtEmail.Text.ToString() + "</td></tr><tr><td>Number</td><td>" + txtPhoneNo.Text.ToString() + "</td></tr><tr><td>Comment</td><td>" + txtComment.Text.ToString() + "</td></tr></table>";
            string tmpMailSub = "Contact Mail";

            int tmpContactmail = new DBConnection().SendMail(txtEmail.Text.ToString().Trim(), tmpMailSub, tmpMailBody);
            if (tmpContactmail == 1)
            {
                Response.Redirect("frmThankYou.aspx?id=1");
            }
        }
        #endregion

        #region Method
        public void FillCapctha()
        {
            try
            {
                Random random = new Random();
                string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                StringBuilder captcha = new StringBuilder();

                for (int i = 0; i < 4; i++)
                {
                    captcha.Append(combination[random.Next(combination.Length)]);
                }

                Session["captcha"] = captcha.ToString();
                //imgCaptcha.ImageUrl = "GenerateCaptcha.aspx?" + DateTime.Now.Ticks.ToString();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion        
    }
}