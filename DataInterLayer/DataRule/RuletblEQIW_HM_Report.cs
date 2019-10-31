using System;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  对表[tblEQIW_HM_Report]的数据操作
    /// 创建者      ：  都玉新
    /// 创建日期    ：  2016-04-11
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIW_HM_Report : BaseRule
    { 
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  断面综合统计
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-04-11
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sRSC">水期</param>
        /// <param name="sPoint">断面代码</param>
        /// <param name="sRIStdName">河流标准名称</param>
        ///  <param name="sRIStdLevel">河流标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="iAppriseID">0:针对单个断面评价、1：针对空间评价</param>
        /// <param name="iSpaceID">0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode </param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iPara1ID">河流均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="iPara2ID">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry="0", int IsPre=0, int IsYear=0, int IsTotal=0, int IsDetail=0,
            int iAppriseID = 0, int iSpaceID=2, short sTatType = 0,int iPara1ID=0,int iPara2ID=0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_Hm_Report_Apprise uspAnalyseData = new usp_tblEQIW_Hm_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;

                uspAnalyseData.EBeginDate = sEBeginDate == null ? "" : sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate;


                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_HM_Report", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() );
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIW_HM_Report", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() +  ",sLIStdLevel:" 
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" );
            }
        }
        /// 功能描述    ：  河流、水系、流域等综合统计
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2015-07-13
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sRSC">水期</param>
        /// <param name="sPoint">断面代码</param>
        /// <param name="sRIStdName">河流标准名称</param>
        ///  <param name="sRIStdLevel">河流标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="iAppriseID">0:针对单个断面评价、1：针对空间评价</param>
        /// <param name="iSpaceID">0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode </param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iPara1ID">河流均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="iPara2ID">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <returns>DataTable</returns>
        public DataTable GetSpaceDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_Hm_Report_Apprise uspAnalyseData = new usp_tblEQIW_Hm_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;

                uspAnalyseData.EBeginDate = sEBeginDate == null ? "" : sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_HM_Report", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_HM_Report", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:");
            }
        }

        /// 功能描述    ：  国家上报信息
        /// 创建者      ：  du
        /// 创建日期    ：  2015-05-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="BeginDate">开始日期</param> 
        /// <param name="EndDate">结束日期</param>
        /// <param name="ItemCode">项目代码</param>
        /// <param name="LLevel">湖库标准级别</param>
        /// <param name="LSDName">湖库标准名称</param> 
        /// <param name="RLevel">河流标准级别</param> 
        /// <param name="RSDName">河流标准名称</param>
        /// <param name="STCode">城市代码</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionForUpReport(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                // usp_tblEQIW_R_Report_DataBaseExprot uspAnalyseData = new usp_tblEQIW_R_Report_DataBaseExprot();
                usp_tblEQIW_Hm_Report_Apprise uspAnalyseData = new usp_tblEQIW_Hm_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.EBeginDate = sEBeginDate == null ? "" : sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_HM_Report", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString()+ ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_HM_Report", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString()  + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
        }


        /// 功能描述    ：  年鉴信息
        /// 创建者      ：  du
        /// 创建日期    ：  2015-05-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="BeginDate">开始日期</param> 
        /// <param name="EndDate">结束日期</param>
        /// <param name="ItemCode">项目代码</param>
        /// <param name="LLevel">湖库标准级别</param>
        /// <param name="LSDName">湖库标准名称</param> 
        /// <param name="RLevel">河流标准级别</param> 
        /// <param name="RSDName">河流标准名称</param>
        /// <param name="STCode">城市代码</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionForApprise(string sTimeType, string sBeginDate, string sEndDate, string sRSC, short sSource, short sJudge, string sPoint,
            string sRIStdName, short sRIStdLevel, string sLIStdName, short sLIStdLevel, string sItem, string cDecCarry, short sFromHour, string sTatName, short sTatType, short sReportFlag)
        {
            try
            {
                usp_tblEQIW_R_Report_DataApprise uspAnalyseData = new usp_tblEQIW_R_Report_DataApprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldRStandardName = sRIStdName;
                uspAnalyseData.fldRLevel = sRIStdLevel;
                uspAnalyseData.fldLStandardName = sLIStdName;
                uspAnalyseData.fldLLevel = sLIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                uspAnalyseData.STatName = sTatName;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.ReportFlag = sReportFlag;
                DataTable tblData = uspAnalyseData.ExecDataTable(3);//调用通用报表过程
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_HM_Report", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_HM_Report", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }
        #endregion
    }
}
