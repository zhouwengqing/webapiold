using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiso
{
    public class GetEQISO_ExecuteProcedureController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-5-12
        /// </summary>
        /// <param name="info">参数</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQISO_Report_APIRating_GIS(Execute_usp_tblEQISO_Report_APIRating_GIS_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                List<SqlParameter> paras = new List<SqlParameter>();

                paras.Add(new SqlParameter("@BeginDate", info.BeginDate));
                paras.Add(new SqlParameter("@EndDate", info.EndDate));
                paras.Add(new SqlParameter("@fldPCode", info.fldPCode));
                paras.Add(new SqlParameter("@fldStandardName", info.fldStandardName));
                paras.Add(new SqlParameter("@fldLevel", info.fldLevel));
                paras.Add(new SqlParameter("@fldItemCode", info.fldItemCode));
                paras.Add(new SqlParameter("@DecCarry", info.DecCarry));


                dt = rule.RunProcedure_V2("usp_tblEQISO_Report_APIRating_GIS", paras.ToList(), null, "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        public class Execute_usp_tblEQISO_Report_APIRating_GIS_Info
        {
            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string fldPCode { get; set; }

            public string fldStandardName { get; set; }

            public int fldLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }
        }











    }
}
