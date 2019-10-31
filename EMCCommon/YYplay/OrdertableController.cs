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
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 功能描述：订单表的相关API
    /// 创建时间：2018-11-21
    /// 创建  人：周文卿
    /// </summary>
    public class OrdertableController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得所有的订单
        /// 创建时间：2018-11-21
        /// 创建  人：周文卿  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetOrdertable(parm reparm)
        {
            string result = string.Empty;
            try
            {

                int count = 0;
                string where = parwhere(reparm);
                if (where == "")
                {
                    where = " and fldCreatetime>='" + DateTime.Now.ToShortDateString() + "'";
                }
                //查询分页的数据
                DataTable dt = rule.getpaging("vwOrdertable", "*", "1=1" + where, reparm.page, reparm.limit, "fldCreatetime desc", out count);

                getdata getdata = new getdata();
                getdata.Table = dt;
                getdata.total = count;

                if (dt.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "成功", getdata);
                }
                else
                {
                    result = rule.JsonStr("error", "失败", getdata);
                }

            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, "Transaction", "GetOrdertable", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：补发通知
        /// 创建时间：2019-03-06
        /// 创建  人：周文卿  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage Reissuenotice(List<tblOrdertable> ordertables)
        {
            string result = string.Empty;
            string orid = "";
            try
            {
                //循环多条订单
                for (int i = 0; i < ordertables.Count; i++)
                {
                    //获得商户的Key
                    RuleCommon rule = new RuleCommon();
                    DataTable Merchant = rule.getdt("select *  from tbleMerchant where fldMerchID='" + ordertables[i].fldMerchID + "'");

                    //获得异步通知地址
                    AsynParameterPay asynParameter = new AsynParameterPay();
                    asynParameter.Amount = ordertables[i].fldOrderAmount.ToString();
                    asynParameter.MerchantId = ordertables[i].fldMerchID;
                    asynParameter.OrderID = ordertables[i].fldOrdernum;
                    asynParameter.OrderTime = ordertables[i].fldchangstautetime.ToString();
                    asynParameter.Paystate = ordertables[i].fldStaute;
                    asynParameter.Paytype = ordertables[i].fldRateName.ToString();
                    asynParameter.ProductName = ordertables[i].fldOrederdetailed.ToString();

                    string getpram = JsonHelper.SerializeObject(asynParameter);
                    //json 转换成Dictionary
                    Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                    //排序
                    RulePayBehavior behavior = new RulePayBehavior();
                    string pxrams = behavior.AsciiDesc(valuePairs);
                    //添加key值
                    pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                    //md5加密
                    string signkey = behavior.EncryptionMd5(pxrams);

                    asynParameter.Sign = signkey;

                    //转换成json 格式
                    string prams = JsonHelper.SerializeObject(asynParameter);

                    //请求  通知
                    RulePayRequest rulePayRequest = new RulePayRequest();
                    string rest = rulePayRequest.PostUrl(ordertables[i].fldNotice.ToString(), prams);
                    if (rest == "ok")
                    {
                        result = "成功" + i + 1;
                    }
                }
                result = rule.JsonStr("ok", "成功", result);

            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " Ordertable", "Reissuenotice", "补发通知失败,失败订单号：" + orid);
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：补发通知
        /// 创建时间：2019-03-06
        /// 创建  人：周文卿  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage SGState(tblOrdertable ordertables)
        {
            string result = string.Empty;
            string orid = "";
            try
            {
                RuleOldOrdertable ruleOldOrdertable = new RuleOldOrdertable();
                bool IsSuccess = false;
                DataTable dataTable = ruleOldOrdertable.updatestate(ordertables.fldMerchID, ordertables.fldChannelnum, "支付成功", out IsSuccess,ordertables.fldOrderAmount);
                if (IsSuccess)
                {
                    //获得商户的Key
                    RuleCommon rule = new RuleCommon();
                    DataTable Merchant = rule.getdt("select *  from tbleMerchant where fldMerchID='" + ordertables.fldMerchID + "'");

                    //获得异步通知地址
                    AsynParameterPay asynParameter = new AsynParameterPay();
                    asynParameter.Amount = ordertables.fldOrderAmount.ToString();
                    asynParameter.MerchantId = ordertables.fldMerchID;
                    asynParameter.OrderID = ordertables.fldOrdernum;
                    asynParameter.OrderTime = ordertables.fldchangstautetime.ToString();
                    asynParameter.Paystate = "支付成功";
                    asynParameter.Paytype = ordertables.fldRateName.ToString();
                    asynParameter.ProductName = ordertables.fldOrederdetailed.ToString();

                    string getpram = JsonHelper.SerializeObject(asynParameter);
                    //json 转换成Dictionary
                    Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                    //排序
                    RulePayBehavior behavior = new RulePayBehavior();
                    string pxrams = behavior.AsciiDesc(valuePairs);
                    //添加key值
                    pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                    //md5加密
                    string signkey = behavior.EncryptionMd5(pxrams);

                    asynParameter.Sign = signkey;

                    //转换成json 格式
                    string prams = JsonHelper.SerializeObject(asynParameter);

                    //请求  通知
                    RulePayRequest rulePayRequest = new RulePayRequest();
                    string rest = rulePayRequest.PostUrl(ordertables.fldNotice.ToString(), prams);
                    result = rule.JsonStr("ok", "成功", "");
                }

            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " Ordertable", "Reissuenotice", "补发通知失败,失败订单号：" + orid);
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 
        /// </summary>

        /// <returns></returns>
        /// 

        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetOrdertableExcelDate(parm reparm)
        {
            try
            {
                string result = string.Empty;

                RuleExcel ruleExcel = new RuleExcel();
                string path = @"~\Excel\";
                string excname = DateTime.Now.ToString("yyyyMMddHHmmss") + "订单列表.xlsx";
                string filename = path + excname;
                var sPath = @filename;
                path = HostingEnvironment.MapPath(path);
                sPath = HostingEnvironment.MapPath(sPath); //转为绝对路径


                string where = parwhere(reparm);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string file = "fldCreatetime,fldChannelnum,fldOrdernum,fldMerchID,fldMerchName,fldOrderAmount,fldStaute,fldServiceCharge,fldRateName,fldUpstreamName,fldChannelID,fldLaunchIP";
                DataTable dt = rule.GetQueryDate("0", "vwOrdertable", "1=1" + where, file);

                List<string> colname = new List<string>();
                colname.Add("创建时间");
                colname.Add("渠道流水号");
                colname.Add("订单号");
                colname.Add("商户号");
                colname.Add("商户名");
                colname.Add("交易金额");
                colname.Add("订单状态");
                colname.Add("手续费");
                colname.Add("支付方式");
                colname.Add("渠道名称");
                colname.Add("渠道号");
                colname.Add("发起方IP");
                ruleExcel.TableToExcel(dt, sPath, colname);

                //取得当前网站的绝对路径
                var sRootePath = HostingEnvironment.MapPath(HostingEnvironment.ApplicationVirtualPath);
                //取得文件相对于网站的路径（如：TempData/abc.mdb）
                var sRelativeUri = new Uri(sRootePath, UriKind.Absolute).MakeRelativeUri(new Uri(sPath, UriKind.Absolute)).ToString();
                // 先判断是否与原路径相同，如相同则表示二者可能不在同一个磁盘上
                var sResult = (0 == string.Compare(Path.GetFullPath(sRelativeUri), Path.GetFullPath(sPath), StringComparison.OrdinalIgnoreCase))
                    ? null : $"http://{HttpContext.Current.Request.Url.Authority}/{sRelativeUri}"; //构造返回路径
                result = rule.JsonStr("ok", excname, sResult);

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "Transaction", "GetOrdertableExcelDate" +
                    "", "");
            }
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
                where += " and fldOrderAmount>=" + reparm.minOrderAmount + " and fldOrderAmount<=" + reparm.maxOrderAmount;
            }
            if (!string.IsNullOrEmpty(reparm.Orderstaute))
            {
                where += " and fldStaute='" + reparm.Orderstaute + "'";
            }
            if (!string.IsNullOrEmpty(reparm.minOrdertime) && !string.IsNullOrEmpty(reparm.maxOrdertime))
            {
                where += " and fldCreateTime>='" + reparm.minOrdertime + "'" + " and fldCreateTime<='" + reparm.maxOrdertime + "'";
            }
            if (!string.IsNullOrEmpty(reparm.channelnum))
            {
                where += " and fldChannelnum='" + reparm.channelnum + "'";
            }
            if (!string.IsNullOrEmpty(reparm.channelid))
            {
                where += " and fldChannelID='" + reparm.channelid + "'";
            }
            if (!string.IsNullOrEmpty(reparm.paymethod))
            {
                where += " and fldRateName='" + reparm.paymethod + "'";
            }
            return where;
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
            /// 
            /// </summary>
            public List<vwOrdertable> vwOrdertable { get; set; }
        }




        /// <summary>
        /// 参数
        /// </summary>
        public class parm
        {

            /// <summary>
            /// 页数
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 每页显示数
            /// </summary>
            public int limit { get; set; }

            /// <summary>
            /// 渠道流水号
            /// </summary>
            public string channelnum { get; set; }

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
            /// 商户号
            /// </summary>
            public string merchanid { get; set; }

            /// <summary>
            /// 订单状态
            /// </summary>
            public string Orderstaute { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string minOrdertime { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string maxOrdertime { get; set; }


            /// <summary>
            /// 渠道号
            /// </summary>
            public string channelid { get; set; }

            /// <summary>
            /// 支付方式
            /// </summary>
            public string paymethod { get; set; }
        }

    }
}
