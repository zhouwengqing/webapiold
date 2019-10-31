using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：上传文件
    /// </summary>
    public class UploadController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 
        /// </summary>
        /// 
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage upload()
        {
            string result = "";
            HttpFileCollection filelist = HttpContext.Current.Request.Files;
            string chinaname = filelist.Keys[0];
            try
            {
                if (filelist != null && filelist.Count > 0)
                {
                    for (int i = 0; i < filelist.Count; i++)
                    {
                        HttpPostedFile file = filelist[i];
                        String Tpath = "/" + DateTime.Now.ToString("yyyy-MM-dd") + "/";
                        string filename = file.FileName;
                        filename = System.Web.HttpUtility.UrlDecode(chinaname) + ".doc";
                        string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string FilePath = "C://exportword/download";
                        DirectoryInfo di = new DirectoryInfo(FilePath);
                        if (!di.Exists) { di.Create(); }
                        try
                        {
                            file.SaveAs(FilePath + @"//" + filename);                        
                        }
                        catch (Exception ex)
                        {
                            result = rule.JsonStr("error", "", ex.Message);
                        }
                    }
                }               
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }




            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


    }
}
