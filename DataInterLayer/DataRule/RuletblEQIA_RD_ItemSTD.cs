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
    /// ��������    ��  �Ա�[tblEQIA_RD_ItemSTD]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_RD_ItemSTD : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblEQIA_RD_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-06-04
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objInsert">��Ҫ��ӵ�ʵ����</param>
        /// <returns>����������¼��PK������ֵ</returns>
        public int Insert(tblEQIA_RD_ItemSTD objInsert)
        {
            try
            {
                usp_tblEQIA_RD_ItemSTD_Insert uspInsert = new usp_tblEQIA_RD_ItemSTD_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("�����¼�¼ʧ��");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("�����ݿ�����ʧ��", "RuletblEQIA_RD_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblEQIA_RD_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("ִ��Sql���ʧ��", "RuletblEQIA_RD_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblEQIA_RD_ItemSTD", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ɾ��[tblEQIA_RD_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-06-04
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
                usp_tblEQIA_RD_ItemSTD_Delete uspDelete = new usp_tblEQIA_RD_ItemSTD_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("ɾ����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("�����ݿ�����ʧ��", "RuletblEQIA_RD_ItemSTD", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("ִ��Sql���ʧ��", "RuletblEQIA_RD_ItemSTD", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblEQIA_RD_ItemSTD", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ����[tblEQIA_RD_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-06-04
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objUpdate_old">��Ҫ���µ�ʵ����</param>
        /// <param name="objUpdate_new">���º��ʵ����</param>
        /// <returns>true / false</returns>
        public bool Update(tblEQIA_RD_ItemSTD objUpdate_old, tblEQIA_RD_ItemSTD objUpdate_new)
        {
            try
            {
                usp_tblEQIA_RD_ItemSTD_Update uspUpdate = new usp_tblEQIA_RD_ItemSTD_Update();
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
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RD_ItemSTD", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBPKException e)
            {
                throw new UpdatePKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblEQIA_RD_ItemSTD", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RD_ItemSTD", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RD_ItemSTD", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ��������ȡ��[tblEQIA_RD_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-06-04
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">PK����ֵ</param>
        /// <returns>tblEQIA_RD_ItemSTD</returns>
        public tblEQIA_RD_ItemSTD ByPK(int iPK)
        {
            try
            {
                usp_tblEQIA_RD_ItemSTD_ByPK uspByPK = new usp_tblEQIA_RD_ItemSTD_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_RD_ItemSTD objData = new tblEQIA_RD_ItemSTD();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_RD_ItemSTD", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_RD_ItemSTD", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_RD_ItemSTD", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblEQIA_RD_ItemSTD]������б�׼����
        /// ������      ��  �ź�
        /// ��������    ��  2009-12-07
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllStandardName()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_RD_ItemSTD_GetAllStandardName uspByAll = new usp_tblEQIA_RD_ItemSTD_GetAllStandardName();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_RD_ItemSTD";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIA_RD_ItemSTD", "GetAllStandardName", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIA_RD_ItemSTD", "GetAllStandardName", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_RD_ItemSTD", "GetAllStandardName", "");
            }
        }

        /// <summary>
        /// ��������    ��  ȡ���վ�ֵ��׼
        /// ������      ��  �ź�
        /// ��������    ��  2009-11-24
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="stritemCode">��Ŀ����</param>
        /// <param name="standardNum">��׼��</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_RD_ItemSTD> GetDaySTG(string stritemCode, string standardNum)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_RD_ItemSTD_GetDaySTG uspSTG = new usp_tblEQIA_RD_ItemSTD_GetDaySTG();
                uspSTG.stritemCode = stritemCode;
                uspSTG.StandardNum = standardNum;
                tblData = uspSTG.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_RD_ItemSTD> listAll = new List<tblEQIA_RD_ItemSTD>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_RD_ItemSTD objData = new tblEQIA_RD_ItemSTD();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_RD_ItemSTD", "GetDaySTG",
"stritemCode��" + stritemCode + ",standardNum:" + standardNum);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_RD_ItemSTD", "GetDaySTG", "stritemCode��" + stritemCode + ",standardNum:" + standardNum);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_RD_ItemSTD", "GetDaySTG", "stritemCode��" + stritemCode + ",standardNum:" + standardNum);
            }
        }
    }
}
