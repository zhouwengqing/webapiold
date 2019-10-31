using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqiw.Eqiw_sts
{
    /// <summary>
    /// 地表水专项获取点位
    /// </summary>
    public class Eqiw_STS_PointController : ApiController
    {



        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获取地表水专项河流信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="Edate">结束年份</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="Level">测点级别</param>
        /// <returns>返回测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiw_STS_River(string Edate, string include, string stcode, string Level)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(Edate))
                {
                    result = rule.JsonStr("error", "缺少结束日期", "");
                }
                else if (string.IsNullOrEmpty(stcode))
                {
                    result = rule.JsonStr("error", "缺少城市代码", "");
                }
                else if (string.IsNullOrEmpty(Level))
                {
                    result = rule.JsonStr("error", "缺少测点级别", "");
                }
                else
                {
                    RuletblEQIW_STS_Section rule_point = new RuletblEQIW_STS_Section();
                    IList<tblEQIW_STS_Section> list;

                    list = rule_point.GetRCodeBySTCodeByRole(stcode, Convert.ToInt32(Edate), short.Parse(Level), Convert.ToInt32(include), 1);



                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有测点数据", "");
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }






        /// <summary>
        /// 功能描述    ：  获取地表水专项断面信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="RCode">河流代码</param>
        /// <param name="Level">测点级别</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="year">年份</param>
        /// <returns>返回测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiw_STS_Section(string STCode, string RCode, string Level, string include, string year)
        {
            string result = string.Empty;
            try
            {
                RuletblEQIW_STS_Section rule_point = new RuletblEQIW_STS_Section();
                IList<tblEQIW_STS_Section> list;

                list = rule_point.GetRSCode(STCode, RCode, short.Parse(Level), Convert.ToInt32(include), int.Parse(year), 1);



                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有测点数据", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }













        /// <summary>
        /// 功能描述    ：  获取地表水专项断面信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="RCode">河流代码</param>
        /// <param name="Level">测点级别</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="year">年份</param>
        /// <returns>返回测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqiw_STS_GetRCodeByYear(string STCode, int Year)
        {
            string result = string.Empty;
            try
            {
                RuletblEQIW_STS_Section rule_point = new RuletblEQIW_STS_Section();
                IList<tblEQIW_STS_Section> list;

                list = rule_point.GetRCodeByYear(STCode, Year);



                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有测点数据", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



    }
}
