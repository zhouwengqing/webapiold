
using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 功能描述：项目因子监测值检查
    /// 创建时间：2017-05-27
    /// </summary>
    public  class ItemCheckController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  取得执行标准标准名称
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-05
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="modeltype">业务名称</param>
        /// <returns>返回执行标准名称执行标准名称键值</returns>
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage GetSTDName(string modeltype)
        {
            string result = string.Empty;
            try
            {
                DataTable tblData = rule.GetSTDName(modeltype);
                if (tblData.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "", tblData);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", tblData);
                }
            }
            catch(Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }          
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

    }
}
