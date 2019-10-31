using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 账户流水列表
    /// </summary>
    public class AccountflowController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得流水列表
        /// 创建  人：周文卿
        /// 创建时间：2018-12-26
        /// </summary>
        /// 
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetAccountflowlist(parm reparm)
        {
            string result = string.Empty;
            try
            {
              
                int count = 0;
                string where = parwhere(reparm);
            
                DataTable dt = rule.getpaging("vwAccountflow", "*", "1=1" + where, reparm.page, reparm.limit, reparm.sort, out count);

                getdata getdata = new getdata();
                getdata.Table = dt;
                getdata.total = count;
                result = rule.JsonStr("ok", "成功", getdata);


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " Accountflow", "GetAccountflowlist", reparm.ToString());
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 
        /// </summary>
        public class parm
        {

            /// <summary>
            /// 排序字段
            /// </summary>
            public string sort { get; set; }

            /// <summary>
            /// 页数
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 每页显示数
            /// </summary>
            public int limit { get; set; }

            /// <summary>
            /// 账户编号
            /// </summary>
            public string Accountingnum { get; set; }

            /// <summary>
            /// 商户ID
            /// </summary>
            public string MerchID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string transactionType { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        public class getdata
        {
            /// <summary>
            /// 总数
            /// </summary>
            public int total { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public DataTable Table { get; set; }


        }

        /// <summary>
        /// 功能描述：拼接where条件
        /// 创建时间：2018-12-26
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        public string parwhere(parm reparm)
        {
            string where = "";
            if (!string.IsNullOrEmpty(reparm.Accountingnum))
            {
                where += " and fldAccountingnum='" + reparm.Accountingnum + "'";
            }
            if (!string.IsNullOrEmpty(reparm.MerchID))
            {
                where += " and fldMerchID='" + reparm.MerchID + "'";
            }
            if (!string.IsNullOrEmpty(reparm.transactionType))
            {
                where += " and fldTransactionType='" + reparm.transactionType + "'";
            }
            return where;
        }
    }
}
