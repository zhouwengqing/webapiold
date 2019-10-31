using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqia.Eqia_r
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIA_R_Data_MiddleController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-21
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData(Info info)
        {
            string result = null;
            try
            {
                if (info.type == "City_DayStat")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIA_R_City_DayStat_Midd> query = new List<tblEQIA_R_City_DayStat_Midd>();
                        List<tblEQIA_R_City_DayStat_Item_Midd> query_Item = new List<tblEQIA_R_City_DayStat_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_R_City_DayStat_Midd
                                     where x.fldAppDate >= BeginDate &&
                                     x.fldAppDate <= EndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIA_R_City_DayStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     x.fldAppDate >= BeginDate &&
                                     x.fldAppDate <= EndDate
                                     select x).ToList();
                        }

                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIA_R_City_DayStat_Item_Midd
                                          on new { x.fldSTCode, x.fldAppDate }
                                          equals new { y.fldSTCode, y.fldAppDate }
                                          select y).ToList();

                            if (info.fldItemCode != "All")
                            {
                                string[] ItemCodeList = info.fldItemCode.Split(',');

                                query_Item = (from x in query_Item
                                              where ItemCodeList.Contains(x.fldItemCode)
                                              select x).ToList();
                            }
                        }


                        ReturnData rd = new ReturnData();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_R_City_DayStat_Midd> query2 = new List<tblEQIA_R_City_DayStat_Midd>();
                            List<tblEQIA_R_City_DayStat_Item_Midd> query_Item2 = new List<tblEQIA_R_City_DayStat_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);


                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_R_City_DayStat_Midd
                                          where x.fldAppDate >= BeginDate &&
                                          x.fldAppDate <= EndDate
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIA_R_City_DayStat_Midd
                                          where info.fldSTCode.Contains(x.fldSTCode) &&
                                          x.fldAppDate >= BeginDate &&
                                          x.fldAppDate <= EndDate
                                          select x).ToList();
                            }




                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query
                                               join y in db.tblEQIA_R_City_DayStat_Item_Midd
                                               on new { x.fldSTCode, x.fldAppDate }
                                               equals new { y.fldSTCode, y.fldAppDate }
                                               select y).ToList();

                                if (info.fldItemCode != "All")
                                {
                                    string[] ItemCodeList = info.fldItemCode.Split(',');

                                    query_Item2 = (from x in query_Item2
                                                   where ItemCodeList.Contains(x.fldItemCode)
                                                   select x).ToList();
                                }
                            }

                            rd.tongqi = query2;
                            rd.tongqi_Item = query_Item2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }


                if (info.type == "City_TotalDateStat")
                {

                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIA_R_City_TotalDateStat_Midd> query = new List<tblEQIA_R_City_TotalDateStat_Midd>();
                        List<tblEQIA_R_City_TotalDateStat_Item_Midd> query_Item = new List<tblEQIA_R_City_TotalDateStat_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_R_City_TotalDateStat_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate)
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIA_R_City_TotalDateStat_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate) &&
                                     info.fldSTCode.Contains(x.fldSTCode)
                                     select x).ToList();
                        }



                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIA_R_City_TotalDateStat_Item_Midd
                                          on new { x.fldSTCode, x.fldAppDate, x.fldTimeType }
                                          equals new { y.fldSTCode, y.fldAppDate, y.fldTimeType }
                                          select y).ToList();

                            if (info.fldItemCode != "All")
                            {
                                string[] ItemCodeList = info.fldItemCode.Split(',');

                                query_Item = (from x in query_Item
                                              where ItemCodeList.Contains(x.fldItemCode)
                                              select x).ToList();
                            }
                        }



                        ReturnData1 rd = new ReturnData1();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_R_City_TotalDateStat_Midd> query2 = new List<tblEQIA_R_City_TotalDateStat_Midd>();
                            List<tblEQIA_R_City_TotalDateStat_Item_Midd> query_Item2 = new List<tblEQIA_R_City_TotalDateStat_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_R_City_TotalDateStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate)
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIA_R_City_TotalDateStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          info.fldSTCode.Contains(x.fldSTCode)
                                          select x).ToList();
                            }

                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query
                                               join y in db.tblEQIA_R_City_TotalDateStat_Item_Midd
                                               on new { x.fldSTCode, x.fldAppDate, x.fldTimeType }
                                               equals new { y.fldSTCode, y.fldAppDate, y.fldTimeType }
                                               select y).ToList();

                                if (info.fldItemCode != "All")
                                {
                                    string[] ItemCodeList = info.fldItemCode.Split(',');

                                    query_Item2 = (from x in query_Item2
                                                   where ItemCodeList.Contains(x.fldItemCode)
                                                   select x).ToList();
                                }
                            }

                            rd.tongqi = query2;
                            rd.tongqi_Item = query_Item2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }

                }


                if (info.type == "Point_DayStat")
                {

                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIA_R_Point_DayStat_Midd> query = new List<tblEQIA_R_Point_DayStat_Midd>();
                        List<tblEQIA_R_Point_DayStat_Item_Midd> query_Item = new List<tblEQIA_R_Point_DayStat_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);



                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_R_Point_DayStat_Midd
                                     where x.fldAppDate >= BeginDate &&
                                     x.fldAppDate <= EndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIA_R_Point_DayStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                     x.fldAppDate >= BeginDate &&
                                     x.fldAppDate <= EndDate
                                     select x).ToList();
                        }



                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIA_R_Point_DayStat_Item_Midd
                                          on new { x.fldSTCode, x.fldPCode, x.fldAppDate }
                                          equals new { y.fldSTCode, y.fldPCode, y.fldAppDate }
                                          select y).ToList();

                            if (info.fldItemCode != "All")
                            {
                                string[] ItemCodeList = info.fldItemCode.Split(',');

                                query_Item = (from x in query_Item
                                              where ItemCodeList.Contains(x.fldItemCode)
                                              select x).ToList();
                            }
                        }



                        ReturnData2 rd = new ReturnData2();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_R_Point_DayStat_Midd> query2 = new List<tblEQIA_R_Point_DayStat_Midd>();
                            List<tblEQIA_R_Point_DayStat_Item_Midd> query_Item2 = new List<tblEQIA_R_Point_DayStat_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_R_Point_DayStat_Midd
                                          where x.fldAppDate >= BeginDate &&
                                          x.fldAppDate <= EndDate
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIA_R_Point_DayStat_Midd
                                          where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                          x.fldAppDate >= BeginDate &&
                                          x.fldAppDate <= EndDate
                                          select x).ToList();
                            }

                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query
                                               join y in db.tblEQIA_R_Point_DayStat_Item_Midd
                                               on new { x.fldSTCode, x.fldPCode, x.fldAppDate }
                                               equals new { y.fldSTCode, y.fldPCode, y.fldAppDate }
                                               select y).ToList();

                                if (info.fldItemCode != "All")
                                {
                                    string[] ItemCodeList = info.fldItemCode.Split(',');

                                    query_Item2 = (from x in query_Item2
                                                   where ItemCodeList.Contains(x.fldItemCode)
                                                   select x).ToList();
                                }
                            }

                            rd.tongqi = query2;
                            rd.tongqi_Item = query_Item2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }


                if (info.type == "Point_TotalDateStat")
                {

                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIA_R_Point_TotalDateStat_Midd> query = new List<tblEQIA_R_Point_TotalDateStat_Midd>();
                        List<tblEQIA_R_Point_TotalDateStat_Item_Midd> query_Item = new List<tblEQIA_R_Point_TotalDateStat_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);


                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_R_Point_TotalDateStat_Midd
                                     where list.Contains(x.fldAppDate)
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIA_R_Point_TotalDateStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                     list.Contains(x.fldAppDate)
                                     select x).ToList();
                        }



                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIA_R_Point_TotalDateStat_Item_Midd
                                          on new { x.fldSTCode, x.fldPCode, x.fldAppDate }
                                          equals new { y.fldSTCode, y.fldPCode, y.fldAppDate }
                                          select y).ToList();

                            if (info.fldItemCode != "All")
                            {
                                string[] ItemCodeList = info.fldItemCode.Split(',');

                                query_Item = (from x in query_Item
                                              where ItemCodeList.Contains(x.fldItemCode)
                                              select x).ToList();
                            }
                        }



                        ReturnData3 rd = new ReturnData3();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_R_Point_TotalDateStat_Midd> query2 = new List<tblEQIA_R_Point_TotalDateStat_Midd>();
                            List<tblEQIA_R_Point_TotalDateStat_Item_Midd> query_Item2 = new List<tblEQIA_R_Point_TotalDateStat_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_R_Point_TotalDateStat_Midd
                                          where list.Contains(x.fldAppDate)
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIA_R_Point_TotalDateStat_Midd
                                          where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                          list.Contains(x.fldAppDate)
                                          select x).ToList();
                            }

                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query
                                               join y in db.tblEQIA_R_Point_TotalDateStat_Item_Midd
                                               on new { x.fldSTCode, x.fldPCode, x.fldAppDate }
                                               equals new { y.fldSTCode, y.fldPCode, y.fldAppDate }
                                               select y).ToList();

                                if (info.fldItemCode != "All")
                                {
                                    string[] ItemCodeList = info.fldItemCode.Split(',');

                                    query_Item2 = (from x in query_Item2
                                                   where ItemCodeList.Contains(x.fldItemCode)
                                                   select x).ToList();
                                }
                            }

                            rd.tongqi = query2;
                            rd.tongqi_Item = query_Item2;
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
            /// “City_DayStat”，城市日数据
            /// “City_TotalDateStat”，城市表
            /// “Point_DayStat”，点位日数据
            /// “Point_TotalDateStat”，点位表
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 时间类型：
            /// “month”、“sea”、“halfyear”、“year”
            /// </summary>
            public string fldTimeType { get; set; }


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

            /// <summary>
            /// 当不传此参数，默认为null，即不查询因子。
            /// 需要所有因子，传值“All”
            /// 需要部分因子，传值“301,302”类似格式
            /// </summary>
            public string fldItemCode { get; set; }


        }

        /// <summary>
        /// “City_DayStat”
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIA_R_City_DayStat_Midd> dangqi { get; set; }

            public List<tblEQIA_R_City_DayStat_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIA_R_City_DayStat_Midd> tongqi { get; set; }

            public List<tblEQIA_R_City_DayStat_Item_Midd> tongqi_Item { get; set; }
        }

        /// <summary>
        /// “City_TotalDateStat”
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQIA_R_City_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIA_R_City_TotalDateStat_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIA_R_City_TotalDateStat_Midd> tongqi { get; set; }

            public List<tblEQIA_R_City_TotalDateStat_Item_Midd> tongqi_Item { get; set; }
        }




        /// <summary>
        /// “Point_DayStat”
        /// </summary>
        public class ReturnData2
        {
            public List<tblEQIA_R_Point_DayStat_Midd> dangqi { get; set; }

            public List<tblEQIA_R_Point_DayStat_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIA_R_Point_DayStat_Midd> tongqi { get; set; }

            public List<tblEQIA_R_Point_DayStat_Item_Midd> tongqi_Item { get; set; }
        }





        /// <summary>
        /// “Point_TotalDateStat”
        /// </summary>
        public class ReturnData3
        {
            public List<tblEQIA_R_Point_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIA_R_Point_TotalDateStat_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIA_R_Point_TotalDateStat_Midd> tongqi { get; set; }

            public List<tblEQIA_R_Point_TotalDateStat_Item_Midd> tongqi_Item { get; set; }
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
