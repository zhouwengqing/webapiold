using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_D
{
    /// <summary>
    /// 功能描述：饮用水点位附件信息
    /// 创建者  ：刘勇军
    /// 创建时间：2018-06-07
    /// </summary>
    public class Eqiw_D_Point_AnnexController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：查询点位附件信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEqiw_D_Point_Annex(Eqiw_D_Point_Annex_Info info)
        {
            string result = string.Empty;

            try
            {
                List<tblEQIW_D_Point_Annex> list = new List<tblEQIW_D_Point_Annex>();

                using (EntityContext db=new EntityContext())
                {
                    list = (from x in db.tblEQIW_D_Point_Annex
                            where x.fldFKID == info.fldFKID
                            select x).ToList();
                }

                if (list.Count>0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 参数实体
        /// </summary>
        public class Eqiw_D_Point_Annex_Info
        {
            public int fldFKID { get; set; }
        }



        /// <summary>
        /// 功能描述：获取图片列表
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="fldFKID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetImgList(int fldFKID)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_Point_Imgs.Where(e => e.fldFKID == fldFKID).ToList();
                    if (dt.Count() > 0)
                    {
                        result = rule.JsonStr("ok", "", dt);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有数据！", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：添加图片
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public HttpResponseMessage AddImg(List<tblEQIW_D_Point_Imgs> info)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_Point_Imgs.AddRange(info);
                     int i=db.SaveChanges();
                    if (i > 0)
                    {
                        result = rule.JsonStr("ok", "上传成功！", dt);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有数据！", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：删除图片
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-15
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage DelImg(int id)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_Point_Imgs.Where(e => e.fldAutoID == id).ToList();
                    db.tblEQIW_D_Point_Imgs.RemoveRange(dt);
                    int ret = db.SaveChanges();
                    if (ret <= 0)
                    {
                        result = rule.JsonStr("error", "没有可删除的数据！", "");
                    }
                    else
                    {
                        FileServer_Setting us = new FileServer_Setting();
                        string FilePath =ConfigurationSettings.AppSettings["PicPath"];
                        if (File.Exists(FilePath + dt[0].fldFilePath))
                        {
                            File.Delete(FilePath + dt[0].fldFilePath);
                        }
                        result = rule.JsonStr("ok", "", dt);
                    }
                }


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：更新图片数据
        /// 创建者  ：徐雍文
        /// 创建时间：2018-08-18
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public HttpResponseMessage UpdateImg(tblEQIW_D_Point_Imgs info)
        {
            string result = string.Empty;
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    var dt = db.tblEQIW_D_Point_Imgs.Where(e => e.fldAutoID == info.fldAutoID).ToList();
                    dt[0].fldFileIsShow = info.fldFileIsShow;
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        result = rule.JsonStr("ok", "更新成功！", dt);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有可更新的数据！", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：添加附件信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetAddPoint_Annex(AddPoint_Annex_Info info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                tblEQIW_D_Point_Annex annexInfo = new tblEQIW_D_Point_Annex();

                using (EntityContext db=new EntityContext())
                {
                    annexInfo.fldFKID = info.fldFKID;
                    annexInfo.fldAnnexName = info.fldAnnexName;
                    annexInfo.fldAnnexType = info.fldAnnexType;
                    annexInfo.fldFileType = info.fldFileType;
                    annexInfo.fldFileSize = info.fldFileSize;
                    annexInfo.fldFilePath = info.fldFilePath;
                    db.tblEQIW_D_Point_Annex.Add(annexInfo);
                    ret = db.SaveChanges();
                }

                if (ret>0)
                {
                    result = rule.JsonStr("ok", "", annexInfo);
                }
                else
                {
                    result = rule.JsonStr("error", "添加失败！", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 参数实体
        /// </summary>
        public class AddPoint_Annex_Info
        {
            public int fldFKID { get; set; }
            
            public string fldAnnexName { get; set; }
            
            public string fldAnnexType { get; set; }
            
            public string fldFileType { get; set; }
            
            public string fldFileSize { get; set; }
            
            public string fldFilePath { get; set; }
        }







        /// <summary>
        /// 功能描述：删除附件信息
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetDeletePoint_Annex(DeletePoint_Annex_Info info)
        {
            string result = string.Empty;
            int ret = 0;
            try
            {
                List< tblEQIW_D_Point_Annex> list = new List<tblEQIW_D_Point_Annex>();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblEQIW_D_Point_Annex
                            where x.fldAutoID == info.fldAutoID
                            select x).ToList();

                    db.tblEQIW_D_Point_Annex.RemoveRange(list);
                    ret = db.SaveChanges();
                }

                if (ret > 0)
                {
                    FileServer_Setting us = new FileServer_Setting();
                    string FilePath = ConfigurationSettings.AppSettings["PicPath"];
                    if (File.Exists(FilePath+list[0].fldFilePath))
                    {
                        File.Delete(FilePath+list[0].fldFilePath);
                    }
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("error", "删除失败！", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 参数实体
        /// </summary>
        public class DeletePoint_Annex_Info
        {
            public int fldAutoID { get; set; }
            
        }












        public class FileServer_Setting
        {
            public string FileDirectory { get; set; }
        }


        /// <summary>
        /// 功能描述：文件上传服务
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        // Post: api/FileServer/UploadServer
        [HttpPost]
        [HttpOptions]
        public IHttpActionResult UploadServer()
        {
            HttpFileCollection filelist = HttpContext.Current.Request.Files;



            if (filelist != null && filelist.Count > 0)
            {
                HttpPostedFile file = HttpContext.Current.Request.Files[0];
                string FldAutoID =HttpContext.Current.Request["FldAutoID"];
                FileServer_Setting us = new FileServer_Setting();

                UploadServer_Return rt = new UploadServer_Return();
                string FilePath = ConfigurationSettings.AppSettings["PicPath"];
                string fileExtension = System.IO.Path.GetExtension(file.FileName).ToLower();
                string FileGUID = Guid.NewGuid().ToString();

                DirectoryInfo di = new DirectoryInfo(FilePath+DateTime.Now.ToString("yyy-MM-dd") + @"\\");

                if (!di.Exists)
                {
                    di.Create();   
                }
                file.SaveAs(di.FullName + FileGUID + fileExtension);

                rt.FileGUID = DateTime.Now.ToString("yyy-MM-dd") + @"\\" + FileGUID + fileExtension;

                return Ok(rt);
            }
            else
            {
                return Ok("文件信息未获取！");
            }
        }




        public class UploadServer_Return
        {
            /// <summary>
            /// 返回参数：成功：返回GUID
            /// </summary>
            public string FileGUID { get; set; }
        }



























        /// <summary>
        /// 功能描述：文件下载服务
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        // Get: api/FileServer/DownloadServer
        [HttpGet] 
        public HttpResponseMessage DownloadServer(string FileGUID, string FileName)
        {
            FileServer_Setting us = new FileServer_Setting();

            string FilePath = ConfigurationSettings.AppSettings["PicPath"];

            var stream = new FileStream(FilePath+FileGUID, FileMode.Open);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(stream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = FileName
            };
            return response;
        }








        /// <summary>
        /// 功能描述：文件删除服务
        /// 创建者  ：刘勇军
        /// 创建时间：2018-06-07
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        // Post: api/FileServer/DeleteServer
        [HttpPost]
        [HttpOptions]
        public IHttpActionResult DeleteServer(DeleteServer_Info info)
        {
            FileServer_Setting us = new FileServer_Setting();

            DeleteServer_Return rt = new DeleteServer_Return();

            string FilePath = ConfigurationSettings.AppSettings["PicPath"];

            if (File.Exists(FilePath + info.FileGUID))
            {
                File.Delete(FilePath + info.FileGUID);
                rt.DeleteState = true;
            }

            return Ok(rt);
        }





        public class DeleteServer_Info
        {
            public string FileGUID { get; set; }
        }


        public class DeleteServer_Return
        {
            /// <summary>
            /// 返回参数：成功返回true
            /// </summary>
            public bool DeleteState { get; set; }
        }





    }
}
