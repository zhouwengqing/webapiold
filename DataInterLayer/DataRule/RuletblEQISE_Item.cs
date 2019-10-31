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
    /// ��������    ��  �Ա�[tblEQISE_Item]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQISE_Item : BaseRule
    {
      

        /// <summary>
        /// ��������    ��  ���[tblEQISE_Item]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-01-15
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
                usp_tblEQISE_Item_ByAll uspByAll = new usp_tblEQISE_Item_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQISE_Item";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQISE_Item", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQISE_Item", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQISE_Item", "GetAllData", "");
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblEQISE_Item]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-01-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>IList<tblEQISE_Item></returns>
        public IList<tblEQISE_Item> GetAllList()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQISE_Item_ByAll uspByAll = new usp_tblEQISE_Item_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQISE_Item> listAll = new List<tblEQISE_Item>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQISE_Item objData = new tblEQISE_Item();
                        objData.MetaDataTable = tblTmp;
                        listAll.Add(objData);
                    }
                    return listAll;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQISE_Item", "GetAllList", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQISE_Item", "GetAllList", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQISE_Item", "GetAllList", "");
            }
        }

     
    }
}
