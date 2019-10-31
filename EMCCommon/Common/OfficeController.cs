using Aspose.Words;
using Aspose.Words.Saving;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCCommon.Common
{
    public class OfficeController : ApiController
    {

        RuleCommon rule = new RuleCommon();


        [HttpPost]
        public HttpResponseMessage WordConvertHtml(WordConvertHtml_Info info)
        {
            string result = string.Empty;
            try
            {

                string path = HttpUtility.UrlDecode(info.path);






                string guid = Guid.NewGuid().ToString();



                if (path.IndexOf(".docx") > 0 || path.IndexOf(".doc") > 0)
                {

                    Aspose.Words.Document doc = new Aspose.Words.Document(path);

                    HtmlSaveOptions hso = new HtmlSaveOptions(SaveFormat.Html);


                    doc.Save(@"C:/docpreview/" + guid + ".html", hso);
                }






                if (path.IndexOf(".xlsx") > 0 || path.IndexOf(".xls") > 0)
                {
                    using (System.IO.Stream stream = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                    {
                        Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook(stream);
                        //if (workbook.Worksheets.Count <= 0)
                        //{
                        //}


                        workbook.Save(@"C:/docpreview/" + guid + ".html", Aspose.Cells.SaveFormat.Html);
                    }
                }





















                WordConvertHtml_Return rt = new WordConvertHtml_Return();
                rt.GUID_Html = guid;






















                if (true)
                {
                    result = rule.JsonStr("ok", "", rt);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class WordConvertHtml_Info
        {
            /// <summary>
            /// 上传后服务器物理地址
            /// </summary>
            public string path { get; set; }
        }


        public class WordConvertHtml_Return
        {
            public string GUID_Html { get; set; }
        }


    }
}
