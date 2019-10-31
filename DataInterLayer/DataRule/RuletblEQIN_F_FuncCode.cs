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
    /// ��������    ��  �Ա�[tblEQIN_F_FuncCode]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIN_F_FuncCode : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblEQIN_F_FuncCode]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-08-10
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllData()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_F_FuncCode_ByAll uspByAll = new usp_tblEQIN_F_FuncCode_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIN_F_FuncCode";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIN_F_FuncCode", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIN_F_FuncCode", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIN_F_FuncCode", "GetAllData", "");
            }
        }
    }
}
