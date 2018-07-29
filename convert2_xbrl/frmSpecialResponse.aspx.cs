using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATSQL;
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmSpecialResponse : System.Web.UI.Page
    {
        #region Handler
        string sQS;
        string[] aQS;
        string lsDetail1, lsDetail2, lsDetail;
        string secret_key = "ebskey";
        string DR = "";
        int tmpSessionUserID = 0;

        int paymentID = 0;
        int trnID = 0;
        string createdDate = "";
        int responseCode = 0;
        int refNo = 0;

        int Quentity = 0;
        int Amount = 0;
        float tax = 0;
        float TotalAmt = 0;

        string bName = "";
        string bAdd = "";
        string bCity = "";
        string bState = "";
        int bZip = 0;
        string bEmail = "";
        string bTelephone = "";
        string sName = "";
        string sAdd = "";
        string sCity = "";
        string sState = "";
        int sZip = 0;
        string sTelephone = "";

        int tmpOderINS = 0;
        int tmpBillingINS = 0;
        int tmpShippingINS = 0;
        int tmpActivate = 0;
        int tmpCartDelete = 0;

        string tmpBody = "";
        string tmpSubject = "";
        string to = "";
        string too = "";
        string tooo = "";
        string to1 = "";
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Convert.ToInt32(Session["UserID"]) == 0)
            {
                convert2_xbrl.Show("Invalid Payment Response", this);
            }
            else
            {
                tmpSessionUserID = Convert.ToInt32(Session["UserID"].ToString());

                tmpSessionUserID = Convert.ToInt32(Session["UserID"].ToString());

                string Query1 = "select quantity from cart where user_id='" + tmpSessionUserID + "'";
                Quentity = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query1));

                string Query2 = "select amount from cart where user_id='" + tmpSessionUserID + "'";
                Amount = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query2));

                string Query3 = "select tax1 from cart where user_id='" + tmpSessionUserID + "'";
                tax = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query3));

                string Query4 = "select totalamt from cart where user_id='" + tmpSessionUserID + "'";
                TotalAmt = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, Query4));

                DR = Request.QueryString["DR"].ToString();
                DR = DR.Replace(' ', '+');
                sQS = Base64Decode(DR);
                DR = new Rc43().Decrypt(secret_key, sQS, false);
                lsDetail += "<table align='center' width='600' cellpadding='2' cellspacing='2' border='0'>";
                lsDetail += "<tr><th width='90%'><h2 class='co'>EBS Payment Integration Page</h2></th></tr></table>";
                lsDetail += "<center><h3>Response</H3></center>";
                lsDetail += "<table align='center' width='600' cellpadding='2' cellspacing='2' border='0'>";
                lsDetail += "<tr><th colspan='2'>Transaction Details</th></tr></table>";
                Response.Write(lsDetail);

                aQS = DR.Split('&');

                foreach (string param in aQS)
                {

                    string[] aParam = param.Split('=');

                    lsDetail1 += "<table align='center' width='600' cellpadding='2' cellspacing='2' border='0'>";
                    lsDetail1 += "<td align='left'>" + aParam[0] + "</td></br>";
                    lsDetail2 += "<td align='left' width='50%'>" + aParam[1] + "</td>";
                    lsDetail2 += "</tr></table>";
                    lsDetail1 += lsDetail2;

                    Response.Write(lsDetail1);

                    lsDetail1 = "";
                    lsDetail2 = "";

                    if (aParam[0].ToString() == "PaymentID")
                    {
                        paymentID = Convert.ToInt32(aParam[1].ToString());
                    }
                    else if (aParam[0].ToString() == "TransactionID")
                    {
                        trnID = Convert.ToInt32(aParam[1].ToString());
                    }
                    else if (aParam[0].ToString() == "DateCreated")
                    {
                        createdDate = aParam[1].ToString();
                    }
                    else if (aParam[0].ToString() == "ResponseCode")
                    {
                        responseCode = Convert.ToInt32(aParam[1].ToString());
                    }
                    else if (aParam[0].ToString() == "MerchantRefNo")
                    {
                        refNo = Convert.ToInt32(aParam[1].ToString());
                    }
                }

                tmpOderINS = new clsResponse().OrderIns(paymentID, tmpSessionUserID, trnID, createdDate, responseCode, Amount, Quentity, tax, TotalAmt);
                if (tmpOderINS != 1)
                {
                    convert2_xbrl.Show("Error while Inserting Finance order", this);
                }

                BillingInformation();
                tmpBillingINS = new clsResponse().BillingInfo(paymentID, bName, bAdd, bCity, bState, bZip, bEmail, bTelephone);
                if (tmpBillingINS != 1)
                {
                    convert2_xbrl.Show("Error while Inserting Finance Biling Info", this);
                }

                ShippingInformation();
                tmpShippingINS = new clsResponse().ShipingInfo(paymentID, sName, sAdd, sCity, sState, sZip, sTelephone);
                if (tmpShippingINS != 1)
                {
                    convert2_xbrl.Show("Error while Inserting Finance Shipping Info", this);
                }

                tmpActivate = new clsResponse().Activate(paymentID, bName, bEmail, createdDate, Quentity);
                if (tmpActivate != 1)
                {
                    convert2_xbrl.Show("Error while Inserting Finance Activate", this);
                }

                if (responseCode == 0)
                {
                    tmpCartDelete = new clsResponse().FinanceCartDelete(tmpSessionUserID);
                    if (tmpCartDelete == 1)
                    {
                        tmpBody = "Dear " + bName + "<br /><br />";
                        tmpBody += "<b>To download Excel sheet please <a href = \"http://convert2xbrl.com/excelsoftware/software.zip\">click here</a> </b><br />";
                        tmpBody += "<b> To download converter software please <a href=\"http://convert2xbrl.com/excelsoftware/convert2xbrl.zip\">click here</a></b><br />";

                        tmpBody += "<table width=\"760\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\">";
                        tmpBody += "<tbody><tr><td colspan=\"3\" align=\"center\" valign=\"top\"></td></tr><tr>";
                        tmpBody += "<td colspan=\"3\" align=\"left\" valign=\"middle\" height=\"40\">";
                        tmpBody += "<span style=\"font-size: 18px;color:#002f75;font-family:Arial, Helvetica; font-weight:bold;\">Order receipt</span>";
                        tmpBody += "</td></tr><tr><td colspan=\"3\" height=\"10\"></td></tr><tr>";
                        tmpBody += "<td width=\"760\" align=\"center\"><table border=\"0\" width=\"760\"><tbody><tr>";
                        tmpBody += "<td nowrap=\"nowrap\" valign=\"top\" width=\"247\"><span><strong>" + createdDate + "</strong></span></td>";
                        tmpBody += "<td valign=\"top\" width=\"21%\"></td><td nowrap=\"nowrap\" valign=\"top\" width=\"197\">";
                        tmpBody += "<span><strong>Payment Id #:" + paymentID + "</strong></span><br />";
                        tmpBody += "<span><strong>Service Tax No.: AASFM9405HSD001</strong></span></td></tr><tr>";
                        tmpBody += "<td colspan=\"3\" height=\"10\"></td></tr><tr><td nowrap=\"nowrap\" valign=\"top\" width=\"247\"></td>";
                        tmpBody += "<td valign=\"top\" width=\"197\"></td><td nowrap=\"nowrap\" valign=\"top\" width=\"310\">";
                        tmpBody += "<span><strong>Billing Information</strong></span></td></tr><tr><td height=\"130\" valign=\"top\" nowrap=\"nowrap\" width=\"247\">";
                        tmpBody += "</td><td valign=\"top\" width=\"197\"></td><td valign=\"top\" width=\"310\">";
                        tmpBody += "<span>" + bName + "</span><br/><span>" + bAdd + "</span><br/><span>" + bCity + "</span><br /><span></span>" + bState + "</span><br />";
                        tmpBody += "<span>" + bZip + "</span><br/><span>\"INDIA\"</span><br/><span>" + bTelephone + "</span><br/><span>" + bEmail + "</span></td></tr>";
                        tmpBody += "<tr><td valign=\"top\"></td><td valign=\"top\"></td><td valign=\"top\"></td></tr></tbody></table></td><td width=\"76\"></td></tr></tbody></table>";

                        tmpBody += "<table cellpadding=\"0\" cellspacing=\"3\" align=\"center\" border=\"0\" width=\"760\"><tbody><tr><td colspan=\"9\" align=\"center\"><hr/></td></tr>";
                        tmpBody += "<tr><td width=\"80\" align=\"left\" valign=\"bottom\"><span style=\"font-size: 10px; ; text-decoration: underline; font-style:italic;\">Sr</span></td>";
                        tmpBody += "<td width=\"300\" align=\"left\" valign=\"bottom\"><span style=\"font-size: 10px; ; text-decoration: underline; font-style:italic;\">Name</span></td>";
                        tmpBody += "<td width=\"200\" align=\"right\" valign=\"bottom\"><span style=\"font-size: 10px; ; text-decoration: underline; padding-left:3px; font-style:italic;\">";
                        tmpBody += "Unit Price</span></td><td width=\"100\" align=\"right\" valign=\"bottom\">";
                        tmpBody += "<span style=\"font-size: 10px; ; text-decoration: underline; padding-left:3px; font-style:italic;\">Qty</span></td>";
                        tmpBody += "<td width=\"100\" align=\"right\" valign=\"bottom\">";
                        tmpBody += "<span style=\"font-size: 10px; ; text-decoration: underline; padding-left:3px; font-style:italic;\">Total Price</span></td></tr>";
                        tmpBody += "<tr><td valign=\"top\">1</td><td valign=\"top\">Xbrl Software<br />1. Cost Audit Report<br />2. Compliance Report</td>";
                        tmpBody += "<td align=\"right\" valign=\"top\">4500</td><td align=\"right\" valign=\"top\">" + Quentity + "</td><td align=\"right\" valign=\"top\">" + Amount + " Rs</td></tr>";
                        tmpBody += "<tr><td colspan=\"4\" align=\"right\" valign=\"top\">Service Tax (14%) Amount : </td><td align=\"right\" valign=\"top\"> " + tax + " Rs</td></tr>";
                        tmpBody += "<tr><td colspan=\"4\" align=\"right\" valign=\"top\">Total Amount : </td><td align=\"right\" valign=\"top\"> " + TotalAmt + " Rs</td></tr>";
                        tmpBody += "<tr><td colspan=\"9\"><hr/></td></tr><tr></tr><tr><td colspan=\"8\" align=\"center\"></td></tr></tbody></table>";

                        tmpBody += "<br /><br /><br /> Regards,<br /> Microvista Technologies <br /> www.Convert2xbrl.com";

                        tmpSubject = "Order Recipt";
                        to = "akhilpadaria012@gmail.com";
                        too = "padariyasaket@gmail.com";
                        tooo = "patelsignal@gmail.com";
                        to1 = bEmail;

                        new DBConnection().SendMail(to, tmpSubject, tmpBody);
                        new DBConnection().SendMail(too, tmpSubject, tmpBody);
                        new DBConnection().SendMail(tooo, tmpSubject, tmpBody);
                        new DBConnection().SendMail(to1, tmpSubject, tmpBody);

                        Response.Redirect("frmOrder.aspx?id=" + paymentID);
                    }
                    else
                    {
                        convert2_xbrl.Show("Error while Deleting Finance Cart", this);
                    }
                }
            }
        }

        #region Method
        private string Base64Decode(string sBase64String)
        {
            byte[] sBase64String_bytes =
            Convert.FromBase64String(sBase64String);
            return UnicodeEncoding.Default.GetString(sBase64String_bytes);
        }

        public string base64Decode(string data)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(data);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }
        public void BillingInformation()
        {
            bName = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_name from checkout_data where user_id='" + tmpSessionUserID + "'"));
            bAdd = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_address from checkout_data where user_id='" + tmpSessionUserID + "'"));
            bCity = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_city from checkout_data where user_id='" + tmpSessionUserID + "'"));
            bState = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_state from checkout_data where user_id='" + tmpSessionUserID + "'"));
            bZip = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_zip from checkout_data where user_id='" + tmpSessionUserID + "'"));
            bEmail = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_email from checkout_data where user_id='" + tmpSessionUserID + "'"));
            bTelephone = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_telephone from checkout_data where user_id='" + tmpSessionUserID + "'"));
        }
        public void ShippingInformation()
        {
            sName = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_name from checkout_data where user_id='" + tmpSessionUserID + "'"));
            sAdd = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_address from checkout_data where user_id='" + tmpSessionUserID + "'"));
            sCity = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_city from checkout_data where user_id='" + tmpSessionUserID + "'"));
            sState = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_state from checkout_data where user_id='" + tmpSessionUserID + "'"));
            sZip = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_zip from checkout_data where user_id='" + tmpSessionUserID + "'"));
            sTelephone = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_telephone from checkout_data where user_id='" + tmpSessionUserID + "'"));
        }
        #endregion
    }
}