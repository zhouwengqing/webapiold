using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqia.Eqia_r
{
    /// <summary>
    /// 其它操作
    /// </summary>
    public class Eqia_R_OtherController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述    ：  根据时间类型获取不同类型的优良天数
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-04-10
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="timetype">时间类型</param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAQIDay(string timetype)
        {
            string result = string.Empty;
            try
            {
                DataTable dt = new DataTable();
                if (timetype == "month")
                {
                    dt = rule.GetMiddleData("select * from tblAQI_Moth", 0);
                }
                else
                {
                    dt = rule.GetMiddleData("select * from tblAQI_Year", 0);
                }
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }










        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-4-18
        /// 功能描述：得到空气标准表
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tblEQIA_R_ItemSTD(Get_tblEQIA_R_ItemSTD_Info info)
        {
            string result = string.Empty;
            try
            {
                using (EMCMIS.Model.EntityContext db = new EMCMIS.Model.EntityContext())
                {

                    List<EMCMIS.Model.tblEQIA_R_ItemSTD> list = new List<EMCMIS.Model.tblEQIA_R_ItemSTD>();


                    list = (from x in db.tblEQIA_R_ItemSTD
                            select x).ToList();
                    
                    if (list != null && list.Count > 0)
                    {
                        result = rule.JsonStr("ok", "", list);
                    }
                    else
                    {
                        result = rule.JsonStr("nodata", "没有数据", "");
                    }
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
        public class Get_tblEQIA_R_ItemSTD_Info
        {
        }

        
        









    }
}
