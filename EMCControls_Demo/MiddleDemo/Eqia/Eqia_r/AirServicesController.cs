using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Eqia.Eqia_r
{

    /// <summary>
    /// 大气数据
    /// </summary>
    public class AirServicesController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        RuletblEQIA_R_Middle Middle = new RuletblEQIA_R_Middle();


        /// <summary>
        /// 功能描述    ：  根据城市代码测点类型获取相关AQI数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-19
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <param name="stcode">城市代码 全部填-1</param>
        /// <param name="stype">测点类型 '城市'|'测点'|'县市区'</param>
        /// <returns>json数据字符串</returns>
        public HttpResponseMessage GetAQIDayReport(string stcode="-1",string stype="城市")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                switch (stype)
                {
                    case "城市":
                        dt = Middle.GetCityAqiHour(stcode);
                        break;                       
                    case "测点":
                        dt = Middle.GetPointAqiHour(stcode);
                        break;
                    case "县市区":
                        dt = Middle.GetCountyAqiHour(stcode);
                        break;
                    default:
                        dt = Middle.GetCityAqiHour(stcode);
                        break;
                }
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  根据城市代码测点类型获取AQI相关数据趋势数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-19
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="iday">天数  默认一天数据</param>
        /// <param name="stype">测点类型 '城市'|'测点'</param>
        /// <param name="pcode">测点代码 默认-1取全部</param>
        /// <returns>json数据字符串</returns>
        public HttpResponseMessage GetTrendAQIOrDensity(string stcode = "-1", int iday = 1, string stype = "城市", string pcode = "-1")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                switch (stype)
                {
                    case "城市":
                        dt = Middle.GetCityAqiDayTrend(stcode, iday);
                        break;
                    case "测点":
                        dt = Middle.GetPointAqiDayTrend(stcode, iday, pcode);
                        break;
                    default:
                        dt = Middle.GetCityAqiDayTrend(stcode, iday);
                        break;
                }
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  根据城市代码测点类型获取城市日报数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-19
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ： 
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="stype">测点类型</param>
        /// <param name="pcode">测点代码</param>
        /// <param name="date">时间</param>
        /// <returns>json数据字符串</returns>
        public HttpResponseMessage GetCityOrPointAQIDayReport(string stcode = "-1", string stype = "城市", string pcode = "-1", string date = "")
        {
            if (date == "")
            {
                date = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                switch (stype)
                {
                    case "城市":
                        dt = Middle.GetcityAqiDay(stcode, date);
                        break;
                    case "测点":
                        dt = Middle.GetpointAqiDay(stcode, pcode, date);
                        break;
                    default:
                        dt = Middle.GetcityAqiDay(stcode, date);
                        break;
                }
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ：  根据城市代码测点类型获取城市日报数据(时间段)
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-19
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ： 
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="stype">测点类型</param>
        /// <param name="pcode">测点代码</param>
        /// <returns>json数据字符串</returns>
        public HttpResponseMessage GetCityOrPointAQIDayReport(string BeginDate, string EndDate, string stcode = "-1", string stype = "城市", string pcode = "-1")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                switch (stype)
                {
                    case "城市":
                        dt = Middle.GetcityAqiDay(BeginDate, EndDate, stcode);
                        break;
                    //case "测点":
                    //    dt = Middle.GetpointAqiDay(stcode, pcode, date);
                    //    break;
                    default:
                        dt = Middle.GetcityAqiDay(BeginDate, EndDate, stcode);
                        break;
                }
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述    ：  根据城市代码测点类型获取相关AQI数据(时间段)
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-10-13
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="stcode">城市代码 全部填-1</param>
        /// <param name="stype">测点类型 '城市'</param>
        /// <returns>json数据字符串</returns>
        public HttpResponseMessage GetAQIDayReport(string BeginDate, string EndDate, string stcode = "-1", string stype = "城市")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                switch (stype)
                {
                    case "城市":
                        dt = Middle.GetCityAqiHour(BeginDate, EndDate,stcode);
                        break;
                    //case "测点":
                    //    dt = Middle.GetPointAqiHour(stcode);
                    //    break;
                    //case "县市区":
                    //    dt = Middle.GetCountyAqiHour(stcode);
                    //    break;
                    default:
                        dt = Middle.GetCityAqiHour(BeginDate, EndDate, stcode);
                        break;
                }
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ：  根据城市代码时间类型获取评价结果
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-10-13
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="stcode">城市代码 全部填-1</param>
        /// <param name="timetype">时间类型 默认月统计评价</param>
        /// <returns>json数据字符串</returns>
        public HttpResponseMessage GetAirYearSeaMonthDatainfo(string BeginDate, string EndDate, string stcode = "-1", string timetype = "month")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                dt = Middle.GetAIRDatainfo(BeginDate, EndDate, stcode, timetype);
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


    }
}
