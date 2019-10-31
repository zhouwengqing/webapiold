using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r
{
    public class Eqiw_R_ItemController : ApiController
    {




        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-3-7
        /// 功能描述：根据河流名称的集合，返回其断面数据
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_Eqiw_R_Item(Get_Eqiw_R_Section_byRSCodeAndYear_Info info)
        {
            string result = string.Empty;
            try
            {
                List<EMCMIS.Model.tblEQIW_R_Item> list = new List<EMCMIS.Model.tblEQIW_R_Item>();


                using (EMCMIS.Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblEQIW_R_Item
                            select x).ToList();
                }

                if (list != null && list.Count > 0)
                {
                    result = rule.JsonStr("ok", "", list);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 参数实体
        /// </summary>
        public class Get_Eqiw_R_Section_byRSCodeAndYear_Info
        {
        }









    }
}
