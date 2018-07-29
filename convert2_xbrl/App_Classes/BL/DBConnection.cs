using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace convert2_xbrl.BL
{
    public class DBConnection
    {
        #region Basic_Rules
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter ad;

        public DBConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["converu6_xbrlEntities"].ToString());
        }

        public void status()
        {

            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
        }
        public DataTable GetDataTable(string query)
        {
            try
            {

                DataTable dt = new DataTable();
                status();
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                ad = new SqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExecuteNonQuery(string query)
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region QueryString
        public int CheckVerifyID(string verifyID)
        {
            try
            {
                status();

                cmd = new SqlCommand();
                cmd.Connection = con;
                DataTable dt = new DataTable();
                cmd.CommandText = "select * from registration where verify_id=" + "'" + verifyID + "'";

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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                ad.Dispose();
            }
        }
        public int UpdateRegistration(string verifyID)
        {
            try
            {
                status();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update registration SET status='1',user_type='1' where verify_id='" + verifyID + "'";

                cmd.CommandType = CommandType.Text;
                ad = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                ad.Dispose();
            }
        }
        #endregion

        #region Login
        public int CheckAuthentication(string username, string password)
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.Connection = con;
                DataTable dt = new DataTable();
                cmd.CommandText = "select * from registration where username=" + "'" + username + "'" + " AND password=" + "'" + password + "' AND status='1' AND user_type='1'";

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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdatePassword(int UserID, string NewPassword)
        {
            try
            {
                status();

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Update registration SET password='" + NewPassword + "' where id='" + UserID + "'";

                cmd.CommandType = CommandType.Text;
                ad = new SqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                ad.Dispose();
            }
        }        
        #endregion

        #region Unsubscribe
        public int UserSubscription(string email)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from registration where email='"+email+"'";
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
        #endregion

        #region Registration
        public string RandomKey(int Size)
        {
            string input = "abcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            Random rd = new Random();
            for (int i = 0; i < Size; i++)
            {
                ch = input[rd.Next(0, input.Length)];
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public int SendMail(string toaddress, string subject, string strHTML)
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();

            try
            {
                MailAddress fromAddress = new MailAddress(toaddress);

                // You can specify the host name or ipaddress of your server
                // Default in IIS will be localhost 

                smtpClient.Host = ConfigurationManager.AppSettings["SMTP"].ToString();

                //Default port will be 25
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"].ToString());

                //From address will be given as a MailAddress Object
                message.From = fromAddress;

                // To address collection of MailAddress
                message.To.Add(toaddress);
                message.Subject = subject;


                message.IsBodyHtml = true;

                // Message body content
                message.Body = strHTML;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                // Send SMTP mail
                // ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("patelsignal@gmail.com", "signal@321");

                smtpClient.Send(message);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int UserRegistration(string fname, string lname, string email, string phone, string firm, string username, string psw, string varifyID, string city)
        {
            try
            {
                status();
                cmd = new SqlCommand();
                cmd.CommandText = "Insert into registration(fname,lname,email,phone,firm,username,password,verify_id,status,user_type,city) values(" + "'" + fname + "','" + lname + "','" + email + "','" + phone + "','" + firm + "','" + username + "','" + psw + "','" + varifyID + "','0','0','" + city + "')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                return 1;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region FeedBack
        public int InsertFeedBack(string name, string mNo, string type, string number, string feedback)
        {
            status();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into feedback (name,m_number,type,number,feedback) values ('" + name + "','" + mNo + "','" + type + "','" + number + "','" + feedback + "')";
            cmd.ExecuteNonQuery();

            return 1;
        }
        #endregion

        //#region Order
        //public int SendOrderMail(string toAddress, string subject, string strHTML)
        //{
        //    SmtpClient smtpClient = new SmtpClient();
        //    MailMessage message = new MailMessage();

        //    try
        //    {
        //        MailAddress fromAddress = new MailAddress(toAddress);

        //        // You can specify the host name or ipaddress of your server
        //        // Default in IIS will be localhost 

        //        smtpClient.Host = ConfigurationManager.AppSettings["SMTP"].ToString();

        //        //Default port will be 25
        //        smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"].ToString());

        //        //From address will be given as a MailAddress Object
        //        message.From = fromAddress;

        //        // To address collection of MailAddress
        //        message.To.Add(toAddress);
        //        message.Subject = subject;


        //        message.IsBodyHtml = true;

        //        // Message body content
        //        message.Body = strHTML;
        //        smtpClient.UseDefaultCredentials = true;
        //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        // Send SMTP mail
        //        // ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
        //        smtpClient.EnableSsl = true;
        //        smtpClient.Credentials = new System.Net.NetworkCredential("patelsignal@gmail.com", "signal@321");

        //        smtpClient.Send(message);
        //        return 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        return 0;
        //    }
        //}
        //#endregion
    }
}