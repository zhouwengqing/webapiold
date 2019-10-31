using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DDYZ.Ensis.Rule.DataRule;

namespace DDYZ.Ensis.Rule.BusinessRule.Query
{
    public class EQIPQuerySql:BaseRule
    {
        Hashtable hasTimeSqlTables = new Hashtable();
        #region ʱ���ѯ����
        /// <summary>
        /// ��������    ��  ƴ��ʱ���ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2010-06-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string QueryTimeSql(string strTime,string type)
        {
            string strTimeSql;
            string strStartTimeTemp;
            string strEndTimeTemp;

            string[] strTimeAll = new string[2];
            if (strTime != "")
            {
                strTimeAll = strTime.Split(';');

                //*�ָʼʱ��ͽ���ʱ��
                strStartTimeTemp = strTimeAll[0];
                strEndTimeTemp = strTimeAll[1];

                //�ָ������� 
                this.hasTimeSqlTables["StartYear"] = Convert.ToDateTime(strStartTimeTemp).Year;
                this.hasTimeSqlTables["StartMonth"] = Convert.ToDateTime(strStartTimeTemp).Month;
                this.hasTimeSqlTables["StartDay"] = Convert.ToDateTime(strStartTimeTemp).Day;

                this.hasTimeSqlTables["EndYear"] = Convert.ToDateTime(strEndTimeTemp).Year;
                this.hasTimeSqlTables["EndMonth"] = Convert.ToDateTime(strEndTimeTemp).Month;
                this.hasTimeSqlTables["EndDay"] = Convert.ToDateTime(strEndTimeTemp).Day;

                strTimeSql = this.GetHourSql(this.hasTimeSqlTables,type);
            }
            else
            {
                strTimeSql = "";
            }
            return strTimeSql;
        }

        /// <summary>
        /// ��������    ��  ƴ��Сʱ��ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2010-06-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        private string GetHourSql(Hashtable hasTimeSqlTable,string type)
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
            if (type == "��������")
            {
                //ͬ�� 
                if (strStartYear == strEndYear)
                {
                    //ͬ��
                    if (strStartMonth == strEndMonth)
                    {
                        strTimeSql.Append("fldYear=" + strStartYear + " and fldMonth=" + strStartMonth);
                        strTimeSql.Append(" and fldDay>=" + strStartDay + " and fldDay<=" + strEndDay);
                        return strTimeSql.ToString();
                    }//��ͬ��
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
            else
            { 
                //ͬ�� 
                if (strStartYear == strEndYear)
                {
                    //ͬ��
                    if (strStartMonth == strEndMonth)
                    {
                        strTimeSql.Append("fldMonitorYear=" + strStartYear + " and fldMonitorMonth=" + strStartMonth);
                        strTimeSql.Append(" and fldMonitorDay>=" + strStartDay + " and fldMonitorDay<=" + strEndDay);
                        return strTimeSql.ToString();
                    }//��ͬ��
                    else
                    {

                        strTimeSql.Append("((fldMonitorYear=" + strStartYear + " and fldMonitorMonth=" + strStartMonth);
                        strTimeSql.Append(" and fldMonitorDay>=" + strStartDay + " and fldMonitorDay<=31) or ");
                        strTimeSql.Append(" (fldMonitorYear=" + strStartYear + " and fldMonitorMonth>" + strStartMonth);
                        strTimeSql.Append(" and fldMonitorMonth<" + strEndMonth + ") or ");
                        strTimeSql.Append(" (fldMonitorYear=" + strStartYear + " and fldMonitorMonth=" + strEndMonth);
                        strTimeSql.Append(" and fldMonitorDay>=1 and fldMonitorDay<=" + strEndDay + "))");
                        return strTimeSql.ToString();
                    }
                }
                else
                {
                    strTimeSql.Append("((fldMonitorYear=" + strStartYear + " and fldMonitorMonth=" + strStartMonth + " and fldMonitorDay>=" + strStartDay + " and fldMonitorDay<=31)");
                    strTimeSql.Append(" or(fldMonitorYear=" + strStartYear + " and fldMonitorMonth>" + strStartMonth + " and  fldMonitorMonth<=12)");
                    strTimeSql.Append(" or( fldMonitorYear>" + strStartYear + " and fldMonitorYear<" + strEndYear + ")");
                    strTimeSql.Append(" or(fldMonitorYear=" + strEndYear + " and fldMonitorMonth>=1 and  fldMonitorMonth<" + strEndMonth + ")");
                    strTimeSql.Append("  or(fldMonitorYear=" + strEndYear + " and  fldMonitorMonth=" + strEndMonth + " and fldMonitorDay>=1 and fldMonitorDay<=" + strEndDay + " ))");
                    return strTimeSql.ToString();
                }
            }

        }

         
        #endregion


    }
}
