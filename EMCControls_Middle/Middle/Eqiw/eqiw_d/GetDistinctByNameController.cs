using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.eqiw_d
{
    /// <summary>
    /// 功能描述：执行中间库去重的操作
    /// 创建时间：2017/12/27
    /// 创建  人：周文卿
    /// 
    /// </summary>
    public class GetDistinctByNameController : ApiController
    {
        RuleCommon rule = new RuleCommon();


        /// <summary>
        /// 功能描述：获得数据
        /// 创建  人：周文卿
        /// 创建时间：2017/12/27 
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="stname"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage getdistinctdata(string tablename, string stname)
        {
            string result = "";
            try
            {
                if (tablename == "city")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<object> retu = new List<object>();
                        var query = (from x in db.tblEQIW_D_City_Midd
                                     select new
                                     {
                                         fldCityCode = x.fldCityCode,
                                         fldCityName = x.fldCityName
                                     }
                                                           ).DistinctBy(x => new { x.fldCityCode, x.fldCityName }).OrderBy(x => x.fldCityCode);
                        var query2 = (from x in db.tblEQIW_D_City_Midd
                                      select new
                                      {
                                          fldSCategory = x.fldSCategory,
                                          fldSCategoryName = x.fldSCategory
                                      }
                                                          ).DistinctBy(x => new { x.fldSCategory }).OrderBy(x => x.fldSCategory);
                        retu.Add(query);
                        retu.Add(query2);
                        result = rule.JsonStr("ok", "成功", retu);
                    }
                }
                if (tablename == "section")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<object> retu = new List<object>();
                        var query = (from x in db.tblEQIW_D_Section_Midd
                                     select new
                                     {
                                         fldCityCode = x.fldCityCode,
                                         fldCityName = x.fldCityName
                                     }
                                                           ).DistinctBy(x => new { x.fldCityCode, x.fldCityName }).OrderBy(x => x.fldCityCode);
                        var query2 = (from x in db.tblEQIW_D_Section_Midd
                                      select new
                                      {
                                          fldSCategory = x.fldSCategory
                                      }
                                                          ).DistinctBy(x => new { x.fldSCategory }).OrderBy(x => x.fldSCategory);


                        if (stname == "-1")
                        {
                            var query3 = (from x in db.tblEQIW_D_Section_Midd
                                          select new
                                          {
                                              fldRSCode = x.fldRSCode,
                                              fldRSName = x.fldRSName,
                                              fldSTName = x.fldSTName
                                          }
                                                              ).DistinctBy(x => new { x.fldRSCode, x.fldRSName }).OrderBy(x => x.fldRSCode);
                            retu.Add(query);
                            retu.Add(query2);
                            retu.Add(query3);
                        }
                        else
                        {
                            var query3 = (from x in db.tblEQIW_D_Section_Midd
                                          where stname.Contains(x.fldCityName)
                                          select new
                                          {
                                              fldRSCode = x.fldRSCode,
                                              fldRSName = x.fldRSName,
                                              fldSTName = x.fldSTName
                                          }
                                                              ).DistinctBy(x => new { x.fldRSCode, x.fldRSName }).OrderBy(x => x.fldRSCode);
                            retu.Add(query);
                            retu.Add(query2);
                            retu.Add(query3);

                        }

                        result = rule.JsonStr("ok", "成功", retu);
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
        /// 功能描述：时间转换
        /// 创建  人：周文卿
        /// 创建时间：2017/12/27
        /// </summary>
        /// <param name="fldTimeType">时间类型</param>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <returns></returns>
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
