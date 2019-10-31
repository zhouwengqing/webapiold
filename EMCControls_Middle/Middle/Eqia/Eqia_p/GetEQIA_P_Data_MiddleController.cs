using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCControls_Middle.Middle.Eqia.Eqia_p
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIA_P_Data_MiddleController : ApiController
    {



        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-18
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData(Info info)
        {
            string result = null;
            try
            {

                if (info.type == "BaseData")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_BaseData_Midd> query = new List<tblEQIA_P_BaseData_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);



                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_P_BaseData_Midd
                                     where x.STatType == info.STatType &&
                                     x.fldSDate >= BeginDate &&
                                     x.fldEDate <= EndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIA_P_BaseData_Midd
                                     where x.STatType == info.STatType &&
                                     x.fldSDate >= BeginDate &&
                                     x.fldEDate <= EndDate &&
                                     info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                     select x).ToList();
                        }





                        ReturnData rd = new ReturnData();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_BaseData_Midd> query2 = new List<tblEQIA_P_BaseData_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);
                            int year = int.Parse(info.fldYear) - 1;

                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_P_BaseData_Midd
                                          where x.STatType == info.STatType &&
                                          x.fldSDate >= BeginDate &&
                                          x.fldEDate <= EndDate
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIA_P_BaseData_Midd
                                          where x.STatType == info.STatType &&
                                          x.fldSDate >= BeginDate &&
                                          x.fldEDate <= EndDate &&
                                          info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                          select x).ToList();
                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }



                if (info.type == "ResultStat")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_ResultStat_Midd> query = new List<tblEQIA_P_ResultStat_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);



                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_P_ResultStat_Midd
                                     where x.TimeType == info.TimeType &&
                                     x.AppriseID == info.AppriseID &&
                                     list.Contains(x.fldAppDate)
                                     select x).ToList();
                        }
                        else
                        {
                            if (info.AppriseID == "0")
                            {
                                query = (from x in db.tblEQIA_P_ResultStat_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         list.Contains(x.fldAppDate) &&
                                         info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                         select x).ToList();
                            }

                            if (info.AppriseID == "1")
                            {
                                query = (from x in db.tblEQIA_P_ResultStat_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         list.Contains(x.fldAppDate) &&
                                         info.fldSTCode.Contains(x.fldSTCode)
                                         select x).ToList();
                            }
                        }






                        ReturnData1 rd = new ReturnData1();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_ResultStat_Midd> query2 = new List<tblEQIA_P_ResultStat_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_P_ResultStat_Midd
                                          where x.TimeType == info.TimeType &&
                                          x.AppriseID == info.AppriseID &&
                                          list.Contains(x.fldAppDate)
                                          select x).ToList();
                            }
                            else
                            {
                                if (info.AppriseID == "0")
                                {
                                    query2 = (from x in db.tblEQIA_P_ResultStat_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              list.Contains(x.fldAppDate) &&
                                              info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                              select x).ToList();
                                }

                                if (info.AppriseID == "1")
                                {
                                    query2 = (from x in db.tblEQIA_P_ResultStat_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              list.Contains(x.fldAppDate) &&
                                              info.fldSTCode.Contains(x.fldSTCode)
                                              select x).ToList();
                                }
                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }




                if (info.type == "STatType2")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_STatType2_Midd> query = new List<tblEQIA_P_STatType2_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);



                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_P_STatType2_Midd
                                     where x.TimeType == info.TimeType &&
                                     x.AppriseID == info.AppriseID
                                     select x).ToList();
                        }
                        else
                        {
                            if (info.AppriseID == "0")
                            {
                                query = (from x in db.tblEQIA_P_STatType2_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                         select x).ToList();


                            }


                            if (info.AppriseID == "1")
                            {
                                query = (from x in db.tblEQIA_P_STatType2_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode)
                                         select x).ToList();

                            }

                        }



                        ReturnData2 rd = new ReturnData2();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_STatType2_Midd> query2 = new List<tblEQIA_P_STatType2_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_P_STatType2_Midd
                                          where x.TimeType == info.TimeType &&
                                          x.AppriseID == info.AppriseID
                                          select x).ToList();
                            }
                            else
                            {
                                if (info.AppriseID == "0")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType2_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode)
                                              select x).ToList();


                                }


                                if (info.AppriseID == "1")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType2_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode)
                                              select x).ToList();

                                }

                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }




                if (info.type == "STatType3")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_STatType3_Midd> query = new List<tblEQIA_P_STatType3_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);


                        query = (from x in db.tblEQIA_P_STatType3_Midd
                                 where x.TimeType == info.TimeType &&
                                 x.AppriseID == info.AppriseID &&
                                 list.Contains(x.fldDate)
                                 select x).ToList();


                        ReturnData3 rd = new ReturnData3();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_STatType3_Midd> query2 = new List<tblEQIA_P_STatType3_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            query2 = (from x in db.tblEQIA_P_STatType3_Midd
                                      where x.TimeType == info.TimeType &&
                                      x.AppriseID == info.AppriseID &&
                                      list.Contains(x.fldDate)
                                      select x).ToList();

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }




                if (info.type == "STatType4")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_STatType4_Midd> query = new List<tblEQIA_P_STatType4_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);


                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_P_STatType4_Midd
                                     where x.fldSDate >= BeginDate &&
                                     x.fldEDate <= EndDate
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in db.tblEQIA_P_STatType4_Midd
                                     where x.fldSDate >= BeginDate &&
                                     x.fldEDate <= EndDate &&
                                     info.fldSTCode.Contains(x.fldSTCode)
                                     select x).ToList();
                        }


                        ReturnData4 rd = new ReturnData4();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_STatType4_Midd> query2 = new List<tblEQIA_P_STatType4_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_P_STatType4_Midd
                                          where x.fldSDate >= BeginDate &&
                                          x.fldEDate <= EndDate
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIA_P_STatType4_Midd
                                          where x.fldSDate >= BeginDate &&
                                          x.fldEDate <= EndDate &&
                                          info.fldSTCode.Contains(x.fldSTCode)
                                          select x).ToList();
                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }




                if (info.type == "STatType5")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_STatType5_Midd> query = new List<tblEQIA_P_STatType5_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);





                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_P_STatType5_Midd
                                     where x.TimeType == info.TimeType &&
                                     x.AppriseID == info.AppriseID &&
                                     x.fldYear == info.fldYear
                                     select x).ToList();
                        }
                        else
                        {
                            if (info.AppriseID == "0")
                            {
                                query = (from x in db.tblEQIA_P_STatType5_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                         x.fldYear == info.fldYear
                                         select x).ToList();

                            }

                            if (info.AppriseID == "1")
                            {
                                query = (from x in db.tblEQIA_P_STatType5_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode) &&
                                         x.fldYear == info.fldYear
                                         select x).ToList();
                            }


                        }


                        ReturnData5 rd = new ReturnData5();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_STatType5_Midd> query2 = new List<tblEQIA_P_STatType5_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);


                            int year = int.Parse(info.fldYear) - 1;


                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_P_STatType5_Midd
                                          where x.TimeType == info.TimeType &&
                                          x.AppriseID == info.AppriseID &&
                                          x.fldYear == year.ToString()
                                          select x).ToList();
                            }
                            else
                            {
                                if (info.AppriseID == "0")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType5_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                              x.fldYear == year.ToString()
                                              select x).ToList();

                                }

                                if (info.AppriseID == "1")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType5_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode) &&
                                              x.fldYear == year.ToString()
                                              select x).ToList();
                                }


                            }


                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }



                if (info.type == "STatType6")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_STatType6_Midd> query = new List<tblEQIA_P_STatType6_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);




                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_P_STatType6_Midd
                                     where x.TimeType == info.TimeType &&
                                     x.AppriseID == info.AppriseID &&
                                     x.fldYear == info.fldYear
                                     select x).ToList();
                        }
                        else
                        {
                            if (info.AppriseID == "0")
                            {
                                query = (from x in db.tblEQIA_P_STatType6_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                         x.fldYear == info.fldYear
                                         select x).ToList();
                            }

                            if (info.AppriseID == "1")
                            {
                                query = (from x in db.tblEQIA_P_STatType6_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode) &&
                                         x.fldYear == info.fldYear
                                         select x).ToList();
                            }
                        }






                        ReturnData6 rd = new ReturnData6();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_STatType6_Midd> query2 = new List<tblEQIA_P_STatType6_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            int year = int.Parse(info.fldYear) - 1;


                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_P_STatType6_Midd
                                          where x.TimeType == info.TimeType &&
                                          x.AppriseID == info.AppriseID &&
                                          x.fldYear == year.ToString()
                                          select x).ToList();
                            }
                            else
                            {
                                if (info.AppriseID == "0")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType6_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                              x.fldYear == year.ToString()
                                              select x).ToList();
                                }

                                if (info.AppriseID == "1")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType6_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode) &&
                                              x.fldYear == year.ToString()
                                              select x).ToList();
                                }
                            }

                            rd.tongqi = query2;
                        }

                        result = rule.JsonStr("ok", "", rd);
                    }
                }



                if (info.type == "STatType7")
                {
                    using (MiddleContext db = new MiddleContext())
                    {

                        List<tblEQIA_P_STatType7_Midd> query = new List<tblEQIA_P_STatType7_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.TimeType, BeginDate, EndDate);


                        if (info.fldSTCode == "-1")
                        {
                            query = (from x in db.tblEQIA_P_STatType7_Midd
                                     where x.TimeType == info.TimeType &&
                                     x.AppriseID == info.AppriseID &&
                                     x.fldYear == info.fldYear
                                     select x).ToList();
                        }
                        else
                        {
                            if (info.AppriseID == "0")
                            {
                                query = (from x in db.tblEQIA_P_STatType7_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                         x.fldYear == info.fldYear
                                         select x).ToList();
                            }

                            if (info.AppriseID == "1")
                            {
                                query = (from x in db.tblEQIA_P_STatType7_Midd
                                         where x.TimeType == info.TimeType &&
                                         x.AppriseID == info.AppriseID &&
                                         info.fldSTCode.Contains(x.fldSTCode) &&
                                         x.fldYear == info.fldYear
                                         select x).ToList();
                            }
                        }


                        ReturnData7 rd = new ReturnData7();
                        rd.dangqi = query;


                        if (info.IsYear == "1")
                        {
                            List<tblEQIA_P_STatType7_Midd> query2 = new List<tblEQIA_P_STatType7_Midd>();

                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            int year = int.Parse(info.fldYear) - 1;


                            list = ConvertDate(info.TimeType, BeginDate, EndDate);

                            if (info.fldSTCode == "-1")
                            {
                                query2 = (from x in db.tblEQIA_P_STatType7_Midd
                                          where x.TimeType == info.TimeType &&
                                          x.AppriseID == info.AppriseID &&
                                          x.fldYear == year.ToString()
                                          select x).ToList();
                            }
                            else
                            {
                                if (info.AppriseID == "0")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType7_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode + "." + x.fldPCode) &&
                                              x.fldYear == year.ToString()
                                              select x).ToList();
                                }

                                if (info.AppriseID == "1")
                                {
                                    query2 = (from x in db.tblEQIA_P_STatType7_Midd
                                              where x.TimeType == info.TimeType &&
                                              x.AppriseID == info.AppriseID &&
                                              info.fldSTCode.Contains(x.fldSTCode) &&
                                              x.fldYear == year.ToString()
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
            /// “BaseData” = 原始数据表
            /// “ResultStat” = 降水点位、城市监测结果统计
            /// “STatType2” = 点位、城市各时段酸雨频率、酸度比例
            /// “STatType3” = 各时段点位、城市酸雨频率、酸度比例
            /// “STatType4” = 阴阳离子平衡
            /// “STatType5” = 样品数统计表
            /// “STatType6” = 离子当量比例
            /// “STatType7” = 离子当量浓度
            /// </summary>
            public string type { get; set; }

            /// <summary>
            /// 时间类型：
            /// “month”、“sea”、“halfyear”、“year”
            /// </summary>
            public string TimeType { get; set; }



            /// <summary>
            /// 0：原始数据表(不带L)
            /// 10：原始数据表(带L)
            /// </summary>
            public string STatType { get; set; }



            /// <summary>
            /// 年份
            /// </summary>
            public string fldYear { get; set; }


            /// <summary>
            /// 0:针对单个点位评价、1：针对城市评价
            /// </summary>
            public string AppriseID { get; set; }


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



        }





        /// <summary>
        /// “BaseData”
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIA_P_BaseData_Midd> dangqi { get; set; }

            public List<tblEQIA_P_BaseData_Midd> tongqi { get; set; }
        }



        /// <summary>
        /// “ResultStat”
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQIA_P_ResultStat_Midd> dangqi { get; set; }

            public List<tblEQIA_P_ResultStat_Midd> tongqi { get; set; }
        }




        /// <summary>
        /// “STatType2”
        /// </summary>
        public class ReturnData2
        {
            public List<tblEQIA_P_STatType2_Midd> dangqi { get; set; }

            public List<tblEQIA_P_STatType2_Midd> tongqi { get; set; }
        }




        /// <summary>
        /// “STatType3”
        /// </summary>
        public class ReturnData3
        {
            public List<tblEQIA_P_STatType3_Midd> dangqi { get; set; }

            public List<tblEQIA_P_STatType3_Midd> tongqi { get; set; }
        }

        /// <summary>
        /// “STatType4”
        /// </summary>
        public class ReturnData4
        {
            public List<tblEQIA_P_STatType4_Midd> dangqi { get; set; }

            public List<tblEQIA_P_STatType4_Midd> tongqi { get; set; }
        }




        /// <summary>
        /// “STatType5”
        /// </summary>
        public class ReturnData5
        {
            public List<tblEQIA_P_STatType5_Midd> dangqi { get; set; }

            public List<tblEQIA_P_STatType5_Midd> tongqi { get; set; }
        }



        /// <summary>
        /// “STatType6”
        /// </summary>
        public class ReturnData6
        {
            public List<tblEQIA_P_STatType6_Midd> dangqi { get; set; }

            public List<tblEQIA_P_STatType6_Midd> tongqi { get; set; }
        }


        /// <summary>
        /// “STatType7”
        /// </summary>
        public class ReturnData7
        {
            public List<tblEQIA_P_STatType7_Midd> dangqi { get; set; }

            public List<tblEQIA_P_STatType7_Midd> tongqi { get; set; }
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
