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

namespace EMCControls_Middle.Middle.Eqiw.eqiw_d
{
    public class ExeEQIW_D_CacheDataController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：缓存中间库数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-9
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

                tblEQIW_D_Info_Midd info_Midd = new tblEQIW_D_Info_Midd();

                DateTime BeginDate = DateTime.Parse(info.BeginDate);

                DateTime EndDate = DateTime.Parse(info.EndDate);

                #endregion




                //第二步
                #region 处理参数表，检查此条件下是否已经进行过缓存

                using (MiddleContext db = new MiddleContext())
                {
                    var query = (from x in db.tblEQIW_D_Info_Midd
                                 where x.TimeType == info.TimeType &&
                                 x.BeginDate == BeginDate &&
                                 x.EndDate == EndDate &&
                                 x.fldRSC == info.fldRSC &&
                                 x.fldRSCode == info.fldRSCode &&
                                 x.fldRStandardName == info.fldRStandardName &&
                                 x.fldRLevel == info.fldRLevel &&
                                 x.fldLStandardName == info.fldLStandardName &&
                                 x.fldLLevel == info.fldLLevel &&
                                 x.fldItemCode == info.fldItemCode &&
                                 x.DecCarry == info.DecCarry &&
                                 x.IsPre == info.IsPre &&
                                 x.IsYear == info.IsYear &&
                                 x.IsTotal == info.IsTotal &&
                                 x.IsDetail == info.IsDetail &&
                                 x.IsTLI == info.IsTLI &&
                                 x.TLIType == info.TLIType &&
                                 x.AppriseID == info.AppriseID &&
                                 x.SpaceID == info.SpaceID &&
                                 x.STatType == info.STatType &&
                                 x.fldSource == info.fldSource &&
                                 x.CalculateID == info.CalculateID
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



                if (info.STatType == 2)
                {
                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@TimeType",info.TimeType),
                        new SqlParameter("@BeginDate",info.BeginDate),
                        new SqlParameter("@EndDate",info.EndDate),
                        new SqlParameter("@fldRSC",info.fldRSC),
                        new SqlParameter("@fldRSCode",info.fldRSCode),
                        new SqlParameter("@fldRStandardName",info.fldRStandardName),
                        new SqlParameter("@fldRLevel",info.fldRLevel),
                        new SqlParameter("@fldLStandardName",info.fldLStandardName),
                        new SqlParameter("@fldLLevel",info.fldLLevel),
                        new SqlParameter("@fldItemCode",info.fldItemCode),
                        new SqlParameter("@DecCarry",info.DecCarry),
                        new SqlParameter("@IsPre",info.IsPre),
                        new SqlParameter("@IsYear",info.IsYear),
                        new SqlParameter("@IsTotal",info.IsTotal),
                        new SqlParameter("@IsDetail",info.IsDetail),
                        new SqlParameter("@IsTLI",info.IsTLI),
                        new SqlParameter("@TLIType",info.TLIType),
                        new SqlParameter("@AppriseID",info.AppriseID),
                        new SqlParameter("@SpaceID",info.SpaceID),
                        new SqlParameter("@STatType",info.STatType),
                        new SqlParameter("@fldSource",int.Parse(info.fldSource)),
                        new SqlParameter("@CalculateID",info.CalculateID),
                        new SqlParameter("@CategoryID",info.CategoryID)
                    };

                    dt = rule.RunProcedure("usp_tblEQIW_DX_Report_Apprise", paras.ToList(), null);

                }
                else
                {
                    SqlParameter[] paras = new SqlParameter[]
                    {
                        new SqlParameter("@TimeType",info.TimeType),
                        new SqlParameter("@BeginDate",info.BeginDate),
                        new SqlParameter("@EndDate",info.EndDate),
                        new SqlParameter("@fldRSC",info.fldRSC),
                        new SqlParameter("@fldRSCode",info.fldRSCode),
                        new SqlParameter("@fldRStandardName",info.fldRStandardName),
                        new SqlParameter("@fldRLevel",info.fldRLevel),
                        new SqlParameter("@fldLStandardName",info.fldLStandardName),
                        new SqlParameter("@fldLLevel",info.fldLLevel),
                        new SqlParameter("@fldItemCode",info.fldItemCode),
                        new SqlParameter("@DecCarry",info.DecCarry),
                        new SqlParameter("@IsPre",info.IsPre),
                        new SqlParameter("@IsYear",info.IsYear),
                        new SqlParameter("@IsTotal",info.IsTotal),
                        new SqlParameter("@IsDetail",info.IsDetail),
                        new SqlParameter("@IsTLI",info.IsTLI),
                        new SqlParameter("@TLIType",info.TLIType),
                        new SqlParameter("@AppriseID",info.AppriseID),
                        new SqlParameter("@SpaceID",info.SpaceID),
                        new SqlParameter("@STatType",info.STatType),
                        new SqlParameter("@fldSource",int.Parse(info.fldSource)),
                        new SqlParameter("@CalculateID",info.CalculateID)
                    };

                    dt = rule.RunProcedure("usp_tblEQIW_D_Report_Apprise", paras.ToList(), null);

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
                    info_Midd.fldRSC = info.fldRSC;
                    info_Midd.fldRSCode = info.fldRSCode;
                    info_Midd.fldRStandardName = info.fldRStandardName;
                    info_Midd.fldRLevel = info.fldRLevel;
                    info_Midd.fldLStandardName = info.fldLStandardName;
                    info_Midd.fldLLevel = info.fldLLevel;
                    info_Midd.fldItemCode = info.fldItemCode;
                    info_Midd.DecCarry = info.DecCarry;
                    info_Midd.IsPre = info.IsPre;
                    info_Midd.IsYear = info.IsYear;
                    info_Midd.IsTotal = info.IsTotal;
                    info_Midd.IsDetail = info.IsDetail;
                    info_Midd.IsTLI = info.IsTLI;
                    info_Midd.TLIType = info.TLIType;
                    info_Midd.AppriseID = info.AppriseID;
                    info_Midd.SpaceID = info.SpaceID;
                    info_Midd.STatType = info.STatType;
                    info_Midd.fldSource = info.fldSource;
                    info_Midd.CalculateID = info.CalculateID;

                    db.tblEQIW_D_Info_Midd.Add(info_Midd);
                    db.SaveChanges();
                }

                info_Midd_fldAutoID = info_Midd.fldAutoID;

                #endregion





                //第五步
                #region 相关数据处理



                // 综合评价 - 城市评价
                if (info.SpaceID == 3 && info.AppriseID == 1)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIW_D_City_Midd> list = new List<tblEQIW_D_City_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIW_D_City_Midd data = new tblEQIW_D_City_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.STatType = info.STatType.ToString();
                            data.fldTimeType = info.TimeType;

                            if (item["fldAppDate"].ToString() == "平均")
                            {
                                data.fldBeginDate = DateTime.Parse(info.BeginDate);
                                data.fldEndDate = DateTime.Parse(info.EndDate);
                            }

                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldAppDate = item["fldAppDate"].ToString();
                            data.fldSCategory = item["fldSCategory"].ToString();
                            data.fldSetCount = item["fldSetCount"].ToString();
                            data.fldRSCount = item["fldRSCount"].ToString();
                            data.fldYJCheckItem = item["fldYJCheckItem"].ToString();
                            data.fldWJCheckItem = item["fldWJCheckItem"].ToString();
                            data.fldAllSL = item["fldAllSL"].ToString();
                            data.fldStdSL = item["fldStdSL"].ToString();
                            data.fldScale = item["fldScale"].ToString();
                            data.fldFStdSL = item["fldFStdSL"].ToString();
                            data.fldFScale = item["fldFScale"].ToString();
                            data.fldCount = item["fldCount"].ToString();
                            data.fldStdCount = item["fldStdCount"].ToString();
                            data.fldstdScale = item["fldstdScale"].ToString();
                            data.fldFstdCount = item["fldFstdCount"].ToString();
                            data.fldFstdScale = item["fldFstdScale"].ToString();
                            data.fldStdSecion = item["fldStdSecion"].ToString();
                            data.fldSectionScale = item["fldSectionScale"].ToString();
                            data.fldFStdSecion = item["fldFStdSecion"].ToString();
                            data.fldFSectionScale = item["fldFSectionScale"].ToString();
                            data.fldSections = item["fldSections"].ToString();
                            data.fldFSections = item["fldFSections"].ToString();
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
                            data.fld6Count = item["fld6Count"].ToString();
                            data.fld6Scale = item["fld6Scale"].ToString();

                            list.Add(data);
                            db.tblEQIW_D_City_Midd.Add(data);
                            db.SaveChanges();





                            // 因子表相关操作
                            List<tblEQIW_D_City_Item_Midd> data_item_list = new List<tblEQIW_D_City_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains(item2 + "_Value"))
                                {
                                    tblEQIW_D_City_Item_Midd data_item = new tblEQIW_D_City_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fld_Value = item[item2 + "_Value"].ToString();

                                    if (item.Table.Columns.Contains(item2 + "_Min"))
                                    {
                                        data_item.fld_Min = item[item2 + "_Min"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_Max"))
                                    {
                                        data_item.fld_Max = item[item2 + "_Max"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_AvgValueStage"))
                                    {
                                        data_item.fld_AvgValueStage = item[item2 + "_AvgValueStage"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_MaxValueStage"))
                                    {
                                        data_item.fld_MaxValueStage = item[item2 + "_MaxValueStage"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_Count"))
                                    {
                                        data_item.fld_MaxValueStage = item[item2 + "_Count"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_OutCount"))
                                    {
                                        data_item.fld_OutCount = item[item2 + "_OutCount"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_OutScale"))
                                    {
                                        data_item.fld_OutScale = item[item2 + "_OutScale"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_AvgOut"))
                                    {
                                        data_item.fld_AvgOut = item[item2 + "_AvgOut"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_MaxOut"))
                                    {
                                        data_item.fld_MaxOut = item[item2 + "_MaxOut"].ToString();
                                    }


                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQIW_D_City_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }














                    }

                }


                // 综合评价 - 断面评价
                if (info.SpaceID == 3 && info.AppriseID == 0)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIW_D_Section_Midd> list = new List<tblEQIW_D_Section_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIW_D_Section_Midd data = new tblEQIW_D_Section_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.STatType = info.STatType.ToString();
                            data.fldTimeType = info.TimeType;

                            if (item["fldAppDate"].ToString() == "平均")
                            {
                                data.fldBeginDate = DateTime.Parse(info.BeginDate);
                                data.fldEndDate = DateTime.Parse(info.EndDate);
                            }

                            data.fldSectionInfo = item["fldSectionInfo"].ToString();
                            data.fldWaterArea = item["fldWaterArea"].ToString();
                            data.fldRSWaterWork = item["fldRSWaterWork"].ToString();
                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldRCode = item["fldRCode"].ToString();
                            data.fldRName = item["fldRName"].ToString();
                            data.fldRSCode = item["fldRSCode"].ToString();
                            data.fldRSName = item["fldRSName"].ToString();
                            data.fldJD = item["fldJD"].ToString();
                            data.fldWD = item["fldWD"].ToString();
                            data.fldSCategory = item["fldSCategory"].ToString();
                            data.fldLevel = item["fldLevel"].ToString();
                            data.fldRSC = item["fldRSC"].ToString();
                            data.fldAppDate = item["fldAppDate"].ToString();
                            data.fldFun = item["fldFun"].ToString();
                            data.fldItemCount = item["fldItemCount"].ToString();
                            data.fldOverCount = item["fldOverCount"].ToString();
                            data.fldTDCheckCount = item["fldTDCheckCount"].ToString();
                            data.fldYJCheckCount = item["fldYJCheckCount"].ToString();
                            //data.fldYJCheckItem = item["fldYJCheckItem"].ToString();
                            data.fldWJCheckCount = item["fldWJCheckCount"].ToString();
                            //data.fldWJCheckItem = item["fldWJCheckItem"].ToString();
                            data.fldAllCheckCount = item["fldAllCheckCount"].ToString();
                            data.fldAllSL = item["fldAllSL"].ToString();
                            data.fldAllScale = item["fldAllScale"].ToString();
                            data.fldStandSL = item["fldStandSL"].ToString();
                            data.fldScaleSL = item["fldScaleSL"].ToString();
                            data.fldFStandSL = item["fldFStandSL"].ToString();
                            data.fldFScaleSL = item["fldFScaleSL"].ToString();
                            data.fldPC = item["fldPC"].ToString();
                            data.fldStandPC = item["fldStandPC"].ToString();
                            data.fldScalePC = item["fldScalePC"].ToString();
                            data.fldFStandPC = item["fldFStandPC"].ToString();
                            data.fldFScalePC = item["fldFScalePC"].ToString();
                            data.fldStage = item["fldStage"].ToString();
                            data.fldSectionApp = item["fldSectionApp"].ToString();
                            data.fldStand = item["fldStand"].ToString();
                            data.fldSingleStageD = item["fldSingleStageD"].ToString();
                            data.fldSingleItemD = item["fldSingleItemD"].ToString();
                            data.fldSingleTimesD = item["fldSingleTimesD"].ToString();
                            data.fldSingleStageF = item["fldSingleStageF"].ToString();
                            data.fldSingleItemF = item["fldSingleItemF"].ToString();
                            data.fldSingleTimesF = item["fldSingleTimesF"].ToString();
                            data.fldWPI = item["fldWPI"].ToString();
                            data.fldAvgWPI = item["fldAvgWPI"].ToString();
                            data.fldOverItem = item["fldOverItem"].ToString();
                            data.fldFOverItem = item["fldFOverItem"].ToString();
                            data.fldOverTimes = item["fldOverTimes"].ToString();
                            data.fldOverScale = item["fldOverScale"].ToString();
                            data.fldOverNum = item["fldOverNum"].ToString();
                            //data.fldOverNum2 = item["fldOverNum2"].ToString();
                            data.fldFOverTimes = item["fldFOverTimes"].ToString();
                            data.fldFOverScale = item["fldFOverScale"].ToString();
                            data.fldFOverNum = item["fldFOverNum"].ToString();
                            data.C314_TLI = item["314_TLI"].ToString();
                            data.C313_TLI = item["313_TLI"].ToString();
                            data.C464_TLI = item["464_TLI"].ToString();
                            data.C501_TLI = item["501_TLI"].ToString();
                            data.C466_TLI = item["466_TLI"].ToString();
                            data.fldTSI = item["fldTSI"].ToString();
                            data.fldTSIRange = item["fldTSIRange"].ToString();
                            data.fldOutItem = item["fldOutItem"].ToString();
                            data.fldOverCheckItem = item["fldOverCheckItem"].ToString();
                            data.fldOverCheckItem_UN = item["fldOverCheckItem_UN"].ToString();
                            data.fldOverCheckTimes = item["fldOverCheckTimes"].ToString();
                            data.fldOverCheckTimes_UN = item["fldOverCheckTimes_UN"].ToString();
                            data.fldRemark = item["fldRemark"].ToString();

                            list.Add(data);
                            db.tblEQIW_D_Section_Midd.Add(data);
                            db.SaveChanges();





                            // 因子表相关操作
                            List<tblEQIW_D_Section_Item_Midd> data_item_list = new List<tblEQIW_D_Section_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains(item2 + "_Value"))
                                {
                                    tblEQIW_D_Section_Item_Midd data_item = new tblEQIW_D_Section_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fld_Value = item[item2 + "_Value"].ToString();

                                    if (item.Table.Columns.Contains(item2 + "_Stage"))
                                    {
                                        data_item.fld_Stage = item[item2 + "_Stage"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_CPI"))
                                    {
                                        data_item.fld_CPI = item[item2 + "_CPI"].ToString();
                                    }

                                    if (item.Table.Columns.Contains(item2 + "_CFI"))
                                    {
                                        data_item.fld_CFI = item[item2 + "_CFI"].ToString();
                                    }

                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQIW_D_Section_Item_Midd.AddRange(data_item_list);
                            db.SaveChanges();
                        }














                    }

                }


                // 因子超标
                if (info.SpaceID == 2)
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_D_ItemOver_Midd> list = new List<tblEQIW_D_ItemOver_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIW_D_ItemOver_Midd data = new tblEQIW_D_ItemOver_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldTimeType = info.TimeType;

                            data.fldItemName = item["fldItemName"].ToString();
                            data.fldDate = item["fldDate"].ToString();
                            data.fldRCount = item["fldRCount"].ToString();
                            data.fldOutCount = item["fldOutCount"].ToString();
                            data.fldScale = item["fldScale"].ToString();
                            data.fldMin = item["fldMin"].ToString();
                            data.fldMax = item["fldMax"].ToString();
                            data.fldMaxOut = item["fldMaxOut"].ToString();
                            data.fldYPCount = item["fldYPCount"].ToString();
                            data.fldYPOutCount = item["fldYPOutCount"].ToString();
                            data.fldYPScale = item["fldYPScale"].ToString();
                            data.fldYPMaxScale = item["fldYPMaxScale"].ToString();
                            data.fldYPOutSection = item["fldYPOutSection"].ToString();
                            data.fldYPOutSectionScale = item["fldYPOutSectionScale"].ToString();
                            data.fldYPMinValue = item["fldYPMinValue"].ToString();
                            data.fldYPMaxValue = item["fldYPMaxValue"].ToString();
                            data.fldYPOverValue = item["fldYPOverValue"].ToString();
                            data.fldYPValue = item["fldYPValue"].ToString();

                            list.Add(data);
                        }

                        db.tblEQIW_D_ItemOver_Midd.AddRange(list);
                        db.SaveChanges();
                    }
                }


                // 城市因子超标
                if (info.SpaceID == 20)
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_D_CityItemOver_Midd> list = new List<tblEQIW_D_CityItemOver_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIW_D_CityItemOver_Midd data = new tblEQIW_D_CityItemOver_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.fldTimeType = info.TimeType;

                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldItemName = item["fldItemName"].ToString();
                            data.fldDate = item["fldDate"].ToString();
                            data.fldRCount = item["fldRCount"].ToString();
                            data.fldOutCount = item["fldOutCount"].ToString();
                            data.fldScale = item["fldScale"].ToString();
                            data.fldMin = item["fldMin"].ToString();
                            data.fldMax = item["fldMax"].ToString();
                            data.fldMaxOut = item["fldMaxOut"].ToString();
                            data.fldYPCount = item["fldYPCount"].ToString();
                            data.fldYPOutCount = item["fldYPOutCount"].ToString();
                            data.fldYPScale = item["fldYPScale"].ToString();
                            data.fldYPMaxScale = item["fldYPMaxScale"].ToString();
                            data.fldYPOutSection = item["fldYPOutSection"].ToString();
                            data.fldYPOutSectionScale = item["fldYPOutSectionScale"].ToString();
                            data.fldYPMinValue = item["fldYPMinValue"].ToString();
                            data.fldYPMaxValue = item["fldYPMaxValue"].ToString();
                            data.fldYPOverValue = item["fldYPOverValue"].ToString();
                            data.fldYPValue = item["fldYPValue"].ToString();

                            list.Add(data);
                        }

                        db.tblEQIW_D_CityItemOver_Midd.AddRange(list);
                        db.SaveChanges();
                    }
                }


                // 年鉴
                if (info.SpaceID == 1)
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIW_D_YearBook_Midd> list = new List<tblEQIW_D_YearBook_Midd>();

                        foreach (DataRow item in dt.Rows)
                        {
                            tblEQIW_D_YearBook_Midd data = new tblEQIW_D_YearBook_Midd();

                            //将参数实体的主键值，设置给数据表的FKID，从而确定数据是从哪个参数下生成的
                            data.fldFKID = info_Midd.fldAutoID;

                            data.STatType = info.STatType.ToString();
                            data.fldTimeType = info.TimeType;

                            data.fldCityCode = item["fldCityCode"].ToString();
                            data.fldCityName = item["fldCityName"].ToString();
                            data.fldSTCode = item["fldSTCode"].ToString();
                            data.fldSTName = item["fldSTName"].ToString();
                            data.fldRCode = item["fldRCode"].ToString();
                            data.fldRName = item["fldRName"].ToString();
                            data.fldRSCode = item["fldRSCode"].ToString();
                            data.fldRSName = item["fldRSName"].ToString();
                            data.fldSCategory = item["fldSCategory"].ToString();
                            data.fldRSC = item["fldRSC"].ToString();
                            data.fldDate = item["fldDate"].ToString();
                            data.fldStage = item["fldStage"].ToString();
                            data.fldOutItems = item["fldOutItems"].ToString();
                            data.fldFOutItems = item["fldFOutItems"].ToString();

                            list.Add(data);
                            db.tblEQIW_D_YearBook_Midd.Add(data);
                            db.SaveChanges();

                            // 因子表相关操作
                            List<tblEQIW_D_YearBook_Item_Midd> data_item_list = new List<tblEQIW_D_YearBook_Item_Midd>();

                            foreach (var item2 in info.fldItemCode.Split(','))
                            {
                                if (item.Table.Columns.Contains("fld" + item2))
                                {
                                    tblEQIW_D_YearBook_Item_Midd data_item = new tblEQIW_D_YearBook_Item_Midd();

                                    data_item.fldFKID = data.fldAutoID;

                                    data_item.fldItemCode = item2;
                                    data_item.fld_Value = item["fld" + item2].ToString();

                                    data_item_list.Add(data_item);
                                }
                            }

                            db.tblEQIW_D_YearBook_Item_Midd.AddRange(data_item_list);
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
                        var query = (from x in db.tblEQIW_D_Info_Midd
                                     where x.fldAutoID == info_Midd_fldAutoID
                                     select x).FirstOrDefault();
                        db.tblEQIW_D_Info_Midd.Remove(query);
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
            public string fldRStandardName { get; set; }


            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldRLevel { get; set; }


            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldLStandardName { get; set; }


            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldLLevel { get; set; }


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
            /// 是否统计富营养化指数
            /// </summary>
            public int IsTLI { get; set; }


            /// <summary>
            /// 富营养化计算时叶绿素a和透明度单位：1-mg/L,cm；0-mg/m^3,m；2-mg/m^3,cm
            /// </summary>
            public int TLIType { get; set; }


            /// <summary>
            /// 0:针对单个断面评价、1：城市评价、2：城市区县评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:日数据表（修约）、1：年鉴表、2：因子超标情况、20：城市因子超标情况、3：综合评价表   31：综合评价表（日均值不修约） 、4：原始数据表（带左中右）、5：日数据表（不修约）、90：取水量秩相关、91：点次达标率秩相关、92：水量达标率秩相关、93：城市因子秩相关
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 0：tblEQIW_D_BaseData
            /// 1：tblEQIW_DT_BaseData
            /// 2：tblEQIW_DX_BaseData
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 用来标识是例行数据还是全分析数据
            /// </summary>
            public string fldSource { get; set; }


            /// <summary>
            /// 计算方法：0：总氮和粪和细菌总数不参与评价、1：总氮和粪参与评价、2：总氮、粪、化学需氧量不参与评价、3：总氮、粪、化学需氧量不参与水质类别,超标水量评价，参加超标因子评价，总大肠菌群都参与
            /// </summary>
            public int CalculateID { get; set; }


            /// <summary>
            /// 乡镇饮用水专用
            /// 默认值0
            /// 重置水源地类别进行评价  0：默认   1：湖库按照河流标准进行评价   2：所有水源地类型按照河流标准评价
            /// </summary>
            public int CategoryID { get; set; }


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
                            var query3 = (from x in db.tblEQIW_D_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQIW_D_Info_Midd.RemoveRange(query3);


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
                            var query3 = (from x in db.tblEQIW_D_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQIW_D_Info_Midd.RemoveRange(query3);


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
                            var query3 = (from x in db.tblEQIW_D_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQIW_D_Info_Midd.RemoveRange(query3);


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
                            var query3 = (from x in db.tblEQIW_D_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQIW_D_Info_Midd.RemoveRange(query3);


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
                            var query3 = (from x in db.tblEQIW_D_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQIW_D_Info_Midd.RemoveRange(query3);


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
                            var query3 = (from x in db.tblEQIW_D_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQIW_D_Info_Midd.RemoveRange(query3);


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
                            var query3 = (from x in db.tblEQIW_D_Info_Midd
                                          where x.fldAutoID == item.fldAutoID
                                          select x).ToList();

                            db.tblEQIW_D_Info_Midd.RemoveRange(query3);


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
}
