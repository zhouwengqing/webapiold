using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPIClient.Pay
{
    public partial class H5Alipay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] == null || Request.QueryString["tid"] == null)
            {
               
            }
            else
            {
                //获得链接地址
                string OrderID = Request.QueryString["OrderID"].ToString();
                string tid = Request.QueryString["tid"].ToString();
                string serviceAddress = "http://localhost:7983/actionapi/alipay/pay?OrderID=" + OrderID + "&tid=" + tid;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
                request.Method = "GET";
                request.ContentType = "application/json";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                Response.Redirect(retString);


                //string serviceAddress2 = retString;
                //HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create(serviceAddress2);
                //request.Method = "POST";
                //request.ContentType = "application/json";
                //HttpWebResponse response2 = (HttpWebResponse)request2.GetResponse();
                //Stream myResponseStream2 = response2.GetResponseStream();
                //StreamReader myStreamReader2 = new StreamReader(myResponseStream2, Encoding.UTF8);
                //string retString2 = myStreamReader2.ReadToEnd();
                //myStreamReader.Close();
                //myResponseStream.Close();

                //Response.Write(retString2);

            }
        }
    }
}