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
    /// ��������    ��  �Ա�[tblEQIW_R_Basedata]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_R_Basedata : BaseRule
    {

        //���
        private string eqiType = "eqiw_r";
        private string TypeName = "�ر�ˮ���";





        #region (����)����ϵͳ��GIS��

        /// <summary>
        /// ��������    ��  ��ȡ�����쳣��λ(����û�д������)
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Point_ByExceptionValueForGis()
        {
            try
            {
                usp_getEQIW_R_Point_ByExceptionValueForGis uspDel = new usp_getEQIW_R_Point_ByExceptionValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByExceptionValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByExceptionValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByExceptionValueForGis", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��ȡˮ�Զ������λ
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>  
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Point_ByOutValueForGis()
        {
            try
            {
                usp_getEQIW_R_Point_ByOutValueForGis uspDel = new usp_getEQIW_R_Point_ByOutValueForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByOutValueForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByOutValueForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Point_ByOutValueForGis", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��ȡˮ�Զ����¼��ֵ��������
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>  
        /// <param name="strPcode">������</param>
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Value_ByPointForGis(string strPcode)
        {
            try
            {
                usp_getEQIW_R_Value_ByPointForGis uspDel = new usp_getEQIW_R_Value_ByPointForGis();
                uspDel.fldPcode = strPcode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByPointForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Value_ByPointForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetEQIW_R_Value_ByPointForGis", "");
            }
        }


        /// <summary>
        /// ��������    ��  ��ȡˮ�����е����¼��ֵ��������
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>   
        /// <returns>DataTable </returns>
        public DataTable GetEQIW_R_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIW_R_Value_ByAllForGis uspDel = new usp_getEQIW_R_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetEQIW_R_Value_ByAllForGis", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��ȡ��ǰʱ����ǰ�����Сʱֵ
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-01
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>   
        /// <param name="strSTName">��������</param>
        /// <param name="strRName">��������</param>
        /// <param name="strRSName">��������</param>
        /// <param name="iDay">��ʾ����</param>
        /// <returns>DataTable </returns>
        public DataTable GetWaterHourValue(string strSTName, string strRName, string strRSName, int iDay)
        {
            try
            {
                usp_tblEQIW_R_Basedata_Living_GetWaterHourValue uspDel = new usp_tblEQIW_R_Basedata_Living_GetWaterHourValue();
                uspDel.showSTName = strSTName;
                uspDel.showRName = strRName;
                uspDel.showRSName = strRSName;
                uspDel.showDay = iDay;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strSTName=" + strSTName + " strRName=" + strRName + " strRSName=" + strRSName + " iDay=" + iDay.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strSTName=" + strSTName + " strRName=" + strRName + " strRSName=" + strRSName + " iDay=" + iDay.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strSTName=" + strSTName + " strRName=" + strRName + " strRSName=" + strRSName + " iDay=" + iDay.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ȡ��ˮ���¾�ֵ\�վ�ֵ\�ܾ�ֵ(month,day,week)
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-01
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>   
        /// <param name="strAVGType">����</param>  
        /// <returns>DataTable </returns>
        public DataTable GetDayOrMonthAvgValue(string strAVGType)
        {
            try
            {
                usp_tblEQIW_R_Basedata_Living_GetDayOrMonthAvgValue uspDel = new usp_tblEQIW_R_Basedata_Living_GetDayOrMonthAvgValue();
                uspDel.AVGType = strAVGType;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strAVGType=" + strAVGType);
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strAVGType=" + strAVGType);
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata_Living", "GetWaterHourValue", "strAVGType=" + strAVGType);
            }
        }


        /// <summary>
        /// ��������    ��  ȡ��ˮ���¾�ֵ\�վ�ֵ\�ܾ�ֵ(month,day,week)
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>    
        /// <param name="strtype">����</param>
        /// <param name="STCode">���д���</param>
        /// <param name="RCode">��������</param> 
        /// <param name="RSCode">�������</param> 
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="BeginDate">��ʼ����</param>
        /// <param name="EndDate">��������</param> 
        /// <returns>DataTable </returns>
        public DataTable GetDayOrMonthAvgValue(string strtype, string STCode, string RCode, string RSCode, string ItemCode, string BeginDate, string EndDate)
        {
            try
            {
                usp_tblEQIW_R_Basedata_GetDayOrMonthAvgValue uspDel = new usp_tblEQIW_R_Basedata_GetDayOrMonthAvgValue();
                uspDel.AVGType = strtype;
                uspDel.STCode = STCode;
                uspDel.RCode = RCode;
                uspDel.RSCode = RSCode;
                uspDel.ItemCode = ItemCode;
                uspDel.BeginDate = BeginDate;
                uspDel.EndDate = EndDate;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetDayOrMonthAvgValue", "strtype=" + strtype);
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetDayOrMonthAvgValue", "strtype=" + strtype);
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetDayOrMonthAvgValue", "strtype=" + strtype);
            }
        }





        /// ��������    ��  ��ȡˮ��ʵʱ������ݺ�ˮ��״��
        /// ������      ��  �촺��
        /// ��������    ��  2013-07-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>   
        /// <param name="STCode">���д���</param>
        /// <returns>DataTable </returns>
        public DataTable GetWaterDataAndQuality_Page(string STCode)
        {
            try
            {
                usp_tblEQIW_R_Basedata_WaterQuality_Page uspDel = new usp_tblEQIW_R_Basedata_WaterQuality_Page();
                uspDel.fldSTCode = STCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetWaterDataAndQuality_Page", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetWaterDataAndQuality_Page", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetWaterDataAndQuality_Page", "");
            }
        }

        /// ��������    ��  ��ȡˮ��ʵʱ������ݺ�ˮ��״��
        /// ������      ��  �촺��
        /// ��������    ��  2013-07-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>   
        /// <param name="IDay">��ʾ����</param>
        /// <param name="STCode">���д���</param>
        /// <param name="RSCode">�������</param>
        /// <returns>DataTable </returns>
        public DataTable GetTrendStageOrDensity(string STCode, int IDay, string RSCode)
        {
            try
            {
                usp_tblEQIW_R_Basedata_GetTrendStageOrDensity_Page uspDel = new usp_tblEQIW_R_Basedata_GetTrendStageOrDensity_Page();
                uspDel.fldSTCode = STCode;
                uspDel.IDay = IDay;
                uspDel.fldRScode = RSCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetTrendStageOrDensity", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetTrendStageOrDensity", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIW_R_Basedata", "GetTrendStageOrDensity", "");
            }
        }



        /// <summary>
        /// ��������    ��  ˮϵ����ͳ�Ʊ�[Page]
        /// ������      ��  zch
        /// ��������    ��  2013-09-07
        /// �޸���      ��  
        /// �޸�����    ��  
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="BeginDate">��ʼ����</param>
        /// <param name="DecCarry">С����ȡλ����</param>
        /// <param name="EndDate">��������</param>
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="LLevel">�����׼����</param>
        /// <param name="LSDName">�����׼����</param>
        /// <param name="RCode">��������</param>
        /// <param name="RLevel">������׼����</param>
        /// <param name="RSCode">�������</param>
        /// <param name="RSDName">������׼����</param>
        /// <param name="STCode">���д���</param>
        /// <param name="TimeType">ʱ�����week,month,year��</param>
        /// <returns>DataTable</returns>
        public DataTable GetRiveWaterQuality(string STCode, string SRName, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_R_Report_AppriseStat_Stat_Page uspAnalyseData = new usp_tblEQIW_R_Report_AppriseStat_Stat_Page();
                uspAnalyseData.fldSTcode = STCode;
                uspAnalyseData.BeginDate = BeginDate;
                uspAnalyseData.EndDate = EndDate;
                uspAnalyseData.fldSRName = SRName;
                uspAnalyseData.fldRStandardName = RSDName;
                uspAnalyseData.fldRLevel = RLevel;
                uspAnalyseData.fldLStandardName = LSDName;
                uspAnalyseData.fldLLevel = LLevel;
                uspAnalyseData.fldItemCode = ItemCode;
                DataTable tblData = uspAnalyseData.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetAppriseStat", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetAppriseStat", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetAppriseStat", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }


        /// ��������    ��  ȡ�ø��������ˮ�����[�������棨Page��]
        /// ������      ��  �촺��
        /// ��������    ��  2013-09-06
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="BeginDate">��ʼ����</param> 
        /// <param name="EndDate">��������</param>
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="LLevel">�����׼����</param>
        /// <param name="LSDName">�����׼����</param> 
        /// <param name="RLevel">������׼����</param> 
        /// <param name="RSDName">������׼����</param>
        /// <param name="STCode">���д���</param>
        /// <returns>DataTable</returns>
        public DataTable GetSRSectionWaterQuality(string SRName, string STCode, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_R_Report_DataStat_Page usp = new usp_tblEQIW_R_Report_DataStat_Page();
                usp.fldSTCode = STCode;
                usp.fldSRName = SRName;
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.fldRStandardName = RSDName;
                usp.fldRLevel = RLevel;
                usp.fldLStandardName = LSDName;
                usp.fldLLevel = LLevel;
                usp.fldItemCode = ItemCode;
                DataTable dt = usp.ExecDataTable();
                if (dt != null)
                {
                    return dt;
                }
                else
                    throw new Exception("ȡ��ͳ�Ƽ�¼ʧ��");

            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��" + e.Message, "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Analyse", "GetAllPCodeAnalyseGis", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }


        /// ��������    ��  ȡ�ú���/ˮ��/�ں� �����ˮ�����[������棨Page��]
        /// ������      ��  �촺��
        /// ��������    ��  2013-09-06
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="BeginDate">��ʼ����</param> 
        /// <param name="EndDate">��������</param>
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="LLevel">�����׼����</param>
        /// <param name="LSDName">�����׼����</param> 
        /// <param name="RLevel">������׼����</param> 
        /// <param name="RSDName">������׼����</param>
        /// <param name="STCode">���д���</param>
        /// <returns>DataTable</returns>
        public DataTable GetHKSectionWaterQuality(string SRName, string STCode, string BeginDate, string EndDate,
                                             string RSDName, short RLevel, string LSDName, short LLevel, string ItemCode)
        {
            try
            {
                usp_tblEQIW_L_Report_TLIStat_Page usp = new usp_tblEQIW_L_Report_TLIStat_Page();
                usp.fldSTCode = STCode;
                usp.fldSRName = SRName;
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.fldRStandardName = RSDName;
                usp.fldRLevel = RLevel;
                usp.fldLStandardName = LSDName;
                usp.fldLLevel = LLevel;
                usp.fldItemCode = ItemCode;
                DataTable dt = usp.ExecDataTable();
                if (dt != null)
                {
                    return dt;
                }
                else
                    throw new Exception("ȡ��ͳ�Ƽ�¼ʧ��");

            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Analyse", "GetHKSectionWaterQuality", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��" + e.Message, "RuletblEQIW_R_Analyse", "GetHKSectionWaterQuality", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Analyse", "GetHKSectionWaterQuality", "STCode:" + STCode + "BeginDate:" + BeginDate + "EndDate:" + EndDate);
            }
        }

        #endregion


        #region ͨ�÷����õ���ҵ���߼�

        /// ��������    ��  �����ۺ�ͳ��
        /// ������      ��  ������
        /// ��������    ��  2015-07-13
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="sTimeType">ʱ������ </param>
        /// <param name="sBeginDate">��ʼ����</param>
        /// <param name="sEndDate">��������</param>
        /// <param name="sEBeginDate">�ڶ���ʱ�ο�ʼʱ��</param>
        /// <param name="sEEndDate">�ڶ���ʱ�ν���ʱ��</param>
        /// <param name="sRSC">ˮ��</param>
        /// <param name="sPoint">�������</param>
        /// <param name="sRIStdName">������׼����</param>
        ///  <param name="sRIStdLevel">������׼����</param> 
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="cDecCarry">ƽ��ֵȡֵ����</param>
        /// <param name="IsPre">�Ƿ�ͳ��ǰ������</param>
        /// <param name="IsYear">�Ƿ�ͳ��ͬ������</param>
        /// <param name="IsTotal">�Ƿ�ͳ��ƽ��ֵ</param>
        /// <param name="IsDetail">�Ƿ�ͳ����ϸ</param>
        /// <param name="iAppriseID">0:��Ե����������ۡ�1����Կռ�����</param>
        /// <param name="iSpaceID">0:����-fldWaterArea��1:ˮϵ-fldRSWaterWork��2������-fldRCode </param>
        /// <param name="sTatType">���ò�����Ĭ��ֵΪ0���������������Ҫ��ʱʹ��</param>
        /// <param name="iPara1ID">������ֵ����0:Ĭ��ֵ����������1����������ǰ4λ����</param>
        /// <param name="iPara2ID">����������Ϣ��0��Ĭ�����ԡ�1������������Ϣ��2��������Ŀ��Ϣ</param>
        /// <param name="iSource">��������</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 0, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_R_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                //uspAnalyseData.EBeginDate = sEBeginDate;
                //uspAnalyseData.EEndDate = sEEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.Source = iSource;

                uspAnalyseData.EBeginDate = sEBeginDate == null ? "" : sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate;


                DataTable tblData = uspAnalyseData.ExecDataTable(3); //����ͨ�ñ�������
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��" + e.Message, "RuletblEQIW_R_Basedata", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:");
            }
        }
        /// ��������    ��  ������ˮϵ��������ۺ�ͳ��
        /// ������      ��  ������
        /// ��������    ��  2015-07-13
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="sTimeType">ʱ������ </param>
        /// <param name="sBeginDate">��ʼ����</param>
        /// <param name="sEndDate">��������</param>
        /// <param name="sEBeginDate">�ڶ���ʱ�ο�ʼʱ��</param>
        /// <param name="sEEndDate">�ڶ���ʱ�ν���ʱ��</param>
        /// <param name="sRSC">ˮ��</param>
        /// <param name="sPoint">�������</param>
        /// <param name="sRIStdName">������׼����</param>
        ///  <param name="sRIStdLevel">������׼����</param> 
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="cDecCarry">ƽ��ֵȡֵ����</param>
        /// <param name="IsPre">�Ƿ�ͳ��ǰ������</param>
        /// <param name="IsYear">�Ƿ�ͳ��ͬ������</param>
        /// <param name="IsTotal">�Ƿ�ͳ��ƽ��ֵ</param>
        /// <param name="IsDetail">�Ƿ�ͳ����ϸ</param>
        /// <param name="iAppriseID">0:��Ե����������ۡ�1����Կռ�����</param>
        /// <param name="iSpaceID">0:����-fldWaterArea��1:ˮϵ-fldRSWaterWork��2������-fldRCode </param>
        /// <param name="sTatType">���ò�����Ĭ��ֵΪ0���������������Ҫ��ʱʹ��</param>
        /// <param name="iPara1ID">������ֵ����0:Ĭ��ֵ����������1����������ǰ4λ����</param>
        /// <param name="iPara2ID">����������Ϣ��0��Ĭ�����ԡ�1������������Ϣ��2��������Ŀ��Ϣ</param>
        /// <param name="iSource">��������</param>
        /// <returns>DataTable</returns>
        public DataTable GetSpaceDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_R_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                //uspAnalyseData.EBeginDate = sEBeginDate;
                //uspAnalyseData.EEndDate = sEEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.Source = iSource;

                uspAnalyseData.EBeginDate = sEBeginDate == null ? "" : sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //����ͨ�ñ�������
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:");
            }
        }

        /// ��������    ��  �����ϱ���Ϣ
        /// ������      ��  du
        /// ��������    ��  2015-05-14
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="sTimeType">ʱ������ </param>
        /// <param name="sBeginDate">��ʼ����</param>
        /// <param name="sEndDate">��������</param>
        /// <param name="sEBeginDate">�ڶ���ʱ�ο�ʼʱ��</param>
        /// <param name="sEEndDate">�ڶ���ʱ�ν���ʱ��</param>
        /// <param name="sRSC">ˮ��</param>
        /// <param name="sPoint">�������</param>
        /// <param name="sRIStdName">������׼����</param>
        ///  <param name="sRIStdLevel">������׼����</param> 
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="cDecCarry">ƽ��ֵȡֵ����</param>
        /// <param name="IsPre">�Ƿ�ͳ��ǰ������</param>
        /// <param name="IsYear">�Ƿ�ͳ��ͬ������</param>
        /// <param name="IsTotal">�Ƿ�ͳ��ƽ��ֵ</param>
        /// <param name="IsDetail">�Ƿ�ͳ����ϸ</param>
        /// <param name="iAppriseID">0:��Ե����������ۡ�1����Կռ�����</param>
        /// <param name="iSpaceID">0:����-fldWaterArea��1:ˮϵ-fldRSWaterWork��2������-fldRCode </param>
        /// <param name="sTatType">���ò�����Ĭ��ֵΪ0���������������Ҫ��ʱʹ��</param>
        /// <param name="iPara1ID">������ֵ����0:Ĭ��ֵ����������1����������ǰ4λ����</param>
        /// <param name="iPara2ID">����������Ϣ��0��Ĭ�����ԡ�1������������Ϣ��2��������Ŀ��Ϣ</param>
        /// <param name="iSource">��������</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionForUpReport(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, int iSource = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                // usp_tblEQIW_R_Report_DataBaseExprot uspAnalyseData = new usp_tblEQIW_R_Report_DataBaseExprot();
                usp_tblEQIW_R_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.EBeginDate = sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.STatType = sTatType;

                uspAnalyseData.Para1ID = iPara1ID;
                uspAnalyseData.Para2ID = iPara2ID;
                uspAnalyseData.Source = iSource;
                uspAnalyseData.EBeginDate = sEBeginDate == null ? "" : sEBeginDate;
                uspAnalyseData.EEndDate = sEEndDate == null ? "" : sEEndDate;
                DataTable tblData = uspAnalyseData.ExecDataTable(3); //����ͨ�ñ�������
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
        }


        /// ��������    ��  �����Ϣ
        /// ������      ��  du
        /// ��������    ��  2015-05-14
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="BeginDate">��ʼ����</param> 
        /// <param name="EndDate">��������</param>
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="LLevel">�����׼����</param>
        /// <param name="LSDName">�����׼����</param> 
        /// <param name="RLevel">������׼����</param> 
        /// <param name="RSDName">������׼����</param>
        /// <param name="STCode">���д���</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionForApprise(string sTimeType, string sBeginDate, string sEndDate, string sRSC, short sSource, short sJudge, string sPoint,
            string sRIStdName, short sRIStdLevel, string sLIStdName, short sLIStdLevel, string sItem, string cDecCarry, short sFromHour, string sTatName, short sTatType, short sReportFlag)
        {
            try
            {
                usp_tblEQIW_R_Report_DataApprise uspAnalyseData = new usp_tblEQIW_R_Report_DataApprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldRSC = sRSC;
                uspAnalyseData.fldSource = sSource;
                uspAnalyseData.fldJudge = sJudge;
                uspAnalyseData.fldRSCode = sPoint;
                uspAnalyseData.fldRStandardName = sRIStdName;
                uspAnalyseData.fldRLevel = sRIStdLevel;
                uspAnalyseData.fldLStandardName = sLIStdName;
                uspAnalyseData.fldLLevel = sLIStdLevel;
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.fldFromHour = sFromHour;
                uspAnalyseData.STatName = sTatName;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.ReportFlag = sReportFlag;
                DataTable tblData = uspAnalyseData.ExecDataTable(3);//����ͨ�ñ������
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Basedata", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }
        #endregion










        /// <summary>
        /// ��������    ��  �������[tblEQIW_R_Basedata]��ļ�¼
        /// ������      ��  �ź�
        /// ��������    ��  2009-12-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="lstData">Ҫ��ӵ�tblEQIW_R_Basedata��ʵ������</param>
        /// <param name="lstCurrentData">��Ҫ���µı����е�ʵ��������</param>
        /// <param name="lstJuniorData">��Ҫ���µ��¼����е�ʵ��������</param>
        /// <param name="lstAud">���δͨ��ԭ���ʵ��������</param>
        /// <param name="new_CityID_Operate">���º�Ĳ�������ID</param>
        /// <param name="new_CityID_Submit">���º���ύ����ID</param>
        /// <returns>�����Ƿ�ɹ�</returns>
        public bool InsertAllOrUpdateNoPassAll(List<tblEQIW_R_Basedata> lstData, List<tblEQIW_R_Basedata_Pre> lstCurrentData, List<tblEQIW_R_Basedata_Pre> lstJuniorData, List<tblEQIW_R_Auditing> lstAud, List<tblFW_AuditingLog> lstAudLog, string new_CityID_Operate, string new_CityID_Submit, int grade, string comment, string operID2, string submit2, string flag2)
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
                            usp_tblEQIW_R_Basedata_Pre_UpdateCity uspUpdate1 = new usp_tblEQIW_R_Basedata_Pre_UpdateCity();
                            uspUpdate1.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                            uspUpdate1.new_fldFlag = Int16.Parse(flag2.Split(',')[iRowIndex].ToString());
                            uspUpdate1.new_fldCityID_Operate = Int32.Parse(operID2.Split(',')[iRowIndex].ToString());
                            uspUpdate1.new_fldCityID_Submit = submit2.Split(',')[iRowIndex];
                            uspUpdate1.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                            int iResultInsert1 = uspUpdate1.ExecNoQuery(conn, tran);
                            if (iResultInsert1 <= 0)
                                throw new Exception("�޸ļ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");

                            date = lstCurrentData[iRowIndex].fldYear.ToString() + lstCurrentData[iRowIndex].fldMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstCurrentData[iRowIndex].fldYear;
                                usp_upin.fldMonth = lstCurrentData[iRowIndex].fldMonth;
                                usp_upin.fldDay = lstCurrentData[iRowIndex].fldDay;
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
                                usp_tblEQIW_R_Basedata_Insert uspInsert = new usp_tblEQIW_R_Basedata_Insert();
                                uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("��Ӽ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                            }
                            //}
                            usp_tblEQIW_R_Basedata_Pre_Delete usp_pre_Delete = new usp_tblEQIW_R_Basedata_Pre_Delete();
                            usp_pre_Delete.fldAutoID = lstData[iRowIndex].fldAutoID;
                            int iResultdelete = usp_pre_Delete.ExecNoQuery(conn, tran);
                            if (iResultdelete <= 0)
                                throw new Exception("ɾ����ʱ���¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");

                            date = lstData[iRowIndex].fldYear.ToString() + lstData[iRowIndex].fldMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstData[iRowIndex].fldYear;
                                usp_upin.fldMonth = lstData[iRowIndex].fldMonth;
                                usp_upin.fldDay = lstData[iRowIndex].fldDay;
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
                        //    usp_tblEQIW_R_Basedata_Pre_UpdateFlag uspUpdate = new usp_tblEQIW_R_Basedata_Pre_UpdateFlag();
                        //    uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                        //    uspUpdate.new_fldFlag = 12;
                        //    uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                        //    int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                        //    //if (iResultInsert <= 0)
                        //    //    throw new Exception("�޸ļ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        //}
                        //���ݸ�Ϊ�¼��������δͨ��״̬
                        for (iRowIndex = 0; iRowIndex < lstJuniorData.Count; iRowIndex++)
                        {
                            usp_tblEQIW_R_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIW_R_Basedata_Pre_UpdateCity();
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
                            usp_tblEQIW_R_Auditing_Insert uspInsert = new usp_tblEQIW_R_Auditing_Insert();
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
                        throw new InsertException("�����ݿ�����ʧ��", "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "�������кţ�" + (lstData[iRowIndex].fldErrorRowIndex) + "������ԭ��ͬһ���ͬһʱ��ͬһ��Ŀ�������Ѿ�����",
                            "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("ִ��Sql���ʧ��", "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("д�����ݿ�ʧ��", "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIW_R_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate��" + new_CityID_Operate.ToString() + ",new_CityID_Submit��" + new_CityID_Submit);
                    }
                }
            }
        }



        /// <summary>
        /// ���������������ʷ����
        /// ����  �ˣ�������
        /// ����ʱ�䣺2018/08/14
        /// </summary>
        /// <param name="fldSTName"></param>
        /// <param name="fldRName"></param>
        /// <param name="fldRSNmae"></param>
        /// <param name="time"></param>
        /// <param name="itemname"></param>
        /// <returns></returns>
        public DataTable GetHistory(string fldSTName, string fldRName, string fldRSNmae, string time, string itemname)
        {
            DataTable dt = new DataTable();
            try {
                usp_GetHistoryData usp = new usp_GetHistoryData();
                usp.fldSTName = fldSTName;
                usp.fldRName = fldRName;
                usp.fldRSName = fldRSNmae;
                usp.fldTime =time;
                usp.fldItemCode = itemname;
                dt=usp.ExecDataTable();
                return dt;
            }
            catch (DBQueryException e) {
                return dt;
            }
        }


    }
}
