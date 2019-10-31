using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DDYZ.Ensis.Rule.DataRule;

namespace DDYZ.Ensis.Rule.BusinessRule.Query
{
    /// <summary>
    /// 功能描述    ：  拼接查询语句条件
    /// 创建者      ：  朱春华
    /// 创建日期    ：  2009-07-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
     public class eqinQuerySql : BaseRule
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
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="hasTable">查询条件</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strCityCode">城市代码</param>
        public string GetStrSqlD(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strCityPoint;
            string strTimeSql;
             
            this.PagehasSqlTable();

            strCityPoint = this.QueryConditionsD(hasTable);
            strTimeSql = this.QueryTimeSql(hasTable); 

            string strSql = "";

            if (strCityPoint != "")
                strSql += strCityPoint + " and ";
            if (strTimeSql != "")
                strSql += strTimeSql + " and "; 
            if (strUserName.ToLower() != "yzadmin")
                strSql += "fldstcode like '%" + strCityCode + "%' and ";

            if (strSql.Length > 0)
                strSql = strSql.Substring(0, strSql.Length - 4);

            return strSql;
        }

        /// <summary>
        /// 功能描述    ：  得到查询条件
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="hasTable">查询条件</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strCityCode">城市代码</param>
        public string GetStrSql(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strCityPoint;
            string strTimeSql;
            string strDNSql;

            this.PagehasSqlTable();

            strCityPoint = this.QueryConditions(hasTable);
            strTimeSql = this.QueryTimeSql(hasTable);
            strDNSql = this.QueryDNSql(hasTable);

            string strSql = "";

            if (strCityPoint != "")
                strSql += strCityPoint + " and ";
            if (strTimeSql != "")
                strSql += strTimeSql + " and ";
            if (strDNSql != "")
                strSql += strDNSql + " and ";
            if (strUserName.ToLower() != "yzadmin")
                strSql += "fldstcode like '%" + strCityCode + "%' and ";

            if (strSql.Length > 0)
                strSql = strSql.Substring(0, strSql.Length - 4);

            return strSql;
        }


        /// <summary>
        /// 功能描述    ：  得到查询条件
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-02
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="hasTable">查询条件</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strCityCode">城市代码</param>
        public string GetStrSqlM(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strCityPoint;
            string strTimeSql; 

            this.PagehasSqlTable();

            strCityPoint = this.QueryConditionsM(hasTable);
            strTimeSql = this.QueryTimeSql(hasTable); 

            string strSql = "";

            if (strCityPoint != "")
                strSql += strCityPoint + " and ";
            if (strTimeSql != "")
                strSql += strTimeSql + " and "; 
            if (strUserName.ToLower() != "yzadmin")
                strSql += "fldstcode like '%" + strCityCode + "%' and ";

            if (strSql.Length > 0)
                strSql = strSql.Substring(0, strSql.Length - 4);

            return strSql;
        }

        /// <summary>
        /// 功能描述    ：  拼接城市测点查询条件
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-02
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>

        private string QueryConditionsM(Hashtable hasTable)
        {
            try
            {
                string strPointSql = hasTable["Point"].ToString();

                if (strPointSql != "")
                    strPointSql = "fldSTCode+'.'+fldPCode in (" + strPointSql + ")";
                return strPointSql;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        /// 功能描述    ：  拼接城市测点查询条件
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>

        private string QueryConditionsD(Hashtable hasTable)
        {
            try
            {
                string strPointSql = hasTable["Point"].ToString();

                if (strPointSql != "")
                    strPointSql = "fldSTCode+'.'+fldXuCode+'.'+fldQuCode in (" + strPointSql + ")";
                return strPointSql;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        #region 城市测点项目查询条件
        /// <summary>
        /// 功能描述    ：  拼接城市测点查询条件
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>

         private string QueryConditions(Hashtable hasTable)
         {
             try
             {
                 string strPointSql = hasTable["Point"].ToString();

                 if (strPointSql != "")
                     strPointSql = "fldSTCode+'.'+fldGDCode in (" + strPointSql + ")";
                 return strPointSql;
             }
             catch (Exception e)
             {
                 return "";
             }
         }

        /// <summary>
        /// 功能描述    ：  拼接昼夜查询条件
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// 
        private string QueryDNSql(Hashtable hasTable)
        {
            string strItemSql;
            if (hasTable["DN"].ToString() != "")
            {
                strItemSql = " fldDN in(" + hasTable["DN"].ToString() + ")";
                return strItemSql;
            }
            return "";
        }

        #endregion

        #region 时间查询条件
        /// <summary>
        /// 功能描述    ：  拼接时间查询条件
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        private string QueryTimeSql(Hashtable hasTable)
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
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
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
        /// 功能描述    ：  拼接季查询条件
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
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
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea='" + strStartSea + "'");
                    return strTimeSql.ToString();
                }//不同月
                else
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea>='" + strStartSea + "'");
                    strTimeSql.Append(" and fldSea<='" + strEndSea + "'");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldYear=" + strStartYear + " and fldSea>='" + strStartSea + "' and fldSea<='4')");
                strTimeSql.Append(" or (fldYear>" + strStartYear + " and fldYear<" + strEndYear + " and fldSea>='1' and fldSea<='4')");
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldSea>='1' and fldSea<='" + strEndSea + "'))");
                return strTimeSql.ToString();
            }
            return strTimeSql.ToString();
        }

        /// <summary>
        /// 功能描述    ：  拼接半年查询条件
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
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
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea=dbo.ufn_getDictionaryNameByValueAndParentID('季节','" +
                            strStartHalf + "')");
                    return strTimeSql.ToString();
                }//不同月
                else
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('季节','" +
                            strStartHalf + "')");
                    strTimeSql.Append(" and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('季节','" +
                            strEndHalf + "')");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldYear=" + strStartYear + " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('季节','" +
                    strStartHalf + "') and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('季节','6'))");
                strTimeSql.Append(" or (fldYear>" + strStartYear + " and fldYear<" + strEndYear+ " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('季节','5') and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('季节','6'))");
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('季节','5') " +
                    "and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('季节','" + strEndHalf + "')))");
                return strTimeSql.ToString();
            }
            return strTimeSql.ToString();
        }
        #endregion

        /// <summary>
        /// 功能描述    ：  拼接排序字符串
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-02
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string GetTaxisSqlM(Hashtable hasTimeSqlTable)
        {
            string strTaxis = "";
            strTaxis = "fldAutoID desc,fldSTCode asc,fldPCode asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc";
            return strTaxis;
        }

        /// <summary>
        /// 功能描述    ：  拼接排序字符串
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string GetTaxisSql(Hashtable hasTimeSqlTable)
        {
            string strTaxis = "";
            strTaxis = "fldAutoID desc,fldSTCode asc,fldGDCODE asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc ,fldNSC asc";
            return strTaxis;
        }

        /// <summary>
        /// 功能描述    ：  拼接排序字符串
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-12-04
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        public string GetTaxisSqlD(Hashtable hasTimeSqlTable)
        {
            string strTaxis = "";
            strTaxis = "fldAutoID desc,fldSTCode asc,fldPName asc,fldYear desc,fldMonth desc,fldDay desc";
            return strTaxis;
        }
    }
}
