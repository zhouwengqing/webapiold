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
    /// ��������    ��  �Ա�[tblEQIS_W_BaseData_Living]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIS_W_BaseData_Living : BaseRule
    { 

        /// <summary>
        /// ��������    ��  ��ȡˮ�����е����¼��ֵ��������
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>   
        /// <returns>DataTable </returns>
        public DataTable GetEQIS_W_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIS_W_Value_ByAllForGis uspDel = new usp_getEQIS_W_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIS_W_BaseData_Living", "GetEQIS_W_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIS_W_BaseData_Living", "GetEQIS_W_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIS_W_BaseData_Living", "GetEQIS_W_Value_ByAllForGis", "");
            }
        }
    }
}
