using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Drawing;
using System.Net.Http.Headers;

namespace EMCCommon.Common
{
    /// <summary>
    /// 针对报告生成的操作
    /// </summary>
    public class GetReportController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：根据前端回传的是base64，解码成图片并保存
        /// 创建  人：周文卿
        /// 创建时间：2017/10/23
        /// 修改  人：
        /// 修改时间：
        /// 修改原因：
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage getimg(dynamic img)
        {
            string result = "";
            try
            {
                string path = img.path;
                string datetime = GetTimeStamp();
                string suffix = ".png"; //文件的后缀名根据实际情况
                string strPath = path + img.filename + suffix;

                //获取图片并保存
                Base64ToImg(img.firstName.ToString().Split(',')[1]).Save(strPath);
                result = rule.JsonStr("ok", "", img.filename + suffix);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        //解析base64编码获取图片
        private Bitmap Base64ToImg(string base64Code)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64Code));
            return new Bitmap(stream);
        }

        //获取当前时间段额时间戳
        public string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        /// <summary>
        /// 功能描述：根据前端传来的html页面导入到word
        /// 创建  人：周文卿
        /// 创建时间：2017/10/23
        /// 修改  人：
        /// 修改时间：
        /// 修改原因：
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetReportYN(dynamic html)
        {
            string result = "";
            try
            {
                AsposeWordsHelper wd = new AsposeWordsHelper();
                string filename = @html.path.ToString() + @"\" + html.filename.ToString() + ".doc";
                html.projectpath = html.projectpath.ToString().Replace(@"\\", @"/");
                if (html.allhtml.ToString().Contains("img"))
                {
                    html.allhtml = html.allhtml.ToString().Replace(@"static/img/", html.projectpath.ToString() + @"/");
                }
                //判断文件夹是否存在 如果不存在就创建
                if (!Directory.Exists(html.path.ToString()))
                {
                    Directory.CreateDirectory(html.path.ToString());
                }
                wd.htmlword("<html><head></head><body>" + html.allhtml + "</body></html>", filename);
                result = rule.JsonStr("ok", "", filename); ;
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }





        /// <summary>
        /// 功能描述：返回一个文件另存为
        /// 创建  人：周文卿
        /// 创建时间：2017/10/23
        /// 修改时间：
        /// 修改  人：
        /// 修改原因：
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetFileFromWebApi(string path, string filname)
        {

            var browser = String.Empty;
            if (HttpContext.Current.Request.UserAgent != null)
            {
                browser = HttpContext.Current.Request.UserAgent.ToUpper();
            }
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", HttpUtility.UrlDecode(filname) + ".doc");
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            FileStream fileStream = File.OpenRead(HttpUtility.UrlDecode(@path));
            httpResponseMessage.Content = new StreamContent(fileStream);
            httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            httpResponseMessage.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName =
                    browser.Contains("FIREFOX")
                        ? Path.GetFileName(filePath)
                        : HttpUtility.UrlEncode(Path.GetFileName(filePath))
            };
            return ResponseMessage(httpResponseMessage);
        }



    }
}
