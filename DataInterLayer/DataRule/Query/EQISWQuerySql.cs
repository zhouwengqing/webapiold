using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DDYZ.Ensis.Rule.DataRule;

namespace DDYZ.Ensis.Rule.BusinessRule.Query
{
    /// <summary>
    /// ��������    ��  ƴ�Ӳ�ѯ�������
    /// ������      ��  ������
    /// ��������    ��  2009-05-18
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class EQISWQuerySql : BaseRule
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
        /// ��������    ��  ƴ�������ַ���
        /// ������      ��  ������
        /// ��������    ��  2009-05-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string GetTaxisSqlS_W(string Quarter, int isb)
        {
            if (isb > 0)
            {
                //�գ��£��������꣬���ֵ
                if (Quarter == "day")
                    return "fldPCode asc,fldYear desc,fldMonth desc,fldDay desc";
                else if (Quarter == "month")
                    return "fldPCode asc,fldYear desc,fldMonth desc";
                else if (Quarter == "sea")
                    return "fldPCode asc,fldYear desc,fldSea desc";
                else if (Quarter == "halfyear")
                    return "fldPCode asc,fldYear desc,fldhalfyear desc";
                else if (Quarter == "year")
                    return "fldPCode asc,fldYear desc";
                else if (Quarter == "year")
                    return "fldPCode asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc,fldMinute,fldSAPH desc,fldSAPR desc";
                else if (Quarter == "renyi")
                    return "fldPCode asc";
                else
                    return "fldPCode asc,fldYear";
            }
            else
            {
                return "fldPCode asc";
            }
        }


        /// <summary>
        /// ��������    ��  �õ���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="hasTable">��ѯ����</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strCityCode">���д���</param>
        public string GetStrSql(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strSourceSql;
            string strCityPoint;
            string strTimeSql;
            string strItemSql;

            this.PagehasSqlTable();

            //strSourceSql = this.QuerySourceSql(hasTable);
            strCityPoint = this.QueryConditions(hasTable);
            strTimeSql = this.QueryTimeSql(hasTable);
            strItemSql = this.QueryItemSql(hasTable);

            string strSql = "";

            //if (strSourceSql != "")
            //    strSql += strSourceSql + " and ";
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
        /// ��������    ��  �õ���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="hasTable">��ѯ����</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strCityCode">���д���</param>
        public string GetStrSqlL(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strSourceSql;
            string strCityPoint;
            string strTimeSql;
            string strItemSql;

            this.PagehasSqlTable();

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

        /// <summary>
        /// ��������    ��  �õ���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="hasTable">��ѯ����</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strCityCode">���д���</param>
        public string GetStrSqlG(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strSourceSql;
            string strCityPoint;
            string strTimeSql;
            string strItemSql;

            this.PagehasSqlTable();

            strSourceSql = this.QuerySourceSql(hasTable);
            strCityPoint = this.QueryConditionsG(hasTable);
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

        #region ���в����Ŀ��ѯ����
        /// <summary>
        /// ��������    ��  ƴ��������Դ��ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-12-02
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="hasTable"></param>
        /// <returns></returns>
        private string QuerySourceSql(Hashtable hasTable)
        {
            string sSourceSql = "";

            if (hasTable["Source"] != null)
            {
                RuletblDictionary ruleDict = new RuletblDictionary();
                if (hasTable["Source"].ToString() != "1")
                    sSourceSql = "fldSource='" + ruleDict.ByParentIDAndValue("������Դ", "0") + "'";
            }

            return sSourceSql;
        }
        /// <summary>
        /// ��������    ��  ƴ�ӳ��в���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��  ������
        /// �޸�����    ��  2009-09-01
        /// �޸�ԭ��    ��  ԭ���Ĳ�ѯ���������ݲ��ԣ�Ӧ����fldSTCode+'.'+fldPCode����ʽ��ϲ�ѯ����
        /// </summary> 
        private string QueryConditionsL(Hashtable hasTable)
        {
            string strPointSql = hasTable["Point"].ToString();

            if (strPointSql != "")
                strPointSql = "fldSTCode+'.'+fldLCode+'.'+fldLSCode in (" + strPointSql + ")";
            return strPointSql;
        }

        /// <summary>
        /// ��������    ��  ƴ�ӳ��в���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��  ������
        /// �޸�����    ��  2009-09-01
        /// �޸�ԭ��    ��  ԭ���Ĳ�ѯ���������ݲ��ԣ�Ӧ����fldSTCode+'.'+fldPCode����ʽ��ϲ�ѯ����
        /// </summary> 
        private string QueryConditionsG(Hashtable hasTable)
        {
            string strPointSql = hasTable["Point"].ToString();

            if (strPointSql != "")
                strPointSql = "fldSTCode+'.'+fldPCode in (" + strPointSql + ")";
            return strPointSql;
        }

        /// <summary>
        /// ��������    ��  ƴ�ӳ��в���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��  ������
        /// �޸�����    ��  2009-09-01
        /// �޸�ԭ��    ��  ԭ���Ĳ�ѯ���������ݲ��ԣ�Ӧ����fldSTCode+'.'+fldPCode����ʽ��ϲ�ѯ����
        /// </summary>

        private string QueryConditions(Hashtable hasTable)
        {            
            string strPointSql = hasTable["Point"].ToString();

            if (strPointSql != "")
                strPointSql = "fldSTCode+'.'+fldPCode  in (" + strPointSql + ")";
            return strPointSql;
        }

        /// <summary>
        /// ��������    ��  ƴ����Ŀ��ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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

        #region ʱ���ѯ����
        /// <summary>
        /// ��������    ��  ƴ��ʱ���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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

                strTimeSql = this.GetHourSql(this.hasTimeSqlTables);
            }
            else
            {
                strTimeSql = "";
            }
            return strTimeSql;
        }

        /// <summary>
        /// ��������    ��  ƴ��Сʱ��ѯ����(ԭʼ���ݱ�)
        /// ������      ��  ������
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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



        /// <summary>
        /// ��������    ��  ƴ���ղ�ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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


        /// <summary>
        /// ��������    ��  ƴ���²�ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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

            //ͬ�� 
            if (strStartYear == strEndYear)
            {
                //ͬ��
                if (strStartMonth == strEndMonth)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldMonth=" + strStartMonth);
                    return strTimeSql.ToString();
                }//��ͬ��
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
        /// ��������    ��  ƴ�Ӽ���ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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

            //ͬ�� 
            if (strStartYear == strEndYear)
            {
                //ͬ��
                if (strStartSea == strEndSea)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea=" + strStartSea);
                    return strTimeSql.ToString();
                }//��ͬ��
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
        /// ��������    ��  ƴ�Ӱ����ѯ����
        /// ������      ��  ������
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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

            //ͬ�� 
            if (strStartYear == strEndYear)
            {
                //ͬ��
                if (strStartHalf == strEndHalf)
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldHalfYear=dbo.ufn_getDictionaryNameByValueAndParentID('�����־','" +
                            strStartHalf + "')");
                    return strTimeSql.ToString();
                }//��ͬ��
                else
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldHalfYear>=dbo.ufn_getDictionaryNameByValueAndParentID('�����־','" +
                            strStartHalf + "')");
                    strTimeSql.Append(" and fldHalfYear<=dbo.ufn_getDictionaryNameByValueAndParentID('�����־','" +
                            strEndHalf + "')");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldYear=" + strStartYear + " and fldHalfYear>=dbo.ufn_getDictionaryNameByValueAndParentID('�����־','" +
                    strStartHalf + "') and fldHalfYear<=dbo.ufn_getDictionaryNameByValueAndParentID('�����־','2'))");
                strTimeSql.Append(" or (fldYear>" + strStartYear + " and fldYear<" + strEndYear + ")");
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldHalfYear>=dbo.ufn_getDictionaryNameByValueAndParentID('�����־','1') " +
                    "and fldHalfYear<=dbo.ufn_getDictionaryNameByValueAndParentID('�����־','" + strEndHalf + "')))");
                return strTimeSql.ToString();
            }
            return strTimeSql.ToString();
        }
        #endregion

        /// <summary>
        /// ��������    ��  ƴ�������ַ���
        /// ������      ��  ������
        /// ��������    ��  2009-05-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string GetTaxisSql(Hashtable hasTimeSqlTable)
        { 

            if (hasTimeSqlTable["Source"] != null && hasTimeSqlTable["Source"].ToString() == "1")
                return "fldSTCode asc,fldPCode asc ,fldSAMPH asc,fldSAMPR asc,fldRSC asc,fldYear desc,fldMonth desc,fldDay desc";
            else                                   
                return "fldSTCode asc,fldPCode asc ,fldSAMPH asc,fldSAMPR asc,fldRSC asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc";
        }

        /// <summary>
        /// ��������    ��  ƴ�������ַ���
        /// ������      ��  �Ƴ�
        /// ��������    ��  2011-07-13
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string GetTaxisSqlL(Hashtable hasTimeSqlTable)
        {
            if (hasTimeSqlTable["Source"] != null && hasTimeSqlTable["Source"].ToString() == "1")
                return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldSAMPR asc,fldRSC asc,fldYear desc,fldMonth desc,fldDay desc";
            else
                return "fldSTCode asc,fldLCode asc,fldLSCode asc,fldSAMPR asc,fldRSC asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc";
        }

        /// <summary>
        /// ��������    ��  ƴ�������ַ���
        /// ������      ��  �Ƴ�
        /// ��������    ��  2011-11-04
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string GetTaxisSqlG(Hashtable hasTimeSqlTable)
        {
            if (hasTimeSqlTable["Source"] != null && hasTimeSqlTable["Source"].ToString() == "1")
                return "fldSTCode asc,fldPCode asc,fldYear desc,fldMonth desc,fldDay desc";
            else
                return "fldSTCode asc,fldPCode asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc";
        }
    }
}