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
            Response.Write("IP: " + ip + "</br>");

            //This is the local IP in our test environment
            if (!ip.Equals("::1"))
            {
                string city = String.Empty;
                string country = String.Empty;
                string region = String.Empty;

                //System.Xml.XmlTextReader hostIPInfoReader = new System.Xml.XmlTextReader("http://freegeoip.net/xml/?q=" + ip);
                System.Xml.XmlTextReader hostIPInfoReader = new System.Xml.XmlTextReader("http://api.ipinfodb.com/v3/ip-city/?key=fa99e1cbc2f3dc6f26cc3e2674456979e8aa93f26e64e266ed31062604b9e63f&format=xml&ip=" + ip);
                try
                {

                    while (hostIPInfoReader.Read())
                    {
                        if (hostIPInfoReader.IsStartElement())
                        {
                            Response.Write(hostIPInfoReader.Name + ":" + hostIPInfoReader.ReadString() + "</br>");
                        }
                    }
                }
                //        if (hostIPInfoReader.Name == "City")
                //            city = hostIPInfoReader.ReadString();

                //        if (hostIPInfoReader.Name == "CountryName")
                //            country = hostIPInfoReader.ReadString();

                //        if (hostIPInfoReader.Name == "RegionName")
                //            region = hostIPInfoReader.ReadString();

                //    }
                //}
                //Response.Write("City: " + city + " Country: " + country + " Region: " + region + "</br>" );
                //}
                catch
                {
                    Response.Write("ip geo-lookup failed" + "</br>");
                }
            }


        }

    }
}