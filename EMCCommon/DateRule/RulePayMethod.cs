using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 功能描述：支付方面的公用方法
    /// 创建  人：周文卿
    /// 创建时间：2018-11-15
    /// </summary>
    public class RulePayMethod
    {

        RulePayBehavior PayBehavior = new RulePayBehavior();

        /// <summary>
        /// 功能描述：判断请求是否合法
        /// 创建  人：周文卿
        /// 创建时间：2018-11-15
        /// </summary>
        /// <param name="payparameter"></param>
        /// <returns></returns>
        public rerurnpram Islegitimate(payparameter payparameter)
        {
            string pramkey = "";
            try
            {

                Dictionary<object, object> dict2 = new Dictionary<object, object>();
                dict2 = PayBehavior.GetPropertiesboj<payparameter>(payparameter);
                rerurnpram rerurnpram = new rerurnpram();
                //日志实体类
                SysLogMsg sysLogMsg = new SysLogMsg();
                string Retunr = "";

                //判断是否有null的参数
                rerurnpram = PayBehavior.IsParmNull(dict2);
                if (rerurnpram.message != "" && rerurnpram.message != null)
                {
                    return rerurnpram;
                }

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict = PayBehavior.GetProperties<payparameter>(payparameter);
                //判断金额
                if (!PayBehavior.tryint(payparameter.Amount))
                {
                    rerurnpram.statecode = "40005";
                    rerurnpram.message = "金额不正确！";
                    sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    sysLogMsg.MerchantId = payparameter.MerchantId;
                    sysLogMsg.MethodName = "LB_PayH5";
                    sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                    sysLogMsg.Content = "金额不正确：{'Amount':'" + payparameter.Amount + "'}";
                    Retunr = LogHelp.logMessage(sysLogMsg);
                    LogHelp.warn(Retunr);
                    return rerurnpram;
                }



                int outint = 0;
                string SecretKey = "";
                string rateName = "";
                DDYZ.Ensis.Rule.DataRule.RuletblOrdertable ordertable = new DDYZ.Ensis.Rule.DataRule.RuletblOrdertable();
                List<newtblSubroute> subroutes = ordertable.IsRule(out outint, payparameter.MerchantId, decimal.Parse(payparameter.Amount), payparameter.OrderID, payparameter.PayType, out SecretKey, out rateName);
                switch (outint)
                {
                    case 40001:
                        rerurnpram.statecode = "40001";
                        rerurnpram.message = "未开户的商户！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PayH5";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "未开户的商户：{'MerchantId':'" + payparameter.MerchantId + "'}";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                    case 40008:
                        rerurnpram.statecode = "40008";
                        rerurnpram.message = "订单号已存在！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PayH5";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "订单号已存在：{'OrderID':'" + payparameter.OrderID + "'}";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                    case 40003:
                        rerurnpram.statecode = "40003";
                        rerurnpram.message = "路由未配置，请联系管理员！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PayH5";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "路由未配置，请联系管理员！";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                    case 40012:
                        rerurnpram.statecode = "40012";
                        rerurnpram.message = "费率未配置！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PayH5";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "费率未配置！";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;

                }
                #region 判断Key值
                //排序得到一个新的Dictionary
                string newdict = PayBehavior.AsciiDesc(dict);
                newdict += "key=" + SecretKey;
                //加密
                string md5string = PayBehavior.EncryptionMd5(newdict);
                pramkey = newdict;
                if (md5string != payparameter.Sign)
                {

                    rerurnpram.statecode = "40002";
                    rerurnpram.message = "验签失败";
                    rerurnpram.data = "";
                    sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    sysLogMsg.MerchantId = payparameter.MerchantId;
                    sysLogMsg.MethodName = "LB_PayH5";
                    sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                    sysLogMsg.Content = "验签失败：{'mysign':" + md5string + ",'sign':" + payparameter.Sign + "}";
                    Retunr = LogHelp.logMessage(sysLogMsg);
                    LogHelp.warn(Retunr);
                    return rerurnpram;
                }
                #endregion

                List<newtblSubroute> newList = PayBehavior.GetRandomList(subroutes, 1);






                string sign = "";
                string orderid = "";
                string url = "";
                //处理参数
                Dictionary<string, string> directory = PayBehavior.HandleParm(newList, dict, ref sign, ref orderid, ref url);
                //按照Ascii从小到大排序 得到一个字符串
                string ascdict = PayBehavior.AsciiDesc(directory);


                RuleCommon common = new RuleCommon();
                DataTable dt = common.GetQueryDate("", "tblChannelinformation", "1=1");

                string fldRequestUrl = "";
                string fldUpstreamSecretKey = "";
                string fldType = "";
                string fldUpstreamMerchantID = "";
                string channel = "";
                //加上Key值
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (newList[0].fldPayType == dt.Rows[i]["fldPayType"].ToString() && newList[0].fldGatewaynumber == dt.Rows[i]["fldNum"].ToString())
                    {
                        fldRequestUrl = dt.Rows[i]["fldRequestUrl"].ToString();
                        fldUpstreamSecretKey = dt.Rows[i]["fldUpstreamSecretKey"].ToString();
                        fldType = dt.Rows[i]["fldType"].ToString();
                        fldUpstreamMerchantID = dt.Rows[i]["fldUpstreamMerchantID"].ToString();
                        channel = dt.Rows[i]["fldNum"].ToString();
                    }
                }
                rerurnpram.message = fldUpstreamSecretKey;
                ascdict = ascdict + "key=" + fldUpstreamSecretKey;
                //加密后的字符串
                string encstring = "";
                //判断加密方式
                switch (newList[0].fldEncryptionWay)
                {
                    case "md5":
                        encstring = PayBehavior.EncryptionMd5(ascdict);
                        break;
                    case "shal":
                        encstring = PayBehavior.Sha1Signature(ascdict);
                        break;
                }

                Processingparameter processingparameter = new Processingparameter();

                string por = "";
                CheckIP checkIP = new CheckIP();
                string ip = checkIP.GetIP();

                decimal amount = decimal.Parse(payparameter.Amount);

                string transactionnum = PayBehavior.ram(1000000000);



                RuleOldOrdertable ordertables = new RuleOldOrdertable();
                #region 根据各个通道 处理请求参数
                switch (newList[0].fldGatewaynumber)
                {
                    case "QJ_004":
                        por = processingparameter.ProcessingQJ(directory, fldUpstreamSecretKey, 0);
                        break;
                    case "YD_010":
                        por = processingparameter.ProcessingYD(directory, fldUpstreamSecretKey);
                        break;
                    case "Y_007":
                        por = processingparameter.ProcessingY(directory, fldUpstreamSecretKey);
                        break;
                    case "RUI_005":
                        por = processingparameter.ProcessingRUI(directory, fldUpstreamSecretKey);
                        break;
                    case "HT_006":
                        por = processingparameter.ProcessingHT(directory, fldUpstreamSecretKey, "0");
                        break;
                    case "ZC_008":
                        por = processingparameter.ProcessingZC(directory, fldUpstreamSecretKey);
                        break;
                    case "WM_009":
                        por = processingparameter.ProcessingWM(directory, fldUpstreamSecretKey);
                        break;
                    case "HF_011":
                        por = processingparameter.ProcessingHF(directory, fldUpstreamSecretKey);
                        break;
                    case "XF_012":
                        por = processingparameter.ProcessingXF(directory, fldUpstreamSecretKey);
                        break;
                    default:
                        directory.Add(sign, encstring);
                        por = processingparameter.Processing(directory);
                        break;
                }

                #endregion
                RulePayRequest rulePayRequest = new RulePayRequest();
                ////请求
                switch (newList[0].fldGatewaynumber)
                {

                    case "RUI_005":
                    case "HT_006":
                    case "Y_007":
                    case "ZC_008":
                    case "WM_009":
                    case "YD_010":
                    case "HF_011":
                        //case "XF_012":
                        rerurnpram = rulePayRequest.HttpPost(fldRequestUrl, por, channel, payparameter.PayType, transactionnum, payparameter.OrderID);
                        break;
                    case "XF_012":

                        rerurnpram = rulePayRequest.trt(fldRequestUrl, por, channel, payparameter.PayType, transactionnum, payparameter.OrderID);
                        break;
                    default:

                        rerurnpram = rulePayRequest.PostUrl(fldRequestUrl, por, payparameter.PayType, channel, transactionnum, payparameter.OrderID);
                        break;
                }

                if (rerurnpram.message == "支付中")
                {

                    rerurnpram.message = "支付中";
                    rerurnpram.statecode = "200";

                    rerurnpram.data = url + "?OrderID=" + payparameter.OrderID + "&tid=" + transactionnum;


                }
                else
                {
                    rerurnpram.message = "支付失败";
                    rerurnpram.urlcode = "";
                    rerurnpram.statecode = "500";
                }

                DDYZ.Ensis.Presistence.DataEntity.tblOrdertable tbl = new DDYZ.Ensis.Presistence.DataEntity.tblOrdertable();
                tbl.fldCreatetime = DateTime.Now;
                tbl.fldtransactionnum = transactionnum;
                tbl.fldChannelnum = orderid;
                tbl.fldOrdernum = payparameter.OrderID;
                tbl.fldOrderAmount = amount;
                tbl.fldRtefundAmount = amount;
                tbl.fldMerchID = payparameter.MerchantId;
                tbl.fldOrederdetailed = payparameter.ProductName;
                tbl.fldRateCode = payparameter.PayType;
                tbl.fldRateName = rateName;
                tbl.fldChannelType = fldType;
                tbl.fldChannelID = fldUpstreamMerchantID;
                tbl.fldOrderInvalid = DateTime.Now;
                tbl.fldNotice = payparameter.Notifyurl;
                tbl.fldLaunchIP = ip;
                tbl.fldStaute = rerurnpram.message;
                tbl.fldchangstautetime = DateTime.Now;
                tbl.fldtransactiontime = DateTime.Now;
                tbl.fldSettlement = amount;
                tbl.fldServiceCharge = 0;
                int index = ordertables.Insert(tbl);

                if (index > 0)
                {

                }
                else
                {
                    rerurnpram.message = "支付失败";
                    rerurnpram.urlcode = "";
                    rerurnpram.statecode = "500";
                }





                return rerurnpram;


            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "Islegitimate", pramkey);
            }

        }




        /// <summary>
        /// 功能描述：判断请求是否合法
        /// 创建  人：周文卿
        /// 创建时间：2018-11-20
        /// </summary>
        /// <param name="payparameter"></param>
        /// <returns></returns>
        public rerurnpram Islegitimate(paysubparameter payparameter)
        {
            try
            {
                Dictionary<object, object> dict2 = new Dictionary<object, object>();
                dict2 = PayBehavior.GetPropertiesboj<paysubparameter>(payparameter);
                rerurnpram rerurnpram = new rerurnpram();

                //日志实体类
                SysLogMsg sysLogMsg = new SysLogMsg();
                string Retunr = "";

                //判断是否有null的参数
                rerurnpram = PayBehavior.IsParmNull(dict2);
                if (rerurnpram.message != "" && rerurnpram.message != null)
                {
                    return rerurnpram;
                }

                //获取IP
                CheckIP checkIP = new CheckIP();
                string ip = checkIP.GetIP();

                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict = PayBehavior.GetProperties<paysubparameter>(payparameter);
                //判断金额
                if (!PayBehavior.tryint(payparameter.Amount))
                {
                    rerurnpram.statecode = "40005";
                    rerurnpram.message = "金额不正确！";
                    sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    sysLogMsg.MerchantId = payparameter.MerchantId;
                    sysLogMsg.MethodName = "LB_PaySub";
                    sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                    sysLogMsg.Content = "金额不正确：{'Amount':" + payparameter.Amount + "}";
                    Retunr = LogHelp.logMessage(sysLogMsg);
                    LogHelp.warn(Retunr);
                    return rerurnpram;
                }



                int outint = 0;
                string SecretKey = "";
                string rateName = "";

                RuletblAgentPay ruletblAgent = new RuletblAgentPay();

                List<newtblSubroute> subroute = new List<newtblSubroute>();
                subroute = ruletblAgent.IsRuleSub(out outint, payparameter.MerchantId, decimal.Parse(payparameter.Amount), payparameter.OrderID, "117", out SecretKey, out rateName, ip);

                switch (outint)
                {
                    case 40001:
                        rerurnpram.statecode = "40001";
                        rerurnpram.message = "未开户的商户！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PaySub";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "未开户的商户：{'Amount':" + payparameter.MerchantId + "}";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                    case 40008:
                        rerurnpram.statecode = "40008";
                        rerurnpram.message = "订单号已存在！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PaySub";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "订单号已存在！";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                    case 40003:
                        rerurnpram.statecode = "40003";
                        rerurnpram.message = "路由未配置，请联系管理员！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PaySub";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "路由未配置，请联系管理员！";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                    case 40009:
                        rerurnpram.statecode = "40009";
                        rerurnpram.message = "账户余额不足！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PaySub";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "账户余额不足！";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                    case 40011:
                        rerurnpram.statecode = "40011";
                        rerurnpram.message = "IP地址受限！";
                        sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        sysLogMsg.MerchantId = payparameter.MerchantId;
                        sysLogMsg.MethodName = "LB_PaySub";
                        sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                        sysLogMsg.Content = "IP地址受限：{'IP':" + ip + "}";
                        Retunr = LogHelp.logMessage(sysLogMsg);
                        LogHelp.warn(Retunr);
                        return rerurnpram;
                }


                #region 判断Key值
                //排序得到一个新的Dictionary
                string newdict = PayBehavior.AsciiDesc(dict);
                newdict += "key=" + SecretKey;
                //加密
                string md5string = PayBehavior.EncryptionMd5(newdict);
                if (md5string != payparameter.Sign)
                {
                    rerurnpram.statecode = "40002";
                    rerurnpram.message = "验签失败";
                    sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    sysLogMsg.MerchantId = payparameter.MerchantId;
                    sysLogMsg.MethodName = "LB_PaySub";
                    sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                    sysLogMsg.Content = "验签失败：{'mysign':" + md5string + ",'sign':" + payparameter.Sign + "}";
                    Retunr = LogHelp.logMessage(sysLogMsg);
                    LogHelp.warn(Retunr);
                    return rerurnpram;
                }
                #endregion
                //根据权重 随机出路由信息
                List<newtblSubroute> newList = PayBehavior.GetRandomList(subroute, 1);

                //渠道信息
                RuleCommon common = new RuleCommon();
                DataTable dt = common.GetQueryDate("", "tblChannelinformation", "1=1");

                string fldRequestUrl = "";//请求地址
                string fldUpstreamSecretKey = "";//上游分配的KEY值
                string fldType = "";//支付类型
                string fldUpstreamMerchantID = "";//上游ID
                string channel = "";//渠道

                bool fldState = false;//渠道状态 0是API,1是手工

                decimal outamount = 0;//外扣金额

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (newList[0].fldPayType == dt.Rows[i]["fldPayType"].ToString() && newList[0].fldGatewaynumber == dt.Rows[i]["fldNum"].ToString())
                    {
                        fldRequestUrl = dt.Rows[i]["fldRequestUrl"].ToString();
                        fldUpstreamSecretKey = dt.Rows[i]["fldUpstreamSecretKey"].ToString();
                        fldType = dt.Rows[i]["fldType"].ToString();
                        fldUpstreamMerchantID = dt.Rows[i]["fldUpstreamMerchantID"].ToString();
                        channel = dt.Rows[i]["fldNum"].ToString();
                        fldState = bool.Parse(dt.Rows[i]["fldState"].ToString());
                        outamount = decimal.Parse(dt.Rows[i]["fldbuckle"].ToString());
                    }
                }

                //判断银行名称是否正确 正确并且换成渠道所需要的银行名称
                RuletblDictionaries ruletblDictionaries = new RuletblDictionaries();
                string bankname = ruletblDictionaries.ValidateDictionaries(fldUpstreamMerchantID, payparameter.Bankname);

                if (bankname == "0")
                {
                    rerurnpram.statecode = "40010";
                    rerurnpram.message = "不支持该银行";
                    rerurnpram.data = "";
                    sysLogMsg.OperationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    sysLogMsg.MerchantId = payparameter.MerchantId;
                    sysLogMsg.MethodName = "LB_PaySub";
                    sysLogMsg.Parameter = JsonHelper.SerializeObject(payparameter);
                    sysLogMsg.Content = "不支持该银行：{'bankname':" + payparameter.Bankname + "}";
                    Retunr = LogHelp.logMessage(sysLogMsg);
                    LogHelp.warn(Retunr);
                    return rerurnpram;
                }

                dict["Bankname"] = bankname;



                string sign = "";
                string orderid = "";
                string url = "";
                //处理参数
                Dictionary<string, string> directory = PayBehavior.HandleParm(newList, dict, ref sign, ref orderid, ref url);



                //按照Ascii从小到大排序 得到一个字符串
                string ascdict = PayBehavior.AsciiDesc(directory);






                rerurnpram.message = fldUpstreamSecretKey;
                ascdict = ascdict + "key=" + fldUpstreamSecretKey;
                //加密后的字符串
                string encstring = "";
                //判断加密方式
                switch (newList[0].fldEncryptionWay)
                {
                    case "md5":
                        encstring = PayBehavior.EncryptionMd5(ascdict);
                        break;
                    case "shal":
                        encstring = PayBehavior.Sha1Signature(ascdict);
                        break;
                }

                Processingparameter processingparameter = new Processingparameter();

                string por = "";

                #region 根据各个通道 处理请求参数
                switch (newList[0].fldGatewaynumber)
                {
                    case "QJ_004":
                        por = processingparameter.ProcessingQJ(directory, fldUpstreamSecretKey, outamount);
                        break;
                    case "HT_006":
                        por = processingparameter.ProcessingHT(directory, fldUpstreamSecretKey, "1");
                        break;
                    case "Y_007":
                        por = processingparameter.ProcessingY(directory, fldUpstreamSecretKey);
                        break;
                    case "YD_010":
                        por = processingparameter.ProcessingYDSub(directory, fldUpstreamSecretKey);
                        break;
                    case "ZC_008":
                        por = processingparameter.ProcessingZC(directory, fldUpstreamSecretKey);
                        break;
                    case "HF_011":
                        por = processingparameter.ProcessingHFSub(directory, fldUpstreamSecretKey);
                        break;
                    default:
                        directory.Add(sign, encstring);
                        por = processingparameter.Processing(directory);
                        break;
                }

                #endregion

                RulePayRequest rulePayRequest = new RulePayRequest();

                string fldPayState = "";

                //请求代付 如果是手工代付 不请求  直接插入 1是手工 0是自动
                if (!fldState)
                {
                    //请求
                    switch (newList[0].fldGatewaynumber)
                    {

                        case "QJ_004":
                            rerurnpram.message = rulePayRequest.PostUrl(fldRequestUrl, por, channel, fldUpstreamSecretKey, orderid);
                            break;
                        case "Y_007":
                        case "HT_006":
                        case "YD_010":
                        case "ZC_008":
                        case "HF_011":
                            rerurnpram.message = rulePayRequest.HttpPostZF(fldRequestUrl, por, channel, fldUpstreamSecretKey, orderid);
                            break;
                    }

                    fldPayState = "处理中";
                }
                else
                {
                    fldPayState = "待提交";
                    rerurnpram.message = "ok";
                }



                //支付状态

                if (rerurnpram.message == "ok")
                {
                    rerurnpram.data = "S";
                    rerurnpram.statecode = "200";
                    rerurnpram.message = "请求成功";

                    DDYZ.Ensis.Presistence.DataEntity.tblAgentPay agentPay = new DDYZ.Ensis.Presistence.DataEntity.tblAgentPay();
                    agentPay.fldAutoID = 0;
                    agentPay.fldCreateTime = DateTime.Now;
                    agentPay.fldtransactionnum = PayBehavior.ram(1000000000);
                    agentPay.fldChannelnum = orderid;
                    agentPay.fldOrdernum = payparameter.OrderID;
                    agentPay.fldMerchID = payparameter.MerchantId;
                    agentPay.fldPayAmount = decimal.Parse(payparameter.Amount);
                    agentPay.fldPayState = fldPayState;
                    agentPay.fldServiceCharge = decimal.Parse(rateName);
                    agentPay.fldActualAmount = decimal.Parse(payparameter.Amount);
                    agentPay.fldAccountname = payparameter.Username;
                    agentPay.fldBankCardId = payparameter.Bankaccount;
                    agentPay.fldBankName = payparameter.Bankname;
                    agentPay.fldChannelID = fldUpstreamMerchantID;
                    agentPay.fldLaunchIP = ip;
                    agentPay.fldNotice = "未通知";
                    agentPay.fldchangstautetime = DateTime.Now;
                    agentPay.fldtransactiontime = DateTime.Now;
                    agentPay.fldRtefundAmount = decimal.Parse(payparameter.Amount) + outamount;
                    agentPay.fldBankType = "支行";
                    agentPay.fldSettlementAmount = 0;
                    agentPay.fldBankbranch = payparameter.Bankbranch;
                    agentPay.fldBankprovince = payparameter.Bankprovince;
                    agentPay.fldBankcity = payparameter.Bankcity;
                    agentPay.fldIdCard = "425648499545154614";
                    agentPay.fldBankTelephoneNo = "18997445161";
                    agentPay.fldCardType = "01";
                    RuletblAgentPay ruletblAgentPay = new RuletblAgentPay();
                    DataTable k = ruletblAgentPay.InserttblAgentPayUptblAcc(agentPay);
                    if (k.Rows.Count > 0)
                    {
                        rerurnpram.statecode = "50000";
                        rerurnpram.message = "服务器出现错误，请联系管理员！";
                        return rerurnpram;
                    }



                }
                else
                {
                    rerurnpram.data = "F";
                    rerurnpram.statecode = "500";
                    rerurnpram.message = "请求失败";
                }
                return rerurnpram;

            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RulePayMethod", "Islegitimate", payparameter.ToString());
            }

        }

    }
}