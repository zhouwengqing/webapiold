using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using ZXing.QrCode;

namespace WebAPIClient.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Xalipay : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
           

            string OrderID = Request.QueryString["OrderID"].ToString();
            string tid = Request.QueryString["tid"].ToString();
            string serviceAddress = "http://localhost:7983/actionapi/alipay/paycode?OrderID=" + OrderID + "&tid=" + tid;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceAddress);
            request.Method = "GET";
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            JToken json = JToken.Parse(retString);

            this.amount.Value = decimal.Parse(json["amount"].ToString()).ToString("F2");

            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions();
            options.DisableECI = true;
            //设置内容编码
            options.CharacterSet = "UTF-8";
            //设置二维码的宽度和高度
            options.Width = 300;
            options.Height = 300;
            //设置二维码的边距,单位不是固定像素
            options.Margin = 1;
            writer.Options = options;

            Bitmap map = writer.Write(json["url"].ToString());
            string path = @"~\Code\";
            path = HostingEnvironment.MapPath(path);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = path + @"\" + OrderID + ".PNG";
            map.Save(path, ImageFormat.Png);
            map.Dispose();
            string fileName = path;


            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                byte[] byteArray = new byte[fs.Length];
                fs.Read(byteArray, 0, byteArray.Length);
                string result = Convert.ToBase64String(byteArray);
                this.imgamu.Value = "data:image/png;base64," + result;
            }


        }
    }
}