using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.EQISO
{
    public class GetEQISO_Data_MiddleController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-29
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData(Info info)
        {
            string result = null;
            try
            {
                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);

                DateTime EndDate = DateTime.Parse(info.fldEndDate);



                if (info.type == "SpaceID0")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQISO_SpaceID0_Midd> query = new List<tblEQISO_SpaceID0_Midd>();
                        List<tblEQISO_SpaceID0_Item_Midd> query_Item = new List<tblEQISO_SpaceID0_Item_Midd>();

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQISO_SpaceID0_Midd
                                     where x.fldDate >= BeginDate &&
                                     x.fldDate <= EndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQISO_SpaceID0_Midd
                                     where x.fldDate >= BeginDate &&
                                     x.fldDate <= EndDate &&
                                     info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode + "." + x.fldPCode)
                                     select x).ToList();
                        }




                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQISO_SpaceID0_Item_Midd
                                          on x.fldAutoID equals y.fldFKID
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
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQISO_SpaceID0_Midd> query2 = new List<tblEQISO_SpaceID0_Midd>();
                            List<tblEQISO_SpaceID0_Item_Midd> query_Item2 = new List<tblEQISO_SpaceID0_Item_Midd>();

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQISO_SpaceID0_Midd
                                          where x.fldDate >= BeginDate &&
                                          x.fldDate <= EndDate
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQISO_SpaceID0_Midd
                                          where x.fldDate >= BeginDate &&
                                          x.fldDate <= EndDate &&
                                          info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode + "." + x.fldPCode)
                                          select x).ToList();
                            }




                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQISO_SpaceID0_Item_Midd
                                               on x.fldAutoID equals y.fldFKID
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





                if (info.type == "SpaceID1")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQISO_SpaceID1_Midd> query = new List<tblEQISO_SpaceID1_Midd>();
                        List<tblEQISO_SpaceID1_Item_Midd> query_Item = new List<tblEQISO_SpaceID1_Item_Midd>();

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQISO_SpaceID1_Midd
                                     where x.fldYear == info.fldYear
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQISO_SpaceID1_Midd
                                     where x.fldYear == info.fldYear &&
                                     info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                     select x).ToList();
                        }




                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQISO_SpaceID1_Item_Midd
                                          on x.fldAutoID equals y.fldFKID
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
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQISO_SpaceID1_Midd> query2 = new List<tblEQISO_SpaceID1_Midd>();
                            List<tblEQISO_SpaceID1_Item_Midd> query_Item2 = new List<tblEQISO_SpaceID1_Item_Midd>();

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQISO_SpaceID1_Midd
                                          where x.fldYear == info.fldYear
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQISO_SpaceID1_Midd
                                          where x.fldYear == info.fldYear &&
                                          info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                          select x).ToList();
                            }



                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQISO_SpaceID1_Item_Midd
                                               on x.fldAutoID equals y.fldFKID
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





                if (info.type == "SpaceID2")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQISO_SpaceID2_Midd> query = new List<tblEQISO_SpaceID2_Midd>();
                        List<tblEQISO_SpaceID2_Item_Midd> query_Item = new List<tblEQISO_SpaceID2_Item_Midd>();

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQISO_SpaceID2_Midd
                                     where x.fldYear == info.fldYear
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQISO_SpaceID2_Midd
                                     where x.fldYear == info.fldYear &&
                                     info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                     select x).ToList();
                        }




                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQISO_SpaceID2_Item_Midd
                                          on x.fldAutoID equals y.fldFKID
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
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQISO_SpaceID2_Midd> query2 = new List<tblEQISO_SpaceID2_Midd>();
                            List<tblEQISO_SpaceID2_Item_Midd> query_Item2 = new List<tblEQISO_SpaceID2_Item_Midd>();

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQISO_SpaceID2_Midd
                                          where x.fldYear == info.fldYear
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQISO_SpaceID2_Midd
                                          where x.fldYear == info.fldYear &&
                                          info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                          select x).ToList();
                            }



                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQISO_SpaceID2_Item_Midd
                                               on x.fldAutoID equals y.fldFKID
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





                if (info.type == "SpaceID3")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQISO_SpaceID3_Midd> query;

                        query = (from x in db.tblEQISO_SpaceID3_Midd
                                 select x).ToList();

                        ReturnData3 rd = new ReturnData3();

                        rd.dangqi = query;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQISO_SpaceID3_Midd> query2;

                            query2 = (from x in db.tblEQISO_SpaceID3_Midd
                                      select x).ToList();

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }








                if (info.type == "SpaceID4")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQISO_SpaceID4_Midd> query;

                        query = (from x in db.tblEQISO_SpaceID4_Midd
                                 where info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                 select x).ToList();

                        ReturnData4 rd = new ReturnData4();

                        rd.dangqi = query;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQISO_SpaceID4_Midd> query2;

                            query2 = (from x in db.tblEQISO_SpaceID4_Midd
                                      where info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                      select x).ToList();

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }









                if (info.type == "SpaceID5")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQISO_SpaceID5_Midd> query = new List<tblEQISO_SpaceID5_Midd>();
                        List<tblEQISO_SpaceID5_Item_Midd> query_Item = new List<tblEQISO_SpaceID5_Item_Midd>();

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQISO_SpaceID5_Midd
                                     where x.fldYear == info.fldYear
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQISO_SpaceID5_Midd
                                     where x.fldYear == info.fldYear &&
                                     info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                     select x).ToList();
                        }




                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQISO_SpaceID5_Item_Midd
                                          on x.fldAutoID equals y.fldFKID
                                          select y).ToList();

                            if (info.fldItemCode != "All")
                            {
                                string[] ItemCodeList = info.fldItemCode.Split(',');

                                query_Item = (from x in query_Item
                                              where ItemCodeList.Contains(x.fldItemCode)
                                              select x).ToList();
                            }
                        }


                        ReturnData5 rd = new ReturnData5();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQISO_SpaceID5_Midd> query2 = new List<tblEQISO_SpaceID5_Midd>();
                            List<tblEQISO_SpaceID5_Item_Midd> query_Item2 = new List<tblEQISO_SpaceID5_Item_Midd>();

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQISO_SpaceID5_Midd
                                          where x.fldYear == info.fldYear
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQISO_SpaceID5_Midd
                                          where x.fldYear == info.fldYear &&
                                          info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldEntCode)
                                          select x).ToList();
                            }



                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQISO_SpaceID5_Item_Midd
                                               on x.fldAutoID equals y.fldFKID
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




                if (info.type == "SpaceID6")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQISO_SpaceID6_Midd> query;

                        query = (from x in db.tblEQISO_SpaceID6_Midd
                                 select x).ToList();

                        ReturnData6 rd = new ReturnData6();

                        rd.dangqi = query;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQISO_SpaceID6_Midd> query2;

                            query2 = (from x in db.tblEQISO_SpaceID6_Midd
                                      select x).ToList();


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
            /// “SpaceID0”：原始数据表
            /// “SpaceID1”：基本统计表
            /// “SpaceID2”：指数统计表
            /// “SpaceID3”：项目各级别统计
            /// “SpaceID4”：污染指数统计
            /// “SpaceID5”：污染级别统计表
            /// “SpaceID6”：土壤质量状况评价
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 时间类型：
            /// “month”、“sea”、“year”
            /// </summary>
            public string fldTimeType { get; set; }

            /// <summary>
            /// 年份
            /// </summary>
            public string fldYear { get; set; }

            /// <summary>
            /// 是否返回同期数据
            /// “0”：不返回
            /// “1”：返回
            /// </summary>
            public string IsYear { get; set; }


            /// <summary>
            /// 城市代码
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
            /// 当不传此参数，默认为null，即不查询因子。
            /// 需要所有因子，传值“All”
            /// 需要部分因子，传值“301,302”类似格式
            /// </summary>
            public string fldItemCode { get; set; }


            /// <summary>
            /// 0:采样地、1：监测类型、2：年份、3：项目、4：点位、5：城市、6：所有行政区
            /// </summary>
            public string AppriseID { get; set; }

            /// <summary>
            /// 0:有采样地信息，例如：武汉
            /// </summary>
            public string STatType { get; set; }

        }





        /// <summary>
        /// SpaceID0
        /// </summary>
        public class ReturnData
        {
            public List<tblEQISO_SpaceID0_Midd> dangqi { get; set; }

            public List<tblEQISO_SpaceID0_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQISO_SpaceID0_Midd> tongqi { get; set; }

            public List<tblEQISO_SpaceID0_Item_Midd> tongqi_Item { get; set; }
        }




        /// <summary>
        /// SpaceID1
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQISO_SpaceID1_Midd> dangqi { get; set; }

            public List<tblEQISO_SpaceID1_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQISO_SpaceID1_Midd> tongqi { get; set; }

            public List<tblEQISO_SpaceID1_Item_Midd> tongqi_Item { get; set; }
        }



        /// <summary>
        /// SpaceID2
        /// </summary>
        public class ReturnData2
        {
            public List<tblEQISO_SpaceID2_Midd> dangqi { get; set; }

            public List<tblEQISO_SpaceID2_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQISO_SpaceID2_Midd> tongqi { get; set; }

            public List<tblEQISO_SpaceID2_Item_Midd> tongqi_Item { get; set; }
        }






        /// <summary>
        /// SpaceID3
        /// </summary>
        public class ReturnData3
        {
            public List<tblEQISO_SpaceID3_Midd> dangqi { get; set; }

            public List<tblEQISO_SpaceID3_Midd> tongqi { get; set; }
        }






        /// <summary>
        /// SpaceID4
        /// </summary>
        public class ReturnData4
        {
            public List<tblEQISO_SpaceID4_Midd> dangqi { get; set; }

            public List<tblEQISO_SpaceID4_Midd> tongqi { get; set; }
        }





        /// <summary>
        /// SpaceID5
        /// </summary>
        public class ReturnData5
        {
            public List<tblEQISO_SpaceID5_Midd> dangqi { get; set; }

            public List<tblEQISO_SpaceID5_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQISO_SpaceID5_Midd> tongqi { get; set; }

            public List<tblEQISO_SpaceID5_Item_Midd> tongqi_Item { get; set; }
        }





        /// <summary>
        /// SpaceID6
        /// </summary>
        public class ReturnData6
        {
            public List<tblEQISO_SpaceID6_Midd> dangqi { get; set; }

            public List<tblEQISO_SpaceID6_Midd> tongqi { get; set; }
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
