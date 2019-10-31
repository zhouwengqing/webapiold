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
    /// 功能描述：账户表的相关操作
    /// 创建时间：2018-12-10
    /// 创建  人：周文卿
    /// </summary>
    public class AccountingController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得账户表的数据
        /// 创建时间：2018-12-10
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetDataList(parm reparm)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                string where = "";
                if (!string.IsNullOrEmpty(reparm.Accountingnum))
                {
                    where += " and fldAccountingnum='" + reparm.Accountingnum + "'";
                }
                if (!string.IsNullOrEmpty(reparm.MerchID))
                {
                    where += " and fldMerchID='" + reparm.MerchID + "'";
                }
                //查询分页的数据
                DataTable dt = rule.getpaging("vwtblAccounting", "*", "1=1" + where, reparm.page, reparm.limit, reparm.sort, out count);
                getdata getdata = new getdata();
                getdata.Table = dt;
                getdata.total = count;
                result = rule.JsonStr("ok", "成功", getdata);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
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
    }
}
