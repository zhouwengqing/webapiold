using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 查询
    /// </summary>
    public class SuccessStateController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：查询实时的成功率
        /// 创建  人：
        /// </summary>
        /// <param name="indextime"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [SupportFilter]

        public HttpResponseMessage Successdatate(string indextime)
        {
            string result = string.Empty;
            try
            {
                RuleSuccessStatecs statecs = new RuleSuccessStatecs();
                DataTable table = statecs.successStatedataTable(indextime);

                result = rule.JsonStr("ok", "成功", table);

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " SuccessState", "Success", indextime);
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：查询所有交易的总金额
        /// 创建  人：
        /// </summary>
        /// <param name="amountpram"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        [SupportFilter]

        public HttpResponseMessage AllAmount(amountpram amountpram)
        {
            string result = string.Empty;
            try
            {

                if (string.IsNullOrEmpty(amountpram.startime))
                {
                    amountpram.startime = DateTime.Now.Date.ToString();
                }
                if (string.IsNullOrEmpty(amountpram.endtime))
                {
                    amountpram.endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                RuleSuccessStatecs statecs = new RuleSuccessStatecs();

                string where = parwhere(amountpram);

                //计算多个时间
                DateTime stime = DateTime.Parse(amountpram.startime);
                DateTime etime = DateTime.Parse(amountpram.endtime);
                TimeSpan ts = etime - stime;

                int tsday = ts.Days;

                DataTable dataTable = new DataTable();
                //时间不是当天时
                if (tsday > 0 && !amountpram.Summary)
                {
                    for (int i = 0; i < tsday; i++)
                    {
                        DateTime pramendtime = stime.AddDays(i);
                        DataTable table = statecs.AllAmount(stime.AddDays(i).ToString("yyyy-MM-dd HH:mm:ss"), pramendtime.AddHours(24).ToString("yyyy-MM-dd HH:mm:ss"), where);
                        dataTable.Merge(table);
                    }
                }
                else
                {
                    DataTable table = statecs.AllAmount(amountpram.startime, amountpram.endtime, where);
                    dataTable.Merge(table);
                    if (amountpram.Summary)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            dataTable.Rows[i]["time"] = stime.Date.ToString("yyyy-MM-dd") + "~" + etime.Date.ToString("yyyy-MM-dd");
                        }
                    }

                }





                result = rule.JsonStr("ok", "成功", dataTable);

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };


            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " SuccessState", "AllAmount", amountpram.ToString());
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amountpram"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage ExcelDate(amountpram amountpram)
        {
            try
            {
                string result = string.Empty;

                RuleExcel ruleExcel = new RuleExcel();
                string path = @"~\Excel\";
                string excname = DateTime.Now.ToString("yyyyMMddHHmmss") + "金额明细.xlsx";
                string filename = path + excname;
                var sPath = @filename;
                path = HostingEnvironment.MapPath(path);
                sPath = HostingEnvironment.MapPath(sPath); //转为绝对路径


                string where = parwhere(amountpram);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                if (string.IsNullOrEmpty(amountpram.startime))
                {
                    amountpram.startime = DateTime.Now.Date.ToString();
                }
                if (string.IsNullOrEmpty(amountpram.endtime))
                {
                    amountpram.endtime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                RuleSuccessStatecs statecs = new RuleSuccessStatecs();

                //计算多个时间
                DateTime stime = DateTime.Parse(amountpram.startime);
                DateTime etime = DateTime.Parse(amountpram.endtime);
                TimeSpan ts = etime - stime;

                int tsday = ts.Days;

                DataTable dataTable = new DataTable();
                //时间不是当天时
                if (tsday > 0)
                {
                    for (int i = 0; i < tsday; i++)
                    {
                        DateTime pramendtime = stime.AddDays(i);
                        DataTable table = statecs.AllAmount(stime.AddDays(i).ToString("yyyy-MM-dd HH:mm:ss"), pramendtime.AddHours(24).ToString("yyyy-MM-dd HH:mm:ss"), where);
                        dataTable.Merge(table);
                    }
                }
                else
                {
                    DataTable table = statecs.AllAmount(amountpram.startime, amountpram.endtime, where);
                    dataTable.Merge(table);
                }


                string allamount = dataTable.Compute("sum(allamount)", "true").ToString();
                string seccs = dataTable.Compute("sum(seccs)", "true").ToString();
                string fldServiceCharge = dataTable.Compute("sum(fldServiceCharge)", "true").ToString();
                string AllCount = dataTable.Compute("sum(AllCount)", "true").ToString();
                string SuccessCount = dataTable.Compute("sum(SuccessCount)", "true").ToString();
                string fldProfit = dataTable.Compute("sum(Profit)", "true").ToString();

                DataRow row = dataTable.NewRow();
                row["allamount"] = allamount == "" ? "0" : allamount;
                row["seccs"] = seccs == "" ? "0" : seccs;
                row["fldServiceCharge"] = fldServiceCharge == "" ? "0" : fldServiceCharge;
                row["AllCount"] = AllCount == "" ? "0" : AllCount;
                row["SuccessCount"] = SuccessCount == "" ? "0" : SuccessCount;
                row["Profit"] = fldProfit == "" ? "0" : fldProfit;
                row["time"] = "合计";

                dataTable.Rows.Add(row);
                List<string> colname = new List<string>();
                colname.Add("日期");
                colname.Add("商户名称");
                colname.Add("商户号");
                colname.Add("渠道名称");
                colname.Add("渠道号");
                colname.Add("支付方式");
                colname.Add("总交易额");
                colname.Add("交易成功金额");
                colname.Add("手续费");
                colname.Add("收入");
                colname.Add("总笔数");
                colname.Add("成功笔数");
                ruleExcel.TableToExcel(dataTable, sPath, colname);

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
        /// 
        /// </summary>
        /// <param name="amountpram"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        [SupportFilter]
        public HttpResponseMessage GetRate()
        {
            string result = string.Empty;
            try
            {

                using (YYPlayContext db = new YYPlayContext())
                {
                    //查询所有的数据 
                    var tbleMerchants = db.tbleRate.Select(x => new { x.fldRateName, x.fldRateCode }).ToList();
                    result = rule.JsonStr("ok", "", tbleMerchants);

                }

                return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, " SuccessState", "GetRate", "");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class amountpram
        {
            /// <summary>
            /// 
            /// </summary>
            public string fldMerchID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string startime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string endtime { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldChannelnum { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string paytype { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public bool Summary { get; set; }

        }




        /// <summary>
        /// 功能描述：拼接where条件
        /// 创建时间：2018-12-07
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="reparm"></param>
        /// <returns></returns>
        public string parwhere(amountpram reparm)
        {
            string where = "";

            if (!string.IsNullOrEmpty(reparm.fldMerchID))
            {
                where += " and a.fldMerchID='" + reparm.fldMerchID + "'";
            }
            if (!string.IsNullOrEmpty(reparm.fldChannelnum))
            {
                where += " and a.fldChannelID='" + reparm.fldChannelnum + "'";
            }

            if (!string.IsNullOrEmpty(reparm.paytype))
            {
                where += " and a.fldRateName='" + reparm.paytype + "'";
            }
            return where;
        }
    }
}
