using System;
using System.Collections.Generic; 
using System.Text;
using System.Data;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIS_W_Analyse_Gis : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  取得海水的综合评价[海水水质断面（Gis）]
        /// 创建者      ：  du
        /// 创建日期    ：  2015-3-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="iYear">年</param>
        /// <param name="iPhase">期数:如果全年为0,期数分为1-4</param>
        /// <param name="STCode">城市代码</param>
        /// <param name="RSCode">点位代码</param>
        /// <param name="StandardName">标准级别名称</param>
        /// <param name="iLevel">标准级别</param>
        /// <param name="RSCode">断面代码</param>
        /// <param name="iStatType">统计类型：1-得到每个点位情况；2-区域水质类别评价</param>
        /// <param name="iSpaceID">区域类型：1-城市、2-省份、3-海域、4-海区</param>
        /// <param name="DecCarry">平均值取值方法 </param>
        /// <returns>DataTable</returns>
        public DataTable GetDataStatAnalyseGis(int iYear, int iPhase, string STCode,  string RSCode,
                                             string StandardName, short iLevel,  string ItemCode, int iStatType,int iSpaceID,string DecCarry)
        {
            try
            {
                usp_tblEQIS_W_Report_DataStat_Gis usp = new usp_tblEQIS_W_Report_DataStat_Gis();
                usp.fldYear = iYear;
                usp.fldPhase = iPhase;
                usp.fldSTCode = STCode;
                usp.fldRSCode = RSCode;
                usp.fldStandardName = StandardName;
                usp.fldLevel = iLevel;
                usp.fldItemCode = ItemCode;
                usp.fldStatType = iStatType;
                usp.fldSpaceID = iSpaceID;
                usp.DecCarry = DecCarry;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIS_W_Analyse_Gis", "GetDataStatAnalyseGis", e.Message);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIS_W_Analyse_Gis", "GetDataStatAnalyseGis", e.Message);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIS_W_Analyse_Gis", "GetDataStatAnalyseGis", e.Message);
            }
        }



        ///// <summary>
        ///// 功能描述    ：  海区评价统计表
        ///// 创建者      ：  du
        ///// 创建日期    ：  2015-03-16
        ///// 修改者      ：  
        ///// 修改日期    ：  
        ///// 修改原因    ：
        ///// </summary> 
        ///// <param name="BeginDate">开始日期</param>
        ///// <param name="DecCarry">小数点取位类型</param>
        ///// <param name="EndDate">结束日期</param>
        ///// <param name="ItemCode">项目代码</param>
        ///// <param name="LLevel">湖库标准级别</param>
        ///// <param name="LSDName">湖库标准名称</param>
        ///// <param name="RCode">河流代码</param>
        ///// <param name="RLevel">河流标准级别</param>
        ///// <param name="RSCode">断面代码</param>
        ///// <param name="RSDName">河流标准名称</param>
        ///// <param name="STCode">城市代码</param>
        ///// <param name="TimeType">时间类别（week,month,year）</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetAppriseStat(string TimeType,string SeaRegionName, string STCode,  string PCode, string BeginDate, string EndDate,
        //                                     string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode, string DecCarry)
            


        //{
        //    try
        //    {
        //        usp_tblEQIS_W_Report_AppriseStat_Gis uspAnalyseData = new usp_tblEQIS_W_Report_AppriseStat_Gis();
        //        uspAnalyseData.TimeType = TimeType;
        //        uspAnalyseData.fldSTCode = STCode;
        //        uspAnalyseData.fldSeaRegionName = SeaRegionName;
        //        uspAnalyseData.fldPCode = PCode;
        //        uspAnalyseData.BeginDate = BeginDate;
        //        uspAnalyseData.EndDate = EndDate;
        //        uspAnalyseData.fldRStandardName = RSDName;
        //        uspAnalyseData.fldRLevel = RLevel;
        //        uspAnalyseData.fldLStandardName = LSDName;
        //        uspAnalyseData.fldLLevel = LLevel;
        //        uspAnalyseData.fldItemCode = ItemCode;
        //        uspAnalyseData.DecCarry = DecCarry;
        //        DataTable tblData = uspAnalyseData.ExecDataTable();
        //        if (tblData != null)
        //            return tblData;
        //        else
        //            throw new Exception("取得记录失败，未找到对应的记录");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Analyse", "GetAppriseStat", "TimeType:" + TimeType.ToString() + "STCode:" + STCode + "PCode:" + PCode  + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Analyse", "GetAppriseStat", "TimeType:" + TimeType.ToString() + "STCode:" + STCode + "PCode:" + PCode  + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetByPKException(e.Message, "RuletblEQIW_R_Analyse", "GetAppriseStat", "TimeType:" + TimeType.ToString() + "STCode:" + STCode + "PCode:" + PCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
        //    }
        //}




        /// <summary>
        /// 功能描述    ：  取得所有的断面综合评价[河流断面（Gis）]
        /// 创建者      ：  
        /// 创建日期    ：  2012-05-24
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
        public DataTable GetAllPCodeAnalyse_Stat_Gis(string TimeType, string sRname,  string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode, string DecCarry)
        {
            try
            {
                usp_tblEQIW_R_Report_AppriseStat_Stat_Gis usp = new usp_tblEQIW_R_Report_AppriseStat_Stat_Gis();
                usp.TimeType = TimeType; 
                usp.fldSRName = sRname; 
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.fldRStandardName = RSDName;
                usp.fldRLevel = RLevel;
                usp.fldLStandardName = LSDName;
                usp.fldLLevel = LLevel;
                usp.fldItemCode = ItemCode;
                usp.DecCarry = DecCarry;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "TimeType:" + TimeType.ToString() +   "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "TimeType:" + TimeType.ToString() + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "TimeType:" + TimeType.ToString() +  "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }

    }
}
