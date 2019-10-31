using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuleQuery_Reported_Data : BaseRule
    {
        /// <summary>
        /// ��������    ��  ��ѯ�¼��ϱ�����
        /// ������      ��  �촺��
        /// ��������    ��  2010-06-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="itype">ҵ�����</param>
        /// <param name="strSTCode">���д���</param>
        /// <param name="strView">��Ӧ��ҵ����ͼ</param>
        /// <param name="strWhere">����ʱ������</param>
        /// <param name="strYear">���</param>
        /// <param name="strBeginTime">��ʼ����</param>
        /// <param name="strEndTime">��������</param>
        /// <param name="iQueryTime">�涨�ϱ�����</param>
        /// <param name="iTimeType">��ѯ�ϱ�����</param>
        /// <returns>DataTable</returns>
        /// 
        public DataTable GetReportedDataInfo(string  itype,string strSTCode,string strView,string strWhere,string strYear,string strBeginTime,string strEndTime,int iTimeType,int iQueryTime)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetReportedDataInfo uspGetDr = new usp_GetReportedDataInfo();
                uspGetDr.ViewType = itype;
                uspGetDr.STCode = strSTCode;
                uspGetDr.STypeView = strView;
                uspGetDr.strWhere = strWhere;
                uspGetDr.strYear = strYear;
                uspGetDr.strBegin = strBeginTime;
                uspGetDr.strEnd = strEndTime;
                uspGetDr.timetype = iTimeType;
                uspGetDr.querytype = iQueryTime;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("�����ݿ����ӳ���", "RuleQuery_Reported_Data", "GetReportedDataInfo", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleQuery_Reported_Data", "GetReportedDataInfo", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetReportedDataInfo", "");
            }
        }


        /// <summary>
        /// ��������    ��  ��ѯ��վ�ϱ�ͳ��
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2018-06-04
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="fldstcode">���д���</param>
        /// <param name="fldYWType">ҵ�����</param>
        /// <param name="fldJCType">�������</param>
        /// <param name="fldLevel">���Ƽ���</param>
        /// <param name="fldBeginDate">��ʼʱ��</param>
        /// <param name="fldEndDate">����ʱ��</param>
        /// <param name="fldTpyeNums">�ϱ�ʱ�䵥λ��ȸ���</param>
        /// <param name="fldSource">����Դ</param>
        /// <returns></returns>
        public DataTable GetSubmitDataInfo_CQ(string fldstcode, string fldYWType, string fldJCType,int fldLevel, string fldBeginDate,string fldEndDate, int fldTpyeNums, int fldSource)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetSubmitDataInfo_CQ uspGetDr = new usp_GetSubmitDataInfo_CQ();
                uspGetDr.strSTCode = fldstcode;
                uspGetDr.strYWType = fldYWType;
                uspGetDr.strJCType = fldJCType;
                uspGetDr.intLevel = fldLevel;
                uspGetDr.BeginDate = fldBeginDate;
                uspGetDr.EndDate = fldEndDate;
                uspGetDr.TpyeNums = fldTpyeNums;
                uspGetDr.Source = fldSource;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("�����ݿ����ӳ���", "RuleQuery_Reported_Data", "GetSubmitDataInfo_CQ", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleQuery_Reported_Data", "GetSubmitDataInfo_CQ", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetSubmitDataInfo_CQ", "");
            }
        }


        /// <summary>
        /// ��������    ��  ��ѯ�¼��ϱ�����
        /// ������      ��  �촺��
        /// ��������    ��  2010-06-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="itype">ҵ�����</param>
        /// <param name="strSTCode">���д���</param>
        /// <param name="strView">��Ӧ��ҵ����ͼ</param>
        /// <param name="strWhere">����ʱ������</param>
        /// <param name="strYear">���</param>
        /// <param name="strBeginTime">��ʼ����</param>
        /// <param name="strEndTime">��������</param>
        /// <param name="iQueryTime">�涨�ϱ�����</param>
        /// <param name="iTimeType">��ѯ�ϱ�����</param>
        /// <returns>DataTable</returns>
        /// 
        public DataTable GetReportedDataInfo_basedata(string itype, string strSTCode, string strView, string strWhere, string strYear, string strBeginTime, string strEndTime, int iTimeType, int iQueryTime)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetReportedDataInfo_basedata uspGetDr = new usp_GetReportedDataInfo_basedata();
                uspGetDr.ViewType = itype;
                uspGetDr.STCode = strSTCode;
                uspGetDr.STypeView = strView;
                uspGetDr.strWhere = strWhere;
                uspGetDr.strYear = strYear;
                uspGetDr.strBegin = strBeginTime;
                uspGetDr.strEnd = strEndTime;
                uspGetDr.timetype = iTimeType;
                uspGetDr.querytype = iQueryTime;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("�����ݿ����ӳ���", "RuleQuery_Reported_Data", "GetReportedDataInfo_basedata", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleQuery_Reported_Data", "GetReportedDataInfo_basedata", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetReportedDataInfo_basedata", "");
            }
        }

        /// <summary>
        /// ��������    ��  �õ�Ӧ��������ƺͿ��Ƽ���
        /// ������      ��  �촺��
        /// ��������    ��  2010-07-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="itype">ҵ�����</param>
        /// <param name="strSTCode">���д���</param>  
        /// <param name="strYear">���</param>
        /// <returns>DataTable</returns>
        public DataTable GetPointNameorLevel(string itype, string strSTCode,string strYear)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetPointNameorLevel uspGetDr = new usp_GetPointNameorLevel();
                uspGetDr.type = itype;
                uspGetDr.sTCode = strSTCode; 
                uspGetDr.sYear = strYear;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("�����ݿ����ӳ���", "RuleQuery_Reported_Data", "GetPointNameorLevel", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleQuery_Reported_Data", "GetPointNameorLevel", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetPointNameorLevel", "");
            }
        }


        /// <summary>
        /// ��������    ��  �õ�ʵ��������ƺͿ��Ƽ���
        /// ������      ��  �촺��
        /// ��������    ��  2010-07-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="itype">ҵ�����</param> 
        /// <param name="sview">��ͼ��</param>
        /// <param name="swhere">�������</param>
        /// <returns>DataTable</returns>
        public DataTable GetPointNameorLevel_shibao(string itype, string sview, string swhere)
        {
            try
            {

                DataTable tblData = new DataTable();
                usp_GetPointNameorLevel_shibao uspGetDr = new usp_GetPointNameorLevel_shibao();
                uspGetDr.type = itype;
                uspGetDr.sWhere = swhere;
                uspGetDr.view = sview;
                tblData = uspGetDr.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("�����ݿ����ӳ���", "RuleQuery_Reported_Data", "GetPointNameorLevel_shibao", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleQuery_Reported_Data", "GetPointNameorLevel_shibao", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleQuery_Reported_Data", "GetPointNameorLevel_shibao", "");
            }
        }
    }
}
