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
    /// 功能描述    ：  对表[tblEQIW_R_Basedata]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIW_R_Basedata : BaseRule
    {

        //类别
        private string eqiType = "eqiw_r";
        private string TypeName = "地表水监测";





        #region (备用)发布系统和GIS用

        /// <summary>
        /// 功能描述    ：  获取河流异常点位(数据没有传输完成)
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Point_ByExceptionValueForGis()
        {
            try
            {
                usp_getEQIW_R_Point_ByExceptionValueForGis uspDel = new usp_getEQIW_R_Point_ByExceptionValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByExceptionValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByExceptionValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByExceptionValueForGis", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获取水自动超标点位
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Point_ByOutValueForGis()
        {
            try
            {
                usp_getEQIW_R_Point_ByOutValueForGis uspDel = new usp_getEQIW_R_Point_ByOutValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByOutValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByOutValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByOutValueForGis", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获取水自动最新检测值及超标项
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <param name="strPcode">测点代码</param>
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Value_ByPointForGis(string strPcode)
        {
            try
            {
                usp_getEQIW_R_Value_ByPointForGis uspDel = new usp_getEQIW_R_Value_ByPointForGis();
                uspDel.fldPcode = strPcode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByPointForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Value_ByPointForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Value_ByPointForGis", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  获取水质所有点最新监测值及超标项
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>   
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIW_R_Value_ByAllForGis uspDel = new usp_getEQIW_R_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByAllForGis", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获取当前时间往前几天的小时值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-01
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>   
        /// <param name="strSTName">城市名称</param>
        /// <param name="strRName">河流名称</param>
        /// <param name="strRSName">断面名称</param>
        /// <param name="iDay">显示天数</param>
        /// <returns>DataTable </returns>
        public DataTable GetWaterHourValue(string strSTName, string strRName, string strRSName, int iDay)
        {
            try
            {
                usp_tblEQIW_R_Basedata_Living_GetWaterHourValue uspDel = new usp_tblEQIW_R_Basedata_Living_GetWaterHourValue();
                uspDel.showSTName = strSTName;
                uspDel.showRName = strRName;
                uspDel.showRSName = strRSName;
                uspDel.showDay = iDay;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strSTName=" + strSTName + " strRName=" + strRName + " strRSName=" + strRSName + " iDay=" + iDay.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strSTName=" + strSTName + " strRName=" + strRName + " strRSName=" + strRSName + " iDay=" + iDay.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strSTName=" + strSTName + " strRName=" + strRName + " strRSName=" + strRSName + " iDay=" + iDay.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  取得水质月均值\日均值\周均值(month,day,week)
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-01
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>   
        /// <param name="strAVGType">类型</param>  
        /// <returns>DataTable </returns>
        public DataTable GetDayOrMonthAvgValue(string strAVGType)
        {
            try
            {
                usp_tblEQIW_R_Basedata_Living_GetDayOrMonthAvgValue uspDel = new usp_tblEQIW_R_Basedata_Living_GetDayOrMonthAvgValue();
                uspDel.AVGType = strAVGType;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strAVGType=" + strAVGType);
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strAVGType=" + strAVGType);
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strAVGType=" + strAVGType);
            }
        }


        /// <summary>
        /// 功能描述    ：  取得水质月均值\日均值\周均值(month,day,week)
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>    
        /// <param name="strtype">类型</param>
        /// <param name="STCode">城市代码</param>
        /// <param name="RCode">河流代码</param> 
        /// <param name="RSCode">断面代码</param> 
        /// <param name="ItemCode">项目代码</param>
        /// <param name="BeginDate">开始日期</param>
        /// <param name="EndDate">结束日期</param> 
        /// <returns>DataTable </returns>
        public DataTable GetDayOrMonthAvgValue(string strtype, string STCode, string RCode, string RSCode, string ItemCode, string BeginDate, string EndDate)
        {
            try
            {
                usp_tblEQIW_R_Basedata_GetDayOrMonthAvgValue uspDel = new usp_tblEQIW_R_Basedata_GetDayOrMonthAvgValue();
                uspDel.AVGType = strtype;
                uspDel.STCode = STCode;
                uspDel.RCode = RCode;
                uspDel.RSCode = RSCode;
                uspDel.ItemCode = ItemCode;
                uspDel.BeginDate = BeginDate;
                uspDel.EndDate = EndDate;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetDayOrMonthAvgValue", "strtype=" + strtype);
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetDayOrMonthAvgValue", "strtype=" + strtype);
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetDayOrMonthAvgValue", "strtype=" + strtype);
            }
        }





        /// 功能描述    ：  获取水质实时监测数据和水质状况
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-07-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>   
        /// <param name="STCode">城市代码</param>
        /// <returns>DataTable </returns>
        public DataTable GetWaterDataAndQuality_Page(string STCode)
        {
            try
            {
                usp_tblEQIW_R_Basedata_WaterQuality_Page uspDel = new usp_tblEQIW_R_Basedata_WaterQuality_Page();
                uspDel.fldSTCode = STCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetWaterDataAndQuality_Page", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetWaterDataAndQuality_Page", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetWaterDataAndQuality_Page", "");
            }
        }

        /// 功能描述    ：  获取水质实时监测数据和水质状况
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-07-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>   
        /// <param name="IDay">显示天数</param>
        /// <param name="STCode">城市代码</param>
        /// <param name="RSCode">断面代码</param>
        /// <returns>DataTable </returns>
        public DataTable GetTrendStageOrDensity(string STCode, int IDay, string RSCode)
        {
            try
            {
                usp_tblEQIW_R_Basedata_GetTrendStageOrDensity_Page uspDel = new usp_tblEQIW_R_Basedata_GetTrendStageOrDensity_Page();
                uspDel.fldSTCode = STCode;
                uspDel.IDay = IDay;
                uspDel.fldRScode = RSCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetTrendStageOrDensity", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetTrendStageOrDensity", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetTrendStageOrDensity", "");
            }
        }



        /// <summary>
        /// 功能描述    ：  水系评价统计表[Page]
        /// 创建者      ：  zch
        /// 创建日期    ：  2013-09-07
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：
        /// </summary> 
        /// <param name="BeginDate">开始日期</param>
        /// <param name="DecCarry">小数点取位类型</param>
        /// <param name="EndDate">结束日期</param>
        /// <param name="ItemCode">项目代码</param>
        /// <param name="LLevel">湖库标准级别</param>
        /// <param name="LSDName">湖库标准名称</param>
        /// <param name="RCode">河流代码</param>
        /// <param name="RLevel">河流标准级别</param>
        /// <param name="RSCode">断面代码</param>
        /// <param name="RSDName">河流标准名称</param>
        /// <param name="STCode">城市代码</param>
        /// <param name="TimeType">时间类别（week,month,year）</param>
        /// <returns>DataTable</returns>
        public DataTable GetRiveWaterQuality(string STCode, string SRName, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_R_Report_AppriseStat_Stat_Page uspAnalyseData = new usp_tblEQIW_R_Report_AppriseStat_Stat_Page();
                uspAnalyseData.fldSTcode = STCode;
                uspAnalyseData.BeginDate = BeginDate;
                uspAnalyseData.EndDate = EndDate;
                uspAnalyseData.fldSRName = SRName;
                uspAnalyseData.fldRStandardName = RSDName;
                uspAnalyseData.fldRLevel = RLevel;
                uspAnalyseData.fldLStandardName = LSDName;
                uspAnalyseData.fldLLevel = LLevel;
                uspAnalyseData.fldItemCode = ItemCode;
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetAppriseStat", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetAppriseStat", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetAppriseStat", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }


        /// 功能描述    ：  取得干流断面的水质类别[河流断面（Page）]
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-09-06
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
        public DataTable GetSRSectionWaterQuality(string SRName, string STCode, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_R_Report_DataStat_Page usp = new usp_tblEQIW_R_Report_DataStat_Page();
                usp.fldSTCode = STCode;
                usp.fldSRName = SRName;
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.fldRStandardName = RSDName;
                usp.fldRLevel = RLevel;
                usp.fldLStandardName = LSDName;
                usp.fldLLevel = LLevel;
                usp.fldItemCode = ItemCode;
                DataTable dt = usp.ExecDataTable();
                if (dt != null)
                {
                    return dt;
                }
                else
                    throw new Exception("取得统计记录失败");

            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }


        /// 功能描述    ：  取得湖泊/水库/内湖 断面的水质类别[湖库断面（Page）]
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-09-06
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
        public DataTable GetHKSectionWaterQuality(string SRName, string STCode, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_L_Report_TLIStat_Page usp = new usp_tblEQIW_L_Report_TLIStat_Page();
                usp.fldSTCode = STCode;
                usp.fldSRName = SRName;
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.fldRStandardName = RSDName;
                usp.fldRLevel = RLevel;
                usp.fldLStandardName = LSDName;
                usp.fldLLevel = LLevel;
                usp.fldItemCode = ItemCode;
                DataTable dt = usp.ExecDataTable();
                if (dt != null)
                {
                    return dt;
                }
                else
                    throw new Exception("取得统计记录失败");

            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Analyse", "GetHKSectionWaterQuality", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIW_R_Analyse", "GetHKSectionWaterQuality", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Analyse", "GetHKSectionWaterQuality", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }

        #endregion


        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  断面综合统计
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2015-07-13
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
        /// <param name="iPara2ID">断面属性信息，0：默认属性、1：江西增加信息、2：湖南项目信息</param>
        /// <param name="iSource">数据类型</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 0, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_R_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                //uspAnalyseData.EBeginDate = sEBeginDate;
                //uspAnalyseData.EEndDate = sEEndDate;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败" + e.Message, "RuletblEQIW_R_Basedata", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:");
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
        /// <param name="sEBeginDate">第二个时段开始时间</param>
        /// <param name="sEEndDate">第二个时段结束时间</param>
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
        /// <param name="iPara2ID">断面属性信息，0：默认属性、1：江西增加信息、2：湖南项目信息</param>
        /// <param name="iSource">数据类型</param>
        /// <returns>DataTable</returns>
        public DataTable GetSpaceDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_R_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                //uspAnalyseData.EBeginDate = sEBeginDate;
                //uspAnalyseData.EEndDate = sEEndDate;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
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
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="sEBeginDate">第二个时段开始时间</param>
        /// <param name="sEEndDate">第二个时段结束时间</param>
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
        /// <param name="iPara2ID">断面属性信息，0：默认属性、1：江西增加信息、2：湖南项目信息</param>
        /// <param name="iSource">数据类型</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionForUpReport(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                // usp_tblEQIW_R_Report_DataBaseExprot uspAnalyseData = new usp_tblEQIW_R_Report_DataBaseExprot();
                usp_tblEQIW_R_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.EBeginDate = sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }
        #endregion










        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIW_R_Basedata]表的记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-12-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIW_R_Basedata的实体数组</param>
        /// <param name="lstCurrentData">需要更新的本城市的实体类数组</param>
        /// <param name="lstJuniorData">需要更新的下级城市的实体类数组</param>
        /// <param name="lstAud">审核未通过原因的实体类数组</param>
        /// <param name="new_CityID_Operate">更新后的操作城市ID</param>
        /// <param name="new_CityID_Submit">更新后的提交城市ID</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAllOrUpdateNoPassAll(List<tblEQIW_R_Basedata> lstData, List<tblEQIW_R_Basedata_Pre> lstCurrentData, List<tblEQIW_R_Basedata_Pre> lstJuniorData, List<tblEQIW_R_Auditing> lstAud, List<tblFW_AuditingLog> lstAudLog, string new_CityID_Operate, string new_CityID_Submit, int grade, string comment, string operID2, string submit2, string flag2)
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
                            usp_tblEQIW_R_Basedata_Pre_UpdateCity uspUpdate1 = new usp_tblEQIW_R_Basedata_Pre_UpdateCity();
                            uspUpdate1.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                            uspUpdate1.new_fldFlag = Int16.Parse(flag2.Split(',')[iRowIndex].ToString());
                            uspUpdate1.new_fldCityID_Operate = Int32.Parse(operID2.Split(',')[iRowIndex].ToString());
                            uspUpdate1.new_fldCityID_Submit = submit2.Split(',')[iRowIndex];
                            uspUpdate1.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                            int iResultInsert1 = uspUpdate1.ExecNoQuery(conn, tran);
                            if (iResultInsert1 <= 0)
                                throw new Exception("修改记录失败，未找到对应的记录");

                            date = lstCurrentData[iRowIndex].fldYear.ToString() + lstCurrentData[iRowIndex].fldMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstCurrentData[iRowIndex].fldYear;
                                usp_upin.fldMonth = lstCurrentData[iRowIndex].fldMonth;
                                usp_upin.fldDay = lstCurrentData[iRowIndex].fldDay;
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
                                usp_tblEQIW_R_Basedata_Insert uspInsert = new usp_tblEQIW_R_Basedata_Insert();
                                uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("添加记录失败，未找到对应的记录");
                            }
                            //}
                            usp_tblEQIW_R_Basedata_Pre_Delete usp_pre_Delete = new usp_tblEQIW_R_Basedata_Pre_Delete();
                            usp_pre_Delete.fldAutoID = lstData[iRowIndex].fldAutoID;
                            int iResultdelete = usp_pre_Delete.ExecNoQuery(conn, tran);
                            if (iResultdelete <= 0)
                                throw new Exception("删除临时表记录失败，未找到对应的记录");

                            date = lstData[iRowIndex].fldYear.ToString() + lstData[iRowIndex].fldMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstData[iRowIndex].fldYear;
                                usp_upin.fldMonth = lstData[iRowIndex].fldMonth;
                                usp_upin.fldDay = lstData[iRowIndex].fldDay;
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
                        //    usp_tblEQIW_R_Basedata_Pre_UpdateFlag uspUpdate = new usp_tblEQIW_R_Basedata_Pre_UpdateFlag();
                        //    uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                        //    uspUpdate.new_fldFlag = 12;
                        //    uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                        //    int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                        //    //if (iResultInsert <= 0)
                        //    //    throw new Exception("修改记录失败，未找到对应的记录");
                        //}
                        //数据改为下级城市审核未通过状态
                        for (iRowIndex = 0; iRowIndex < lstJuniorData.Count; iRowIndex++)
                        {
                            usp_tblEQIW_R_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIW_R_Basedata_Pre_UpdateCity();
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
                            usp_tblEQIW_R_Auditing_Insert uspInsert = new usp_tblEQIW_R_Auditing_Insert();
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
                        throw new InsertException("打开数据库连接失败", "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (lstData[iRowIndex].fldErrorRowIndex) + "，错误原因：同一测点同一时间同一项目的数据已经存在",
                            "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                }
            }
        }



        /// <summary>
        /// 功能描述：获得历史数据
        /// 创建  人：周文卿
        /// 创建时间：2018/08/14
        /// </summary>
        /// <param name="fldSTName"></param>
        /// <param name="fldRName"></param>
        /// <param name="fldRSNmae"></param>
        /// <param name="time"></param>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public DataTable GetHistory(string fldSTName, string fldRName, string fldRSNmae, string time, string itemname)
        {
            DataTable dt = new DataTable();
            try {
                usp_GetHistoryData usp = new usp_GetHistoryData();
                usp.fldSTName = fldSTName;
                usp.fldRName = fldRName;
                usp.fldRSName = fldRSNmae;
                usp.fldTime =time;
                usp.fldItemCode = itemname;
                dt=usp.ExecDataTable();
                return dt;
            }
            catch (DBQueryException e) {
                return dt;
            }
        }


    }
}
