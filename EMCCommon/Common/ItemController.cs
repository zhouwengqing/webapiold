
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
    /// 因子操作
    /// </summary>
    public class ItemController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  根据业务名称获取所有因子
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-17
        /// 修改者      ：  周文卿 
        /// 修改日期    ：  2017-07-19
        /// 修改原因    ：  添加英文业务类别的判断
        /// </summary>
        /// <param name="obj">动态类型参数包括：modeltype业务类型，typetwo,英文的业务类别</param>
        /// <returns>返回该业务所有因子信息</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage GetItemAll(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                if (Convert.ToString(obj.modeltype) != "" || Convert.ToString(obj.modeltype) != null)
                {
                    if (obj.typetwo == null)
                    {
                        DataTable dt = rule.GetItem(Convert.ToString(obj.modeltype));
                        result = rule.JsonStr("ok", "", dt);
                    }
                    else
                    {
                        DataTable dt = rule.GetItembytype(Convert.ToString(obj.typetwo));
                        result = rule.JsonStr("ok", "", dt);
                    }
                }
                else
                {
                    result = rule.JsonStr("error", "参数错误", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }










        /// <summary>
        /// 功能描述    ：  根据业务名称和因子代码获取对应因子
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-17
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="obj">动态类型参数包括：modeltype业务类型、itemcode因子代码</param>
        /// <returns>返回该业务单个因子信息</returns>
        [HttpPost]
        //[SupportFilter]
        public HttpResponseMessage GetItemSelect(dynamic obj)
        {
            string result = string.Empty;
            try
            {
                if (Convert.ToString(obj.modeltype) != "" && Convert.ToString(obj.modeltype) != null && Convert.ToString(obj.itemcode) != "" && Convert.ToString(obj.itemcode) != null)
                {
                    DataTable dt = rule.GetItem(Convert.ToString(obj.modeltype), Convert.ToString(obj.itemcode));
                    result = rule.JsonStr("ok", "", dt);
                }
                else
                {
                    result = rule.JsonStr("error", "参数错误", "");
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
