using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_D
{
    public class GetEQIW_D_ExecuteProcedureController : ApiController
    {


        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-28
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_D_Report_KHApprise(usp_tblEQIW_D_Report_KHApprise_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour),
                    new SqlParameter("@STatName",info.STatName),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@ReportFlag",info.ReportFlag)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_D_Report_KHApprise", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// usp_tblEQIW_D_Report_KHApprise - 参数实体
        /// </summary>
        public class usp_tblEQIW_D_Report_KHApprise_Info
        {
            /// <summary>
            /// 时间类型
            /// </summary>
            public string TimeType { get; set; }


            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }


            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }



            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }


            /// <summary>
            /// 手动 0，自动 1，全部 2
            /// </summary>
            public int fldSource { get; set; }


            /// <summary>
            /// 数据冲突(0 先手 1 先自,2全部)
            /// </summary>
            public int fldJudge { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldRStandardName { get; set; }


            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldRLevel { get; set; }


            /// <summary>
            /// 地下水
            /// </summary>
            public string fldLStandardName { get; set; }


            /// <summary>
            /// 湖库级别
            /// </summary>
            public int fldLLevel { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 开始小时
            /// </summary>
            public int fldFromHour { get; set; }


            /// <summary>
            /// 区域分组名称
            /// </summary>
            public string STatName { get; set; }


            /// <summary>
            /// 1按断面平级；0按区域评价
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 存储过程用途，0：报表显示；1：图形分析
            /// </summary>
            public int ReportFlag { get; set; }






        }













        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-28
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_D_Report_KHBaseData(usp_tblEQIW_D_Report_KHBaseData_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldSource",info.fldSource),
                    new SqlParameter("@fldJudge",info.fldJudge),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldLStandardName",info.fldLStandardName),
                    new SqlParameter("@fldLLevel",info.fldLLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldFromHour",info.fldFromHour),
                    new SqlParameter("@STatName",info.STatName),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@ReportFlag",info.ReportFlag)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_D_Report_KHBaseData", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// usp_tblEQIW_D_Report_KHBaseData - 参数实体
        /// </summary>
        public class usp_tblEQIW_D_Report_KHBaseData_Info
        {
            /// <summary>
            /// 时间类型
            /// </summary>
            public string TimeType { get; set; }


            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }


            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }



            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }


            /// <summary>
            /// 手动 0，自动 1，全部 2
            /// </summary>
            public int fldSource { get; set; }


            /// <summary>
            /// 数据冲突(0 先手 1 先自,2全部)
            /// </summary>
            public int fldJudge { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldRStandardName { get; set; }


            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldRLevel { get; set; }


            /// <summary>
            /// 地下水
            /// </summary>
            public string fldLStandardName { get; set; }


            /// <summary>
            /// 湖库级别
            /// </summary>
            public int fldLLevel { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }


            /// <summary>
            /// 开始小时
            /// </summary>
            public int fldFromHour { get; set; }


            /// <summary>
            /// 区域分组名称
            /// </summary>
            public string STatName { get; set; }


            /// <summary>
            /// 1按断面平级；0按区域评价
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 存储过程用途，0：报表显示；1：图形分析
            /// </summary>
            public int ReportFlag { get; set; }






        }







    }
}
