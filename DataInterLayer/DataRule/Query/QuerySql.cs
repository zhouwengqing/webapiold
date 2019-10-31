using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using DDYZ.Ensis.Rule.DataRule;

namespace DDYZ.Ensis.Rule.BusinessRule.Query
{
    /// <summary>
    /// ��������    ��  ƴ�Ӳ�ѯ�������
    /// ������      ��  �촺��
    /// ��������    ��  2009-05-18
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class QuerySql : BaseRule
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
        /// ��������    ��  �õ���ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="hasTable">��ѯ����</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strCityCode">���д���</param>
        public string GetStrSql(Hashtable hasTable,string strUserName,string strCityCode)
        {
            string strSourceSql;
            string strCityPoint;
            string strTimeSql;
            string strItemSql;
            
            this.PagehasSqlTable();

            strSourceSql = this.QuerySourceSql(hasTable);
            strCityPoint=this.QueryConditions(hasTable);
            strTimeSql = this.QueryTimeSql(hasTable);
            strItemSql=this.QueryItemSql(hasTable);

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
           
             
            //if (hasTable["DataType"] != null && hasTable["DataType"].ToString() == "1")
            //    strSql += "fldEHour!=-1 and";
            if (strSql.Length > 0)
                strSql = strSql.Substring(0, strSql.Length - 4);

            return strSql;
        }

        /// <summary>
        /// ��������    ��  �õ�������ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-22
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="hasTable">��ѯ����</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strCityCode">���д���</param>
        public string GetEQIA_RD_StrSql(Hashtable hasTable, string strUserName, string strCityCode)
        {
            string strSourceSql;
            string strCityPoint;
            string strTimeSql;
            string strItemSql;

            this.PagehasSqlTable();

            strSourceSql = this.QuerySourceSql(hasTable);
            strCityPoint = this.QueryConditions(hasTable);
            strTimeSql = this.QueryEQIAR_RD_TimeSql(hasTable);
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


            //if (hasTable["DataType"] != null && hasTable["DataType"].ToString() == "1")
            //    strSql += "fldEHour!=-1 and";
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

            //if (hasTable["Source"] != null)
            //{
            //    RuletblDictionary ruleDict = new RuletblDictionary();
            //    if (hasTable["Source"].ToString() != "1")
            //        sSourceSql = "fldSource='" + ruleDict.ByParentIDAndValue("������Դ", "0") + "'";
            //}

            return sSourceSql;
        }

        /// <summary>
        /// ��������    ��  ƴ�ӳ��в���ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-18
        /// �޸���      ��  ������
        /// �޸�����    ��  2009-09-01
        /// �޸�ԭ��    ��  ԭ���Ĳ�ѯ���������ݲ��ԣ�Ӧ����fldSTCode+'.'+fldPCode����ʽ��ϲ�ѯ����
        /// </summary>
        private string QueryConditions(Hashtable hasTable)
        {
            string strPointSql = hasTable["Point"].ToString();

            if (strPointSql != "")
                strPointSql = "fldSTCode+'.'+fldPCode in (" + strPointSql + ")";
            return strPointSql;
        }

        /// <summary>
        /// ��������    ��  ƴ�Ӳ����Ŀ��ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// 
        private string QueryItemSql(Hashtable hasTable)
        {
            string strItemSql;
            if (hasTable.Contains("Item") && hasTable["Item"].ToString() != "")
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
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string QueryEQIAR_RD_TimeSql(Hashtable hasTable)
        {
            string strTimeSql = "";
            string strStartTimeTemp;
            string strEndTimeTemp;

            string[] strTimeAll = new string[2];
            if (hasTable["TimeType"].ToString() != "1")
            {
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

                    strTimeSql = this.GetEQIA_RD_HourSql(this.hasTimeSqlTables);
                }
                //if (hasTable["Module"] != null && hasTable["Module"].ToString() == "eqia_r")
                //{
                //    if (hasTable["DataType"] != null && hasTable["DataType"].ToString() == "1")
                //        strTimeSql += " and fldEHour!=-1 ";
                //    else
                //    {
                //        if (hasTable["Source"].ToString() == "0")
                //            strTimeSql += " and fldEHour=-1 ";
                //    }
                //}
            }
            else
            {
                if (hasTable["Source"].ToString() == "0")
                {
                    if (hasTable["DataType"] != null && hasTable["DataType"].ToString() == "0")
                        strTimeSql = "fldEHour=-1 ";
                    else
                    {
                        strTimeAll = hasTable["Hours"].ToString().Split(';');
                        strTimeSql = "fldEHour>=" + strTimeAll[0].ToString() + " and fldEHour<=" + strTimeAll[1].ToString();
                    }
                }
            }

            return strTimeSql;
        }


        /// <summary>
        /// ��������    ��  ƴ�ӽ���Сʱ��ѯ����(ԭʼ���ݱ�)
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-22
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        private string GetEQIA_RD_HourSql(Hashtable hasTimeSqlTable)
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
                    strTimeSql.Append("fldEYear=" + strStartYear + " and fldEMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldEDay>=" + strStartDay + " and fldEDay<=" + strEndDay);
                    return strTimeSql.ToString();
                }//��ͬ��
                else
                {

                    strTimeSql.Append("((fldEYear=" + strStartYear + " and fldEMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldEDay>=" + strStartDay + " and fldEDay<=31) or ");
                    strTimeSql.Append(" (fldEYear=" + strStartYear + " and fldEMonth>" + strStartMonth);
                    strTimeSql.Append(" and fldEMonth<" + strEndMonth + ") or ");
                    strTimeSql.Append(" (fldEYear=" + strStartYear + " and fldEMonth=" + strEndMonth);
                    strTimeSql.Append(" and fldEDay>=1 and fldEDay<=" + strEndDay + "))");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldEyear=" + strStartYear + " and fldEmonth=" + strStartMonth + " and fldEday>=" + strStartDay + " and fldEday<=31)");
                strTimeSql.Append(" or(fldEyear=" + strStartYear + " and fldEmonth>" + strStartMonth + " and  fldEmonth<=12)");
                strTimeSql.Append(" or( fldEyear>" + strStartYear + " and fldEyear<" + strEndYear + ")");
                strTimeSql.Append(" or(fldEyear=" + strEndYear + " and fldEmonth>=1 and  fldEmonth<" + strEndMonth + ")");
                strTimeSql.Append("  or(fldEyear=" + strEndYear + " and  fldEmonth=" + strEndMonth + " and fldEday>=1 and fldEday<=" + strEndDay + " ))");
                return strTimeSql.ToString();
            }

        }
        /// <summary>
        /// ��������    ��  ƴ��ʱ���ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string QueryTimeSql(Hashtable hasTable)
        {
            string strTimeSql="";
            string strStartTimeTemp;
            string strEndTimeTemp;

            string[] strTimeAll = new string[2];
            if (hasTable["TimeType"].ToString()!= "1")            
            { 
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
                //if (hasTable["Module"] != null && hasTable["Module"].ToString() == "eqia_r")
                //{
                //    if (hasTable["DataType"] != null && hasTable["DataType"].ToString() == "1")
                //        strTimeSql += " and fldEHour!=-1 ";
                //    else
                //    {
                //        if (hasTable["Source"].ToString() == "0")
                //            strTimeSql += " and fldEHour=-1 ";
                //    }
                //}
            }
            else
            {
                if (hasTable["Source"].ToString() == "0")
                {
                    if (hasTable["DataType"] != null && hasTable["DataType"].ToString() == "0")
                        strTimeSql = "fldSHour=-1 ";
                    else
                    {
                        strTimeAll = hasTable["Hours"].ToString().Split(';');
                        strTimeSql = "fldSHour>=" + strTimeAll[0].ToString() + " and fldSHour<=" + strTimeAll[1].ToString();
                    }
                }
            }
           
            return strTimeSql;
        }



        /// <summary>
        /// ��������    ��  ƴ��Сʱ��ѯ����(ԭʼ���ݱ�)
        /// ������      ��  �촺��
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
                    strTimeSql.Append("fldSYear=" + strStartYear + " and fldSMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldSDay>=" + strStartDay + " and fldSDay<=" + strEndDay);
                    return strTimeSql.ToString();
                }//��ͬ��
                else
                {

                    strTimeSql.Append("((fldSYear=" + strStartYear + " and fldSMonth=" + strStartMonth);
                    strTimeSql.Append(" and fldSDay>=" + strStartDay + " and fldSDay<=31) or ");
                    strTimeSql.Append(" (fldSYear=" + strStartYear + " and fldSMonth>" + strStartMonth);
                    strTimeSql.Append(" and fldSMonth<" + strEndMonth + ") or ");
                    strTimeSql.Append(" (fldSYear=" + strStartYear + " and fldSMonth=" + strEndMonth);
                    strTimeSql.Append(" and fldSDay>=1 and fldSDay<=" + strEndDay + "))");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldSyear=" + strStartYear + " and fldSmonth=" + strStartMonth + " and fldSday>=" + strStartDay + " and fldSday<=31)");
                strTimeSql.Append(" or(fldSyear=" + strStartYear + " and fldSmonth>" + strStartMonth + " and  fldSmonth<=12)");
                strTimeSql.Append(" or( fldSyear>" + strStartYear + " and fldSyear<" + strEndYear + ")");
                strTimeSql.Append(" or(fldSyear=" + strEndYear + " and fldSmonth>=1 and  fldSmonth<" + strEndMonth + ")");
                strTimeSql.Append("  or(fldSyear=" + strEndYear + " and  fldSmonth=" + strEndMonth + " and fldSday>=1 and fldSday<=" + strEndDay + " ))");
                return strTimeSql.ToString();
            }

        }

        /// <summary>
        /// ��������    ��  ƴ���ղ�ѯ����
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        private string GetDaySql(Hashtable hasTimeSqlTable)
        {
            StringBuilder strTimeSql=new StringBuilder();
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
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        private string GetMonthSql(Hashtable hasTimeSqlTable)
        {
             StringBuilder strTimeSql=new StringBuilder();
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
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldMonth>=1 and fldMonth<=" + strEndMonth+"))");
                return strTimeSql.ToString();
            }
        }

        /// <summary>
        /// ��������    ��  ƴ�Ӽ���ѯ����
        /// ������      ��  �촺��
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
        /// ������      ��  �촺��
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
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string GetTaxisSql(Hashtable hasTimeSqlTable)
        {
            if (hasTimeSqlTable["Source"] != null && hasTimeSqlTable["Source"].ToString() == "1")
                return "fldSTCode asc,fldPCode asc,fldSYear,fldSMonth,fldSDay";
            else
                return "fldSTCode asc,fldPCode asc,fldSYear,fldSMonth,fldSDay";
        }
        /// <summary>
        /// ��������    ��  ƴ�������ַ���
        /// ������      ��  �촺��
        /// ��������    ��  2009-05-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string GetEQIA_D_TaxisSql(Hashtable hasTimeSqlTable)
        {
            if (hasTimeSqlTable["Source"] != null && hasTimeSqlTable["Source"].ToString() == "1")
                return "fldPType asc,fldSrot asc";
            else
                return "fldPType asc,fldSrot asc";
        }
    }
} 