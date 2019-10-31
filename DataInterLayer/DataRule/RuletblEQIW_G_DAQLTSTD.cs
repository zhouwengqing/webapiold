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
    /// ��������    ��  �Ա�[tblEQIW_G_DAQLTSTD]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_G_DAQLTSTD : BaseRule
    {      
        /// <summary>
        /// ��������    ��  ȡ��ˮ��ִ�б�׼
        /// ������      ��  �ź�
        /// ��������    ��  2009-12-14
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="stritemCode">��Ŀ����</param>
        /// <param name="edition">��׼�汾</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_G_DAQLTSTD> GetSTD(string stritemCode, string edition)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_G_ItemSTD_GetSTD uspSTD = new usp_tblEQIW_G_ItemSTD_GetSTD();
                uspSTD.stritemCode = stritemCode;
                uspSTD.Edition = edition;
                tblData = uspSTD.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_G_DAQLTSTD> listAll = new List<tblEQIW_G_DAQLTSTD>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_G_DAQLTSTD objData = new tblEQIW_G_DAQLTSTD();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_G_DAQLTSTD", "GetSTD",
                    "stritemCode��" + stritemCode + ",edition:" + edition);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_G_DAQLTSTD", "GetSTD", 
                    "stritemCode��" + stritemCode + ",edition:" + edition);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_G_DAQLTSTD", "GetSTD", 
                    "stritemCode��" + stritemCode + ",edition:" + edition);
            }
        }
    }
}
