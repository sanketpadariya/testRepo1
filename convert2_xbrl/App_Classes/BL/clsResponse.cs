using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace convert2_xbrl.BL
{
    public class clsResponse
    {
        #region DBConnection
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter ad;

        public clsResponse()
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

        #region Finance_Resonse
        public int financeOrderIns(int orderID, int userID, int trnID, string dateAdded, int paymentStatus, int amount, int quantiity, float tax, float totalAmoutnt)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into finance_order(order_id,user_id,t_id,added_date,payment_status,amount,quantity,reference,IsAccept,tax1,totalamt) values('" + orderID + "','" + userID + "','" + trnID + "','" + dateAdded + "','" + paymentStatus + "','" + amount + "','" + quantiity + "','','1','" + tax + "','" + totalAmoutnt + "')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int financeBillingInfo(int orderID, string name, string addres, string city, string state, int zip, string email, string phone)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into finance_billing_information(order_id,name,address,city,state,zip,country,email,phone) values('"+orderID+"','"+name+"','"+addres+"','"+city+"','"+state+"','"+zip+"','India','"+email+"','"+phone+"')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int financeShipingInfo(int orderID, string name, string addres, string city, string state, int zip, string phone)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into finance_shipping_information(order_id,name,address,city,state,zip,country,phone) values('" + orderID + "','" + name + "','" + addres + "','" + city + "','" + state + "','" + zip + "','India','" + phone + "')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int financeActivate(int paymentID, string name, string email,string dateAdded, int qty)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into finance_activate(payment_id,name,email,status,date_time,m_add,qty,usedqty) values('" + paymentID+ "','" + name + "','" + email+ "','0','" + dateAdded+ "','','"+qty+"','')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int FinanceCartDelete(int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete finance_cart where user_id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        #endregion

        #region Cart_Resonse
        public int OrderIns(int orderID, int userID, int trnID, string dateAdded, int paymentStatus, int amount, int quantiity, float tax, float totalAmoutnt)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into order_info(order_id,user_id,t_id,added_date,payment_status,amount,quantity,reference,IsAccept,tax1,totalamt) values('" + orderID + "','" + userID + "','" + trnID + "','" + dateAdded + "','" + paymentStatus + "','" + amount + "','" + quantiity + "','','1','" + tax + "','" + totalAmoutnt + "')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int BillingInfo(int orderID, string name, string addres, string city, string state, int zip, string email, string phone)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into billing_information(order_id,name,address,city,state,zip,country,email,phone) values('" + orderID + "','" + name + "','" + addres + "','" + city + "','" + state + "','" + zip + "','India','" + email + "','" + phone + "')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int ShipingInfo(int orderID, string name, string addres, string city, string state, int zip, string phone)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into shipping_information(order_id,name,address,city,state,zip,country,phone) values('" + orderID + "','" + name + "','" + addres + "','" + city + "','" + state + "','" + zip + "','India','" + phone + "')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int Activate(int paymentID, string name, string email, string dateAdded, int qty)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into activate(payment_id,name,email,status,date_time,m_add,qty,usedqty) values('" + paymentID + "','" + name + "','" + email + "','0','" + dateAdded + "','','" + qty + "','')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int CartDelete(int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete finance_cart where user_id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        #endregion
    }
}