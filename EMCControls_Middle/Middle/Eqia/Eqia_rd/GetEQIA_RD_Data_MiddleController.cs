using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqia.Eqia_rd
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIA_RD_Data_MiddleController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-18
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData(Info info)
        {
            string result = null;
            try
            {

                if (info.type == "ZHAppraise")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_RD_ZHAppraise_Midd> query = new List<tblEQIA_RD_ZHAppraise_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);


                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_RD_ZHAppraise_Midd
                                     where x.TimeType == info.TimeType &&
                                     x.fldYear == info.fldYear &&
                                     list.Contains(x.fldDate) &&
                                     x.AppriseID == info.AppriseID
                                     select x).ToList();
                        }
                        else
                        {
                            if (info.AppriseID == "0")
                            {
                                query = (from x in db.tblEQIA_RD_ZHAppraise_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.fldYear == info.fldYear &&
                                         list.Contains(x.fldDate) &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                         select x).ToList();
                            }

                            if (info.AppriseID == "1")
                            {
                                query = (from x in db.tblEQIA_RD_ZHAppraise_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.fldYear == info.fldYear &&
                                         list.Contains(x.fldDate) &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode)
                                         select x).ToList();
                            }
                        }
                        ReturnData rd = new ReturnData();
                        rd.dangqi = query;
                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_RD_ZHAppraise_Midd> query2 = new List<tblEQIA_RD_ZHAppraise_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);
                            int year = int.Parse(info.fldYear) - 1;

                            list = ConvertDate(info.TimeType, BeginDate, EndDate);


                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_RD_ZHAppraise_Midd
                                          where x.TimeType == info.TimeType &&
                                          x.fldYear == year.ToString() &&
                                          list.Contains(x.fldDate) &&
                                          x.AppriseID == info.AppriseID
                                          select x).ToList();
                            }
                            else
                            {
                                if (info.AppriseID == "0")
                                {
                                    query2 = (from x in db.tblEQIA_RD_ZHAppraise_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.fldYear == year.ToString() &&
                                              list.Contains(x.fldDate) &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                              select x).ToList();
                                }

                                if (info.AppriseID == "1")
                                {
                                    query2 = (from x in db.tblEQIA_RD_ZHAppraise_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.fldYear == year.ToString() &&
                                              list.Contains(x.fldDate) && 
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode)
                                              select x).ToList();
                                }
                            }


                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
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
        /// 参数实体
        /// </summary>
        public class Info
        {
            /// <summary>
            /// “ZHAppraise”，综合评价
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 时间类型：
            /// “month”、“sea”、“halfyear”、“year”
            /// </summary>
            public string TimeType { get; set; }

            /// <summary>
            /// 年份
            /// </summary>
            public string fldYear { get; set; }


            /// <summary>
            /// 0:针对单个点位评价、1：针对城市评价
            /// </summary>
            public string AppriseID { get; set; }


            /// <summary>
            /// 城市代码：
            /// 1.“-1”返回所有城市
            /// 2.代码列表形式，代码用任意字符分割即可
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// “1”返回同期数据
            /// </summary>
            public string IsYear { get; set; }



        }





        /// <summary>
        /// “ZHAppraise”
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIA_RD_ZHAppraise_Midd> dangqi { get; set; }

            public List<tblEQIA_RD_ZHAppraise_Midd> tongqi { get; set; }
        }




        public List<string> ConvertDate(string fldTimeType, DateTime BeginDate, DateTime EndDate)
        {
            List<string> list = new List<string>();

            if (fldTimeType == "month")
            {
                int BeginMonth = BeginDate.Month;

                int EndMonth = EndDate.Month;

                for (int i = BeginMonth; i <= EndMonth; i++)
                {
                    if (BeginMonth < 10)
                    {
                        list.Add(BeginDate.Year.ToString() + "年0" + i.ToString() + "月");
                    }
                    else
                    {
                        list.Add(BeginDate.Year.ToString() + "年" + i.ToString() + "月");
                    }
                }
            }

            if (fldTimeType == "sea")
            {
                if (EndDate.Month == 3)
                {
                    list.Add(BeginDate.Year.ToString() + "年1季度");
                }
                else if (EndDate.Month == 6)
                {
                    if (BeginDate.Month == 1)
                    {
                        list.Add(BeginDate.Year.ToString() + "年1季度");
                        list.Add(BeginDate.Year.ToString() + "年2季度");
                    }
                    else if (BeginDate.Month == 4)
                    {
                        list.Add(BeginDate.Year.ToString() + "年2季度");
                    }
                }
                else if (EndDate.Month == 9)
                {
                    if (BeginDate.Month == 1)
                    {
                        list.Add(BeginDate.Year.ToString() + "年1季度");
                        list.Add(BeginDate.Year.ToString() + "年2季度");
                        list.Add(BeginDate.Year.ToString() + "年3季度");
                    }
                    else if (BeginDate.Month == 4)
                    {
                        list.Add(BeginDate.Year.ToString() + "年2季度");
                        list.Add(BeginDate.Year.ToString() + "年3季度");
                    }
                    else if (BeginDate.Month == 7)
                    {
                        list.Add(BeginDate.Year.ToString() + "年3季度");
                    }
                }
                else if (EndDate.Month == 12)
                {
                    if (BeginDate.Month == 1)
                    {
                        list.Add(BeginDate.Year.ToString() + "年1季度");
                        list.Add(BeginDate.Year.ToString() + "年2季度");
                        list.Add(BeginDate.Year.ToString() + "年3季度");
                        list.Add(BeginDate.Year.ToString() + "年4季度");
                    }
                    else if (BeginDate.Month == 4)
                    {
                        list.Add(BeginDate.Year.ToString() + "年2季度");
                        list.Add(BeginDate.Year.ToString() + "年3季度");
                        list.Add(BeginDate.Year.ToString() + "年4季度");
                    }
                    else if (BeginDate.Month == 7)
                    {
                        list.Add(BeginDate.Year.ToString() + "年3季度");
                        list.Add(BeginDate.Year.ToString() + "年4季度");
                    }
                    else if (BeginDate.Month == 10)
                    {
                        list.Add(BeginDate.Year.ToString() + "年4季度");
                    }
                }

            }

            if (fldTimeType == "halfyear")
            {
                if (BeginDate.Month == 1 && EndDate.Month == 6)
                {
                    list.Add(BeginDate.Year.ToString() + "年上半年");
                }

                if (BeginDate.Month == 7 && EndDate.Month == 12)
                {
                    list.Add(BeginDate.Year.ToString() + "年下半年");
                }

                if (BeginDate.Month == 1 && EndDate.Month == 12)
                {
                    list.Add(BeginDate.Year.ToString() + "年上半年");
                    list.Add(BeginDate.Year.ToString() + "年下半年");
                }
            }

            if (fldTimeType == "year")
            {
                list.Add(BeginDate.Year.ToString() + "年");
            }

            return list;
        }





    }
}
