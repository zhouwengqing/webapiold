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
    /// ��������    ��  �Ա�[RuletblEQIW_R_Auto_Basedata]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_R_Auto_Basedata : BaseRule
    {
     
        #region ͨ�÷����õ���ҵ���߼�

        /// ��������    ��  ˮ���Զ��ۺ�ͳ��
        /// ������      ��  ������
        /// ��������    ��  2016-05-21
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="sTimeType">ʱ������ </param>
        /// <param name="sBeginDate">��ʼ����</param>
        /// <param name="sEndDate">��������</param>
        /// <param name="iHour">Сʱ</param>
        /// <param name="sRIStdName">������׼����</param>
        ///  <param name="sRIStdLevel">������׼����</param> 
        /// <param name="cDecCarry">ƽ��ֵȡֵ����</param>
        /// <param name="iPara1ID">������ֵ����0:Ĭ��ֵ����������1����������ǰ4λ����</param>
        /// <returns>DataTable</returns>
        public DataTable GetSectionAutoDataInfo(string sTimeType, string sBeginDate, string sEndDate, int iHour, 
            string sRIStdName, short sRIStdLevel, string cDecCarry="0",int iPara1ID=0)
        {
            try
            {
                usp_tblEQIW_R_Auto_Report_Apprise uspAnalyseData = new usp_tblEQIW_R_Auto_Report_Apprise();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.intHour = iHour;
                uspAnalyseData.fldStandardName = sRIStdName;
                uspAnalyseData.fldLevel = sRIStdLevel;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.Para1ID = iPara1ID;
                DataTable tblData = uspAnalyseData.ExecDataTable(3); //����ͨ�ñ�������
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Auto_Basedata", "GetSectionAutoDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",intHour:" + iHour.ToString() +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() );
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��"+ e.Message, "RuletblEQIW_R_Auto_Basedata", "GetSectionAutoDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",intHour:" + iHour.ToString() +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() +  ",sLIStdLevel:" 
                                           );
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Auto_Basedata", "GetSectionAutoDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",intHour:" + iHour.ToString() +
                                            ",sRIStdName:" + sRIStdName + ",sRIStdLevel:" + sRIStdLevel.ToString() + ",sLIStdName:" );
            }
        }
    
        #endregion
    }
}
