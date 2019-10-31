
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：获取测点或者断面信息
    /// 创建时间：2017-06-02
    /// </summary>
    public class PointOrSectionController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  得到项目组合数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-15
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">动态类型参数包括：UserID用户ID、fldobject业务类型</param>
        /// <returns></returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage QueryItemGroup(dynamic obj)
        {
            string result = string.Empty;           
            result = rule.JsonStr("ok", "", "");
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


    }
}
