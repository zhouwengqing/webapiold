using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqia.Eqia_p
{
    public class GetEQIA_P_ExecuteProcedureController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-12
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIA_P_Report_CityRHBalance(usp_tblEQIA_P_Report_CityRHBalance_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@fldPCode",info.fldPCode),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@pHStand",info.pHStand),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@ReportFlag",info.ReportFlag),
                    new SqlParameter("@intSTLevel",info.intSTLevel)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIA_P_Report_CityRHBalance", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// usp_tblEQIA_P_Report_CityRHBalance - 参数实体
        /// </summary>
        public class usp_tblEQIA_P_Report_CityRHBalance_Info
        {

            public string BeginDate { get; set; }


            public string EndDate { get; set; }



            public string TimeType { get; set; }




            public string fldPCode { get; set; }



            public string fldItemCode { get; set; }


            public double pHStand { get; set; }


            public string DecCarry { get; set; }


            public int ReportFlag { get; set; }


            public int intSTLevel { get; set; }


        }





    }
}
