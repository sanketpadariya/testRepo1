using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace convert2_xbrl
{
    public partial class Rc43 : System.Web.UI.Page
    {
        #region handler
        string[] s;
        int i = 0;
        int j = 0;
        int t = 0;
        string _key = "";
        string key = "";        
        int tmpStr = 0;

        int lnth = 0;
        #endregion

        #region Metod
        private static int ord(char ch)
        {
            return (int)(Encoding.GetEncoding(1252).GetBytes(ch + "")[0]);
        }
        private static char chr(int i)
        {
            byte[] bytes = new byte[1];
            bytes[0] = (byte)i;
            return Encoding.GetEncoding(1252).GetString(bytes)[0];
        }
        public Rc43(string key)
        { 
            if(key != null)
            {
                setKey(key);
            }
        }
        public void setKey(string k)
        {
            if(k.Length > 0)
            {
                _key = k;
            }
        }
        public void tpKey(string k)
        {
            lnth = k.Length;

            for (i = 0; i < 256; i++)
            {
                s[i] = i.ToString();
            }

            for (i = 0; i < 256; i++)
            {
                j = (j + Convert.ToInt32(s[i]) + (ord (key[i % lnth]))) % 256;
                t = Convert.ToInt32(s[i]);
                s[i] = s[j];
                s[j] = t.ToString();
            }
            i = 0;
            j = 0;
        }
        public void crypt(string paramStr)
        {
            key = _key;
            tmpStr = paramStr.Length;
            for (int c = 0; c < tmpStr; c++)
            {
                i = (i + 1) % 256;
                j = (j + i) % 256;
                t = Convert.ToInt32(s[i]);
                s[i] = s[j];
                s[j] = t.ToString();
                t = (Convert.ToInt32(s[i]) + Convert.ToInt32(s[j])) % 256;
                paramStr[c] = chr(ord(paramStr[c] ^ s[t]));
            }
        }
        public void decrypt(string paramString)
        {
            crypt(paramString);
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}