
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;


namespace EMCControls_EMCMIS.eqid.eqid_d
{
    /// <summary>
    /// 功能描述：辐射点位获取
    /// 创建时间：2017/09/04
    /// 创建  人：周文卿
    /// 修改时间：
    /// 修改  人：
    /// 修改原因：
    /// </summary>
    public class Geteqid_dpointController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：辐射点位获取
        /// 创建时间：2017/09/04
        /// 创建  人：周文卿
        /// 修改时间：
        /// 修改  人：
        /// 修改原因：
        /// </summary>
        /// <param name="Edate"></param>
        /// <param name="stcode"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage Geteqid_d_ddlPName(string Edate, string stcode)
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
                    RuletblEQID_D_Point rule_point = new RuletblEQID_D_Point();
                    IList<tblEQID_D_Point> list = rule_point.GetPCodeByYear(stcode, int.Parse(Edate));
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
