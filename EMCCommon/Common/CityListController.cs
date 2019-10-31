
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
    /// 功能描述：加载城市下拉列表
    /// 创建者：熊瑞竹
    /// 创建日期：2017-07-06
    /// </summary>
    public class CityListController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 创建者：熊瑞竹
        /// 创建日期：2017-07-06
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <returns>返回城市列表的json格式的字符串</returns>
        ///[SupportFilter]
        [HttpGet]
        public HttpResponseMessage GetCityList()
        {
            string retstr = "";//需要返回的字符串
            try
            {
                DataTable dt = rule.getdt("select fldSTCode,fldSTName,fldAutoId,fldParentID from LAPtblFW_RegCity");
                string datastr = JsonHelper.SerializeObject(dt);
                retstr += rule.JsonStr("ok", "", datastr);
            }
            catch (Exception e)
            {
                retstr = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(retstr, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 创建者：周文卿
        /// 创建日期：2017-09-09
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <returns>根据城市代码返回城市列表的json格式的字符串</returns>
        ///[SupportFilter]
        [HttpGet]
        public HttpResponseMessage GetCityListByStcode(string STCode)
        {
            string retstr = "";//需要返回的字符串
            try
            {
                DataTable dt = rule.getdt("select fldSTCode,fldSTName,fldAutoId,fldParentID from LAPtblFW_RegCity where fldSTCode like '%" + STCode.Substring(0, 4) + "%' and fldSTCode !='" + STCode + "'");
                string datastr = JsonHelper.SerializeObject(dt);
                retstr += rule.JsonStr("ok", "", datastr);
            }
            catch (Exception e)
            {
                retstr = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(retstr, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 创建者：周文卿
        /// 创建日期：2017-09-09
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <returns>根据城市代码返回城市列表的json格式的字符串</returns>
        ///[SupportFilter]
        [HttpGet]
        public HttpResponseMessage GetCityList(string STCode)
        {
            string retstr = "";//需要返回的字符串
            try
            {
                DataTable dt = rule.getdt("select fldSTCode,fldSTName,fldAutoId,fldParentID from LAPtblFW_RegCity where fldSTCode like '" + STCode + "%' and fldParentID=2");
                retstr = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                retstr = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(retstr, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}
