using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAPIClient.TestView
{
    public partial class alipay : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderID"] == null || Request.QueryString["tid"] == null)
            {
                payyrl.Src = "http://localhost:8066/404/";
            }
            else
            {
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
                Response.Write("<script>window.location='" + retString + "'</script>");
            }
            
        }
    }
}