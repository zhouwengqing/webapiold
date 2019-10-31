using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
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
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 功能描述：代付相关API
    /// 创建时间：2018-12-07
    /// 创建  人：周文卿
    /// </summary>
    public class AgentPayController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：得到代付表
        /// 创建时间：2018-12-07
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetAgentPay(parm reparm)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                string where = parwhere(reparm);




                //查询分页的数据
                DataTable dt = rule.getpaging("vwtblAgentPay", "*", "1=1" + where, reparm.page, reparm.limit, reparm.sort, out count);

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
        /// 功能描述：得到导出的数据
        /// 创建时间：2018-12-10
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetExcelDate(parm reparm)
        {
            string result = string.Empty;
            try
            {


                RuleExcel ruleExcel = new RuleExcel();
                string path = @"~\Excel\";
                string excname = DateTime.Now.ToString("yyyyMMddHHmmss") + "代付列表.xlsx";
                string filename = path + excname;
                var sPath = @filename;
                path = HostingEnvironment.MapPath(path);
                sPath = HostingEnvironment.MapPath(sPath); //转为绝对路径


                string where = parwhere(reparm);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string file = "fldCreateTime,fldChannelnum,fldOrdernum,fldMerchID,fldMerchName,fldPayState,fldServiceCharge,fldBankName,fldBankbranch,fldAccountname,fldBankCardId,fldBankprovince,fldBankcity,fldPayAmount,fldRtefundAmount,fldChannelID," +
                    "fldLaunchIP,fldNotice,fldchangstautetime,fldtransactiontime,fldBankType,fldBankTelephoneNo,fldIdCard,fldCardType";
                DataTable dt = rule.GetQueryDate("0", "vwtblAgentPay", "1=1" + where, file);

                List<string> colname = new List<string>();
                colname.Add("创建时间");
                colname.Add("渠道流水号");
                colname.Add("订单号");
                colname.Add("商户号");
                colname.Add("商户名");
              
                colname.Add("订单状态");
                colname.Add("手续费");
               
               
                colname.Add("银行名称");

                colname.Add("银行支行");
                colname.Add("账户名");
                colname.Add("银行卡号");

                colname.Add("银行省份");

                colname.Add("开户行所在市");

                colname.Add("代付金额");
                colname.Add("上送金额");
                colname.Add("渠道号");
                colname.Add("发起方IP");
                colname.Add("异步通知地址");
                colname.Add("状态变化时间");

                colname.Add("交易时间");
                colname.Add("银行类型");



                colname.Add("电话号码");
                colname.Add("身份证号");
                colname.Add("银行卡类型");


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
                throw new InsertException(e.Message, "Transaction", "AgentPay", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }





        /// <summary>
        /// 功能描述：根据ID 修改状态
        /// 创建时间：2019-03-04
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="fldAutoID"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage Updatestate(string fldAutoID)
        {
            string result = string.Empty;
            try
            {
                rule.getdt("update tblAgentPay set fldPayState='待审核' where fldAutoID in (" + fldAutoID + ")");

                result = rule.JsonStr("ok", "成功", "");


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：根据ID 修改状态（审核成功）
        /// 创建时间：2019-03-04
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="tblAgents"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage autistateok(List<DDYZ.Ensis.Presistence.DataEntity.tblAgentPay> tblAgents)
        {
            string result = string.Empty;
            try
            {
                //成功减少冻结金额 扣除手续费
                RuletblAgentPay agentPay = new RuletblAgentPay();

                string okdata = "";

                //根据循环更新

                int countindex = 0;

                for (int i = 0; i < tblAgents.Count; i++)
                {
                     bool IsSuccess = false;
                    DataTable dataTable = agentPay.updatestate(tblAgents[i].fldMerchID, tblAgents[i].fldChannelnum, "代付成功", out IsSuccess, tblAgents[i].fldPayAmount);
                    okdata += tblAgents[i].fldAutoID + ",";

                    //RuleCommon rule = new RuleCommon();
                    //DataTable Merchant = rule.getdt("select *  from tbleMerchant where fldMerchID='" + tblAgents[i].fldMerchID + "'");

                    ////代付成功 异步通知                   
                    //AsynParameterSub asyn = new AsynParameterSub();
                    //asyn.Amount = tblAgents[i].fldPayAmount.ToString();
                    //asyn.MerchantId = tblAgents[i].fldMerchID.ToString();
                    //asyn.OrderID = tblAgents[i].fldOrdernum.ToString();
                    //asyn.Paystate = "支付成功";
                    //asyn.OrderTime = DateTime.Now.ToString();


                    //string getpram = JsonHelper.SerializeObject(asyn);
                    ////json 转换成Dictionary
                    //Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                    ////排序
                    //RulePayBehavior behavior = new RulePayBehavior();
                    //string pxrams = behavior.AsciiDesc(valuePairs);
                    ////添加key值
                    //pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                    ////md5加密
                    //string signkey = behavior.EncryptionMd5(pxrams);

                    //asyn.Sign = signkey;

                    ////转换成json 格式
                    //string prams = JsonHelper.SerializeObject(asyn);

                    ////请求  通知
                    //RulePayRequest rulePayRequest = new RulePayRequest();
                    //string rest = rulePayRequest.PostUrl(tblAgents[i].fldNotice.ToString(), prams);
                    //if (rest != "ok")
                    //{
                    //    //开启线程
                    //    Thread thread1 = new Thread(() => Notifyurl.myThread(tblAgents[i].fldMerchID.ToString(), tblAgents[i].fldOrdernum, tblAgents[i].fldPayAmount.ToString(), DateTime.Now.ToString(), tblAgents[i].fldNotice, "代付成功", Merchant.Rows[0]["fldSecretKey"].ToString()));
                    //    thread1.Start();
                   // }

                    countindex++;

                }




                result = rule.JsonStr("ok", "成功", "提交审核：" + (tblAgents.Count) + "条,成功：" + countindex + "条");


            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：根据ID 修改状态（审核失败）
        /// 创建时间：2019-03-04
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="tblAgents"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage autistatefail(List<DDYZ.Ensis.Presistence.DataEntity.tblAgentPay> tblAgents)
        {
            string result = string.Empty;
            try
            {
                //成功减少冻结金额 扣除手续费
                RuletblAgentPay agentPay = new RuletblAgentPay();

                string okdata = "";

                //根据循环更新

                int countindex = 0;

                for (int i = 0; i < tblAgents.Count; i++)
                {
                    bool IsSuccess = false;
                    DataTable dataTable = agentPay.updatestatefail(tblAgents[i].fldMerchID, tblAgents[i].fldChannelnum, "代付失败", out IsSuccess, tblAgents[i].fldPayAmount);
                    okdata += tblAgents[i].fldAutoID + ",";

                    //RuleCommon rule = new RuleCommon();
                    //DataTable Merchant = rule.getdt("select *  from tbleMerchant where fldMerchID='" + tblAgents[i].fldMerchID + "'");

                    ////代付成功 异步通知                   
                    //AsynParameterSub asyn = new AsynParameterSub();
                    //asyn.Amount = tblAgents[i].fldPayAmount.ToString();
                    //asyn.MerchantId = tblAgents[i].fldMerchID.ToString();
                    //asyn.OrderID = tblAgents[i].fldOrdernum.ToString();
                    //asyn.Paystate = "代付失败";
                    //asyn.OrderTime = DateTime.Now.ToString();


                    //string getpram = JsonHelper.SerializeObject(asyn);
                    ////json 转换成Dictionary
                    //Dictionary<string, string> valuePairs = JsonHelper.DeserializeStringToDictionary<string, string>(getpram);
                    ////排序
                    //RulePayBehavior behavior = new RulePayBehavior();
                    //string pxrams = behavior.AsciiDesc(valuePairs);
                    ////添加key值
                    //pxrams += "key=" + Merchant.Rows[0]["fldSecretKey"].ToString();
                    ////md5加密
                    //string signkey = behavior.EncryptionMd5(pxrams);

                    //asyn.Sign = signkey;

                    ////转换成json 格式
                    //string prams = JsonHelper.SerializeObject(asyn);

                    ////请求  通知
                    //RulePayRequest rulePayRequest = new RulePayRequest();
                    //string rest = rulePayRequest.PostUrl(tblAgents[i].fldNotice.ToString(), prams);
                    //if (rest != "ok")
                    //{
                    //    //开启线程
                    //    Thread thread1 = new Thread(() => Notifyurl.myThread(tblAgents[i].fldMerchID.ToString(), tblAgents[i].fldOrdernum, tblAgents[i].fldPayAmount.ToString(), DateTime.Now.ToString(), tblAgents[i].fldNotice, "代付失败", Merchant.Rows[0]["fldSecretKey"].ToString()));
                    //    thread1.Start();
                    //}

                    countindex++;

                }




                result = rule.JsonStr("ok", "成功", "提交审核：" + (tblAgents.Count) + "条,成功：" + countindex + "条");


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
            /// 页面状态
            /// </summary>
            public string flag { get; set; }

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
            /// 代付状态
            /// </summary>
            public string PayState { get; set; }

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
            /// 银行卡号
            /// </summary>
            public string banknum { get; set; }
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
        /// 创建时间：2018-12-07
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        public string parwhere(parm reparm)
        {
            string where = "";
            if (!string.IsNullOrEmpty(reparm.channelnum))
            {
                where += " and fldChannelnum='" + reparm.channelnum + "'";
            }
            if (!string.IsNullOrEmpty(reparm.flag))
            {
                if (reparm.flag == "0")
                {
                    where += " and fldPayState !='待提交' and fldPayState !='异常' and fldPayState !='待审核'";
                }
                if (reparm.flag == "1")
                {
                    where += " and fldPayState ='待提交' ";
                }
                if (reparm.flag == "2")
                {
                    where += " and fldPayState ='待审核' ";
                }
                if (reparm.flag == "3")
                {
                    where += " and fldPayState ='异常' ";
                }

            }
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
                where += " and fldActualAmount>=" + reparm.minOrderAmount + " and fldActualAmount<=" + reparm.maxOrderAmount;
            }
            if (!string.IsNullOrEmpty(reparm.PayState))
            {
                where += " and fldPayState='" + reparm.PayState + "'";
            }

            if (!string.IsNullOrEmpty(reparm.minOrdertime) && !string.IsNullOrEmpty(reparm.maxOrdertime))
            {
                where += " and fldCreateTime>='" + reparm.minOrdertime + "'" + " and fldCreateTime<='" + reparm.maxOrdertime + "'";
            }
            else
            {
                where += " and fldCreatetime>='" + DateTime.Now.ToShortDateString() + "'";
            }

            if (!string.IsNullOrEmpty(reparm.channelid))
            {
                where += " and fldChannelID='" + reparm.channelid + "'";
            }
            if (!string.IsNullOrEmpty(reparm.banknum))
            {
                where += " and fldBankCardId='" + reparm.banknum + "'";
            }
            return where;
        }
    }
}
