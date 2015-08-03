using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EncryptLib;

namespace Encrypt.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write("test");
            Response.Write("md5 32位加密:"+MD5Helper.Get32Md5("1"));
        }
    }
}