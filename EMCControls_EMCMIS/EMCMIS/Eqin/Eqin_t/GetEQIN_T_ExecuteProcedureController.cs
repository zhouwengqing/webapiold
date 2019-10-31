using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqin.Eqin_t
{
    public class GetEQIN_T_ExecuteProcedureController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-19
        /// </summary>
        /// <param name="obj">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIN_T_Report_LevelStat(usp_tblEQIN_T_Report_LevelStat_Info obj)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",obj.BeginDate),
                    new SqlParameter("@EndDate",obj.EndDate),
                    new SqlParameter("@DN",obj.DN),
                    new SqlParameter("@fldSTCode",obj.fldSTCode),
                    new SqlParameter("@ReportFlag",obj.ReportFlag),
                    new SqlParameter("@intSTLevel",obj.intSTLevel)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIN_T_Report_LevelStat", paras.ToList(), "result", "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }







        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-19
        /// </summary>
        /// <param name="obj">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIN_T_Report_ValueStatCompare(usp_tblEQIN_T_Report_ValueStatCompare_Info obj)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@BeginDate",obj.BeginDate),
                    new SqlParameter("@EndDate",obj.EndDate),
                    new SqlParameter("@DN",obj.DN),
                    new SqlParameter("@fldSTCode",obj.fldSTCode),
                    new SqlParameter("@ReportFlag",obj.ReportFlag),
                    new SqlParameter("@intSTLevel",obj.intSTLevel)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIN_T_Report_ValueStatCompare", paras.ToList(), "result", "EntityContext");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }









        /// <summary>
        /// usp_tblEQIN_T_Report_LevelStat - 参数实体
        /// </summary>
        public class usp_tblEQIN_T_Report_LevelStat_Info
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }



            public string DN { get; set; }


            public string fldSTCode { get; set; }

            public int ReportFlag { get; set; }

            public int intSTLevel { get; set; }

        }







        /// <summary>
        /// usp_tblEQIN_T_Report_LevelStat - 参数实体
        /// </summary>
        public class usp_tblEQIN_T_Report_ValueStatCompare_Info
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }



            public string DN { get; set; }


            public string fldSTCode { get; set; }

            public int ReportFlag { get; set; }

            public int intSTLevel { get; set; }

        }



















    }
}
