using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Lib.account;
using DDYZ.Ensis.Library.Lib.str;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  �Ա�[tblFW_RegCity]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblFW_RegCity : BaseRule
    {
        ///// <summary>
        ///// ��������    ��  ���ע����в����ɡ�ϵͳ����Ա����ɫ��admin�û�������admin���衾ϵͳ����Ա����ɫ
        ///// ������      ��  ������
        ///// ��������    ��  2009-04-14
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="objInsert">Ҫ���ɵ�ע�����ʵ��</param>
        ///// <param name="sPassword">���ɳɹ����admin������</param>
        ///// <returns></returns>
        //public bool Insert(tblFW_RegCity objInsert, out string sPassword)
        //{
        //    using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString_LAP))
        //    {
        //        conn.Open();
        //        using (SqlTransaction tran = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                //����ע�����
        //                usp_tblFW_RegCity_Insert uspInsert = new usp_tblFW_RegCity_Insert();
        //                uspInsert.ReceiveParameter(objInsert);
        //                uspInsert.ExecNoQuery(conn, tran);
        //                int iCityID = uspInsert.fldAutoID;
        //                if (iCityID < 1)
        //                    throw new InsertException("����ע�����ʧ��", "RuletblFW_RegCity", "Insert", "");
        //                //����[ϵͳ����Ա]��ɫ
        //                tblFW_Role objRole = new tblFW_Role();
        //                objRole.fldName = "ϵͳ����Ա";
        //                objRole.fldRoleDesc = "ϵͳ����Ա";
        //                objRole.fldCityID = iCityID;
        //                usp_tblFW_Role_Insert uspRole = new usp_tblFW_Role_Insert();
        //                uspRole.ReceiveParameter(objRole);
        //                uspRole.ExecNoQuery(conn, tran);
        //                int iRoleID = uspRole.fldAutoID;
        //                if (iRoleID < 1)
        //                    throw new InsertException("����[ϵͳ����Ա]��ɫʧ��", "RuletblFW_RegCity", "Insert", "");
        //                //����[ϵͳ����Ա]<=5������Ȩ��
        //                usp_tblFW_Role_RightSet_ResetAdmin uspRightReset = new usp_tblFW_Role_RightSet_ResetAdmin();
        //                uspRightReset.fldRoleID = iRoleID;
        //                uspRightReset.ExecNoQuery(conn, tran);
        //                //����[ϵͳ����Ա]<=5���������ݿ��
        //                usp_tblFW_Role_Maintenance_ResetAdmin uspMaintReset = new usp_tblFW_Role_Maintenance_ResetAdmin();
        //                uspMaintReset.fldRoleID = iRoleID;
        //                uspMaintReset.ExecNoQuery(conn, tran);
        //                //����admin�û�
        //                sPassword = StringTools.GenerateRandomChar(8);
        //                tblFW_User objUser = new tblFW_User();
        //                objUser.fldUserName = "admin";
        //                objUser.fldPassword = PasswordTools.Md5(sPassword);
        //                objUser.fldUserDesc = "ϵͳ����Ա";
        //                objUser.fldCityID = iCityID;
        //                objUser.fldActive = true;
        //                usp_tblFW_User_Insert uspUser = new usp_tblFW_User_Insert();
        //                uspUser.ReceiveParameter(objUser);
        //                uspUser.ExecNoQuery(conn, tran);
        //                int iUserID = uspUser.fldAutoID;
        //                if (iUserID < 1)
        //                    throw new InsertException("����[admin]��ɫʧ��", "RuletblFW_RegCity", "Insert", "");
        //                //admin��[ϵͳ����Ա]��ɫ��������
        //                tblFW_User_Role objUserRole = new tblFW_User_Role();
        //                objUserRole.fldUserID = iUserID;
        //                objUserRole.fldRoleID = iRoleID;
        //                usp_tblFW_User_Role_Insert uspUserRole = new usp_tblFW_User_Role_Insert();
        //                uspUserRole.ReceiveParameter(objUserRole);
        //                uspUserRole.ExecNoQuery(conn, tran);
        //                int iUserRole = uspUserRole.fldAutoID;
        //                if (iUserRole < 1)
        //                    throw new InsertException("����[admin]��[ϵͳ����Ա]ʧ��", "RuletblFW_RegCity", "Insert", "");
        //                tran.Commit();
        //                return true;
        //            }
        //            catch (DBOpenException e)
        //            {
        //                throw new InsertException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (DBPKException e)
        //            {
        //                throw new InsertPKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (DBQueryException e)
        //            {
        //                throw new InsertException("д�����ݿ�ʧ��", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (DBException e)
        //            {
        //                throw new InsertException("д�����ݿ�ʧ��", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (InsertException e)
        //            {
        //                tran.Rollback();
        //                throw e;
        //            }
        //            catch (Exception e)
        //            {
        //                tran.Rollback();
        //                throw new DataRuleException(e.Message, "RuletblFW_RegCity", "Insert", "");
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// ��������    ��  ���[tblFW_RegCity]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-09
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
                usp_tblFW_RegCity_ByAll uspByAll = new usp_tblFW_RegCity_ByAll();
                tblData = uspByAll.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblFW_RegCity";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetAllData", "");
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblFW_RegCity]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-09
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>IList<tblFW_RegCity></returns>
        public IList<tblFW_RegCity> GetAllList()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_RegCity_ByAll uspByAll = new usp_tblFW_RegCity_ByAll();
                tblData = uspByAll.ExecDataTable(1);
                if (tblData != null)
                {
                    IList<tblFW_RegCity> listAll = new List<tblFW_RegCity>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblFW_RegCity objData = new tblFW_RegCity();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "GetAllList", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "GetAllList", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_RegCity", "GetAllList", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��������ȡ��[tblFW_RegCity]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-09
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">PK����ֵ</param>
        /// <returns>tblFW_RegCity</returns>
        public tblFW_RegCity ByPK(int iPK)
        {
            try
            {
                usp_tblFW_RegCity_ByPK uspByPK = new usp_tblFW_RegCity_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable(1);
                if (tblData != null)
                {
                    tblFW_RegCity objData = new tblFW_RegCity();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_RegCity", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ���ݳ��д���ȡ��[tblFW_RegCity]��ļ�¼
        /// ������      ��  ������
        /// ��������    ��  2009-04-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sSTCode">���д���</param>
        /// <returns>tblFW_RegCity</returns>
        public tblFW_RegCity ByCode(string sSTCode)
        {
            try
            {
                usp_tblFW_RegCity_ByCode uspByCode = new usp_tblFW_RegCity_ByCode();
                uspByCode.fldSTCode = sSTCode;
                DataTable tblData = uspByCode.ExecDataTable(1);
                if (tblData != null)
                {
                    tblFW_RegCity objData = new tblFW_RegCity();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "ByCode", sSTCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "ByCode", sSTCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_RegCity", "ByCode", sSTCode);
            }
        }


        /// <summary>
        /// ��������    ��  ���ݳ��д���ȡ��[tblFW_RegCity]��ļ�¼
        /// ������      ��  �촺��
        /// ��������    ��  2010-08-24
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sSTCode">���д���</param>
        /// <returns>tblFW_RegCity</returns>
        public IList<tblFW_RegCity> ByAllCode(string sSTCode)
        {
            try
            {
                usp_tblFW_RegCity_ByAllCode uspByCode = new usp_tblFW_RegCity_ByAllCode();
                uspByCode.fldSTCode = sSTCode;
                DataTable tblData = uspByCode.ExecDataTable(1);
                 if (tblData != null)
                {
                    IList<tblFW_RegCity> listAll = new List<tblFW_RegCity>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblFW_RegCity objData = new tblFW_RegCity();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "ByAllCode", sSTCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "ByAllCode", sSTCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_RegCity", "ByAllCode", sSTCode);
            }
        }

        ///// <summary>
        ///// ��������    ��  ���ݽ�ɫID��ҵ��ģ���ȡ������Ϣ
        ///// ������      ��  ������
        ///// ��������    ��  2012-02-07
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="roleID">��ɫID</param>
        ///// <param name="moudle">ҵ��ģ��</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetCityByRoleID(int roleID, int moudle)
        //{
        //    try
        //    {
        //        DataTable tblData = new DataTable();
        //        usp_GetCityByRoleID uspGetCity = new usp_GetCityByRoleID();
        //        uspGetCity.fldRoleID = roleID;
        //        uspGetCity.fldMoudle = moudle;
        //        tblData = uspGetCity.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "GetCityByRoleID", "roleID��" + roleID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "GetCityByRoleID", "roleID��" + roleID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetCityByRoleID", "roleID��" + roleID);
        //    }
        //}

        ///// <summary>
        ///// ��������    ��  ���[tblFW_RegCity]����Լ����¼����еļ�¼
        ///// ������      ��  ������
        ///// ��������    ��  2009-04-13
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetSelfAndChildren(int iAutoID)
        //{
        //    try
        //    {
        //        DataTable tblData = new DataTable();
        //        usp_tblFW_RegCity_SelfAndChild uspByAll = new usp_tblFW_RegCity_SelfAndChild();
        //        uspByAll.fldAutoID = iAutoID;
        //        tblData = uspByAll.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "GetSelfAndChildren", "iAutoID��" + iAutoID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "GetSelfAndChildren", "iAutoID��" + iAutoID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetSelfAndChildren", "iAutoID��" + iAutoID);
        //    }
        //}

        ///// <summary>
        ///// ��������    ��  ���ݽ�ɫ���[tblFW_RegCity]��ļ�¼
        ///// ������      ��  �ź�
        ///// ��������    ��  2011-12-27
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetSelfAndChildrenByRoleID(int iAutoID,int roleID,int moudle)
        //{
        //    try
        //    {
        //        DataTable tblData = new DataTable();
        //        usp_tblFW_RegCity_SelfAndChildByRole uspByAll = new usp_tblFW_RegCity_SelfAndChildByRole();
        //        uspByAll.fldAutoID = iAutoID;
        //        uspByAll.Roleid = roleID;
        //        uspByAll.Moudle = moudle;
        //        tblData = uspByAll.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "GetSelfAndChildrenByRoleID", "iAutoID��" + iAutoID.ToString() + ",roleID��" + roleID.ToString() + ",moudle��" + moudle.ToString());
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "GetSelfAndChildrenByRoleID", "iAutoID��" + iAutoID.ToString() + ",roleID��" + roleID.ToString() + ",moudle��" + moudle.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetSelfAndChildrenByRoleID", "iAutoID��"+iAutoID.ToString() + ",roleID��" + roleID.ToString() + ",moudle��" + moudle.ToString());
        //    }
        //}

        ///// <summary>
        ///// ��������    ��  ����[tblFW_RegCity]��ļ�¼
        ///// ������      ��  Auto Generator
        ///// ��������    ��  2009-05-05
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="objUpdate_old">��Ҫ���µ�ʵ����</param>
        ///// <param name="objUpdate_new">���º��ʵ����</param>
        ///// <returns>true / false</returns>
        //public bool Update(tblFW_RegCity objUpdate_old, tblFW_RegCity objUpdate_new)
        //{
        //    try
        //    {
        //        usp_tblFW_RegCity_Update uspUpdate = new usp_tblFW_RegCity_Update();
        //        uspUpdate.ReceiveParameter_Old(objUpdate_old);
        //        uspUpdate.ReceiveParameter_New(objUpdate_new);
        //        int iResult = uspUpdate.ExecNoQuery(1);
        //        if (iResult > 0)
        //            return true;
        //        else
        //            throw new Exception("���¼�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new UpdateException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "Update",
        //            "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new UpdateException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "Update",
        //            "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        throw new UpdateException(e.Message, "RuletblFW_RegCity", "Update",
        //            "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
        //    }
        //}

        ///// <summary>
        ///// ��������    ��  ���[tblFW_RegCity]����ϼ����еļ�¼���������Լ���
        ///// ������      ��  ������
        ///// ��������    ��  2009-05-05
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetParent(int iAutoID)
        //{
        //    try
        //    {
        //        usp_tblFW_RegCity_Parent uspParent = new usp_tblFW_RegCity_Parent();
        //        uspParent.fldAutoID = iAutoID;
        //        DataTable tblData = uspParent.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "GetParent", "iAutoID��" + iAutoID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "GetParent", "iAutoID��" + iAutoID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetParent", "iAutoID��" + iAutoID);
        //    }
        //}

        ///// <summary>
        ///// ��������    ��  ���[tblFW_RegCity]����ϼ����е�ID
        ///// ������      ��  ������
        ///// ��������    ��  2009-06-15
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>������ID</returns>
        //public int GetParentCityID(int iAutoID)
        //{
        //    try
        //    {
        //        usp_tblFW_RegCity_ByPK uspByPK = new usp_tblFW_RegCity_ByPK();
        //        uspByPK.fldAutoID = iAutoID;
        //        DataTable tblData = uspByPK.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblFW_RegCity objData = new tblFW_RegCity();
        //            objData.MetaDataTable = tblData;
        //            return objData.fldParentID;
        //        }
        //        else
        //            throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("�����ݿ�����ʧ��", "RuletblFW_RegCity", "GetParentCityID", "iAutoID��" + iAutoID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("ִ��Sql���ʧ��", "RuletblFW_RegCity", "GetParentCityID", "iAutoID��" + iAutoID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetParentCityID", "iAutoID��" + iAutoID);
        //    }
        //}
    }
}
