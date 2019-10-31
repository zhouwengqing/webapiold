using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Common
{
    /// <summary>
    /// 省和城市地图边界限
    /// </summary>
    public class ProvAndCityBoundGLController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        RuletblEQIA_R_Middle Middle = new RuletblEQIA_R_Middle();
        /// <summary>
        /// 功能描述    ：  根据城市代码获取省和城市地图边界限
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-18
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <param name="prcode">省代码</param>
        /// <param name="stcode">城市代码 默认-1获取该省所有城市边界线</param>
        /// <returns></returns>
        public HttpResponseMessage GetProvAndCityBoundGL(string prcode,string stcode="-1")
        {
            string result = string.Empty;
            try
            {
                Region map = new Region(prcode);
                result = rule.JsonStr("ok", "", map.getRegionItem(stcode));
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
    }
}
