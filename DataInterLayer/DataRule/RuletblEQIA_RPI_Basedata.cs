using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using System.Collections;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  �Ա�[tblEQIA_RPI_Basedata]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_RPI_Basedata : BaseRule
    {
        //���
        private string eqiType = "eqia_r";
        private string TypeName = "�������";







        /// <summary>
        /// ��������    ��  ��ȡ�����쳣��λ(����û�д������)
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Point_ByExceptionValueForGis()
        {
            try
            {
                usp_getEQIA_R_Point_ByExceptionValueForGis uspDel = new usp_getEQIA_R_Point_ByExceptionValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByExceptionValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByExceptionValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByExceptionValueForGis", "");
            }
        }
        /// <summary>
        /// ��������    ��  ��ȡ���������λ
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Point_ByOutValueForGis()
        {
            try
            {
                usp_getEQIA_R_Point_ByOutValueForGis uspDel = new usp_getEQIA_R_Point_ByOutValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByOutValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByOutValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Point_ByOutValueForGis", "");
            }
        }


        /// <summary>
        /// ��������    ��  ��ȡ�������¼��ֵ��������
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="strPcode">������</param>
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Value_ByPointForGis(string strSTCode, string strPcode)
        {
            try
            {
                usp_getEQIA_R_Value_ByPointForGis uspDel = new usp_getEQIA_R_Value_ByPointForGis();
                uspDel.fldPcode = strPcode;
                uspDel.fldSTCode = strSTCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByPointForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByPointForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByPointForGis", "");
            }
        }


        /// <summary>
        /// ��������    ��  ȡ�����в�����ļ��ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-19
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIA_R_Value_ByAllForGis uspDel = new usp_getEQIA_R_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_Value_ByAllForGis", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��ȡ����(O3)��8Сʱ������ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetO3EightAVGValue()
        {
            try
            {
                usp_Eqia_RPI_Basedata_Living_GetO3EightAVGValue uspDel = new usp_Eqia_RPI_Basedata_Living_GetO3EightAVGValue();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetO3EightAVGValue", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetO3EightAVGValue", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetO3EightAVGValue", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��ȡ24Сʱ������ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetTwentyFourAVGValue()
        {
            try
            {
                usp_Eqia_RPI_Basedata_Living_GetTwentyFourAVGValue uspDel = new usp_Eqia_RPI_Basedata_Living_GetTwentyFourAVGValue();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetTwentyFourAVGValue", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetTwentyFourAVGValue", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetTwentyFourAVGValue", "");
            }
        }



        /// <summary>
        /// ��������    ��  ͨ������ȡ��㵱ǰʱ����ǰ�����ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-01
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>  
        /// <param name="strSTName">��������</param>
        /// <param name="strPName">�������</param>
        /// <param name="iDay">��ʾ����</param>
        /// <returns>DataTable </returns>
        public DataTable GetPointHourValue(string strSTName, string strPName, int iDay)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_Living_GetHoursValue uspDel = new usp_tblEQIA_RPI_BaseData_Living_GetHoursValue();
                uspDel.ShowStName = strSTName;
                uspDel.showPName = strPName;
                uspDel.ShowDay = iDay;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetPointHourValue", "strSTName=" + strSTName + " strPName=" + strPName + " iDay=" + iDay.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetPointHourValue", "strSTName=" + strSTName + " strPName=" + strPName + " iDay=" + iDay.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetPointHourValue", "strSTName=" + strSTName + " strPName=" + strPName + " iDay=" + iDay.ToString());
            }
        }



        /// <summary>
        /// ��������    ��  ȡ���������÷������ݵĹ�������(ִ��Lap���ݿ�)
        /// ������      ��  �촺��
        /// ��������    ��  2012-11-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIA_R_SetCPUDataGis(string strSQL)
        {
            try
            {
                usp_execInsert uspSql = new usp_execInsert();
                uspSql.insertsql = strSQL;
                DataTable dt = uspSql.ExecDataTable(1);
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_SetCPUDataGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetEQIA_R_SetCPUDataGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetEQIA_R_SetCPUDataGis", "");
            }
        }




        /// <summary>
        /// ��������    ��  ȡ�����г��кͲ�����/��ǰСʱ�ļ��ֵ��AQI����������״��
        /// ������      ��  �촺��
        /// ��������    ��  2013-07-24
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="strCode">���д���</param>
        /// <returns>DataTable </returns>
        public DataTable GetRealTimeAQI_BAllForPage(string strCode)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetRealTimeAQI_Page uspDel = new usp_tblEQIA_RPI_BaseData_GetRealTimeAQI_Page();
                uspDel.fldSTCode = strCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetRealTimeAQI_BAllForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetRealTimeAQI_BAllForPage", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetRealTimeAQI_BAllForPage", "");
            }
        }
        /// <summary>
        /// ��������    ��  ȡ��ʵʱ������������AQI��Ũ��
        /// ������      ��  �촺��
        /// ��������    ��  2013-07-24
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="strCode">���д���</param>
        /// <param name="iDay">��ʾ����</param>
        /// <param name="sType">��� ����/���</param>
        /// <returns>DataTable </returns>
        public DataTable GetTrendAQIOrDensity_Page(string strCode, int iDay, string sType)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_Page uspDel = new usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_Page();
                uspDel.Day = iDay;
                uspDel.fldSTCode = strCode;
                uspDel.Type = sType;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_Page", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_Page", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_Page", "");
            }
        }



        /// <summary>
        /// ��������    ��  ȡ�ü�����ӵľ�ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2013-08-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="type">ʱ�����(��,��,��)</param>
        /// <param name="iSource">������Դ(�ֹ�:0 �Զ�:1)</param>
        /// <param name="strBeginDate">��ʼʱ��</param>
        /// <param name="strEndDate">����ʱ��</param>
        /// <param name="strItemCode">������Ӵ���</param>
        /// <param name="strSTCode">���д���</param>
        /// <returns>DataTable </returns>
        public DataTable GetItemAVGData(string type, string strBeginDate, string strEndDate, string strSTCode, string strItemCode, short iSource, string sReportType)
        {
            try
            {
                usp_tblEQIA_R_BaseData_GetItemAVGDataForGis uspAVGData = new usp_tblEQIA_R_BaseData_GetItemAVGDataForGis();
                uspAVGData.fldTimeType = type;
                uspAVGData.BeginDate = strBeginDate;
                uspAVGData.EndDate = strEndDate;
                uspAVGData.fldSTCode = strSTCode;
                uspAVGData.fldItemCode = strItemCode;
                uspAVGData.fldSource = iSource;
                uspAVGData.ReportType = sReportType;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + type + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode + ",sSource:" + iSource.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + type + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode + ",sSource:" + iSource.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + type + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode + ",sSource:" + iSource.ToString());
            }
        }

        /// <summary> 
        /// ��������    ��  ȡ��AQI�����ձ�
        /// ������      ��  �촺��
        /// ��������    ��  2013-09-03
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="BDate">��ʼʱ��</param>
        /// <param name="EDate">����ʱ��</param> 
        /// <returns>DataTable</returns>
        public DataTable GetDayAQIReport_Page(string STCode, string BDate, string EDate)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetCityDayAQI_Page uspAVGData = new usp_tblEQIA_RPI_BaseData_GetCityDayAQI_Page();
                uspAVGData.fldSTCode = STCode;
                uspAVGData.BeginDate = BDate.ToString();
                uspAVGData.EndDate = EDate.ToString();
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetDayAQIReport_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetDayAQIReport_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetDayAQIReport_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
        }


        /// <summary> 
        /// ��������    ��  ȡ��AQI��������
        /// ������      ��  �촺��
        /// ��������    ��  2013-09-23
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="BDate">��ʼʱ��</param>
        /// <param name="EDate">����ʱ��</param> 
        /// <param name="PCode">������</param>
        /// <param name="sType">�������(����/���)</param>
        /// <returns>DataTable</returns>
        public DataTable GetCityAQIDayProportion_Page(string STCode, string PCode, string BDate, string EDate, string sType)
        {
            try
            {
                usp_tblEQIA_R_Report_CityDayData_Page uspAVGData = new usp_tblEQIA_R_Report_CityDayData_Page();
                uspAVGData.fldSTCode = STCode;
                uspAVGData.fldPCode = PCode;
                uspAVGData.BeginDate = BDate.ToString();
                uspAVGData.EndDate = EDate.ToString();
                uspAVGData.fldType = sType;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetCityAQIDayProportion_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetCityAQIDayProportion_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetCityAQIDayProportion_Page", "STCode:" + STCode + "BDate:" + BDate.ToString() + ",EDate:" + EDate.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ���о�ֵ��AQIֵ
        /// ������      ��  du
        /// ��������    ��  2014-11-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="sTimeType">ʱ�����(��,��,��..)</param>
        /// <param name="sBeginDate">��ʼʱ��</param>
        /// <param name="sEndDate">����ʱ��</param>
        /// <param name="sItem">ѡ����Ŀid</param>
        /// <param name="sPoint">���</param>
        /// <param name="sIStdName">��Ŀ����ı�׼����</param>
        /// <param name="sIStdLevel">��Ŀ����ı�׼����</param>
        /// <param name="sSource">������Դ(0�ֹ����Զ� 2ȫ��)</param>
        /// <param name="sJudge">���ݳ�ͻѡ�񣨣��ֹ����Զ���</param>
        /// <param name="cDecCarry">��Ŀ����ȡֵ����</param>
        /// <param name="sReportFlag">�洢������;��0��������ʾ��1��ͼ�η���</param>
        /// <param name="sSTLevel">���м������1-ʡվ��2-��վ��3-����վ     </param>
        /// <param name="sFromHour">��ʼСʱ</param>
        /// <returns>DataTable</returns>
        public DataTable GetCityAvgAndAQI_Q(string sTimeType, string sBeginDate, string sEndDate, string sItem, string sPoint,
                                                    string sIStdName, short sIStdLevel, short sSource, short sJudge, string cDecCarry, short sFromHour, short sReportFlag, short sSTLevel)
        {
            try
            {
                usp_tblEQIA_R_Report_CityValue_AQIEx uspAnalyseData = new usp_tblEQIA_R_Report_CityValue_AQIEx();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sIStdName;
                uspAnalyseData.fldLevel = sIStdLevel;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                uspAnalyseData.ReportFlag = sReportFlag;
                uspAnalyseData.intSTLevel = sSTLevel;
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_Report", "GetCityAvgAndAQI_Q", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_Report", "GetCityAvgAndAQI_Q", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Report", "GetCityAvgAndAQI_Q", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }
        /// <summary>
        /// ��������    ��  ����ֵ��AQIֵ
        /// ������      ��  ���Ѷ�
        /// ��������    ��  2014-07-16
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="sTimeType">ʱ�����(��,��,��..)</param>
        /// <param name="sBeginDate">��ʼʱ��</param>
        /// <param name="sEndDate">����ʱ��</param>
        /// <param name="sItem">ѡ����Ŀid</param>
        /// <param name="sPoint">���</param>
        /// <param name="sIStdName">��Ŀ����ı�׼����</param>
        /// <param name="sIStdLevel">��Ŀ����ı�׼����</param>
        /// <param name="sSource">������Դ(0�ֹ����Զ� 2ȫ��)</param>
        /// <param name="sJudge">���ݳ�ͻѡ�񣨣��ֹ����Զ���</param>
        /// <param name="cDecCarry">��Ŀ����ȡֵ����</param>
        /// <param name="sReportFlag">�洢������;��0��������ʾ��1��ͼ�η���</param>
        /// <param name="sSTLevel">���м������1-ʡվ��2-��վ��3-����վ     </param>
        /// <param name="sFromHour">��ʼСʱ</param>
        /// <returns>DataTable</returns>
        public DataTable GetPointAvgAndAQI(string sTimeType, string sBeginDate, string sEndDate, string sItem, string sPoint,
                                                    string sIStdName, short sIStdLevel, short sSource, short sJudge, string cDecCarry, short sFromHour, short sReportFlag, short sSTLevel)
        {
            try
            {
                usp_tblEQIA_R_Report_PointValue_AQI uspAnalyseData = new usp_tblEQIA_R_Report_PointValue_AQI();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.fldStandardName = sIStdName;
                uspAnalyseData.fldLevel = sIStdLevel;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                uspAnalyseData.ReportFlag = sReportFlag;
                uspAnalyseData.intSTLevel = sSTLevel;
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_Report", "GetPointAvgAndAQI", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_Report", "GetPointAvgAndAQI", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Report", "GetPointAvgAndAQI", "sTimeType:" + sTimeType +
                    ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sIStdName:" + sIStdName + ",sIStdLevel:" +
                    sIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" + cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }

        /// <summary> 
        /// ��������    ��  ���ʪ�ȣ��¶�
        /// ������      ��  �촺��
        /// ��������    ��  2013-11-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="DTime">ʱ��</param>
        /// <param name="Pcode">������</param>
        /// <param name="STCode">���д���</param>
        /// <returns>DataTable </returns>
        public DataTable GetHumidityAndTemperature(string STCode, string Pcode, DateTime DTime)
        {
            try
            {
                usp_tblEQIA_RPI_Basedata_GetHumidityAndTemperature uspAVGData = new usp_tblEQIA_RPI_Basedata_GetHumidityAndTemperature();
                uspAVGData.fldStCode = STCode;
                uspAVGData.fldPcode = Pcode;
                uspAVGData.fldYear = DTime.Year;
                uspAVGData.fldMonth = DTime.Month;
                uspAVGData.fldDay = DTime.Day;
                uspAVGData.fldhour = DTime.Hour;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetHumidityAndTemperature", "STCode:" + STCode + ",Pcode:" + Pcode +
                    ",DTime:" + DTime.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetHumidityAndTemperature", "STCode:" + STCode + ",Pcode:" + Pcode +
                    ",DTime:" + DTime.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetHumidityAndTemperature", "STCode:" + STCode + ",Pcode:" + Pcode +
                    ",DTime:" + DTime.ToString());
            }
        }


        /// <summary>
        /// ��������    ��  ȡ��ʵʱ������������AQI��Ũ��
        /// ������      ��  �촺��
        /// ��������    ��  2013-07-24
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="strCode">���д���</param>
        /// <param name="iDay">��ʾ����</param>
        /// <param name="sType">��� ����/���</param>
        /// <returns>DataTable </returns>
        public DataTable GetTrendAQIOrDensity_GIS(string strCode, bool isTrend)
        {
            try
            {
                usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_GIS uspDel = new usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_GIS();
                uspDel.isTrend = isTrend;
                uspDel.fldSTCode = strCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_GIS", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_GIS", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetTrendAQIOrDensity_GIS", "");
            }
        }
















        /// <summary>
        /// ��������    ��  �������[tblEQIA_RPI_Basedata]��ļ�¼
        /// ������      ��  �ź�
        /// ��������    ��  2009-05-13
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="lstData">Ҫ��ӵ�tblEQIA_RPI_Basedata��ʵ������</param>
        /// <param name="lstCurrentData">��Ҫ���µı����е�ʵ��������</param>
        /// <param name="lstJuniorData">��Ҫ���µ��¼����е�ʵ��������</param>
        /// <param name="lstAud">���δͨ��ԭ���ʵ��������</param>
        /// <param name="new_CityID_Operate">���º�Ĳ�������ID</param>
        /// <param name="new_CityID_Submit">���º���ύ����ID</param>
        /// <returns>�����Ƿ�ɹ�</returns>
        public bool InsertAllOrUpdateNoPassAll(List<tblEQIA_RPI_Basedata> lstData, List<tblEQIA_RPI_Basedata_Pre> lstCurrentData, List<tblEQIA_RPI_Basedata_Pre> lstJuniorData, List<tblEQIA_RPI_Auditing> lstAud, List<tblFW_AuditingLog> lstAudLog, string new_CityID_Operate, string new_CityID_Submit, int grade, string comment, string operID2, string submit2, string flag2)
        {
            int iRowIndex = 0;
            string dateAll = "", date = "";
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        //����
                        for (iRowIndex = 0; iRowIndex < lstCurrentData.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RPI_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIA_RPI_Basedata_Pre_UpdateCity();
                            uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                            uspUpdate.new_fldFlag = Int16.Parse(flag2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Operate = Int32.Parse(operID2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Submit = submit2.Split(',')[iRowIndex];
                            uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("�޸ļ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");

                            date = lstCurrentData[iRowIndex].fldSYear.ToString() + lstCurrentData[iRowIndex].fldSMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstCurrentData[iRowIndex].fldSYear;
                                usp_upin.fldMonth = lstCurrentData[iRowIndex].fldSMonth;
                                usp_upin.fldDay = lstCurrentData[iRowIndex].fldSDay;
                                usp_upin.fldComment = comment;
                                int iResultUpIn = usp_upin.ExecNoQuery(conn, tran);
                                if (iResultUpIn <= 0)
                                    throw new Exception("�޸Ļ����ʧ��");
                            }
                            dateAll += date + ",";
                        }

                        //����¼�뵽ԭʼ��
                        for (iRowIndex = 0; iRowIndex < lstData.Count; iRowIndex++)
                        {
                            //if (lstData[iRowIndex].fldItemValue != -1)
                            //{
                            //������¼�뵽_RAW ����
                            usp_tblEQI_InsertByType usp_ins = new usp_tblEQI_InsertByType();
                            usp_ins.autoid = lstData[iRowIndex].fldAutoID;
                            usp_ins.type = eqiType;
                            int iResultInsertByType = usp_ins.ExecNoQuery(conn, tran);
                            if (iResultInsertByType <= 0)
                                throw new Exception("��Ӽ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");

                            //�ж��Ƿ���ɾ�����ݣ� ��û��ɾ��������¼�뵽ԭʼ������ȥ
                            usp_tblEQI_GetByType usp_get = new usp_tblEQI_GetByType();
                            usp_get.autoid = lstData[iRowIndex].fldAutoID;
                            usp_get.type = eqiType;
                            DataTable dt = usp_get.ExecDataTable();
                            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "0")
                            {
                                usp_tblEQIA_RPI_Basedata_Insert uspInsert = new usp_tblEQIA_RPI_Basedata_Insert();
                                uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("��Ӽ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                            }
                            //}
                            usp_tblEQIA_RPI_Basedata_Pre_Delete usp_pre_Delete = new usp_tblEQIA_RPI_Basedata_Pre_Delete();
                            usp_pre_Delete.fldAutoID = lstData[iRowIndex].fldAutoID;
                            int iResultdelete = usp_pre_Delete.ExecNoQuery(conn, tran);
                            if (iResultdelete <= 0)
                                throw new Exception("ɾ����ʱ���¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");

                            date = lstData[iRowIndex].fldSYear.ToString() + lstData[iRowIndex].fldSMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstData[iRowIndex].fldSYear;
                                usp_upin.fldMonth = lstData[iRowIndex].fldSMonth;
                                usp_upin.fldDay = lstData[iRowIndex].fldSDay;
                                usp_upin.fldComment = comment;
                                int iResultUpIn = usp_upin.ExecNoQuery(conn, tran);
                                if (iResultUpIn <= 0)
                                    throw new Exception("�޸Ļ����ʧ��");
                            }
                            dateAll += date + ",";

                        }






                        //���ݸ�Ϊ�����������δͨ��״̬
                        //for (iRowIndex = 0; iRowIndex < lstCurrentData.Count; iRowIndex++)
                        //{
                        //    usp_tblEQIA_RPI_Basedata_Pre_UpdateFlag uspUpdate = new usp_tblEQIA_RPI_Basedata_Pre_UpdateFlag();
                        //    uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                        //    uspUpdate.new_fldFlag = 12;
                        //    uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                        //    int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                        //    //if (iResultInsert <= 0)
                        //        //throw new Exception("�޸ļ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        //}
                        //���ݸ�Ϊ�¼��������δͨ��״̬
                        for (iRowIndex = 0; iRowIndex < lstJuniorData.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RPI_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIA_RPI_Basedata_Pre_UpdateCity();
                            uspUpdate.ReceiveParameter_Old(lstJuniorData[iRowIndex]);
                            uspUpdate.new_fldCityID_Operate = Convert.ToInt32(new_CityID_Operate.Split(',')[iRowIndex]);
                            uspUpdate.new_fldCityID_Submit = new_CityID_Submit.Split(',')[iRowIndex];
                            uspUpdate.new_fldFlag = -2;
                            uspUpdate.new_fldDate_Operate = DateTime.Now;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("�޸ļ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        //���δͨ��ԭ��д�����ݱ�
                        for (iRowIndex = 0; iRowIndex < lstAud.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RPI_Auditing_Insert uspInsert = new usp_tblEQIA_RPI_Auditing_Insert();
                            uspInsert.ReceiveParameter(lstAud[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery();
                            if (iResultInsert <= 0)
                                throw new Exception("������δͨ��ԭ��ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        //����������¼���浽�����־
                        for (iRowIndex = 0; iRowIndex < lstAudLog.Count; iRowIndex++)
                        {
                            usp_tblFW_AuditingLog_Insert uspInsert = new usp_tblFW_AuditingLog_Insert();
                            uspInsert.ReceiveParameter(lstAudLog[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery();
                            if (iResultInsert <= 0)
                                throw new Exception("��������־δͨ��ԭ��ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "�������кţ�" + (lstData[iRowIndex].fldErrorRowIndex) + "������ԭ��ͬһ���ͬһʱ��ͬһ��Ŀ�������Ѿ�����",
                            "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("д�����ݿ�ʧ��", "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIA_RPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                }
            }
        }





















    }
}
