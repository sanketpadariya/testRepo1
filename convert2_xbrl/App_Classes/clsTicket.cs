using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace convert2_xbrl.BL
{
    public class clsTicket
    {
        #region DBConnection
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter ad;

        public clsTicket()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString());
        }
        public void status()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
        }
        #endregion
                
        public int SubmitTicket(string name, string email, string phoneNo, string qTitle, string qDescription, int userID)
        {
            status();

            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Insert into ticket(name,email,phone,q_title,q_desc,status,user_id,date_time) Values('" + name + "','" + email + "','" + phoneNo + "','" + qTitle + "','" + qDescription + "','1','" + userID + "','" + DateTime.Now + "')";
            cmd.ExecuteNonQuery();

            return 1;
        }
        
        public int ViewTicket(int sessionID)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from ticket where user_id='" + sessionID + "' and status='1'";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}