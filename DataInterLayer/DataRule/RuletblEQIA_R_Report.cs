using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using System.Collections;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIA_R_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  年、季、月报统计评价
        /// 创建者      ：  夏天
        /// 创建日期    ：  2015-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sLStdName">湖库标准名称</param>
        ///  <param name="sLStdLevel">湖库标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>        
        /// <param name="Source">数据源</param>
        /// <param name="iAppriseID">0:针对单个点位评价、1：针对城市评价、2：城市、测点都存在 </param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iCityID">0:默认城市；1：太原市</param>
        /// <param name="iCalculateID">计算方法，0：按照国家标准计算，1：不进行数据有效性判定</param>
        /// <returns>DataTable</returns>
        public DataTable GetAirYearSeaMonthDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sPoint, string sItem, string sLStdName = "环境空气质量标准2012",
             short sLStdLevel = 2, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int Source = 0, int iAppriseID = 0, short sTatType = 0, int iCityID = 0, int iCalculateID = 0)
        {
            try
            {
                usp_tblEQIA_R_Report_AppriseStat uspAnalyseData = new usp_tblEQIA_R_Report_AppriseStat();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.fldSource = Source;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.CityID = iCityID;
                uspAnalyseData.CalculateID = iCalculateID;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIA_R_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }


        /// 功能描述    ：  日报统计评价
        /// 创建者      ：  夏天
        /// 创建日期    ：  2015-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sLStdName">空气标准名称</param>
        ///  <param name="sLStdLevel">空气标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>        
        /// <param name="Source">数据源</param>
        /// <param name="iAppriseID">0:针对单个点位评价、1：针对城市评价、2：城市、测点都存在 </param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iCityID">0:默认城市；1：太原市</param>
        /// <param name="iCalculateID">计算方法，0：按照国家标准计算，1：不进行数据有效性判定</param>
        /// <returns>DataTable</returns>
        public DataTable GetAirDayDataInfo(string sBeginDate, string sEndDate, string sPoint, string sItem, string sLStdName = "环境空气质量标准2012",
             short sLStdLevel = 2, string sTimeType = "day", string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int Source = 0, int iAppriseID = 0, short sTatType = 0,int iCityID = 0, int iCalculateID = 0)
        {
            try
            {
                usp_tblEQIA_R_Report_AppriseStat uspAnalyseData = new usp_tblEQIA_R_Report_AppriseStat();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.fldSource = Source;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.CityID = iCityID;
                uspAnalyseData.CalculateID = iCalculateID;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Basedata", "GetAirDayDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_Basedata", "GetAirDayDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Basedata", "GetAirDayDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + 
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }



        /// 功能描述    ：  大气小时数据评价信息
        /// 创建者      ：  都玉新
        /// 创建日期    ：  206-06-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sStdName">空气标准名称</param>
        ///  <param name="sStdLevel">空气标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <returns>DataTable</returns>
        public DataTable GetAirHourDataInfo(string sBeginDate, string sEndDate, string sPoint, string sItem, string sStdName = "环境空气质量标准2012",
             short sStdLevel = 2, string cDecCarry = "0")
        {
            try
            {
                usp_tblEQIA_R_Report_HourStat uspAnalyseData = new usp_tblEQIA_R_Report_HourStat();
                uspAnalyseData.BeginTime = System.Convert.ToDateTime(sBeginDate);
                uspAnalyseData.EndTime = System.Convert.ToDateTime(sEndDate);
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sStdName;
                uspAnalyseData.fldLevel = sStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Basedata", "GetAirHourDataInfo",  
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sStdName:" + sStdName + ",sStdLevel:" + sStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQIA_R_Basedata", "GetAirHourDataInfo", 
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sStdName:" + sStdName + ",sStdLevel:" + sStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Basedata"+e.Message, "GetAirHourDataInfo", 
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sStdName:" + sStdName + ",sStdLevel:" + sStdLevel.ToString() + ",sLIStdName:");
            }
        }


        /// 功能描述    ： 空气综合秩相关
        /// 创建者      ：  du
        /// 创建日期    ：  2016-01-02
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="sLStdName">湖库标准名称</param>
        ///  <param name="sLStdLevel">湖库标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>        
        /// <param name="Source">数据源</param>
        /// <param name="iAppriseID">0:针对单个点位评价、1：针对城市评价、2：城市、测点都存在  </param>
        /// <param name="sTatType">0:综合评价表；90：达标天数秩相关；91：污染物浓度秩相关;92：综合指数秩相关</param>
        /// <param name="iCityID">0:默认城市；1：太原市</param>
        /// <param name="iCalculateID">计算方法，0：按照国家标准计算，1：不进行数据有效性判定</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQIADataInfo(string sTimeType, string sBeginDate, string sEndDate, string sPoint, string sItem, string sLStdName = "环境空气质量标准2012",
             short sLStdLevel = 2, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int Source = 0, int iAppriseID = 0, short sTatType = 0, int iCityID = 0, int iCalculateID = 0)
        {
            try
            {
                usp_tblEQIA_R_Report_AppriseStat uspAnalyseData = new usp_tblEQIA_R_Report_AppriseStat();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.fldSource = Source;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.CityID = iCityID;
                uspAnalyseData.CalculateID = iCalculateID;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Basedata", "GetEQIADataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_Basedata", "GetEQIADataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Basedata", "GetEQIADataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }

        #endregion
    }
}
