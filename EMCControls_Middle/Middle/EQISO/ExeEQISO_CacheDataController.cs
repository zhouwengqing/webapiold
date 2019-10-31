using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace EMCControls_Middle.Middle.EQISO
{
    public class ExeEQISO_CacheDataController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：缓存中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-28
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ExeCacheData(Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                //第一步
                #region 初始化变量

                tblEQISO_Info_Midd info_Midd = new tblEQISO_Info_Midd();

                DateTime BeginDate = DateTime.Parse(info.BeginDate);

                DateTime EndDate = DateTime.Parse(info.EndDate);

                #endregion




                //第二步
                #region 处理参数表，检查此条件下是否已经进行过缓存

                using (MiddleContext db = new MiddleContext())
                {
                    var query = (from x in db.tblEQISO_Info_Midd
                                 where x.TimeType == info.TimeType &&
                                 x.BeginDate == BeginDate &&
                                 x.EndDate == EndDate &&
                                 x.fldRSCode == info.fldRSCode &&
                                 x.fldStandardName == info.fldStandardName &&
                                 x.fldLevel == info.fldLevel &&
                                 x.fldItemCode == info.fldItemCode &&
                                 x.DecCarry == info.DecCarry &&
                                 x.AppriseID == info.AppriseID &&
                                 x.SpaceID == info.SpaceID &&
                                 x.STatType == info.STatType
                                 select x).Count();

                    if (query > 0)
                    {
                        result = rule.JsonStr("ok", "此条件下已经进行过数据缓存。", "");
                        return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                    }
                }

                #endregion




                //第三步
                #region 执行通用存储过程，返回数据

                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@STatType",info.STatType)
                };

                dt = rule.RunProcedure("usp_tblEQISO_Report_Apprise", paras.ToList(), null);

                if (dt == null || dt.Rows.Count == 0)
                {
                    result = rule.JsonStr("ok", "此条件集合下并未返回数据", "");
                    return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
                }

                #endregion




                //第四步
                #region 如果存储过程返回数据，那么将条件写入参数表

                using (MiddleContext db = new MiddleContext())
                {
                    info_Midd.TimeType = info.TimeType;
                    info_Midd.BeginDate = BeginDate;
                    info_Midd.EndDate = EndDate;
                    info_Midd.fldRSCode = info.fldRSCode;
                    info_Midd.fldStandardName = info.fldStandardName;
                    info_Midd.fldLevel = info.fldLevel;
                    info_Midd.fldItemCode = info.fldItemCode;
                    info_Midd.DecCarry = info.DecCarry;
                    info_Midd.AppriseID = info.AppriseID;
                    info_Midd.SpaceID = info.SpaceID;
                    info_Midd.STatType = info.STatType;


                    db.tblEQISO_Info_Midd.Add(info_Midd);
                    db.SaveChanges();
                }

                #endregion





                //第五步
                #region 相关数据处理



                //原始数据表
                if (info.SpaceID == 0)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQISO_SpaceID0_Midd> list = new List<tblEQISO_SpaceID0_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQISO_SpaceID0_Midd data = new tblEQISO_SpaceID0_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldEntCode = item["fldEntCode"].ToString();
                            data.fldEntName = item["fldEntName"].ToString();
                            data.fldAddress = item["fldAddress"].ToString();
                            data.fldPCode = item["fldPCode"].ToString();
                            data.fldPName = item["fldPName"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();
                            data.fldDate = Convert.ToDateTime(item["fldYear"].ToString() + "-" + item["fldMonth"].ToString() + "-" + item["fldDay"].ToString());

                            db.tblEQISO_SpaceID0_Midd.Add(data);
                            db.SaveChanges();


                            List<tblEQISO_SpaceID0_Item_Midd> data_item_list = new List<tblEQISO_SpaceID0_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains("fld" + item2))
                                {
                                    tblEQISO_SpaceID0_Item_Midd data_item = new tblEQISO_SpaceID0_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fldItemValue = item["fld" + item2].ToString();
                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQISO_SpaceID0_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }
                }



                //基本统计表
                if (info.SpaceID == 1)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQISO_SpaceID1_Midd> list = new List<tblEQISO_SpaceID1_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQISO_SpaceID1_Midd data = new tblEQISO_SpaceID1_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.AppriseID = info.AppriseID.ToString();
                            data.STatType = info.STatType.ToString();

                            data.fldYear = item["fldYear"].ToString();
                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldEntCode = item["fldEntCode"].ToString();
                            data.fldEntName = item["fldEntName"].ToString();
                            data.fldAddress = item["fldAddress"].ToString();
                            data.fldDate = item["fldDate"].ToString();

                            db.tblEQISO_SpaceID1_Midd.Add(data);
                            db.SaveChanges();


                            List<tblEQISO_SpaceID1_Item_Midd> data_item_list = new List<tblEQISO_SpaceID1_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains("fld" + item2))
                                {
                                    tblEQISO_SpaceID1_Item_Midd data_item = new tblEQISO_SpaceID1_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fldItemValue = item["fld" + item2].ToString();
                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQISO_SpaceID1_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }
                }




                //指数统计表
                if (info.SpaceID == 2)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQISO_SpaceID2_Midd> list = new List<tblEQISO_SpaceID2_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQISO_SpaceID2_Midd data = new tblEQISO_SpaceID2_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.AppriseID = info.AppriseID.ToString();
                            data.STatType = info.STatType.ToString();

                            data.fldYear = item["fldYear"].ToString();
                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldEntCode = item["fldEntCode"].ToString();
                            data.fldEntName = item["fldEntName"].ToString();
                            data.fldAddress = item["fldAddress"].ToString();
                            data.fldPCode = item["fldPCode"].ToString();
                            data.fldPName = item["fldPName"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();
                            data.fldSOType = item["fldSOType"].ToString();
                            data.fldWPI_W = item["fldWPI_W"].ToString();
                            data.fldWPI_Y = item["fldWPI_Y"].ToString();
                            data.fldWPI_Avg = item["fldWPI_Avg"].ToString();
                            data.fldWPI_Max = item["fldWPI_Max"].ToString();
                            data.fldWPI = item["fldWPI"].ToString();
                            data.fldLevelApp = item["fldLevelApp"].ToString();
                            data.fldPCount = item["fldPCount"].ToString();
                            data.fldStdCount = item["fldStdCount"].ToString();
                            data.fldStdScale = item["fldStdScale"].ToString();
                            data.fldItemOvers = item["fldItemOvers"].ToString();
                            data.fldMaxPiApp = item["fldMaxPiApp"].ToString();
                            data.fldPnItem = item["fldPnItem"].ToString();
                            data.fldPiItem = item["fldPiItem"].ToString();

                            db.tblEQISO_SpaceID2_Midd.Add(data);
                            db.SaveChanges();


                            List<tblEQISO_SpaceID2_Item_Midd> data_item_list = new List<tblEQISO_SpaceID2_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains("fld" + item2))
                                {
                                    tblEQISO_SpaceID2_Item_Midd data_item = new tblEQISO_SpaceID2_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fldItemValue = item["fld" + item2].ToString();

                                    if (item.Table.Columns.Contains("fld" + item2 + "_Count"))
                                    {
                                        data_item.Count = item["fld" + item2 + "_Count"].ToString();
                                    }

                                    if (item.Table.Columns.Contains("fld" + item2 + "_Val"))
                                    {
                                        data_item.Val = item["fld" + item2 + "_Val"].ToString();
                                    }

                                    if (item.Table.Columns.Contains("fld" + item2 + "_OutCount"))
                                    {
                                        data_item.OutCount = item["fld" + item2 + "_OutCount"].ToString();
                                    }

                                    if (item.Table.Columns.Contains("fld" + item2 + "_OutScale"))
                                    {
                                        data_item.OutScale = item["fld" + item2 + "_OutScale"].ToString();
                                    }

                                    if (item.Table.Columns.Contains("fld" + item2 + "_CheckCount"))
                                    {
                                        data_item.CheckCount = item["fld" + item2 + "_CheckCount"].ToString();
                                    }

                                    if (item.Table.Columns.Contains("fld" + item2 + "_fldCheckScale"))
                                    {
                                        data_item.fldCheckScale = item["fld" + item2 + "_fldCheckScale"].ToString();
                                    }

                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQISO_SpaceID2_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }
                }




                //项目各级别统计
                if (info.SpaceID == 3)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQISO_SpaceID3_Midd> list = new List<tblEQISO_SpaceID3_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQISO_SpaceID3_Midd data = new tblEQISO_SpaceID3_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldItemName = item["fldItemName"].ToString();
                            data.fldSOType = item["fldSOType"].ToString();
                            data.fld1Count = item["fld1Count"].ToString();
                            data.fld1Scale = item["fld1Scale"].ToString();
                            data.fld2Count = item["fld2Count"].ToString();
                            data.fld2Scale = item["fld2Scale"].ToString();
                            data.fld3Count = item["fld3Count"].ToString();
                            data.fld3Scale = item["fld3Scale"].ToString();
                            data.fld4Count = item["fld4Count"].ToString();
                            data.fld4Scale = item["fld4Scale"].ToString();
                            data.fld5Count = item["fld5Count"].ToString();
                            data.fld5Scale = item["fld5Scale"].ToString();
                            data.fldCount = item["fldCount"].ToString();
                            data.fldOutScale = item["fldOutScale"].ToString();
                            data.fldCFI = item["fldCFI"].ToString();
                            data.fldMin = item["fldMin"].ToString();
                            data.fldMax = item["fldMax"].ToString();
                            data.fldAvg = item["fldAvg"].ToString();
                            data.fldMaxOut = item["fldMaxOut"].ToString();

                            list.Add(data);
                        }

                        db.tblEQISO_SpaceID3_Midd.AddRange(list);
                        db.SaveChanges();
                    }
                }




                //污染指数统计
                if (info.SpaceID == 4)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQISO_SpaceID4_Midd> list = new List<tblEQISO_SpaceID4_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQISO_SpaceID4_Midd data = new tblEQISO_SpaceID4_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.AppriseID = info.AppriseID.ToString();
                            data.STatType = info.STatType.ToString();

                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldEntCode = item["fldEntCode"].ToString();
                            data.fldEntName = item["fldEntName"].ToString();
                            data.fldAddress = item["fldAddress"].ToString();
                            data.fldType = item["fldType"].ToString();
                            data.fldSOType = item["fldSOType"].ToString();
                            data.fldCount = item["fldCount"].ToString();
                            data.fld1Count = item["fld1Count"].ToString();
                            data.fld1Scale = item["fld1Scale"].ToString();
                            data.fld2Count = item["fld2Count"].ToString();
                            data.fld2Scale = item["fld2Scale"].ToString();
                            data.fld3Count = item["fld3Count"].ToString();
                            data.fld3Scale = item["fld3Scale"].ToString();
                            data.fld4Count = item["fld4Count"].ToString();
                            data.fld4Scale = item["fld4Scale"].ToString();
                            data.fld5Count = item["fld5Count"].ToString();
                            data.fld5Scale = item["fld5Scale"].ToString();

                            list.Add(data);
                        }

                        db.tblEQISO_SpaceID4_Midd.AddRange(list);
                        db.SaveChanges();
                    }
                }





                //污染级别统计表
                if (info.SpaceID == 5)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQISO_SpaceID5_Midd> list = new List<tblEQISO_SpaceID5_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQISO_SpaceID5_Midd data = new tblEQISO_SpaceID5_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.AppriseID = info.AppriseID.ToString();
                            data.STatType = info.STatType.ToString();

                            data.fldYear = item["fldYear"].ToString();
                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldEntCode = item["fldEntCode"].ToString();
                            data.fldEntName = item["fldEntName"].ToString();
                            data.fldAddress = item["fldAddress"].ToString();
                            data.fldPCode = item["fldPCode"].ToString();
                            data.fldPName = item["fldPName"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();
                            data.fldSOType = item["fldSOType"].ToString();
                            data.fldWPI_W = item["fldWPI_W"].ToString();
                            data.fldWPI_Y = item["fldWPI_Y"].ToString();
                            data.fldWPI_Avg = item["fldWPI_Avg"].ToString();
                            data.fldWPI_Max = item["fldWPI_Max"].ToString();
                            data.fldWPI = item["fldWPI"].ToString();

                            db.tblEQISO_SpaceID5_Midd.Add(data);
                            db.SaveChanges();


                            List<tblEQISO_SpaceID5_Item_Midd> data_item_list = new List<tblEQISO_SpaceID5_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains("fld" + item2))
                                {
                                    tblEQISO_SpaceID5_Item_Midd data_item = new tblEQISO_SpaceID5_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fldItemValue = item["fld" + item2].ToString();
                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQISO_SpaceID5_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }
                }







                //土壤质量状况评价
                if (info.SpaceID == 6)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQISO_SpaceID6_Midd> list = new List<tblEQISO_SpaceID6_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQISO_SpaceID6_Midd data = new tblEQISO_SpaceID6_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldStatType = item["fldStatType"].ToString();
                            data.fldSOType = item["fldSOType"].ToString();
                            data.fld1Count = item["fld1Count"].ToString();
                            data.fld1Scale = item["fld1Scale"].ToString();
                            data.fld2Count = item["fld2Count"].ToString();
                            data.fld2Scale = item["fld2Scale"].ToString();
                            data.fld3Count = item["fld3Count"].ToString();
                            data.fld3Scale = item["fld3Scale"].ToString();
                            data.fld4Count = item["fld4Count"].ToString();
                            data.fld4Scale = item["fld4Scale"].ToString();
                            data.fld5Count = item["fld5Count"].ToString();
                            data.fld5Scale = item["fld5Scale"].ToString();
                            data.fldCount = item["fldCount"].ToString();

                            list.Add(data);
                        }

                        db.tblEQISO_SpaceID6_Midd.AddRange(list);
                        db.SaveChanges();
                    }
                }






                #endregion





                result = rule.JsonStr("ok", "执行成功！", info_Midd.fldAutoID);
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
        public class Info
        {
            /// <summary>
            /// 时间类型
            /// </summary>
            public string TimeType { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }


            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldStandardName { get; set; }


            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldLevel { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 0:针对单个断面评价、1：针对空间评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 0:有采样地信息，例如：武汉
            /// </summary>
            public int STatType { get; set; }


        }


























        /// <summary>
        /// 功能描述：删除中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-29
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DelCacheData(List<Del_Info> info)
        {
            string result = null;
            int num = 0;
            try
            {
                using (MiddleContext db = new MiddleContext())
                {
                    foreach (var item in info)
                    {


                        if (item.SpaceID == 0)
                        {
                            var query = (from x in db.tblEQISO_SpaceID0_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();



                            //删除因子表数据
                            foreach (var item2 in query)
                            {
                                var query2 = (from x in db.tblEQISO_SpaceID0_Item_Midd
                                              where x.fldFKID == item2.fldAutoID
                                              select x).ToList();

                                db.tblEQISO_SpaceID0_Item_Midd.RemoveRange(query2);
                            }



                            //删除数据表数据
                            db.tblEQISO_SpaceID0_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblEQISO_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQISO_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }



                        if (item.SpaceID == 1)
                        {
                            var query = (from x in db.tblEQISO_SpaceID1_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();



                            //删除因子表数据
                            foreach (var item2 in query)
                            {
                                var query2 = (from x in db.tblEQISO_SpaceID1_Item_Midd
                                              where x.fldFKID == item2.fldAutoID
                                              select x).ToList();

                                db.tblEQISO_SpaceID1_Item_Midd.RemoveRange(query2);
                            }



                            //删除数据表数据
                            db.tblEQISO_SpaceID1_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblEQISO_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQISO_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }




                        if (item.SpaceID == 2)
                        {
                            var query = (from x in db.tblEQISO_SpaceID2_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();



                            //删除因子表数据
                            foreach (var item2 in query)
                            {
                                var query2 = (from x in db.tblEQISO_SpaceID2_Item_Midd
                                              where x.fldFKID == item2.fldAutoID
                                              select x).ToList();

                                db.tblEQISO_SpaceID2_Item_Midd.RemoveRange(query2);
                            }



                            //删除数据表数据
                            db.tblEQISO_SpaceID2_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblEQISO_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQISO_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }




                        if (item.SpaceID == 3)
                        {
                            var query = (from x in db.tblEQISO_SpaceID3_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();


                            //删除数据表数据
                            db.tblEQISO_SpaceID3_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblEQISO_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQISO_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }




                        if (item.SpaceID == 4)
                        {
                            var query = (from x in db.tblEQISO_SpaceID4_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();


                            //删除数据表数据
                            db.tblEQISO_SpaceID4_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblEQISO_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQISO_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }




                        if (item.SpaceID == 5)
                        {
                            var query = (from x in db.tblEQISO_SpaceID5_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();



                            //删除因子表数据
                            foreach (var item2 in query)
                            {
                                var query2 = (from x in db.tblEQISO_SpaceID5_Item_Midd
                                              where x.fldFKID == item2.fldAutoID
                                              select x).ToList();

                                db.tblEQISO_SpaceID5_Item_Midd.RemoveRange(query2);
                            }



                            //删除数据表数据
                            db.tblEQISO_SpaceID5_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblEQISO_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQISO_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }




                        if (item.SpaceID == 6)
                        {
                            var query = (from x in db.tblEQISO_SpaceID6_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();


                            //删除数据表数据
                            db.tblEQISO_SpaceID6_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblEQISO_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQISO_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }





                    }
                }










                result = rule.JsonStr("ok", "执行成功！", num);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }





        /// <summary>
        /// 删除参数表实体
        /// </summary>
        public class Del_Info
        {

            /// <summary>
            /// 用于区分表的字段
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 参数表ID
            /// </summary>
            public int fldAutoID { get; set; }

        }











    }





    public static class EntityConverter
    {

        /// <summary>
        /// DataTable生成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dataTable) where T : class, new()
        {
            if (dataTable == null || dataTable.Rows.Count <= 0) throw new ArgumentNullException("dataTable", "当前对象为null无法生成表达式树");
            Func<DataRow, T> func = ToExpression<T>(dataTable.Rows[0]);
            List<T> collection = new List<T>(dataTable.Rows.Count);
            foreach (DataRow dr in dataTable.Rows)
            {
                collection.Add(func(dr));
            }
            return collection;
        }


        /// <summary>
        /// 生成表达式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public static Func<DataRow, T> ToExpression<T>(this DataRow dataRow) where T : class, new()
        {
            if (dataRow == null) throw new ArgumentNullException("dataRow", "当前对象为null 无法转换成实体");
            ParameterExpression paramter = Expression.Parameter(typeof(DataRow), "dr");
            List<MemberBinding> binds = new List<MemberBinding>();
            for (int i = 0; i < dataRow.ItemArray.Length; i++)
            {
                String colName = dataRow.Table.Columns[i].ColumnName;
                PropertyInfo pInfo = typeof(T).GetProperty(colName);
                if (pInfo == null) continue;
                MethodInfo mInfo = typeof(DataRowExtensions).GetMethod("Field", new Type[] { typeof(DataRow), typeof(String) }).MakeGenericMethod(pInfo.PropertyType);
                MethodCallExpression call = Expression.Call(mInfo, paramter, Expression.Constant(colName, typeof(String)));
                MemberAssignment bind = Expression.Bind(pInfo, call);
                binds.Add(bind);
            }
            MemberInitExpression init = Expression.MemberInit(Expression.New(typeof(T)), binds.ToArray());
            return Expression.Lambda<Func<DataRow, T>>(init, paramter).Compile();
        }


    }













}
