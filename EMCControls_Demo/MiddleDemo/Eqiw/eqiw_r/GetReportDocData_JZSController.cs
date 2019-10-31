using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DDYZ.Ensis.Rule.DataRule;


namespace EMCControls_DemoMiddleDemo.Eqiw.eqiw_r
{
    /// <summary>
    /// 功能描述：获得JZS数据
    /// 创建  人：周文卿
    /// 创建时间：2017/11/15
    /// </summary>
    public class GetReportDocData_JZSController : ApiController
    {
        RuleCommon rule = new RuleCommon();
        Report_Common rc = new Report_Common();

        /// <summary>
        /// 功能描述：获得水质简报数据（双月）
        /// 创建  人：周文卿
        /// 创建时间：2017/11/02
        /// </summary>
        /// <param name="concent"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetReportDocdata_JZS(dynamic concent)
        {
            string result = "";
            try
            {

                DataTable dt = new DataTable();

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();
                //河流合计
                dt = rc.getreportdt_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "-1", "GB 3838-2002", 1, 0, 0, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 0);

                //断面
                dt1 = rc.getreportdt_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "-1", "GB 3838-2002", 1, 0, 1, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 0);
                //湖库
                dt2 = rc.getreportdtlake_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                   , 3, "", " '360400.24.10','360400.24.100','360400.24.110','360400.24.120','360400.24.130','361100.24.140','361100.24.150','361100.24.160','361100.24.20','361100.24.30','360200.30.301','360400.24.4','360100.24.40','360400.51.410','360500.52.410','360400.51.420','360400.51.430','360500.52.430','360400.51.440','360500.52.440','360100.24.50','360100.24.60','360100.24.70','360400.24.80','360400.24.90'",
                                   "GB 3838-2002", 0, 0, 1, 0, 1, 1, 3, concent.TimeType.ToString(), 1, 1, 2,4);

                DataTable dt3 = (from x in dt2.AsEnumerable()
                                 where x["fldRSName"].ToString() == "平均"
                                 select x).CopyToDataTable();
                retudata rt = new retudata();
                rt.River = dt;
                rt.Point = dt1;
                rt.Lake = dt3;

                result = rule.JsonStr("ok", "", rt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：获得水质简报数据（单月）
        /// 创建  人：周文卿
        /// 创建时间：2017/11/03
        /// </summary>
        /// <param name="concent"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetReportDocSingledata_JZS(dynamic concent)
        {
            string result = "";
            try
            {

                DataTable dt = new DataTable();

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();
                //河流合计
                dt = rc.getreportdt_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "-1",
                                  "GB 3838-2002", 0, 0, 0, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 1);

                //断面
                dt1 = rc.getreportdt_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "-1",
                                  "GB 3838-2002", 1, 0, 1, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 0);
                //湖库
                dt2 = rc.getreportdtlake_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "", " '360400.24.10','360400.24.100','360400.24.110','360400.24.120','360400.24.130','361100.24.140','361100.24.150','361100.24.160','361100.24.20','361100.24.30','360200.30.301','360400.24.4','360100.24.40','360400.51.410','360500.52.410','360400.51.420','360400.51.430','360500.52.430','360400.51.440','360500.52.440','360100.24.50','360100.24.60','360100.24.70','360400.24.80','360400.24.90'",
                                            "GB 3838-2002", 0, 0, 0, 0,1, 0, 3, concent.TimeType.ToString(), 1, 1, 2,4);



                //垂线
                DataTable dt3 = rc.getreportdtlake_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "", " '360400.24.10','360400.24.100','360400.24.110','360400.24.120','360400.24.130','361100.24.140','361100.24.150','361100.24.160','361100.24.20','361100.24.30','360200.30.301','360400.24.4','360100.24.40','360400.51.410','360500.52.410','360400.51.420','360400.51.430','360500.52.430','360400.51.440','360500.52.440','360100.24.50','360100.24.60','360100.24.70','360400.24.80','360400.24.90'",
                                            "GB 3838-2002", 0, 0, 1, 0, 1, 0, 3, concent.TimeType.ToString(), 1, 1, 2,4);
                //大中型水库
                DataTable dt4 = rc.getreportdtlake_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                           , 3, "", " '360400.24.10','360400.24.100','360400.24.110','360400.24.120','360400.24.130','361100.24.140','361100.24.150','361100.24.160','361100.24.20','361100.24.30','360200.30.301','360400.24.4','360100.24.40','360400.51.410','360500.52.410','360400.51.420','360400.51.430','360500.52.430','360400.51.440','360500.52.440','360100.24.50','360100.24.60','360100.24.70','360400.24.80','360400.24.90'",
                                           "GB 3838-2002", 0, 0, 1, 0,1, 0, 3, concent.TimeType.ToString(), 1, 1, 2, 4);
                //排污口
                //DataTable dt5 = rule.getreportdtw_n(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467", 3, "'420100.25.25HK01','420100.25.25HK02','420100.25.25HK03','420100.25.25HK04','420100.25.25HK05','420100.25.25HK06','420100.25.25HK08','420100.25.25HK10','420100.25.25HK11','420100.25.25HK12','420100.25.25HK13','420100.25.25HK14','420100.25.25HK15','420100.25.25HK16','420100.25.25HK17','420100.25.25HK18','420100.25.25HK19','420100.25.25HK20','420100.25.25HK22','420100.25.25HK23','420100.25.25HK24','420100.25.25HK25','420100.25.25HK26','420100.25.25HK27','420100.25.25HK28','420100.25.25HK29','420100.25.25HK30','420100.25.25HK31','420100.25.25HK32','420100.601000.601000HL01','420100.601000.601000HL02','420102.601000.601000HL03','420102.651100.651100HL01','420102.651100.651100HL02','420103.601000.601000HL04','420104.618100.618100HL01','420104.618100.618100HL02','420104.651100.651100HL03','420104.651100.651100HL04','420105.353.353HK01','420105.353.353HK02','420105.618100.618100HL03','420105.618100.618100HL04','420105.618100.618100HL05','420105.618100.618100HL06','420105.618100.618100HL07','420105.964.964HK01','420105.964.964HK02','420106.601000.601000HL05','420106.601000.601000HL06','420106.601000.601000HL07','420106.601000.601000HL08','420107.601000.601000HL09','420107.601000.601000HL10','420107.601000.601000HL11','420107.601000.601000HL12','420111.401.401HK01','420111.810.810HK01','420111.810.810HK02','420112.651100.651100HL05','420112.651100.651100HL06','420114.618100.618100HL08','420114.618100.618100HL09','420114.618100.618100HL10','420114.964.964HK03','420114.964.964HK04','420115.401.401HK02','420115.401.401HK03','420115.401.401HK04','420115.401.401HK05','420115.401.401HK06','420115.401.401HK07'",
                //                                    "", 0, 3, concent.TimeType.ToString());
                //DataTable dt4 = (from x in dt3.AsEnumerable()
                //                 where x["fldRSName"].ToString() != "平均"
                //                 select x).CopyToDataTable();
                retudata rt = new retudata();
                rt.River = dt;
                rt.Point = dt1;
                rt.Lake = dt2;
                rt.LakePoint = dt3;
                rt.BigLake = dt4;
                //rt.Sewage = dt5;

                result = rule.JsonStr("ok", "", rt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }


        /// <summary>
        /// 功能描述：地表水水质监测信息
        /// 创建  人：周文卿
        /// 创建时间：2017/11/11 
        /// </summary>
        /// <param name="concent"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public HttpResponseMessage GetReportDocRangedata_JZS(dynamic concent)
        {
            string result = "";
            try
            {

                DataTable dt = new DataTable();

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();
                //河流合计
                dt = rc.getreportdt_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "-1", "GB 3838-2002", 0, 0, 0, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 1);

                //断面
                dt1 = rc.getreportdt_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "-1", "GB 3838-2002", 0, 0, 1, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 1);
                //湖库
                dt2 = rc.getreportdtlake_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "", " '360400.24.10','360400.24.100','360400.24.110','360400.24.120','360400.24.130','361100.24.140','361100.24.150','361100.24.160','361100.24.20','361100.24.30','360200.30.301','360400.24.4','360100.24.40','360400.51.410','360500.52.410','360400.51.420','360400.51.430','360500.52.430','360400.51.440','360500.52.440','360100.24.50','360100.24.60','360100.24.70','360400.24.80','360400.24.90'",
                                            "GB 3838-2002", 0, 0, 0, 1, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2,4);



                //垂线
                DataTable dt3 = rc.getreportdtlake_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "", " '360400.24.10','360400.24.100','360400.24.110','360400.24.120','360400.24.130','361100.24.140','361100.24.150','361100.24.160','361100.24.20','361100.24.30','360200.30.301','360400.24.4','360100.24.40','360400.51.410','360500.52.410','360400.51.420','360400.51.430','360500.52.430','360400.51.440','360500.52.440','360100.24.50','360100.24.60','360100.24.70','360400.24.80','360400.24.90'",
                                            "GB 3838-2002", 0, 0, 1, 0, 1, 0, 3, concent.TimeType.ToString(), 1, 1, 2,4);
                //大中型水库
                DataTable dt4 = rc.getreportdtlake_JZS(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                           , 3, "", " '360400.24.10','360400.24.100','360400.24.110','360400.24.120','360400.24.130','361100.24.140','361100.24.150','361100.24.160','361100.24.20','361100.24.30','360200.30.301','360400.24.4','360100.24.40','360400.51.410','360500.52.410','360400.51.420','360400.51.430','360500.52.430','360400.51.440','360500.52.440','360100.24.50','360100.24.60','360100.24.70','360400.24.80','360400.24.90'", "GB 3838-2002", 0, 0, 1, 0, 1, 0, 3, concent.TimeType.ToString(), 1, 1, 2,4);
                retudata rt = new retudata();
                rt.River = dt;
                rt.Point = dt1;
                rt.Lake = dt2;
                rt.LakePoint = dt3;
                rt.BigLake = dt4;


                result = rule.JsonStr("ok", "", rt);
            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", "", e.Message);
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }
        /// <summary>
        /// 
        /// </summary>
        public class retudata
        {

            /// <summary>
            ///  河流
            /// </summary>
            public DataTable River { get; set; }

            /// <summary>
            /// 断面
            /// </summary>
            public DataTable Point { get; set; }

            /// <summary>
            /// 湖库
            /// </summary>
            public DataTable Lake { get; set; }

            /// <summary>
            /// 垂线
            /// </summary>
            public DataTable LakePoint { get; set; }

            /// <summary>
            /// 大中型水库
            /// </summary>
            public DataTable BigLake { get; set; }

            /// <summary>
            /// 排污口
            /// </summary>
            public DataTable Sewage { get; set; }
        }
    }
}
