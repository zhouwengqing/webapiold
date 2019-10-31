using DDYZ.Ensis.Rule.BusinessRule.Query;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.other
{
    /// <summary>
    /// 
    /// </summary>
    public class GetReportedController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        Hashtable htView;


        /// <summary>
        /// 功能描述    ：  获得区县上报统计
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-06-04
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetSubmitDataInfo(Dt info)
        {
            string result = string.Empty;
            try
            {
                RuleQuery_Reported_Data ruleInfo = new RuleQuery_Reported_Data();
                DataTable dtPre = ruleInfo.GetSubmitDataInfo_CQ(info.fldstcode, info.fldYWType, info.fldJCType, info.fldLevel, info.fldBeginDate, info.fldEndDate, info.fldTpyeNums, info.fldSource);
                result = rule.JsonStr("ok","", dtPre);

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        Datainfo Dainfo;
        /// <summary>
        /// 功能描述    ：  获得区县上报统计
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-02-02
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetReportedDataInfo(Datainfo info)
        {
            string result = string.Empty;
            try
            {
                Dainfo = info;
                this.htView = this.GetHasView();
                string strW = this.GetStrWhere();
                string strYear = info.vtime.Substring(0, 4);
                string[] strBeginAndEndDate = this.GetBeginAndEndDate();
                string strview = this.htView[info.strView].ToString();
                string viewtype = info.strView;
                if (viewtype != "企业污染源" || viewtype != "污水处理厂")
                    strview += "_Pre";
                RuleQuery_Reported_Data ruleInfo = new RuleQuery_Reported_Data();
                DataTable dtPre = ruleInfo.GetReportedDataInfo(viewtype,
                                info.strSTCode, strview, strW, strYear, strBeginAndEndDate[0], strBeginAndEndDate[1],
                               info.timetype == "" ? 1 : Convert.ToInt32(info.timetype), int.Parse(info.factType));
                result = rule.JsonStr("ok","", dtPre);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 初始化业务类别对应的视图
        /// </summary>
        /// <returns></returns>
        private Hashtable GetHasView()
        {
            Hashtable hasT = new Hashtable();
            hasT.Add("大气监测", "vwEQIA_RPI_Basedata_query_xia");
            hasT.Add("降尘监测", "vwEQIA_RDPI_Basedata_xia");
            hasT.Add("降水监测", "vwEQIA_PPI_Basedata_xia");
            hasT.Add("三年行动降尘", "vwEQIA_D_Basedata_xia");
            hasT.Add("河流监测", "vwEQIW_R_Basedata_xia");
            hasT.Add("饮用水监测", "vwEQIW_D_Basedata_xia");
            hasT.Add("湖库监测", "vwEQIW_L_Basedata_xia");
            hasT.Add("区域噪声", "vwEQIN_A_BaseData_Query");
            hasT.Add("功能区噪声", "vwEQIN_F_BaseData_Query");
            hasT.Add("道路交通噪声", "vwEQIN_T_BaseData_Query");
            hasT.Add("鸣号监测", "vwEQIN_M_BaseData_Query");
            hasT.Add("企业污染源", "废气~vwEQIP_S_MaintainGasMonitorData_xia,废水~vwEQIP_S_MaintainWaterMonitorData_xia");
            hasT.Add("污水处理厂", "vwEQIP_W_MaintainWaterMonitorData_xia");
            hasT.Add("土壤监测", "vwEQISO_Basedata_xia");
            hasT.Add("海水监测", "vwEQIS_W_Basedata_xia");
            return hasT;
        }

        /// <summary>
        /// 得到时间过滤条件
        /// </summary>
        /// <returns></returns>
        public string GetStrWhere()
        {
            string strSql = "1=1";
            string[] temp;
            string strTime = Dainfo.vtime;
            switch (int.Parse(Dainfo.factType))
            {
                case 2://周
                    temp = strTime.Split(';');
                    temp = this.GetWeekSpan(int.Parse(temp[0].ToString()), int.Parse(temp[1].ToString()));
                    strSql = GetTimeWhere(temp[0] + ";" + temp[1]);
                    break;
                case 3://月
                    temp = strTime.Split(';');
                    strSql = GetTimeWhere(temp[0] + "-" + temp[1] + "-01" + ";" + temp[0] + "-" + temp[1] + "-" + GetLastDayInMonth(int.Parse(temp[0]), int.Parse(temp[1])));
                    break;
                case 4://季
                    temp = strTime.Split(';');
                    strSql = GetTimeWhere(temp[0] + "-" + this.GetSeaMonth(int.Parse(temp[1]), true) + ";" + temp[0] + "-" + this.GetSeaMonth(int.Parse(temp[1]), false));
                    break;
                case 0://日 
                case 1://日 
                    strSql = GetTimeWhere(strTime + ";" + strTime);
                    break;
                case 5://半年
                    temp = strTime.Split(';');
                    if (temp[1] == "0")
                        strSql = GetTimeWhere(temp[0] + "-01-01" + ";" + temp[0] + "-06-30");
                    else
                        strSql = GetTimeWhere(temp[0] + "-07-01" + ";" + temp[0] + "-12-31");
                    break;
            }
            return strSql;
        }


        /// <summary>
        /// 得到时间的where语句
        /// </summary>
        /// <returns></returns>
        public string GetTimeWhere(string strTime)
        {
            Hashtable ht = new Hashtable();
            ht.Add("TimeType", 0);
            ht.Add("Time", strTime);
            string strViewType = Dainfo.strView;
            string strtimeW = "1=1";
            switch (strViewType)
            {
                case "大气监测":
                case "降水监测":
                    QuerySql timewhere = new QuerySql();
                    strtimeW = timewhere.QueryTimeSql(ht);
                    break;
                case "降尘监测":
                case "三年行动降尘":
                    QuerySql timewhere8 = new QuerySql();
                    strtimeW = timewhere8.QueryEQIAR_RD_TimeSql(ht);
                    break;
                case "区域噪声":
                case "功能区噪声":
                case "道路交通噪声":
                case "鸣号监测":
                    EQINTQuerySql timewhere1 = new EQINTQuerySql();
                    strtimeW = timewhere1.QueryTimeSql(ht);
                    break;
                case "河流监测":
                case "饮用水监测":
                case "湖库监测":
                case "海水监测":
                    EQIWRQuerySql timewhere2 = new EQIWRQuerySql();
                    strtimeW = timewhere2.QueryTimeSql(ht);
                    break;
                case "企业污染源":
                    EQIPQuerySql timewhere3 = new EQIPQuerySql();
                    strtimeW = timewhere3.QueryTimeSql(strTime, "企业污染源");
                    break;
                case "污水处理厂":
                    EQIPQuerySql timewhere4 = new EQIPQuerySql();
                    strtimeW = timewhere4.QueryTimeSql(strTime, "污水处理厂");
                    break;
                case "固废处理厂":
                    EQIPQuerySql timewhere5 = new EQIPQuerySql();
                    strtimeW = timewhere5.QueryTimeSql(strTime, "固废处理厂");
                    break;
                case "厂界噪声":
                    EQIPQuerySql timewhere6 = new EQIPQuerySql();
                    strtimeW = timewhere6.QueryTimeSql(strTime, "厂界噪声");
                    break;
                case "土壤监测":
                    EQISOQuerySql timewhere7 = new EQISOQuerySql();
                    strtimeW = timewhere7.QueryTimeSql(ht);
                    break;


            }
            return strtimeW;
        }


        /// <summary>
        /// 功能描述    ：  根据月份取得月份的最后一天
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-11-30
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：   
        /// </summary>
        /// <param name="_year">年份</param>
        /// <param name="_month">月份</param>
        /// <returns></returns>
        private int GetLastDayInMonth(int _year, int _month)
        {
            switch (_month)
            {
                case 2:
                    if ((_year % 4 == 0 && _year % 100 != 0) || (_year % 400 == 0))
                        return 29;
                    else
                        return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                default:
                    return 0;
            }
        }


        /// <summary>
        /// 功能描述    ：  根据季度取得月份
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-06-18
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：   
        /// </summary>
        /// <param name="isea">季度</param>
        /// <param name="bStartOrEnd">开始或结束(true开始,false结束)</param>
        /// <returns></returns>
        private string GetSeaMonth(int isea, bool bStartOrEnd)
        {
            string temp = "";
            if (bStartOrEnd)
            {
                switch (isea)
                {
                    case 1:
                        temp = "01-01";
                        break;
                    case 2:
                        temp = "04-01";
                        break;
                    case 3:
                        temp = "07-01";
                        break;
                    case 4:
                        temp = "10-01";
                        break;
                }
            }
            else
            {
                switch (isea)
                {
                    case 1:
                        temp = "03-31";
                        break;
                    case 2:
                        temp = "06-30";
                        break;
                    case 3:
                        temp = "09-30";
                        break;
                    case 4:
                        temp = "12-31";
                        break;
                }
            }
            return temp;
        }

        /// <summary>
        /// 取得某年某周的时间段
        /// </summary>
        /// <param name="iYear">年</param>
        /// <param name="iWeeks">周</param>
        /// <returns></returns>
        private string[] GetWeekSpan(int iYear, int iWeeks)
        {
            string[] temp = new string[2];
            DateTime dtFirstDate = new DateTime(iYear, 1, 1);

            int iDays = (iWeeks - 1) * 7;
            dtFirstDate = dtFirstDate.AddDays(iDays);

            int iDaysOfWeek = (int)dtFirstDate.DayOfWeek;

            temp[0] = dtFirstDate.AddDays(-(iDaysOfWeek - 1)).ToString("yyyy-MM-dd");

            temp[1] = dtFirstDate.AddDays(7 - iDaysOfWeek).ToString("yyyy-MM-dd");
            return temp;
        }

        /// <summary>
        /// 得到开始日期和结束日期
        /// </summary>
        /// <returns></returns>
        public string[] GetBeginAndEndDate()
        {
            string strSql = "1=1";
            string[] temp = new string[2];
            string strTime = Dainfo.vtime;
            switch (int.Parse(Dainfo.factType))
            {
                case 2://周
                    temp = strTime.Split(';');
                    temp = this.GetWeekSpan(int.Parse(temp[0].ToString()), int.Parse(temp[1].ToString()));
                    break;
                case 3://月
                    temp = strTime.Split(';');
                    strSql = temp[0] + "-" + temp[1] + "-01" + ";" + temp[0] + "-" + temp[1] + "-" + GetLastDayInMonth(int.Parse(temp[0]), int.Parse(temp[1]));
                    temp = strSql.Split(';');
                    break;
                case 4://季
                    temp = strTime.Split(';');
                    strSql = temp[0] + "-" + this.GetSeaMonth(int.Parse(temp[1]), true) + ";" + temp[0] + "-" + this.GetSeaMonth(int.Parse(temp[1]), false);
                    temp = strSql.Split(';');
                    break;
                case 0://日 
                case 1://日 
                    temp[0] = strTime;
                    temp[1] = strTime;
                    break;
                case 5://半年
                    temp = strTime.Split(';');
                    if (temp[1] == "0")
                        strSql = temp[0] + "-01-01" + ";" + temp[0] + "-06-30";
                    else
                        strSql = temp[0] + "-07-01" + ";" + temp[0] + "-12-31";
                    temp = strSql.Split(';');
                    break;
            }
            return temp;
        }


        /// <summary>
        /// 
        /// </summary>
        public class Datainfo
        {
            /// <summary>
            /// 
            /// </summary>
            public string factType { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string strSTCode { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string strView { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string timetype { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string vtime { get; set; }
        }


        /// <summary>
        /// 
        /// </summary>
        public class Dt
        {
            /// <summary>
            /// 
            /// </summary>
            public string fldstcode { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldYWType { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldJCType { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int fldLevel { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public int fldTpyeNums { get; set; }


            /// <summary>
            /// 
            /// </summary>
            public int fldSource { get; set; }
        }

    }
}
