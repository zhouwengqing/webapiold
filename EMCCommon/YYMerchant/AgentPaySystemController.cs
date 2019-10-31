using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.DateRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCCommon.YYMerchant
{
    /// <summary>
    /// 功能描述：商户系统代付表
    /// 创建时间：2018-12-19
    /// 创建  人：周文卿
    /// </summary>
    public class AgentPaySystemController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：商户系统代付表
        /// 创建时间：2018-12-19
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [MerchantFiter]
        public HttpResponseMessage GetAgentPaySystem(parm reparm)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                string where = parwhere(reparm);
                //查询分页的数据
                DataSet dt = rule.getpaging("vwtblAgentPaySystem", "*", "1=1" + where, reparm.page, reparm.limit, reparm.sort, out count, "SUM(fldPayAmount) as fldPayAmount,SUM(fldSettlementAmount) as fldSettlementAmount,SUM(fldServiceCharge) as fldServiceCharge");

                getdata getdata = new getdata();
                getdata.Table = dt.Tables[0];
                getdata.SUMTable = dt.Tables[1];
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
        /// 功能描述：商户系统代付表（导出）
        /// 创建时间：2018-12-19
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [MerchantFiter]
        public HttpResponseMessage GetAgentPaySystemExcel(parm reparm)
        {
            string result = string.Empty;
            try
            {
                

                RuleExcel ruleExcel = new RuleExcel();
                string path = @"~\Excel\MerchantSysem\";
                string excname = DateTime.Now.ToString("yyyyMMddHHmmss") + "代付列表.xlsx";
                string filename = path + excname;
                var sPath = @filename;
                path = HostingEnvironment.MapPath(path);
                sPath = HostingEnvironment.MapPath(sPath); //转为绝对路径


                string where = parwhere(reparm);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string file = "fldCreatetime,fldtransactionnum,fldOrdernum,fldMerchID,fldMerchName,fldPayAmount,fldPayState,fldServiceCharge,fldchangstautetime";
                DataTable dt = rule.GetQueryDate("0", "vwtblAgentPaySystem", "1=1" + where, file);

                List<string> colname = new List<string>();
                colname.Add("订单创建时间");
                colname.Add("交易流水");
                colname.Add("订单号");
                colname.Add("商户ID");
                colname.Add("商户名称");
                colname.Add("代付金额");
                colname.Add("代付状态");
                colname.Add("手续费");
                colname.Add("状态变化时间");
                ruleExcel.TableToExcel(dt, sPath, colname);

                //取得当前网站的绝对路径
                var sRootePath = HostingEnvironment.MapPath(HostingEnvironment.ApplicationVirtualPath);
                //取得文件相对于网站的路径（如：TempData/abc.mdb）
                var sRelativeUri = new Uri(sRootePath, UriKind.Absolute).MakeRelativeUri(new Uri(sPath, UriKind.Absolute)).ToString();
                // 先判断是否与原路径相同，如相同则表示二者可能不在同一个磁盘上
                var sResult = (0 == string.Compare(Path.GetFullPath(sRelativeUri), Path.GetFullPath(sPath), StringComparison.OrdinalIgnoreCase))
                    ? null : $"http://{HttpContext.Current.Request.Url.Authority}/{sRelativeUri}"; //构造返回路径
                result = rule.JsonStr("ok", excname, sResult);

              
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "Transaction", "GetOrdertableExcelDate" +
                    "", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


       
        /// <summary>
        /// 功能描述：验证支付密码支付正确
        /// 创建时间：2018-12-20
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="paypass"></param>
        /// <param name="MerchantID"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [MerchantFiter]
        public HttpResponseMessage Ispaypass(string paypass,string MerchantID)
        {
            string result = string.Empty;
            try
            {
                using (YYPlayContext merchant = new YYPlayContext())
                {
                  
                 

                    List<tbleMerchant> tbleMerchants = (from x in merchant.tbleMerchant
                                                        where x.fldPayPass == paypass
                                                        && x.fldMerchID== MerchantID
                                                        select x).ToList(); 
                    if (tbleMerchants.Count > 0)
                    {
                        result = rule.JsonStr("ok", "成功", true);
                    }
                    else
                    {
                        result = rule.JsonStr("error", "", false);
                    }
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：拼接where条件
        /// 创建时间：2018-12-07
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        public string parwhere(parm reparm)
        {
            string where = "";

            if (!string.IsNullOrEmpty(reparm.merchanid))
            {
                where += " and fldMerchID='" + reparm.merchanid + "'";
            }
            if (!string.IsNullOrEmpty(reparm.Ordernum))
            {
                where += " and fldOrdernum='" + reparm.Ordernum + "'";
            }
            if (!string.IsNullOrEmpty(reparm.minOrderAmount) && !string.IsNullOrEmpty(reparm.maxOrderAmount))
            {
                where += " and fldPayAmount>=" + reparm.minOrderAmount + " and fldPayAmount<=" + reparm.maxOrderAmount;
            }
            if (!string.IsNullOrEmpty(reparm.State))
            {
                where += " and fldPayState='" + reparm.State + "'";
            }
            if (!string.IsNullOrEmpty(reparm.minOrdertime) && !string.IsNullOrEmpty(reparm.maxOrdertime))
            {
                where += " and fldCreateTime>='" + reparm.minOrdertime + "'" + " and fldCreateTime<='" + reparm.maxOrdertime + "'";
            }
            else
            {
                where += " and fldCreatetime>='" + DateTime.Now.ToShortDateString() + "'";
            }
            if (!string.IsNullOrEmpty(reparm.transactionnum))
            {
                where += " and fldtransactionnum='" + reparm.transactionnum + "'";
            }
            if (!string.IsNullOrEmpty(reparm.BankCardId))
            {
                where += " and fldBankCardId='" + reparm.BankCardId + "'";
            }
            return where;
        }

        /// <summary>
        /// 
        /// </summary>
        public class parm
        {
            /// <summary>
            /// 商户ID
            /// </summary>
            public string merchanid { get; set; }

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
            /// 订单号
            /// </summary>
            public string Ordernum { get; set; }

            /// <summary>
            /// 最小金额
            /// </summary>
            public string minOrderAmount { get; set; }


            /// <summary>
            /// 最大金额
            /// </summary>
            public string maxOrderAmount { get; set; }



            /// <summary>
            /// 状态
            /// </summary>
            public string State { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string minOrdertime { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string maxOrdertime { get; set; }


            /// <summary>
            /// 交易流水
            /// </summary>
            public string transactionnum { get; set; }

            /// <summary>
            /// 银行卡号
            /// </summary>
            public string BankCardId { get; set; }

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

            /// <summary>
            /// 汇总数据
            /// </summary>
            public DataTable SUMTable { get; set; }


        }
    }
}
