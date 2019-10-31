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
    /// ��������    ��  �Ա�[tblEQIA_RD_Item]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_RD_Item : BaseRule
    {



        /// <summary>
        /// ��������    ��  ���[tblEQIA_RD_Item]������м�¼
        /// ������      ��  ������
        /// ��������    ��  2017-07-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="code">��Ŀ����</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_RD_Item> GetAllListBycode(string code)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_RD_Item_ByCode uspBycode = new usp_tblEQIA_RD_Item_ByCode();
                uspBycode.code = code;
                tblData = uspBycode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_RD_Item> listAll = new List<tblEQIA_RD_Item>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_RD_Item objData = new tblEQIA_RD_Item();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_RD_Item", "GetAllListBycode", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_RD_Item", "GetAllListBycode", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_RD_Item", "GetAllListBycode", "");
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblEQIA_R_Item]���Լ���Ŀ��׼ֵ��¼
        /// ������      ��  ������
        /// ��������    ��  2017-07-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetItemAndSTDDataByItemCode(string itemCode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Item_GetDaySTDValueByItemCode uspByAll = new usp_tblEQIA_R_Item_GetDaySTDValueByItemCode();
                uspByAll.fldItemCode = itemCode;
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_Item";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
        }


        /// <summary>
        /// ��������    ��  ���[tblEQIA_RD_Item]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-06-03
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
                usp_tblEQIA_RD_Item_ByAll uspByAll = new usp_tblEQIA_RD_Item_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_RD_Item";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIA_RD_Item", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIA_RD_Item", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_RD_Item", "GetAllData", "");
            }
        }










    }
}
