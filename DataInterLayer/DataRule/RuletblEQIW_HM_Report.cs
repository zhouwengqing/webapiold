using System;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  �Ա�[tblEQIW_HM_Report]�����ݲ���
    /// ������      ��  ������
    /// ��������    ��  2016-04-11
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_HM_Report : BaseRule
    { 
        #region ͨ�÷����õ���ҵ���߼�

        /// ��������    ��  �����ۺ�ͳ��
        /// ������      ��  ������
        /// ��������    ��  2016-04-11
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="sTimeType">ʱ������ </param>
        /// <param name="sBeginDate">��ʼ����</param>
        /// <param name="sEndDate">��������</param>
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
        /// <param name="iPara2ID">���ò�����Ĭ��ֵΪ0���������������Ҫ��ʱʹ��</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry="0", int IsPre=0, int IsYear=0, int IsTotal=0, int IsDetail=0,
            int iAppriseID = 0, int iSpaceID=2, short sTatType = 0,int iPara1ID=0,int iPara2ID=0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_Hm_Report_Apprise uspAnalyseData = new usp_tblEQIW_Hm_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_HM_Report", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() );
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��" + e.Message, "RuletblEQIW_HM_Report", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() +  ",sLIStdLevel:" 
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" );
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
        /// <param name="iPara2ID">���ò�����Ĭ��ֵΪ0���������������Ҫ��ʱʹ��</param>
        /// <returns>DataTable</returns>
        public DataTable GetSpaceDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                usp_tblEQIW_Hm_Report_Apprise uspAnalyseData = new usp_tblEQIW_Hm_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_HM_Report", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_HM_Report", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdLevel:"
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetSpaceDataInfo", "sTimeType:" + sTimeType +
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
        /// <param name="BeginDate">��ʼ����</param> 
        /// <param name="EndDate">��������</param>
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="LLevel">�����׼����</param>
        /// <param name="LSDName">�����׼����</param> 
        /// <param name="RLevel">������׼����</param> 
        /// <param name="RSDName">������׼����</param>
        /// <param name="STCode">���д���</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionForUpReport(string sTimeType, string sBeginDate, string sEndDate, string sRSC, string sPoint,
            string sRIStdName, short sRIStdLevel, string sItem, string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0,
            int iAppriseID = 1, int iSpaceID = 2, short sTatType = 0, int iPara1ID = 0, int iPara2ID = 0, string sEBeginDate = "", string sEEndDate = "")
        {
            try
            {
                // usp_tblEQIW_R_Report_DataBaseExprot uspAnalyseData = new usp_tblEQIW_R_Report_DataBaseExprot();
                usp_tblEQIW_Hm_Report_Apprise uspAnalyseData = new usp_tblEQIW_Hm_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_HM_Report", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString()+ ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_HM_Report", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sTatType:" + sTatType.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetShangbao", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString()  + ",cDecCarry:" +
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_HM_Report", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_HM_Report", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_HM_Report", "GetSectionForApprise", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint + ",sRSC:" + sRSC +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" + sLIStdName + ",sLIStdLevel:" +
                                            sLIStdLevel.ToString() + ",sSource:" + sSource.ToString() + ",sJudge:" + sJudge.ToString() + ",cDecCarry:" +
                                            cDecCarry.ToString() + ",sFromHour:" + sFromHour.ToString());
            }
        }
        #endregion
    }
}
