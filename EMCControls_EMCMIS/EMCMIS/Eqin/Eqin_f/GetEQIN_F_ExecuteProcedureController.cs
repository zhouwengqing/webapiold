using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqin.Eqin_f
{
    public class GetEQIN_F_ExecuteProcedureController : ApiController
    {



        RuleCommon rule = new RuleCommon();




        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-21
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_getEQIN_F_Value_ByAllForGis()
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {

                dt = rule.ExecProcessPrd("usp_getEQIN_F_Value_ByAllForGis", null, null);






                dt.Columns.Add("fldStaLod", typeof(string));
                dt.Columns.Add("fldStaLad", typeof(string));

                DataTable dt2 = rule.getdt("select * from tblEQIN_F_Point");

                foreach (DataRow item in dt.Rows)
                {
                    foreach (DataRow item2 in dt2.Rows)
                    {
                        if
                        (
                            item["fldSTCode"].ToString() == item2["fldSTCode"].ToString() &&
                            item["fldPCode"].ToString() == item2["fldPCode"].ToString() &&
                            item["fldYear"].ToString() == item2["fldYear"].ToString()
                        )
                        {
                            item["fldStaLod"] = item2["fldStaLod"];
                            item["fldStaLad"] = item2["fldStaLad"];
                        }
                    }
                }





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
