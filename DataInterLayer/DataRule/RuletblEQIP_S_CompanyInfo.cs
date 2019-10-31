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

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  �Ա�[tblEQIP_S_CompanyInfo]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIP_S_CompanyInfo : BaseRule
    {  
        /// <summary>
        /// ��������    ��  ȡ�õ�����ҵ��GIS��Ϣ
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>  
        /// <returns>DataTable</returns>
        public DataTable GetCompanyInfoForGis(string sType)
        {
            try
            {
                usp_tblEQIP_S_WaterCompanyInfo_forGis GetCompany = new usp_tblEQIP_S_WaterCompanyInfo_forGis();
                GetCompany.EType = sType;
                DataTable tblData = GetCompany.ExecDataTable(2);
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIP_S_CompanyInfo", "GetCompanyInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIP_S_CompanyInfo", "GetCompanyInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIP_S_CompanyInfo", "GetCompanyInfoForGis", "");
            }
        }
    }
}
