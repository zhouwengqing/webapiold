
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.Eqin.Eqin_f
{
    /// <summary>
    /// 噪声功能区公共api
    /// </summary>
    public class Eqin_F_CommonController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获取功能区名称
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-17
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <returns>功能区名称</returns>
        [HttpGet]
        //
        public HttpResponseMessage GetNDISCAll()
        {
            string result = string.Empty;
            try
            {
                RuletblEQIN_F_FuncCode rule_func = new RuletblEQIN_F_FuncCode();
                DataTable dt = rule_func.GetAllData();
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
