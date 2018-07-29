using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            string tmpRandom = new DBConnection().RandomKey(15);

            //string tmpbody = "Hi,<br/> To Confirm Your Registration Click Belove Link <br/><br/> <a id=" + "anc" + " href=" + "http://localhost:65351/default.aspx?verify_id=" + tmpRandom.ToString() + ">Redirect Page</a>"; //"Hi,<br/><br/> Your Username: '" + Uname.ToString() + "'. <br/> Your Password: '" + Psw.ToString() + "'. <br/><br/> Please login using your User Name and Password. <br/><br/> Thank You";

            string tmpbody = "<table><tr><td>First Name</td><td>" + txtFname.Text + "</td></tr><tr><td>Last Name</td><td>" + txtLname.Text + "</td></tr>";
            tmpbody += "<tr><td>Email</td><td>" + txtEmail.Text + "</td></tr><tr><td>Phone</td><td>" + txtPhoneNo.Text + "</td></tr><tr><td>Company</td><td>" + txtFirm.Text + "</td></tr>";
            tmpbody += "<tr><tr><td>City</td><td>" + txtCity.Text + "</td></tr><tr><td>Username</td><td>" + txtUserName.Text + "</td></tr><tr><td>Password</td><td>" + txtPassword.Text + "</td></tr></table><br/><br/>";

            tmpbody += "Hello " + txtFname.Text + "&nbsp;" + txtLname.Text + ",<br />";
            tmpbody += "Congratulations!You've just created an account to <a href='http://www.convert2xbrl.com'>convert2xbrl.com</a>.<br />";
            tmpbody += "But you're not finished yet.<br/><br />To activate your account and confirm ownership of this email address, click the link below to activate your account:<br />";
            tmpbody += "<a href='http://localhost:65351/default.aspx?verify_id='" + tmpRandom + "'>";
            tmpbody += "http://localhost:65351/default.aspx?verify_id=" + tmpRandom + "</a>";
            tmpbody += "<br /><br />Regards<br />Microvista Technologies";


            string tmp = "Activate your account to convert2xbrl.com";

            int objtmp = new DBConnection().SendMail(txtEmail.Text.ToString().Trim(), tmp.ToString(), tmpbody.ToString());

            if (objtmp == 1)
            {
                convert2_xbrl.Show("Conformation Mail is send to your Mail Address", this);

                int objRegi = new DBConnection().UserRegistration(txtFname.Text.ToString().Trim(), txtLname.Text.ToString().Trim(), txtEmail.Text.ToString().Trim(), txtPhoneNo.Text.ToString().Trim(), txtFirm.Text.ToString().Trim(), txtUserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim(), tmpRandom.ToString(), txtCity.Text.ToString().Trim());

                if (objRegi == 1)
                {
                    convert2_xbrl.Show("For Login please check you Conformation-Mail", this);
                    Clear();
                    //Response.Redirect("frmLogin.aspx");
                }
                else
                {
                    convert2_xbrl.Show("Error in User Registration", this);
                    Clear();
                }
            }
            else
            {
                convert2_xbrl.Show("Error in sending Conformation Mail", this);
                Clear();
            }
        }

        public void Clear()
        {
            txtFname.Text = "";
            txtLname.Text = "";
            txtUserName.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            txtCity.Text = "";
            txtFirm.Text = "";
            txtPassword.Text = "";
        }
    }
}