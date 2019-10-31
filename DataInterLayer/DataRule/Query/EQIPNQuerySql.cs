using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DDYZ.Ensis.Rule.DataRule;

namespace DDYZ.Ensis.Rule.BusinessRule.Query
{
    /// <summary>
    /// ��������    ��  ƴ�Ӳ�ѯ�������
    /// ������      ��  �ź�
    /// ��������    ��  2010-02-26
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class EQIPNQuerySql : BaseRule
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
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="hasTable">��ѯ����</param>
        /// <param name="strUserName">�û���</param>
        /// <param name="strCityCode">���д���</param>
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
                strSql += "fldSTCode like '%" + strCityCode + "%' and ";

            if (strSql.Length > 0)
                strSql = strSql.Substring(0, strSql.Length - 4);

            return strSql;
        }

        #region ���в����Ŀ��ѯ����
        /// <summary>
        /// ��������    ��  ƴ�ӳ��в���ѯ����
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>

        private string QueryConditions(Hashtable hasTable)
        {
            try
            {
                string strPointSql = hasTable["Point"].ToString();
                string strPointName = hasTable["PointName"].ToString();
                //string strname="";
                //for(int i=0;i<strPointName.Length;i++)
                //{
                //    strname+=",'"+strPointName[i].Remove(0,strPointName[i].IndexOf('.')+1)+"'";
                //}  
                if (strPointSql != "")
                    strPointSql = "fldSTCode+'.'+fldCompanyCode in (" + strPointSql + ") and fldcompanyName in(" + strPointName + ") ";
                return strPointSql;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        /// <summary>
        /// ��������    ��  ƴ����ҹ��ѯ����
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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

        #region ʱ���ѯ����
        /// <summary>
        /// ��������    ��  ƴ��ʱ���ѯ����
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        private string QueryTimeSql(Hashtable hasTable)
        {
            string strTimeSql;
            string strStartTimeTemp;
            string strEndTimeTemp;

            string[] strTimeAll = new string[2];
            if (hasTable["TimeType"].ToString() == "1")
            {
                string [] strTemp=new string[3];
                strTemp = hasTable["Hours"].ToString().Split(';');
                strTimeSql = "fldYear=" + strTemp[2].ToString() + " and fldHour>=" + strTemp[0].ToString() + " and fldHour<=" + strTemp[1].ToString();
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
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
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
        /// ��������    ��  ƴ�Ӽ���ѯ����
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
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
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea='" + strStartSea + "'");
                    return strTimeSql.ToString();
                }//��ͬ��
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
        /// ��������    ��  ƴ�Ӱ����ѯ����
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
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
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea=dbo.ufn_getDictionaryNameByValueAndParentID('����','" +
                            strStartHalf + "')");
                    return strTimeSql.ToString();
                }//��ͬ��
                else
                {
                    strTimeSql.Append("fldYear=" + strStartYear + " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('����','" +
                            strStartHalf + "')");
                    strTimeSql.Append(" and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('����','" +
                            strEndHalf + "')");
                    return strTimeSql.ToString();
                }
            }
            else
            {
                strTimeSql.Append("((fldYear=" + strStartYear + " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('����','" +
                    strStartHalf + "') and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('����','6'))");
                strTimeSql.Append(" or (fldYear>" + strStartYear + " and fldYear<" + strEndYear + " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('����','5') and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('����','6'))");
                strTimeSql.Append(" or (fldYear=" + strEndYear + " and fldSea>=dbo.ufn_getDictionaryNameByValueAndParentID('����','5') " +
                    "and fldSea<=dbo.ufn_getDictionaryNameByValueAndParentID('����','" + strEndHalf + "')))");
                return strTimeSql.ToString();
            }
            return strTimeSql.ToString();
        }
        #endregion

        /// <summary>
        /// ��������    ��  ƴ�������ַ���
        /// ������      ��  �ź�
        /// ��������    ��  2010-02-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        public string GetTaxisSql(Hashtable hasTimeSqlTable)
        {
            string strTaxis = "";
            strTaxis = "fldAutoID desc,fldSTCode asc,fldCompanyCode asc,fldYear desc,fldMonth desc,fldDay desc,fldHour desc, fldSR asc";
            return strTaxis;
        }
    }
}
