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
    /// ��������    ��  �Ա�[tblEQIA_R_ItemSTD]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_R_ItemSTD : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblEQIA_R_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-05-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objInsert">��Ҫ��ӵ�ʵ����</param>
        /// <returns>����������¼��PK������ֵ</returns>
        public int Insert(tblEQIA_R_ItemSTD objInsert)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_Insert uspInsert = new usp_tblEQIA_R_ItemSTD_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("�����¼�¼ʧ��");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ɾ��[tblEQIA_R_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-05-26
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
                usp_tblEQIA_R_ItemSTD_Delete uspDelete = new usp_tblEQIA_R_ItemSTD_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("ɾ����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblEQIA_R_ItemSTD", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ����[tblEQIA_R_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-05-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objUpdate_old">��Ҫ���µ�ʵ����</param>
        /// <param name="objUpdate_new">���º��ʵ����</param>
        /// <returns>true / false</returns>
        public bool Update(tblEQIA_R_ItemSTD objUpdate_old, tblEQIA_R_ItemSTD objUpdate_new)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_Update uspUpdate = new usp_tblEQIA_R_ItemSTD_Update();
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
                throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBPKException e)
            {
                throw new UpdatePKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblEQIA_R_ItemSTD", "Update",
                    "objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_R_ItemSTD", "Update", 
					"objUpdate_old��" + objUpdate_old.ToString() + "��objUpdate_new��" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ��������ȡ��[tblEQIA_R_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-05-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iPK">PK����ֵ</param>
        /// <returns>tblEQIA_R_ItemSTD</returns>
        public tblEQIA_R_ItemSTD ByPK(int iPK)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_ByPK uspByPK = new usp_tblEQIA_R_ItemSTD_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_ItemSTD objData = new tblEQIA_R_ItemSTD();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "ByPK", iPK.ToString());
            }
        }



        /// <summary>
        /// ��������    ��  ���[tblEQIA_R_ItemSTD]������б�׼����
        /// ������      ��  ������
        /// ��������    ��  2009-07-08
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
                usp_tblEQIA_R_ItemSTD_GetAllStandardName uspByAll = new usp_tblEQIA_R_ItemSTD_GetAllStandardName();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_ItemSTD";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "GetAllStandardName", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "GetAllStandardName", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_ItemSTD", "GetAllStandardName", "");
            }
        }
        
        /// <summary>
        /// ��������    ��  ���ݱ�׼���ƺ���Ŀ����ȡ��[tblEQIA_R_ItemSTD]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-05-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sStandardName">��׼����</param>
        /// <param name="sItemCode">��Ŀ����</param>
        /// <returns>tblEQIA_R_ItemSTD</returns>
        public tblEQIA_R_ItemSTD ByStandardNameAndItemCode(string sStandardName,string sItemCode)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_ByStandardNameAndItemCode uspByPK = new usp_tblEQIA_R_ItemSTD_ByStandardNameAndItemCode();
                uspByPK.fldStandardName = sStandardName;
                uspByPK.fldItemCode = sItemCode;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_ItemSTD objData = new tblEQIA_R_ItemSTD();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "ByStandardNameAndItemCode",
                    "sStandardName��" + sStandardName + "��sItemCode��" + sItemCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "ByStandardNameAndItemCode",
                    "sStandardName��" + sStandardName + "��sItemCode��" + sItemCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "ByStandardNameAndItemCode",
                    "sStandardName��" + sStandardName + "��sItemCode��" + sItemCode);
            }
        }

        /// <summary>
        /// ��������    ��  ���ݱ�׼����,��Ŀ����ͼ���ȡ�ñ�׼ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2009-07-31
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="sStandardName">��׼����</param>
        /// <param name="sItemCode">��Ŀ����</param>
        /// <param name="strSTDLevel">����(һ��,����..)</param>
        /// <param name="strFlag">���(month,sea..)</param>
        /// <returns>decimal</returns>
        public decimal GetItemStandard(string sStandardName, string sItemCode, string strSTDLevel, string strFlag)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_GetSTG uspSTG= new usp_tblEQIA_R_ItemSTD_GetSTG();
                uspSTG.strItemCode = sItemCode;
                uspSTG.strSTDName = sStandardName;
                uspSTG.strSTDLevel = strSTDLevel;
                uspSTG.strFlag = strFlag;
                DataTable tblData = uspSTG.ExecDataTable();
                if (tblData != null)
                {
                    return decimal.Parse(tblData.Rows[0]["STG"].ToString());
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "GetItemStandard",
                    "sStandardName��" + sStandardName + "��sItemCode��" + sItemCode + "; strSTDLevel:" + strSTDLevel+"; strFlag:"+strFlag);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "GetItemStandard",
                    "sStandardName��" + sStandardName + "��sItemCode��" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetItemStandard",
                    "sStandardName��" + sStandardName + "��sItemCode��" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
        }


        /// <summary>
        /// ��������    ��  ȡ��ָ��ƽ��ֵ
        /// ������      ��  �촺��
        /// ��������    ��  2009-07-31
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="dNumValue">�Ա�ֵ</param>
        /// <param name="sStandardName">��׼����</param>
        /// <param name="sItemCode">��Ŀ����</param>
        /// <param name="strSTDLevel">����(һ��,����..)</param>
        /// <param name="strFlag">���(month,sea..)</param>
        /// <returns>decimal</returns>
        public decimal GetTargetAVG(decimal dNumValue, string sStandardName, string sItemCode, string strSTDLevel, string strFlag)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_GetTargetAVG uspTargetAVG = new usp_tblEQIA_R_ItemSTD_GetTargetAVG();
                uspTargetAVG.numValue = dNumValue;
                uspTargetAVG.strItemCode = sItemCode;
                uspTargetAVG.strSTDName = sStandardName;
                uspTargetAVG.strSTDLevel = strSTDLevel;
                uspTargetAVG.strFlag = strFlag;
                DataTable tblData = uspTargetAVG.ExecDataTable();
                if (tblData != null)
                {
                    if (tblData.Rows[0]["TargetAVG"].ToString() == "")
                        return 0;
                    else
                        return decimal.Parse(tblData.Rows[0]["TargetAVG"].ToString());
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "GetTargetAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName��" + sStandardName + ";sItemCode��" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "GetTargetAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName��" + sStandardName + ";sItemCode��" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetTargetAVG",
                    "dNumValue:"+dNumValue.ToString()+";sStandardName��" + sStandardName + ";sItemCode��" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
        }


        /// <summary>
        /// ��������    ��  ȡ������������
        /// ������      ��  �촺��
        /// ��������    ��  2009-08-03
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="dNumValue">ƽ��ֵ</param>
        /// <param name="sStandardName">��׼����</param>
        /// <param name="sItemCode">��Ŀ����</param> 
        /// <param name="strFlag">���(month,sea..)</param>
        /// <returns>int</returns>
        public int GetAQLAVG(decimal dNumValue, string sStandardName, string sItemCode,  string strFlag)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_GetAQL uspAQLAVG = new usp_tblEQIA_R_ItemSTD_GetAQL();
                uspAQLAVG.nAVG = dNumValue;
                uspAQLAVG.strItemCode = sItemCode;
                uspAQLAVG.strSTDName = sStandardName;
                uspAQLAVG.strFlag = strFlag;
                DataTable tblData = uspAQLAVG.ExecDataTable();
                if (tblData != null)
                {
                    return int.Parse(tblData.Rows[0]["AQLLevel"].ToString());
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "GetAQLAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName��" + sStandardName + "��sItemCode��" + sItemCode + "; strFlag:" + strFlag);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "GetAQLAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName��" + sStandardName + "��sItemCode��" + sItemCode + "; strFlag:" + strFlag);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetAQLAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName��" + sStandardName + "��sItemCode��" + sItemCode + "; strFlag:" + strFlag);
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
        public IList<tblEQIA_R_ItemSTD> GetDaySTG(string stritemCode,string standardNum)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_ItemSTD_GetDaySTG uspSTG = new usp_tblEQIA_R_ItemSTD_GetDaySTG();
                uspSTG.stritemCode = stritemCode;
                uspSTG.StandardNum = standardNum;
                tblData = uspSTG.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_ItemSTD> listAll = new List<tblEQIA_R_ItemSTD>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_ItemSTD objData = new tblEQIA_R_ItemSTD();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_ItemSTD", "GetDaySTG",
"stritemCode��" + stritemCode + ",standardNum:" + standardNum);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_ItemSTD", "GetDaySTG", "stritemCode��" + stritemCode + ",standardNum:" + standardNum);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetDaySTG", "stritemCode��" + stritemCode + ",standardNum:" + standardNum);
            }
        }
    }
}
