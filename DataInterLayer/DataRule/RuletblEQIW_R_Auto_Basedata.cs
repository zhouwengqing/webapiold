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
    /// 功能描述    ：  对表[RuletblEQIW_R_Auto_Basedata]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIW_R_Auto_Basedata : BaseRule
    {
     
        #region 通用服务用到的业务逻辑

        /// 功能描述    ：  水质自动综合统计
        /// 创建者      ：  都玉新
        /// 创建日期    ：  2016-05-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sTimeType">时间类型 </param>
        /// <param name="sBeginDate">开始日期</param>
        /// <param name="sEndDate">结束日期</param>
        /// <param name="iHour">小时</param>
        /// <param name="sRIStdName">河流标准名称</param>
        ///  <param name="sRIStdLevel">河流标准级别</param> 
        /// <param name="cDecCarry">平均值取值方法</param>
        /// <param name="iPara1ID">河流均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionAutoDataInfo(string sTimeType, string sBeginDate, string sEndDate, int iHour, 
            string sRIStdName, short sRIStdLevel, string cDecCarry="0",int iPara1ID=0)
        {
            try
            {
                usp_tblEQIW_R_Auto_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Auto_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.intHour = iHour;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.Para1ID = iPara1ID;
                DataTable tblData = uspAnalyseData.ExecDataTable(3); //连接通用报表连接
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Auto_Basedata", "GetSectionAutoDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",intHour:" + iHour.ToString() +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() );
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败"+ e.Message, "RuletblEQIW_R_Auto_Basedata", "GetSectionAutoDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",intHour:" + iHour.ToString() +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() +  ",sLIStdLevel:" 
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Auto_Basedata", "GetSectionAutoDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",intHour:" + iHour.ToString() +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" );
            }
        }
    
        #endregion
    }
}
