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
    public class RuletblEQIW_D_Analyse_Gis : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  取得所有的水厂水质达标情况[Gis]
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-06-03
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
        /// <param name="TimeType">时间类别（month,year）</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllPCodeAnalyseGis(string TimeType, string STCode, string RCode, string RSCode, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode, string DecCarry)
        {
            try
            {
                usp_tblEQIW_D_Report_StageDataStat_Gis usp = new usp_tblEQIW_D_Report_StageDataStat_Gis();
                usp.TimeType = TimeType;
                usp.fldSTCode = STCode;
                usp.fldRCode = RCode;
                usp.fldRSCode = RSCode;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_D_Analyse", "GetAllPCodeAnalyseGis", "TimeType:" + TimeType.ToString() + "STCode:" + STCode + "RCode:" + RCode + "RSCode:" + RSCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_D_Analyse", "GetAllPCodeAnalyseGis", "TimeType:" + TimeType.ToString() + "STCode:" + STCode + "RCode:" + RCode + "RSCode:" + RSCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Analyse", "GetAllPCodeAnalyseGis", "TimeType:" + TimeType.ToString() + "STCode:" + STCode + "RCode:" + RCode + "RSCode:" + RSCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }


        /// <summary>
        /// 功能描述    ：  取得所有的水厂水质达标情况[Gis]
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-06-03
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
        public DataTable GetAllPCodeExceededRatePage(string STCode,  string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_D_BaseData_StageDataStat_Page usp = new usp_tblEQIW_D_BaseData_StageDataStat_Page(); 
                usp.fldSTCode = STCode; 
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_D_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode +  "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_D_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }

        /// <summary>
        /// 功能描述    ：  取得城市饮用水水质类别
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-09-23
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
        public DataTable GetEQIW_D_WaterQuality_Page(string STCode, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_D_BaseData_WaterQuality_Page usp = new usp_tblEQIW_D_BaseData_WaterQuality_Page();
                usp.fldSTCode = STCode;
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_D_Analyse", "GetEQIW_D_WaterQuality_Page", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_D_Analyse", "GetEQIW_D_WaterQuality_Page", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Analyse", "GetEQIW_D_WaterQuality_Page", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }
    }
}
