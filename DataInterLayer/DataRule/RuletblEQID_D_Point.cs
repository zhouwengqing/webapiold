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
    /// ��������    ��  �Ա�[tblEQID_D_Point]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQID_D_Point : BaseRule
    { 


        /// <summary>
        /// ��������    ��  ���ݵ�ǰ��ݻ��[tblEQIA_R_Point]��ļ�¼��GISʹ��
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>List</returns>
        public List<tblEQID_D_Point> GetPointInfoForGis()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQID_D_Point_ForGis uspGetAll = new usp_tblEQID_D_Point_ForGis();
                tblData = uspGetAll.ExecDataTable();
                if (tblData != null)
                {
                    List<tblEQID_D_Point> listAll = new List<tblEQID_D_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQID_D_Point objData = new tblEQID_D_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQID_D_Point", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQID_D_Point", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQID_D_Point", "GetPointInfoForGis", "");
            }
        }

        /// <summary>
        /// ��������    ��  ������ݡ����д�����[tblEQID_D_Point]��Ĳ�����Ͳ������
        /// ������      ��  �Ƴ�
        /// ��������    ��  2012-02-22
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <returns>IList</returns>
        public IList<tblEQID_D_Point> GetPCodeByYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQID_D_Point_GetGDCODEByYear uspGetPCode = new usp_tblEQID_D_Point_GetGDCODEByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQID_D_Point> listAll = new List<tblEQID_D_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQID_D_Point objData = new tblEQID_D_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQID_D_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQID_D_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQID_D_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }

         



    }
}
