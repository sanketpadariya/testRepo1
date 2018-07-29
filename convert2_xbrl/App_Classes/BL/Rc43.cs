using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace convert2_xbrl.BL
{
    public class Rc43
    {
        private int ord(char ch)
        {
            return (int)(Encoding.GetEncoding(1252).GetBytes(ch + "")[0]);
        }

        private char chr(int i)
        {
            byte[] bytes = new byte[1];
            bytes[0] = (byte)i;
            return Encoding.GetEncoding(1252).GetString(bytes)[0];
        }

        private string pack(string packtype, string datastring)
        {
            int i, j, datalength, packsize;
            byte[] bytes;
            char[] hex;
            string tmp;

            datalength = datastring.Length;
            packsize = (datalength / 2) + (datalength % 2);
            bytes = new byte[packsize];
            hex = new char[2];

            for (i = j = 0; i < datalength; i += 2)
            {
                hex[0] = datastring[i];
                if (datalength - i == 1)
                    hex[1] = '0';
                else
                    hex[1] = datastring[i + 1];
                tmp = new string(hex, 0, 2);
                try { bytes[j++] = byte.Parse(tmp, System.Globalization.NumberStyles.HexNumber); }
                catch { } /* grin */
            }
            return Encoding.GetEncoding(1252).GetString(bytes);
        }

        public string bin2hex(string bindata)
        {
            int i;
            byte[] bytes = Encoding.GetEncoding(1252).GetBytes(bindata);
            string hexString = "";
            for (i = 0; i < bytes.Length; i++)
            {
                hexString += bytes[i].ToString("x2");
            }
            return hexString;
        }

        public string Encrypt(string pwd, string data, bool ispwdHex)
        {
            int a, i, j, k, tmp, pwd_length, data_length;
            int[] key, box;
            byte[] cipher;
            //string cipher;

            if (ispwdHex)
                pwd = pack("H*", pwd); // valid input, please!
            pwd_length = pwd.Length;
            data_length = data.Length;
            key = new int[256];
            box = new int[256];
            cipher = new byte[data.Length];
            //cipher = "";

            for (i = 0; i < 256; i++)
            {
                key[i] = ord(pwd[i % pwd_length]);
                box[i] = i;
            }
            for (j = i = 0; i < 256; i++)
            {
                j = (j + box[i] + key[i]) % 256;
                tmp = box[i];
                box[i] = box[j];
                box[j] = tmp;
            }
            for (a = j = i = 0; i < data_length; i++)
            {
                a = (a + 1) % 256;
                j = (j + box[a]) % 256;
                tmp = box[a];
                box[a] = box[j];
                box[j] = tmp;
                k = box[((box[a] + box[j]) % 256)];
                cipher[i] = (byte)(ord(data[i]) ^ k);
                //cipher += chr(ord(data[i]) ^ k);
            }
            return Encoding.GetEncoding(1252).GetString(cipher);
            //return cipher;
        }

        public string Decrypt(string pwd, string data, bool ispwdHex)
        {
            return Encrypt(pwd, data, ispwdHex);
        }
    }
}