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

namespace EMCControls_Middle.Middle.Eqia.Eqia_r
{
    public class ExeEQIA_R_CacheDataController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建时间：2018-4-27
        /// 功能描述：缓存中间库数据
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ExeCacheData(Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            int info_Midd_fldAutoID = 0;
            try
            {

                //第一步
                #region 初始化变量

                tblEQIA_R_Info_Midd info_Midd = new tblEQIA_R_Info_Midd();

                DateTime BeginDate = DateTime.Parse(info.BeginDate);

                DateTime EndDate = DateTime.Parse(info.EndDate);

                #endregion


                //第二步
                #region 处理参数表，检查此条件下是否已经进行过缓存

                using (MiddleContext db = new MiddleContext())
                {
                    var query = (from x in db.tblEQIA_R_Info_Midd
                                 where x.TimeType == info.TimeType &&
                                 x.BeginDate == BeginDate &&
                                 x.EndDate == EndDate &&
                                 x.fldPCode == info.fldPCode &&
                                 x.fldStandardName == info.fldStandardName &&
                                 x.fldLevel == info.fldLevel &&
                                 x.fldItemCode == info.fldItemCode &&
                                 x.DecCarry == info.DecCarry &&
                                 x.IsPre == info.IsPre &&
                                 x.IsYear == info.IsYear &&
                                 x.IsTotal == info.IsTotal &&
                                 x.IsDetail == info.IsDetail &&
                                 x.fldSource == info.fldSource &&
                                 x.AppriseID == info.AppriseID &&
                                 x.STatType == info.STatType &&
                                 x.CityID == info.CityID &&
                                 x.CalculateID == info.CalculateID &&
                                 x.ItemValueType == info.ItemValueType
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



                if (info.STatType == 0)
                {
                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@TimeType",info.TimeType),
                        new SqlParameter("@BeginDate",info.BeginDate),
                        new SqlParameter("@EndDate",info.EndDate),
                        new SqlParameter("@fldPCode",info.fldPCode),
                        new SqlParameter("@fldStandardName",info.fldStandardName),
                        new SqlParameter("@fldLevel",info.fldLevel),
                        new SqlParameter("@fldItemCode",info.fldItemCode),
                        new SqlParameter("@DecCarry",info.DecCarry),
                        new SqlParameter("@IsPre",info.IsPre),
                        new SqlParameter("@IsYear",info.IsYear),
                        new SqlParameter("@IsTotal",info.IsTotal),
                        new SqlParameter("@IsDetail",info.IsDetail),
                        new SqlParameter("@fldSource",info.fldSource),
                        new SqlParameter("@AppriseID",info.AppriseID),
                        new SqlParameter("@STatType",info.STatType),
                        new SqlParameter("@CityID",info.CityID),
                        new SqlParameter("@CalculateID",info.CalculateID),
                        new SqlParameter("@ItemValueType",info.ItemValueType)
                    };

                    dt = rule.RunProcedure("usp_tblEQIA_R_Report_AppriseStat", paras.ToList(), null);

                }


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
                    info_Midd.fldStandardName = info.fldStandardName;
                    info_Midd.fldLevel = info.fldLevel;
                    info_Midd.fldItemCode = info.fldItemCode;
                    info_Midd.DecCarry = info.DecCarry;
                    info_Midd.IsPre = info.IsPre;
                    info_Midd.IsYear = info.IsYear;
                    info_Midd.IsTotal = info.IsTotal;
                    info_Midd.IsDetail = info.IsDetail;
                    info_Midd.fldSource = info.fldSource;
                    info_Midd.AppriseID = info.AppriseID;
                    info_Midd.STatType = info.STatType;
                    info_Midd.CityID = info.CityID;
                    info_Midd.CalculateID = info.CalculateID;
                    info_Midd.ItemValueType = info.ItemValueType;

                    db.tblEQIA_R_Info_Midd.Add(info_Midd);
                    db.SaveChanges();
                }

                info_Midd_fldAutoID = info_Midd.fldAutoID;

                #endregion



                //第五步
                #region 相关数据处理
                List<Model.tblEQIA_R_Item> list_item = new List<tblEQIA_R_Item>();
                using (MiddleContext db = new MiddleContext())
                {
                    list_item = (from x in db.tblEQIA_R_Item
                                 select x).ToList();


                    list_item = (from x in list_item
                                 where info.fldItemCode.Split(',').Contains(x.fldItemCode)
                                 select x).ToList();
                }


                // 日 - 城市评价
                if (info.TimeType == "day" && info.AppriseID == 1)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_R_City_DayStat_Midd> list = new List<tblEQIA_R_City_DayStat_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIA_R_City_DayStat_Midd data = new tblEQIA_R_City_DayStat_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;


                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldAppDate = DateTime.Parse(item["fldAppDate"].ToString());
                            data.fldMaxDAPI = item["fldMaxDAPI"].ToString();
                            data.fldItem = item["fldItem"].ToString();
                            data.fldOverItems = item["fldOverItems"].ToString();
                            data.fldDAQL = item["fldDAQL"].ToString();


                            list.Add(data);
                            db.tblEQIA_R_City_DayStat_Midd.Add(data);
                            db.SaveChanges();





                            // 因子表相关操作
                            List<tblEQIA_R_City_DayStat_Item_Midd> data_item_list = new List<tblEQIA_R_City_DayStat_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {

                                tblEQIA_R_City_DayStat_Item_Midd data_item = new tblEQIA_R_City_DayStat_Item_Midd();

                                data_item.fldFKID = int.Parse(data.fldAutoID.ToString());

                                data_item.fldItemCode = item2;
                                data_item.fldSTCode = item["fldSTCode"].ToString();
                                data_item.fldAppDate = DateTime.Parse(item["fldAppDate"].ToString());




                                data_item.fldItemAVG = item["AVG_" + (from x in list_item where item2 == x.fldItemCode select x.fldItemName).FirstOrDefault()].ToString();
                                data_item.fldItemAQI = item["AQI_" + (from x in list_item where item2 == x.fldItemCode select x.fldItemName).FirstOrDefault()].ToString();



                                data_item_list.Add(data_item);

                            }

                            db.tblEQIA_R_City_DayStat_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }

                }


                // 日 - 点位评价
                if (info.TimeType == "day" && info.AppriseID == 0)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_R_Point_DayStat_Midd> list = new List<tblEQIA_R_Point_DayStat_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIA_R_Point_DayStat_Midd data = new tblEQIA_R_Point_DayStat_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldPCode = item["fldPCode"].ToString();
                            data.fldPName = item["fldPName"].ToString();
                            data.fldPointLevel = item["fldPointLevel"].ToString();
                            data.fldAppDate = DateTime.Parse(item["fldAppDate"].ToString());
                            data.fldMaxDAPI = item["fldMaxDAPI"].ToString();
                            data.fldItem = item["fldItem"].ToString();
                            data.fldOverItems = item["fldOverItems"].ToString();

                            list.Add(data);
                            db.tblEQIA_R_Point_DayStat_Midd.Add(data);
                            db.SaveChanges();





                            // 因子表相关操作
                            List<tblEQIA_R_Point_DayStat_Item_Midd> data_item_list = new List<tblEQIA_R_Point_DayStat_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                tblEQIA_R_Point_DayStat_Item_Midd data_item = new tblEQIA_R_Point_DayStat_Item_Midd();

                                data_item.fldFKID = int.Parse(data.fldAutoID.ToString());

                                data_item.fldItemCode = item2;
                                data_item.fldSTCode = item["fldSTCode"].ToString();
                                data_item.fldPCode = item["fldPCode"].ToString();
                                data_item.fldAppDate = DateTime.Parse(item["fldAppDate"].ToString());
                                data_item.fldItemAVG = item["AVG_" + (from x in list_item where item2 == x.fldItemCode select x.fldItemName).FirstOrDefault()].ToString();
                                data_item.fldItemAQI = item["AQI_" + (from x in list_item where item2 == x.fldItemCode select x.fldItemName).FirstOrDefault()].ToString();

                                data_item_list.Add(data_item);

                            }

                            db.tblEQIA_R_Point_DayStat_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }

                }

                // 季度、年、月 - 点位评价
                if ((info.TimeType == "sea" && info.AppriseID == 0) || (info.TimeType == "month" && info.AppriseID == 0) || (info.TimeType == "year" && info.AppriseID == 0))
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_R_Point_TotalDateStat_Midd> list = new List<tblEQIA_R_Point_TotalDateStat_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIA_R_Point_TotalDateStat_Midd data = new tblEQIA_R_Point_TotalDateStat_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;
                            data.fldTimeType = info.TimeType;

                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldPCode = item["fldPCode"].ToString();
                            data.fldPName = item["fldPName"].ToString();
                            data.fldPointLevel = item["fldPointLevel"].ToString();

                            data.fldAppDate = item["fldAppDate"].ToString();
                            data.fldSumCount = item["fldSumCount"].ToString();
                            data.fldCount = item["fldCount"].ToString();
                            data.fldYLCount = item["fldYLCount"].ToString();
                            data.fldYCount = item["fld1Count"].ToString();
                            data.fldLCount = item["fld2Count"].ToString();
                            data.fldQDCount = item["fld3Count"].ToString();
                            data.fldZDCount = item["fld4Count"].ToString();
                            data.fldZZDCount = item["fld5Count"].ToString();
                            data.fldYZCount = item["fld6Count"].ToString();
                            data.fldWPI = item["fldWPI"].ToString();
                            data.fldMCPI = item["fldMCPI"].ToString();
                            data.fldCFI = item["fldCFI"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();

                            list.Add(data);
                            db.tblEQIA_R_Point_TotalDateStat_Midd.Add(data);
                            db.SaveChanges();





                            // 因子表相关操作
                            List<tblEQIA_R_Point_TotalDateStat_Item_Midd> data_item_list = new List<tblEQIA_R_Point_TotalDateStat_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {

                                tblEQIA_R_Point_TotalDateStat_Item_Midd data_item = new tblEQIA_R_Point_TotalDateStat_Item_Midd();

                                data_item.fldFKID = int.Parse(data.fldAutoID.ToString());

                                data_item.fldItemCode = item2;
                                data_item.fldSTCode = item["fldSTCode"].ToString();
                                data_item.fldPCode = item["fldPCode"].ToString();
                                data_item.fldTimeType = item["fldType"].ToString();
                                data_item.fldAppDate = item["fldAppDate"].ToString();
                                data_item.fldItemAVG = item["AVG_" + item2].ToString();
                                data_item.fldItemSD = item["Sd_" + item2].ToString();
                                data_item.fldItemMin = item["Min_" + item2].ToString();
                                data_item.fldItemMax = item["Max_" + item2].ToString();
                                data_item.fldItemLevels = item["Levels_" + item2].ToString();
                                data_item.fldItemAllDays = item["AllDays_" + item2].ToString();
                                data_item.fldItemCurDays = item["CurDays_" + item2].ToString();
                                data_item.fldItemStdDays = item["StdDays_" + item2].ToString();
                                data_item.fldItem1LevelDays = item["1LevelDays" + item2].ToString();
                                data_item.fldItemStand = item["Stand" + item2].ToString();
                                data_item.fldItemOvers = item["Overs" + item2].ToString();
                                data_item.fldItemMinOut = item["MinOut" + item2].ToString();
                                data_item.fldItemMaxOut = item["MaxOut_" + item2].ToString();
                                data_item.fldItemCFI = item["CFI_" + item2].ToString();
                                data_item.fldItemCFIW = item["CFI_W_" + item2].ToString();
                                data_item.fldItemCPI = item["CPI_" + item2].ToString();
                                data_item.fldItemLoad = item["Load_" + item2].ToString();
                                data_item.fldItemBFW = item["BFW_" + item2].ToString();
                                data_item.fldItemBFW90 = item["BFW90_" + item2].ToString();
                                data_item.fldItemBFW98 = item["BFW98_" + item2].ToString();

                                data_item_list.Add(data_item);

                            }

                            db.tblEQIA_R_Point_TotalDateStat_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }

                }

                // 季度、年、月 - 城市评价
                if ((info.TimeType == "sea" && info.AppriseID == 1) || (info.TimeType == "month" && info.AppriseID == 1) || (info.TimeType == "year" && info.AppriseID == 1))
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_R_City_TotalDateStat_Midd> list = new List<tblEQIA_R_City_TotalDateStat_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIA_R_City_TotalDateStat_Midd data = new tblEQIA_R_City_TotalDateStat_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;
                            data.fldTimeType = info.TimeType;

                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldAppDate = item["fldAppDate"].ToString();
                            data.fldSumCount = item["fldSumCount"].ToString();
                            data.fldCount = item["fldCount"].ToString();
                            data.fldYLCount = item["fldYLCount"].ToString();
                            data.fldYCount = item["fld1Count"].ToString();
                            data.fldLCount = item["fld2Count"].ToString();
                            data.fldQDCount = item["fld3Count"].ToString();
                            data.fldZDCount = item["fld4Count"].ToString();
                            data.fldZZDCount = item["fld5Count"].ToString();
                            data.fldYZCount = item["fld6Count"].ToString();
                            data.fldWPI = item["fldWPI"].ToString();
                            data.fldMCPI = item["fldMCPI"].ToString();
                            data.fldCFI = item["fldCFI"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();

                            list.Add(data);
                            db.tblEQIA_R_City_TotalDateStat_Midd.Add(data);
                            db.SaveChanges();





                            // 因子表相关操作
                            List<tblEQIA_R_City_TotalDateStat_Item_Midd> data_item_list = new List<tblEQIA_R_City_TotalDateStat_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                tblEQIA_R_City_TotalDateStat_Item_Midd data_item = new tblEQIA_R_City_TotalDateStat_Item_Midd();

                                data_item.fldFKID = int.Parse(data.fldAutoID.ToString());

                                data_item.fldItemCode = item2;
                                data_item.fldSTCode = item["fldSTCode"].ToString();
                                data_item.fldTimeType = item["fldType"].ToString();
                                data_item.fldAppDate = item["fldAppDate"].ToString();
                                data_item.fldItemAVG = item["AVG_" + item2].ToString();
                                data_item.fldItemSD = item["Sd_" + item2].ToString();
                                data_item.fldItemMin = item["Min_" + item2].ToString();
                                data_item.fldItemMax = item["Max_" + item2].ToString();
                                data_item.fldItemLevels = item["Levels_" + item2].ToString();
                                data_item.fldItemAllDays = item["AllDays_" + item2].ToString();
                                data_item.fldItemCurDays = item["CurDays_" + item2].ToString();
                                data_item.fldItemStdDays = item["StdDays_" + item2].ToString();
                                data_item.fldItem1LevelDays = item["1LevelDays" + item2].ToString();
                                data_item.fldItemStand = item["Stand" + item2].ToString();
                                data_item.fldItemOvers = item["Overs" + item2].ToString();
                                data_item.fldItemMinOut = item["MinOut" + item2].ToString();
                                data_item.fldItemMaxOut = item["MaxOut_" + item2].ToString();
                                data_item.fldItemCFI = item["CFI_" + item2].ToString();
                                data_item.fldItemCFIW = item["CFI_W_" + item2].ToString();
                                data_item.fldItemCPI = item["CPI_" + item2].ToString();
                                data_item.fldItemLoad = item["Load_" + item2].ToString();
                                data_item.fldItemBFW = item["BFW_" + item2].ToString();
                                data_item.fldItemBFW90 = item["BFW90_" + item2].ToString();
                                data_item.fldItemBFW98 = item["BFW98_" + item2].ToString();

                                data_item_list.Add(data_item);

                            }

                            db.tblEQIA_R_City_TotalDateStat_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }
                    }

                }

                #endregion


                result = rule.JsonStr("ok", "执行成功！", info_Midd.fldAutoID);
            }
            catch (Exception e)
            {
                if (info_Midd_fldAutoID > 0)
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        var query = (from x in db.tblEQIA_R_Info_Midd
                                     where x.fldAutoID == info_Midd_fldAutoID
                                     select x).FirstOrDefault();
                        db.tblEQIA_R_Info_Midd.Remove(query);
                        db.SaveChanges();
                    }
                }

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
            public string fldPCode { get; set; }

            /// <summary>
            /// 标准级别名称
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
            /// 数据源
            /// </summary>
            public int fldSource { get; set; }

            /// <summary>
            /// 0:针对单个点位评价、1：针对城市评价  
            /// </summary>
            public int AppriseID { get; set; }

            /// <summary>
            /// 0:综合评价表；90：达标天数秩相关；91：污染物浓度秩相关;92：综合指数秩相关  
            /// </summary>
            public int STatType { get; set; }

            /// <summary>
            /// 0:默认城市（fldSTCode）；1：区县（太原市fldLCode）  20：城市（月标准）  21：区县（月标准）
            /// </summary>
            public int CityID { get; set; }

            /// <summary>
            /// --计算方法，0：按照国家标准计算，1：不进行数据有效性判定，2：点位个数按照国家判定，有效天数不按 
            /// </summary>
            public int CalculateID { get; set; }

            /// <summary>
            /// --day:默认例行数据， hour：未审核小时数据	,  audithourdata:已审核小时值	,cityday:城市日均值   , middlehour:中间库小时数据	,middleday:中间库日数据	  			    
            /// </summary>
            public string ItemValueType { get; set; }


        }









    }
}
