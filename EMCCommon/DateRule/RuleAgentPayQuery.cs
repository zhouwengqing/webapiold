using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 代付查询
    /// </summary>
    public class RuleAgentPayQuery
    {


        /// <summary>
        /// 功能描述：代付查询
        /// </summary>
        /// <param name="MerchantId">商户ID</param>
        /// <param name="order_no">订单号</param>
        /// <param name="key">key值</param>
        /// <param name="cheanlname">渠道名称</param>
        public static void QueryAgentThend(string MerchantId, string order_no, string key, string cheanlname)
        {

            //读取参数配置Json 文件
            RuleCommon rule = new RuleCommon();
            string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/QueryAgent.json");//配置的json文件地址;
            string getjson = rule.GetJson(strLocalpath);
            //转换成JSON对象
            JArray jsonObj = JArray.Parse(getjson);
            JToken array = new JArray();
            //循环JSON 根据渠道名称 匹配对象
            for (int i = 0; i < jsonObj.Count; i++)
            {
                if (jsonObj[i]["fldGatewaynumber"].ToString() == cheanlname)
                {
                    array = jsonObj[i];
                }
            }

            //得到参数列表
            JToken childrenarray = JArray.Parse(array["parameter"].ToString());

            Dictionary<string, string> directory = new Dictionary<string, string>();

            foreach (JToken item in childrenarray[0].Children())
            {
                var JP = item as JProperty;
                string keyname = JP.Name;
                string value = JP.Value.ToString();
                //如果value分别是order_no 
                switch (value)
                {
                    case "order_no":
                        value = order_no;
                        break;
                }
                directory.Add(keyname, value);
            }


            //根据各个渠道不同的要求 处理参数
            Processingparameter processingparameter = new Processingparameter();

            string por = "";

            switch (cheanlname)
            {
                case "HT_006":
                    por = processingparameter.ProcessingHT(directory, key, "1");
                    break;
                case "QJ_004":
                    por = processingparameter.ProcessingQJ(directory, key,0);
                    break;
                case "YD_010":
                    por = processingparameter.ProcessingYDSelect(directory, key);
                    break;
                case "ZC_008":
                    por = processingparameter.ProcessingZCselect(directory, key);
                    break;
                case "HF_011":
                    por = processingparameter.ProcessingHFselect(directory, key);
                    break;
            }
            //根据requesttype 判断请求的方式 1是application/x-www-form-urlencoded 0是application/json
            TimerExampleState s = new TimerExampleState();
            //QueryRequest rulePayRequest = new QueryRequest();
            //string rest = "err";
            //rest = rulePayRequest.HttpPostZF(array["payurl"].ToString(), por, cheanlname, order_no);

            s.type = array["requesttype"].ToString();
            s.fldNotice = array["payurl"].ToString();
            s.cheanlname = cheanlname;

            s.pram = por;
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

                QueryRequest rulePayRequest = new QueryRequest();
                string rest = "err";

                switch (s.type)
                {
                    case "1":
                        rest = rulePayRequest.HttpPostZF(s.fldNotice, s.pram, s.cheanlname,s.orid);
                        break;
                    case "0":
                        rest = rulePayRequest.HttpPostJSON(s.fldNotice, s.pram, s.cheanlname);
                        break;
                }

                if (rest == "ok")
                {
                    
                    s.tmr.Dispose();
                    s.tmr = null;
                }

                if (s.counter == 6)
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

            public string cheanlname = "";

            public string orid = "";

            /// <summary>
            /// 请求地址
            /// </summary>
            public string fldNotice = "";

            //支付参数
            public string pram = "";

            //代付参数
            public string subpram = "";

            //请求方式
            public string type = "";
        }

        /// <summary>
        /// 功能描述：手工执行代付查询
        /// 创建  人：周文卿
        /// 创建时间：2019-03-21
        /// </summary>
        /// <param name="MerchantId"></param>
        /// <param name="order_no"></param>
        /// <param name="key"></param>
        /// <param name="cheanlname"></param>
        /// <returns></returns>
        public string manualQuery(string MerchantId, string order_no, string key, string cheanlname) {
            RuleCommon rule = new RuleCommon();
            string strLocalpath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/Config/QueryAgent.json");//配置的json文件地址;
            string getjson = rule.GetJson(strLocalpath);
            //转换成JSON对象
            JArray jsonObj = JArray.Parse(getjson);
            JToken array = new JArray();
            //循环JSON 根据渠道名称 匹配对象
            for (int i = 0; i < jsonObj.Count; i++)
            {
                if (jsonObj[i]["fldGatewaynumber"].ToString() == cheanlname)
                {
                    array = jsonObj[i];
                }
            }

            //得到参数列表
            JToken childrenarray = JArray.Parse(array["parameter"].ToString());

            Dictionary<string, string> directory = new Dictionary<string, string>();

            foreach (JToken item in childrenarray[0].Children())
            {
                var JP = item as JProperty;
                string keyname = JP.Name;
                string value = JP.Value.ToString();
                //如果value分别是order_no 
                switch (value)
                {
                    case "order_no":
                        value = order_no;
                        break;
                }
                directory.Add(keyname, value);
            }


            //根据各个渠道不同的要求 处理参数
            Processingparameter processingparameter = new Processingparameter();

            string por = "";

            switch (cheanlname)
            {
                case "HT_006":
                    por = processingparameter.ProcessingHT(directory, key, "1");
                    break;
                case "QJ_004":
                    por = processingparameter.ProcessingQJ(directory, key,0);
                    break;
            }
            QueryRequest rulePayRequest = new QueryRequest();
            string rest = "err";

            switch (array["requesttype"].ToString())
            {
                case "1":
                    //rest = rulePayRequest.HttpPostZF(array["payurl"].ToString(), por, cheanlname);
                    break;
                case "0":
                    rest = rulePayRequest.HttpPostJSON(array["payurl"].ToString(), por, cheanlname);
                    break;
            }
            return rest;
        }

    }
}