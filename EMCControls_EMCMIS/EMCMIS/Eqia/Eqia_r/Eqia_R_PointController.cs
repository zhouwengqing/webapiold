﻿
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqia.Eqia_r
{
    /// <summary>
    /// 有关大气点位操作
    /// </summary>
    public class Eqia_R_PointController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获得大气测点信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-13
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
        public HttpResponseMessage Geteqia_r_ddlPName(string Edate, string include, string stcode, string Level)
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
                    RuletblEQIA_R_Point rule_point = new RuletblEQIA_R_Point();
                    IList<tblEQIA_R_Point> list;
                    if (Level == "-2")
                    {
                        list = rule_point.GetPCodeByYear(stcode, Convert.ToInt32(Edate));
                    }
                    else
                    {
                        list = rule_point.GetPCodeByRole(stcode, Convert.ToInt32(Edate), short.Parse(Level), Convert.ToInt32(include), 1);
                    }
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
        /// 功能描述    ：  获得大气测点信息-重金属
        /// 创建者      ：  熊瑞竹
        /// 创建日期    ：  2017-09-13
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="Edate">结束年份</param>
        /// <param name="stcode">城市代码</param>
        /// <returns>返回测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage Geteqia_r_hm_ddlPName(string Edate, string stcode)
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
                else
                {
                    RuletblEQIA_R_Point rule_point = new RuletblEQIA_R_Point();
                    IList<tblEQIA_R_Point> list;
                    list = rule_point.GetPCodeByYearHM(stcode, Convert.ToInt32(Edate));

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
    }
}
