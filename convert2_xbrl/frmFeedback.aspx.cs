using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmFeedback : System.Web.UI.Page
    {
        #region Handler
        string tmpRadioButton = "";
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
            string tmpbody = "<table><tr><td>Name / Email </td><td>" + txtEmailID.Text.ToString() + "</td></tr><tr><td>Membership Number</td><td>" + txtMemberShip.Text.ToString() + "</td></tr><tr><td>Type</td><td>" + rbtSubject.Text.ToString() + "</td></tr><tr><td>Phone Number</td><td>" + txtPhoneNo.Text.ToString() + "</td></tr><tr><td>Feedback</td><td>" + txtComment.Text.ToString() + "</td></tr></table>";
            string tmpSub = rbtSubject.Text;

            int tmpSendMail = new DBConnection().SendMail(txtEmailID.Text.ToString().Trim(), tmpSub, tmpbody);
            if (tmpSendMail == 1)
            {
                int tmpInsertFeedback = new DBConnection().InsertFeedBack(txtEmailID.Text.ToString().Trim(), txtMemberShip.Text.ToString().Trim(), rbtSubject.Text.ToString(), txtPhoneNo.Text.ToString().Trim(), txtComment.Text.ToString().Trim());
                if (tmpInsertFeedback == 1)
                {
                    convert2_xbrl.Show("Thank you for your valueable time. your feedback is sent.", this);
                    Clear();
                }
            }
        }
        #endregion

        #region Method
        public void Clear()
        {
            txtEmailID.Text = "";
            txtMemberShip.Text = "";
            txtPhoneNo.Text = "";
            txtComment.Text = "";
        }
        #endregion
    }
}