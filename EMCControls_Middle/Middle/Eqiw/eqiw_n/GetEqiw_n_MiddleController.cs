using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DDYZ.Ensis.Rule.DataRule;


namespace EMCControls_Middle.Middle.Eqiw
{
    /// <summary>
    /// 功能描述：获得排污口的数据
    /// </summary>
    public class GetEqiw_n_MiddleController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：获得排污口的数据
        /// 创建  人：周文卿
        /// 创建时间：2017/12/20
        /// 
        /// </summary>
        /// <param name="concent"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage Geteqiwn_data(w_npra concent)
        {
            string result = "";
            try
            {

                DataTable dt = new DataTable();

                DataTable dt5 = rule.getreportdtw_n(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", concent.itemcode.ToString(), 3, concent.fldLSCode.ToString(),
                                                    "", 0, 3, concent.TimeType.ToString());
                retudata rt = new retudata();

                rt.Sewage = dt5;

                result = rule.JsonStr("ok", "", rt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 返回实体
        /// </summary>
        public class retudata
        {

            /// <summary>
            /// 排污口
            /// </summary>
            public DataTable Sewage { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class w_npra
        {
            /// <summary>
            /// 开始时间
            /// </summary>
            public string BeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string EndDate { get; set; }

            /// <summary>
            /// 时间类型
            /// </summary>
            public string TimeType { get; set; }

            /// <summary>
            /// 点位
            /// </summary>
            public string fldLSCode { get; set; }

            /// <summary>
            /// 因子代码
            /// </summary>
            public string itemcode { get; set; }

        }
    }
}
