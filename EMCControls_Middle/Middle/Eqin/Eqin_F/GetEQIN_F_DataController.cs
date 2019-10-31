using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqin.Eqin_F
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIN_F_Data_MiddleController : ApiController
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



                string Sea = null;

                if (info.fldBeginDate == "-1" && info.fldEndDate == "-1")
                {
                    Sea = "合计";
                }
                else
                {
                    DateTime fldBeginDate = DateTime.Parse(info.fldBeginDate);

                    DateTime fldEndDate = DateTime.Parse(info.fldEndDate);


                    if (fldEndDate.Month == 3)
                    {
                        Sea += "一季度,";
                    }
                    else if (fldEndDate.Month == 6)
                    {
                        if (fldBeginDate.Month == 1)
                        {
                            Sea += "一季度,二季度";
                        }
                        else if (fldBeginDate.Month == 4)
                        {
                            Sea += "二季度";
                        }
                    }
                    else if (fldEndDate.Month == 9)
                    {
                        if (fldBeginDate.Month == 1)
                        {
                            Sea += "一季度,二季度,三季度";
                        }
                        else if (fldBeginDate.Month == 4)
                        {
                            Sea += ",二季度,三季度";
                        }
                        else if (fldBeginDate.Month == 7)
                        {
                            Sea += "三季度";
                        }
                    }
                    else if (fldEndDate.Month == 12)
                    {
                        if (fldBeginDate.Month == 1)
                        {
                            Sea += "一季度,二季度,三季度,四季度,合计";
                        }
                        else if (fldBeginDate.Month == 4)
                        {
                            Sea += "二季度,三季度,四季度";
                        }
                        else if (fldBeginDate.Month == 7)
                        {
                            Sea += "三季度,四季度";
                        }
                        else if (fldBeginDate.Month == 10)
                        {
                            Sea += "四季度";
                        }
                    }

                }


                List<string> YearList = info.fldYear.Split(',').ToList();



                if (info.type == "City_TotalDateStat")
                {
                    using (MiddleContext db = new MiddleContext())
                    {
                        var query = (from x in db.tblEQIN_F_City_TotalDateStat_Midd
                                     where YearList.Contains(x.fldYear) &&
                                     x.ReportType == info.ReportType &&
                                     Sea.Contains(x.fldDate)
                                     select x).ToList();

                        ReturnData rd = new ReturnData();
                        rd.dangqi = query;

                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            var query2 = (from x in db.tblEQIN_F_City_TotalDateStat_Midd
                                          where x.fldYear == year.ToString() &&
                                          x.ReportType == info.ReportType &&
                                          Sea.Contains(x.fldDate)
                                          select x).ToList();

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

                        List<tblEQIN_F_Point_HourStat_Midd> query;

                        if (info.fldSTCode == "-1" && info.fldGDCode == "-1")
                        {
                            query = (from x in db.tblEQIN_F_Point_HourStat_Midd
                                     where x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).OrderBy(x => x.fldGDCode).OrderBy(x => x.fldappdate).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIN_F_Point_HourStat_Midd
                                     where info.PointFormat.Contains(x.fldSTCode + "." + x.fldGDCode) &&
                                     x.fldappdate >= fldBeginDate &&
                                     x.fldappdate <= fldEndDate
                                     select x).OrderBy(x => x.fldGDCode).OrderBy(x => x.fldappdate).ToList();
                        }

                        result = rule.JsonStr("ok", "", query);
                    }
                }
                else if (info.type == "Point_TotalDateStat")
                {

                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIN_F_Point_TotalDateStat_Midd> query;

                        if (info.fldSTCode == "-1" && info.fldPCode == "-1")
                        {
                            query = (from x in db.tblEQIN_F_Point_TotalDateStat_Midd
                                     where YearList.Contains(x.fldYear) &&
                                     Sea.Contains(x.fldDate) &&
                                     x.ReportType == info.ReportType
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIN_F_Point_TotalDateStat_Midd
                                     where info.PointFormat.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                     YearList.Contains(x.fldYear) &&
                                     Sea.Contains(x.fldDate) &&
                                     x.ReportType == info.ReportType
                                     select x).ToList();
                        }

                        ReturnData1 rd = new ReturnData1();
                        rd.dangqi = query;

                        if (info.IsYear == "1" && YearList.Count == 1)
                        {
                            int year = int.Parse(info.fldYear) - 1;

                            List<tblEQIN_F_Point_TotalDateStat_Midd> query2;

                            if (info.fldSTCode == "-1" && info.fldPCode == "-1")
                            {
                                query2 = (from x in db.tblEQIN_F_Point_TotalDateStat_Midd
                                          where x.fldYear == year.ToString() &&
                                          Sea.Contains(x.fldDate) &&
                                          x.ReportType == info.ReportType
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIN_F_Point_TotalDateStat_Midd
                                          where info.PointFormat.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                          x.fldYear == year.ToString() &&
                                          Sea.Contains(x.fldDate) &&
                                          x.ReportType == info.ReportType
                                          select x).ToList();
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
            /// “City_TotalDateStat”，按城市缓存的数据
            /// “Point_HourStat”，点位小时值
            /// “Point_TotalDateStat”，点位表
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
            /// GDCode
            /// </summary>
            public string fldGDCode { get; set; }

            /// <summary>
            /// PCode
            /// </summary>
            public string fldPCode { get; set; }

            /// <summary>
            /// 开始时间
            /// </summary>
            public string fldBeginDate { get; set; }

            /// <summary>
            /// 结束时间
            /// </summary>
            public string fldEndDate { get; set; }

            /// <summary>
            /// 是否需要前期数据
            /// 0=否
            /// 1=是
            /// </summary>
            public string IsYear { get; set; }

            /// <summary>
            /// 点位格式：
            /// 1.fldSTCdoe.fldPCode
            /// 2.用半角逗号分隔
            /// 3.用于Point_TotalDateStat表，不用于点位小时值
            /// </summary>
            public string PointFormat { get; set; }


            /// <summary>
            /// 报表对象，用于行政区划分
            /// 1：地市级行政区left(fldSTCode,4)+'00'
            /// 0：各级行政区fldSTCode
            /// </summary>
            public string ReportType { get; set; }


        }

        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIN_F_City_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIN_F_City_TotalDateStat_Midd> tongqi { get; set; }

        }


        /// <summary>
        /// 数据实体
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQIN_F_Point_TotalDateStat_Midd> dangqi { get; set; }

            public List<tblEQIN_F_Point_TotalDateStat_Midd> tongqi { get; set; }

        }













    }
}
