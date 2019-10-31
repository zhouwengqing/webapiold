using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.DateRule;
using EMCCommon.Mode;
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
    /// 查询接口统一
    /// </summary>
    public class QueryServiceController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：根据商户号和商户发来的订单号 查询订单
        /// 创建时间：2019-02-24
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage QueryOrdertable(selectparm reparm)
        {
            try
            {
                string result = "";


                using (YYPlayContext context = new YYPlayContext())
                {
                    DataTable dt = rule.GetQueryDate("", "tbleMerchant", "fldMerchID='" + reparm.MerchID + "'");


                    if (dt.Rows.Count > 0)
                    {
                        //验证签名
                        notsign notsign = new notsign();
                        notsign.MerchID = reparm.MerchID;
                        notsign.OrderID = reparm.OrderID;
                        RulePayBehavior behavior = new RulePayBehavior();


                        //转换成JSON
                        string json = JsonHelper.SerializeObject(notsign);

                        //实体转字典类型
                        Dictionary<string, string> pairs = behavior.ObjectToMap(notsign, false);
                        //排序后的字段
                        string sign = behavior.AsciiDesc(pairs);
                        //加上key值 然后对比
                        sign += "key=" + dt.Rows[0]["fldSecretKey"].ToString();

                        string newsign = behavior.EncryptionMd5(sign);
                        if (newsign != reparm.Sign)
                        {
                            result = rule.JsonStr("error", "验签失败", "");
                            new InsertException(newsign, "Transaction", "GetOrdertableExcelDate", sign);
                        }
                        else
                        {
                            //查询订单表
                            DataTable table = rule.GetQueryDate("", "vwDownOrdertable", " 1=1 and MerchID='" + reparm.MerchID + "' and OrderID='" + reparm.OrderID + "'", "*");
                            if (table.Rows.Count > 0)
                            {
                                result = rule.JsonStr("ok", "查询成功", table);
                            }
                            else
                            {
                                result = rule.JsonStr("error", "查询不到这条订单，请核对订单号和商户号！", "");
                            }
                        }
                    }
                    else
                    {
                        result = rule.JsonStr("error", "商户ID不存在", "");
                    }
                }

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "Transaction", "GetOrdertableExcelDate", "");
            }
        }

        /// <summary>
        /// 功能描述：根据商户号和商户发来的订单号 查询代付
        /// 创建时间：2019-02-24
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage QuerySubtable(selectparm reparm)
        {
            try
            {
                string result = "";


                using (YYPlayContext context = new YYPlayContext())
                {
                    DataTable dt = rule.GetQueryDate("", "tbleMerchant", "fldMerchID='" + reparm.MerchID + "'");


                    if (dt.Rows.Count > 0)
                    {
                        //验证签名
                        notsign notsign = new notsign();
                        notsign.MerchID = reparm.MerchID;
                        notsign.OrderID = reparm.OrderID;
                        RulePayBehavior behavior = new RulePayBehavior();


                        //转换成JSON
                        string json = JsonHelper.SerializeObject(notsign);

                        //实体转字典类型
                        Dictionary<string, string> pairs = behavior.ObjectToMap(notsign, false);
                        //排序后的字段
                        string sign = behavior.AsciiDesc(pairs);
                        //加上key值 然后对比
                        sign += "key=" + dt.Rows[0]["fldSecretKey"].ToString();

                        string newsign = behavior.EncryptionMd5(sign);

                        if (newsign != reparm.Sign)
                        {
                            result = rule.JsonStr("erroe", "验签失败", "");
                            new InsertException(newsign, "Transaction", "QuerySubtable", sign);
                        }
                        else
                        {
                            //查询订单表
                            DataTable table = rule.GetQueryDate("", "vwDownsubtable", " 1=1 and MerchID='" + reparm.MerchID + "' and OrderID='" + reparm.OrderID+"'", "*");
                            if (table.Rows.Count > 0)
                            {
                                result = rule.JsonStr("ok", "查询成功", table);
                            }
                            else
                            {
                                result = rule.JsonStr("error", "查询不到这条订单，请核对订单号和商户号！", "");
                            }
                        }
                    }
                    else
                    {
                        result = rule.JsonStr("error", "商户ID不存在", "");
                    }
                }

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "Transaction", "GetOrdertableExcelDate", "");
            }
        }

        /// <summary>
        /// 功能描述：根据商户号和商户发来的订单号 查询余额
        /// 创建时间：2019-02-24
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage QueryBalancetable(selectparm reparm)
        {
            try
            {
                string result = "";


                using (YYPlayContext context = new YYPlayContext())
                {
                    DataTable dt = rule.GetQueryDate("", "tbleMerchant", "fldMerchID='" + reparm.MerchID + "'");


                    if (dt.Rows.Count > 0)
                    {
                        //验证签名
                        Withdraw notsign = new Withdraw();
                        notsign.MerchID = reparm.MerchID;
                        RulePayBehavior behavior = new RulePayBehavior();


                        //转换成JSON
                        string json = JsonHelper.SerializeObject(notsign);

                        //实体转字典类型
                        Dictionary<string, string> pairs = behavior.ObjectToMap(notsign, false);
                        //排序后的字段
                        string sign = behavior.AsciiDesc(pairs);
                        //加上key值 然后对比
                        sign += "key=" + dt.Rows[0]["fldSecretKey"].ToString();
                        string newsign = behavior.EncryptionMd5(sign);

                        if (newsign != reparm.Sign)
                        {
                            result = rule.JsonStr("error", "验签失败", "");
                            new InsertException(newsign, "Transaction", "QueryBalancetable", sign);
                        }
                        else
                        {
                            //查询订单表
                            DataTable table = rule.GetQueryDate("", "vwDownBalancetable", " 1=1 and MerchID='" + reparm.MerchID + "'", "*");
                            if (table.Rows.Count > 0)
                            {
                                result = rule.JsonStr("ok", "查询成功", table);
                            }
                            else
                            {
                                result = rule.JsonStr("erroe", "查询不到该账户信息，请核对商户号！", "");
                            }
                        }
                    }
                    else
                    {
                        result = rule.JsonStr("error", "商户ID不存在", "");
                    }
                }

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "Transaction", "GetOrdertableExcelDate", "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class selectparm
        {

            /// <summary>
            ///  商户ID
            /// </summary>
            public string MerchID { get; set; }

            /// <summary>
            ///  订单id
            /// </summary>
            public string OrderID { get; set; }

            /// <summary>
            /// 签名
            /// </summary>
            public string Sign { get; set; }
        }

        /// <summary>
        /// 不带sign的参数
        /// </summary>
        public class notsign
        {

            /// <summary>
            ///  商户ID
            /// </summary>
            public string MerchID { get; set; }

            /// <summary>
            ///  订单id
            /// </summary>
            public string OrderID { get; set; }


        }



        /// <summary>
        /// 余额参数
        /// </summary>
        public class Withdraw
        {

            /// <summary>
            ///  商户ID
            /// </summary>
            public string MerchID { get; set; }

        }
    }
}
