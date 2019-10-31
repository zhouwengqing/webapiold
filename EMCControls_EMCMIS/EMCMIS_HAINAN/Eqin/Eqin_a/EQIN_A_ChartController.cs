using DDYZ.Ensis.Rule.DataRule;
using EMCControls_EMCMIS.EMCMIS_HAINAN.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Eqin.Eqin_a
{
    public class EQIN_A_ChartController : ApiController
    {


        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-23
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Get_tbl_IF_EQIN_A_StatData(Get_tbl_IF_EQIN_A_StatData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            List<tbl_IF_EQIN_A_StatData> list = new List<tbl_IF_EQIN_A_StatData>();
            try
            {
                using (EntityContext db = new EntityContext())
                {
                    list = (from x in db.tbl_IF_EQIN_A_StatData
                            where x.fldDate == info.fldDate &&
                            x.fldDN == info.fldDN
                            select x).ToList();
                }

                result = rule.JsonStr("ok", "", list);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Get_tbl_IF_EQIN_A_StatData_Info
        {
            /// <summary>
            /// 时间类似“2017年”
            /// </summary>
            public string fldDate { get; set; }

            /// <summary>
            /// “昼间”、“夜间”
            /// </summary>
            public string fldDN { get; set; }
        }






    }
}
