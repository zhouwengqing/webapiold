using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.other
{
    public class UploadAndDownloadForReportGenerationController : ApiController
    {

        RuleCommon rule = new RuleCommon();


        [HttpPost]
        public HttpResponseMessage Upload_File()
        {
            string result = string.Empty;
            try
            {

                List<string> list = new List<string>();

                HttpFileCollection filelist = HttpContext.Current.Request.Files;



                string FilePath = HostingEnvironment.MapPath(@"~/App_Data/ReportArchive/");

                DirectoryInfo di = new DirectoryInfo(FilePath);

                if (!di.Exists)
                {
                    di.Create();
                }

                if (filelist != null && filelist.Count > 0)
                {
                    for (int i = 0; i < filelist.Count; i++)
                    {
                        HttpPostedFile file = filelist[i];



                        string date = DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒");

                        file.SaveAs(FilePath + date);

                        list.Add(date);
                    }
                }
                else
                {
                    result = "上传的文件信息不存在！";
                }




                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }








        [HttpPost]
        public HttpResponseMessage Upload_File_V2()
        {
            string result = string.Empty;
            try
            {

                List<string> list = new List<string>();

                HttpFileCollection filelist = HttpContext.Current.Request.Files;



                //string FilePath = HostingEnvironment.MapPath(@"~/App_Data/ReportArchive/");

                DirectoryInfo di = new DirectoryInfo(@"C:/docpreview/");

                if (!di.Exists)
                {
                    di.Create();
                }

                if (filelist != null && filelist.Count > 0)
                {
                    for (int i = 0; i < filelist.Count; i++)
                    {
                        HttpPostedFile file = filelist[i];

                        var name = System.IO.Path.GetExtension(file.FileName);

                        //string date = DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒");

                        string guid = Guid.NewGuid().ToString();

                        string path = @"C:/docpreview/" + guid + name;

                        file.SaveAs(path);

                        list.Add(path);
                    }
                }
                else
                {
                    result = "上传的文件信息不存在！";
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }








        [HttpGet]
        public HttpResponseMessage Download_File_V2(string fldAutoID)
        {
            string result = string.Empty;
            try
            {
                int ID = int.Parse(fldAutoID);

                Model.tblReportArchive list = new Model.tblReportArchive();

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblReportArchive
                            where x.fldAutoID == ID
                            select x).ToList().FirstOrDefault();
                }

                var stream = new FileStream(list.fldPath, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = list.fldFileName
                };

                return response;


                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }



            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




































        /// <summary>
        ///  功能描述：河北报告归档上传
        ///  创建时间：20180708
        ///  创建  人：周文卿
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Upload_File_Hebei()
        {
            string result = string.Empty;
            try
            {

                List<string> list = new List<string>();

                HttpFileCollection filelist = HttpContext.Current.Request.Files;

                string FilePath = @"C://exportword/ReportArchive/";

                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }


                DirectoryInfo di = new DirectoryInfo(FilePath);

                if (!di.Exists)
                {
                    di.Create();
                }

                if (filelist != null && filelist.Count > 0)
                {
                    for (int i = 0; i < filelist.Count; i++)
                    {
                        HttpPostedFile file = filelist[i];

                        string name = file.FileName.Substring(file.FileName.LastIndexOf('.'));

                        string date = DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒");

                        file.SaveAs(FilePath + date + name);

                        list.Add(date + name);
                    }

                }
                else
                {
                    result = "上传的文件信息不存在！";
                }




                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public HttpResponseMessage Upload_IstallorUpdate(Upload_Data_Info info)
        {
            string result = string.Empty;
            try
            {


                int i = rule.Upload_IstallorUpdate(info.fldReport_Name, info.fldReport_Type, info.fldRName, info.fldUserID, info.fldTime, info.fldPath, info.fldFileName);
                if (i > 0)
                {
                    result = rule.JsonStr("ok", "", i);
                }
                else
                {
                    result = rule.JsonStr("ok", "", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        [HttpPost]
        public HttpResponseMessage Upload_Data(Upload_Data_Info info)
        {
            string result = string.Empty;
            try
            {

                Model.tblReportArchive list = new Model.tblReportArchive();
                list.fldAutoID = 0;
                list.fldReport_Name = info.fldReport_Name;
                list.fldReport_Type = info.fldReport_Type;
                list.fldRName = info.fldRName;
                list.fldUserID = info.fldUserID;
                list.fldTime = info.fldTime;
                list.fldPath = info.fldPath;
                list.fldFileName = info.fldFileName;

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    db.tblReportArchive.Add(list);
                    db.SaveChanges();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class Upload_Data_Info
        {
            public string fldReport_Name { get; set; }

            public string fldReport_Type { get; set; }

            public string fldRName { get; set; }

            public string fldUserID { get; set; }

            public string fldTime { get; set; }

            public string fldPath { get; set; }

            public string fldFileName { get; set; }
        }


















        [HttpPost]
        public HttpResponseMessage Upload_File_For_ElectronicFile()
        {
            string result = string.Empty;
            try
            {
                List<string> list = new List<string>();

                HttpFileCollection filelist = HttpContext.Current.Request.Files;

                string FilePath = @"C:/docpreview/";

                DirectoryInfo di = new DirectoryInfo(FilePath);

                if (!di.Exists)
                {
                    di.Create();
                }

                if (filelist != null && filelist.Count > 0)
                {
                    for (int i = 0; i < filelist.Count; i++)
                    {
                        HttpPostedFile file = filelist[i];

                        var name = System.IO.Path.GetExtension(file.FileName);

                        string guid = Guid.NewGuid().ToString();

                        file.SaveAs(FilePath + guid + name);

                        list.Add(FilePath + guid + name);
                    }
                }
                else
                {
                    result = "上传的文件信息不存在！";
                }




                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        [HttpPost]
        public HttpResponseMessage Upload_Data__For_ElectronicFile(Upload_Data__For_ElectronicFile_Info info)
        {
            string result = string.Empty;
            try
            {

                Model.ElectronicFile list = new Model.ElectronicFile();

                list.fldReport_Name = info.fldReport_Name;
                list.fldReport_Type = info.fldReport_Type;
                list.fldRName = info.fldRName;
                list.fldUserID = info.fldUserID;
                list.fldTime = DateTime.Now;
                list.fldPath = info.fldPath;
                list.fldFileName = info.fldFileName;

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    db.ElectronicFile.Add(list);
                    db.SaveChanges();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class Upload_Data__For_ElectronicFile_Info
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string fldReport_Name { get; set; }

            /// <summary>
            /// 类型
            /// </summary>
            public string fldReport_Type { get; set; }

            /// <summary>
            /// 河流名称
            /// </summary>
            public string fldRName { get; set; }

            /// <summary>
            /// 用户ID
            /// </summary>
            public string fldUserID { get; set; }

            /// <summary>
            /// 时间
            /// </summary>
            public string fldTime { get; set; }

            /// <summary>
            /// 路径
            /// </summary>
            public string fldPath { get; set; }

            /// <summary>
            /// 文件完整名称：文件名称+扩展名
            /// </summary>
            public string fldFileName { get; set; }
        }






























        [HttpPost]
        public HttpResponseMessage Upload_Delete(Upload_Delete_Info info)
        {
            string result = string.Empty;
            try
            {

                Model.tblReportArchive list = new Model.tblReportArchive();


                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblReportArchive
                            where x.fldAutoID == info.fldAutoID
                            select x).ToList().FirstOrDefault();


                    File.Delete(list.fldPath);

                    db.tblReportArchive.Remove(list);
                    db.SaveChanges();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class Upload_Delete_Info
        {
            public int fldAutoID { get; set; }
        }









        [HttpPost]
        public HttpResponseMessage Upload_Delete_For_ElectronicFile(Upload_Delete_For_ElectronicFile_Info info)
        {
            string result = string.Empty;
            try
            {

                Model.ElectronicFile list = new Model.ElectronicFile();
                List<Model.ElectronicFile> arr = new List<Model.ElectronicFile>();

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    foreach (var item in info.fldAutoID.Split(','))
                    {
                        int t = Convert.ToInt32(item.ToString());
                        list = (from x in db.ElectronicFile
                                where x.fldAutoID == t
                                select x).ToList().FirstOrDefault();

                        if (list.fldPath != null && list.fldPath != "")
                        {
                            File.Delete(list.fldPath);
                        }

                        db.ElectronicFile.Remove(list);
                        arr.Add(list);
                    }

                    db.SaveChanges();
                }

                result = rule.JsonStr("ok", "", arr);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class Upload_Delete_For_ElectronicFile_Info
        {
            public string fldAutoID { get; set; }
        }





















        [HttpPost]
        public HttpResponseMessage Upload_Query(Upload_Query_Info info)
        {
            string result = string.Empty;
            try
            {
                List<Model.tblReportArchive> list = new List<Model.tblReportArchive>();

                List<Model.tblReportArchive> listdata = new List<Model.tblReportArchive>();


                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblReportArchive
                            select x).ToList();
                }

                if (!(info.fldUserID == "admin"))
                {
                    list = (from x in list
                            where x.fldUserID == info.fldUserID
                            select x).ToList();
                }


                if (!(info.obj == "" || info.obj == null))
                {
                    var query1 = from x in list
                                 where x.fldReport_Name.Contains(info.obj)
                                 select x;

                    var query2 = from x in list
                                 where x.fldReport_Type.Contains(info.obj)
                                 select x;

                    var query3 = from x in list
                                 where x.fldRName.Contains(info.obj)
                                 select x;

                    var query4 = from x in list
                                 where x.fldTime.Contains(info.obj)
                                 select x;

                    listdata = query1.Union(query2).ToList();

                    listdata = listdata.Union(query3).ToList();

                    listdata = listdata.Union(query4).ToList();

                    list = listdata;
                }







                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class Upload_Query_Info
        {
            public string obj { get; set; }

            public string fldUserID { get; set; }
        }












        [HttpPost]
        public HttpResponseMessage Upload_Query_For_ElectronicFile(_For_ElectronicFile_Info info)
        {
            string result = string.Empty;
            try
            {
                List<Model.ElectronicFile> list = new List<Model.ElectronicFile>();

                List<Model.ElectronicFile> listdata = new List<Model.ElectronicFile>();


                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.ElectronicFile
                            select x).ToList();
                }

                if (!(info.fldUserID == "admin"))
                {
                    list = (from x in list
                            where x.fldUserID == info.fldUserID
                            select x).ToList();
                }

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                list = (from x in list
                        where x.fldTime >= BeginDate &&
                        x.fldTime <= EndDate
                        select x).ToList();


                if (!(info.obj == "" || info.obj == null))
                {
                    var query1 = from x in list
                                 where x.fldReport_Name.Contains(info.fldReport_Name)
                                 select x;

                    var query2 = from x in list
                                 where x.fldReport_Type.Contains(info.fldReport_Type)
                                 select x;

                    var query3 = from x in list
                                 where x.fldRName.Contains(info.fldRName)
                                 select x;


                    listdata = query1.Union(query2).ToList();

                    listdata = listdata.Union(query3).ToList();


                    list = listdata;
                }

                list = list.OrderByDescending(x => x.fldTime).ToList();




                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class _For_ElectronicFile_Info
        {
            /// <summary>
            /// 业务类型，确定参数，需要给
            /// </summary>
            public string fldReport_Type { get; set; }

            /// <summary>
            /// 文档目录，确定参数，可以自己赋予意义
            /// </summary>
            public string fldReport_Name { get; set; }

            /// <summary>
            /// 自己定义吧
            /// </summary>
            public string fldRName { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// 给null，就返回用户ID下，时间范围内的数据，不跟fldReport_Type、fldReport_Name、fldRName等关联
            /// </summary>
            public string obj { get; set; }

            /// <summary>
            /// admin
            /// </summary>
            public string fldUserID { get; set; }
        }









        [HttpPost]
        public HttpResponseMessage Upload_Query_For_ElectronicFile_V2(Upload_Query_For_ElectronicFile_V2_Info info)
        {
            string result = string.Empty;
            try
            {
                List<Model.ElectronicFile> list = new List<Model.ElectronicFile>();

                List<Model.ElectronicFile> listdata = new List<Model.ElectronicFile>();


                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.ElectronicFile
                            select x).ToList();
                }

                if (!(info.fldUserID == "admin"))
                {
                    list = (from x in list
                            where x.fldUserID == info.fldUserID
                            select x).ToList();
                }

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                list = (from x in list
                        where x.fldTime >= BeginDate &&
                        x.fldTime <= EndDate
                        select x).ToList();


                if (!(info.obj == "" || info.obj == null))
                {
                    if (info.fldReport_Name != null && info.fldReport_Name != "")
                    {
                        list = (from x in list
                                where x.fldReport_Name.Contains(info.fldReport_Name)
                                select x).ToList();
                    }


                    if (info.fldReport_Type != null && info.fldReport_Type != "")
                    {
                        list = (from x in list
                                where x.fldReport_Type.Contains(info.fldReport_Type)
                                select x).ToList();
                    }

                    if (info.fldRName != null && info.fldRName != "")
                    {
                        list = (from x in list
                                where x.fldRName.Contains(info.fldRName)
                                select x).ToList();
                    }


                    if (info.fldUserID != null && info.fldUserID != "")
                    {
                        list = (from x in list
                                where x.fldUserID == info.fldUserID
                                select x).ToList();
                    }

                    if (info.fldFileName != null && info.fldFileName != "")
                    {
                        list = (from x in list
                                where x.fldFileName.Contains(info.fldFileName)
                                select x).ToList();
                    }
                }

                list = list.OrderByDescending(x => x.fldTime).ToList();

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class Upload_Query_For_ElectronicFile_V2_Info
        {
            /// <summary>
            /// 业务类型，确定参数，需要给
            /// </summary>
            public string fldReport_Type { get; set; }

            /// <summary>
            /// 文档目录，确定参数，可以自己赋予意义
            /// </summary>
            public string fldReport_Name { get; set; }

            /// <summary>
            /// 自己定义吧
            /// </summary>
            public string fldRName { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// 给null，就返回用户ID下，时间范围内的数据，不跟fldReport_Type、fldReport_Name、fldRName等关联
            /// </summary>
            public string obj { get; set; }

            /// <summary>
            /// admin
            /// </summary>
            public string fldUserID { get; set; }


            public string fldFileName { get; set; }
        }
































        [HttpGet]
        public HttpResponseMessage Download_File(string fldAutoID)
        {
            string result = string.Empty;
            try
            {
                int ID = int.Parse(fldAutoID);

                Model.tblReportArchive list = new Model.tblReportArchive();

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblReportArchive
                            where x.fldAutoID == ID
                            select x).ToList().FirstOrDefault();
                }


                var FilePath = HostingEnvironment.MapPath(@"~/App_Data/ReportArchive/") + list.fldPath;



                var stream = new FileStream(FilePath, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = list.fldFileName
                };

                return response;


                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }



            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }













        [HttpGet]
        public HttpResponseMessage Download_File__For_ElectronicFile(string fldAutoID)
        {
            string result = string.Empty;
            try
            {
                int ID = int.Parse(fldAutoID);

                Model.ElectronicFile list = new Model.ElectronicFile();

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.ElectronicFile
                            where x.fldAutoID == ID
                            select x).ToList().FirstOrDefault();
                }


                var FilePath = list.fldPath;



                var stream = new FileStream(FilePath, FileMode.Open);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(stream);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = list.fldFileName
                };

                return response;


                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }



            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }























        [HttpPost]
        public HttpResponseMessage QueryPoint_For_ElectronicFile(QueryPoint_For_ElectronicFile_Info info)
        {
            string result = string.Empty;
            try
            {
                //List<Model.ElectronicFile_Point> list = new List<Model.ElectronicFile_Point>();


                DataTable dt = rule.getdt("select fldAutoID as id,fldPointName as label,fldParentID from ElectronicFile_Point");
                //using (Model.EntityContext db = new Model.EntityContext())
                //{
                //list = (from x in db.ElectronicFile_Point
                //        select x).ToList();

                //}

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class QueryPoint_For_ElectronicFile_Info
        {
        }







        [HttpPost]
        public HttpResponseMessage AddPoint_For_ElectronicFile(AddPoint_For_ElectronicFile_Info info)
        {
            string result = string.Empty;
            try
            {
                Model.ElectronicFile_Point list = new Model.ElectronicFile_Point();

                list.fldPointName = info.fldPointName;
                list.fldParentID = info.fldParentID;


                using (Model.EntityContext db = new Model.EntityContext())
                {
                    db.ElectronicFile_Point.Add(list);
                    db.SaveChanges();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class AddPoint_For_ElectronicFile_Info
        {
            /// <summary>
            /// 节点名称
            /// </summary>
            public string fldPointName { get; set; }

            /// <summary>
            /// 父节点ID，如果是根节点，可不传
            /// </summary>
            public int fldParentID { get; set; }
        }










        [HttpPost]
        public HttpResponseMessage DeletePoint_For_ElectronicFile(DeletePoint_For_ElectronicFile_Info info)
        {
            string result = string.Empty;
            try
            {
                Model.ElectronicFile_Point list = new Model.ElectronicFile_Point();
                List<Model.ElectronicFile_Point> list2 = new List<Model.ElectronicFile_Point>();


                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.ElectronicFile_Point
                            where x.fldAutoID == info.fldAutoID
                            select x).FirstOrDefault();

                    list2 = (from x in db.ElectronicFile_Point
                             where x.fldAutoID == list.fldParentID
                             select x).ToList();

                    db.ElectronicFile_Point.RemoveRange(list2);

                    db.ElectronicFile_Point.Remove(list);

                    db.SaveChanges();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class DeletePoint_For_ElectronicFile_Info
        {
            /// <summary>
            /// 节点名称
            /// </summary>
            public int fldAutoID { get; set; }
        }












    }
}
