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
    /// ��������    ��  �Ա�[tblEQIN_T_Point]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIN_T_Point : BaseRule
    {

        /// <summary>
        /// ��������    ��  ������ݡ����д�����[tblEQIN_T_Point]���·�δ����·������
        /// ������      ��  �촺��
        /// ��������    ��  2012-04-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>List</returns>
        public List<tblEQIN_T_Point> GetRDInfoForGis()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_T_Point_forGis uspGetRDCode = new usp_tblEQIN_T_Point_forGis();
                tblData = uspGetRDCode.ExecDataTable();
                if (tblData != null)
                {
                    List<tblEQIN_T_Point> listAll = new List<tblEQIN_T_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIN_T_Point objData = new tblEQIN_T_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIN_T_Point", "GetRDInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIN_T_Point", "GetRDInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIN_T_Point", "GetRDInfoForGis", "");
            }
        }






        /// <summary>
        /// ��������    ��  ������ݡ����д�����[tblEQIN_T_Point]��ı����к��¼����д���
        /// ������      ��  �ź�
        /// ��������    ��  2009-08-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <returns>IList</returns>
        public IList<tblEQIN_T_Point> GetSTCodeByYearandCode(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_T_Point_GetSTCodeByYearandCode uspGetRDCODE = new usp_tblEQIN_T_Point_GetSTCodeByYearandCode();
                uspGetRDCODE.fldSTCode = STCode;
                uspGetRDCODE.fldYear = Year;
                tblData = uspGetRDCODE.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIN_T_Point> listAll = new List<tblEQIN_T_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIN_T_Point objData = new tblEQIN_T_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIN_T_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIN_T_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIN_T_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }




















    }
}
