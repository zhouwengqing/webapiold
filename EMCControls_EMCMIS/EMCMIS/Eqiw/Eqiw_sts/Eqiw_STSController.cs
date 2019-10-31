using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_sts
{
    public class Eqiw_STSController : ApiController
    {


        //public static List<tblEQIW_R_Item> Item { get; set; }


        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述    ：  获取地表水专项
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2018-5-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>返回测点信息</returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_STS_DataAndItem(Get_Eqiw_STS_DataAndItem_Info info)
        {
            string result = string.Empty;
            try
            {
                List<tblEQIW_STS_Data> list = new List<tblEQIW_STS_Data>();

                List<tblEQIW_STS_Data_Item> list_item = new List<tblEQIW_STS_Data_Item>();

                Get_Eqiw_STS_DataAndItem_Return rt = new Get_Eqiw_STS_DataAndItem_Return();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblEQIW_STS_Data
                            select x).ToList();

                    if (info.fldBeginDate != null && info.fldEndDate != null)
                    {
                        list = (from x in db.tblEQIW_STS_Data
                                where x.fldDate >= info.fldBeginDate && x.fldDate <= info.fldEndDate
                                select x).ToList();
                    }


                    if (info.fldSTCode != null && info.fldSTCode != "")
                    {
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldTaskName + "." + x.fldSTName + "." + x.fldRName + "." + x.fldRSName)
                                select x).ToList();
                    }


                    if (list.Count > 0)
                    {
                        if (info.fldItemCode != null && info.fldItemCode != "")
                        {
                            list_item = (from x in db.tblEQIW_STS_Data_Item
                                         where info.fldItemCode.Contains(x.fldItemCode)
                                         select x).ToList();
                        }
                        else
                        {
                            list_item = (from x in db.tblEQIW_STS_Data_Item
                                         select x).ToList();
                        }

                        list_item = (from x in list
                                     join y in list_item
                                     on x.fldAutoID equals y.fldFKID
                                     select y).ToList();
                    }
                }


                rt.Data = list;
                rt.Data_Item = list_item;


                List<Get_Eqiw_STS_DataAndItem_Return_Name> list_name = new List<Get_Eqiw_STS_DataAndItem_Return_Name>();
                list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldTaskName", ShowName = "课题名称" });
                list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldSTName", ShowName = "所属区县名称" });
                list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldRName", ShowName = "所在河流名称" });
                list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldRSName", ShowName = "点位名称" });
                list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldDate", ShowName = "时间" });
                list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldSAMPH", ShowName = "水平向代码" });
                list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldSAMPR", ShowName = "垂直向代码" });
                //list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldItemCode", ShowName = "项目代码" });
                //list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "fldItemName", ShowName = "项目名称" });
                //list_name.Add(new Get_Eqiw_STS_DataAndItem_Return_Name() { ColName = "Value", ShowName = "项目值" });

                rt.NameList = list_name;


                result = rule.JsonStr("ok", "", rt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_Eqiw_STS_DataAndItem_Info
        {
            public DateTime? fldBeginDate { get; set; }

            public DateTime? fldEndDate { get; set; }

            public string fldSTCode { get; set; }

            public string fldItemCode { get; set; }

        }


        public class Get_Eqiw_STS_DataAndItem_Return
        {
            public List<tblEQIW_STS_Data> Data { get; set; }

            public List<tblEQIW_STS_Data_Item> Data_Item { get; set; }

            public List<Get_Eqiw_STS_DataAndItem_Return_Name> NameList { get; set; }
        }


        public class Get_Eqiw_STS_DataAndItem_Return_Name
        {
            public string ColName { get; set; }

            public string ShowName { get; set; }
        }









        /// <summary>
        /// 功能描述    ：  获取地表水专项
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2018-5-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>返回测点信息</returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_STS_DataAndItem_WithObject(Get_Eqiw_STS_DataAndItem_WithObject_Info info)
        {
            string result = string.Empty;
            try
            {
                List<tblEQIW_STS_Data> list = new List<tblEQIW_STS_Data>();

                List<tblEQIW_STS_Data_Item> list_item = new List<tblEQIW_STS_Data_Item>();

                Get_Eqiw_STS_DataAndItem_Return rt = new Get_Eqiw_STS_DataAndItem_Return();

                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tblEQIW_STS_Data
                            select x).ToList();

                    if (info.fldBeginDate != null && info.fldEndDate != null)
                    {
                        list = (from x in db.tblEQIW_STS_Data
                                where x.fldDate >= info.fldBeginDate && x.fldDate <= info.fldEndDate
                                select x).ToList();
                    }

                    var temp = (from x in list
                                where x.fldTaskName.Contains(info.fldObject) ||
                                x.fldSTName.Contains(info.fldObject) ||
                                x.fldRName.Contains(info.fldObject) ||
                                x.fldRSName.Contains(info.fldObject)
                                select x).ToList();

                    if (temp.Count > 0)
                    {
                        list_item = (from x in db.tblEQIW_STS_Data_Item
                                     select x).ToList();

                        list_item = (from x in temp
                                     join y in list_item
                                     on x.fldAutoID equals y.fldFKID
                                     select y).ToList();
                    }
                    else
                    {
                        list_item = (from x in db.tblEQIW_STS_Data_Item
                                     where x.fldItemName.Contains(info.fldObject)
                                     select x).ToList();

                        list_item = (from x in list
                                     join y in list_item
                                     on x.fldAutoID equals y.fldFKID
                                     select y).ToList();
                    }
                }


                rt.Data = list;
                rt.Data_Item = list_item;

                result = rule.JsonStr("ok", "", rt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_Eqiw_STS_DataAndItem_WithObject_Info
        {
            public DateTime? fldBeginDate { get; set; }

            public DateTime? fldEndDate { get; set; }

            public string fldObject { get; set; }
        }


        public class Get_Eqiw_STS_DataAndItem_WithObject_Return
        {
            public List<tblEQIW_STS_Data> Data { get; set; }

            public List<tblEQIW_STS_Data_Item> Data_Item { get; set; }
        }

















































        /// <summary>
        /// 功能描述    ：  获取地表水专项
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2018-5-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>返回测点信息</returns>
        [HttpPost]
        public HttpResponseMessage Update_Eqiw_STS_DataAndItem(Update_Eqiw_STS_DataAndItem_Info info)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                string fldContent = "";
                string ChangeData = "";
                using (EntityContext db = new EntityContext())
                {
                    if (info.Data != null)
                    {
                        var temp = db.tblEQIW_STS_Data.Find(info.Data.fldAutoID);

                        fldContent += "ID为" + temp.fldAutoID + "的断面数据由用户" + info.fldUserID + "变更为：";

                        if (temp.fldTaskName != info.Data.fldTaskName)
                        {
                            ChangeData += "【课题名称：" + temp.fldTaskName + "→" + info.Data.fldTaskName + "】；";
                        }

                        if (temp.fldSTName != info.Data.fldSTName)
                        {
                            ChangeData += "【所属区县名称：" + temp.fldSTName + "→" + info.Data.fldSTName + "】；";
                        }

                        if (temp.fldRName != info.Data.fldRName)
                        {
                            ChangeData += "【所在河流名称：" + temp.fldRName + "→" + info.Data.fldRName + "】；";
                        }

                        if (temp.fldRSName != info.Data.fldRSName)
                        {
                            ChangeData += "【点位名称：" + temp.fldRSName + "→" + info.Data.fldRSName + "】；";
                        }

                        if (temp.fldDate != info.Data.fldDate)
                        {
                            ChangeData += "【时间：" + temp.fldDate + "→" + info.Data.fldDate + "】；";
                        }

                        if (temp.fldSAMPH != info.Data.fldSAMPH)
                        {
                            ChangeData += "【水平向代码：" + temp.fldSAMPH + "→" + info.Data.fldSAMPH + "】；";
                        }

                        if (temp.fldSAMPR != info.Data.fldSAMPR)
                        {
                            ChangeData += "【垂直向代码：" + temp.fldSAMPR + "→" + info.Data.fldSAMPR + "】；";
                        }

                        db.tblEQIW_STS_Data.AddOrUpdate(info.Data);
                    }


                    if (info.Data_Item_List != null)
                    {
                        foreach (var item in info.Data_Item_List)
                        {



                            var query = (from x in db.tblEQIW_STS_Data_Item
                                         where x.fldFKID == item.fldFKID &&
                                         x.fldItemCode == item.fldItemCode
                                         select x).FirstOrDefault();


                            //var query = (from x in temp
                            //             where x.fldFKID == item.fldFKID &&
                            //             x.fldItemCode == item.fldItemCode
                            //             select x).FirstOrDefault();

                            if (query != null)
                            {
                                if (query.Value != item.Value)
                                {
                                    ChangeData += "【" + query.fldItemName + "：" + query.Value + "→" + item.Value + "】；";
                                }
                            }
                        }
                        db.tblEQIW_STS_Data_Item.AddOrUpdate(info.Data_Item_List.ToArray());
                    }


                    if (ChangeData != "")
                    {
                        tblEQIW_STS_Data_Log log = new tblEQIW_STS_Data_Log();
                        log.fldFKID = info.Data.fldAutoID;
                        log.fldUserID = info.fldUserID;
                        log.fldOperateDate = DateTime.Now;
                        log.fldContent = ChangeData;
                        db.tblEQIW_STS_Data_Log.AddOrUpdate(log);
                    }





                    count = db.SaveChanges();

                }

                result = rule.JsonStr("ok", "", count);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Update_Eqiw_STS_DataAndItem_Info
        {
            public int fldUserID { get; set; }

            public tblEQIW_STS_Data Data { get; set; }

            public List<tblEQIW_STS_Data_Item> Data_Item_List { get; set; }
        }


        public class Update_Eqiw_STS_DataAndItem_Return
        {
        }








        /// <summary>
        /// 功能描述    ：  获取地表水专项
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2018-5-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>返回测点信息</returns>
        [HttpPost]
        public HttpResponseMessage Delete_Eqiw_STS_DataAndItem(Delete_Eqiw_STS_DataAndItem_Info info)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                using (EntityContext db = new EntityContext())
                {

                    if (info.fldAutoID_List != null)
                    {
                        var query = (from x in db.tblEQIW_STS_Data
                                     where info.fldAutoID_List.Contains(x.fldAutoID)
                                     select x).ToList();

                        db.tblEQIW_STS_Data.RemoveRange(query);


                        var query2 = (from x in db.tblEQIW_STS_Data_Item
                                      where info.fldAutoID_List.Contains(x.fldFKID)
                                      select x).ToList();

                        db.tblEQIW_STS_Data_Item.RemoveRange(query2);


                        count = db.SaveChanges();

                    }


                    if (info.DataID_List != null)
                    {
                        var query = (from x in db.tblEQIW_STS_Data
                                     where info.DataID_List.Contains(x.fldAutoID)
                                     select x).ToList();

                        db.tblEQIW_STS_Data.RemoveRange(query);

                        count = db.SaveChanges();

                    }






                    if (info.DataItemID_List != null)
                    {
                        var query = (from x in db.tblEQIW_STS_Data_Item
                                     where info.DataItemID_List.Contains(x.fldAutoID)
                                     select x).ToList();

                        db.tblEQIW_STS_Data_Item.RemoveRange(query);

                        count = db.SaveChanges();

                    }





                }

                result = rule.JsonStr("ok", "", count);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Delete_Eqiw_STS_DataAndItem_Info
        {
            public List<int> fldAutoID_List { get; set; }

            public List<int> DataID_List { get; set; }

            public List<int> DataItemID_List { get; set; }
        }


        public class Delete_Eqiw_STS_DataAndItem_Return
        {
        }




        /// <summary>
        /// 功能描述    ：  获取地表水专项评结果价
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-6-04
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="info">获取评价结果参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetDataStage(Getdatainfo info)
        {
            string result = string.Empty;
            try
            {
                RuletblEQIW_STS_Basedata rt = new RuletblEQIW_STS_Basedata();
                DataTable dt = rt.Geteqiw_sts_dataStage(info.bdate, info.edate, info.rscode, info.itemcode, info.fldstandardname, info.fldLevel);
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 获取评价结果参数
        /// </summary>
        public class Getdatainfo
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            public DateTime bdate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public DateTime edate { get; set; }

            /// <summary>
            /// 断面
            /// </summary>
            public string rscode { get; set; }

            /// <summary>
            /// 因子
            /// </summary>
            public string itemcode { get; set; }

            /// <summary>
            /// 评价标准
            /// </summary>
            public string fldstandardname { get; set; }


            /// <summary>
            /// 评价等级
            /// </summary>
            public short fldLevel { get; set; }
        }
































    }
}
