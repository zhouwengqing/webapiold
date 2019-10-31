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
    /// ��������    ��  �Ա�[tblEQIA_R_Point]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_R_Point : BaseRule
    { 


        /// <summary>
        /// ��������    ��  ���ݱ������ұ���ĳ��к����
        /// ������      ��  �촺��
        /// ��������    ��  2009-06-22
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="strTableName">����</param>
        /// <param name="StrCode">���д���</param> 
        /// <param name="strUserName">�û���</param>
        /// <param name="strType">���("city"���س���,���򷵻����)</param>
        public DataTable GetCityOrTypeName(string strTableName,string StrCode,string strUserName,string strType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_GetCityOrTypeName uspGetCityOrTypeName = new usp_GetCityOrTypeName();
                uspGetCityOrTypeName.name = strTableName;
                uspGetCityOrTypeName.stcode = StrCode;
                uspGetCityOrTypeName.username = strUserName;
                uspGetCityOrTypeName.type = strType;
                tblData = uspGetCityOrTypeName.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_R_Point", "GetCityOrTypeName", "STCode:" + StrCode + " TableName:" + strTableName);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_R_Point", "GetCityOrTypeName", "STCode:" + StrCode + " TableName:" + strTableName);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetCityOrTypeName", "STCode:" + StrCode + " TableName:" + strTableName);
            }
        }
         

        /// <summary>
        /// ��������    ��  ���ݵ�ǰ��ݻ��[tblEQIA_R_Point]��ļ�¼��GISʹ��
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>List</returns>
        public List<tblEQIA_R_Point> GetPointInfoForGis(string SType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_ForGis uspGetAll = new usp_tblEQIA_R_Point_ForGis();
                uspGetAll.fldType = SType;
                tblData = uspGetAll.ExecDataTable();
                if (tblData != null)
                {
                    List<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_R_Point", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_R_Point", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPointInfoForGis", "");
            }
        } 
        /// <summary>
        /// ��������    ��  ���ݵ�ǰ��ݻ��[tblEQIA_R_Point]��ļ�¼��GISʹ��
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForPage(string STCode,string sType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_ForPage uspGetAll = new usp_tblEQIA_R_Point_ForPage();
                uspGetAll.Stcode = STCode;
                uspGetAll.Type = sType;
                tblData = uspGetAll.ExecDataTable(); 
                if (tblData != null)
                { 
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_R_Point", "GetPointInfoForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_R_Point", "GetPointInfoForPage", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPointInfoForPage", "");
            }
        }

        /// <summary>
        /// ��������    ��  ������ݡ����д���Ͳ�����ͻ��[tblEQIA_R_Point]��Ĳ�����ƺͲ�����
        /// ������      ��  ������
        /// ��������    ��  2009-06-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_Point> GetPCodeByYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_GetPCodeByYear uspGetPCode = new usp_tblEQIA_R_Point_GetPCodeByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }


        /// <summary>
        /// ��������    ��  ������ݡ����д���Ͳ�����ͻ��[tblEQIA_R_Point]��Ĳ�����ƺͲ�����
        /// ������      ��  ������
        /// ��������    ��  2009-06-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_Point> GetPCodeByYearHM(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_GetPCodeByYear_New uspGetPCode = new usp_tblEQIA_R_Point_GetPCodeByYear_New();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_R_Point", "GetPCodeByYearHM",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_R_Point", "GetPCodeByYearHM",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCodeByYearHM",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }


        /// <summary>
        /// ��������    ��  ���ݽ�ɫ����ݡ���㼶�𡢳��д���Ͳ�����ͻ��[tblEQIA_R_Point]��Ĳ�����ƺͲ�����
        /// ������      ��  �ź�
        /// ��������    ��  2011-12-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <param name="Level">��㼶��</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_Point> GetPCodeByRole(string STCode, int Year, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_GetPCodeByRole uspGetPCode = new usp_tblEQIA_R_Point_GetPCodeByRole();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                uspGetPCode.fldPLevel = Level;
                uspGetPCode.include = include;
                uspGetPCode.roleid = roleid;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIA_R_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIA_R_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }
    }
}
