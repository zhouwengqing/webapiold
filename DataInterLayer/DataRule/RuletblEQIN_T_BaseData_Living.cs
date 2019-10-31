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
    /// ��������    ��  �Ա�[tblEQIN_T_BaseData_Living]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIN_T_BaseData_Living : BaseRule
    { 

        /// <summary>
        /// ��������    ��  ȡ�����в�����ļ��ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIN_T_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIN_T_Value_ByAllForGis uspDel = new usp_getEQIN_T_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIN_T_BaseData_Living", "GetEQIN_T_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIN_T_BaseData_Living", "GetEQIN_T_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIN_T_BaseData_Living", "GetEQIN_T_Value_ByAllForGis", "");
            }
        }
    }
}
