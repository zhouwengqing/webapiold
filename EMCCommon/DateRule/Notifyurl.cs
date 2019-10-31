using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 异步通知
    /// </summary>
    public class Notifyurl
    {


        /// <summary>
        /// 功能描述：支付线程
        /// </summary>
        /// <param name="MerchantId">商户ID</param>
        /// <param name="order_no">订单号</param>
        /// <param name="order_amount">金额</param>
        /// <param name="order_time">订单创建时间</param>
        /// <param name="pay_type">支付方式</param>
        /// <param name="product_name">商品描述</param>
        /// <param name="fldNotice">异步通知地址</param>
        /// <param name="key">商户key值</param>

        public static void myThread(string MerchantId, string order_no, string order_amount, string order_time, string pay_type, string product_name, string fldNotice, string key)
        {

            TimerExampleState s = new TimerExampleState();
            s.fldNotice = fldNotice;

            AsynParameterPay asyn = new AsynParameterPay();
            asyn.MerchantId = MerchantId;
            asyn.OrderID = order_no;
            asyn.Amount = order_amount;
            asyn.OrderTime = order_time;
            asyn.Paytype = pay_type;
            asyn.ProductName = product_name;
            asyn.Paystate = "支付成功";

            string getpram = JsonHelper.SerializeObject(asyn);
            //json 转换成Dictionary
            Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
            //排序
            RulePayBehavior behavior = new RulePayBehavior();
            string sign = behavior.AsciiDesc(valuePairs);
            //添加key值
            sign += "key=" + key;
            //md5加密
            string signkey = behavior.EncryptionMd5(sign);

            asyn.Sign = signkey;

            //装换成json
            s.pram = JsonHelper.SerializeObject(asyn);

            //创建代理对象TimerCallback，该代理将被定时调用
            TimerCallback timerDelegate = new TimerCallback(Request);
            //创建一个时间间隔为5m的定时器
            Timer timer = new Timer(timerDelegate, s, 5 * 60 * 1000, 5 * 60 * 1000);
            s.tmr = timer;
            //主线程停下来等待Timer对象的终止
            while (s.tmr != null)
                Thread.Sleep(1000);
        }


        /// <summary>
        /// 功能描述：代付线程
        /// </summary>
        /// <param name="MerchantId">商户ID</param>
        /// <param name="order_no">订单号</param>
        /// <param name="order_amount">金额</param>
        /// <param name="order_time">订单创建时间</param>
        /// <param name="fldNotice">异步通知地址</param>
        /// <param name="status">代付状态</param>
        /// <param name="key">商户分配的key值</param>
        public static void myThread(string MerchantId, string order_no, string order_amount, string order_time, string fldNotice, string status, string key)
        {

            TimerExampleState s = new TimerExampleState();
            s.fldNotice = fldNotice;

            AsynParameterSub asyn = new AsynParameterSub();
            asyn.MerchantId = MerchantId;
            asyn.OrderID = order_no;
            asyn.Amount = order_amount;
            asyn.OrderTime = order_time;
            asyn.Paystate = status;
            s.pram = JsonHelper.SerializeObject(asyn);


            string getpram = JsonHelper.SerializeObject(asyn);
            //json 转换成Dictionary
            Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
            //排序
            RulePayBehavior behavior = new RulePayBehavior();
            string sign = behavior.AsciiDesc(valuePairs);
            //添加key值
            sign += "key=" + key;
            //md5加密
            string signkey = behavior.EncryptionMd5(sign);

            asyn.Sign = signkey;

            s.pram = JsonHelper.SerializeObject(asyn);
            //创建代理对象TimerCallback，该代理将被定时调用
            TimerCallback timerDelegate = new TimerCallback(Request);
            //创建一个时间间隔为5m的定时器
            Timer timer = new Timer(timerDelegate, s, 5 * 60 * 1000, 5 * 60 * 1000);
            s.tmr = timer;
            //主线程停下来等待Timer对象的终止
            while (s.tmr != null)
                Thread.Sleep(1000);
        }

        /// <summary>
        /// 功能描述：定时请求
        /// 创建  人：周文卿
        /// 创建时间：2019-02-20
        /// </summary>
        /// <param name="state"></param>
        static void Request(Object state)
        {
            TimerExampleState s = (TimerExampleState)state;
            try
            {


                s.counter++;

                //拼接参数

                RulePayRequest rulePayRequest = new RulePayRequest();
                string rest = rulePayRequest.PostUrl(s.fldNotice, s.pram);
                if (rest == "ok")
                {
                    Console.WriteLine("定时器的处理");
                    s.tmr.Dispose();
                    s.tmr = null;
                }

                if (s.counter == 5)
                {

                    s.tmr.Dispose();
                    s.tmr = null;
                }
            }
            catch (Exception e)
            {
                s.tmr.Dispose();
                s.tmr = null;
                throw new InsertException(e.Message, "Transaction", "Request", s.ToString());
            }

        }

        /// <summary>
        /// 参数
        /// </summary>
        class TimerExampleState
        {
            public int counter = 0;

            public Timer tmr;

            /// <summary>
            /// 异步地址
            /// </summary>
            public string fldNotice = "";

            //支付参数
            public string pram = "";

            //代付参数
            public string subpram = "";
        }
    }
}