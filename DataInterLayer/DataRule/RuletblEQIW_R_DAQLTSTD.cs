using System;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System.Collections.Generic;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  �Ա�[tblEQIW_R_DAQLTSTD]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_R_DAQLTSTD : BaseRule
    {


        /// <summary>
        /// ��������    ��  ���ݱ���ȡ�����а汾������
        /// ������      ��  ������
        /// ��������    ��  2017-05-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetEdition(string table)
        {
            usp_All_DAQLTSTD_GetEditionBytable uspGetEdition = new usp_All_DAQLTSTD_GetEditionBytable()
            {
                table = table
            };
            return uspGetEdition.ExecDataTable();
        }

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
        public IList<tblEQIW_R_DAQLTSTD> GetSTD(string stritemCode, string edition)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_ItemSTD_GetSTD uspSTD = new usp_tblEQIW_R_ItemSTD_GetSTD();
                uspSTD.stritemCode = stritemCode;
                uspSTD.Edition = edition;
                tblData = uspSTD.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_DAQLTSTD> listAll = new List<tblEQIW_R_DAQLTSTD>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_DAQLTSTD objData = new tblEQIW_R_DAQLTSTD();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_DAQLTSTD", "GetSTD",
                    "stritemCode��" + stritemCode + ",edition:" + edition);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_DAQLTSTD", "GetSTD",
                    "stritemCode��" + stritemCode + ",edition:" + edition);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_DAQLTSTD", "GetSTD",
                    "stritemCode��" + stritemCode + ",edition:" + edition);
            }
        }

    }
}
