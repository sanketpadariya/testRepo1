using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace convert2_xbrl
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            submitted.OnClientClick = "return validate()";
        }

        protected void submitted_Click(object sender, EventArgs e)
        {
            string Url = "testing.aspx";
            string Method = "post";
            string FormName = "form1";

            NameValueCollection FormFields = new NameValueCollection();
            FormFields.Add("account_id", "10755");
            FormFields.Add("reference_no", "12000");
            FormFields.Add("amount", "5000");
            FormFields.Add("description", "TEST");
            FormFields.Add("name", "Tinu");
            FormFields.Add("address", "test");
            FormFields.Add("city", "test");
            FormFields.Add("state", "test");
            FormFields.Add("postal_code", "600021");
            FormFields.Add("country", "test");
            FormFields.Add("email", "testemail@ebs.in");
            FormFields.Add("phone", "9876543210");
            FormFields.Add("ship_name", "test");
            FormFields.Add("ship_address", "test");
            FormFields.Add("ship_city", "test");
            FormFields.Add("ship_state", "test");
            FormFields.Add("ship_postal_code", "600021");
            FormFields.Add("ship_country", "test");
            FormFields.Add("ship_phone", "9876543210");
            FormFields.Add("return_url", "http://localhost:2741/EBS-asp.net/response.aspx?DR={DR}");
            FormFields.Add("mode", "TEST");

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


    }
}