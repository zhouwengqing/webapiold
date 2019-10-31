using DDYZ.Ensis.Rule.DataRule;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Presistence.DataEntity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.IO;

namespace EMCControls_EMCMIS.EMCMIS.other
{
    /// <summary>
    /// 创建  人：周文卿
    /// 创建时间：2018年3月24日
    /// 功能描述：上报时上传附件
    /// </summary>
    public class UploadAttachmentController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：上传附件
        /// 创建  人：周文卿
        /// 创建时间：2018/3/24
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage UploadAttach()
        {
            string result = string.Empty;
            try
            {

                HttpFileCollection filelist = HttpContext.Current.Request.Files;
                if (filelist != null && filelist.Count > 0)
                {
                    for (int i = 0; i < filelist.Count; i++)
                    {
                        HttpPostedFile file = filelist[i];
                        String Tpath = DateTime.Now.ToString("yyyy-MM-dd");
                        string filename = file.FileName;
                        string FileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string FilePath = @"C:\transfer\DocManageTemp\\" + Tpath + "\\" + FileName + "\\";
                        DirectoryInfo di = new DirectoryInfo(FilePath);
                        if (!di.Exists) { di.Create(); }
                        try
                        {
                            file.SaveAs(FilePath + filename);
                            string str = System.Web.HttpUtility.UrlEncode(@"\DocManageTemp\\" + Tpath + "\\" + FileName + "\\" + filename, System.Text.Encoding.GetEncoding("utf-8")).Replace("+", "%20");
                            result = rule.JsonStr("ok", "文件上传成功！", str);
                            //result.obj = (Tpath + FileName).Replace("\\", "/");
                        }
                        catch (Exception ex)
                        {
                            result = rule.JsonStr("no", "上传文件写入失败：" + ex.Message, "");
                        }
                    }
                }
                else
                {
                    result = rule.JsonStr("no", "文件不存在", "");
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        ///  功能描述：插入到tblDocManage表
        ///  创建  人：周文卿
        ///  创建时间：2018/3/24
        ///  修改  人：
        ///  修改时间：
        ///  修改原因：
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage InsetDoc(pram tbl)
        {
            string result = string.Empty;
            #region 查询本月是否有导入附件
            DataTable dt = rule.getdt("select fldSTCode,fldSTName,fldAutoId,fldParentID from LAPtblFW_RegCity");
            tblDocManage tblDocManage = new tblDocManage();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (tbl.cityid == dt.Rows[i]["fldAutoid"].ToString())
                {
                    tblDocManage.fldSTCode = dt.Rows[i]["fldSTCode"].ToString();
                    tblDocManage.fldSTName = dt.Rows[i]["fldSTName"].ToString();
                }
            }
            string filname = "";
            string path = "";
            DataTable dt1 = rule.getdt("select * from tblDocManage where fldSTName='" + tblDocManage.fldSTName + "'");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime timedoc = DateTime.Parse(dt1.Rows[i]["fldDocDate"].ToString());
                if (timedoc.Month == DateTime.Now.Month && timedoc.Year == DateTime.Now.Year)
                {
                    filname = dt.Rows[i]["fldDocName"].ToString();
                    path = dt.Rows[i]["fldDocPath"].ToString();
                }
            }
            #endregion
            #region 插入
            if (filname == "" && path == "")
            {
                tblDocManage.fldBusinessType = System.Web.HttpUtility.UrlDecode(tbl.fldBusinessType);
                tblDocManage.fldDocDate = DateTime.Now.ToShortDateString();
                tblDocManage.fldDocName = tbl.DocName;
                tblDocManage.fldDocPath = System.Web.HttpUtility.UrlDecode(tbl.docpath);
                tblDocManage.fldOperate_UserID = tbl.userid;
                tblDocManage.fldisReport = false;
                tblDocManage.fldFileClassify = "区县上传-上报说明";
                tblDocManage.fldUpLoadDate = DateTime.Now.ToString();
                tblDocManage.fldReportingDate = "";
                usp_tblDocManage_Insert uspInsert = new usp_tblDocManage_Insert();
                uspInsert.ReceiveParameter(tblDocManage);
                int idex = uspInsert.ExecNoQuery();
               
                if (idex > 0)
                {
                    result = rule.JsonStr("ok", "", "");
                }
            }
            else
            {
                result = rule.JsonStr("repeat", "本月已经上传过附件！不能重复上传！", "");
            }
            #endregion
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：查询是否有数据
        /// 创建  人：周文卿
        /// 创建时间：2018/3/24
        /// 修改原因：
        /// 修改时间：
        /// 修改  人：
        /// </summary>
        /// <param name="name"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage selectdoc(string name, string time)
        {
            string result = string.Empty;


            string filname = "";
            string path = "";
            DataTable dt = rule.getdt("select * from tblDocManage where fldSTName='" + name + "'");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime timedoc = DateTime.Parse(dt.Rows[i]["fldDocDate"].ToString());
                if (timedoc.Month == DateTime.Parse(time).Month && timedoc.Year == DateTime.Parse(time).Year)
                {
                    filname = dt.Rows[i]["fldDocName"].ToString();
                    path = @"C:\transfer" + dt.Rows[i]["fldDocPath"].ToString();
                }
            }
            if (filname != "" && path != "")
            {
                pradoc doc = new pradoc();
                doc.filname = System.Web.HttpUtility.UrlEncode(filname);
                doc.path = System.Web.HttpUtility.UrlEncode(path);
                result = rule.JsonStr("ok", "", doc);
            }
            else
            {
                result = rule.JsonStr("no", "没有数据！", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 附件参数
        /// </summary>
        public class pradoc
        {
            /// <summary>
            /// 文件名称
            /// </summary>
            public string filname { get; set; }

            /// <summary>
            /// 文件保存地址
            /// </summary>
            public string path { get; set; }
        }

        /// <summary>
        /// 功能描述：下载附件
        /// 创建  人：周文卿
        /// 创建时间：2018/03/24
        /// 修改原因：
        /// 修改时间：
        /// 修改  人：
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IHttpActionResult GetFile(string path, string filname)
        {

            var browser = String.Empty;


            if (HttpContext.Current.Request.UserAgent != null)
            {
                browser = HttpContext.Current.Request.UserAgent.ToUpper();
            }
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content", HttpUtility.UrlDecode(filname));
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            FileStream fileStream = File.OpenRead(HttpUtility.UrlDecode(@path));
            httpResponseMessage.Content = new StreamContent(fileStream);
            httpResponseMessage.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            httpResponseMessage.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName =
                    browser.Contains("FIREFOX")
                        ? Path.GetFileName(filePath)
                        : HttpUtility.UrlEncode(Path.GetFileName(filePath))
            };
            return ResponseMessage(httpResponseMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        public class pram
        {
            /// <summary>
            /// 城市id
            /// </summary>
            public string cityid { get; set; }

            /// <summary>
            /// 业务类别
            /// </summary>
            public string fldBusinessType { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string userid { get; set; }

            /// <summary>
            /// 文件名称
            /// </summary>
            public string DocName { get; set; }

            public string docpath { get; set; }
        }
    }
}
