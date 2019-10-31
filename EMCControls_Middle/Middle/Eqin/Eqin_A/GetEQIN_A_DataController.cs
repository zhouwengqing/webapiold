using DDYZ.Ensis.Rule.DataRule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMCControls_Middle.Middle.Model;

namespace EMCControls_Middle.Middle.Eqin.Eqin_A
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIN_A_Data_MiddleController : ApiController
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

                        List<tblEQIN_A_City_TotalDateStat_Midd> query;

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIN_A_City_TotalDateStat_Midd
                                     where YearList.Contains(x.fldYear) &&
                                     x.ReportType == info.ReportType &&
                                     x.STatType == info.STatType
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIN_A_City_TotalDateStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     YearList.Contains(x.fldYear) &&
                                     x.ReportType == info.ReportType &&
                                     x.STatType == info.STatType
                                     select x).ToList();
                        }



                        ReturnData rd = new ReturnData();
                        rd.dangqi = query;

                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQIN_A_City_TotalDateStat_Midd> query2;

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIN_A_City_TotalDateStat_Midd
                                          where x.fldYear == year.ToString() &&
                                          x.ReportType == info.ReportType &&
                                          x.STatType == info.STatType
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIN_A_City_TotalDateStat_Midd
                                          where info.fldSTCode.Contains(x.fldSTCode) &&
                                          x.fldYear == year.ToString() &&
                                          x.ReportType == info.ReportType &&
                                          x.STatType == info.STatType
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

                        List<tblEQIN_A_Point_HourStat_Midd> query;

                        if (info.fldSTCode == "-1" && info.fldGDCode == "-1")
                        {
                            query = (from x in db.tblEQIN_A_Point_HourStat_Midd
                                     where x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).ToList();
                        }
                        else if (info.fldSTCode != "-1")
                        {
                            query = (from x in db.tblEQIN_A_Point_HourStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIN_A_Point_HourStat_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     info.fldGDCode.Contains(x.fldGDCode) &&
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

                        List<tblEQIN_A_Point_TotalDateStat_Midd> query;

                        if (info.fldSTCode == "-1" && info.fldGDCode == "-1")
                        {
                            query = (from x in db.tblEQIN_A_Point_TotalDateStat_Midd
                                     where YearList.Contains(x.fldYear)
                                     select x).ToList();
                        }
                        else
                        {
                            List<string> pointlist = new List<string>();

                            pointlist = info.PointFormat.Split(',').ToList();

                            query = (from x in db.tblEQIN_A_Point_TotalDateStat_Midd
                                     where pointlist.Contains(x.fldSTCode.ToString() + "." + x.fldGDCode.ToString()) &&
                                     YearList.Contains(x.fldYear)
                                     select x).ToList();
                        }

                        ReturnData1 rd = new ReturnData1();
                        rd.dangqi = query;

                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQIN_A_Point_TotalDateStat_Midd> query2;

                            if (info.fldSTCode == "-1" && info.fldGDCode == "-1")
                            {
                                query2 = (from x in db.tblEQIN_A_Point_TotalDateStat_Midd
                                          where x.fldYear == year.ToString()
                                          select x).ToList();
                            }
                            else
                            {
                                List<string> pointlist = new List<string>();

                                pointlist = info.PointFormat.Split(',').ToList();

                                query2 = (from x in db.tblEQIN_A_Point_TotalDateStat_Midd
                                          where pointlist.Contains(x.fldSTCode.ToString() + "." + x.fldGDCode.ToString()) &&
                                          x.fldYear == year.ToString()
                                          select x).ToList();
                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }

                }
                else if (info.type == "City_AverageData")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIN_A_City_AverageData_Midd> query;

                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIN_A_City_AverageData_Midd
                                     where YearList.Contains(x.fldYear) &&
                                     x.ReportType == info.ReportType
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIN_A_City_AverageData_Midd
                                     where info.fldSTCode.Contains(x.fldSTCode) &&
                                     YearList.Contains(x.fldYear) &&
                                     x.ReportType == info.ReportType
                                     select x).ToList();
                        }

                        ReturnData2 rd = new ReturnData2();
                        rd.dangqi = query;

                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQIN_A_City_AverageData_Midd> query2;

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIN_A_City_AverageData_Midd
                                          where x.fldYear == year.ToString() &&
                                          x.ReportType == info.ReportType
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIN_A_City_AverageData_Midd
                                          where info.fldSTCode.Contains(x.fldSTCode) &&
                                          x.fldYear == year.ToString() &&
                                          x.ReportType == info.ReportType
                                          select x).ToList();
                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }
                else if (info.type == "City_ProvinceData")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        var query = (from x in db.tblEQIN_A_City_ProvinceData_Midd
                                     where YearList.Contains(x.fldYear) &&
                                     x.STatType == info.STatType
                                     select x).ToList();

                        ReturnData3 rd = new ReturnData3();
                        rd.dangqi = query;

                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            var query2 = (from x in db.tblEQIN_A_City_ProvinceData_Midd
                                          where x.fldYear == year.ToString() &&
                                          x.STatType == info.STatType
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
            /// 1.“City_AverageData”，城市噪声均值
            /// 2.“Point_TotalDateStat”，点位表
            /// 3.“Point_HourStat”，小时值
            /// 4.“City_TotalDateStat”，城市表
            /// 5.“City_ProvinceData”，全省统计
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 城市代码：
            /// 1.“-1”返回所有城市
            /// 2.代码列表形式，代码用任意字符分割即可
            /// </summary>
            public string fldSTCode { get; set; }

            /// <summary>
            /// 年份
            /// </summary>
            public string fldYear { get; set; }

            public string fldGDCode { get; set; }

            public string fldBeginDate { get; set; }

            public string fldEndDate { get; set; }


            public string IsYear { get; set; }


            /// <summary>
            /// 用于行政区划分
            /// 0：各级行政区fldSTCode
            /// 1：地市级行政区left(fldSTCode,4)+'00'
            /// </summary>
            public string ReportType { get; set; }



            /// <summary>
            /// 点位格式：
            /// 1.fldSTCdoe.fldGDCode
            /// 2.用半角逗号分隔
            /// 3.用于Point_TotalDateStat表，不用于点位小时值
            /// </summary>
            public string PointFormat { get; set; }


            /// <summary>
            /// 报表内容
            /// 90按功能区
            /// 91按声源
            /// 92按声级
            /// 93分段
            /// </summary>
            public string STatType { get; set; }



        }

        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIN_A_City_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIN_A_City_TotalDateStat_Midd> tongqi { get; set; }

        }


        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQIN_A_Point_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIN_A_Point_TotalDateStat_Midd> tongqi { get; set; }

        }



        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData2
        {
            public List<tblEQIN_A_City_AverageData_Midd> dangqi { get; set; }

            public List<tblEQIN_A_City_AverageData_Midd> tongqi { get; set; }

        }



        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData3
        {
            public List<tblEQIN_A_City_ProvinceData_Midd> dangqi { get; set; }

            public List<tblEQIN_A_City_ProvinceData_Midd> tongqi { get; set; }

        }

    }
}
