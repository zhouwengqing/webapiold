using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_l
{
    public class GetEQIW_L_ExecuteProcedureController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-16
        /// </summary>
        /// <param name="obj">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_L_Section_ForGis(usp_tblEQIW_L_Section_ForGis_Parameter obj)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@fldType",obj.fldType)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_L_Section_ForGis", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_L_Section_ForGis - 参数实体
        /// </summary>
        public class usp_tblEQIW_L_Section_ForGis_Parameter
        {
            public string fldType { get; set; }
        }





















        /// <summary>
        /// 功能描述：由存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-16
        /// </summary>
        /// <param name="obj">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Execute_usp_tblEQIW_L_Report_LakeStageForGIS(usp_tblEQIW_L_Report_LakeStageForGIS_Parameter obj)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",obj.TimeType),
                    new SqlParameter("@BeginDate",obj.BeginDate),
                    new SqlParameter("@EndDate",obj.EndDate),
                    new SqlParameter("@fldRSC",obj.fldRSC),
                    new SqlParameter("@fldSource",obj.fldSource),
                    new SqlParameter("@fldJudge",obj.fldJudge),
                    new SqlParameter("@fldLSCode",obj.fldLSCode),
                    new SqlParameter("@fldRStandardName",obj.fldRStandardName),
                    new SqlParameter("@fldRLevel",obj.fldRLevel),
                    new SqlParameter("@fldLStandardName",obj.fldLStandardName),
                    new SqlParameter("@fldLLevel",obj.fldLLevel),
                    new SqlParameter("@fldItemCode",obj.fldItemCode),
                    new SqlParameter("@DecCarry",obj.DecCarry),
                    new SqlParameter("@fldFromHour",obj.fldFromHour),
                    new SqlParameter("@STatName",obj.STatName),
                    new SqlParameter("@STatType",obj.STatType),
                    new SqlParameter("@ReportFlag",obj.ReportFlag)
                };

                dt = rule.ExecProcessPrd("usp_tblEQIW_L_Report_LakeStageForGIS", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// usp_tblEQIW_L_Report_LakeStageForGIS - 参数实体
        /// </summary>
        public class usp_tblEQIW_L_Report_LakeStageForGIS_Parameter
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
            public string fldLSCode { get; set; }


            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldRStandardName { get; set; }



            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldRLevel { get; set; }


            /// <summary>
            /// 湖库标准级别名称
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
