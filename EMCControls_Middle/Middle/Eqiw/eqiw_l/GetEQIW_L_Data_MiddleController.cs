using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqiw.eqiw_l
{
    public class GetEQIW_L_Data_MiddleController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-14
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData(Info info)
        {
            string result = null;
            try
            {

                if (info.type == "ItemOverStat")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIW_L_ItemOverStat_Midd> query = new List<tblEQIW_L_ItemOverStat_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        List<tblEQIW_L_ItemOverStat_Midd> query_Temp = new List<tblEQIW_L_ItemOverStat_Midd>();

                        string[] fldSapceTypeList = info.fldSpaceType.Split(',');



                        foreach (var item in fldSapceTypeList)
                        {
                            query_Temp = (from x in db.tblEQIW_L_ItemOverStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          x.fldSpaceType == item &&
                                          list.Contains(x.fldAppDate)
                                          select x).ToList();

                            query.AddRange(query_Temp);
                        }






                        ReturnData rd = new ReturnData();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIW_L_ItemOverStat_Midd> query2 = new List<tblEQIW_L_ItemOverStat_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);




                            foreach (var item in fldSapceTypeList)
                            {
                                query_Temp = (from x in db.tblEQIW_L_ItemOverStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              x.fldSpaceType == item &&
                                              list.Contains(x.fldAppDate)
                                              select x).ToList();

                                query2.AddRange(query_Temp);
                            }





                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }


                if (info.type == "SectionStat")
                {

                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_L_SectionStat_Midd> query = new List<tblEQIW_L_SectionStat_Midd>();
                        List<tblEQIW_L_SectionStat_Item_Midd> query_Item = new List<tblEQIW_L_SectionStat_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIW_L_SectionStat_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate)
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIW_L_SectionStat_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate) &&
                                     info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                     select x).ToList();
                        }

                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIW_L_SectionStat_Item_Midd
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
                            List<tblEQIW_L_SectionStat_Midd> query2 = new List<tblEQIW_L_SectionStat_Midd>();
                            List<tblEQIW_L_SectionStat_Item_Midd> query_Item2 = new List<tblEQIW_L_SectionStat_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIW_L_SectionStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate)
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIW_L_SectionStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                          select x).ToList();
                            }

                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQIW_L_SectionStat_Item_Midd
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


                if (info.type == "TatalSectStat_N")
                {

                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_L_TatalSectStat_N_Midd> query = new List<tblEQIW_L_TatalSectStat_N_Midd>();
                        List<tblEQIW_L_TatalSectStat_N_Item_Midd> query_Item = new List<tblEQIW_L_TatalSectStat_N_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        List<tblEQIW_L_TatalSectStat_N_Midd> query_Temp = new List<tblEQIW_L_TatalSectStat_N_Midd>();

                        string[] fldSapceTypeList = info.fldSpaceType.Split(',');

                        foreach (var item in fldSapceTypeList)
                        {
                            query_Temp = (from x in db.tblEQIW_L_TatalSectStat_N_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          x.fldSpaceType == item
                                          select x).ToList();
                            query.AddRange(query_Temp);
                        }



                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIW_L_TatalSectStat_N_Item_Midd
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
                            List<tblEQIW_L_TatalSectStat_N_Midd> query2 = new List<tblEQIW_L_TatalSectStat_N_Midd>();
                            List<tblEQIW_L_TatalSectStat_N_Item_Midd> query_Item2 = new List<tblEQIW_L_TatalSectStat_N_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);



                            foreach (var item in fldSapceTypeList)
                            {
                                query_Temp = (from x in db.tblEQIW_L_TatalSectStat_N_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate) &&
                                              x.fldSpaceType == item
                                              select x).ToList();
                                query2.AddRange(query_Temp);
                            }


                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQIW_L_TatalSectStat_N_Item_Midd
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


                if (info.type == "TatalSectStat_Z")
                {

                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_L_TatalSectStat_Z_Midd> query = new List<tblEQIW_L_TatalSectStat_Z_Midd>();
                        List<tblEQIW_L_TatalSectStat_Z_Item_Midd> query_Item = new List<tblEQIW_L_TatalSectStat_Z_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        List<tblEQIW_L_TatalSectStat_Z_Midd> query_Temp = new List<tblEQIW_L_TatalSectStat_Z_Midd>();

                        string[] fldSapceTypeList = info.fldSpaceType.Split(',');


                        if (info.fldSTCode == "-1")
                        {
                            foreach (var item in fldSapceTypeList)
                            {
                                query_Temp = (from x in db.tblEQIW_L_TatalSectStat_Z_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate) &&
                                              x.fldSpaceType == item
                                              select x).ToList();
                                query.AddRange(query_Temp);
                            }
                        }
                        else
                        {
                            foreach (var item in fldSapceTypeList)
                            {
                                query_Temp = (from x in db.tblEQIW_L_TatalSectStat_Z_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate) &&
                                              x.fldSpaceType == item &&
                                              info.fldSTCode.Contains(x.fldSpaceName)
                                              select x).ToList();
                                query.AddRange(query_Temp);
                            }
                        }







                        if (info.fldItemCode != null)
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIW_L_TatalSectStat_Z_Item_Midd
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

                        ReturnData3 rd = new ReturnData3();
                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;

                        if (info.IsYear == "1")
                        {
                            List<tblEQIW_L_TatalSectStat_Z_Midd> query2 = new List<tblEQIW_L_TatalSectStat_Z_Midd>();
                            List<tblEQIW_L_TatalSectStat_Z_Item_Midd> query_Item2 = new List<tblEQIW_L_TatalSectStat_Z_Item_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);


                            if (info.fldSTCode == "-1")
                            {
                                foreach (var item in fldSapceTypeList)
                                {
                                    query_Temp = (from x in db.tblEQIW_L_TatalSectStat_Z_Midd
                                                  where x.fldTimeType == info.fldTimeType &&
                                                  list.Contains(x.fldAppDate) &&
                                                  x.fldSpaceType == item
                                                  select x).ToList();
                                    query2.AddRange(query_Temp);
                                }
                            }
                            else
                            {
                                foreach (var item in fldSapceTypeList)
                                {
                                    query_Temp = (from x in db.tblEQIW_L_TatalSectStat_Z_Midd
                                                  where x.fldTimeType == info.fldTimeType &&
                                                  list.Contains(x.fldAppDate) &&
                                                  x.fldSpaceType == item &&
                                                  info.fldSTCode.Contains(x.fldSpaceName)
                                                  select x).ToList();
                                    query2.AddRange(query_Temp);
                                }
                            }


                            if (info.fldItemCode != null)
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQIW_L_TatalSectStat_Z_Item_Midd
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
            /// “ItemOverStat”，因子超标
            /// “SectionStat”，断面表
            /// “TatalSectStat_N”，年鉴数据
            /// “TatalSectStat_Z”，综合数据
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

            /// <summary>
            /// 空间类型：
            /// “WaterArea”
            /// “LCode”
            /// “STCode”
            /// “AllProvince”
            /// “STCode_LCode”
            /// “WaterArea_STCode”
            /// “STCode_LCode”
            /// </summary>
            public string fldSpaceType { get; set; }


        }





        /// <summary>
        /// “ItemOverStat”
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIW_L_ItemOverStat_Midd> dangqi { get; set; }

            public List<tblEQIW_L_ItemOverStat_Midd> tongqi { get; set; }
        }


        /// <summary>
        /// “SectionStat”
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQIW_L_SectionStat_Midd> dangqi { get; set; }

            public List<tblEQIW_L_SectionStat_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIW_L_SectionStat_Midd> tongqi { get; set; }

            public List<tblEQIW_L_SectionStat_Item_Midd> tongqi_Item { get; set; }
        }



        /// <summary>
        /// “TatalSectStat_N”
        /// </summary>
        public class ReturnData2
        {
            public List<tblEQIW_L_TatalSectStat_N_Midd> dangqi { get; set; }

            public List<tblEQIW_L_TatalSectStat_N_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIW_L_TatalSectStat_N_Midd> tongqi { get; set; }

            public List<tblEQIW_L_TatalSectStat_N_Item_Midd> tongqi_Item { get; set; }
        }




        /// <summary>
        /// “TatalSectStat_Z”
        /// </summary>
        public class ReturnData3
        {
            public List<tblEQIW_L_TatalSectStat_Z_Midd> dangqi { get; set; }

            public List<tblEQIW_L_TatalSectStat_Z_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIW_L_TatalSectStat_Z_Midd> tongqi { get; set; }

            public List<tblEQIW_L_TatalSectStat_Z_Item_Midd> tongqi_Item { get; set; }
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
