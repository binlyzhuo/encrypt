using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EncryptLib;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace Encrypt.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("test");
            Response.Write("md5 32位加密:"+MD5Helper.Get32Md5("1"));
            Response.Write("<br/>");
            Response.Write("RSA加密算法!!#####@@~~");

            RSACryptoServiceProvider crypt = new RSACryptoServiceProvider();
            string publickey = crypt.ToXmlString(false);//公钥
            string privatekey = crypt.ToXmlString(true);//私钥

            crypt.Clear();

            StreamWriter one = new StreamWriter(Server.MapPath("a.txt"), true, UTF8Encoding.UTF8);
            one.Write(publickey);
            StreamWriter two = new StreamWriter(Server.MapPath("b.txt"), true, UTF8Encoding.UTF8);
            two.Write(privatekey);
            one.Flush();
            two.Flush();
            one.Close();
            two.Close();

            //=================================
            StreamReader sr = new StreamReader(Server.MapPath("a.txt"), UTF8Encoding.UTF8);
            string readpublickey = sr.ReadToEnd(); //包含 RSA 密钥信息的 XML 字符串。
            sr.Close();
            UTF8Encoding enc = new UTF8Encoding();
            byte[] bytes = enc.GetBytes("Just2");
            RSACryptoServiceProvider crypt2 = new RSACryptoServiceProvider();
            crypt2.FromXmlString(readpublickey);
            bytes = crypt2.Encrypt(bytes, false);
            string encryttext = Convert.ToBase64String(bytes);
            string abb = Server.UrlEncode(encryttext);
            Response.Write("<br/>");
            Response.Write("密文为:" + abb);

            //=================================
            StreamReader sr3 = new StreamReader(Server.MapPath("b.txt"), UTF8Encoding.UTF8);
            string readprivatekey = sr3.ReadToEnd();
            sr3.Close();
            RSACryptoServiceProvider crypt3 = new RSACryptoServiceProvider();
            UTF8Encoding enc3 = new UTF8Encoding();
            string sss = "BCOyV%2bmK7u8Gp26JZ2qeEXzZM8ColhiYMa1e992ojU6dPTWWIFVqLAb60%2b5Yt4rl7aw%2f8ZJltZck4ftKkSc%2fXYQZP7OM2wmQn6U6QeYF84Hi1jhT4abYoXAMRyxPfR7Y69pjJLxU4WNG3cXh%2bR3maeb24FSTxtltY2mGDc3xaho%3d";
            byte[] bytes3 = Convert.FromBase64String(@Server.UrlDecode(sss));
            crypt3.FromXmlString(readprivatekey);
            byte[] decryptbyte = crypt3.Decrypt(bytes, false);
            string decrypttext = enc.GetString(decryptbyte);
            Response.Write("<br/>");
            Response.Write("明文为:" + decrypttext);
        }
    }
}