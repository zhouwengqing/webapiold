using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using System.Collections;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  对表[tblEQIA_RPI_Basedata]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIA_RPI_Basedata : BaseRule
    {
        //类别
        private string eqiType = "eqia_r";
        private string TypeName = "大气监测";







        /// <summary>
        /// 功能描述    ：  获取大气异常点位(数据没有传输完成)
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Point_ByExceptionValueForGis()
        {
            try
            {
                usp_getEQIA_R_Point_ByExceptionValueForGis uspDel = new usp_getEQIA_R_Point_ByExceptionValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByExceptionValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByExceptionValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByExceptionValueForGis", "");
            }
        }
        /// <summary>
        /// 功能描述    ：  获取大气超标点位
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Point_ByOutValueForGis()
        {
            try
            {
                usp_getEQIA_R_Point_ByOutValueForGis uspDel = new usp_getEQIA_R_Point_ByOutValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByOutValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByOutValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByOutValueForGis", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  获取大气最新检测值及超标项
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="strPcode">测点代码</param>
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Value_ByPointForGis(string strSTCode, string strPcode)
        {
            try
            {
                usp_getEQIA_R_Value_ByPointForGis uspDel = new usp_getEQIA_R_Value_ByPointForGis();
                uspDel.fldPcode = strPcode;
                uspDel.fldSTCode = strSTCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByPointForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByPointForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByPointForGis", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  取得所有测点最后的监测值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIA_R_Value_ByAllForGis uspDel = new usp_getEQIA_R_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByAllForGis", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获取臭氧(O3)的8小时滑动均值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetO3EightAVGValue()
        {
            try
            {
                usp_Eqia_RPI_Basedata_Living_GetO3EightAVGValue uspDel = new usp_Eqia_RPI_Basedata_Living_GetO3EightAVGValue();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetO3EightAVGValue", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetO3EightAVGValue", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetO3EightAVGValue", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获取24小时滑动均值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetTwentyFourAVGValue()
        {
            try
            {
                usp_Eqia_RPI_Basedata_Living_GetTwentyFourAVGValue uspDel = new usp_Eqia_RPI_Basedata_Living_GetTwentyFourAVGValue();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetTwentyFourAVGValue", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetTwentyFourAVGValue", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetTwentyFourAVGValue", "");
            }
        }



        /// <summary>
        /// 功能描述    ：  通过测点获取测点当前时间至前几天的值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-01
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <param name="strSTName">城市名称</param>
        /// <param name="strPName">测点名称</param>
        /// <param name="iDay">显示天数</param>
        /// <returns>DataTable </returns>
        public DataTable GetPointHourValue(string strSTName, string strPName, int iDay)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_Living_GetHoursValue uspDel = new usp_tblEQIA_RPI_BaseData_Living_GetHoursValue();
                uspDel.ShowStName = strSTName;
                uspDel.showPName = strPName;
                uspDel.ShowDay = iDay;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetPointHourValue", "strSTName=" + strSTName + " strPName=" + strPName + " iDay=" + iDay.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetPointHourValue", "strSTName=" + strSTName + " strPName=" + strPName + " iDay=" + iDay.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetPointHourValue", "strSTName=" + strSTName + " strPName=" + strPName + " iDay=" + iDay.ToString());
            }
        }



        /// <summary>
        /// 功能描述    ：  取得所有设置发布数据的规则数据(执行Lap数据库)
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-11-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_SetCPUDataGis(string strSQL)
        {
            try
            {
                usp_execInsert uspSql = new usp_execInsert();
                uspSql.insertsql = strSQL;
                DataTable dt = uspSql.ExecDataTable(1);
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_SetCPUDataGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_SetCPUDataGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_SetCPUDataGis", "");
            }
        }




        /// <summary>
        /// 功能描述    ：  取得所有城市和测点最后/当前小时的监测值和AQI，空气质量状况
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="strCode">城市代码</param>
        /// <returns>DataTable </returns>
        public DataTable GetRealTimeAQI_BAllForPage(string strCode)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetRealTimeAQI_Page uspDel = new usp_tblEQIA_RPI_BaseData_GetRealTimeAQI_Page();
                uspDel.fldSTCode = strCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetRealTimeAQI_BAllForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetRealTimeAQI_BAllForPage", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetRealTimeAQI_BAllForPage", "");
            }
        }
        /// <summary>
        /// 功能描述    ：  取得实时数据趋势数据AQI和浓度
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="strCode">城市代码</param>
        /// <param name="iDay">显示几天</param>
        /// <param name="sType">类别 城市/测点</param>
        /// <returns>DataTable </returns>
        public DataTable GetTrendAQIOrDensity_Page(string strCode, int iDay, string sType)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_Page uspDel = new usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_Page();
                uspDel.Day = iDay;
                uspDel.fldSTCode = strCode;
                uspDel.Type = sType;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_Page", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_Page", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_Page", "");
            }
        }



        /// <summary>
        /// 功能描述    ：  取得监测因子的均值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-08-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="type">时间类别(年,月,日)</param>
        /// <param name="iSource">数据来源(手工:0 自动:1)</param>
        /// <param name="strBeginDate">开始时间</param>
        /// <param name="strEndDate">结束时间</param>
        /// <param name="strItemCode">监测因子代码</param>
        /// <param name="strSTCode">城市代码</param>
        /// <returns>DataTable </returns>
        public DataTable GetItemAVGData(string type, string strBeginDate, string strEndDate, string strSTCode, string strItemCode, short iSource, string sReportType)
        {
            try
            {
                usp_tblEQIA_R_BaseData_GetItemAVGDataForGis uspAVGData = new usp_tblEQIA_R_BaseData_GetItemAVGDataForGis();
                uspAVGData.fldTimeType = type;
                uspAVGData.BeginDate = strBeginDate;
                uspAVGData.EndDate = strEndDate;
                uspAVGData.fldSTCode = strSTCode;
                uspAVGData.fldItemCode = strItemCode;
                uspAVGData.fldSource = iSource;
                uspAVGData.ReportType = sReportType;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + type + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode + ",sSource:" + iSource.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + type + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode + ",sSource:" + iSource.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + type + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode + ",sSource:" + iSource.ToString());
            }
        }

        /// <summary> 
        /// 功能描述    ：  取得AQI空气日报
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-09-03
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="BDate">开始时间</param>
        /// <param name="EDate">结束时间</param> 
        /// <returns>DataTable</returns>
        public DataTable GetDayAQIReport_Page(string STCode, string BDate, string EDate)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetCityDayAQI_Page uspAVGData = new usp_tblEQIA_RPI_BaseData_GetCityDayAQI_Page();
                uspAVGData.fldSTCode = STCode;
                uspAVGData.BeginDate = BDate.ToString();
                uspAVGData.EndDate = EDate.ToString();
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetDayAQIReport_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetDayAQIReport_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetDayAQIReport_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
        }


        /// <summary> 
        /// 功能描述    ：  取得AQI级别天数
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-09-23
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="BDate">开始时间</param>
        /// <param name="EDate">结束时间</param> 
        /// <param name="PCode">测点代码</param>
        /// <param name="sType">数据类别(城市/测点)</param>
        /// <returns>DataTable</returns>
        public DataTable GetCityAQIDayProportion_Page(string STCode, string PCode, string BDate, string EDate, string sType)
        {
            try
            {
                usp_tblEQIA_R_Report_CityDayData_Page uspAVGData = new usp_tblEQIA_R_Report_CityDayData_Page();
                uspAVGData.fldSTCode = STCode;
                uspAVGData.fldPCode = PCode;
                uspAVGData.BeginDate = BDate.ToString();
                uspAVGData.EndDate = EDate.ToString();
                uspAVGData.fldType = sType;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetCityAQIDayProportion_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetCityAQIDayProportion_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetCityAQIDayProportion_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  城市均值及AQI值
        /// 创建者      ：  du
        /// 创建日期    ：  2014-11-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ： 
        /// </summary>
        /// <param name="sTimeType">时间类别(月,季,年..)</param>
        /// <param name="sBeginDate">开始时间</param>
        /// <param name="sEndDate">结束时间</param>
        /// <param name="sItem">选中项目id</param>
        /// <param name="sPoint">测点</param>
        /// <param name="sIStdName">项目超标的标准名称</param>
        /// <param name="sIStdLevel">项目超标的标准级别</param>
        /// <param name="sSource">数据来源(0手工１自动 2全部)</param>
        /// <param name="sJudge">数据冲突选择（０手工１自动）</param>
        /// <param name="cDecCarry">项目数据取值方法</param>
        /// <param name="sReportFlag">存储过程用途，0：报表显示；1：图形分析</param>
        /// <param name="sSTLevel">城市级别参数1-省站；2-市站；3-区县站     </param>
        /// <param name="sFromHour">开始小时</param>
        /// <returns>DataTable</returns>
        public DataTable GetCityAvgAndAQI_Q(string sTimeType, string sBeginDate, string sEndDate, string sItem, string sPoint,
                                                    string sIStdName, short sIStdLevel, short sSource, short sJudge, string cDecCarry, short sFromHour, short sReportFlag, short sSTLevel)
        {
            try
            {
                usp_tblEQIA_R_Report_CityValue_AQIEx uspAnalyseData = new usp_tblEQIA_R_Report_CityValue_AQIEx();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sIStdName;
                uspAnalyseData.fldLevel = sIStdLevel;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                uspAnalyseData.ReportFlag = sReportFlag;
                uspAnalyseData.intSTLevel = sSTLevel;
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Report", "GetCityAvgAndAQI_Q", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_Report", "GetCityAvgAndAQI_Q", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Report", "GetCityAvgAndAQI_Q", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }
        /// <summary>
        /// 功能描述    ：  测点均值及AQI值
        /// 创建者      ：  陈友多
        /// 创建日期    ：  2014-07-16
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ： 
        /// </summary>
        /// <param name="sTimeType">时间类别(月,季,年..)</param>
        /// <param name="sBeginDate">开始时间</param>
        /// <param name="sEndDate">结束时间</param>
        /// <param name="sItem">选中项目id</param>
        /// <param name="sPoint">测点</param>
        /// <param name="sIStdName">项目超标的标准名称</param>
        /// <param name="sIStdLevel">项目超标的标准级别</param>
        /// <param name="sSource">数据来源(0手工１自动 2全部)</param>
        /// <param name="sJudge">数据冲突选择（０手工１自动）</param>
        /// <param name="cDecCarry">项目数据取值方法</param>
        /// <param name="sReportFlag">存储过程用途，0：报表显示；1：图形分析</param>
        /// <param name="sSTLevel">城市级别参数1-省站；2-市站；3-区县站     </param>
        /// <param name="sFromHour">开始小时</param>
        /// <returns>DataTable</returns>
        public DataTable GetPointAvgAndAQI(string sTimeType, string sBeginDate, string sEndDate, string sItem, string sPoint,
                                                    string sIStdName, short sIStdLevel, short sSource, short sJudge, string cDecCarry, short sFromHour, short sReportFlag, short sSTLevel)
        {
            try
            {
                usp_tblEQIA_R_Report_PointValue_AQI uspAnalyseData = new usp_tblEQIA_R_Report_PointValue_AQI();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sIStdName;
                uspAnalyseData.fldLevel = sIStdLevel;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                uspAnalyseData.ReportFlag = sReportFlag;
                uspAnalyseData.intSTLevel = sSTLevel;
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Report", "GetPointAvgAndAQI", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_Report", "GetPointAvgAndAQI", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Report", "GetPointAvgAndAQI", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }

        /// <summary> 
        /// 功能描述    ：  测点湿度，温度
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-11-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="DTime">时间</param>
        /// <param name="Pcode">测点代码</param>
        /// <param name="STCode">城市代码</param>
        /// <returns>DataTable </returns>
        public DataTable GetHumidityAndTemperature(string STCode, string Pcode, DateTime DTime)
        {
            try
            {
                usp_tblEQIA_RPI_Basedata_GetHumidityAndTemperature uspAVGData = new usp_tblEQIA_RPI_Basedata_GetHumidityAndTemperature();
                uspAVGData.fldStCode = STCode;
                uspAVGData.fldPcode = Pcode;
                uspAVGData.fldYear = DTime.Year;
                uspAVGData.fldMonth = DTime.Month;
                uspAVGData.fldDay = DTime.Day;
                uspAVGData.fldhour = DTime.Hour;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetHumidityAndTemperature", "STCode:" + STCode + ",Pcode:" + Pcode +
                    ",DTime:" + DTime.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetHumidityAndTemperature", "STCode:" + STCode + ",Pcode:" + Pcode +
                    ",DTime:" + DTime.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetHumidityAndTemperature", "STCode:" + STCode + ",Pcode:" + Pcode +
                    ",DTime:" + DTime.ToString());
            }
        }


        /// <summary>
        /// 功能描述    ：  取得实时数据趋势数据AQI和浓度
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-07-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="strCode">城市代码</param>
        /// <param name="iDay">显示几天</param>
        /// <param name="sType">类别 城市/测点</param>
        /// <returns>DataTable </returns>
        public DataTable GetTrendAQIOrDensity_GIS(string strCode, bool isTrend)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_GIS uspDel = new usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_GIS();
                uspDel.isTrend = isTrend;
                uspDel.fldSTCode = strCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_GIS", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_GIS", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_GIS", "");
            }
        }
















        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIA_RPI_Basedata]表的记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-05-13
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIA_RPI_Basedata的实体数组</param>
        /// <param name="lstCurrentData">需要更新的本城市的实体类数组</param>
        /// <param name="lstJuniorData">需要更新的下级城市的实体类数组</param>
        /// <param name="lstAud">审核未通过原因的实体类数组</param>
        /// <param name="new_CityID_Operate">更新后的操作城市ID</param>
        /// <param name="new_CityID_Submit">更新后的提交城市ID</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAllOrUpdateNoPassAll(List<tblEQIA_RPI_Basedata> lstData, List<tblEQIA_RPI_Basedata_Pre> lstCurrentData, List<tblEQIA_RPI_Basedata_Pre> lstJuniorData, List<tblEQIA_RPI_Auditing> lstAud, List<tblFW_AuditingLog> lstAudLog, string new_CityID_Operate, string new_CityID_Submit, int grade, string comment, string operID2, string submit2, string flag2)
        {
            int iRowIndex = 0;
            string dateAll = "", date = "";
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        //更新
                        for (iRowIndex = 0; iRowIndex < lstCurrentData.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RPI_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIA_RPI_Basedata_Pre_UpdateCity();
                            uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                            uspUpdate.new_fldFlag = Int16.Parse(flag2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Operate = Int32.Parse(operID2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Submit = submit2.Split(',')[iRowIndex];
                            uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("修改记录失败，未找到对应的记录");

                            date = lstCurrentData[iRowIndex].fldSYear.ToString() + lstCurrentData[iRowIndex].fldSMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstCurrentData[iRowIndex].fldSYear;
                                usp_upin.fldMonth = lstCurrentData[iRowIndex].fldSMonth;
                                usp_upin.fldDay = lstCurrentData[iRowIndex].fldSDay;
                                usp_upin.fldComment = comment;
                                int iResultUpIn = usp_upin.ExecNoQuery(conn, tran);
                                if (iResultUpIn <= 0)
                                    throw new Exception("修改或添加失败");
                            }
                            dateAll += date + ",";
                        }

                        //数据录入到原始表
                        for (iRowIndex = 0; iRowIndex < lstData.Count; iRowIndex++)
                        {
                            //if (lstData[iRowIndex].fldItemValue != -1)
                            //{
                            //把数据录入到_RAW 表中
                            usp_tblEQI_InsertByType usp_ins = new usp_tblEQI_InsertByType();
                            usp_ins.autoid = lstData[iRowIndex].fldAutoID;
                            usp_ins.type = eqiType;
                            int iResultInsertByType = usp_ins.ExecNoQuery(conn, tran);
                            if (iResultInsertByType <= 0)
                                throw new Exception("添加记录失败，未找到对应的记录");

                            //判断是否是删除数据， 把没有删除的数据录入到原始表里面去
                            usp_tblEQI_GetByType usp_get = new usp_tblEQI_GetByType();
                            usp_get.autoid = lstData[iRowIndex].fldAutoID;
                            usp_get.type = eqiType;
                            DataTable dt = usp_get.ExecDataTable();
                            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "0")
                            {
                                usp_tblEQIA_RPI_Basedata_Insert uspInsert = new usp_tblEQIA_RPI_Basedata_Insert();
                                uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("添加记录失败，未找到对应的记录");
                            }
                            //}
                            usp_tblEQIA_RPI_Basedata_Pre_Delete usp_pre_Delete = new usp_tblEQIA_RPI_Basedata_Pre_Delete();
                            usp_pre_Delete.fldAutoID = lstData[iRowIndex].fldAutoID;
                            int iResultdelete = usp_pre_Delete.ExecNoQuery(conn, tran);
                            if (iResultdelete <= 0)
                                throw new Exception("删除临时表记录失败，未找到对应的记录");

                            date = lstData[iRowIndex].fldSYear.ToString() + lstData[iRowIndex].fldSMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstData[iRowIndex].fldSYear;
                                usp_upin.fldMonth = lstData[iRowIndex].fldSMonth;
                                usp_upin.fldDay = lstData[iRowIndex].fldSDay;
                                usp_upin.fldComment = comment;
                                int iResultUpIn = usp_upin.ExecNoQuery(conn, tran);
                                if (iResultUpIn <= 0)
                                    throw new Exception("修改或添加失败");
                            }
                            dateAll += date + ",";

                        }






                        //数据改为本级城市审核未通过状态
                        //for (iRowIndex = 0; iRowIndex < lstCurrentData.Count; iRowIndex++)
                        //{
                        //    usp_tblEQIA_RPI_Basedata_Pre_UpdateFlag uspUpdate = new usp_tblEQIA_RPI_Basedata_Pre_UpdateFlag();
                        //    uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                        //    uspUpdate.new_fldFlag = 12;
                        //    uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                        //    int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                        //    //if (iResultInsert <= 0)
                        //        //throw new Exception("修改记录失败，未找到对应的记录");
                        //}
                        //数据改为下级城市审核未通过状态
                        for (iRowIndex = 0; iRowIndex < lstJuniorData.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RPI_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIA_RPI_Basedata_Pre_UpdateCity();
                            uspUpdate.ReceiveParameter_Old(lstJuniorData[iRowIndex]);
                            uspUpdate.new_fldCityID_Operate = Convert.ToInt32(new_CityID_Operate.Split(',')[iRowIndex]);
                            uspUpdate.new_fldCityID_Submit = new_CityID_Submit.Split(',')[iRowIndex];
                            uspUpdate.new_fldFlag = -2;
                            uspUpdate.new_fldDate_Operate = DateTime.Now;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("修改记录失败，未找到对应的记录");
                        }
                        //审核未通过原因写入数据表
                        for (iRowIndex = 0; iRowIndex < lstAud.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RPI_Auditing_Insert uspInsert = new usp_tblEQIA_RPI_Auditing_Insert();
                            uspInsert.ReceiveParameter(lstAud[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery();
                            if (iResultInsert <= 0)
                                throw new Exception("添加审核未通过原因失败，未找到对应的记录");
                        }
                        //审批操作记录保存到审核日志
                        for (iRowIndex = 0; iRowIndex < lstAudLog.Count; iRowIndex++)
                        {
                            usp_tblFW_AuditingLog_Insert uspInsert = new usp_tblFW_AuditingLog_Insert();
                            uspInsert.ReceiveParameter(lstAudLog[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery();
                            if (iResultInsert <= 0)
                                throw new Exception("添加审核日志未通过原因失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (lstData[iRowIndex].fldErrorRowIndex) + "，错误原因：同一测点同一时间同一项目的数据已经存在",
                            "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                }
            }
        }





















    }
}
