using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_EMCMIS.EMCMIS.Eqiw.Eqiw_r_Auto
{
    /// <summary>
    /// 功能描述：自动监测报表
    /// 创建时间：2018/03/29
    /// 创建者  ：刘勇军 
    /// </summary>
    public class Eqiw_R_Auto_ReportController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-3-29
        /// 功能描述：数据捕获率
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        /// 

        [HttpPost]
        public HttpResponseMessage Report_CaptureSet(Report_CaptureSet_Info info)
        {
            string result = string.Empty;

            List<string> ItemCodeParameter = info.fldItemCode.Split(',').ToList();
            try
            {

                List<Model.tblEQIW_R_HourData_Auto> list = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_Section> list_section = new List<Model.tblEQIW_R_Section>();

                List<Model.tblEQIW_R_Item> list_item = new List<Model.tblEQIW_R_Item>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                TimeSpan d3 = EndDate.Subtract(BeginDate);

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    //根据因子代码查询小时值
                    list = (from x in db.tblEQIW_R_HourData_Auto
                            where ItemCodeParameter.Contains(x.fldItemCode)
                            select x).ToList();
                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询小时值
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }

                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay);
                    }

                    //根据时间查询小时值
                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();

                    //根据时间查询断面
                    list_section = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == BeginDate.Year
                                    select x).ToList();

                    //查询因子
                    list_item = (from y in db.tblEQIW_R_Item select y).ToList();

                }



                var query = (from x in list
                             group x by x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                             into g
                             select new
                             {
                                 //组合断面代码
                                 SectionCode = g.Key,
                                 //断面名称
                                 SectionName = (from x in list_section
                                                where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                                select x.fldRSName).FirstOrDefault(),
                                 //日期
                                 Date = BeginDate.ToShortDateString().ToString() + "~" + EndDate.ToShortDateString().ToString(),
                                 //捕获率数据集合
                                 CaptureSet = from y in g
                                              group y by y.fldItemCode
                                              into h
                                              select new
                                              {
                                                  //因子代码
                                                  ItemCode = h.Key,
                                                  //因子名称:转为因子捕获率  如：氨氮捕获率
                                                  ItemName = (from x in list_item
                                                              where h.Key == x.fldItemCode
                                                              select x.fldItemName).FirstOrDefault() + "捕获率",
                                                  //捕获率
                                                  CaptureRate = double.Parse(h.Count().ToString()) / (6 * d3.Days)
                                              },
                                 //合计捕获率
                                 TotalCapture = double.Parse(GetCapture((from x in list where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode select x).ToList(), ItemCodeParameter).ToString()) / (6 * d3.Days),
                                 //数据捕获率
                                 DataCapture = double.Parse(GetCapture((from x in list where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode select x).ToList(), ItemCodeParameter).ToString()) / (6 * d3.Days * ItemCodeParameter.Count())
                             }).ToList();
                //合计捕获率是各因子捕获率之合      数据捕获率是所选时间段断面各因子数据总个数 /（因子个数 * 6 * 所选时间段天数）


                if (query.Count > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 合计捕获：各因子捕获之合
        /// </summary>
        /// <param name="list">集合</param>
        /// <param name="ItemCode">因子代码</param>
        /// <returns></returns>
        public int GetCapture(List<Model.tblEQIW_R_HourData_Auto> list, List<string> ItemCode)
        {
            int ret = 0;

            foreach (var item in ItemCode)
            {
                ret += (from x in list where x.fldItemCode == item select x).Count();
            }

            return ret;
        }





        /// <summary>
        /// 捕获率参数实体
        /// </summary>
        public class Report_CaptureSet_Info
        {
            /// <summary>
            /// 断面代码
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
            /// 因子代码集合
            /// </summary>
            public string fldItemCode { get; set; }
        }




















        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-3-30
        /// 功能描述：日运行情况
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Report_DayOperation(Report_DayOperation_Info info)
        {
            string result = string.Empty;

            List<string> ItemCodeParameter = info.fldItemCode.Split(',').ToList();
            try
            {

                List<Model.tblEQIW_R_HourData_Auto> list = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_Section> list_section = new List<Model.tblEQIW_R_Section>();

                List<Model.tblEQIW_R_Item> list_item = new List<Model.tblEQIW_R_Item>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                TimeSpan d3 = EndDate.Subtract(BeginDate);

                using (Model.EntityContext db = new Model.EntityContext())
                {

                    //根据因子代码查询小时值
                    list = (from x in db.tblEQIW_R_HourData_Auto
                            where ItemCodeParameter.Contains(x.fldItemCode)
                            select x).ToList();

                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay);
                    }

                    //根据时间查询小时值
                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();

                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询小时值
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }


                    //根据时间查询断面
                    list_section = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == BeginDate.Year
                                    select x).ToList();

                    //查询因子
                    list_item = (from y in db.tblEQIW_R_Item select y).ToList();

                }
                var query = (from x in list
                             group x by x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                             into g
                             select new
                             {
                                 //组合断面代码
                                 SectionCode = g.Key,
                                 //断面名称
                                 SectionName = (from x in list_section
                                                where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                                select x.fldRSName).FirstOrDefault(),
                                 //日期
                                 EveryDayDate = (from z in g
                                                 group z by z.fldYear + "-" + z.fldMonth + "-" + z.fldDay
                                                 into q
                                                 select new
                                                 {
                                                     //日期
                                                     Date = q.Key,
                                                     //因子数据集合
                                                     IteMCodeSet = from y in q
                                                                   group y by y.fldItemCode
                                                                   into h
                                                                   select new
                                                                   {
                                                                       //因子代码
                                                                       ItemCode = h.Key,
                                                                       //因子名称
                                                                       ItemName = (from x in list_item
                                                                                   where h.Key == x.fldItemCode
                                                                                   select x.fldItemName).FirstOrDefault(),
                                                                       //比率
                                                                       ItemRatio = (double.Parse(h.Count().ToString()) / 6 * 100) > 100 ? "100%" : (double.Parse(h.Count().ToString()) / 6 * 100 + "%"),
                                                                   },
                                                     //总情况
                                                     TotalSituation = (double.Parse(q.Count().ToString()) / (ItemCodeParameter.Count() * 6) * 100 > 100 ? "100%" : ((double.Parse(q.Count().ToString()) / (ItemCodeParameter.Count() * 6) * 100 + "%")))

                                                 })
                             }).ToList();


                if (query.Count > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有保存数据！", "");
                }
            }
            catch (Exception e)
            {

                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }




        /// <summary>
        /// 日运行参数实体
        /// </summary>
        public class Report_DayOperation_Info
        {
            /// <summary>
            /// 断面代码
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
            /// 因子代码集合
            /// </summary>
            public string fldItemCode { get; set; }
        }



















        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-3-30
        /// 功能描述：实际水样比对合格率
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Report_ContrastQualificationRate(Report_ContrastQualificationRate_Info info)
        {
            string result = string.Empty;

            List<string> ItemCodeParameter = info.fldItemCode.Split(',').ToList();
            try
            {

                List<Model.tblEQIW_R_HourData_Auto> list = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_HourData_Auto> list2 = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_DAQLTSTD> list_daqltstd = new List<Model.tblEQIW_R_DAQLTSTD>();

                List<Model.tblEQIW_R_Section> list_section = new List<Model.tblEQIW_R_Section>();

                List<Model.tblEQIW_R_Item> list_item = new List<Model.tblEQIW_R_Item>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);


                using (Model.EntityContext db = new Model.EntityContext())
                {

                    //查询小时值
                    list = (from x in db.tblEQIW_R_HourData_Auto
                            select x).ToList();
                    //根据因子代码查询小时值
                    list = (from x in list
                            where ItemCodeParameter.Contains(x.fldItemCode)
                            select x).ToList();

                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay);
                    }

                    //根据时间查询小时值
                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();

                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询小时值
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }

                    //根据时间查询断面
                    list_section = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == BeginDate.Year
                                    select x).ToList();

                    //查询因子
                    list_item = (from y in db.tblEQIW_R_Item select y).ToList();

                    //根据超标依据查询合格标准
                    list_daqltstd = (from y in db.tblEQIW_R_DAQLTSTD
                                     where y.fldEdition == info.fldEdition
                                     select y).ToList();



                    list2 = (from x in list select x).ToList();



                    list2 = (from x in list2
                             join y in list_daqltstd
                             on new
                             {
                                 x.fldItemCode

                             } equals new
                             {
                                 y.fldItemCode
                             }
                             where x.fldItemValue < y.fldST30
                             select x).ToList();



                }

                var query = (from x in list
                             group x by x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                             into g
                             select new
                             {
                                 //组合断面代码
                                 SectionCode = g.Key,
                                 //断面名称
                                 SectionName = (from x in list_section
                                                where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                                select x.fldRSName).FirstOrDefault(),
                                 //因子数据集合
                                 ItemSet = from y in g
                                           group y by y.fldItemCode
                                              into h
                                           select new
                                           {
                                               //因子代码
                                               ItemCode = h.Key,
                                               //因子名称
                                               ItemName = (from x in list_item
                                                           where h.Key == x.fldItemCode
                                                           select x.fldItemName).FirstOrDefault(),
                                               //因子合格率
                                               ItemQualification = (double.Parse((from x in list2
                                                                                  where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode &&
                                                                                  h.Key == x.fldItemCode
                                                                                  select x).Count().ToString()) / h.Count() * 100).ToString("f2") + "%"
                                           },
                                 //总合格率
                                 TotalQualification = (double.Parse((from x in list2
                                                                     where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                                                     select x).Count().ToString()) / g.Count() * 100).ToString("f2") + "%"

                             }).ToList();



                if (query.Count > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }





        /// <summary>
        /// 实际水样比对合格率参数实体
        /// </summary>
        public class Report_ContrastQualificationRate_Info
        {
            /// <summary>
            /// 断面代码
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
            /// 超标依据
            /// </summary>
            public string fldEdition { get; set; }

            /// <summary>
            /// 因子代码集合
            /// </summary>
            public string fldItemCode { get; set; }
        }



























        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-3-31
        /// 功能描述：累计情况统计
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Report_MeasuresImplementRate(Report_MeasuresImplementRate_Info info)
        {
            string result = string.Empty;

            List<string> ItemCodeParameter = info.fldItemCode.Split(',').ToList();
            try
            {
                List<Model.tblEQIW_R_HourData_Auto> list = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_Section> list_section = new List<Model.tblEQIW_R_Section>();

                List<Model.tblEQIW_R_Item> list_item = new List<Model.tblEQIW_R_Item>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                TimeSpan d3 = EndDate.Subtract(BeginDate);

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    //查询小时值
                    list = (from x in db.tblEQIW_R_HourData_Auto
                            select x).ToList();

                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay);
                    }

                    //根据时间查询小时值
                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();

                    //根据因子代码查询小时值
                    list = (from x in list
                            where ItemCodeParameter.Contains(x.fldItemCode)
                            select x).ToList();

                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询小时值
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }


                    //根据时间查询断面
                    list_section = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == BeginDate.Year
                                    select x).ToList();

                    //查询因子
                    list_item = (from y in db.tblEQIW_R_Item select y).ToList();


                }







                var query = (from x in list
                             group x by x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                            into g
                             select new
                             {
                                 //组合断面代码
                                 SectionCode = g.Key,
                                 //断面名称
                                 SectionName = (from x in list_section
                                                where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                                select x.fldRSName).FirstOrDefault(),
                                 //日期
                                 Date = BeginDate.ToShortDateString().ToString() + "~" + EndDate.ToShortDateString().ToString(),
                                 //因子数据集合
                                 ItemCodeSet = from y in g
                                               group y by y.fldItemCode
                                               into h
                                               select new
                                               {
                                                   //因子代码
                                                   ItemCode = h.Key,
                                                   //因子名称:
                                                   ItemName = (from x in list_item
                                                               where h.Key == x.fldItemCode
                                                               select x.fldItemName).FirstOrDefault(),
                                                   //百分比
                                                   Percentage = double.Parse(GetDay(BeginDate, EndDate, g.Key, new List<string> { h.Key }).ToString()) / d3.Days
                                               },
                                 //总情况
                                 TotalPercentage = double.Parse(GetDay(BeginDate, EndDate, g.Key, ItemCodeParameter).ToString()) / d3.Days
                             }).ToList();


                if (query.Count > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
                }
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 得到合格天数
        /// </summary>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="STCode">断面代码</param>
        /// <param name="ItemCode">因子代码</param>
        /// <returns></returns>
        public int GetDay(DateTime beginTime, DateTime endTime, string STCode, List<string> ItemCode)
        {
            int dd = 0;

            try
            {
                List<Model.tblEQIW_R_HourData_Auto> list = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_HourData_Auto> list2 = new List<Model.tblEQIW_R_HourData_Auto>();

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    //查询小时值
                    list = (from x in db.tblEQIW_R_HourData_Auto
                            select x).ToList();

                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay);
                    }

                    //根据时间查询小时值
                    list = (from x in list
                            where x.fldDate >= beginTime &&
                            x.fldDate <= endTime
                            select x).ToList();

                    //根据因子代码查询小时值
                    list = (from x in list
                            where ItemCode.Contains(x.fldItemCode)
                            select x).ToList();

                    //根据断面代码查询小时值
                    list = (from x in list
                            where STCode == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                            select x).ToList();

                    List<DateTime> listDays = new List<DateTime>();
                    DateTime dtDay = new DateTime();

                    for (dtDay = beginTime; dtDay.CompareTo(endTime) <= 0; dtDay = dtDay.AddDays(1))
                    {
                        listDays.Add(dtDay);
                    }

                    foreach (var item in listDays)
                    {
                        list2 = (from x in list
                                 where x.fldDate == item
                                 select x).ToList();
                        if (list2.Count() > 4)
                        {
                            dd++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                dd = 0;
            }


            return dd;
        }



        /// <summary>
        /// 累计情况参数实体
        /// </summary>
        public class Report_MeasuresImplementRate_Info
        {
            /// <summary>
            /// 断面代码
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
            /// 因子代码集合
            /// </summary>
            public string fldItemCode { get; set; }
        }































        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-4-02
        /// 功能描述：异常数据统计
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Report_ExceptionStatistics(Report_ExceptionStatistics_Info info)
        {
            string result = string.Empty;

            List<Model.tblEQIW_R_Auto_Remark> list = new List<Model.tblEQIW_R_Auto_Remark>();
            try
            {

                List<Model.tblEQIW_R_Section> list_section = new List<Model.tblEQIW_R_Section>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    //查询异常数据
                    list = (from x in db.tblEQIW_R_Auto_Remark select x).ToList();

                    //根据时间查询异常数据
                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();

                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询异常数据
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }

                    //根据时间查询断面
                    list_section = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == BeginDate.Year
                                    select x).ToList();

                }


                var query = (from q in list
                             select new
                             {
                                 //时间段
                                 Date = BeginDate.ToShortDateString().ToString() + "~" + EndDate.ToShortDateString().ToString(),
                                 //断面集合
                                 SectionSet = (from x in list
                                               group x by x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                        into g
                                               select new
                                               {
                                                   //断面代码
                                                   SectionCode = g.Key,
                                                   SectionName = (from x in list_section
                                                                  where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                                                  select x.fldRSName).FirstOrDefault(),
                                                   //断流天数
                                                   StopNum = (from x in g
                                                              where "断流".Contains(x.fldRemark)
                                                              select x).Count(),
                                                   //停电天数
                                                   PowerFailureNum = (from x in g
                                                                      where "停电".Contains(x.fldRemark)
                                                                      select x).Count(),

                                                   //封冻天数
                                                   FrozenNum = (from x in g
                                                                where "封冻".Contains(x.fldRemark)
                                                                select x).Count(),
                                                   //汛期天数
                                                   FloodSeasonNum = (from x in g
                                                                     where "汛期".Contains(x.fldRemark)
                                                                     select x).Count(),
                                                   //仪器安装天数
                                                   InstallNum = (from x in g
                                                                 where "仪器安装".Contains(x.fldRemark)
                                                                 select x).Count(),
                                                   //其他天数
                                                   OtherNum = (from x in g
                                                               where !("断流".Contains(x.fldRemark) &&
                                                                   "停电".Contains(x.fldRemark) &&
                                                                   "封冻".Contains(x.fldRemark) &&
                                                                   "汛期".Contains(x.fldRemark) &&
                                                                   "仪器安装".Contains(x.fldRemark))
                                                               select x).Count(),
                                               }),
                                 //总断流天数
                                 StopTotalNum = (from x in list where "断流".Contains(x.fldRemark) select x).Count(),
                                 //断流的断面数
                                 StopSTNum = (from x in list where "断流".Contains(x.fldRemark) select x.fldRSCode).Distinct().Count(),
                                 //总停电天数
                                 PowerTotalNum = (from x in list where "停电".Contains(x.fldRemark) select x).Count(),
                                 //停电的断面数
                                 PowerSTNum = (from x in list where "停电".Contains(x.fldRemark) select x.fldRSCode).Distinct().Count(),
                                 //总封冻天数
                                 FrozenTotalNum = (from x in list where "封冻".Contains(x.fldRemark) select x).Count(),
                                 //封冻的断面数
                                 FrozenSTNum = (from x in list where "封冻".Contains(x.fldRemark) select x.fldRSCode).Distinct().Count(),
                                 //总汛期天数
                                 SeasonTotalNum = (from x in list where "汛期".Contains(x.fldRemark) select x).Count(),
                                 //汛期的断面数
                                 SeasonSTNum = (from x in list where "汛期".Contains(x.fldRemark) select x.fldRSCode).Distinct().Count(),
                                 //总仪器安装天数
                                 InstallTotalNum = (from x in list where "仪器安装".Contains(x.fldRemark) select x).Count(),
                                 //仪器安装的断面数
                                 InstallSTNum = (from x in list where "仪器安装".Contains(x.fldRemark) select x.fldRSCode).Distinct().Count(),
                                 //总其他天数
                                 OtherTotalNum = (from x in list
                                                  where !("断流".Contains(x.fldRemark) &&
                                                    "停电".Contains(x.fldRemark) &&
                                                    "封冻".Contains(x.fldRemark) &&
                                                    "汛期".Contains(x.fldRemark) &&
                                                    "仪器安装".Contains(x.fldRemark))
                                                  select x).Count(),
                                 //其他的断面数
                                 OtherSTNum = (from x in list
                                               where !("断流".Contains(x.fldRemark) &&
                                                    "停电".Contains(x.fldRemark) &&
                                                    "封冻".Contains(x.fldRemark) &&
                                                    "汛期".Contains(x.fldRemark) &&
                                                    "仪器安装".Contains(x.fldRemark))
                                               select x.fldRSCode).Distinct().Count(),
                             }).ToList().FirstOrDefault();


                if (query != null)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有保存数据！", "");
                }
            }
            catch (Exception e)
            {

                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }





        /// <summary>
        /// 异常数据统计参数实体
        /// </summary>
        public class Report_ExceptionStatistics_Info
        {
            /// <summary>
            /// 断面代码
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
        }
































        /// <summary>
        /// 创建者  ：刘勇军 
        /// 创建日期：2018-4-02
        /// 功能描述：重点断面水质周报上报
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Report_QualityWeekly(Report_QualityWeekly_Info info)
        {
            string result = string.Empty;

            List<string> ItemCodeParameter = info.fldItemCode.Split(',').ToList();
            try
            {

                List<Model.tblEQIW_R_HourData_Auto> list = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_HourData_Auto> list2 = new List<Model.tblEQIW_R_HourData_Auto>();

                List<Model.tblEQIW_R_Section> list_section = new List<Model.tblEQIW_R_Section>();

                List<Model.tblEQIW_R_Item> list_item = new List<Model.tblEQIW_R_Item>();

                List<Model.tblEQIW_R_DAQLTSTD> list_daqltstd = new List<Model.tblEQIW_R_DAQLTSTD>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    //查询小时值
                    list = (from x in db.tblEQIW_R_HourData_Auto select x).ToList();

                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询异常数据
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                select x).ToList();
                    }

                    //根据因子查询小时值
                    list = (from x in list
                            where ItemCodeParameter.Contains(x.fldItemCode)
                            select x).ToList();

                    foreach (var item in list)
                    {
                        item.fldDate = DateTime.Parse(item.fldYear + "-" + item.fldMonth + "-" + item.fldDay);
                    }

                    //根据时间查询小时值
                    list = (from x in list
                            where x.fldDate >= BeginDate &&
                            x.fldDate <= EndDate
                            select x).ToList();

                    //根据时间查询断面
                    list_section = (from x in db.tblEQIW_R_Section
                                    where x.fldYear == BeginDate.Year
                                    select x).ToList();

                    //查询因子
                    list_item = (from y in db.tblEQIW_R_Item select y).ToList();

                    //根据超标依据查询合格标准
                    list_daqltstd = (from y in db.tblEQIW_R_DAQLTSTD
                                     where y.fldEdition == info.fldEdition
                                     select y).ToList();

                    list2 = (from x in list select x).ToList();


                    list2 = (from x in list2
                             join y in list_daqltstd
                             on new
                             {
                                 x.fldItemCode

                             } equals new
                             {
                                 y.fldItemCode
                             }
                             where x.fldItemValue > y.fldST30
                             select x).ToList();

                }

                var query = (from x in list
                             group x by x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                             into g
                             select new
                             {
                                 //断面代码
                                 SectionCode = g.Key,
                                 //断面名称
                                 SectionName = (from x in list_section
                                                where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                                select x.fldRSName).FirstOrDefault(),
                                 //水系名称
                                 fldRName = (from x in list_section
                                             where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                             select x.fldRName).FirstOrDefault(),
                                 //断面属性
                                 SectionAttribute = GetAttribute((from x in list_section where g.Key == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode select x.fldSCategory).FirstOrDefault().ToString()),
                                 //因子集合
                                 ItemSet = (from y in g
                                            group y by y.fldItemCode
                                            into h
                                            select new
                                            {
                                                //因子代码
                                                ItemCode = h.Key,
                                                //因子名称
                                                ItemName = (from x in list_item
                                                            where h.Key == x.fldItemCode
                                                            select x.fldItemName).FirstOrDefault(),
                                                //因子值
                                                ItemValue = (from x in h
                                                             where h.Key == x.fldItemCode
                                                             select x.fldItemValue).ToList().Average()
                                            }),
                                 //水质类别
                                 WaterType = "",
                                 //执行标准
                                 Standard = info.fldEdition,
                                 //主要污染指标
                                 Contaminated = GetContaminated(list2, g.Key)
                             }).ToList();
                if (query.Count > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有保存数据！", "");
                }

            }
            catch (Exception e)
            {

                throw;
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 断面属性名称
        /// </summary>
        /// <param name="SA">断面属性值</param>
        /// <returns></returns>
        public string GetAttribute(string SA)
        {
            string ret = string.Empty;

            switch (SA)
            {
                case "0":
                    ret = "国控";
                    break;
                case "1":
                    ret = "省控";
                    break;
                case "2":
                    ret = "市控";
                    break;
                case "3":
                    ret = "县控";
                    break;
                case "6":
                    ret = "考核";
                    break;
                case "7":
                    ret = "外省";
                    break;
                case "8":
                    ret = "乡镇";
                    break;
                case "4":
                    ret = "其他";
                    break;
            }
            return ret;
        }


        /// <summary>
        /// 得到主要污染指标
        /// </summary>

        /// <returns></returns>
        public string GetContaminated(List<Model.tblEQIW_R_HourData_Auto> list, string SectionCode)
        {
            string ret = "";

            try
            {
                List<Model.tblEQIW_R_Item> list_item = new List<Model.tblEQIW_R_Item>();

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in list
                            where SectionCode == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                            select x).ToList();

                    list_item = (from x in db.tblEQIW_R_Item select x).ToList();

                    for (int i = 0; i < list.Count(); i++)
                    {
                        if (i == 0)
                        {
                            ret += (from x in list_item where x.fldItemCode == list[i].fldItemCode select x.fldItemName).FirstOrDefault();
                        }
                        else
                        {
                            ret += "、" + (from x in list_item where x.fldItemCode == list[i].fldItemCode select x.fldItemName).FirstOrDefault();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                ret = "";
            }
            return ret;
        }



        /// <summary>
        /// 重点断面水质周报上报
        /// </summary>
        public class Report_QualityWeekly_Info
        {
            /// <summary>
            /// 断面代码
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
            /// 超标依据
            /// </summary>
            public string fldEdition { get; set; }
            /// <summary>
            /// 因子代码集合
            /// </summary>
            public string fldItemCode { get; set; }
        }






















        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-4-8
        /// 功能描述：各水质类别个数及所占比例报表
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Report_StageCountAndScale(Report_StageCountAndScale_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@EBeginDate",info.EBeginDate),
                    new SqlParameter("@EEndDate",info.EEndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@IsTotal",info.IsTotal),
                    new SqlParameter("@IsDetail",info.IsDetail),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@Para1ID",info.Para1ID),
                    new SqlParameter("@Para2ID",info.Para2ID),
                    new SqlParameter("@Source",info.Source),
                    new SqlParameter("@CalculateID",info.CalculateID)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_Apprise_For_Auto", paras.ToList(), null, "dbReport");

                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }









        public class Report_StageCountAndScale_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string EBeginDate { get; set; }

            public string EEndDate { get; set; }

            public string fldRSC { get; set; }

            public string fldRSCode { get; set; }

            public string fldStandardName { get; set; }

            public int fldLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int IsPre { get; set; }

            public int IsYear { get; set; }

            public int IsTotal { get; set; }

            public int IsDetail { get; set; }

            public int AppriseID { get; set; }

            public int SpaceID { get; set; }

            public int STatType { get; set; }

            public int Para1ID { get; set; }

            public int Para2ID { get; set; }

            public int Source { get; set; }

            public int CalculateID { get; set; }
        }






















        /// <summary>
        /// 创建者  ：吕荣誉
        /// 创建日期：2018-4-10
        /// 功能描述：访问自动存储过程
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage Report_usp_tblEQIW_R_Report_Apprise_For_Auto(Report_usp_tblEQIW_R_Report_Apprise_For_Auto_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = new SqlParameter[]
                {
                    new SqlParameter("@TimeType",info.TimeType),
                    new SqlParameter("@BeginDate",info.BeginDate),
                    new SqlParameter("@EndDate",info.EndDate),
                    new SqlParameter("@EBeginDate",info.EBeginDate),
                    new SqlParameter("@EEndDate",info.EEndDate),
                    new SqlParameter("@fldRSC",info.fldRSC),
                    new SqlParameter("@fldRSCode",info.fldRSCode),
                    new SqlParameter("@fldStandardName",info.fldStandardName),
                    new SqlParameter("@fldLevel",info.fldLevel),
                    new SqlParameter("@fldItemCode",info.fldItemCode),
                    new SqlParameter("@DecCarry",info.DecCarry),
                    new SqlParameter("@IsPre",info.IsPre),
                    new SqlParameter("@IsYear",info.IsYear),
                    new SqlParameter("@IsTotal",info.IsTotal),
                    new SqlParameter("@IsDetail",info.IsDetail),
                    new SqlParameter("@AppriseID",info.AppriseID),
                    new SqlParameter("@SpaceID",info.SpaceID),
                    new SqlParameter("@STatType",info.STatType),
                    new SqlParameter("@Para1ID",info.Para1ID),
                    new SqlParameter("@Para2ID",info.Para2ID),
                    new SqlParameter("@Source",info.Source),
                    new SqlParameter("@CalculateID",info.CalculateID)
                };

                dt = rule.RunProcedure_V2("usp_tblEQIW_R_Report_Apprise_For_Auto", paras.ToList(), null, "dbReport");


                result = rule.JsonStr("ok", "", dt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        public class Report_usp_tblEQIW_R_Report_Apprise_For_Auto_Info
        {
            public string TimeType { get; set; }

            public string BeginDate { get; set; }

            public string EndDate { get; set; }

            public string EBeginDate { get; set; }

            public string EEndDate { get; set; }

            public string fldRSC { get; set; }

            public string fldRSCode { get; set; }

            public string fldStandardName { get; set; }

            public int fldLevel { get; set; }

            public string fldItemCode { get; set; }

            public string DecCarry { get; set; }

            public int IsPre { get; set; }

            public int IsYear { get; set; }

            public int IsTotal { get; set; }

            public int IsDetail { get; set; }

            public int AppriseID { get; set; }

            public int SpaceID { get; set; }

            public int STatType { get; set; }

            public int Para1ID { get; set; }

            public int Para2ID { get; set; }

            public int Source { get; set; }

            public int CalculateID { get; set; }
        }








        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-05-04
        /// 功能描述：考核预警分析
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEarlyWarningAnalysis(GetEarlyWarningAnalysis_Info info)
        {
            string result = string.Empty;
            try
            {
                List<string> ItemCode = new List<string>();

                List<Model.tblEQIW_R_Basedata> list = new List<Model.tblEQIW_R_Basedata>();

                List<Model.tblEQIW_R_Basedata> list_2 = new List<Model.tblEQIW_R_Basedata>();

                List<Model.tblEQIW_R_DAQLTSTD> list_DAQ = new List<Model.tblEQIW_R_DAQLTSTD>();

                List<Model.tblEQIW_R_Auto_Itemstarget> list_star = new List<Model.tblEQIW_R_Auto_Itemstarget>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                DateTime LBeginDate = DateTime.Parse(info.fldBeginDate).AddYears(-1);
                DateTime LEndDate = DateTime.Parse(info.fldEndDate).AddYears(-1);

                if (info.fldItemCode != "All")
                {
                    ItemCode = info.fldItemCode.Split(',').ToList();
                }

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblEQIW_R_Basedata
                            select x).ToList();

                    if (info.fldSTCode != "-1")
                    {
                        //根据断面代码查询
                        list = (from x in list
                                where info.fldSTCode.Contains(x.fldSTCode)
                                select x).ToList();
                    }

                    if (info.fldItemCode != "All")
                    {
                        //根据因子代码查询
                        list = (from x in list
                                where ItemCode.Contains(x.fldItemCode)
                                select x).ToList();
                    }

                    list_2 = (from x in list
                              where DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) >= LBeginDate &&
                             DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) <= LEndDate
                              select x).ToList();

                    //根据时间查询
                    list = (from x in list
                            where DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) >= BeginDate &&
                           DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) <= EndDate
                            select x).ToList();

                    list_star = (from x in db.tblEQIW_R_Auto_Itemstarget
                                 where ItemCode.Contains(x.fldItemCode)
                                 select x).ToList();

                    list_DAQ = (from x in db.tblEQIW_R_DAQLTSTD
                                where x.fldEdition == "GB 3838-2002" && ItemCode.Contains(x.fldItemCode)
                                select x).ToList();

                }

                var query = (from x in list
                             group x by x.fldYear + "-" + x.fldMonth
                             into g
                             select new
                             {
                                 g.Key,
                                 //累计均值
                                 AccumulativeAVG = (from y in list
                                                    where y.fldYear + "-" + y.fldMonth == g.Key
                                                    select y).Count() > 0 ? (from y in list
                                                                             where y.fldYear + "-" + y.fldMonth == g.Key
                                                                             select y.fldItemValue).Average() : 0,

                                 //去年同期均值
                                 LastAccumulativeAVG = (from y in list_2
                                                        where DateTime.Parse(y.fldYear + "-" + y.fldMonth) == DateTime.Parse(g.Key).AddYears(-1)
                                                        select y).Count() > 0 ? (from y in list_2
                                                                                 where DateTime.Parse(y.fldYear + "-" + y.fldMonth) == DateTime.Parse(g.Key).AddYears(-1)
                                                                                 select y.fldItemValue).Average() : 0,

                                 //标准值
                                 StandardValue = (from y in list_DAQ where y.fldItemCode == g.FirstOrDefault().fldItemCode select y.fldST30).FirstOrDefault(),

                                 //预期达标值
                                 ExpectedValue = (from y in list_star where y.fldRSCode == g.FirstOrDefault().fldRSCode select y.fldItemTarget).FirstOrDefault()
                             });

                if (query.Count() > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
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
        public class GetEarlyWarningAnalysis_Info
        {
            /// <summary>
            /// 断面代码
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
            /// 因子代码
            /// </summary>
            public string fldItemCode { get; set; }
        }




        /// <summary>
        /// 创建者  ：刘勇军
        /// 创建日期：2018-06-08
        /// 功能描述：考核预警分析根据断面RSCode查询
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetEarlyWarningAnalysisByRSCode(GetEarlyWarningAnalysisByRSCode_Info info)
        {
            string result = string.Empty;
            try
            {
                List<string> ItemCode = new List<string>();

                List<Model.tblEQIW_R_Basedata> list = new List<Model.tblEQIW_R_Basedata>();

                List<Model.tblEQIW_R_Basedata> list_2 = new List<Model.tblEQIW_R_Basedata>();

                List<Model.tblEQIW_R_DAQLTSTD> list_DAQ = new List<Model.tblEQIW_R_DAQLTSTD>();

                List<Model.tblEQIW_R_Auto_Itemstarget> list_star = new List<Model.tblEQIW_R_Auto_Itemstarget>();

                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                DateTime LBeginDate = DateTime.Parse(info.fldBeginDate).AddYears(-1);
                DateTime LEndDate = DateTime.Parse(info.fldEndDate).AddYears(-1);

                if (info.fldItemCode != "All")
                {
                    ItemCode = info.fldItemCode.Split(',').ToList();
                }

                using (Model.EntityContext db = new Model.EntityContext())
                {
                    list = (from x in db.tblEQIW_R_Basedata
                            select x).ToList();

                    if (info.fldRSCode != "-1")
                    {
                        //根据断面代码查询
                        list = (from x in list
                                where info.fldRSCode.Contains(x.fldRSCode)
                                select x).ToList();
                    }

                    if (info.fldItemCode != "All")
                    {
                        //根据因子代码查询
                        list = (from x in list
                                where ItemCode.Contains(x.fldItemCode)
                                select x).ToList();
                    }

                    list_2 = (from x in list
                              where DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) >= LBeginDate &&
                             DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) <= LEndDate
                              select x).ToList();

                    //根据时间查询
                    list = (from x in list
                            where DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) >= BeginDate &&
                           DateTime.Parse(x.fldYear + "-" + x.fldMonth + "-" + x.fldDay) <= EndDate
                            select x).ToList();

                    list_star = (from x in db.tblEQIW_R_Auto_Itemstarget
                                 where ItemCode.Contains(x.fldItemCode)
                                 select x).ToList();

                    list_DAQ = (from x in db.tblEQIW_R_DAQLTSTD
                                where x.fldEdition == "GB 3838-2002" && ItemCode.Contains(x.fldItemCode)
                                select x).ToList();

                }

                var query = (from x in list
                             group x by x.fldYear + "-" + x.fldMonth
                             into g
                             select new
                             {
                                 g.Key,
                                 //累计均值
                                 AccumulativeAVG = (from y in list
                                                    where y.fldYear + "-" + y.fldMonth == g.Key
                                                    select y).Count() > 0 ? (from y in list
                                                                             where y.fldYear + "-" + y.fldMonth == g.Key
                                                                             select y.fldItemValue).Average() : 0,

                                 //去年同期均值
                                 LastAccumulativeAVG = (from y in list_2
                                                        where DateTime.Parse(y.fldYear + "-" + y.fldMonth) == DateTime.Parse(g.Key).AddYears(-1)
                                                        select y).Count() > 0 ? (from y in list_2
                                                                                 where DateTime.Parse(y.fldYear + "-" + y.fldMonth) == DateTime.Parse(g.Key).AddYears(-1)
                                                                                 select y.fldItemValue).Average() : 0,

                                 //标准值
                                 StandardValue = (from y in list_DAQ where y.fldItemCode == g.FirstOrDefault().fldItemCode select y.fldST30).FirstOrDefault(),

                                 //预期达标值
                                 ExpectedValue = (from y in list_star where y.fldRSCode == g.FirstOrDefault().fldRSCode select y.fldItemTarget).FirstOrDefault()
                             });

                if (query.Count() > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
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
        public class GetEarlyWarningAnalysisByRSCode_Info
        {
            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldRSCode { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// 因子代码
            /// </summary>
            public string fldItemCode { get; set; }
        }
    }
}
