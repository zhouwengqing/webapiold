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
    /// ��������    ��  �Ա�[tblEQIA_RD_Point]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_RD_Point : BaseRule
    {
        /// <summary>
        /// ��������    ��  ������ݡ����д���Ͳ�����ͻ��[tblEQIA_RD_Point]��Ĳ�����ƺͲ�����
        /// ������      ��  �ź�
        /// ��������    ��  2009-06-16
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_RD_Point> GetPCodeByYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_RD_Point_GetPCodeByYear uspGetPCode = new usp_tblEQIA_RD_Point_GetPCodeByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_RD_Point> listAll = new List<tblEQIA_RD_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_RD_Point objData = new tblEQIA_RD_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_RD_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_RD_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_RD_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ������ݡ���㼶�𡢳��д���Ͳ�����ͻ��[tblEQIA_RD_Point]��Ĳ�����ƺͲ�����
        /// ������      ��  �ź�
        /// ��������    ��  2011-12-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <param name="Level">��㼶��</param>
        /// <param name="roleid">��ɫID</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_RD_Point> GetPCodeByRole(string STCode, int Year, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_RD_Point_GetPCodeByRole uspGetPCode = new usp_tblEQIA_RD_Point_GetPCodeByRole();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                uspGetPCode.fldPLevel = Level;
                uspGetPCode.include = include;
                uspGetPCode.roleid = roleid;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_RD_Point> listAll = new List<tblEQIA_RD_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_RD_Point objData = new tblEQIA_RD_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_RD_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_RD_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_RD_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }
    }
}
