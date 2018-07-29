using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace convert2_xbrl.BL
{
    public class clsCart
    {
        #region DBConnection
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter ad;

        public clsCart()
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

        #region Cart
        public int CartProcessSelect(int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from cart where user_id=" + "'" + id + "'";
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
        public int CartProcessDelete(int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete cart where user_id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        public int CartProcessInsert(int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Insert Into cart(user_id,product_id,price,quantity,amount,tax1,totalamt) Values('" + id + "','1','4500','1','4500','630','5130')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }

        public int CartUpdate(int quentity, int amount, int tex, int totalAmount, int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "update cart set quantity='" + quentity + "',amount='" + amount + "',tax1='" + tex + "',totalamt='" + totalAmount + "' where user_id='" + id + "'";
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

            cmd.CommandText = "delete cart where user_id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            return 1;
        }

        #region Cart_Checkout
        public int InsCheckoutEntry(int userID, string Bname, string Baddress, string Bcity, string Bstate, string Bzip, string Bcountry, string Bemail, string Btelphone, string Sname, string Saddress, string Scity, string Sstate, string Szip, string Scountry, string Stelephone, string referedBy)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into checkout_data(user_id,billing_name,billing_address,billing_city,billing_state,billing_zip,billing_country,billing_email,billing_telephone,shipping_name,shipping_address,shipping_city,shipping_state,shipping_zip,shipping_country,shipping_telephone,refered_by,added_date) values ('" + userID + "','" + Bname + "','" + Baddress + "','" + Bcity + "','" + Bstate + "','" + Bzip + "','" + Bcountry + "','" + Bemail + "','" + Btelphone + "','" + Sname + "','" + Saddress + "','" + Scity + "','" + Sstate + "','" + Szip + "','" + Scountry + "','" + Stelephone + "','" + referedBy + "','" + DateTime.Now + "')";
            cmd.ExecuteNonQuery();
            return 1;
        }
        public DataTable GetTopMostCID()
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT TOP 1 * FROM [converu6_xbrl].[dbo].[checkout_data] ORDER BY id desc";
                DataTable dt = new DataTable();
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetContetntByCID(int id)
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from checkout_data where id='" + id + "'";
                DataTable dt = new DataTable();
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #endregion

        #region Finance_Cart
        public int FinanceCartProcessSelect(int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from finance_cart where user_id=" + "'" + id + "'";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
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
        public int FinanceCartProcessInsert(int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Insert Into finance_cart(user_id,product_id,price,quantity,amount,tax1,totalamt) Values('" + id + "','1','4500','1','4500','630','5130')";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }

        public int FinanceCartUpdate(int quentity, int amount, int tex, int totalAmount, int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "update finance_cart set quantity='" + quentity + "',amount='" + amount + "',tax1='" + tex + "',totalamt='" + totalAmount + "' where user_id='" + id + "'";
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

        public DataTable GetFCartContentbyID(int id)
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from finance_cart where user_id='" + id + "'";
                DataTable dt = new DataTable();
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region Finance_CheckOut
        public int InsFinanceCheckoutEntry(int userID, string Bname, string Baddress, string Bcity, string Bstate, string Bzip, string Bcountry, string Bemail, string Btelphone, string Sname, string Saddress, string Scity, string Sstate, string Szip, string Scountry, string Stelephone, string referedBy)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into finance_checkout_data(user_id,billing_name,billing_address,billing_city,billing_state,billing_zip,billing_country,billing_email,billing_telephone,shipping_name,shipping_address,shipping_city,shipping_state,shipping_zip,shipping_country,shipping_telephone,refered_by,added_date) values ('" + userID + "','" + Bname + "','" + Baddress + "','" + Bcity + "','" + Bstate + "','" + Bzip + "','" + Bcountry + "','" + Bemail + "','" + Btelphone + "','" + Sname + "','" + Saddress + "','" + Scity + "','" + Sstate + "','" + Szip + "','" + Scountry + "','" + Stelephone + "','" + referedBy + "','" + DateTime.Now + "')";
            cmd.ExecuteNonQuery();
            return 1;
        }
        public DataTable GetTopMostFID()
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT TOP 1 * FROM [converu6_xbrl].[dbo].[finance_checkout_data] ORDER BY id desc";
                DataTable dt = new DataTable();
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DataTable GetContetntByFID(int id)
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from finance_checkout_data where id='" + id + "'";
                DataTable dt = new DataTable();
                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
        #endregion

        #region Three_Five_Cart
        public int ThreeFiveCartUpdate(int quentity, int amount, int id)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "update cart set quantity='" + quentity + "',amount='" + amount + "' where user_id='" + id + "'";
            cmd.CommandType = CommandType.Text;
            ad = new SqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            return 1;
        }
        #endregion
    }
}