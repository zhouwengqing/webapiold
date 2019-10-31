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
    /// ��������    ��  �Ա�[tblFW_User]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblFW_User : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblFW_User]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-03-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objInsert">��Ҫ��ӵ�ʵ����</param>
        /// <returns>����������¼��PK������ֵ</returns>
        public int Insert(tblFW_User objInsert)
        {
            try
            {
                usp_tblFW_User_Insert uspInsert = new usp_tblFW_User_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("�����¼�¼ʧ��");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("�����ݿ�����ʧ��", "RuletblFW_User", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblFW_User", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("ִ��Sql���ʧ��", "RuletblFW_User", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblFW_User", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ɾ��[tblFW_User]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-03-27
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
                usp_tblFW_User_Delete uspDelete = new usp_tblFW_User_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("ɾ����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("�����ݿ�����ʧ��", "RuletblFW_User", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("ִ��Sql���ʧ��", "RuletblFW_User", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblFW_User", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ����[tblFW_User]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objUpdate_old">��Ҫ���µ�ʵ����</param>
        /// <param name="objUpdate_new">���º��ʵ����</param>
        /// <returns>true / false</returns>
        public bool Update(tblFW_User objUpdate_old, tblFW_User objUpdate_new)
        {
            try
            {
                usp_tblFW_User_Update uspUpdate = new usp_tblFW_User_Update();
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
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblFW_User", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblFW_User", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblFW_User", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ����[tblFW_User]�������
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-08
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objUpdate">��Ҫ���µ�ʵ����</param>
        /// <returns>true / false</returns>
        public bool UpdatePassword(tblFW_User objUpdate)
        {
            try
            {
                usp_tblFW_User_UpdatePassword uspUpdate = new usp_tblFW_User_UpdatePassword();
                uspUpdate.ReceiveParameter(objUpdate);
                int iResult = uspUpdate.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("���¼�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblFW_User", "UpdatePassword", objUpdate.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblFW_User", "UpdatePassword", objUpdate.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblFW_User", "UpdatePassword", objUpdate.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblFW_User]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-03-27
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
                usp_tblFW_User_ByAll uspByAll = new usp_tblFW_User_ByAll();
                tblData = uspByAll.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblFW_User";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblFW_User", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblFW_User", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblFW_User", "GetAllData", "");
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblFW_User]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-03-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>IList<tblFW_User></returns>
        public IList<tblFW_User> GetAllList()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_User_ByAll uspByAll = new usp_tblFW_User_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblFW_User> listAll = new List<tblFW_User>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblFW_User objData = new tblFW_User();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblFW_User", "GetAllList", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblFW_User", "GetAllList", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_User", "GetAllList", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��������ȡ��[tblFW_User]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-03-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">PK����ֵ</param>
        /// <returns>tblFW_User</returns>
        public tblFW_User ByPK(int iPK)
        {
            try
            {
                usp_tblFW_User_ByPK uspByPK = new usp_tblFW_User_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblFW_User objData = new tblFW_User();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblFW_User", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblFW_User", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_User", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  �����û���ȡ��[tblFW_User]��ļ�¼
        /// ������      ��  ������
        /// ��������    ��  2009-03-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sUserName">�û���</param>
        /// <param name="stcode">���д���</param>
        /// <returns>tblFW_User</returns>
        public tblFW_User ByUserName(string sUserName, string stcode)
        {
            try
            {
                usp_tblFW_User_ByUserName uspByUserName = new usp_tblFW_User_ByUserName();
                uspByUserName.fldUserName = sUserName;
                uspByUserName.fldSTCode = stcode;
                DataTable tblData = uspByUserName.ExecDataTable(1);
                if (tblData != null)
                {
                    tblFW_User objData = new tblFW_User();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblFW_User", "ByUserName", sUserName);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblFW_User", "ByUserName", sUserName);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_User", "ByUserName", sUserName);
            }
        }

        /// <summary>
        /// ��������    ��  �����û����͹ؼ��ּ���Ƿ�ӵ�в���Ȩ��
        /// ������      ��  ������
        /// ��������    ��  2009-04-09
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iUserPK">�û�PK</param>
        /// <param name="sKeyword">Ȩ�޹ؼ���</param>
        /// <returns>Ȩ�޶�Ӧ��ҳ�漶��ID,���û��Ȩ����Ϊ0</returns>
        public int CheckKeyword(int iUserPK, string sKeyword)
        {
            try
            {
                usp_tblFW_User_CheckRight uspCheckRight = new usp_tblFW_User_CheckRight();
                uspCheckRight.UserAutoID = iUserPK;
                uspCheckRight.RightKeyword = sKeyword;
                object objResult = uspCheckRight.ExecScalar();
                return Convert.ToInt32(objResult == null || objResult.ToString().Trim()=="" ? "0" : objResult);
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblFW_User", "CheckKeyword", "iUserPK��" + iUserPK + "��sKeyword��" + sKeyword);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblFW_User", "CheckKeyword", "iUserPK��" + iUserPK + "��sKeyword��" + sKeyword);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_User", "CheckKeyword", "iUserPK��" + iUserPK + "��sKeyword��" + sKeyword);
            }
        }

        /// <summary>
        /// ��������    ��  ����û�ӵ�е�Ȩ�޵�fldAutoID
        /// ������      ��  ������
        /// ��������    ��  2009-04-09
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iUserPK">�û�PK</param>
        /// <returns>IList</returns>
        public IList<int> GetAllRightID(int iUserPK)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_User_AllRight uspAllRight = new usp_tblFW_User_AllRight();
                uspAllRight.UserAutoID = iUserPK;
                tblData = uspAllRight.ExecDataTable();
                if (tblData != null)
                {
                    IList<int> listAll = new List<int>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        listAll.Add(Convert.ToInt32(tblData.Rows[i]["fldRightSetID"].ToString()));
                    }
                    return listAll;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblFW_User", "GetAllRightID", "iUserPK��" + iUserPK);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblFW_User", "GetAllRightID", "iUserPK��" + iUserPK);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_User", "GetAllRightID", "iUserPK��" + iUserPK);
            }
        }

        /// <summary>
        /// ��������    ��  ����û�ӵ�е����ݿ���fldAutoID
        /// ������      ��  ������
        /// ��������    ��  2009-04-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iUserPK">�û�PK</param>
        /// <returns>IList<int></returns>
        public IList<int> GetAllMaintenanceID(int iUserPK)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_User_AllMaintenance uspAllMaintenance = new usp_tblFW_User_AllMaintenance();
                uspAllMaintenance.UserAutoID = iUserPK;
                tblData = uspAllMaintenance.ExecDataTable();
                if (tblData != null)
                {
                    IList<int> listAll = new List<int>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        if (tblData.Rows[i]["fldMaintenanceID"].ToString() == "") continue;
                        listAll.Add(Convert.ToInt32(tblData.Rows[i]["fldMaintenanceID"].ToString()));
                    }
                    return listAll;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblFW_User", "GetAllMaintenanceID", "iUserPK��" + iUserPK);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblFW_User", "GetAllMaintenanceID", "iUserPK��" + iUserPK);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_User", "GetAllMaintenanceID", "iUserPK��" + iUserPK);
            }
        }

        /// <summary>
        /// ��������    ��  ͬʱɾ��[tblFW_User]��Ķ�����¼
        /// ������      ��  �ź�
        /// ��������    ��  2009-04-09
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="arrPK">Ҫɾ�����û�ID�б�</param>
        /// <returns></returns>
        public bool DeleteMany(List<int> arrPK)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < arrPK.Count; i++)
                        {
                            usp_tblFW_User_Delete uspDelete = new usp_tblFW_User_Delete();
                            uspDelete.fldAutoID = arrPK[i];
                            int iResult = uspDelete.ExecNoQuery(conn, tran);
                            if (iResult <= 0)
                                throw new Exception("ɾ����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new DeleteException("�����ݿ�����ʧ��", "RuletblFW_User", "DeleteMany", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new DeleteException("ִ��Sql���ʧ��", "RuletblFW_User", "DeleteMany", "");
                    }
                    catch (DBException e)
                    {
                        throw new DeleteException("ִ��Sql���ʧ��", "RuletblFW_User", "DeleteMany", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new DeleteException(e.Message, "RuletblFW_User", "DeleteMany", "");
                    }
                }
            }
        }

        /// <summary>
        /// ��������    ��  ��ѡ�е��û�������״̬��Ϊ��
        /// ������      ��  �ź�
        /// ��������    ��  2009-04-14
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="arrPK">Ҫͣ�õ��û�ID�б�</param>
        /// <returns></returns>
        public bool StopMany(List<int> arrPK)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < arrPK.Count; i++)
                        {
                            usp_tblFW_User_UpdateActive uspUpdate = new usp_tblFW_User_UpdateActive();
                            uspUpdate.fldAutoID = arrPK[i];
                            int iResult = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResult <= 0)
                                throw new Exception("ͣ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("�����ݿ�����ʧ��", "RuletblFW_User", "StopMany", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("ִ��Sql���ʧ��", "RuletblFW_User", "StopMany", "");
                    }
                    catch (DBException e)
                    {
                        throw new UpdateException("ִ��Sql���ʧ��", "RuletblFW_User", "StopMany", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new UpdateException(e.Message, "RuletblFW_User", "StopMany", "");
                    }
                }
            }
        }
    }
}
