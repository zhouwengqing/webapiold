using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Lib.sql;
using System.Reflection;
using System.Text.RegularExpressions;
using DDYZ.Ensis.Presistence.DataEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json.Converters;

namespace DDYZ.Ensis.Rule.DataRule
{

    public class Report_Common
    {

        /// <summary>
        ///  获得河流通用存储过程数据
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="DecCarry">修约的方式</param>
        /// <param name="AppriseID">--0:针对单个断面评价、1：针对空间评价</param>
        /// <param name="fldItemCode">项目ID</param>
        /// <param name="fldLevel">级别</param>
        /// <param name="fldRSC">水期</param>
        /// <param name="fldRSCode">点位代码</param>
        /// <param name="fldStandardName">标准名称</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="Para1ID">-河流均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="Para2ID">--断面属性信息，0：默认属性、1,91：江西增加信息、2：湖南项目信息、3：太原、4：内蒙、5：湖北超标情况</param>
        /// <param name="SpaceID">--0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode、--5:流域+河流、6：城市+河流、7：流域+水系、8：干支流-fldRiverStream、9：河流+fldAttribute、99：全省</param>
        /// <param name="STatType">--0:数据导出格式、1:年鉴格式、2：因子超标评价、3:断面或者河流综合评价、4：数据市站上报省站格式1  --90:综合指数秩相关、91：浓度秩相关、92：达标率秩相关、93：因子污染指数秩相关、94：各类达标率秩相关、95：各空间各级达标率数秩相关--96：平均综合指数秩相关、--97：因子断面达标率秩相关</param>
        /// <param name="TimeType">时间类型</param>
        /// <param name="IsTotal">是否求平均</param>
        /// <returns></returns>
        public DataTable getreportdt_JZS(string BeginDate, string EndDate, string DecCarry, int AppriseID, string fldItemCode, short fldLevel
                                , string fldRSC, string fldRSCode, string fldStandardName, int IsDetail, int IsPre, int IsYear, int Para1ID, int Para2ID, int Source
                                , int SpaceID, short STatType, string TimeType, int IsTotal)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIW_R_Report_Apprise usp = new usp_tblEQIW_R_Report_Apprise();
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.EBeginDate = "";
                usp.EEndDate = "";
                usp.DecCarry = DecCarry;
                usp.AppriseID = AppriseID;
                usp.fldItemCode = fldItemCode;
                usp.fldLevel = fldLevel;
                usp.fldRSC = fldRSC;
                usp.fldRSCode = fldRSCode;
                usp.fldStandardName = fldStandardName;
                usp.IsDetail = IsDetail;
                usp.IsTotal = IsTotal;
                usp.IsPre = IsPre;
                usp.IsYear = IsYear;
                usp.Para1ID = Para1ID;
                usp.Para2ID = Para2ID;
                usp.SpaceID = SpaceID;
                usp.STatType = STatType;
                usp.TimeType = TimeType;
                usp.Source = 0;
                dt = usp.ExecDataTable(3);
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }
        }


        /// <summary>
        /// 获得湖库数据通用存储过程
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>       
        /// <param name="DecCarry">平均值取值方法:0:四舍六入五单一、1:四舍五入、2:直接截断、5：对武汉项目特殊处理，氨氮和总磷按照有效位数修约</param>
        /// <param name="AppriseID">0:针对单个断面评价、1：针对空间评价</param>
        /// <param name="fldItemCode">因子代码</param>
        /// <param name="fldLevel">级别</param>
        /// <param name="fldRSC">水期</param>
        /// <param name="fldLSCode">湖库+垂线代码</param>
        /// <param name="fldStandardName">级别名称</param>
        /// <param name="IsDetail">是否统计明细  </param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="Para1ID">湖库均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="Para2ID">备用参数 </param>  
        /// <param name="STatType">1:年鉴表、2：项目超标情况表、3：综合评价表</param>
        /// <param name="TimeType">时间类型</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsTLI">是否统计富营养化指数</param>
        /// <param name="TLIType">富营养化计算时叶绿素a和透明度单位：0-mg/L,cm；1-mg/m^3,m</param>
        /// <returns></returns>
        public DataTable getreportdtlake_JZS(string BeginDate, string EndDate, string DecCarry, int AppriseID, string fldItemCode, short fldLevel
                                , string fldRSC, string fldLSCode, string fldStandardName, int IsDetail, int IsPre, int IsYear, int Para1ID, int Para2ID, int Source
                                , short STatType, string TimeType, int IsTotal, int IsTLI, int TLIType,int SpaceID)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIW_RL_Report_Apprise usp = new usp_tblEQIW_RL_Report_Apprise();
                usp.TimeType = TimeType;
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.EBeginDate = "";
                usp.EEndDate = "";
                usp.fldRSC = fldRSC;
                usp.fldRSCode = fldLSCode;
                usp.fldStandardName = fldStandardName;
                usp.fldLevel = fldLevel;
                usp.fldItemCode = fldItemCode;
                usp.DecCarry = DecCarry;
                usp.IsPre = IsPre;
                usp.IsYear = IsYear;
                usp.IsTotal = IsTotal;
                usp.IsDetail = IsDetail;
                usp.IsTLI = IsTLI;
                usp.TLIType = TLIType;
                usp.AppriseID = AppriseID;
                usp.SpaceID = SpaceID;
                usp.STatType = STatType;
                usp.Para1ID = Para1ID;
                usp.Para2ID = Para2ID;
                usp.Source = 0;
                dt = usp.ExecDataTable(3);
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }
        }

        /// <summary>
        /// 功能描述：获得排污口的数据
        /// 创建时间：2017/11/09
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="DecCarry">修约方式</param>
        /// <param name="fldItemCode">因子代码</param>
        /// <param name="fldLevel">河流级别</param>
        /// <param name="fldLSCode">测点代码</param>
        /// <param name="fldRSC">水期</param>
        /// <param name="ReportFlag">0：报表显示；1：图形分析</param>
        /// <param name="STatType">1按断面平级；0按区域评价</param>
        /// <param name="TimeType">时间类型</param>
        /// <returns></returns>

        public DataTable getreportdtw_n(string BeginDate, string EndDate, string DecCarry, string fldItemCode, short fldLevel, string fldLSCode, string fldRSC, short ReportFlag, short STatType, string TimeType)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIW_N_Report_Apprise usp = new usp_tblEQIW_N_Report_Apprise();
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.DecCarry = DecCarry;
                usp.fldItemCode = fldItemCode;
                usp.fldLevel = fldLevel;
                usp.fldLSCode = fldLSCode;
                usp.fldRSC = fldRSC;
                usp.ReportFlag = ReportFlag;
                usp.STatType = STatType;
                usp.TimeType = TimeType;
                dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }

        }
    }
}
