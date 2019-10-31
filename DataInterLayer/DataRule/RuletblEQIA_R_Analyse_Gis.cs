using System;
using System.Collections.Generic; 
using System.Text;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;

using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 用于发布Gis的数据分析类
    /// </summary>
    public class RuletblEQIA_R_Analyse_Gis : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  测点空气质量日报
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-05-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <param name="sBeginDate">开始时间</param>
        /// <param name="sEndDate">结束时间</param>
        /// <param name="sItem">选中项目id</param>
        /// <param name="sPoint">测点</param>
        /// <param name="sIStdName">项目超标的标准名称</param>
        /// <param name="sIStdLevel">项目超标的标准级别</param>
        /// <param name="sSource">数据来源(0手工１自动 2全部)</param>
        /// <param name="sJudge">数据冲突选择（０手工１自动）</param>
        /// <param name="cDecCarry">项目数据取值方法</param>
        /// <param name="sFromHour">开始小时</param> 
        /// <returns>DataTable</returns>
        /// 
        public DataTable GetAirQualityDayGis(string sBeginDate, string sEndDate, string sItem, string sPoint, string sTCode,
                                                   string sIStdName, short sIStdLevel, short sSource, short sJudge, string cDecCarry, short sFromHour)
        {
            try
            {
                usp_tblEQIA_R_Report_AirQualityDay_Gis uspAnalyseData = new usp_tblEQIA_R_Report_AirQualityDay_Gis();
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldSTCode = sTCode;
                uspAnalyseData.fldStandardName = sIStdName;
                uspAnalyseData.fldLevel = sIStdLevel;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Analyse_Gis", "GetAirQualityDay", "sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_Analyse_Gis", "GetAirQualityDay", "sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Analyse_Gis", "GetAirQualityDay", " sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }

    }
}
