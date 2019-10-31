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
    public class RuletblEQIN_F_Report : BaseRule
    {
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  功能区噪声统计评价
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2015-09-23
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="PointType">点位传入方式0：fldSTCode、1：fldSTCode+'.'+fldPCode</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="iAppriseID">0:监测结果、1：达标统计情况</param>
        /// <param name="ReportType">报表类型，用于行政区划分0：省级、1：市级</param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQINFDataInfo(string sTimeType, string sBeginDate, string sEndDate, int iPointType, string sPoint,
             string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,int iAppriseID = 0,
             int iReportType = 0, short sTatType = 0)
        {
            try
            {
                usp_tblEQIN_F_Report_AppriseStat uspAnalyseData = new usp_tblEQIN_F_Report_AppriseStat();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.PointType = iPointType;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.ReportType = iReportType;
                uspAnalyseData.STatType = sTatType;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIN_F_Report", "GetEQINFDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ",PointType:" + iPointType +
                                            ",iAppriseID:" + iAppriseID + ",ReportType:" + iReportType);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIN_F_Report", "GetEQINFDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ",PointType:" + iPointType +
                                            ",iAppriseID:" + iAppriseID + ",ReportType:" + iReportType);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIN_F_Report", "GetEQINFDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ",PointType:" + iPointType +
                                            ",iAppriseID:" + iAppriseID + ",ReportType:" + iReportType);
            }
        }

        /// 功能描述    ：  功能区噪声统计评价-新
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-01-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sPoint">测点代码列表</param>
        /// <param name="PointType">点位传入方式0：fldSTCode、1：fldSTCode+'.'+fldPCode</param>
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="iSpaceID">0:监测结果、1：达标统计情况</param>
        /// <param name="ReportType">报表类型，用于行政区划分0：省级、1：市级</param>
        /// <param name="sTatType">备用参数，默认值为0，如果有特殊评价要求时使用</param>
        /// <returns>DataTable</returns>
        public DataTable GetEQINFDataInfoS(string sTimeType, string sBeginDate, string sEndDate, int iPointType, string sPoint,
             string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int iSpaceID = 0,
             int iReportType = 0, short sTatType = 0)
        {
            try
            {
                usp_tblEQIN_F_Report_AppriseStat_S uspAnalyseData = new usp_tblEQIN_F_Report_AppriseStat_S();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.PointType = iPointType;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.ReportType = iReportType;
                uspAnalyseData.STatType = sTatType;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIN_F_Report", "GetEQINFDataInfoS", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ",PointType:" + iPointType +
                                            ",iSpaceID:" + iSpaceID + ",ReportType:" + iReportType);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIN_F_Report", "GetEQINFDataInfoS", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ",PointType:" + iPointType +
                                            ",iSpaceID:" + iSpaceID + ",ReportType:" + iReportType);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIN_F_Report", "GetEQINFDataInfoS", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sPoint:" + sPoint + ",PointType:" + iPointType +
                                            ",iSpaceID:" + iSpaceID + ",ReportType:" + iReportType);
            }
        }


        #endregion
    }
}
