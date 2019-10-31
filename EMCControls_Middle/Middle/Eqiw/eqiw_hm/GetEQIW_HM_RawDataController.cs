using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.eqiw_hm
{
    public class GetEQIW_HM_RawDataController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：由通用存储过程来获取数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-1-2
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetRawData(Info info)
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
                    new SqlParameter("@EBeginDate",info.EBeginDate),
                    new SqlParameter("@EEndDate",info.EEndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@IsTotal",info.IsTotal),
                    new SqlParameter("@IsDetail",info.IsDetail),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@Para1ID",info.Para1ID),
                    new SqlParameter("@Para2ID",info.Para2ID)
                };

                dt = rule.RunProcedure("usp_tblEQIW_Hm_Report_Apprise", paras.ToList(), null);

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 存储过程参数实体
        /// </summary>
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
            /// 第二个时段开始时间
            /// </summary>
            public string EBeginDate { get; set; }


            /// <summary>
            /// 第二个时段结束时间
            /// </summary>
            public string EEndDate { get; set; }


            /// <summary>
            /// 水期代码
            /// </summary>
            public string fldRSC { get; set; }


            /// <summary>
            /// 测点代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 河流标准级别名称
            /// </summary>
            public string fldStandardName { get; set; }


            /// <summary>
            /// 河流级别
            /// </summary>
            public int fldLevel { get; set; }


            /// <summary>
            /// 项目id
            /// </summary>
            public string fldItemCode { get; set; }



            /// <summary>
            /// 平均值取值方法:0:四舍六入五单一、1:四舍五入、2:直接截断、5：对武汉项目特殊处理，氨氮和总磷按照有效位数修约
            /// </summary>
            public string DecCarry { get; set; }



            /// <summary>
            /// 是否统计前期数据
            /// </summary>
            public int IsPre { get; set; }



            /// <summary>
            /// 是否统计同期数据
            /// </summary>
            public int IsYear { get; set; }


            /// <summary>
            /// 是否统计平均值
            /// </summary>
            public int IsTotal { get; set; }


            /// <summary>
            /// 是否统计明细
            /// </summary>
            public int IsDetail { get; set; }


            /// <summary>
            /// 0:针对单个断面评价、1：针对空间评价
            /// </summary>
            public int AppriseID { get; set; }


            /// <summary>
            /// 0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode
            /// </summary>
            public int SpaceID { get; set; }


            /// <summary>
            /// 0:数据导出格式、1:年鉴格式、2：因子超标评价、3:断面或者河流综合评价、4：数据市站上报省站格式1
            /// 90:综合指数秩相关、91：浓度秩相关、92：达标率秩相关、93：因子污染指数秩相关、94：各类达标率秩相关
            /// </summary>
            public int STatType { get; set; }


            /// <summary>
            /// 河流均值处理，0:默认值按行政区、1：按行政区前4位处理
            /// </summary>
            public int Para1ID { get; set; }


            /// <summary>
            /// 断面属性信息，0：默认属性、1：江西增加信息
            /// </summary>
            public int Para2ID { get; set; }

        }



    }
}
