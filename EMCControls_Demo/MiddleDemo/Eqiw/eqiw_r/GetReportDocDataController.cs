﻿using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using DDYZ.Ensis.Rule.DataRule;



namespace EMCControls_DemoMiddleDemo.Eqiw.eqiw_r
{
    /// <summary>
    /// 功能描述：临时获得报告河流需要的数据
    /// 创建  人：周文卿
    /// 创建时间：2017/10/27
    /// 
    /// 
    /// </summary>
    public class GetReportDocDataController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得水质简报数据（双月）
        /// 创建  人：周文卿
        /// 创建时间：2017/11/02
        /// </summary>
        /// <param name="concent"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetReportDocdata(dynamic concent)
        {
            string result = "";
            try
            {

                DataTable dt = new DataTable();

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();
                //河流合计
                dt = rule.getreportdt(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "'601000.355','601000.61','601000.62','618100.251','618100.410','618100.51','651100.412','601123.421','601123.423','601123.465','601112.431','601112.432','601114.441','601114.442','651100.365','601115.451','601115.452','601116.461','601116.462'", "GB 3838-2002", 1, 0, 0, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 0);

                //断面
                dt1 = rule.getreportdt(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "'601000.355','601000.61','601000.62','618100.251','618100.410','618100.51','651100.412','601123.421','601123.423','601123.465','601112.431','601112.432','601114.441','601114.442','651100.365','601115.451','601115.452','601116.461','601116.462'", "GB 3838-2002", 1, 0, 1, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 0);
                //湖库
                dt2 = rule.getreportdtlake(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "F", "'25.1','25.12','25.16','25.18','25.2','25.22','25.3','25.4','25.5','25.7','25.8','402.511','402.512','402.513','402.514','405.591'", "GB 3838-2002", 0, 0, 1, 0, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2);

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
        public HttpResponseMessage GetReportDocSingledata(dynamic concent)
        {
            string result = "";
            try
            {

                DataTable dt = new DataTable();

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();
                //河流合计
                dt = rule.getreportdt(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "'601000.62','601114.441','618100.251','651100.751','601112.431','601115.451','601112.432','601116.731','601123.465','651100.412','601115.721','601117.912','601118.915','601701.741','601116.462','601000.355','601116.461','601123.423','601114.712','618100.1','651100.351','601117.911','601701.742','601114.442','618100.51','618100.410','651100.365','601115.452','601000.61','601123.421'",
                                  "GB 3838-2002", 0, 0, 0, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 1);

                //断面
                dt1 = rule.getreportdt(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "'601000.62','601114.441','618100.251','651100.751','601112.431','601115.451','601112.432','601116.731','601123.465','651100.412','601115.721','601117.912','601118.915','601701.741','601116.462','601000.355','601116.461','601123.423','601114.712','618100.1','651100.351','601117.911','601701.742','601114.442','618100.51','618100.410','651100.365','601115.452','601000.61','601123.421'",
                                  "GB 3838-2002", 1, 0, 1, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 0);
                //湖库
                dt2 = rule.getreportdtlake(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "F", "'25.1','25.2','25.3','25.5','1010.1010','1020.1020','1030.1030','25.12','25.16','25.18','25.22','25.4','25.7','25.8','840.841','861.861','901.901','902.902','925.925','926.926','903.903','904.904','905.905','906.906','907.907','908.908','909.909','910.910','915.915','916.916','353.561','353.562','353.563','850.851','913.913','914.914','977.977','978.978','979.979','980.980','351.551','351.552','351.553','911.911','912.912','917.917','976.976','790.791','800.801','760.761','770.771','780.781','810.811','810.812','810.965','918.918','928.928','352.541','352.542','352.543','1130.1130','1140.1140','929.929','981.981','1390.1390','964.531','1450.1450','1460.1460','1470.1470','1480.1480','1490.1490','935.935','937.937','938.938','953.953','962.962','964.939','964.964','964.966','402.511','402.512','402.513','402.514','405.591','512.515','401.521','401.522','830.831','1690.1690','1690.1691','1700.1700','1710.1710','1720.1720','401.956','401.970','401.971','401.972','401.973','830.832','830.833','410.581','1910.1910','1920.1920','1930.1930','1940.1940','1960.1960','1970.1970','1980.1980','1990.1990','2000.2000','2010.2010','410.582','946.947','404.571','2110.2110','930.930','940.940','941.941','943.943','944.944','945.945','946.946'",
                                            "GB 3838-2002", 0, 0, 0, 1, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2);



                //垂线
                DataTable dt3 = rule.getreportdtlake(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "F", "'25.1','25.2','25.3','25.5','1010.1010','1020.1020','1030.1030','25.12','25.16','25.18','25.22','25.4','25.7','25.8','840.841','861.861','901.901','902.902','925.925','926.926','903.903','904.904','905.905','906.906','907.907','908.908','909.909','910.910','915.915','916.916','353.561','353.562','353.563','850.851','913.913','914.914','977.977','978.978','979.979','980.980','351.551','351.552','351.553','911.911','912.912','917.917','976.976','790.791','800.801','760.761','770.771','780.781','810.811','810.812','810.965','918.918','928.928','352.541','352.542','352.543','1130.1130','1140.1140','929.929','981.981','1390.1390','964.531','1450.1450','1460.1460','1470.1470','1480.1480','1490.1490','935.935','937.937','938.938','953.953','962.962','964.939','964.964','964.966','402.511','402.512','402.513','402.514','405.591','512.515','401.521','401.522','830.831','1690.1690','1690.1691','1700.1700','1710.1710','1720.1720','401.956','401.970','401.971','401.972','401.973','830.832','830.833','410.581','1910.1910','1920.1920','1930.1930','1940.1940','1960.1960','1970.1970','1980.1980','1990.1990','2000.2000','2010.2010','410.582','946.947','404.571','2110.2110','930.930','940.940','941.941','943.943','944.944','945.945','946.946'",
                                            "GB 3838-2002", 0, 0, 1, 1, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2);
                //大中型水库
                DataTable dt4 = rule.getreportdtlake(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                           , 3, "F", "'1890.1890','1900.1900','1950.1950','820.821','820.822','931.931','931.932','931.933','931.934','820.948','950.950','951.951','952.952','986.986'", "GB 3838-2002", 0, 0, 1, 0, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2);
                //排污口
                DataTable dt5 = rule.getreportdtw_n(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467", 3, "'420100.25.25HK01','420100.25.25HK02','420100.25.25HK03','420100.25.25HK04','420100.25.25HK05','420100.25.25HK06','420100.25.25HK08','420100.25.25HK10','420100.25.25HK11','420100.25.25HK12','420100.25.25HK13','420100.25.25HK14','420100.25.25HK15','420100.25.25HK16','420100.25.25HK17','420100.25.25HK18','420100.25.25HK19','420100.25.25HK20','420100.25.25HK22','420100.25.25HK23','420100.25.25HK24','420100.25.25HK25','420100.25.25HK26','420100.25.25HK27','420100.25.25HK28','420100.25.25HK29','420100.25.25HK30','420100.25.25HK31','420100.25.25HK32','420100.601000.601000HL01','420100.601000.601000HL02','420102.601000.601000HL03','420102.651100.651100HL01','420102.651100.651100HL02','420103.601000.601000HL04','420104.618100.618100HL01','420104.618100.618100HL02','420104.651100.651100HL03','420104.651100.651100HL04','420105.353.353HK01','420105.353.353HK02','420105.618100.618100HL03','420105.618100.618100HL04','420105.618100.618100HL05','420105.618100.618100HL06','420105.618100.618100HL07','420105.964.964HK01','420105.964.964HK02','420106.601000.601000HL05','420106.601000.601000HL06','420106.601000.601000HL07','420106.601000.601000HL08','420107.601000.601000HL09','420107.601000.601000HL10','420107.601000.601000HL11','420107.601000.601000HL12','420111.401.401HK01','420111.810.810HK01','420111.810.810HK02','420112.651100.651100HL05','420112.651100.651100HL06','420114.618100.618100HL08','420114.618100.618100HL09','420114.618100.618100HL10','420114.964.964HK03','420114.964.964HK04','420115.401.401HK02','420115.401.401HK03','420115.401.401HK04','420115.401.401HK05','420115.401.401HK06','420115.401.401HK07'",
                                                    "", 0, 3, concent.TimeType.ToString());
                //DataTable dt4 = (from x in dt3.AsEnumerable()
                //                 where x["fldRSName"].ToString() != "平均"
                //                 select x).CopyToDataTable();
                retudata rt = new retudata();
                rt.River = dt;
                rt.Point = dt1;
                rt.Lake = dt2;
                rt.LakePoint = dt3;
                rt.BigLake = dt4;
                rt.Sewage = dt5;

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
        public HttpResponseMessage GetReportDocRangedata(dynamic concent)
        {
            string result = "";
            try
            {

                DataTable dt = new DataTable();

                DataTable dt1 = new DataTable();

                DataTable dt2 = new DataTable();
                //河流合计
                dt = rule.getreportdt(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "'601000.62','601114.441','618100.251','651100.751','601112.431','601115.451','601112.432','601116.731','601123.465','651100.412','601115.721','601117.912','601118.915','601701.741','601116.462','601000.355','601116.461','601123.423','601114.712','618100.1','651100.351','601117.911','601701.742','601114.442','618100.51','618100.410','651100.365','601115.452','601000.61','601123.421'",
                                  "GB 3838-2002", 0, 0, 0, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 1);

                //断面
                dt1 = rule.getreportdt(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                  , 3, "0", "'601000.62','601114.441','618100.251','651100.751','601112.431','601115.451','601112.432','601116.731','601123.465','651100.412','601115.721','601117.912','601118.915','601701.741','601116.462','601000.355','601116.461','601123.423','601114.712','618100.1','651100.351','601117.911','601701.742','601114.442','618100.51','618100.410','651100.365','601115.452','601000.61','601123.421'",
                                  "GB 3838-2002", 0, 0, 1, 0, 1, 0, 2, 3, concent.TimeType.ToString(), 1);
                //湖库
                dt2 = rule.getreportdtlake(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 1, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "F", "'25.1','25.2','25.3','25.5','1010.1010','1020.1020','1030.1030','25.12','25.16','25.18','25.22','25.4','25.7','25.8','840.841','861.861','901.901','902.902','925.925','926.926','903.903','904.904','905.905','906.906','907.907','908.908','909.909','910.910','915.915','916.916','353.561','353.562','353.563','850.851','913.913','914.914','977.977','978.978','979.979','980.980','351.551','351.552','351.553','911.911','912.912','917.917','976.976','790.791','800.801','760.761','770.771','780.781','810.811','810.812','810.965','918.918','928.928','352.541','352.542','352.543','1130.1130','1140.1140','929.929','981.981','1390.1390','964.531','1450.1450','1460.1460','1470.1470','1480.1480','1490.1490','935.935','937.937','938.938','953.953','962.962','964.939','964.964','964.966','402.511','402.512','402.513','402.514','405.591','512.515','401.521','401.522','830.831','1690.1690','1690.1691','1700.1700','1710.1710','1720.1720','401.956','401.970','401.971','401.972','401.973','830.832','830.833','410.581','1910.1910','1920.1920','1930.1930','1940.1940','1960.1960','1970.1970','1980.1980','1990.1990','2000.2000','2010.2010','410.582','946.947','404.571','2110.2110','930.930','940.940','941.941','943.943','944.944','945.945','946.946'",
                                            "GB 3838-2002", 0, 0, 0, 1, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2);



                //垂线
                DataTable dt3 = rule.getreportdtlake(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                            , 3, "F", "'25.1','25.2','25.3','25.5','1010.1010','1020.1020','1030.1030','25.12','25.16','25.18','25.22','25.4','25.7','25.8','840.841','861.861','901.901','902.902','925.925','926.926','903.903','904.904','905.905','906.906','907.907','908.908','909.909','910.910','915.915','916.916','353.561','353.562','353.563','850.851','913.913','914.914','977.977','978.978','979.979','980.980','351.551','351.552','351.553','911.911','912.912','917.917','976.976','790.791','800.801','760.761','770.771','780.781','810.811','810.812','810.965','918.918','928.928','352.541','352.542','352.543','1130.1130','1140.1140','929.929','981.981','1390.1390','964.531','1450.1450','1460.1460','1470.1470','1480.1480','1490.1490','935.935','937.937','938.938','953.953','962.962','964.939','964.964','964.966','402.511','402.512','402.513','402.514','405.591','512.515','401.521','401.522','830.831','1690.1690','1690.1691','1700.1700','1710.1710','1720.1720','401.956','401.970','401.971','401.972','401.973','830.832','830.833','410.581','1910.1910','1920.1920','1930.1930','1940.1940','1960.1960','1970.1970','1980.1980','1990.1990','2000.2000','2010.2010','410.582','946.947','404.571','2110.2110','930.930','940.940','941.941','943.943','944.944','945.945','946.946'",
                                            "GB 3838-2002", 0, 0, 1, 1, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2);
                //大中型水库
                DataTable dt4 = rule.getreportdtlake(concent.BeginDate.ToString(), concent.EndDate.ToString(), "0", 0, "302,315,314,316,317,311,313,434,435,318,319,320,438,436,323,437,325,326,327,328,467"
                                           , 3, "F", "'1890.1890','1900.1900','1950.1950','820.821','820.822','931.931','931.932','931.933','931.934','820.948','950.950','951.951','952.952','986.986'", "GB 3838-2002", 0, 0, 1, 0, 0, 0, 3, concent.TimeType.ToString(), 1, 1, 2);                              
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
