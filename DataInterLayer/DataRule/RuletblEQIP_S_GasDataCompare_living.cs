using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  �Ա�[tblEQIP_S_GasDataCompare_living]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIP_S_GasDataCompare_living : BaseRule
    {  

        /// <summary>
        /// ��������    ��  ȡ�����в�����ļ��ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-16
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIP_S_Value_ByAllForGis(string strType)
        {
            try
            {
                usp_getEQIP_S_Value_ByAllForGis uspDel = new usp_getEQIP_S_Value_ByAllForGis();
                uspDel.fldType = strType;
                DataTable dt = uspDel.ExecDataTable(2);
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIP_S_GasDataCompare_living", "GetEQIP_S_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIP_S_GasDataCompare_living", "GetEQIP_S_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIP_S_GasDataCompare_living", "GetEQIP_S_Value_ByAllForGis", "");
            }
        }
    }
}
