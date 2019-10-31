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
    public class RuletblEQIA_P_Report : BaseRule
    {
        /// ��������    ��  ԭʼ���ݱ�
        /// ������      ��  ����
        /// ��������    ��  2015-09-06
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="sTimeType">ʱ������ </param>
        /// <param name="sBeginDate">��ʼ����</param>
        /// <param name="sEndDate">��������</param>
        /// <param name="sPoint">�������б�</param>
        /// <param name="pHStand">��׼ֵ</param>
        /// <param name="ItemCode">��Ŀ����</param>
        /// <param name="cDecCarry">ƽ��ֵȡֵ����</param>
        /// <param name="IsPre">�Ƿ�ͳ��ǰ������</param>
        /// <param name="IsYear">�Ƿ�ͳ��ͬ������</param>
        /// <param name="IsTotal">�Ƿ�ͳ��ƽ��ֵ</param>
        /// <param name="IsDetail">�Ƿ�ͳ����ϸ</param>     
        /// <param name="iAppriseID">0:��Ե�����λ���ۡ�1����Գ������ۡ�2�����С���㶼���� </param>
        /// <param name="sTatType">���ò�����Ĭ��ֵΪ0���������������Ҫ��ʱʹ��</param>
        /// <param name="iSpaceID">0�����ս�������ͳ�ƣ�1��������������������ͳ��</param>
        ///  <param name="iCalculateID">ȫʡ�����ʼ��㷽����0���о�ֵ��1����������Խ�ˮ����</param>
        /// <returns>DataTable</returns>
        public DataTable GetSTatTypeDataInfo(string sTimeType, string sBeginDate, string sEndDate, string sPoint, string sItem, string pHStand="5.6",
             string cDecCarry = "0", int IsPre = 0, int IsYear = 0, int IsTotal = 0, int IsDetail = 0, int iAppriseID = 0, short sTatType = 0, int iSpaceID = 0,int iCalculateID=0)
        {
            try
            {
                usp_tblEQIA_P_Report_AppriseStat uspAnalyseData = new usp_tblEQIA_P_Report_AppriseStat();
                uspAnalyseData.TimeType = sTimeType;
                uspAnalyseData.BeginDate = sBeginDate;
                uspAnalyseData.EndDate = sEndDate;
                uspAnalyseData.fldPCode = sPoint;
                uspAnalyseData.pHStand = decimal.Parse(pHStand);
                uspAnalyseData.fldItemCode = sItem;
                uspAnalyseData.DecCarry = cDecCarry;
                uspAnalyseData.IsPre = IsPre;
                uspAnalyseData.IsYear = IsYear;
                uspAnalyseData.IsTotal = IsTotal;
                uspAnalyseData.IsDetail = IsDetail;
                uspAnalyseData.AppriseID = iAppriseID;
                uspAnalyseData.STatType = sTatType;
                uspAnalyseData.SpaceID = iSpaceID;
                uspAnalyseData.CalculateID = iCalculateID;

                DataTable tblData = uspAnalyseData.ExecDataTable(3); //����ͨ�ñ�������
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��" + e.Message, "RuletblEQIA_R_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Basedata", "GetLSectionDataInfo", "sTimeType:" + sTimeType +
                                            ",sBeginDate:" + sBeginDate + ",sEndDate:" + sEndDate + ",sItem:" + sItem + ",sPoint:" + sPoint);
            }
        }
    }
}
