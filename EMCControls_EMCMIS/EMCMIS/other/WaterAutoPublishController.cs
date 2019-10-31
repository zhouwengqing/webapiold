using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.other
{
    /// <summary>
    /// 水自动发布
    /// </summary>
    public class WaterAutoPublishController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  获得水自动发布数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-03-15
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：
        /// </summary>
        /// <param name="type">数据类型 1 审核的自动数据 2未审核的自动数据</param>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
        public HttpResponseMessage GetSectionData_Auto(int type,string BeginDate="",string EndDate="")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                if (type == 1)
                    dt = rule.GetWaterAutoPublish("tblEQIW_R_BaseData_Auto", BeginDate, EndDate);
                else if (type == 2)
                    dt = rule.GetWaterAutoPublish("tblEQIW_R_BaseData_Raw", BeginDate, EndDate);
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述    ：  获得水发布数据
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2018-06-12
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：
        /// </summary>     
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public HttpResponseMessage GetSectionDataGis(string BeginDate ="", string EndDate = "")
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
              
                dt = rule.GetWaterAutoPublishGis(BeginDate, EndDate);
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
