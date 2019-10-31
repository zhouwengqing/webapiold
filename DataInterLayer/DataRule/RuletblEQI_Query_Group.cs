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
    /// ��������    ��  �Ա�[tblEQI_Query_Group]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQI_Query_Group : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblEQI_Query_Group]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-05-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objInsert">��Ҫ��ӵ�ʵ����</param>
        /// <returns>����������¼��PK������ֵ</returns>
        public int Insert(tblEQI_Query_Group objInsert)
        {
            try
            {
                usp_tblEQI_Query_Group_Insert uspInsert = new usp_tblEQI_Query_Group_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("�����¼�¼ʧ��");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("�����ݿ�����ʧ��", "RuletblEQI_Query_Group", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblEQI_Query_Group", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("ִ��Sql���ʧ��", "RuletblEQI_Query_Group", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblEQI_Query_Group", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ɾ��[tblEQI_Query_Group]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-05-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">��Ҫɾ���ļ�¼��PK����ֵ</param>
        /// <returns>true / false</returns>
        public bool Delete(int iPK)
        {
            try
            {
                usp_tblEQI_Query_Group_Delete uspDelete = new usp_tblEQI_Query_Group_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("ɾ����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("�����ݿ�����ʧ��", "RuletblEQI_Query_Group", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("ִ��Sql���ʧ��", "RuletblEQI_Query_Group", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblEQI_Query_Group", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ����[tblEQI_Query_Group]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-05-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objUpdate_old">��Ҫ���µ�ʵ����</param>
        /// <param name="objUpdate_new">���º��ʵ����</param>
        /// <returns>true / false</returns>
        public bool Update(tblEQI_Query_Group objUpdate_old, tblEQI_Query_Group objUpdate_new)
        {
            try
            {
                usp_tblEQI_Query_Group_Update uspUpdate = new usp_tblEQI_Query_Group_Update();
                uspUpdate.ReceiveParameter_Old(objUpdate_old);
                uspUpdate.ReceiveParameter_New(objUpdate_new);
                int iResult = uspUpdate.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("���¼�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQI_Query_Group", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQI_Query_Group", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQI_Query_Group", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblEQI_Query_Group]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-05-28
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
                usp_tblEQI_Query_Group_ByAll uspByAll = new usp_tblEQI_Query_Group_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQI_Query_Group";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQI_Query_Group", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQI_Query_Group", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQI_Query_Group", "GetAllData", "");
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblEQI_Query_Group]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-05-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>IList<tblEQI_Query_Group></returns>
        public IList<tblEQI_Query_Group> GetAllList()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQI_Query_Group_ByAll uspByAll = new usp_tblEQI_Query_Group_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQI_Query_Group> listAll = new List<tblEQI_Query_Group>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQI_Query_Group objData = new tblEQI_Query_Group();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_Query_Group", "GetAllList", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_Query_Group", "GetAllList", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Query_Group", "GetAllList", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��������ȡ��[tblEQI_Query_Group]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-05-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">PK����ֵ</param>
        /// <returns>tblEQI_Query_Group</returns>
        public tblEQI_Query_Group ByPK(int iPK)
        {
            try
            {
                usp_tblEQI_Query_Group_ByPK uspByPK = new usp_tblEQI_Query_Group_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblEQI_Query_Group objData = new tblEQI_Query_Group();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQI_Query_Group", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQI_Query_Group", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQI_Query_Group", "ByPK", iPK.ToString());
            }
        }




        /// <summary>
        /// ��������    ��  �����û�����ģ������ȡ��[tblEQI_Query_Group]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2010-05-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">PK����ֵ</param>
        /// <returns>tblEQI_Query_Group</returns> 
        public IList<tblEQI_Query_Group> GetByUserIDandObject(int UserID, string Object)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQI_Query_Group_ByUserIDandObject uspByUserIDandObject = new usp_tblEQI_Query_Group_ByUserIDandObject();
                uspByUserIDandObject.fldUserID = UserID;
                uspByUserIDandObject.fldObject = Object;
                tblData = uspByUserIDandObject.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQI_Query_Group> listAll = new List<tblEQI_Query_Group>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQI_Query_Group objData = new tblEQI_Query_Group();
                        objData.MetaDataTable = tblTmp;
                        listAll.Add(objData);
                    }
                    tblData.Dispose();
                    return listAll;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_Query_Group", "GetByUserIDandObject", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_Query_Group", "GetByUserIDandObject", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Query_Group", "GetByUserIDandObject", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
        }
    }
}
