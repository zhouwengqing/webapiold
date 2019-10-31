
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqin.Eqin_t
{
    /// <summary>
    /// 道路交通噪声相关操作
    /// </summary>
    public class Eqin_T_PointController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获得道路交通噪声测点信息
        /// 创建者      ：  吕荣誉
        /// 创建日期    ：  2017-7-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="Edate">结束年份</param>
        /// <param name="stcode">城市代码</param>
        /// <returns>返回区域噪声测点信息</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetEqin_T_ddlPName(string Edate, string stcode)
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
                    RuletblEQIN_T_Point rule_point = new RuletblEQIN_T_Point();
                    IList<tblEQIN_T_Point> list = rule_point.GetSTCodeByYearandCode(stcode, Convert.ToInt32(Edate));
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
