using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ATSQL;

namespace convert2_xbrl
{
    public partial class frmThreeProcess : System.Web.UI.Page
    {
        #region Handler
        string tmpReturnUrl = "";
        int tmpSessionID = 0;
        int tmpTotalAmount = 0;
        string bName = "";
        string bAdd = "";
        string bCity = "";
        string bState = "";
        string bZip = "";
        string bCountry = "";
        string bEmail = "";
        string bTelephone = "";
        string sName = "";
        string sAdd = "";
        string sCity = "";
        string sState = "";
        string sZip = "";
        string sCountry = "";
        string sTelephone = "";
        string referedBy = "";
        string tmpString = "";
        string tmpHasCode = "";
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            string Url = "https://secure.ebs.in/pg/ma/sale/pay/";
            string Method = "post";
            string FormName = "form1";

            string secret_key = "ebskey";
            string account_id = "5880";
            tmpSessionID = Convert.ToInt32(Session["UserID"].ToString());
            string reference_no = "1";
            string mode = "TEST";
            string return_url = "http://localhost:65351/frmResponse.aspx?DR={DR}";

            CollectInforamtion();
            string amount = tmpTotalAmount.ToString();

            string input = secret_key + "|" + account_id + "|" + amount + "|" + reference_no + "|" + return_url + "|" + mode;

            MD5 md5 = MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            string secure_hash = sb.ToString();

            NameValueCollection FormFields = new NameValueCollection();
            FormFields.Add("account_id", account_id);
            FormFields.Add("reference_no", reference_no);
            FormFields.Add("amount", amount);
            FormFields.Add("description", "Xbrl Software");
            FormFields.Add("name", bName);
            FormFields.Add("address", bAdd);
            FormFields.Add("city", bCity);
            FormFields.Add("state", bCity);
            FormFields.Add("postal_code", bZip);
            FormFields.Add("country", "IND");
            FormFields.Add("email", bEmail);
            FormFields.Add("phone", bTelephone);
            FormFields.Add("ship_name", sName);
            FormFields.Add("ship_address", sAdd);
            FormFields.Add("ship_city", sCity);
            FormFields.Add("ship_state", sState);
            FormFields.Add("ship_postal_code", sZip);
            FormFields.Add("ship_country", "IND");
            FormFields.Add("ship_phone", sTelephone);
            FormFields.Add("return_url", return_url);
            FormFields.Add("mode", mode);
            FormFields.Add("secure_hash", secure_hash);

            Response.Clear();
            Response.Write("<html><head>");
            Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
            Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
            for (int i = 0; i < FormFields.Keys.Count; i++)
            {
                Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", FormFields.Keys[i], FormFields[FormFields.Keys[i]]));
            }
            Response.Write("</form>");
            Response.Write("</body></html>");
            Response.End();
        }
        #endregion

        #region Metod
        public void CollectInforamtion()
        {
            tmpTotalAmount = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select totalamt from cart where user_id='" + tmpSessionID + "'"));
            bName = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_name from checkout_data where user_id='" + tmpSessionID + "'"));
            bAdd = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_address from checkout_data where user_id='" + tmpSessionID + "'"));
            bCity = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_city from checkout_data where user_id='" + tmpSessionID + "'"));
            bState = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_state from checkout_data where user_id='" + tmpSessionID + "'"));
            bZip = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_zip from checkout_data where user_id='" + tmpSessionID + "'"));
            bCountry = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_country from checkout_data where user_id='" + tmpSessionID + "'"));
            bEmail = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_email from checkout_data where user_id='" + tmpSessionID + "'"));
            bTelephone = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select billing_telephone from checkout_data where user_id='" + tmpSessionID + "'"));
            sName = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_name from checkout_data where user_id='" + tmpSessionID + "'"));
            sAdd = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_address from checkout_data where user_id='" + tmpSessionID + "'"));
            sCity = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_city from checkout_data where user_id='" + tmpSessionID + "'"));
            sState = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_state from checkout_data where user_id='" + tmpSessionID + "'"));
            sZip = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_zip from checkout_data where user_id='" + tmpSessionID + "'"));
            sCountry = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_country from checkout_data where user_id='" + tmpSessionID + "'"));
            sTelephone = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select shipping_telephone from checkout_data where user_id='" + tmpSessionID + "'"));
            referedBy = Convert.ToString(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select refered_by from checkout_data where user_id='" + tmpSessionID + "'"));
        }
        #endregion
    }
}