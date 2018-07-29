using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmUnsubscribe : System.Web.UI.Page
    {
        #region Handler
        int tmpCheckResisteredEmail = 0;
        string tmpSendEmail = null;
        string tmpSubject = null;
        string tmpBody = null;
        int tmpVar = 0;
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            tmpCheckResisteredEmail = new DBConnection().UserSubscription(txtEmail.Text.ToString().Trim());
            if (tmpCheckResisteredEmail > 0)
            {
                tmpSendEmail = "sales@microvistatech.com";
                tmpSubject = "Unsubscribe Email ID";
                tmpBody = "<table><tr><td>Email</td><td>"+txtEmail.Text.ToString().Trim()+"</td></tr><tr><td>Message</td><td>"+txtMessage.Text.ToString().Trim()+"</td></tr></table>";

                tmpVar = new DBConnection().SendMail(tmpSendEmail.ToString(), tmpSubject.ToString(), tmpBody.ToString());
                if (tmpVar > 0)
                {
                    convert2_xbrl.Show("Our Support Team will Unsubscribe You Shortly", this);
                }
                else
                {
                    convert2_xbrl.Show("Error in Sending Email",this);
                }
            }
            else
            {
                convert2_xbrl.Show("Email Id is not Registered",this);
            }
        }
        #endregion
    }
}