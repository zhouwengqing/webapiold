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
    public class RuletblEQIW_L_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑
        /// 功能描述    ：  湖库统计评价
        /// 创建者      ：  summer
        /// 创建日期    ：  2015-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sRSC">水期</param>
        /// <param name="sPoint">断面代码</param>
        /// <param name="sLStdName">湖库标准名称</param>
        ///  <param name="sLStdLevel">湖库标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="IsTLI">是否统计富营养化指数</param>
        /// <param name="TLIType">富营养化计算时叶绿素a和透明度单位：0-mg/L,cm；1-mg/m^3,m</param>
        /// <param name="iAppriseID">0:针对单个垂线评价、1：针对湖库评价</param>
        /// <param name="iSpaceID">0:湖库-fldLCode、1：流域-fldWaterArea、2：设区市-fldSTCode</param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iPara1ID">湖库均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="iPara2ID">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iSource">数据类型</param>
        /// <returns>DataTable</returns>
        public DataTable GetLakeDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sLStdName, short sLStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int IsTLI = 0,int TLIType=0, int iAppriseID = 1, int iSpaceID = 0, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_L_Report_Apprise uspAnalyseData = new usp_tblEQIW_L_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldLSCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = 1;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.IsTLI = IsTLI;
                uspAnalyseData.TLIType = TLIType;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.Source = iSource;

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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_L_Basedata", "GetLakeDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQIW_L_Basedata", "GetLakeDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_L_Basedata", "GetLakeDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }

        /// 功能描述    ：  垂线统计评价
        /// 创建者      ：  summer
        /// 创建日期    ：  2015-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sEBeginDate">第二个时段开始时间</param>
        /// <param name="sEEndDate">第二个时段结束时间</param>
        /// <param name="sRSC">水期</param>
        /// <param name="sPoint">垂线代码列表</param>
        /// <param name="sLStdName">湖库标准名称</param>
        ///  <param name="sLStdLevel">湖库标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="IsTLI">是否统计富营养化指数</param>
        /// <param name="TLIType">富营养化计算时叶绿素a和透明度单位：0-mg/L,cm；1-mg/m^3,m</param>
        /// <param name="iSpaceID">0:湖库-fldLCode、1：流域-fldWaterArea、2：设区市-fldSTCode</param>
        /// <param name="iAppriseID">0:针对单个垂线评价、1：针对湖库评价</param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iPara1ID">湖库均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="iPara2ID">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iSource">数据类型</param>
        /// <returns>DataTable</returns>
        public DataTable GetLSectionDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
             string sLStdName , short sLStdLevel , string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
             int IsTLI = 0, int TLIType = 1,
             int iAppriseID =0, int iSpaceID=0, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_L_Report_Apprise uspAnalyseData = new usp_tblEQIW_L_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldLSCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.IsTLI = IsTLI;
                uspAnalyseData.TLIType = TLIType;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.Source = iSource;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_L_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIW_L_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_L_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }

        /// 功能描述    ：  湖库统计评价
        /// 创建者      ：  summer
        /// 创建日期    ：  2015-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sEBeginDate">第二个时段开始时间</param>
        /// <param name="sEEndDate">第二个时段结束时间</param>
        /// <param name="sRSC">水期</param>
        /// <param name="sPoint">断面代码</param>
        /// <param name="sLStdName">湖库标准名称</param>
        ///  <param name="sLStdLevel">湖库标准级别</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="IsTLI">是否统计富营养化指数</param>
        /// <param name="TLIType">富营养化计算时叶绿素a和透明度单位：0-mg/L,cm；1-mg/m^3,m</param>
        /// <param name="iAppriseID">0:针对单个垂线评价、1：针对湖库评价</param>
        ///  <param name="iSpaceID">0:湖库-fldLCode、1：流域-fldWaterArea、2：设区市-fldSTCode</param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iPara1ID">湖库均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="iPara2ID">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <param name="iSource">数据类型</param>
        /// <returns>DataTable</returns>
        public DataTable GetLDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sLStdName, short sLStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int IsTLI = 0, int TLIType = 0, int iAppriseID = 0, int iSpaceID = 0, short sTatType = 2,int iPara1ID=0,int iPara2ID=0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_L_Report_Apprise uspAnalyseData = new usp_tblEQIW_L_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldLSCode = sPoint;
                uspAnalyseData.fldStandardName = sLStdName;
                uspAnalyseData.fldLevel = sLStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.IsTLI = IsTLI;
                uspAnalyseData.TLIType = TLIType;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.Source = iSource;
               
                uspAnalyseData.EBeginDate = sEBeginDate==null ? "":sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate; 

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_L_Basedata", "GetLakeDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+e.Message, "RuletblEQIW_L_Basedata", "GetLakeDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_L_Basedata", "GetLakeDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sLStdName + ",sRIStdLevel:" + sLStdLevel.ToString() + ",sLIStdName:");
            }
        }




        #endregion

        #region 以下是从综合发布系统迁移过来的

        /// <summary>
        /// 功能描述    ：  湖泊、水库水质类别评价
        /// 创建者      ：  顾兴明
        /// 创建日期    ：  2011-07-04
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始时间</param>
        /// <param name="sEndDate">结束时间</param>
        /// <param name="sRSC">水期代码</param>
        /// <param name="sSource">手动 0，自动 1，全部 2</param>
        /// <param name="sJudge">数据冲突(0 先手 1 先自2全部)</param>
        /// <param name="sPoint">测点代码</param>
        /// <param name="sRIStdName">河流标准级别名称</param>
        /// <param name="sRIStdLevel">河流级别</param>
        /// <param name="sLIStdLevel">湖库标准级别名称</param>
        /// <param name="sLIStdLevel">湖库级别</param>
        /// <param name="sItem">选中项目id</param>
        /// <param name="sDecCarry">平均值取值方法 </param>
        /// <param name="sFromHour">开始小时</param>
        /// <param name="sTatType">0 按流域；1 按河流； 2  按断面 
        /// <returns>DataTable</returns>
        public DataTable GetDataTypeReport(string sTimeType, string sSBeginDate, string sSEndDate, string sEBeginDate, string sEEndDate, string sRSC, short sSource, short sJudge, string sPoint,
            string sRIStdName, short sRIStdLevel, string sLIStdName, short sLIStdLevel,  string sItem, string sDecCarry, short sFromHour,string sTatName, short sTatType,short sReportFlag)                                  
        {
            try
             {
                usp_tblEQIW_L_Report_StageStat uspAnalyseData = new usp_tblEQIW_L_Report_StageStat();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.SBeginDate = sSBeginDate;
                uspAnalyseData.SEndDate = sSEndDate;
                uspAnalyseData.EBeginDate = sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate;
                uspAnalyseData.fldRSC = sRSC;     
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.fldLSCode = sPoint;
                uspAnalyseData.fldRStandardName = sRIStdName;
                uspAnalyseData.fldRLevel = sRIStdLevel;
                uspAnalyseData.fldLStandardName = sLIStdName;
                uspAnalyseData.fldLLevel = sLIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = sDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                uspAnalyseData.STatName = sTatName;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.ReportFlag = sReportFlag;
                
                
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_L_Report", "usp_tblEQIW_L_Report_StageStat", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sSBeginDate + ",sEndDate:" + sSEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            sDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_L_Report", "GetDataStatReport", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sSBeginDate + ",sEndDate:" + sSEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            sDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_L_Report", "GetDataStatReport", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sSBeginDate + ",sEndDate:" + sSEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            sDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  全区湖库水质类别统计
        /// 创建者      ：  顾兴明
        /// 创建日期    ：  2011-07-08
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始时间</param>
        /// <param name="sEndDate">结束时间</param>
        /// <param name="sRSC">水期代码</param>
        /// <param name="sSource">手动 0，自动 1，全部 2</param>
        /// <param name="sJudge">数据冲突(0 先手 1 先自2全部)</param>
        /// <param name="sPoint">测点代码</param>
        /// <param name="sRIStdName">河流标准级别名称</param>
        /// <param name="sRIStdLevel">河流级别</param>
        /// <param name="sLIStdLevel">湖库标准级别名称</param>
        /// <param name="sSource">湖库级别</param>
        /// <param name="sItem">选中项目id</param>
        /// <param name="cDecCarry">平均值取值方法 </param>
        /// <param name="sFromHour">开始小时</param>
        /// <param name="sTatType">0 按流域；1 按河流； 2  按断面 
        /// <returns>DataTable</returns>
        public DataTable GetLakeStage(string sTimeType, string sBeginDate, string sEndDate, string sRSC, short sSource, short sJudge, string sPoint,
            string sRIStdName, short sRIStdLevel, string sLIStdName, short sLIStdLevel, string sItem, string cDecCarry, short sFromHour, string sTatName, short sTatType, short sReportFlag)
        {
            try
            {
                usp_tblEQIW_L_Report_LakeStageForGIS uspAnalyseData = new usp_tblEQIW_L_Report_LakeStageForGIS();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.fldLSCode = sPoint;
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
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_L_Report", "GetDataStatReport", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_L_Report", "GetDataStatReport", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_L_Report", "GetDataStatReport", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }

        #endregion
    }
}
