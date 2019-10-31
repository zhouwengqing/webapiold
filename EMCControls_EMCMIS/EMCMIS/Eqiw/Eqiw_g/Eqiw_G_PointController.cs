using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqiw.Eqiw_g
{
    /// <summary>
    /// 地下水点位操作控制器
    /// </summary>
    public class Eqiw_G_PointController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获得地下水点位信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-17
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="year">结束年份</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="Level">测点级别</param>
        /// <returns>返回点位信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqiw_g_ddlRName(string year, string include, string stcode, string Level)
        {
            string result = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(year))
                {
                    result = rule.JsonStr("error", "缺少结束日期", "");
                }
                else if (string.IsNullOrEmpty(stcode))
                {
                    result = rule.JsonStr("error", "缺少城市代码", "");
                }
                else if (string.IsNullOrEmpty(Level))
                {
                    result = rule.JsonStr("error", "缺少断面级别", "");
                }
                else
                {
                    RuletblEQIW_G_Section rule_section = new RuletblEQIW_G_Section();
                    IList<tblEQIW_G_Section> list = rule_section.GetRCodeBySTCode(stcode, year, Level, include);
                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有点位数据", "");
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
        /// 功能描述    ：  获得地下水点位信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-17
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="year">结束年份</param>
        /// <param name="include">是否包含上级</param>
        /// <param name="stcode">城市代码</param>
        /// <param name="Level">测点级别</param>
        /// <returns>返回点位信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqiw_g_GetByYearAndLevel(string STCode, int Year, short Level)
        {
            string result = string.Empty;
            try
            {
                RuletblEQIW_G_Section rule_section = new RuletblEQIW_G_Section();
                DataTable list = rule_section.GetByYearAndLevel(STCode, Year, Level);
                if (list != null && list.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有点位数据", "");
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
