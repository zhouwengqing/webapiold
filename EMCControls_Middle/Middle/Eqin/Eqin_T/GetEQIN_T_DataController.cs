using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqin.Eqin_T
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIN_T_Data_MiddleController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-11-3
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData(Info info)
        {
            string result = null;
            try
            {

                List<string> YearList = info.fldYear.Split(',').ToList();


                if (info.type == "City_TotalDateStat")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIN_T_City_TotalDateStat_Midd> query;

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIN_T_City_TotalDateStat_Midd
                                     where YearList.Contains(x.fldYear)
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIN_T_City_TotalDateStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     YearList.Contains(x.fldYear)
                                     select x).ToList();
                        }



                        ReturnData rd = new ReturnData();

                        rd.dangqi = query;

                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;


                            List<tblEQIN_T_City_TotalDateStat_Midd> query2;

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIN_T_City_TotalDateStat_Midd
                                          where x.fldYear == year.ToString()
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIN_T_City_TotalDateStat_Midd
                                          where info.fldSTCode.Contains(x.fldSTCode) &&
                                          x.fldYear == year.ToString()
                                          select x).ToList();
                            }




                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }

                }
                else if (info.type == "Point_HourStat")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        DateTime fldBeginDate = DateTime.Parse(info.fldBeginDate);

                        DateTime fldEndDate = DateTime.Parse(info.fldEndDate);

                        List<tblEQIN_T_Point_HourStat_Midd> query;

                        if (info.fldSTCode == "-1" && info.fldRDCode == "-1")
                        {
                            query = (from x in db.tblEQIN_T_Point_HourStat_Midd
                                     where x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).ToList();
                        }
                        else if (info.fldSTCode != "-1")
                        {
                            query = (from x in db.tblEQIN_T_Point_HourStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIN_T_Point_HourStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     info.fldRDCode.Contains(x.fldRDCode) &&
                                     x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).ToList();
                        }

                        result = rule.JsonStr("ok", "", query);
                    }
                }
                else if (info.type == "Point_TotalDateStat")
                {
                    using (MiddleContext db = new MiddleContext())
                    {


                        List<tblEQIN_T_Point_TotalDateStat_Midd> query;

                        if (info.fldSTCode == "-1" && info.fldRDCode == "-1")
                        {
                            query = (from x in db.tblEQIN_T_Point_TotalDateStat_Midd
                                     where YearList.Contains(x.fldYear)
                                     select x).ToList();
                        }
                        else if (info.fldSTCode != "-1")
                        {
                            query = (from x in db.tblEQIN_T_Point_TotalDateStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     YearList.Contains(x.fldYear)
                                     select x).ToList();
                        }
                        else
                        {
                            List<string> pointlist = new List<string>();

                            pointlist = info.PointFormat.Split(',').ToList();

                            query = (from x in db.tblEQIN_T_Point_TotalDateStat_Midd
                                     where pointlist.Contains(x.fldSTCode.ToString() + "." + x.fldRDCode.ToString()) &&
                                     YearList.Contains(x.fldYear)
                                     select x).ToList();
                        }




                        ReturnData1 rd = new ReturnData1();
                        rd.dangqi = query;


                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQIN_T_Point_TotalDateStat_Midd> query2;

                            if (info.fldSTCode == "-1" && info.fldRDCode == "-1")
                            {
                                query2 = (from x in db.tblEQIN_T_Point_TotalDateStat_Midd
                                          where x.fldYear == year.ToString()
                                          select x).ToList();
                            }
                            else if (info.fldSTCode != "-1")
                            {
                                query2 = (from x in db.tblEQIN_T_Point_TotalDateStat_Midd
                                          where info.fldSTCode.Contains(x.fldSTCode) &&
                                          x.fldYear == year.ToString()
                                          select x).ToList();
                            }
                            else
                            {
                                List<string> pointlist = new List<string>();

                                pointlist = info.PointFormat.Split(',').ToList();

                                query2 = (from x in db.tblEQIN_T_Point_TotalDateStat_Midd
                                          where pointlist.Contains(x.fldSTCode.ToString() + "." + x.fldRDCode.ToString()) &&
                                          x.fldYear == year.ToString()
                                          select x).ToList();
                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }

                }
                else if (info.type == "City_Data")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIN_T_City_Data_Midd> query;

                        if (info.fldSTCode == "-1")
                        {
                            if (info.DN == "All")
                            {
                                query = (from x in db.tblEQIN_T_City_Data_Midd
                                         where YearList.Contains(x.fldYear) &&
                                         x.ReportType == info.ReportType &&
                                         x.STatType == info.STatType
                                         select x).ToList();
                            }
                            else
                            {
                                query = (from x in db.tblEQIN_T_City_Data_Midd
                                         where YearList.Contains(x.fldYear) &&
                                         x.ReportType == info.ReportType &&
                                         x.STatType == info.STatType &&
                                         x.fldDN == info.DN
                                         select x).ToList();
                            }
                        }
                        else
                        {
                            if (info.DN == "All")
                            {
                                query = (from x in db.tblEQIN_T_City_Data_Midd
                                         where info.fldSTCode.Contains(x.fldSTCode) &&
                                         YearList.Contains(x.fldYear) &&
                                         x.ReportType == info.ReportType &&
                                         x.STatType == info.STatType
                                         select x).ToList();
                            }
                            else
                            {
                                query = (from x in db.tblEQIN_T_City_Data_Midd
                                         where info.fldSTCode.Contains(x.fldSTCode) &&
                                         YearList.Contains(x.fldYear) &&
                                         x.ReportType == info.ReportType &&
                                         x.STatType == info.STatType &&
                                         x.fldDN == info.DN
                                         select x).ToList();

                            }
                        }




                        ReturnData2 rd = new ReturnData2();
                        rd.dangqi = query;


                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQIN_T_City_Data_Midd> query2;

                            if (info.fldSTCode == "-1")
                            {
                                if (info.DN == "All")
                                {
                                    query2 = (from x in db.tblEQIN_T_City_Data_Midd
                                              where x.fldYear == year.ToString() &&
                                              x.ReportType == info.ReportType &&
                                              x.STatType == info.STatType
                                              select x).ToList();

                                }
                                else
                                {
                                    query2 = (from x in db.tblEQIN_T_City_Data_Midd
                                              where x.fldYear == year.ToString() &&
                                              x.ReportType == info.ReportType &&
                                              x.STatType == info.STatType &&
                                              x.fldDN == info.DN
                                              select x).ToList();
                                }
                            }
                            else
                            {
                                if (info.DN == "All")
                                {
                                    query2 = (from x in db.tblEQIN_T_City_Data_Midd
                                              where info.fldSTCode.Contains(x.fldSTCode) &&
                                              x.fldYear == year.ToString() &&
                                              x.ReportType == info.ReportType &&
                                              x.STatType == info.STatType
                                              select x).ToList();
                                }
                                else
                                {
                                    query2 = (from x in db.tblEQIN_T_City_Data_Midd
                                              where info.fldSTCode.Contains(x.fldSTCode) &&
                                              x.fldYear == year.ToString() &&
                                              x.ReportType == info.ReportType &&
                                              x.STatType == info.STatType &&
                                              x.fldDN == info.DN
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
            /// 1.值：City_TotalDateStat，按城市缓存的表
            /// 2.值：Point_HourStat，点位小时值
            /// 3.值：Point_TotalDateStat，点位表
            /// 4.值：City_Data，按城市缓存的声级表
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 年份
            /// </summary>
            public string fldYear { get; set; }

            /// <summary>
            /// RDCode
            /// 1.“最大值”与“平均值”传入即可获取
            /// </summary>
            public string fldRDCode { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// 是否返回同期数据，0不返回，1返回
            /// </summary>
            public string IsYear { get; set; }

            /// <summary>
            /// 报表对象，用于行政区划分
            /// 1：地市级行政区left(fldSTCode,4)+'00'
            /// 0：各级行政区fldSTCode
            /// </summary>
            public string ReportType { get; set; }

            /// <summary>
            /// 报表内容
            /// 0：按声级范围
            /// 1：按声级水平
            /// </summary>
            public string STatType { get; set; }


            /// <summary>
            /// 点位格式：
            /// 1.fldSTCdoe.fldRDCode
            /// 2.用半角逗号分隔
            /// 3.用于Point_TotalDateStat表，不用于点位小时值
            /// </summary>
            public string PointFormat { get; set; }


            /// <summary>
            /// 昼夜：用于“City_Data”表
            /// 1.值：“D”或者“N”，返回昼或者夜数据
            /// 2.值：“All”返回昼夜所有数据
            /// </summary>
            public string DN { get; set; }


        }

        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIN_T_City_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIN_T_City_TotalDateStat_Midd> tongqi { get; set; }
        }


        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQIN_T_Point_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIN_T_Point_TotalDateStat_Midd> tongqi { get; set; }
        }


        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData2
        {
            public List<tblEQIN_T_City_Data_Midd> dangqi { get; set; }

            public List<tblEQIN_T_City_Data_Midd> tongqi { get; set; }
        }




    }
}
