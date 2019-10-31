using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DDYZ.Ensis.Rule.DataRule; 

namespace DDYZ.Ensis.Rule.BusinessRule.Query
{
    /// <summary>
    /// 功能描述    ：  拼接查询语句条件
    /// 创建者      ：  马立军
    /// 创建日期    ：  2009-05-18
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class EQIWRQuerySql : BaseRule
    {
        Hashtable hasTimeSqlTables = new Hashtable();

        private void PagehasSqlTable()
        {
            this.hasTimeSqlTables.Add("StartYear", "");
            this.hasTimeSqlTables.Add("EndYear", "");
            this.hasTimeSqlTables.Add("StartMonth", "");
            this.hasTimeSqlTables.Add("EndMonth", "");
            this.hasTimeSqlTables.Add("StartDay", "");
            this.hasTimeSqlTables.Add("EndDay", "");
            this.hasTimeSqlTables.Add("StartSea", "");
            this.hasTimeSqlTables.Add("EndSea", "");
            this.hasTimeSqlTables.Add("StartHalfYear", "");
            this.hasTimeSqlTables.Add("EndHalfYear", "");
        }


        /// <summary>
        /// 功能描述    ：  得到查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="hasTable">查询条件</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strCityCode">城市代码</param>
        public string GetStrSql(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strSourceSql;
            string strCityPoint;
            string strTimeSql;
            string strItemSql;

            //this.PagehasSqlTable();

            strSourceSql = this.QuerySourceSql(hasTable);
            strCityPoint = this.QueryConditions(hasTable);
            strTimeSql = this.QueryTimeSql(hasTable);
            strItemSql = this.QueryItemSql(hasTable);

            string strSql = "";

            if (strSourceSql != "")
                strSql += strSourceSql + " and ";
            if (strCityPoint != "")
                strSql += strCityPoint + " and ";
            if (strTimeSql != "")
                strSql += strTimeSql + " and ";
            if (strItemSql != "")
                strSql += strItemSql + " and ";
            if (strUserName.ToLower() != "yzadmin")
                strSql += "fldstcode like '%" + strCityCode + "%' and ";

            if (strSql.Length > 0)
                strSql = strSql.Substring(0, strSql.Length - 4);

            return strSql;
        }

        

        /// <summary>
        /// 功能描述    ：  得到查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="hasTable">查询条件</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strCityCode">城市代码</param>
        public string GetStrSqlL(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strSourceSql;
            string strCityPoint;
            string strTimeSql;
            string strItemSql;

            //this.PagehasSqlTable();

            strSourceSql = this.QuerySourceSql(hasTable);
            strCityPoint = this.QueryConditionsL(hasTable);
            strTimeSql = this.QueryTimeSql(hasTable);
            strItemSql = this.QueryItemSql(hasTable);

            string strSql = "";

            if (strSourceSql != "")
                strSql += strSourceSql + " and ";
            if (strCityPoint != "")
                strSql += strCityPoint + " and ";
            if (strTimeSql != "")
                strSql += strTimeSql + " and ";
            if (strItemSql != "")
                strSql += strItemSql + " and ";
            if (strUserName.ToLower() != "yzadmin")
                strSql += "fldstcode like '%" + strCityCode + "%' and ";

            if (strSql.Length > 0)
                strSql = strSql.Substring(0, strSql.Length - 4);

            return strSql;
        }



        #region 城市测点项目查询条件
        /// <summary>
        /// 功能描述    ：  拼接数据来源查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-12-02
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="hasTable"></param>
        /// <returns></returns>
        private string QuerySourceSql(Hashtable hasTable)
        {
            string sSourceSql = "";

            if (hasTable["Source"] != null)
            {
                //RuletblDictionary ruleDict = new RuletblDictionary();
                //if (hasTable["Source"].ToString() != "1")
                    //sSourceSql = "fldSource='" + ruleDict.ByParentIDAndValue("数据来源", "0") + "'";
                sSourceSql = "fldSource='" + hasTable["Source"].ToString() + "'";
            }

            return sSourceSql;
        }
        /// <summary>
        /// 功能描述    ：  拼接城市测点查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-18
        /// 修改者      ：  黄成
        /// 修改日期    ：  2011-08-10
        /// 修改原因    ：  修改可以使用湖库
        /// </summary>

        private string QueryConditionsL(Hashtable hasTable)
        {
            string strPointSql = hasTable["Point"].ToString();

            if (strPointSql != "")
                strPointSql = "fldSTCode+'.'+fldLCode+'.'+fldLSCode in (" + strPointSql + ")";
            return strPointSql;
        }

        /// <summary>
        /// 功能描述    ：  拼接城市测点查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-18
        /// 修改者      ：  马立军
        /// 修改日期    ：  2009-09-01
        /// 修改原因    ：  原来的查询出来的数据不对，应采用fldSTCode+'.'+fldPCode的形式组合查询条件
        /// </summary>

        private string QueryConditions(Hashtable hasTable)
        {            
            string strPointSql = hasTable["Point"].ToString();

            if (strPointSql != "")
                strPointSql = "fldSTCode+'.'+fldRCode+'.'+fldRSCode in (" + strPointSql + ")";
            return strPointSql;
        }

        /// <summary>
        /// 功能描述    ：  拼接项目查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// 
        private string QueryItemSql(Hashtable hasTable)
        {
            string strItemSql;
            if (hasTable["Item"].ToString() != "")
            {
                strItemSql = " fldItemCode in(" + hasTable["Item"].ToString() + ")";
                return strItemSql;
            }
            return "";
        }
        #endregion

        #region 时间查询条件
        /// <summary>
        /// 功能描述    ：  拼接时间查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string QueryTimeSql(Hashtable hasTable)
        {
            string strTimeSql;
            string strStartTimeTemp;
            string strEndTimeTemp;

            string[] strTimeAll = new string[2];

            if (hasTable["TimeType"].ToString() == "1")
            {
                strTimeAll = hasTable["Hours"].ToString().Split(';');
                strTimeSql = "fldHour>=" + strTimeAll[0].ToString() + " and fldHour<=" + strTimeAll[1].ToString();
                return strTimeSql;
            }
            if (hasTable["Time"].ToString() != "")
            {
                strTimeAll = hasTable["Time"].ToString().Split(';');

                //*分割开始时间和结束时间
                strStartTimeTemp = strTimeAll[0];
                strEndTimeTemp = strTimeAll[1];

                //分割年月日 
                this.hasTimeSqlTables["StartYear"] = Convert.ToDateTime(strStartTimeTemp).Year;
                this.hasTimeSqlTables["StartMonth"] = Convert.ToDateTime(strStartTimeTemp).Month;
                this.hasTimeSqlTables["StartDay"] = Convert.ToDateTime(strStartTimeTemp).Day;

                this.hasTimeSqlTables["EndYear"] = Convert.ToDateTime(strEndTimeTemp).Year;
                this.hasTimeSqlTables["EndMonth"] = Convert.ToDateTime(strEndTimeTemp).Month;
                this.hasTimeSqlTables["EndDay"] = Convert.ToDateTime(strEndTimeTemp).Day;

                strTimeSql = this.GetHourSql(this.hasTimeSqlTables);
            }
            else
            {
                strTimeSql = "";
            }
            return strTimeSql;
        }

        /// <summary>
        /// 功能描述    ：  拼接小时查询条件(原始数据表)
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-18
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        private string GetHourSql(Hashtable hasTimeSqlTable)
        {
            StringBuilder strTimeSql = new StringBuilder();
            string strStartYear;
            string strEndYear;
            string strStartMonth;
            string strEndMonth;
            string strStartDay;
            string strEndDay;

            strStartYear = hasTimeSqlTable["StartYear"].ToString();
            strEndYear = hasTimeSqlTable["EndYear"].ToString();
            strStartMonth = hasTimeSqlTable["StartMonth"].ToString();
            strEndMonth = hasTimeSqlTable["EndMonth"].ToString();
            strStartDay = hasTimeSqlTable["StartDay"].ToString();
            strEndDay = hasTimeSqlTable["EndDay"].ToString();

            //同年 
            if (strStartYear == strEndYear)
            {
                //同月
                if (strStartMonth == strEndMonth)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldDay>=" + strStartDay + " and fldDay<=" + strEndDay);
                    return strTimeSql.ToString();
                }//不同月
                else
                {

                    strTimeSql.Append("((fldYear=" + strStartYear + " and fldMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldDay>=" + strStartDay + " and fldDay<=31) or ");
                    strTimeSql.Append(" (fldYear=" + strStartYear + " and fldMonth>" + strStartMonth);
                    strTimeSql.Append(" and fldMonth<" + strEndMonth + ") or ");
                    strTimeSql.Append(" (fldYear=" + strStartYear + " and fldMonth=" + strEndMonth);
                    strTimeSql.Append(" and fldDay>=1 and fldDay<=" + strEndDay + "))");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldyear=" + strStartYear + " and fldmonth=" + strStartMonth + " and fldday>=" + strStartDay + " and fldday<=31)");
                strTimeSql.Append(" or(fldyear=" + strStartYear + " and fldmonth>" + strStartMonth + " and  fldmonth<=12)");
                strTimeSql.Append(" or( fldyear>" + strStartYear + " and fldyear<" + strEndYear + ")");
                strTimeSql.Append(" or(fldyear=" + strEndYear + " and fldmonth>=1 and  fldmonth<" + strEndMonth + ")");
                strTimeSql.Append("  or(fldyear=" + strEndYear + " and  fldmonth=" + strEndMonth + " and fldday>=1 and fldday<=" + strEndDay + " ))");
                return strTimeSql.ToString();
            }

        }



        /// <summary>
        /// 功能描述    ：  拼接日查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        private string GetDaySql(Hashtable hasTimeSqlTable)
        {
            StringBuilder strTimeSql = new StringBuilder();
            string strStartYear;
            string strEndYear;
            string strStartMonth;
            string strEndMonth;
            string strStartDay;
            string strEndDay;

            strStartYear = hasTimeSqlTable["StartYear"].ToString();
            strEndYear = hasTimeSqlTable["EndYear"].ToString();
            strStartMonth = hasTimeSqlTable["StartMonth"].ToString();
            strEndMonth = hasTimeSqlTable["EndMonth"].ToString();
            strStartDay = hasTimeSqlTable["StartDay"].ToString();
            strEndDay = hasTimeSqlTable["EndDay"].ToString();

            //同年 
            if (strStartYear == strEndYear)
            {
                //同月
                if (strStartMonth == strEndMonth)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldDay>=" + strStartDay + " and fldDay<=" + strEndDay);
                    return strTimeSql.ToString();
                }//不同月
                else
                {

                    strTimeSql.Append("((fldYear=" + strStartYear + " and fldMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldDay>=" + strStartDay + " and fldDay<=31) or ");
                    strTimeSql.Append(" (fldYear=" + strStartYear + " and fldMonth>" + strStartMonth);
                    strTimeSql.Append(" and fldMonth<" + strEndMonth + ") or ");
                    strTimeSql.Append(" (fldYear=" + strStartYear + " and fldMonth=" + strEndMonth);
                    strTimeSql.Append(" and fldDay>=1 and fldDay<=" + strEndDay + "))");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldyear=" + strStartYear + " and fldmonth=" + strStartMonth + " and fldday>=" + strStartDay + " and fldday<=31)");
                strTimeSql.Append(" or(fldyear=" + strStartYear + " and fldmonth>" + strStartMonth + " and  fldmonth<=12)");
                strTimeSql.Append(" or( fldyear>" + strStartYear + " and fldyear<" + strEndYear + ")");
                strTimeSql.Append(" or(fldyear=" + strEndYear + " and fldmonth>=1 and  fldmonth<" + strEndMonth + ")");
                strTimeSql.Append("  or(fldyear=" + strEndYear + " and  fldmonth=" + strEndMonth + " and fldday>=1 and fldday<=" + strEndDay + " ))");
                return strTimeSql.ToString();
            }

        }


        /// <summary>
        /// 功能描述    ：  拼接月查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        private string GetMonthSql(Hashtable hasTimeSqlTable)
        {
            StringBuilder strTimeSql = new StringBuilder();
            string strStartYear;
            string strEndYear;
            string strStartMonth;
            string strEndMonth;

            strStartYear = hasTimeSqlTable["StartYear"].ToString();
            strEndYear = hasTimeSqlTable["EndYear"].ToString();
            strStartMonth = hasTimeSqlTable["StartMonth"].ToString();
            strEndMonth = hasTimeSqlTable["EndMonth"].ToString();

            //同年 
            if (strStartYear == strEndYear)
            {
                //同月
                if (strStartMonth == strEndMonth)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldMonth=" + strStartMonth);
                    return strTimeSql.ToString();
                }//不同月
                else
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldMonth>=" + strStartMonth);
                    strTimeSql.Append(" and fldMonth<=" + strEndMonth);
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldYear=" + strStartYear + " and fldMonth>=" + strStartMonth + " and fldMonth<=12)");
                strTimeSql.Append(" or (fldYear>" + strStartYear + " and fldYear<" + strEndYear + ")");
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldMonth>=1 and fldMonth<=" + strEndMonth + "))");
                return strTimeSql.ToString();
            }
        }

        /// <summary>
        /// 功能描述    ：  拼接季查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        private string GetSeaSql(Hashtable hasTimeSqlTable)
        {
            StringBuilder strTimeSql = new StringBuilder();
            string strStartYear;
            string strEndYear;
            string strStartSea;
            string strEndSea;

            strStartYear = hasTimeSqlTable["StartYear"].ToString();
            strEndYear = hasTimeSqlTable["EndYear"].ToString();
            strStartSea = hasTimeSqlTable["StartSea"].ToString();
            strEndSea = hasTimeSqlTable["EndSea"].ToString();

            //同年 
            if (strStartYear == strEndYear)
            {
                //同月
                if (strStartSea == strEndSea)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea=" + strStartSea);
                    return strTimeSql.ToString();
                }//不同月
                else
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea>=" + strStartSea);
                    strTimeSql.Append(" and fldSea<=" + strEndSea);
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldYear=" + strStartYear + " and fldSea>=" + strStartSea + " and fldSea<=4)");
                strTimeSql.Append(" or (fldYear>" + strStartYear + " and fldYear<" + strEndYear + ")");
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldSea>=1 and fldSea<=" + strEndSea + "))");
                return strTimeSql.ToString();
            }
            return strTimeSql.ToString();
        }

        /// <summary>
        /// 功能描述    ：  拼接半年查询条件
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        private string GetHalfYearSql(Hashtable hasTimeSqlTable)
        {
            StringBuilder strTimeSql = new StringBuilder();
            string strStartYear;
            string strEndYear;
            string strStartHalf;
            string strEndHalf;

            strStartYear = hasTimeSqlTable["StartYear"].ToString();
            strEndYear = hasTimeSqlTable["EndYear"].ToString();
            strStartHalf = hasTimeSqlTable["StartHalfYear"].ToString();
            strEndHalf = hasTimeSqlTable["EndHalfYear"].ToString();

            //同年 
            if (strStartYear == strEndYear)
            {
                //同月
                if (strStartHalf == strEndHalf)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldHalfYear=dbo.ufn_getDictionaryNameByValueAndParentID('半年标志','" +
                            strStartHalf + "')");
                    return strTimeSql.ToString();
                }//不同月
                else
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldHalfYear>=dbo.ufn_getDictionaryNameByValueAndParentID('半年标志','" +
                            strStartHalf + "')");
                    strTimeSql.Append(" and fldHalfYear<=dbo.ufn_getDictionaryNameByValueAndParentID('半年标志','" +
                            strEndHalf + "')");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldYear=" + strStartYear + " and fldHalfYear>=dbo.ufn_getDictionaryNameByValueAndParentID('半年标志','" +
                    strStartHalf + "') and fldHalfYear<=dbo.ufn_getDictionaryNameByValueAndParentID('半年标志','2'))");
                strTimeSql.Append(" or (fldYear>" + strStartYear + " and fldYear<" + strEndYear + ")");
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldHalfYear>=dbo.ufn_getDictionaryNameByValueAndParentID('半年标志','1') " +
                    "and fldHalfYear<=dbo.ufn_getDictionaryNameByValueAndParentID('半年标志','" + strEndHalf + "')))");
                return strTimeSql.ToString();
            }
            return strTimeSql.ToString();
        }
        #endregion


        /// <summary>
        /// 功能描述    ：  拼接排序字符串
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string GetTaxisSql(Hashtable hasTimeSqlTable)
        {
            //string strTaxis = "";
            //if (hasTimeSqlTable["DataType"].ToString() == "0")
            //{
            //    strTaxis = "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear asc,fldMonth asc,fldDay asc,fldHour asc,fldMinute asc,fldItemCode asc";
            //}
            //else
            //{
            //    if (hasTimeSqlTable["DataType"].ToString() == "1" || hasTimeSqlTable["DataType"].ToString() == "3")
            //    {
            //        switch (hasTimeSqlTable["TimeType"].ToString())
            //        {
            //            case "Day_Data":
            //                strTaxis = "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear asc,fldMonth asc,fldDay asc";
            //                break;
            //            case "Month_Data":
            //                strTaxis = "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear asc,fldMonth asc";
            //                break;
            //            case "Season_Data":
            //                strTaxis = "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear asc,fldSea asc";
            //                break;
            //            case "HalfYear_Data":
            //                strTaxis = "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear asc,fldHalfYear asc";
            //                break;
            //            case "Year_Data":
            //                strTaxis = "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear asc";
            //                break;
            //            case "CYear_Data":
            //                strTaxis = "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear asc,fldRSC asc";
            //                break;
            //        }
            //        if (hasTimeSqlTable["DataType"].ToString() == "1")
            //        {
            //            strTaxis = strTaxis + ",fldItemCode asc";
            //        }
            //    }
            //}
            //return strTaxis;

            if (hasTimeSqlTable["Source"] != null && hasTimeSqlTable["Source"].ToString() == "1")
                return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldSAMPH asc,fldSAMPR asc,fldRSC asc,fldYear desc,fldMonth desc,fldDay desc";
            else
                return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear desc,fldMonth desc";
        }


        /// <summary>
        /// 功能描述    ：  拼接排序字符串
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string GetTaxisSql(string Quarter)
        { 
                //日，月，季，半年，年均值
                if (Quarter == "day")
                    return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear desc,fldMonth desc,fldDay desc";
                else if (Quarter == "month")
                    return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear desc,fldMonth desc";
                else if (Quarter == "sea")
                    return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear desc,fldSea desc";
                else if (Quarter == "halfyear")
                    return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear desc,fldhalfyear desc";
                else if (Quarter == "year")
                    return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear desc";
                else
                    return "fldSTCode asc,fldRCode asc,fldRSCode asc,fldYear";
             
        }

        /// <summary>
        /// 功能描述    ：  拼接排序字符串
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string GetTaxisSqlR(string Quarter, int isb)
        {
            if (isb > 0)
            {
                //日，月，季，半年，年均值
                if (Quarter == "day")
                    return "fldRCode asc,fldRSCode asc,fldYear desc,fldMonth desc,fldDay desc";
                else if (Quarter == "month")
                    return "fldRCode asc,fldRSCode asc,fldYear desc,fldMonth desc";
                else if (Quarter == "sea")
                    return "fldRCode asc,fldRSCode asc,fldYear desc,fldSea desc";
                else if (Quarter == "halfyear")
                    return "fldRCode asc,fldRSCode asc,fldYear desc,fldhalfyear desc";
                else if (Quarter == "year")
                    return "fldRCode asc,fldRSCode asc,fldYear desc";
                else if (Quarter == "year")
                    return "fldRCode asc,fldRSCode asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc,fldMinute,fldSAPH desc,fldSAPR desc";
                else if (Quarter == "renyi" || Quarter == "RenYiMon")
                    return "fldRCode asc,fldRSCode asc";
                else
                    return "fldRCode asc,fldRSCode asc,fldYear";
            }
            else
            {
                return "fldRCode asc,fldRSCode desc";
            }
        }

        /// <summary>
        /// 功能描述    ：  拼接排序字符串
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string GetTaxisSqlL(string Quarter,int isb)
        {

            //日，月，季，半年，年均值
            if (isb >= 1)
            {
                if (Quarter == "day")
                    return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldYear desc,fldMonth desc,fldDay desc";
                else if (Quarter == "month")
                    return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldYear desc,fldMonth desc";
                else if (Quarter == "sea")
                    return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldYear desc,fldSea desc";
                else if (Quarter == "halfyear")
                    return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldYear desc,fldhalfyear desc";
                else if (Quarter == "year")
                    return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldYear desc";
                else if (Quarter == "renyi" || Quarter == "RenYiMon")
                    return "fldSTCode asc,fldLCode asc,fldLSCode asc";
                else
                    return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldYear desc";
            }
            else
            {
                return "fldSTCode asc,fldLCode asc,fldLSCode desc";
            }

        }
    }
}