using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Web.Http;
using DDYZ.Ensis.Rule.DataRule;
using System.Data;


namespace EMCControls_EMCMIS.EMCSIS.EQIS_W
{
    public class GetEQIS_W_DataController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：近岸海域海水水质
        /// 创建  人：周文卿
        /// 创建时间：20180913
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetEQIS_W_DataSatge(Info info)
        {
            string result = null;
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldRStandardName",info.fldRStandardName),
                    new SqlParameter("@fldRLevel",info.fldRLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@fldSourc",info.fldSourc),
                    new SqlParameter("@StatType",info.StatType)
                 };
                dt = rule.RunProcedureSIS("usp_tblEQIS_W_Report_DataAvgStage", paras.ToList(), null);
                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Info
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
            /// 数据源
            /// </summary>
            public string fldSourc { get; set; }

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
            public string fldRLevel { get; set; }

            /// <summary>
            /// 项目
            /// </summary>
            public string fldItemCode { get; set; }

            /// <summary>
            /// 平均值取值方法
            /// </summary>
            public string DecCarry { get; set; }

            /// <summary>
            /// 统计类型
            /// </summary>
            public string StatType { get; set; }

        }
    }
}
