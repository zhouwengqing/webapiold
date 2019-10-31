using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.V_eqiw_d
{
    public class GetV_EQIW_D_Data_MiddleController : ApiController
    {



        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-11-30
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData(Info info)
        {
            string result = null;
            try
            {

                if (info.type == "ItemOver")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblV_EQIW_D_ItemOver_Midd> query;

                        query = (from x in db.tblV_EQIW_D_ItemOver_Midd
                                 where x.fldTimeType == info.fldTimeType &&
                                 x.fldDate.Contains(info.fldYear)
                                 select x).ToList();

                        ReturnData rd = new ReturnData();

                        rd.dangqi = query;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblV_EQIW_D_ItemOver_Midd> query2;

                            query2 = (from x in db.tblV_EQIW_D_ItemOver_Midd
                                      where x.fldTimeType == info.fldTimeType &&
                                      x.fldDate.Contains(year.ToString())
                                      select x).ToList();

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }


                if (info.type == "CityItemOver")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblV_EQIW_D_CityItemOver_Midd> query;

                        query = (from x in db.tblV_EQIW_D_CityItemOver_Midd
                                 where x.fldTimeType == info.fldTimeType &&
                                 x.fldDate.Contains(info.fldYear) &&
                                 info.fldSTCode.Contains(x.fldSTCode)
                                 select x).ToList();

                        ReturnData2 rd = new ReturnData2();

                        rd.dangqi = query;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblV_EQIW_D_CityItemOver_Midd> query2;

                            query2 = (from x in db.tblV_EQIW_D_CityItemOver_Midd
                                      where x.fldTimeType == info.fldTimeType &&
                                      x.fldDate.Contains(year.ToString()) &&
                                      info.fldSTCode.Contains(x.fldSTCode)
                                      select x).ToList();

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }




                }


                if (info.type == "BaseData")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_D_BaseData_Midd> query;
                        List<tblEQIW_D_BaseData_Item_Midd> query_Item;

                        DateTime fldBeginDate = DateTime.Parse(info.fldBeginDate);

                        DateTime fldEndDate = DateTime.Parse(info.fldEndDate);

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIW_D_BaseData_Midd
                                     where x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIW_D_BaseData_Midd
                                     where x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).ToList();
                        }


                        query_Item = (from x in query
                                      join y in db.tblEQIW_D_BaseData_Item_Midd
                                      on x.fldAutoID equals y.fldFKID
                                      select y).ToList();

                        ReturnData3 rd = new ReturnData3();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;


                        result = rule.JsonStr("ok", "", rd);
                    }




                }


                if (info.type == "DayOfData")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_D_DayOfData_Midd> query;
                        List<tblEQIW_D_DayOfData_Item_Midd> query_Item;

                        DateTime fldBeginDate = DateTime.Parse(info.fldBeginDate);

                        DateTime fldEndDate = DateTime.Parse(info.fldEndDate);

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIW_D_DayOfData_Midd
                                     where DateTime.Parse(x.fldDate) >= fldBeginDate &&
                                     DateTime.Parse(x.fldDate) <= fldEndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIW_D_DayOfData_Midd
                                     where DateTime.Parse(x.fldDate) >= fldBeginDate &&
                                     DateTime.Parse(x.fldDate) <= fldEndDate
                                     select x).ToList();
                        }


                        query_Item = (from x in query
                                      join y in db.tblEQIW_D_DayOfData_Item_Midd
                                      on x.fldAutoID equals y.fldFKID
                                      select y).ToList();

                        ReturnData4 rd = new ReturnData4();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;


                        result = rule.JsonStr("ok", "", rd);
                    }








                }


                if (info.type == "YearBook")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblV_EQIW_D_YearBook_Midd> query = new List<tblV_EQIW_D_YearBook_Midd>();
                        List<tblV_EQIW_D_YearBook_Item_Midd> query_Item = new List<tblV_EQIW_D_YearBook_Item_Midd>();

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblV_EQIW_D_YearBook_Midd
                                     where x.STatType == info.STatType &&
                                     x.fldTimeType == info.fldTimeType
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblV_EQIW_D_YearBook_Midd
                                     where x.STatType == info.STatType &&
                                     x.fldTimeType == info.fldTimeType &&
                                     info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                     select x).ToList();
                        }

                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblV_EQIW_D_YearBook_Item_Midd
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

                            List<tblV_EQIW_D_YearBook_Midd> query2 = new List<tblV_EQIW_D_YearBook_Midd>();
                            List<tblV_EQIW_D_YearBook_Item_Midd> query_Item2 = new List<tblV_EQIW_D_YearBook_Item_Midd>();

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblV_EQIW_D_YearBook_Midd
                                          where x.STatType == info.STatType &&
                                          x.fldTimeType == info.fldTimeType
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblV_EQIW_D_YearBook_Midd
                                          where x.STatType == info.STatType &&
                                          x.fldTimeType == info.fldTimeType &&
                                          info.fldSTCode.Contains(x.fldCityCode + "." + x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                          select x).ToList();
                            }

                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblV_EQIW_D_YearBook_Item_Midd
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


                if (info.type == "City")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblV_EQIW_D_City_Midd> query = new List<tblV_EQIW_D_City_Midd>();
                        List<tblV_EQIW_D_City_Item_Midd> query_Item = new List<tblV_EQIW_D_City_Item_Midd>();


                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblV_EQIW_D_City_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate) &&
                                     x.STatType == info.STatType
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblV_EQIW_D_City_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     info.fldSTCode.Contains(x.fldSTCode) &&
                                     list.Contains(x.fldAppDate) &&
                                     x.STatType == info.STatType
                                     select x).ToList();
                        }

                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblV_EQIW_D_City_Item_Midd
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



                        ReturnData6 rd = new ReturnData6();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblV_EQIW_D_City_Midd> query2 = new List<tblV_EQIW_D_City_Midd>();
                            List<tblV_EQIW_D_City_Item_Midd> query_Item2 = new List<tblV_EQIW_D_City_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);


                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblV_EQIW_D_City_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          x.STatType == info.STatType
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblV_EQIW_D_City_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          info.fldSTCode.Contains(x.fldSTCode) &&
                                          list.Contains(x.fldAppDate) &&
                                          x.STatType == info.STatType
                                          select x).ToList();
                            }

                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblV_EQIW_D_City_Item_Midd
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


                if (info.type == "Section")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblV_EQIW_D_Section_Midd> query = new List<tblV_EQIW_D_Section_Midd>();
                        List<tblV_EQIW_D_Section_Item_Midd> query_Item = new List<tblV_EQIW_D_Section_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblV_EQIW_D_Section_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate) &&
                                     x.STatType == info.STatType
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblV_EQIW_D_Section_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate) &&
                                     info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                     x.STatType == info.STatType
                                     select x).ToList();
                        }



                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblV_EQIW_D_Section_Item_Midd
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



                        ReturnData7 rd = new ReturnData7();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblV_EQIW_D_Section_Midd> query2 = new List<tblV_EQIW_D_Section_Midd>();
                            List<tblV_EQIW_D_Section_Item_Midd> query_Item2 = new List<tblV_EQIW_D_Section_Item_Midd>();


                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);


                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblV_EQIW_D_Section_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          x.STatType == info.STatType
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblV_EQIW_D_Section_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                          x.STatType == info.STatType
                                          select x).ToList();
                            }


                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblV_EQIW_D_Section_Item_Midd
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
            /// “ItemOver”：因子超标
            /// “CityItemOver”：城市因子超标
            /// “BaseData”：原始数据
            /// “DayOfData”：日数据
            /// “YearBook”：年鉴
            /// “City”：城市表
            /// “Section”：点位表
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
            /// 0：tblEQIW_D_BaseData
            /// 1：tblEQIW_DT_BaseData
            /// </summary>
            public string STatType { get; set; }

        }






        /// <summary>
        /// ItemOver数据实体
        /// </summary>
        public class ReturnData
        {
            public List<tblV_EQIW_D_ItemOver_Midd> dangqi { get; set; }

            public List<tblV_EQIW_D_ItemOver_Midd> tongqi { get; set; }
        }

        /// <summary>
        /// CityItemOver数据实体
        /// </summary>
        public class ReturnData2
        {
            public List<tblV_EQIW_D_CityItemOver_Midd> dangqi { get; set; }

            public List<tblV_EQIW_D_CityItemOver_Midd> tongqi { get; set; }
        }

        /// <summary>
        /// BaseData数据实体
        /// </summary>
        public class ReturnData3
        {
            public List<tblEQIW_D_BaseData_Midd> dangqi { get; set; }

            public List<tblEQIW_D_BaseData_Item_Midd> dangqi_Item { get; set; }
        }

        /// <summary>
        /// DayOfData数据实体
        /// </summary>
        public class ReturnData4
        {
            public List<tblEQIW_D_DayOfData_Midd> dangqi { get; set; }

            public List<tblEQIW_D_DayOfData_Item_Midd> dangqi_Item { get; set; }
        }

        /// <summary>
        /// YearBook数据实体
        /// </summary>
        public class ReturnData5
        {
            public List<tblV_EQIW_D_YearBook_Midd> dangqi { get; set; }

            public List<tblV_EQIW_D_YearBook_Item_Midd> dangqi_Item { get; set; }

            public List<tblV_EQIW_D_YearBook_Midd> tongqi { get; set; }

            public List<tblV_EQIW_D_YearBook_Item_Midd> tongqi_Item { get; set; }
        }

        /// <summary>
        /// City数据实体
        /// </summary>
        public class ReturnData6
        {
            public List<tblV_EQIW_D_City_Midd> dangqi { get; set; }

            public List<tblV_EQIW_D_City_Item_Midd> dangqi_Item { get; set; }

            public List<tblV_EQIW_D_City_Midd> tongqi { get; set; }

            public List<tblV_EQIW_D_City_Item_Midd> tongqi_Item { get; set; }
        }


        /// <summary>
        /// Section数据实体
        /// </summary>
        public class ReturnData7
        {
            public List<tblV_EQIW_D_Section_Midd> dangqi { get; set; }

            public List<tblV_EQIW_D_Section_Item_Midd> dangqi_Item { get; set; }

            public List<tblV_EQIW_D_Section_Midd> tongqi { get; set; }

            public List<tblV_EQIW_D_Section_Item_Midd> tongqi_Item { get; set; }
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
                    if (i < 10)
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
