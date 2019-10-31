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
    /// ��������    ��  �Ա�[tblEQIS_DZ_Point]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2015-03-30
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIS_DZ_Point : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���ݵ�ǰ��ݻ�ó�����������������ļ�¼��GISʹ��
        /// ������      ��  du
        /// ��������    ��  2015-03-30
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForGis()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIS_DZ_Point_ForGis uspGetAll = new usp_tblEQIS_DZ_Point_ForGis();
                tblData = uspGetAll.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIS_DZ_Point", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIS_DZ_Point", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIS_DZ_Point", "GetPointInfoForGis", "");
            }
        }

    }
}
