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
    /// ��������    ��  �Ա�[tblEQIS_W_Item]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIS_W_Item : BaseRule
    {



        /// <summary>
        /// ��������    ��  ���[tblEQIS_W_Item]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-10-09
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
                usp_tblEQIS_W_Item_ByAll uspByAll = new usp_tblEQIS_W_Item_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIS_W_Item";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIS_W_Item", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIS_W_Item", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIS_W_Item", "GetAllData", "");
            }
        }














    }
}
