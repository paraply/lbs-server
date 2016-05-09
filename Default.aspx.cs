using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
   {
        String uid = Request.QueryString["id"];
        if (!String.IsNullOrEmpty(uid)) // We only want to store data when we get an ID
        {
            Response.Write("GOT ID:" + uid + "</br>");
            String ip;
            HttpRequest httpReq = HttpContext.Current.Request;
            ip = httpReq.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(ip))
            {
                ip = httpReq.ServerVariables["REMOTE_ADDR"];
            }
            Response.Write("IP: " + ip);
        }

   }
}