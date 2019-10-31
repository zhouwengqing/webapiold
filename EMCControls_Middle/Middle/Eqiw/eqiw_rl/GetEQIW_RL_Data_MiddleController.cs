using DDYZ.Ensis.Rule.DataRule;
using EMCControls_Middle.Middle.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EMCControls_EMCMIS.EMCMIS.Model;


namespace EMCControls_Middle.Middle.Eqiw.eqiw_rl
{
    /// <summary>
    /// 
    /// </summary>
    public class GetEQIW_RL_Data_MiddleController : ApiController
    {

        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2017-12-7
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

                        List<tblEQIW_RL_ItemOverStat_Midd> query = new List<tblEQIW_RL_ItemOverStat_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        if (info.IsTotal == "1" || info.IsTotal == "2")
                        {
                            list.Add("平均");
                        }






                        query = (from x in db.tblEQIW_RL_ItemOverStat_Midd
                                 where x.fldTimeType == info.fldTimeType &&
                                                     x.fldSectionType == info.fldSCategory &&
                                                     list.Contains(x.fldAppDate) &&
                                                     x.fldSpace == info.fldSpaceName
                                 select x).ToList();










                        #region 均值相关操作


                        if (info.IsTotal == "1")
                        {
                            var query_avg = (from x in query
                                             where x.fldAppDate == "平均" &&
                                             x.fldBeginDate < BeginDate && x.fldEndDate > EndDate
                                             select x).ToList();

                            foreach (var item in query_avg)
                            {
                                query.Remove(item);
                            }
                        }
                        else if (info.IsTotal == "2")
                        {
                            query = (from x in query
                                     where x.fldAppDate == "平均" &&
                                     x.fldBeginDate == BeginDate &&
                                     x.fldEndDate == EndDate
                                     select x).ToList();
                        }


                        #endregion




















                        ReturnData rd = new ReturnData();
                        rd.dangqi = query;














                        if (info.IsYear == "1")
                        {

                            List<tblEQIW_RL_ItemOverStat_Midd> query2 = new List<tblEQIW_RL_ItemOverStat_Midd>();


                            BeginDate = BeginDate.AddYears(-1);
                            EndDate = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);



                            query2 = (from x in db.tblEQIW_RL_ItemOverStat_Midd
                                      where x.fldTimeType == info.fldTimeType &&
                                                                  x.fldSectionType == info.fldSCategory &&
                                                                  list.Contains(x.fldAppDate) &&
                                                                  x.fldSpace == info.fldSpaceName
                                      select x).ToList();





                            #region 均值相关操作


                            if (info.IsTotal == "1")
                            {
                                var query_avg = (from x in query2
                                                 where x.fldAppDate == "平均" &&
                                                 x.fldBeginDate < BeginDate && x.fldEndDate > EndDate
                                                 select x).ToList();

                                foreach (var item in query_avg)
                                {
                                    query2.Remove(item);
                                }
                            }
                            else if (info.IsTotal == "2")
                            {
                                query2 = (from x in query2
                                          where x.fldAppDate == "平均" &&
                                          x.fldBeginDate == BeginDate &&
                                          x.fldEndDate == EndDate
                                          select x).ToList();
                            }


                            #endregion













                            rd.tongqi = query2;
                        }










                        result = rule.JsonStr("ok", "", rd);
                    }
                }


                if (info.type == "SectionStat")
                {

                    using (MiddleContext db = new MiddleContext())
                    {

                        ReturnData1 rd = new ReturnData1();

                        List<tblEQIW_RL_SectionStat_Midd> query = new List<tblEQIW_RL_SectionStat_Midd>();
                        List<tblEQIW_RL_SectionStat_Item_Midd> query_Item = new List<tblEQIW_RL_SectionStat_Item_Midd>();




                        List<string> list = new List<string>();


                        DateTime BeginDate = new DateTime();
                        DateTime EndDate = new DateTime();

                        if (info.fldBeginDate == "-1" || info.fldEndDate == "-1")
                        {
                            list.Add("平均");
                        }
                        else
                        {
                            BeginDate = DateTime.Parse(info.fldBeginDate);
                            EndDate = DateTime.Parse(info.fldEndDate);
                            list = ConvertDate(info.fldTimeType, BeginDate, EndDate);





                            #region 均值相关操作

                            if (info.IsTotal == "1")
                            {
                                query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                         where x.fldTimeType == info.fldTimeType &&
                                         list.Contains(x.fldAppDate)
                                         select x).ToList();

                                list.Clear();

                                list.Add("平均");


                                var query_temp = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                  where x.fldTimeType == info.fldTimeType &&
                                                  list.Contains(x.fldAppDate) &&
                                                  x.fldBeginDate >= BeginDate && x.fldEndDate <= EndDate
                                                  select x).ToList();

                                query.AddRange(query_temp);


                            }
                            else if (info.IsTotal == "2")
                            {
                                list.Clear();
                                list.Add("平均");

                                if (info.Special == "2")
                                {
                                    DateTime dateTime_Temp = new DateTime(BeginDate.Year, 1, 1);
                                    query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                             where x.fldTimeType == info.fldTimeType &&
                                             list.Contains(x.fldAppDate) &&
                                             x.fldBeginDate == dateTime_Temp &&
                                             x.fldEndDate <= EndDate
                                             select x).ToList();
                                }
                                else
                                {
                                    query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                             where x.fldTimeType == info.fldTimeType &&
                                             list.Contains(x.fldAppDate) &&
                                             x.fldBeginDate == BeginDate &&
                                             x.fldEndDate == EndDate
                                             select x).ToList();
                                }
                            }
                            else
                            {
                                query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                         where x.fldTimeType == info.fldTimeType &&
                                         list.Contains(x.fldAppDate)
                                         select x).ToList();
                            }

                            #endregion
                        }


                        if (info.fldKHLevel == null)
                        {
                            query = (from x in query
                                     where x.fldKHLevel != "7" && x.fldKHLevel != "6"
                                     select x).ToList();
                        }
                        else
                        {
                            query = (from x in query
                                     where x.fldKHLevel == info.fldKHLevel
                                     select x).ToList();
                        }






                        if (info.fldSTCode == "-1")
                        {
                            if (info.fldSCategory == null || info.fldSCategory == "")
                            {
                                if (info.fldTimeType == "day")
                                {
                                    query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                             where x.fldTimeType == info.fldTimeType &&
                                             x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                             x.fldAppDate.CompareTo(info.fldEndDate) <= 0
                                             select x).ToList();
                                }

                            }
                            else
                            {
                                query = (from x in query
                                         where info.fldSCategory.Contains(x.fldSCategory)
                                         select x).ToList();

                                if (info.fldTimeType == "day")
                                {
                                    query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                             where x.fldTimeType == info.fldTimeType &&
                                             x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                             x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                             info.fldSCategory.Contains(x.fldSCategory)
                                             select x).ToList();
                                }
                            }
                        }
                        else
                        {
                            if (info.fldSCategory == null || info.fldSCategory == "")
                            {
                                if (info.CityFormat == "1")
                                {
                                    query = (from x in query
                                             where info.fldSTCode.Contains(x.fldSTCode)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldSTCode.Contains(x.fldSTCode)
                                                 select x).ToList();
                                    }
                                }
                                else if (info.CityFormat == "2")
                                {
                                    query = (from x in query
                                             where info.fldRCode.Contains(x.fldRCode)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldRCode.Contains(x.fldRCode)
                                                 select x).ToList();
                                    }
                                }
                                else if (info.CityFormat == "3")
                                {
                                    query = (from x in query
                                             where info.fldRSCode.Contains(x.fldRSCode)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldRSCode.Contains(x.fldRSCode)
                                                 select x).ToList();
                                    }
                                }
                                else
                                {
                                    query = (from x in query
                                             where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                                 select x).ToList();
                                    }
                                }

                            }
                            else
                            {
                                if (info.CityFormat == "1")
                                {
                                    query = (from x in query
                                             where info.fldSTCode.Contains(x.fldSTCode) &&
                                             info.fldSCategory.Contains(x.fldSCategory)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldSTCode.Contains(x.fldSTCode) &&
                                                 info.fldSCategory.Contains(x.fldSCategory)
                                                 select x).ToList();
                                    }
                                }
                                else if (info.CityFormat == "2")
                                {
                                    query = (from x in query
                                             where info.fldRCode.Contains(x.fldRCode) &&
                                             info.fldSCategory.Contains(x.fldSCategory)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldRCode.Contains(x.fldRCode) &&
                                                 info.fldSCategory.Contains(x.fldSCategory)
                                                 select x).ToList();
                                    }
                                }
                                else if (info.CityFormat == "3")
                                {
                                    query = (from x in query
                                             where info.fldRSCode.Contains(x.fldRSCode) &&
                                             info.fldSCategory.Contains(x.fldSCategory)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldRSCode.Contains(x.fldRSCode) &&
                                                 info.fldSCategory.Contains(x.fldSCategory)
                                                 select x).ToList();
                                    }
                                }
                                else
                                {
                                    query = (from x in query
                                             where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                             info.fldSCategory.Contains(x.fldSCategory)
                                             select x).ToList();

                                    if (info.fldTimeType == "day")
                                    {
                                        query = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                 where x.fldTimeType == info.fldTimeType &&
                                                 x.fldAppDate.CompareTo(info.fldBeginDate) >= 0 &&
                                                 x.fldAppDate.CompareTo(info.fldEndDate) <= 0 &&
                                                 info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                                 info.fldSCategory.Contains(x.fldSCategory)
                                                 select x).ToList();
                                    }
                                }
                            }
                        }









                        if (info.StaLodAndStaLad == "1")
                        {
                            DataTable dt2 = new DataTable();

                            dt2 = rule.SqlQueryForDataTatable("EntityContext", "select * from tblEQIW_R_Section");

                            dt2.Columns.Add("fldStaLod", typeof(string));
                            dt2.Columns.Add("fldStaLad", typeof(string));

                            foreach (DataRow item in dt2.Rows)
                            {
                                item["fldStaLod"] = (double.Parse(item["fldLOD"].ToString()) + double.Parse(item["fldLOM"].ToString()) / 60 + double.Parse(item["fldLOS"].ToString()) / 3600).ToString();
                                item["fldStaLad"] = (double.Parse(item["fldLAD"].ToString()) + double.Parse(item["fldLAM"].ToString()) / 60 + double.Parse(item["fldLAS"].ToString()) / 3600).ToString();
                            }

                            foreach (var item in query)
                            {
                                foreach (DataRow item2 in dt2.Rows)
                                {
                                    if
                                    (
                                        item.fldSTCode == item2["fldSTCode"].ToString() &&
                                        item.fldRCode == item2["fldRCode"].ToString() &&
                                        item.fldRSCode == item2["fldRSCode"].ToString() &&
                                        item.fldAppDate.ToString().Substring(0, 4) == item2["fldYear"].ToString()
                                    )
                                    {
                                        item.fldStaLod = item2["fldStaLod"].ToString();
                                        item.fldStaLad = item2["fldStaLad"].ToString();
                                    }
                                }
                            }

                        }












                        if (info.fldItemCode != null && info.fldItemCode != "")
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIW_RL_SectionStat_Item_Midd
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




                        rd.dangqi = query;
                        rd.dangqi_Item = query_Item;









                        if (info.IsYear == "1")
                        {
                            List<tblEQIW_RL_SectionStat_Midd> query2 = new List<tblEQIW_RL_SectionStat_Midd>();
                            List<tblEQIW_RL_SectionStat_Item_Midd> query_Item2 = new List<tblEQIW_RL_SectionStat_Item_Midd>();

                            DateTime BeginDate_IsYear = BeginDate.AddYears(-1);
                            DateTime EndDate_IsYear = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate_IsYear, EndDate_IsYear);


                            #region 均值相关操作

                            if (info.IsTotal == "1")
                            {
                                //list.Add("平均");

                                //query2 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                //          where x.fldTimeType == info.fldTimeType &&
                                //          list.Contains(x.fldAppDate) &&
                                //          x.fldBeginDate >= BeginDate && x.fldEndDate <= EndDate
                                //          select x).ToList();



                                query2 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate)
                                          select x).ToList();

                                list.Clear();

                                list.Add("平均");


                                var query_temp = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                  where x.fldTimeType == info.fldTimeType &&
                                                  list.Contains(x.fldAppDate) &&
                                                  x.fldBeginDate >= BeginDate_IsYear && x.fldEndDate <= EndDate_IsYear
                                                  select x).ToList();

                                query2.AddRange(query_temp);









                            }
                            else if (info.IsTotal == "2")
                            {
                                list.Clear();
                                list.Add("平均");

                                query2 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          x.fldBeginDate == BeginDate_IsYear &&
                                          x.fldEndDate == EndDate_IsYear
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate)
                                          select x).ToList();
                            }

                            #endregion



                            if (info.fldKHLevel == null)
                            {
                                query2 = (from x in query2
                                          where x.fldKHLevel != "7" && x.fldKHLevel != "6"
                                          select x).ToList();
                            }
                            else
                            {
                                query2 = (from x in query2
                                          where x.fldKHLevel == info.fldKHLevel
                                          select x).ToList();
                            }




                            if (info.fldSTCode == "-1")
                            {
                                if (info.fldSCategory != null)
                                {
                                    query2 = (from x in query2
                                              where info.fldSCategory.Contains(x.fldSCategory)
                                              select x).ToList();
                                }
                            }
                            else
                            {
                                if (info.fldSCategory == null)
                                {
                                    if (info.CityFormat == "1")
                                    {
                                        query2 = (from x in query2
                                                  where info.fldSTCode.Contains(x.fldSTCode)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "2")
                                    {
                                        query2 = (from x in query2
                                                  where info.fldRCode.Contains(x.fldRCode)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "3")
                                    {
                                        query2 = (from x in query2
                                                  where info.fldRSCode.Contains(x.fldRSCode)
                                                  select x).ToList();
                                    }
                                    else
                                    {
                                        query2 = (from x in query2
                                                  where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                                  select x).ToList();
                                    }
                                }
                                else
                                {
                                    if (info.CityFormat == "1")
                                    {
                                        query2 = (from x in query2
                                                  where info.fldSTCode.Contains(x.fldSTCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "2")
                                    {
                                        query2 = (from x in query2
                                                  where info.fldRCode.Contains(x.fldRCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "3")
                                    {
                                        query2 = (from x in query2
                                                  where info.fldRCode.Contains(x.fldRCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                    else
                                    {
                                        query2 = (from x in query2
                                                  where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                }
                            }









                            if (info.fldItemCode != null && info.fldItemCode != "")
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQIW_RL_SectionStat_Item_Midd
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





















                        if (info.IsPre == "1")
                        {
                            List<tblEQIW_RL_SectionStat_Midd> query3 = new List<tblEQIW_RL_SectionStat_Midd>();
                            List<tblEQIW_RL_SectionStat_Item_Midd> query_Item3 = new List<tblEQIW_RL_SectionStat_Item_Midd>();

                            DateTime BeginDate_IsPre = BeginDate.AddMonths(-1);
                            DateTime EndDate_IsPre = EndDate.AddMonths(-1);


                            if (info.Special == "1")
                            {
                                BeginDate_IsPre = BeginDate_IsPre.AddMonths(1);
                            }


                            list = ConvertDate(info.fldTimeType, BeginDate_IsPre, EndDate_IsPre);









                            #region 均值相关操作

                            if (info.Special == "1")
                            {
                                if (BeginDate_IsPre.Month == 1 && EndDate_IsPre.Month == 1)
                                {
                                    query3 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              x.fldAppDate == BeginDate_IsPre.Year.ToString() + "年12月" &&
                                              x.fldBeginDate == BeginDate_IsPre &&
                                              x.fldEndDate == EndDate_IsPre
                                              select x).ToList();
                                }
                                else
                                {
                                    query3 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              x.fldAppDate == "平均" &&
                                              x.fldBeginDate == BeginDate_IsPre &&
                                              x.fldEndDate == EndDate_IsPre
                                              select x).ToList();
                                }
                            }
                            else
                            {
                                if (info.IsTotal == "1")
                                {
                                    //list.Add("平均");

                                    //query3 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                    //          where x.fldTimeType == info.fldTimeType &&
                                    //          list.Contains(x.fldAppDate) &&
                                    //          x.fldBeginDate >= BeginDate && x.fldEndDate <= EndDate
                                    //          select x).ToList();


                                    query3 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate)
                                              select x).ToList();

                                    list.Clear();

                                    list.Add("平均");


                                    var query_temp = (from x in db.tblEQIW_RL_SectionStat_Midd
                                                      where x.fldTimeType == info.fldTimeType &&
                                                      list.Contains(x.fldAppDate) &&
                                                      x.fldBeginDate >= BeginDate_IsPre && x.fldEndDate <= EndDate_IsPre
                                                      select x).ToList();

                                    query3.AddRange(query_temp);




                                }
                                else if (info.IsTotal == "2")
                                {
                                    list.Clear();
                                    list.Add("平均");

                                    query3 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate) &&
                                              x.fldBeginDate == BeginDate &&
                                              x.fldEndDate == EndDate
                                              select x).ToList();
                                }
                                else
                                {
                                    query3 = (from x in db.tblEQIW_RL_SectionStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate)
                                              select x).ToList();
                                }
                            }

                            #endregion




                            if (info.fldKHLevel == null)
                            {
                                query3 = (from x in query3
                                          where x.fldKHLevel != "7" && x.fldKHLevel != "6"
                                          select x).ToList();
                            }
                            else
                            {
                                query3 = (from x in query3
                                          where x.fldKHLevel == info.fldKHLevel
                                          select x).ToList();
                            }







                            if (info.fldSTCode == "-1")
                            {
                                if (info.fldSCategory != null)
                                {
                                    query3 = (from x in query3
                                              where info.fldSCategory.Contains(x.fldSCategory)
                                              select x).ToList();
                                }
                            }
                            else
                            {
                                if (info.fldSCategory == null)
                                {
                                    if (info.CityFormat == "1")
                                    {
                                        query3 = (from x in query3
                                                  where info.fldSTCode.Contains(x.fldSTCode)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "2")
                                    {
                                        query3 = (from x in query3
                                                  where info.fldRCode.Contains(x.fldRCode)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "3")
                                    {
                                        query3 = (from x in query3
                                                  where info.fldRSCode.Contains(x.fldRSCode)
                                                  select x).ToList();
                                    }
                                    else
                                    {
                                        query3 = (from x in query3
                                                  where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                                  select x).ToList();
                                    }
                                }
                                else
                                {
                                    if (info.CityFormat == "1")
                                    {
                                        query3 = (from x in query3
                                                  where info.fldSTCode.Contains(x.fldSTCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "2")
                                    {
                                        query3 = (from x in query3
                                                  where info.fldRCode.Contains(x.fldRCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                    else if (info.CityFormat == "3")
                                    {
                                        query3 = (from x in query3
                                                  where info.fldRCode.Contains(x.fldRCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                    else
                                    {
                                        query3 = (from x in query3
                                                  where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                                  info.fldSCategory.Contains(x.fldSCategory)
                                                  select x).ToList();
                                    }
                                }
                            }





                            if (info.fldItemCode != null && info.fldItemCode != "")
                            {
                                query_Item3 = (from x in query3
                                               join y in db.tblEQIW_RL_SectionStat_Item_Midd
                                               on x.fldAutoID equals y.fldFKID
                                               select y).ToList();

                                if (info.fldItemCode != "All")
                                {
                                    string[] ItemCodeList = info.fldItemCode.Split(',');

                                    query_Item3 = (from x in query_Item3
                                                   where ItemCodeList.Contains(x.fldItemCode)
                                                   select x).ToList();
                                }
                            }

                            rd.qianqi = query3;
                            rd.qianqi_Item = query_Item3;
                        }






                        result = rule.JsonStr("ok", "", rd);
                    }

                }


                if (info.type == "TatalSectStat")
                {


                    using (MiddleContext db = new MiddleContext())
                    {
                        List<tblEQIW_RL_TatalSectStat_Midd> query = new List<tblEQIW_RL_TatalSectStat_Midd>();
                        List<tblEQIW_RL_TatalSectStat_Item_Midd> query_Item = new List<tblEQIW_RL_TatalSectStat_Item_Midd>();

                        DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                        DateTime EndDate = DateTime.Parse(info.fldEndDate);

                        List<string> list = ConvertDate(info.fldTimeType, BeginDate, EndDate);





                        #region 均值相关操作

                        if (info.IsTotal == "1")
                        {
                            query = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate)
                                     select x).ToList();

                            list.Clear();

                            list.Add("平均");


                            var query_temp = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate) &&
                                              x.fldBeginDate >= BeginDate && x.fldEndDate <= EndDate
                                              select x).ToList();

                            query.AddRange(query_temp);


                        }
                        else if (info.IsTotal == "2")
                        {
                            list.Clear();
                            list.Add("平均");

                            if (info.Special == "2")
                            {
                                DateTime dateTime_Temp = new DateTime(BeginDate.Year, 1, 1);
                                query = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                         where x.fldTimeType == info.fldTimeType &&
                                         list.Contains(x.fldAppDate) &&
                                         x.fldBeginDate == dateTime_Temp &&
                                         x.fldEndDate <= EndDate
                                         select x).ToList();
                            }
                            else
                            {
                                query = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                         where x.fldTimeType == info.fldTimeType &&
                                         list.Contains(x.fldAppDate) &&
                                         x.fldBeginDate == BeginDate &&
                                         x.fldEndDate == EndDate
                                         select x).ToList();
                            }
                        }
                        else
                        {
                            query = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                     where x.fldTimeType == info.fldTimeType &&
                                     list.Contains(x.fldAppDate)
                                     select x).ToList();
                        }

                        #endregion





















                        List<string> fldSpaceTypeList = info.fldSpaceType.Split(',').ToList();

                        if (info.fldSpaceName == null || info.fldSpaceName == "")
                        {

                            query = (from x in query
                                     where x.fldTimeType == info.fldTimeType &&
                                     info.fldSpaceType.Contains(x.fldSpaceType) &&
                                     info.fldSCategory.Contains(x.fldSCategory)
                                     select x).ToList();
                        }
                        else
                        {
                            if (info.SpaceNameIsList == "1")
                            {
                                query = (from x in query
                                         where x.fldTimeType == info.fldTimeType &&
                                         info.fldSpaceType.Contains(x.fldSpaceType) &&
                                         x.fldSpaceName == info.fldSpaceName &&
                                         info.fldSCategory.Contains(x.fldSCategory)
                                         select x).ToList();
                            }
                            else
                            {
                                query = (from x in query
                                         where x.fldTimeType == info.fldTimeType &&
                                         info.fldSpaceType.Contains(x.fldSpaceType) &&
                                         info.fldSpaceName.Contains(x.fldSpaceName) &&
                                         info.fldSCategory.Contains(x.fldSCategory)
                                         select x).ToList();
                            }
                        }



                        List<tblEQIW_RL_TatalSectStat_Midd> query3 = new List<tblEQIW_RL_TatalSectStat_Midd>();

                        foreach (var item in fldSpaceTypeList)
                        {
                            var query4 = (from x in query
                                          where x.fldSpaceType == item
                                          select x).ToList();
                            query3.AddRange(query4);
                        }

                        query = query3;



                        if (info.fldItemCode != null && info.fldItemCode != "")
                        {
                            query_Item = (from x in query
                                          join y in db.tblEQIW_RL_TatalSectStat_Item_Midd
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
                            List<tblEQIW_RL_TatalSectStat_Midd> query2 = new List<tblEQIW_RL_TatalSectStat_Midd>();
                            List<tblEQIW_RL_TatalSectStat_Item_Midd> query_Item2 = new List<tblEQIW_RL_TatalSectStat_Item_Midd>();

                            DateTime BeginDate_IsYear = BeginDate.AddYears(-1);
                            DateTime EndDate_IsYear = EndDate.AddYears(-1);

                            list = ConvertDate(info.fldTimeType, BeginDate_IsYear, EndDate_IsYear);

                            if (info.IsTotal == "1" || info.IsTotal == "2")
                            {
                                list.Add("平均");
                            }


                            if (info.fldSpaceName == null || info.fldSpaceName == "")
                            {
                                query2 = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                          where x.fldTimeType == info.fldTimeType &&
                                          list.Contains(x.fldAppDate) &&
                                          info.fldSpaceType.Contains(x.fldSpaceType) &&
                                          info.fldSCategory.Contains(x.fldSCategory)
                                          select x).ToList();
                            }
                            else
                            {
                                if (info.SpaceNameIsList == "1")
                                {
                                    query2 = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate) &&
                                              info.fldSpaceType.Contains(x.fldSpaceType) &&
                                              x.fldSpaceName == info.fldSpaceName &&
                                              info.fldSCategory.Contains(x.fldSCategory)
                                              select x).ToList();
                                }
                                else
                                {
                                    query2 = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                              where x.fldTimeType == info.fldTimeType &&
                                              list.Contains(x.fldAppDate) &&
                                              info.fldSpaceType.Contains(x.fldSpaceType) &&
                                              info.fldSpaceName.Contains(x.fldSpaceName) &&
                                              info.fldSCategory.Contains(x.fldSCategory)
                                              select x).ToList();
                                }
                            }








                            List<tblEQIW_RL_TatalSectStat_Midd> query5 = new List<tblEQIW_RL_TatalSectStat_Midd>();



                            foreach (var item in fldSpaceTypeList)
                            {
                                var query4 = (from x in query2
                                              where x.fldSpaceType == item
                                              select x).ToList();

                                if (query4.Count > 0)
                                {
                                    query5.AddRange(query4);
                                }
                            }

                            if (query5 != null)
                            {
                                query2 = query5;
                            }







                            #region 同期-均值相关操作


                            if (info.IsTotal == "1")
                            {
                                var query_avg = (from x in query2
                                                 where x.fldAppDate == "平均" &&
                                                 x.fldBeginDate < BeginDate_IsYear && x.fldEndDate > EndDate_IsYear
                                                 select x).ToList();

                                foreach (var item in query_avg)
                                {
                                    query2.Remove(item);
                                }
                            }
                            else if (info.IsTotal == "2")
                            {
                                query2 = (from x in query2
                                          where x.fldAppDate == "平均" &&
                                          x.fldBeginDate == BeginDate_IsYear &&
                                          x.fldEndDate == EndDate_IsYear
                                          select x).ToList();
                            }


                            #endregion






                            if (info.fldItemCode != null && info.fldItemCode != "")
                            {
                                query_Item2 = (from x in query2
                                               join y in db.tblEQIW_RL_TatalSectStat_Item_Midd
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




                        if (info.IsPre == "1")
                        {
                            List<tblEQIW_RL_TatalSectStat_Midd> query10 = new List<tblEQIW_RL_TatalSectStat_Midd>();
                            List<tblEQIW_RL_TatalSectStat_Item_Midd> query_Item10 = new List<tblEQIW_RL_TatalSectStat_Item_Midd>();

                            DateTime BeginDate_IsPre = BeginDate.AddMonths(-1);
                            DateTime EndDate_IsPre = EndDate.AddMonths(-1);

                            if (info.Special == "1")
                            {
                                BeginDate_IsPre = BeginDate_IsPre.AddMonths(1);
                            }


                            list = ConvertDate(info.fldTimeType, BeginDate_IsPre, EndDate_IsPre);

                            if (info.IsTotal == "1" || info.IsTotal == "2")
                            {
                                list.Add("平均");
                            }


                            if (info.fldSpaceName == null || info.fldSpaceName == "")
                            {
                                query10 = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                           where x.fldTimeType == info.fldTimeType &&
                                           list.Contains(x.fldAppDate) &&
                                           info.fldSpaceType.Contains(x.fldSpaceType) &&
                                           info.fldSCategory.Contains(x.fldSCategory)
                                           select x).ToList();
                            }
                            else
                            {
                                if (info.SpaceNameIsList == "1")
                                {
                                    query10 = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                               where x.fldTimeType == info.fldTimeType &&
                                               list.Contains(x.fldAppDate) &&
                                               info.fldSpaceType.Contains(x.fldSpaceType) &&
                                               x.fldSpaceName == info.fldSpaceName &&
                                               info.fldSCategory.Contains(x.fldSCategory)
                                               select x).ToList();
                                }
                                else
                                {
                                    query10 = (from x in db.tblEQIW_RL_TatalSectStat_Midd
                                               where x.fldTimeType == info.fldTimeType &&
                                               list.Contains(x.fldAppDate) &&
                                               info.fldSpaceType.Contains(x.fldSpaceType) &&
                                               info.fldSpaceName.Contains(x.fldSpaceName) &&
                                               info.fldSCategory.Contains(x.fldSCategory)
                                               select x).ToList();
                                }
                            }








                            List<tblEQIW_RL_TatalSectStat_Midd> query5 = new List<tblEQIW_RL_TatalSectStat_Midd>();



                            foreach (var item in fldSpaceTypeList)
                            {
                                var query4 = (from x in query10
                                              where x.fldSpaceType == item
                                              select x).ToList();

                                if (query4.Count > 0)
                                {
                                    query5.AddRange(query4);
                                }
                            }

                            if (query5 != null)
                            {
                                query10 = query5;
                            }







                            #region 同期-均值相关操作



                            if (info.Special == "1")
                            {
                                if (BeginDate_IsPre.Month == 1 && EndDate_IsPre.Month == 1)
                                {
                                    query10 = (from x in query10
                                               where x.fldAppDate == BeginDate_IsPre.Year.ToString() + "年12月" &&
                                               x.fldBeginDate == BeginDate_IsPre &&
                                               x.fldEndDate == EndDate_IsPre
                                               select x).ToList();
                                }
                                else
                                {
                                    query10 = (from x in query10
                                               where x.fldAppDate == "平均" &&
                                               x.fldBeginDate == BeginDate_IsPre &&
                                               x.fldEndDate == EndDate_IsPre
                                               select x).ToList();
                                }
                            }
                            else
                            {
                                if (info.IsTotal == "1")
                                {
                                    var query_avg = (from x in query10
                                                     where x.fldAppDate == "平均" &&
                                                     x.fldBeginDate < BeginDate_IsPre && x.fldEndDate > EndDate_IsPre
                                                     select x).ToList();

                                    foreach (var item in query_avg)
                                    {
                                        query10.Remove(item);
                                    }
                                }
                                else if (info.IsTotal == "2")
                                {
                                    query10 = (from x in query10
                                               where x.fldAppDate == "平均" &&
                                              x.fldBeginDate == BeginDate_IsPre &&
                                              x.fldEndDate == EndDate_IsPre
                                               select x).ToList();
                                }
                            }



                            #endregion






                            if (info.fldItemCode != null && info.fldItemCode != "")
                            {
                                query_Item10 = (from x in query10
                                                join y in db.tblEQIW_RL_TatalSectStat_Item_Midd
                                                on x.fldAutoID equals y.fldFKID
                                                select y).ToList();

                                if (info.fldItemCode != "All")
                                {
                                    string[] ItemCodeList = info.fldItemCode.Split(',');

                                    query_Item10 = (from x in query_Item10
                                                    where ItemCodeList.Contains(x.fldItemCode)
                                                    select x).ToList();
                                }
                            }

                            rd.qianqi = query10;
                            rd.qianqi_Item = query_Item10;
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
            /// “SectionStat”，断面
            /// “TatalSectStat”，合计
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
            /// “RSWaterWork”
            /// “RCode”
            /// </summary>
            public string fldSpaceType { get; set; }

            /// <summary>
            /// null查询所有
            /// 传值部分查询：“均值”
            /// </summary>
            public string fldSpaceName { get; set; }


            /// <summary>
            /// “全部”、“河流”、“湖库”
            /// </summary>
            public string fldSCategory { get; set; }


            /// <summary>
            /// 城市格式
            /// 为1的情况下，按照城市
            /// 为2，按照河流
            /// 为3，按照断面
            /// 为null的情况下，按照点位格式
            /// </summary>
            public string CityFormat { get; set; }


            /// <summary>
            /// 河流代码
            /// </summary>
            public string fldRCode { get; set; }

            /// <summary>
            /// 断面代码
            /// </summary>
            public string fldRSCode { get; set; }


            /// <summary>
            /// 值为1，全等匹配SpaceName
            /// 为null，包含关系
            /// </summary>
            public string SpaceNameIsList { get; set; }


            /// <summary>
            /// 是否增加经度纬度
            /// 1：增加经度纬度列fldStaLod和fldStaLad
            /// </summary>
            public string StaLodAndStaLad { get; set; }



            /// <summary>
            /// 是否返回合计值
            /// "1"：返回日期范围内的单月数据和日期范围内的均值数据
            /// "2"：只返回精确日期下的均值数据
            /// "3"：结束日期减一个月来得出合计
            /// </summary>
            public string IsTotal { get; set; }


            /// <summary>
            /// "1"：返回前期数据
            /// </summary>
            public string IsPre { get; set; }


            /// <summary>
            /// 特殊参数
            /// </summary>
            public string Special { get; set; }



            /// <summary>
            /// 考核级别
            /// 如果不传为null，就会筛选出非7的数据
            /// </summary>
            public string fldKHLevel { get; set; }


        }

        /// <summary>
        /// “ItemOverStat”
        /// </summary>
        public class ReturnData
        {
            public List<tblEQIW_RL_ItemOverStat_Midd> dangqi { get; set; }

            public List<tblEQIW_RL_ItemOverStat_Midd> tongqi { get; set; }
        }

        /// <summary>
        /// “SectionStat”
        /// </summary>
        public class ReturnData1
        {
            public List<tblEQIW_RL_SectionStat_Midd> dangqi { get; set; }

            public List<tblEQIW_RL_SectionStat_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIW_RL_SectionStat_Midd> tongqi { get; set; }

            public List<tblEQIW_RL_SectionStat_Item_Midd> tongqi_Item { get; set; }

            public List<tblEQIW_RL_SectionStat_Midd> qianqi { get; set; }

            public List<tblEQIW_RL_SectionStat_Item_Midd> qianqi_Item { get; set; }


            public object HistoryWorstData { get; set; }
        }

        /// <summary>
        /// “TatalSectStat”
        /// </summary>
        public class ReturnData2
        {
            public List<tblEQIW_RL_TatalSectStat_Midd> dangqi { get; set; }

            public List<tblEQIW_RL_TatalSectStat_Item_Midd> dangqi_Item { get; set; }

            public List<tblEQIW_RL_TatalSectStat_Midd> tongqi { get; set; }

            public List<tblEQIW_RL_TatalSectStat_Item_Midd> tongqi_Item { get; set; }

            public List<tblEQIW_RL_TatalSectStat_Midd> qianqi { get; set; }

            public List<tblEQIW_RL_TatalSectStat_Item_Midd> qianqi_Item { get; set; }

        }




        public List<string> ConvertDate(string fldTimeType, DateTime BeginDate, DateTime EndDate)
        {
            List<string> list = new List<string>();

            if (fldTimeType == "month")
            {
                if (BeginDate.Year == EndDate.Year)
                {
                    for (int i = BeginDate.Month; i <= EndDate.Month; i++)
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

                if (BeginDate.Year < EndDate.Year)
                {
                    for (int i = BeginDate.Year; i <= EndDate.Year; i++)
                    {
                        if (i == BeginDate.Year)
                        {
                            for (int j = BeginDate.Month; j <= 12; j++)
                            {
                                if (j < 10)
                                {
                                    list.Add(i.ToString() + "年0" + j.ToString() + "月");
                                }
                                else
                                {
                                    list.Add(i.ToString() + "年" + j.ToString() + "月");
                                }
                            }
                        }
                        else if (i == EndDate.Year)
                        {
                            for (int j = 1; j <= EndDate.Month; j++)
                            {
                                if (j < 10)
                                {
                                    list.Add(i.ToString() + "年0" + j.ToString() + "月");
                                }
                                else
                                {
                                    list.Add(i.ToString() + "年" + j.ToString() + "月");
                                }
                            }
                        }
                        else
                        {
                            for (int j = 1; j <= 12; j++)
                            {
                                if (j < 10)
                                {
                                    list.Add(i.ToString() + "年0" + j.ToString() + "月");
                                }
                                else
                                {
                                    list.Add(i.ToString() + "年" + j.ToString() + "月");
                                }
                            }
                        }
                    }
                }
            }

            if (fldTimeType == "sea")
            {



                if (BeginDate.Year == EndDate.Year)
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




                if (BeginDate.Year < EndDate.Year)
                {
                    for (int i = BeginDate.Year; i <= EndDate.Year; i++)
                    {
                        if (i == BeginDate.Year)
                        {
                            if (BeginDate.Month == 1)
                            {
                                list.Add(i.ToString() + "年1季度");
                                list.Add(i.ToString() + "年2季度");
                                list.Add(i.ToString() + "年3季度");
                                list.Add(i.ToString() + "年4季度");
                            }
                            else if (BeginDate.Month == 4)
                            {
                                list.Add(i.ToString() + "年2季度");
                                list.Add(i.ToString() + "年3季度");
                                list.Add(i.ToString() + "年4季度");
                            }
                            else if (BeginDate.Month == 7)
                            {
                                list.Add(i.ToString() + "年3季度");
                                list.Add(i.ToString() + "年4季度");
                            }
                            else if (BeginDate.Month == 10)
                            {
                                list.Add(i.ToString() + "年4季度");
                            }






                            if (EndDate.Month == 3)
                            {
                                list.Add(i.ToString() + "年1季度");
                            }
                            else if (EndDate.Month == 6)
                            {
                                if (BeginDate.Month == 1)
                                {
                                    list.Add(i.ToString() + "年1季度");
                                    list.Add(i.ToString() + "年2季度");
                                }
                                else if (BeginDate.Month == 4)
                                {
                                    list.Add(i.ToString() + "年2季度");
                                }
                            }
                            else if (EndDate.Month == 9)
                            {
                                if (BeginDate.Month == 1)
                                {
                                    list.Add(i.ToString() + "年1季度");
                                    list.Add(i.ToString() + "年2季度");
                                    list.Add(i.ToString() + "年3季度");
                                }
                                else if (BeginDate.Month == 4)
                                {
                                    list.Add(i.ToString() + "年2季度");
                                    list.Add(i.ToString() + "年3季度");
                                }
                                else if (BeginDate.Month == 7)
                                {
                                    list.Add(i.ToString() + "年3季度");
                                }
                            }
                            else if (EndDate.Month == 12)
                            {
                                if (BeginDate.Month == 1)
                                {
                                    list.Add(i.ToString() + "年1季度");
                                    list.Add(i.ToString() + "年2季度");
                                    list.Add(i.ToString() + "年3季度");
                                    list.Add(i.ToString() + "年4季度");
                                }
                                else if (BeginDate.Month == 4)
                                {
                                    list.Add(i.ToString() + "年2季度");
                                    list.Add(i.ToString() + "年3季度");
                                    list.Add(i.ToString() + "年4季度");
                                }
                                else if (BeginDate.Month == 7)
                                {
                                    list.Add(i.ToString() + "年3季度");
                                    list.Add(i.ToString() + "年4季度");
                                }
                                else if (BeginDate.Month == 10)
                                {
                                    list.Add(i.ToString() + "年4季度");
                                }
                            }









                        }
                        else if (i == EndDate.Year)
                        {
                            if (EndDate.Month == 3)
                            {
                                list.Add(i.ToString() + "年1季度");
                            }
                            else if (EndDate.Month == 6)
                            {
                                list.Add(i.ToString() + "年1季度");
                                list.Add(i.ToString() + "年2季度");
                            }
                            else if (EndDate.Month == 9)
                            {
                                list.Add(i.ToString() + "年1季度");
                                list.Add(i.ToString() + "年2季度");
                                list.Add(i.ToString() + "年3季度");
                            }
                            else if (EndDate.Month == 12)
                            {
                                list.Add(i.ToString() + "年1季度");
                                list.Add(i.ToString() + "年2季度");
                                list.Add(i.ToString() + "年3季度");
                                list.Add(i.ToString() + "年4季度");
                            }
                        }
                        else
                        {
                            list.Add(i.ToString() + "年1季度");
                            list.Add(i.ToString() + "年2季度");
                            list.Add(i.ToString() + "年3季度");
                            list.Add(i.ToString() + "年4季度");
                        }
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





















        /// <summary>
        /// 功能描述：统计历史最差
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-3-31
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData_AppraiseHistoryWorst(GetData_AppraiseHistoryWorst_Info info)
        {
            string result = null;
            try
            {
                GetData_AppraiseHistoryWorst_Retrun rd = new GetData_AppraiseHistoryWorst_Retrun();

                List<tblEQIW_RL_SectionStat_Midd> HistoryWorstList = new List<tblEQIW_RL_SectionStat_Midd>();


                using (MiddleContext db = new MiddleContext())
                {
                    HistoryWorstList = (from x in db.tblEQIW_RL_SectionStat_Midd
                                        where info.fldSTCode == x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode
                                        select x).ToList();
                }

                var query2 = from x in HistoryWorstList
                             group x by x.fldStage into g
                             select new
                             {
                                 g.Key,
                                 g
                             };

                List<string> namelist = new List<string>();
                namelist.Add("劣Ⅴ类");
                namelist.Add("Ⅴ类");
                namelist.Add("Ⅳ类");
                namelist.Add("Ⅲ类");
                namelist.Add("Ⅱ类");
                namelist.Add("Ⅰ类");



                foreach (var item in namelist)
                {
                    var query3 = (from x in query2
                                  where x.Key == item
                                  select x).ToList();

                    if (query3.Count() > 0)
                    {
                        rd.HistoryWorstData = query3;
                        break;
                    }
                }


                result = rule.JsonStr("ok", "", rd);

            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class GetData_AppraiseHistoryWorst_Info
        {
            /// <summary>
            /// 格式：fldSTCode.fldRCode.fldRSCode
            /// </summary>
            public string fldSTCode { get; set; }
        }


        public class GetData_AppraiseHistoryWorst_Retrun
        {
            public object HistoryWorstData { get; set; }
        }

















        /// <summary>
        /// 功能描述：地表水、水华按照国控、市控、全部取得数据
        /// 创建者  ：吕荣誉
        /// 创建时间：2018-4-12
        /// </summary>
        /// <param name="info">参数列表</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetData_RLAndSH(GetData_RLAndSH_Info info)
        {
            string result = null;
            try
            {
                using (MiddleContext db = new MiddleContext())
                {

                    GetData_RLAndSH_Return rd = new GetData_RLAndSH_Return();

                    List<tblEQIW_RL_SectionStat_Midd> query = new List<tblEQIW_RL_SectionStat_Midd>();

                    List<tblEQIW_RL_SectionStat_Midd> query_tongqi = new List<tblEQIW_RL_SectionStat_Midd>();
                    List<tblEQIW_RL_SectionStat_Midd> query_qianqi = new List<tblEQIW_RL_SectionStat_Midd>();





                    List<string> list_section = new List<string>();


                    List<string> list = new List<string>();


                    DateTime BeginDate = new DateTime();
                    DateTime EndDate = new DateTime();


                    if (info.fldBeginDate == "-1" || info.fldEndDate == "-1")
                    {
                        list.Add("平均");
                    }
                    else
                    {
                        BeginDate = DateTime.Parse(info.fldBeginDate);
                        EndDate = DateTime.Parse(info.fldEndDate);
                        list = ConvertDate(info.fldTimeType, BeginDate, EndDate);

                        if (info.IsTotal == "1" || info.IsTotal == "2")
                        {
                            list.Add("平均");
                        }
                    }


                    using (Model_MIS.EntityContext db_MIS = new Model_MIS.EntityContext())
                    {



                        if (info.fldAttribute == "水华")
                        {
                            list_section = (from x in db_MIS.tblEQIW_R_Section
                                            where info.fldAttribute == x.fldAttribute &&
                                            info.fldYear == x.fldYear &&
                                            info.fldRVTown.Contains(x.fldRVTown) &&
                                            info.fldSLevel.Contains(x.fldSLevel)
                                            select x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode).ToList();



                        }
                        else
                        {
                            list_section = (from x in db_MIS.tblEQIW_R_Section
                                            where info.fldAttribute.Contains(x.fldAttribute) &&
                                            info.fldYear == x.fldYear
                                            select x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode).ToList();



                            if (info.fldTen == "水十条")
                            {
                                var query1 = (from x in db_MIS.tblEQI_Point_Group
                                              where x.fldName == "考核断面105个"
                                              select x.fldPointContent).FirstOrDefault();

                                List<string> list_section2 = query1.Replace("'", "").Split(',').ToList();


                                list_section = (from x in list_section
                                                join y in list_section2
                                                on x equals y
                                                select x).ToList();



                            }
                        }
                    }




                    query = (from x in db.tblEQIW_RL_SectionStat_Midd
                             where list.Contains(x.fldAppDate) &&
                             list_section.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                             x.fldStand == "超标" &&
                             info.fldSCategory.Contains(x.fldSCategory)
                             select x).ToList();

                    rd.dangqi = query;










                    if (info.IsYear == "1")
                    {
                        List<tblEQIW_RL_SectionStat_Midd> query2 = new List<tblEQIW_RL_SectionStat_Midd>();
                        List<tblEQIW_RL_SectionStat_Item_Midd> query_Item2 = new List<tblEQIW_RL_SectionStat_Item_Midd>();

                        DateTime BeginDate_IsYear = BeginDate.AddYears(-1);
                        DateTime EndDate_IsYear = EndDate.AddYears(-1);

                        list = ConvertDate(info.fldTimeType, BeginDate_IsYear, EndDate_IsYear);

                        if (info.IsTotal == "1" || info.IsTotal == "2")
                        {
                            list.Add("平均");
                        }


                        query_tongqi = (from x in db.tblEQIW_RL_SectionStat_Midd
                                        where list.Contains(x.fldAppDate) &&
                                        list_section.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                        x.fldStand == "超标" &&
                                        info.fldSCategory.Contains(x.fldSCategory)
                                        select x).ToList();

                        rd.tongqi = query_tongqi;
                    }








                    if (info.IsPre == "1")
                    {
                        List<tblEQIW_RL_SectionStat_Midd> query3 = new List<tblEQIW_RL_SectionStat_Midd>();
                        List<tblEQIW_RL_SectionStat_Item_Midd> query_Item3 = new List<tblEQIW_RL_SectionStat_Item_Midd>();

                        DateTime BeginDate_IsPre = BeginDate.AddMonths(-1);
                        DateTime EndDate_IsPre = EndDate.AddMonths(-1);

                        list = ConvertDate(info.fldTimeType, BeginDate_IsPre, EndDate_IsPre);

                        if (info.IsTotal == "1" || info.IsTotal == "2")
                        {
                            list.Add("平均");
                        }





                        query_qianqi = (from x in db.tblEQIW_RL_SectionStat_Midd
                                        where list.Contains(x.fldAppDate) &&
                                        list_section.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode) &&
                                        x.fldStand == "超标" &&
                                        info.fldSCategory.Contains(x.fldSCategory)
                                        select x).ToList();

                        rd.qianqi = query_qianqi;

                    }








                    var Q2 = from x in query
                             group x by new
                             {
                                 x.fldRSName,
                                 x.fldAppDate,
                                 x.fldStage
                             } into g
                             select new Data
                             {
                                 fldRSName = g.Key.fldRSName,

                                 fldAppDate = g.Key.fldAppDate,

                                 dangqi_Stage = g.Key.fldStage,

                                 tongqi_Stage = (from x in query_tongqi
                                                 where x.fldSTName == g.Key.fldRSName
                                                 select x.fldStage).FirstOrDefault(),

                                 qianqi_Stage = (from x in query_qianqi
                                                 where x.fldSTName == g.Key.fldRSName
                                                 select x.fldStage).FirstOrDefault(),

                                 dangqi_Items = g.Select(x => x.fldOverItem).FirstOrDefault()
                             };


                    rd.datas = Q2.ToList();


                    result = rule.JsonStr("ok", "", rd);

                }



            }
            catch (Exception e)
            {
                result = rule.JsonStr("error", e.Message, "");
            }

            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        public class GetData_RLAndSH_Info
        {
            public string fldTimeType { get; set; }

            public string fldBeginDate { get; set; }

            public string fldEndDate { get; set; }

            public string IsTotal { get; set; }

            /// <summary>
            /// 水华：“水华”、“大中型水库”、“综合整治湖库”
            /// 国控：“国控考核”、“国控科研趋势断面”
            /// 市控：“市控考核断面”、“市控评价断面”
            /// </summary>
            public string fldAttribute { get; set; }

            /// <summary>
            /// “水十条”
            /// </summary>
            public string fldTen { get; set; }

            /// <summary>
            /// 当fldAttribute == "水华"时，fldRVTown的值可为“回水区”、“非回水区”，多个返回可写“回水区,非回水区”
            /// </summary>
            public string fldRVTown { get; set; }


            /// <summary>
            /// 当fldAttribute == "水华"时，1是国控，2是市控
            /// </summary>
            public List<int?> fldSLevel { get; set; }

            /// <summary>
            /// 年份，作用于断面
            /// </summary>
            public int fldYear { get; set; }


            /// <summary>
            /// "1"返回同期数据
            /// </summary>
            public string IsYear { get; set; }


            /// <summary>
            /// "1"：返回前期数据
            /// </summary>
            public string IsPre { get; set; }


            /// <summary>
            /// “河流”、“湖库”
            /// </summary>
            public string fldSCategory { get; set; }
        }





        public class GetData_RLAndSH_Return
        {
            public List<tblEQIW_RL_SectionStat_Midd> dangqi { get; set; }

            public List<tblEQIW_RL_SectionStat_Midd> tongqi { get; set; }

            public List<tblEQIW_RL_SectionStat_Midd> qianqi { get; set; }

            public List<Data> datas { get; set; }
        }




        public class Data
        {
            public string fldRSName { get; set; }

            public string fldAppDate { get; set; }

            public string dangqi_Stage { get; set; }

            public string tongqi_Stage { get; set; }

            public string qianqi_Stage { get; set; }

            public string dangqi_Items { get; set; }
        }














        /// <summary>
        /// 功能描述：采测分离数据和常规数据比较表
        /// 创建者  ：刘勇军 
        /// 创建时间：2018-4-20
        /// </summary>
        /// <param name="info">参数实体</param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage GetCompare_SeparateAndRoutine(GetCompare_SeparateAndRoutine_Info info)
        {
            string result = null;
            DataTable dt = new DataTable();
            try
            {
                List<tblEQIW_RL_SectionStat_Midd> list_Section = new List<tblEQIW_RL_SectionStat_Midd>();

                List<tblEQIW_RL_SectionStat_Item_Midd> list_Section_Item = new List<tblEQIW_RL_SectionStat_Item_Midd>();


                DateTime BeginDate = DateTime.Parse(info.fldBeginDate);
                DateTime EndDate = DateTime.Parse(info.fldEndDate);

                using (MiddleContext db = new MiddleContext())
                {
                    list_Section = (from x in db.tblEQIW_RL_SectionStat_Midd
                                    select x).ToList();

                    if (info.fldTimeType != null && info.fldTimeType != "")
                    {
                        list_Section = (from x in list_Section
                                        where x.fldTimeType == info.fldTimeType
                                        select x).ToList();
                    }


                    if (info.fldSTCode != "-1")
                    {
                        list_Section = (from x in list_Section
                                        where info.fldSTCode.Contains(x.fldSTCode + "." + x.fldRCode + "." + x.fldRSCode)
                                        select x).ToList();
                    }

                    //根据时间查询
                    list_Section = (from x in list_Section
                                    where x.fldBeginDate >= BeginDate && x.fldEndDate <= EndDate
                                    select x).ToList();


                    if (info.fldItemCode != null && info.fldItemCode != "")
                    {
                        if (info.fldItemCode != "All")
                        {
                            string[] ItemCodeList = info.fldItemCode.Split(',');

                            list_Section_Item = (from x in db.tblEQIW_RL_SectionStat_Item_Midd
                                                 where ItemCodeList.Contains(x.fldItemCode)
                                                 select x).ToList();
                        }
                        else
                        {
                            list_Section_Item = (from x in db.tblEQIW_RL_SectionStat_Item_Midd
                                                 select x).ToList();
                        }
                    }
                }


                var query = (from x in list_Section
                             group x by x.fldAutoID
                        into g
                             select new
                             {
                                 fldAutoID = g.Key,
                                 Section_Data = g,
                                 Item_Date = (from y in list_Section_Item
                                              where y.fldFKID == g.Key
                                              select y).ToList()
                             }).ToList();


                if (query.Count > 0)
                {
                    result = rule.JsonStr("ok", "", query);
                }
                else
                {
                    result = rule.JsonStr("nodata", "没有数据！", "");
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
        public class GetCompare_SeparateAndRoutine_Info
        {
            //时间类型：month、year、sea、day
            public string fldTimeType { get; set; }

            //开始时间
            public string fldBeginDate { get; set; }

            //结束时间
            public string fldEndDate { get; set; }


            public string fldAppDate { get; set; }

            //断面代码
            public string fldSTCode { get; set; }

            //因子
            public string fldItemCode { get; set; }


        }


































































    }
}
