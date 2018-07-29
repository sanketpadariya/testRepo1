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
using convert2_xbrl.BL;

namespace convert2_xbrl
{
    public partial class frmFinanceProcess : System.Web.UI.Page
    {        
        #region Handler        
        int tmpSessionID = 0;
        int tmpID = 0;
        string referedBy = "";
        int tmpTotalAmount = 0;
        string bName = "";
        string bAdd = "";
        string bCity = "";
        string bState = "";
        string bZip = "";        
        string bEmail = "";
        string bTelephone = "";
        string sName = "";
        string sAdd = "";
        string sCity = "";
        string sState = "";
        string sZip = "";        
        string sTelephone = "";
        string tmpString = "";
        string tmpHasCode = "";
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                tmpID = Convert.ToInt32(Request.QueryString["id"].ToString());

                string Url = "https://secure.ebs.in/pg/ma/sale/pay/";
                string Method = "post";
                string FormName = "form1";

                string secret_key = "ebskey";
                string account_id = "5880";
                tmpSessionID = Convert.ToInt32(Session["UserID"].ToString());
                string reference_no = "1";
                string mode = "TEST";
                string return_url = "http://localhost:65351/frmFinanceResponse.aspx?DR={DR}";

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
            else
            {
                convert2_xbrl.Show("",this);
            }
           
        }
        #endregion  

        #region Metod
        public void CollectInforamtion()
        {
            DataTable dt = new DataTable();
            dt = new clsCart().GetContetntByFID(tmpID);

            tmpTotalAmount = Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString(), CommandType.Text, "select totalamt from finance_cart where user_id='" + tmpSessionID + "'"));
            bName = dt.Rows[0]["billing_name"].ToString();
            bAdd = dt.Rows[0]["billing_address"].ToString();
            bCity = dt.Rows[0]["billing_city"].ToString();
            bState = dt.Rows[0]["billing_state"].ToString();
            bZip = dt.Rows[0]["billing_zip"].ToString();
            bEmail = dt.Rows[0]["billing_email"].ToString();
            bTelephone = dt.Rows[0]["billing_telephone"].ToString();
            sName = dt.Rows[0]["shipping_name"].ToString();
            sAdd = dt.Rows[0]["shipping_address"].ToString();
            sCity = dt.Rows[0]["shipping_city"].ToString();
            sState = dt.Rows[0]["shipping_state"].ToString();
            sZip = dt.Rows[0]["shipping_zip"].ToString();
            sTelephone = dt.Rows[0]["shipping_telephone"].ToString();
            referedBy = dt.Rows[0]["refered_by"].ToString();
        }        
        #endregion
    }
}