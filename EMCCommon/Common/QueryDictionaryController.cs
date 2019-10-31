using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Data;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Common
{
    /// <summary>
    /// 对字典表操作
    /// </summary>
    public class QueryDictionaryController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        RuletblDictionary ruleDict = new RuletblDictionary();
        /// <summary>
        /// 功能描述    ：  根据父节点的名字查询子节点数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-05
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="parentname">父节点名称</param>
        /// <returns>返回字典表数据</returns>
        [HttpGet]
        //[SupportFilter]
        public HttpResponseMessage ByParentName(string parentname)
        {
            string result = string.Empty;
            try
            {
                DataTable tblData = ruleDict.ByParentName(parentname);
                if (tblData.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "", tblData);
                }
                else
                {
                    result = rule.JsonStr("nodata", "无数据", tblData);
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
