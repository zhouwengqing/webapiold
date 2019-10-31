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
    /// ��������    ��  �Ա�[tblDictionary]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblDictionary : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblDictionary]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objInsert">��Ҫ��ӵ�ʵ����</param>
        /// <returns>����������¼��PK������ֵ</returns>
        public int Insert(tblDictionary objInsert)
        {
            try
            {
                usp_tblDictionary_Insert uspInsert = new usp_tblDictionary_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery(1);
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("�����¼�¼ʧ��");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("�����ݿ�����ʧ��", "RuletblDictionary", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblDictionary", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("ִ��Sql���ʧ��", "RuletblDictionary", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblDictionary", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ɾ��[tblDictionary]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-29
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
                usp_tblDictionary_Delete uspDelete = new usp_tblDictionary_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery(1);
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("ɾ����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("�����ݿ�����ʧ��", "RuletblDictionary", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("ִ��Sql���ʧ��", "RuletblDictionary", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblDictionary", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ����[tblDictionary]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objUpdate_old">��Ҫ���µ�ʵ����</param>
        /// <param name="objUpdate_new">���º��ʵ����</param>
        /// <returns>true / false</returns>
        public bool Update(tblDictionary objUpdate_old, tblDictionary objUpdate_new)
        {
            try
            {
                usp_tblDictionary_Update uspUpdate = new usp_tblDictionary_Update();
                uspUpdate.ReceiveParameter_Old(objUpdate_old);
                uspUpdate.ReceiveParameter_New(objUpdate_new);
                int iResult = uspUpdate.ExecNoQuery(1);
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("���¼�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblDictionary", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBPKException e)
            {
                throw new UpdatePKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblFW_Dept", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblDictionary", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblDictionary", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ��������ȡ��[tblDictionary]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">PK����ֵ</param>
        /// <returns>tblDictionary</returns>
        public tblDictionary ByPK(int iPK)
        {
            try
            {
                usp_tblDictionary_ByPK uspByPK = new usp_tblDictionary_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable(1);
                if (tblData != null)
                {
                    tblDictionary objData = new tblDictionary();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblDictionary", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblDictionary", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ͬʱɾ��[tblDictionary]��Ķ�����¼
        /// ������      ��  �Ŵ�
        /// ��������    ��  2009-04-30
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="arrPK">Ҫɾ��������ID�б�</param>
        /// <returns></returns>
        public bool DeleteMany(List<int> arrPK)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString_LAP))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < arrPK.Count; i++)
                        {
                            usp_tblDictionary_Delete_ParentID dicPDelete = new usp_tblDictionary_Delete_ParentID();
                            dicPDelete.fldParentID = arrPK[i];
                            dicPDelete.ExecNoQuery(conn, tran);
                            usp_tblDictionary_Delete dicDelete = new usp_tblDictionary_Delete();
                            dicDelete.fldAutoID = arrPK[i];
                            int iResult = dicDelete.ExecNoQuery(conn, tran);
                            if (iResult <= 0)
                                throw new Exception("ɾ����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new DeleteException("�����ݿ�����ʧ��", "RuletblDictionary", "DeleteMany", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new DeleteException("ִ��Sql���ʧ��", "RuletblDictionary", "DeleteMany", "");
                    }
                    catch (DBException e)
                    {
                        throw new DeleteException("д�����ݿ�ʧ��", "RuletblDictionary", "DeleteMany", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new DeleteException(e.Message, "RuletblDictionary", "DeleteMany", "");
                    }
                }
            }
        }

        /// <summary>
        /// ��������    ��  ���Ҹ��ֵ��µ���������Ŀ�ֵ�
        /// ������      ��  �Ŵ�
        /// ��������    ��  2009-05-04
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="pid">Ҫ���ҵĸ��ֵ�</param>
        /// <returns></returns>
        public DataTable ByParentID(int pid)
        {
            try
            {
                usp_tblDictionary_Select_ByParentID selectByParentID = new usp_tblDictionary_Select_ByParentID();
                selectByParentID.fldAutoID = pid;
                DataTable tblData = selectByParentID.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblDictionary";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblDictionary", "ByParentID", pid.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblDictionary", "ByParentID", pid.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentID", pid.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ���Ҹ��ֵ��µ���������Ŀ�ֵ�
        /// ������      ��  ������
        /// ��������    ��  2009-05-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sParentName">Ҫ���ҵĸ��ֵ�����</param>
        /// <returns></returns>
        public DataTable ByParentName(string sParentName)
        {
            try
            {
                usp_tblDictionary_Select_ByParentName selectByParentName = new usp_tblDictionary_Select_ByParentName();
                selectByParentName.fldName = sParentName;
                DataTable tblData = selectByParentName.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblDictionary";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblDictionary", "ByParentName", sParentName);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblDictionary", "ByParentName", sParentName);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentName", sParentName);
            }
        }

        /// <summary>
        /// ��������    ��  ����ĳ�����ֵ����Ƿ����ĳ�����ֵ�����
        /// ������      ��  ������
        /// ��������    ��  2009-05-11
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="fldpid">���ֵ�ID</param>
        /// <param name="fldname">���ֵ�����</param>
        /// <returns></returns>
        public bool CheckDBHave(int fldpid, string fldname)
        {
            try
            {
                usp_tblDictionary_Select_ByNameAndParentID selectByNameAndParentID = new usp_tblDictionary_Select_ByNameAndParentID();
                selectByNameAndParentID.fldParentID = fldpid;
                selectByNameAndParentID.fldName = fldname;
                int icount = int.Parse(selectByNameAndParentID.ExecScalar(1).ToString());
                if (icount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblDictionary", "CheckDBHave", 
                        "fldpid��" + fldpid.ToString() + "��fldname��" + fldname);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblDictionary", "CheckDBHave", 
                        "fldpid��" + fldpid.ToString() + "��fldname��" + fldname);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "CheckDBHave", 
                        "fldpid��" + fldpid.ToString() + "��fldname��" + fldname);
            }
        }

        /// <summary>
        /// ��������    ��  ���ݸ��ֵ�ID���ֵ�ֵȡ���ֵ�����
        /// ������      ��  ������
        /// ��������    ��  2009-05-11
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sParentName">���ֵ������</param>
        /// <param name="sValue">�ֵ�ֵ</param>
        /// <returns>tblDictionary</returns>
        public string ByParentIDAndValue(string sParentName, string sValue)
        {
            try
            {
                usp_tblDictionary_GetNameByParentIDAndValue uspGetName = new usp_tblDictionary_GetNameByParentIDAndValue();
                uspGetName.fldParentName = sParentName;
                uspGetName.fldKey = sValue;
                object objResult = uspGetName.ExecScalar(1);
                return objResult == null ? "" : objResult.ToString().Trim();
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName��" + sParentName+ "��sValue��" + sValue);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName��" + sParentName + "��sValue��" + sValue);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName��" + sParentName+ "��sValue��" + sValue);
            }
        }

        /// <summary>
        /// ��������    ��  ���ݸ��ֵ�ID���ֵ�����ȡ���ֵ�ֵ
        /// ������      ��  �ź�
        /// ��������    ��  2009-12-23
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sParentName">���ֵ������</param>
        /// <param name="sName">�ֵ�����</param>
        /// <returns>tblDictionary</returns>
        public string ByParentIDAndName(string sParentName, string sName)
        {
            try
            {
                usp_tblDictionary_GetValueByParentIDAndName uspGetName = new usp_tblDictionary_GetValueByParentIDAndName();
                uspGetName.fldParentName = sParentName;
                uspGetName.fldName = sName;
                object objResult = uspGetName.ExecScalar(1);
                return objResult == null ? "" : objResult.ToString().Trim();
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName��" + sParentName + "��sName��" + sName);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblDictionary", "ByParentIDAndName",
                    "sParentName��" + sParentName + "��sName��" + sName);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentIDAndName",
                    "sParentName��" + sParentName + "��sName��" + sName);
            }
        }
    }
}
