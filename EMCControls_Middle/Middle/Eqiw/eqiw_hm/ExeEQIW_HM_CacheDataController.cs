using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.eqiw_hm
{
    public class ExeEQIW_HM_CacheDataController : ApiController
    {

        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：缓存中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-3
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ExeCacheData_EQIW_RLD(Info_EQIW_RLD info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                //第一步
                #region 初始化变量

                tblHM_EQIW_RLD_Info_Midd info_Midd = new tblHM_EQIW_RLD_Info_Midd();

                DateTime BeginDate = DateTime.Parse(info.BeginDate);

                DateTime EndDate = DateTime.Parse(info.EndDate);



                DateTime? EBeginDate = null;

                DateTime? EEndDate = null;


                DateTime EBeginDate2 = new DateTime();

                DateTime EEndDate2 = new DateTime();

                if (!(info.EBeginDate == "" || info.EEndDate == ""))
                {
                    DateTime.TryParse(info.EBeginDate, out EBeginDate2);

                    DateTime.TryParse(info.EEndDate, out EEndDate2);

                    EBeginDate = EBeginDate2;

                    EEndDate = EEndDate2;
                }




                #endregion




                //第二步
                #region 处理参数表，检查此条件下是否已经进行过缓存

                using (MiddleContext db = new MiddleContext())
                {
                    var query = (from x in db.tblHM_EQIW_RLD_Info_Midd
                                 where x.TimeType == info.TimeType &&
                                 x.BeginDate == BeginDate &&
                                 x.EndDate == EndDate &&
                                 x.EBeginDate == EBeginDate &&
                                 x.EEndDate == EEndDate &&
                                 x.fldRSC == info.fldRSC &&
                                 x.fldRSCode == info.fldRSCode &&
                                 x.fldStandardName == info.fldStandardName &&
                                 x.fldLevel == info.fldLevel &&
                                 x.fldStandardNameG == info.fldStandardNameG &&
                                 x.fldLevelG == info.fldLevelG &&
                                 x.fldItemCode == info.fldItemCode &&
                                 x.DecCarry == info.DecCarry &&
                                 x.IsPre == info.IsPre &&
                                 x.IsYear == info.IsYear &&
                                 x.IsTotal == info.IsTotal &&
                                 x.IsDetail == info.IsDetail &&
                                 x.AppriseID == info.AppriseID &&
                                 x.SpaceID == info.SpaceID &&
                                 x.STatType == info.STatType &&
                                 x.Para1ID == info.Para1ID &&
                                 x.Para2ID == info.Para2ID &&
                                 x.Source == info.Source
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
                    new SqlParameter("@EBeginDate",info.EBeginDate),
                    new SqlParameter("@EEndDate",info.EEndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldStandardNameG",info.fldStandardNameG),
                    new SqlParameter("@fldLevelG",info.fldLevelG),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@IsTotal",info.IsTotal),
                    new SqlParameter("@IsDetail",info.IsDetail),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@Para1ID",info.Para1ID),
                    new SqlParameter("@Para2ID",info.Para2ID),
                    new SqlParameter("@Source",info.Source)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIW_RLD_Report_HMApprirse", paras.ToList(), null, "HMEntityContext");

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
                    info_Midd.EBeginDate = EBeginDate;
                    info_Midd.EEndDate = EEndDate;
                    info_Midd.fldRSC = info.fldRSC;
                    info_Midd.fldRSCode = info.fldRSCode;
                    info_Midd.fldStandardName = info.fldStandardName;
                    info_Midd.fldLevel = info.fldLevel;
                    info_Midd.fldStandardNameG = info.fldStandardNameG;
                    info_Midd.fldLevelG = info.fldLevelG;
                    info_Midd.fldItemCode = info.fldItemCode;
                    info_Midd.DecCarry = info.DecCarry;
                    info_Midd.IsPre = info.IsPre;
                    info_Midd.IsYear = info.IsYear;
                    info_Midd.IsTotal = info.IsTotal;
                    info_Midd.IsDetail = info.IsDetail;
                    info_Midd.AppriseID = info.AppriseID;
                    info_Midd.SpaceID = info.SpaceID;
                    info_Midd.STatType = info.STatType;
                    info_Midd.Para1ID = info.Para1ID;
                    info_Midd.Para2ID = info.Para2ID;
                    info_Midd.Source = info.Source;

                    db.tblHM_EQIW_RLD_Info_Midd.Add(info_Midd);
                    db.SaveChanges();
                }

                #endregion





                //第五步
                #region 相关数据处理




                //年鉴格式
                if (info.STatType == 1)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblHM_EQIW_RLD_STatType1_Midd> list = new List<tblHM_EQIW_RLD_STatType1_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblHM_EQIW_RLD_STatType1_Midd data = new tblHM_EQIW_RLD_STatType1_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldWaterArea = item["fldWaterArea"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();
                            data.fldAtt = item["fldAtt"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldRCode = item["fldRCode"].ToString();
                            data.fldRName = item["fldRName"].ToString();
                            data.fldRSCode = item["fldRSCode"].ToString();
                            data.fldRSName = item["fldRSName"].ToString();
                            data.fldDate = item["fldDate"].ToString();
                            data.fldFun = item["fldFun"].ToString();
                            data.fldStage = item["fldStage"].ToString();

                            db.tblHM_EQIW_RLD_STatType1_Midd.Add(data);
                            db.SaveChanges();


                            List<tblHM_EQIW_RLD_STatType1_Item_Midd> data_item_list = new List<tblHM_EQIW_RLD_STatType1_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains("fld" + item2))
                                {
                                    tblHM_EQIW_RLD_STatType1_Item_Midd data_item = new tblHM_EQIW_RLD_STatType1_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fldItemValue = item["fld" + item2].ToString();
                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblHM_EQIW_RLD_STatType1_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }

                }






                //断面或者河流综合评价
                if (info.STatType == 3)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblHM_EQIW_RLD_STatType3_Midd> list = new List<tblHM_EQIW_RLD_STatType3_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblHM_EQIW_RLD_STatType3_Midd data = new tblHM_EQIW_RLD_STatType3_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            //data.AppriseID = info.AppriseID.ToString();
                            //data.STatType = info.STatType.ToString();

                            data.fldWaterArea = item["fldWaterArea"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldRCode = item["fldRCode"].ToString();
                            data.fldRName = item["fldRName"].ToString();
                            data.fldRSCode = item["fldRSCode"].ToString();
                            data.fldRSName = item["fldRSName"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();
                            data.fldAtt = item["fldAtt"].ToString();
                            data.fldRSC = item["fldRSC"].ToString();
                            data.fldAppDate = item["fldAppDate"].ToString();
                            data.fldType = item["fldType"].ToString();
                            data.fldFun = item["fldFun"].ToString();
                            data.fldStage = item["fldStage"].ToString();
                            data.fldSectionApp = item["fldSectionApp"].ToString();
                            data.fldStand = item["fldStand"].ToString();

                            db.tblHM_EQIW_RLD_STatType3_Midd.Add(data);
                            db.SaveChanges();


                            List<tblHM_EQIW_RLD_STatType3_Item_Midd> data_item_list = new List<tblHM_EQIW_RLD_STatType3_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains(item2 + "_Value"))
                                {
                                    tblHM_EQIW_RLD_STatType3_Item_Midd data_item = new tblHM_EQIW_RLD_STatType3_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fld_Value = item[item2 + "_Value"].ToString();


                                    if (item.Table.Columns.Contains(item2 + "_Stage"))
                                    {
                                        data_item.fld_Stage = item[item2 + "_Stage"].ToString();
                                    }


                                    if (item.Table.Columns.Contains(item2 + "_STG"))
                                    {
                                        data_item.fld_STG = item[item2 + "_STG"].ToString();
                                    }


                                    if (item.Table.Columns.Contains(item2 + "_Over"))
                                    {
                                        data_item.fld_Over = item[item2 + "_Over"].ToString();
                                    }


                                    if (item.Table.Columns.Contains(item2 + "_OutScale"))
                                    {
                                        data_item.fld_OutScale = item[item2 + "_OutScale"].ToString();
                                    }


                                    if (item.Table.Columns.Contains(item2 + "_Min"))
                                    {
                                        data_item.fld_Min = item[item2 + "_Min"].ToString();
                                    }


                                    if (item.Table.Columns.Contains(item2 + "_Max"))
                                    {
                                        data_item.fld_Max = item[item2 + "_Max"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_MaxOut"))
                                    {
                                        data_item.fld_MaxOut = item[item2 + "_MaxOut"].ToString();
                                    }


                                    if (item.Table.Columns.Contains(item2 + "_MaxDate"))
                                    {
                                        data_item.fld_MaxDate = item[item2 + "_MaxDate"].ToString();
                                    }


                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblHM_EQIW_RLD_STatType3_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
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
        public class Info_EQIW_RLD
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
            /// 第二个时段开始时间
            /// </summary>
            public string EBeginDate { get; set; }


            /// <summary>
            /// 第二个时段结束时间
            /// </summary>
            public string EEndDate { get; set; }


            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }


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
            /// 地下水标准级别名称
            /// </summary>
            public string fldStandardNameG { get; set; }



            /// <summary>
            /// 地下水级别
            /// </summary>
            public int fldLevelG { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法:0:四舍六入五单一、1:四舍五入、2:直接截断、5：对武汉项目特殊处理，氨氮和总磷按照有效位数修约
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 是否统计前期数据
            /// </summary>
            public int IsPre { get; set; }


            /// <summary>
            /// 是否统计同期数据
            /// </summary>
            public int IsYear { get; set; }



            /// <summary>
            /// 是否统计平均值
            /// </summary>
            public int IsTotal { get; set; }


            /// <summary>
            /// 是否统计明细
            /// </summary>
            public int IsDetail { get; set; }


            /// <summary>
            /// 0:针对单个断面评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode、
            /// 5:流域+河流、6：城市+河流、7：流域+水系、8：干支流-fldRiverStream、9：河流+fldAttribute、99：全省
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 1:年鉴格式、3:断面或者河流综合评价、91：浓度秩相关
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 河流均值处理，0:默认值按行政区、1：按行政区前4位处理
            /// </summary>
            public int Para1ID { get; set; }


            /// <summary>
            /// 业务类别，0：河流\1：湖库\2：饮用水
            /// </summary>
            public int Para2ID { get; set; }



            /// <summary>
            /// 
            /// </summary>
            public int Source { get; set; }

        }

















        /// <summary>
        /// 功能描述：缓存中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-3
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ExeCacheData_EQIA_R(Info_EQIA_R info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                //第一步
                #region 初始化变量

                tblHM_EQIA_R_Info_Midd info_Midd = new tblHM_EQIA_R_Info_Midd();

                DateTime BeginDate = DateTime.Parse(info.BeginDate);

                DateTime EndDate = DateTime.Parse(info.EndDate);


                #endregion




                //第二步
                #region 处理参数表，检查此条件下是否已经进行过缓存

                using (MiddleContext db = new MiddleContext())
                {
                    var query = (from x in db.tblHM_EQIA_R_Info_Midd
                                 where x.TimeType == info.TimeType &&
                                 x.BeginDate == BeginDate &&
                                 x.EndDate == EndDate &&
                                 x.fldPCode == info.fldPCode &&
                                 x.fldItemCode == info.fldItemCode &&
                                 x.DecCarry == info.DecCarry &&
                                 x.fldSource == info.fldSource
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
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldSource",info.fldSource)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIA_R_Report_AppriseStat_HM", paras.ToList(), null, "HMEntityContext");

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
                    info_Midd.fldPCode = info.fldPCode;
                    info_Midd.fldItemCode = info.fldItemCode;
                    info_Midd.DecCarry = info.DecCarry;
                    info_Midd.fldSource = info.fldSource;

                    db.tblHM_EQIA_R_Info_Midd.Add(info_Midd);
                    db.SaveChanges();
                }

                #endregion





                //第五步
                #region 相关数据处理




                if (true)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblHM_EQIA_R_Midd> list = new List<tblHM_EQIA_R_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblHM_EQIA_R_Midd data = new tblHM_EQIA_R_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldLCode = item["fldLCode"].ToString();
                            data.fldLName = item["fldLName"].ToString();
                            data.fldPCode = item["fldPCode"].ToString();
                            data.fldPName = item["fldPName"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();
                            data.fldTrade = item["fldTrade"].ToString();
                            data.fldDate = item["fldDate"].ToString();
                            data.fldType = item["fldType"].ToString();
                            data.fldCount = item["fldCount"].ToString();
                            data.fldStdCount = item["fldStdCount"].ToString();
                            data.fldOverItems = item["fldOverItems"].ToString();
                            data.fldOvers = item["fldOvers"].ToString();
                            data.fldOverDate = item["fldOverDate"].ToString();

                            list.Add(data);
                        }

                        db.tblHM_EQIA_R_Midd.AddRange(list);
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
        public class Info_EQIA_R
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
            public string fldPCode { get; set; }

            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 数据源
            /// </summary>
            public int fldSource { get; set; }

        }















        /// <summary>
        /// 功能描述：缓存中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-3
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ExeCacheData_EQISO(Info_EQISO info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                //第一步
                #region 初始化变量

                tblHM_EQISO_Info_Midd info_Midd = new tblHM_EQISO_Info_Midd();

                DateTime BeginDate = DateTime.Parse(info.BeginDate);

                DateTime EndDate = DateTime.Parse(info.EndDate);

                #endregion




                //第二步
                #region 处理参数表，检查此条件下是否已经进行过缓存

                using (MiddleContext db = new MiddleContext())
                {
                    var query = (from x in db.tblHM_EQISO_Info_Midd
                                 where x.BeginDate == BeginDate &&
                                 x.EndDate == EndDate &&
                                 x.fldPCode == info.fldPCode &&
                                 x.fldStandardName == info.fldStandardName &&
                                 x.fldLevel == info.fldLevel &&
                                 x.fldItemCode == info.fldItemCode &&
                                 x.DecCarry == info.DecCarry
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
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry)
                };

                dt = rule.RunProcedure_V2("usp_tblEQISO_Report_LevelApprise", paras.ToList(), null, "HMEntityContext");

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
                    info_Midd.BeginDate = BeginDate;
                    info_Midd.EndDate = EndDate;
                    info_Midd.fldPCode = info.fldPCode;
                    info_Midd.fldStandardName = info.fldStandardName;
                    info_Midd.fldLevel = info.fldLevel;
                    info_Midd.fldItemCode = info.fldItemCode;
                    info_Midd.DecCarry = info.DecCarry;

                    db.tblHM_EQISO_Info_Midd.Add(info_Midd);
                    db.SaveChanges();
                }

                #endregion





                //第五步
                #region 相关数据处理




                if (true)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblHM_EQISO_Midd> list = new List<tblHM_EQISO_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblHM_EQISO_Midd data = new tblHM_EQISO_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldPCount = item["fldPCount"].ToString();
                            data.fldScale = item["fldScale"].ToString();
                            data.fldRange = item["fldRange"].ToString();
                            data.fldPiAvg = item["fldPiAvg"].ToString();
                            data.fld1Level = item["fld1Level"].ToString();
                            data.fld2Level = item["fld2Level"].ToString();

                            list.Add(data);
                        }

                        db.tblHM_EQISO_Midd.AddRange(list);
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
        public class Info_EQISO
        {

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
            public string fldPCode { get; set; }


            /// <summary>
            /// 标准级别名称
            /// </summary>
            public string fldStandardName { get; set; }


            /// <summary>
            /// 级别
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

        }















        /// <summary>
        /// 功能描述：删除中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-4
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DelCacheData_EQIW_RLD(List<Del_Info_EQIW_RLD> info)
        {
            string result = null;
            int num = 0;
            try
            {
                using (MiddleContext db = new MiddleContext())
                {
                    foreach (var item in info)
                    {


                        if (item.STatType == 1)
                        {
                            var query = (from x in db.tblHM_EQIW_RLD_STatType1_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();



                            //删除因子表数据
                            foreach (var item2 in query)
                            {
                                var query2 = (from x in db.tblHM_EQIW_RLD_STatType1_Item_Midd
                                              where x.fldFKID == item2.fldAutoID
                                              select x).ToList();

                                db.tblHM_EQIW_RLD_STatType1_Item_Midd.RemoveRange(query2);
                            }



                            //删除数据表数据
                            db.tblHM_EQIW_RLD_STatType1_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblHM_EQIW_RLD_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblHM_EQIW_RLD_Info_Midd.RemoveRange(query3);


                            num = db.SaveChanges();
                        }



                        if (item.STatType == 3)
                        {
                            var query = (from x in db.tblHM_EQIW_RLD_STatType3_Midd
                                         where x.fldFKID == item.fldAutoID
                                         select x).ToList();



                            //删除因子表数据
                            foreach (var item2 in query)
                            {
                                var query2 = (from x in db.tblHM_EQIW_RLD_STatType3_Item_Midd
                                              where x.fldFKID == item2.fldAutoID
                                              select x).ToList();

                                db.tblHM_EQIW_RLD_STatType3_Item_Midd.RemoveRange(query2);
                            }



                            //删除数据表数据
                            db.tblHM_EQIW_RLD_STatType3_Midd.RemoveRange(query);





                            //删除参数表数据
                            var query3 = (from x in db.tblHM_EQIW_RLD_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblHM_EQIW_RLD_Info_Midd.RemoveRange(query3);


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
        public class Del_Info_EQIW_RLD
        {

            /// <summary>
            /// 用于区分表的字段
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 参数表ID
            /// </summary>
            public int fldAutoID { get; set; }

        }










        /// <summary>
        /// 功能描述：删除中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-4
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DelCacheData_EQISO(List<Del_Info_EQISO> info)
        {
            string result = null;
            int num = 0;
            try
            {
                using (MiddleContext db = new MiddleContext())
                {
                    foreach (var item in info)
                    {


                        var query = (from x in db.tblHM_EQISO_Midd
                                     where x.fldFKID == item.fldAutoID
                                     select x).ToList();


                        //删除数据表数据
                        db.tblHM_EQISO_Midd.RemoveRange(query);



                        //删除参数表数据
                        var query3 = (from x in db.tblHM_EQISO_Info_Midd
                                      where x.fldAutoID == item.fldAutoID
                                      select x).ToList();

                        db.tblHM_EQISO_Info_Midd.RemoveRange(query3);


                        num = db.SaveChanges();

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
        public class Del_Info_EQISO
        {

            /// <summary>
            /// 参数表ID
            /// </summary>
            public int fldAutoID { get; set; }

        }




























        /// <summary>
        /// 功能描述：删除中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-4
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage DelCacheData_EQIA_R(List<Del_Info_EQIA_R> info)
        {
            string result = null;
            int num = 0;
            try
            {
                using (MiddleContext db = new MiddleContext())
                {
                    foreach (var item in info)
                    {


                        var query = (from x in db.tblHM_EQIA_R_Midd
                                     where x.fldFKID == item.fldAutoID
                                     select x).ToList();


                        //删除数据表数据
                        db.tblHM_EQIA_R_Midd.RemoveRange(query);



                        //删除参数表数据
                        var query3 = (from x in db.tblHM_EQIA_R_Info_Midd
                                      where x.fldAutoID == item.fldAutoID
                                      select x).ToList();

                        db.tblHM_EQIA_R_Info_Midd.RemoveRange(query3);


                        num = db.SaveChanges();

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
        public class Del_Info_EQIA_R
        {

            /// <summary>
            /// 参数表ID
            /// </summary>
            public int fldAutoID { get; set; }

        }



























    }
}
