using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RASencryption;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 处理查询返回的参数
    /// </summary>
    public class QueryRetuenResult
    {
        RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();

        /// <summary>
        /// 汇通代付查询返回的结果
        /// </summary>
        /// <returns></returns>
        public string Query_HTSUb(string result)
        {
            try
            {
                string retext = "";
                Dictionary<string, string> valuePairs = new Dictionary<string, string>();
                //先按& 转换成数组
                string[] jsontext = result.Split('&');
                RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();
                messageLog.inserttblPayfailMessageLog("亿点", "888017", "查询代付", "代付", result, DateTime.Now, result);
                for (int i = 0; i < jsontext.Length; i++)
                {
                    //在进行=的截取 获得key值很Value值
                    string[] keyvalue = jsontext[i].Split('=');
                    valuePairs.Add(keyvalue[0], keyvalue[1]);
                }
                //判断是否成功
                if (valuePairs["RspCod"].ToString() == "00000")
                {
                    string fldChannelnum = valuePairs["TxSN"].ToString();
                    RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                    DataSet alldt = ruletbl.selechannebycidsub(fldChannelnum);

                    //渠道信息表
                    DataTable dt = alldt.Tables[0];
                    //订单表
                    DataTable oerderdt = alldt.Tables[1];
                    //商户表
                    DataTable Merchant = alldt.Tables[2];
                    //判断数据库里面是否有订单号
                    if (oerderdt.Rows.Count > 0)
                    {
                        //判断状态 如果是3和4 标记为异常 不退款 由人工审核
                        if (valuePairs["Status"].ToString() == "3")
                        {
                            RuletblAgentPay ruletblAgent = new RuletblAgentPay();
                            bool IsSuccess = false;
                            ruletblAgent.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "异常", out IsSuccess);
                            if (!IsSuccess)
                            {
                                retext = "error";
                            }
                            else
                            {

                                retext = "ok";
                            }
                        }
                        //如果是1 修改状态 扣款
                        if (valuePairs["Status"].ToString() == "1" && oerderdt.Rows[0]["fldPayState"].ToString() != "代付成功")
                        {

                            RuletblAgentPay ruleOldOrdertable = new RuletblAgentPay();
                            bool IsSuccess = false;
                            DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "代付成功", out IsSuccess, decimal.Parse(valuePairs["EntrustPayAmt"].ToString()) / 100);
                            if (!IsSuccess)
                            {
                                retext = "error";
                            }
                            else
                            {

                                retext = "ok";
                            }
                        }
                        else
                        {
                            retext = "error";
                        }
                    }
                    else
                    {
                        retext = "error";
                    }
                }

                return retext;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "QueryRetuenResult", "Query_HTSUb", result);
            }


        }


        /// <summary>
        /// 万通代付查询返回的结果
        /// </summary>
        /// <returns></returns>
        public string Query_QJSUb(string result)
        {
            try
            {
                string Ownresult = "error";
                JToken rejson = JToken.Parse(result);
                messageLog.inserttblPayfailMessageLog("万通", "1550473045", "查询代付", "代付", result, DateTime.Now, result);
                string aa = rejson["status"].ToString();
                if (aa == "True")
                {
                    string statecode = rejson["resp_code"].ToString();

                    string fldChannelnum = rejson["order_no"].ToString();
                    RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                    DataSet alldt = ruletbl.selechannebycidsub(fldChannelnum);

                    //渠道信息表
                    DataTable dt = alldt.Tables[0];
                    //订单表
                    DataTable oerderdt = alldt.Tables[1];
                    //商户表
                    DataTable Merchant = alldt.Tables[2];

                    //代付失败 修改成异常状态
                    if (statecode == "F")
                    {

                        RuletblAgentPay ruletblAgent = new RuletblAgentPay();
                        bool IsSuccess = false;
                        ruletblAgent.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "异常", out IsSuccess);
                        if (!IsSuccess)
                        {
                            Ownresult = "error";
                        }
                        else
                        {

                            Ownresult = "ok";
                        }
                    }
                    //代付成功 且异步还没有通知
                    if (statecode == "S" && oerderdt.Rows[0]["fldPayState"].ToString() != "代付成功")
                    {

                        RuletblAgentPay ruleOldOrdertable = new RuletblAgentPay();
                        bool IsSuccess = false;
                        DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "代付成功", out IsSuccess, decimal.Parse(rejson["order_amount"].ToString()));
                        if (!IsSuccess)
                        {
                            Ownresult = "error";
                        }
                        else
                        {

                            Ownresult = "ok";
                        }
                    }
                    else
                    {
                        Ownresult = "ok";
                    }

                }
                return Ownresult;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "QueryRetuenResult", "Query_HTSUb", result);
            }


        }


        /// <summary>
        /// 亿点代付查询返回的结果
        /// </summary>
        /// <returns></returns>
        public string Query_YDSUb(string result)
        {
            try
            {
                string retext = "error";

                //先按& 转换成数组
                JToken jToken = JsonConvert.DeserializeObject(result) as JObject;

                RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();
                messageLog.inserttblPayfailMessageLog("亿点", "888017", "查询代付", "代付", result, DateTime.Now, result);

                if (jToken["transferStatus"] != null)
                {
                    string fldChannelnum = jToken["transferId"].ToString();
                    RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                    DataSet alldt = ruletbl.selechannebycidsub(fldChannelnum);

                    //渠道信息表
                    DataTable dt = alldt.Tables[0];
                    //订单表
                    DataTable oerderdt = alldt.Tables[1];
                    //商户表
                    DataTable Merchant = alldt.Tables[2];

                    //判断是否成功
                    if (jToken["transferStatus"].ToString() == "S")
                    {

                        //判断数据库里面是否有订单号
                        if (oerderdt.Rows.Count > 0 && oerderdt.Rows[0]["fldPayState"].ToString() != "代付成功")
                        {

                            RuletblAgentPay ruleOldOrdertable = new RuletblAgentPay();
                            bool IsSuccess = false;
                            DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "代付成功", out IsSuccess, decimal.Parse(jToken["transferMoney"].ToString()));
                            if (!IsSuccess)
                            {
                                retext = "error";
                            }
                            else
                            {

                                retext = "ok";
                            }

                        }
                        else
                        {
                            retext = "error";
                        }
                    }
                    if (jToken["transferStatus"].ToString() == "E" && jToken["transferStatus"].ToString() == "N")
                    {
                        RuletblAgentPay ruletblAgent = new RuletblAgentPay();
                        bool IsSuccess = false;
                        ruletblAgent.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "异常", out IsSuccess);
                        if (!IsSuccess)
                        {
                            retext = "error";
                        }
                        else
                        {

                            retext = "ok";
                        }
                    }
                }



                return retext;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "QueryRetuenResult", "Query_YDSUb", result);
            }


        }


        /// <summary>
        /// 再创代付查询返回的结果
        /// </summary>
        /// <returns></returns>
        public string Query_ZCSUb(string result, string orid)
        {
            try
            {
                string retext = "error";

                //先按& 转换成数组
                JToken jToken = JsonConvert.DeserializeObject(result) as JObject;

                RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();
                messageLog.inserttblPayfailMessageLog("再创", "605", "查询代付", "代付", result, DateTime.Now, result);

                if (jToken["status"].ToString() == "0")
                {
                    string fldChannelnum = jToken["order_no"].ToString();
                    RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                    DataSet alldt = ruletbl.selechannebycidsub(fldChannelnum);

                    //渠道信息表
                    DataTable dt = alldt.Tables[0];
                    //订单表
                    DataTable oerderdt = alldt.Tables[1];
                    //商户表
                    DataTable Merchant = alldt.Tables[2];

                    //判断是否成功
                    if (jToken["wdstatus"].ToString() == "2")
                    {

                        //判断数据库里面是否有订单号
                        if (oerderdt.Rows.Count > 0 && oerderdt.Rows[0]["fldPayState"].ToString() != "代付成功")
                        {

                            RuletblAgentPay ruleOldOrdertable = new RuletblAgentPay();
                            bool IsSuccess = false;
                            DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "代付成功", out IsSuccess, decimal.Parse(oerderdt.Rows[0]["fldPayAmount"].ToString()));
                            if (!IsSuccess)
                            {
                                retext = "error";
                            }
                            else
                            {

                                retext = "ok";
                            }

                        }
                        else
                        {
                            retext = "error";
                        }
                    }
                    if (jToken["wdstatus"].ToString() == "3")
                    {
                        RuletblAgentPay ruletblAgent = new RuletblAgentPay();
                        bool IsSuccess = false;
                        ruletblAgent.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "异常", out IsSuccess);
                        if (!IsSuccess)
                        {
                            retext = "error";
                        }
                        else
                        {

                            retext = "ok";
                        }
                    }
                }



                return retext;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "QueryRetuenResult", "Query_YDSUb", result);
            }


        }


        /// <summary>
        /// 海付代付查询返回的结果
        /// </summary>
        /// <returns></returns>
        public string Query_HFSUb(string result, string orid)
        {
            try
            {
                string retext = "error";

                //先按& 转换成数组
                JToken jToken = JsonConvert.DeserializeObject(result) as JObject;

                RuletblPayfailMessageLog messageLog = new RuletblPayfailMessageLog();
                messageLog.inserttblPayfailMessageLog("海付", "734641", "查询代付", "代付", result, DateTime.Now, result);

                if (jToken["respCode"].ToString() == "0000")
                {
                    string fldChannelnum = jToken["pay_number"].ToString();
                    RuletblChannelinformation ruletbl = new RuletblChannelinformation();
                    DataSet alldt = ruletbl.selechannebycidsub(fldChannelnum);

                    //渠道信息表
                    DataTable dt = alldt.Tables[0];
                    //订单表
                    DataTable oerderdt = alldt.Tables[1];
                    //商户表
                    DataTable Merchant = alldt.Tables[2];

                    //判断是否成功
                    if (jToken["status"].ToString() == "00")
                    {

                        //判断数据库里面是否有订单号
                        if (oerderdt.Rows.Count > 0 && oerderdt.Rows[0]["fldPayState"].ToString() != "代付成功")
                        {

                            RuletblAgentPay ruleOldOrdertable = new RuletblAgentPay();
                            bool IsSuccess = false;
                            DataTable dataTable = ruleOldOrdertable.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "代付成功", out IsSuccess, decimal.Parse(oerderdt.Rows[0]["fldPayAmount"].ToString()));
                            if (!IsSuccess)
                            {
                                retext = "error";
                            }
                            else
                            {

                                retext = "ok";
                            }

                        }
                        else
                        {
                            retext = "error";
                        }
                    }
                    if (jToken["status"].ToString() == "02")
                    {
                        RuletblAgentPay ruletblAgent = new RuletblAgentPay();
                        bool IsSuccess = false;
                        ruletblAgent.updatestate(oerderdt.Rows[0]["fldMerchID"].ToString(), fldChannelnum, "异常", out IsSuccess);
                        if (!IsSuccess)
                        {
                            retext = "error";
                        }
                        else
                        {

                            retext = "ok";
                        }
                    }
                }



                return retext;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "QueryRetuenResult", "Query_HFSUb", result);
            }


        }
    }
}