using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuleQuery_Reported_Data : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  查询下级上报数据
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-06-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="itype">业务类别</param>
        /// <param name="strSTCode">城市代码</param>
        /// <param name="strView">对应的业务视图</param>
        /// <param name="strWhere">过滤时间条件</param>
        /// <param name="strYear">年份</param>
        /// <param name="strBeginTime">开始日期</param>
        /// <param name="strEndTime">结束日期</param>
        /// <param name="iQueryTime">规定上报类型</param>
        /// <param name="iTimeType">查询上报类型</param>
        /// <returns>DataTable</returns>
        /// 
        public DataTable GetReportedDataInfo(string  itype,string strSTCode,string strView,string strWhere,string strYear,string strBeginTime,string strEndTime,int iTimeType,int iQueryTime)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetReportedDataInfo uspGetDr = new usp_GetReportedDataInfo();
                uspGetDr.ViewType = itype;
                uspGetDr.STCode = strSTCode;
                uspGetDr.STypeView = strView;
                uspGetDr.strWhere = strWhere;
                uspGetDr.strYear = strYear;
                uspGetDr.strBegin = strBeginTime;
                uspGetDr.strEnd = strEndTime;
                uspGetDr.timetype = iTimeType;
                uspGetDr.querytype = iQueryTime;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleQuery_Reported_Data", "GetReportedDataInfo", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleQuery_Reported_Data", "GetReportedDataInfo", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetReportedDataInfo", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  查询市站上报统计
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-06-04
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="fldstcode">城市代码</param>
        /// <param name="fldYWType">业务类别</param>
        /// <param name="fldJCType">监测类型</param>
        /// <param name="fldLevel">控制级别</param>
        /// <param name="fldBeginDate">起始时间</param>
        /// <param name="fldEndDate">结束时间</param>
        /// <param name="fldTpyeNums">上报时间单位跨度个数</param>
        /// <param name="fldSource">数据源</param>
        /// <returns></returns>
        public DataTable GetSubmitDataInfo_CQ(string fldstcode, string fldYWType, string fldJCType,int fldLevel, string fldBeginDate,string fldEndDate, int fldTpyeNums, int fldSource)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetSubmitDataInfo_CQ uspGetDr = new usp_GetSubmitDataInfo_CQ();
                uspGetDr.strSTCode = fldstcode;
                uspGetDr.strYWType = fldYWType;
                uspGetDr.strJCType = fldJCType;
                uspGetDr.intLevel = fldLevel;
                uspGetDr.BeginDate = fldBeginDate;
                uspGetDr.EndDate = fldEndDate;
                uspGetDr.TpyeNums = fldTpyeNums;
                uspGetDr.Source = fldSource;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleQuery_Reported_Data", "GetSubmitDataInfo_CQ", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleQuery_Reported_Data", "GetSubmitDataInfo_CQ", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetSubmitDataInfo_CQ", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  查询下级上报数据
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-06-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="itype">业务类别</param>
        /// <param name="strSTCode">城市代码</param>
        /// <param name="strView">对应的业务视图</param>
        /// <param name="strWhere">过滤时间条件</param>
        /// <param name="strYear">年份</param>
        /// <param name="strBeginTime">开始日期</param>
        /// <param name="strEndTime">结束日期</param>
        /// <param name="iQueryTime">规定上报类型</param>
        /// <param name="iTimeType">查询上报类型</param>
        /// <returns>DataTable</returns>
        /// 
        public DataTable GetReportedDataInfo_basedata(string itype, string strSTCode, string strView, string strWhere, string strYear, string strBeginTime, string strEndTime, int iTimeType, int iQueryTime)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetReportedDataInfo_basedata uspGetDr = new usp_GetReportedDataInfo_basedata();
                uspGetDr.ViewType = itype;
                uspGetDr.STCode = strSTCode;
                uspGetDr.STypeView = strView;
                uspGetDr.strWhere = strWhere;
                uspGetDr.strYear = strYear;
                uspGetDr.strBegin = strBeginTime;
                uspGetDr.strEnd = strEndTime;
                uspGetDr.timetype = iTimeType;
                uspGetDr.querytype = iQueryTime;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleQuery_Reported_Data", "GetReportedDataInfo_basedata", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleQuery_Reported_Data", "GetReportedDataInfo_basedata", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetReportedDataInfo_basedata", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  得到应报测点名称和控制级别
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-07-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="itype">业务类别</param>
        /// <param name="strSTCode">城市代码</param>  
        /// <param name="strYear">年份</param>
        /// <returns>DataTable</returns>
        public DataTable GetPointNameorLevel(string itype, string strSTCode,string strYear)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetPointNameorLevel uspGetDr = new usp_GetPointNameorLevel();
                uspGetDr.type = itype;
                uspGetDr.sTCode = strSTCode; 
                uspGetDr.sYear = strYear;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleQuery_Reported_Data", "GetPointNameorLevel", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleQuery_Reported_Data", "GetPointNameorLevel", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetPointNameorLevel", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  得到实报测点名称和控制级别
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-07-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="itype">业务类别</param> 
        /// <param name="sview">视图名</param>
        /// <param name="swhere">过滤语句</param>
        /// <returns>DataTable</returns>
        public DataTable GetPointNameorLevel_shibao(string itype, string sview, string swhere)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetPointNameorLevel_shibao uspGetDr = new usp_GetPointNameorLevel_shibao();
                uspGetDr.type = itype;
                uspGetDr.sWhere = swhere;
                uspGetDr.view = sview;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "RuleQuery_Reported_Data", "GetPointNameorLevel_shibao", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleQuery_Reported_Data", "GetPointNameorLevel_shibao", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetPointNameorLevel_shibao", "");
            }
        }
    }
}
