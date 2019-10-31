using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_DemoMiddle.Eqia.Eqia_r
{
    /// <summary>
    /// 获取大气相关经纬度信息
    /// </summary>
    public class Eqia_R_GIS_LivingController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        RuletblEQIA_R_Middle Middle = new RuletblEQIA_R_Middle();
        /// <summary>
        /// 功能描述    ：  根据城市代码获取各业务测点城市经纬度
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-08-17
        /// 修改者      ：  
        /// 修改日期    ：  
        /// 修改原因    ：  
        /// </summary>
        /// <param name="stcode">城市代码 全部填-1</param>
        /// <returns></returns>
        public HttpResponseMessage GetPointLatitudeAndLongitude(string stcode = "-1")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = Middle.GetPoint_Country_Select(stcode);
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
