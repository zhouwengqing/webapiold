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
    /// ��������    ��  �Ա�[tblEQIW_D_Section]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_D_Section
    {

        /// <summary>
        /// ��������    ��  ���ݵ�ǰ��ݻ��ˮ�ʶ����ļ�¼��GISʹ��
        /// ������      ��  �촺��
        /// ��������    ��  2012-06-03
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForGis()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Section_ForGis uspGetAll = new usp_tblEQIW_D_Section_ForGis();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_D_Section", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_D_Section", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_D_Section", "GetPointInfoForGis", "");
            }
        }



        /// <summary>
        /// ��������    ��  ���ݵ�ǰ��ݻ������ˮ���л�ˮ����Ϣ
        /// ������      ��  �촺��
        /// ��������    ��  2012-06-03
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetCitySectionInfoForPage(string STCode, string sType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Section_ForPage uspGetAll = new usp_tblEQIW_D_Section_ForPage();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_D_Section", "GetCitySectionInfoForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_D_Section", "GetCitySectionInfoForPage", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_D_Section", "GetCitySectionInfoForPage", "");
            }
        }




        /// <summary>
        /// ��������    ��  ������ݡ����д���Ͳ�����ͻ��[tblEQIW_D_Session]��ĺ�������ͺ�������
        /// ������      ��  �Ƴ�
        /// ��������    ��  2011-09-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_D_Section> GetRCodeBySTcodeAndYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Session_GetRCodeByYear uspGetPCode = new usp_tblEQIW_D_Session_GetRCodeByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();

                if (tblData != null)
                {
                    IList<tblEQIW_D_Section> listAll = new List<tblEQIW_D_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_D_Section objData = new tblEQIW_D_Section();
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
                throw new GetListException("�����ݿ�����ʧ��", "tblEQIW_D_Section", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "tblEQIW_D_Section", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "tblEQIW_D_Section", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }










        /// <summary>
        /// ��������    ��  ���ݶ��漶�𡢳��д���ͺ���������[tblEQIW_R_Section]��ĵر�ˮ�������ƺͶ������
        /// ������      ��  �ź�
        /// ��������    ��  2009-08-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="RCode">��������</param>
        /// <param name="Level">���漶��</param>
        /// <param name="include">�Ƿ�����ϼ�</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_D_Section> GetRSCode(string STCode, string RCode, short Level, int include, int year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Section_GetRSCode uspGetRSCode = new usp_tblEQIW_D_Section_GetRSCode();
                uspGetRSCode.fldSTCode = STCode;
                uspGetRSCode.fldRCode = RCode;
                uspGetRSCode.fldSLevel = Level;
                uspGetRSCode.include = include;
                uspGetRSCode.fldYear = year;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_D_Section> listAll = new List<tblEQIW_D_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_D_Section objData = new tblEQIW_D_Section();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_D_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_D_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_D_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
        }















        /// <summary>
        /// ��������    ��  ������ѡ���д���ȡ��[tblEQIW_D_Section]��ĺ�������
        /// ������      ��  ��˧
        /// ��������    ��  2011-01-16
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <returns>tblEQIW_D_Section</returns>
        public IList<tblEQIW_D_Section> GetRCodeBySTCode(string STCode, int fldYear, short Level, int include)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Section_GetRCodeBySTCode uspGetRCode = new usp_tblEQIW_D_Section_GetRCodeBySTCode();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                uspGetRCode.fldPLevel = Level;
                uspGetRCode.include = include;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_D_Section> listAll = new List<tblEQIW_D_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_D_Section objData = new tblEQIW_D_Section();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_D_Section", "GetRCodeBySTCode", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_D_Section", "GetRCodeBySTCode", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Section", "GetRCodeBySTCode", STCode);
            }
        }







        /// <summary>
        /// ��������    ��  ������ѡ���д���ȡ��[tblEQIW_D_Section]��ĺ������룬��STCode
        /// ������      ��  ��˧
        /// ��������    ��  2011-01-16
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <returns>tblEQIW_D_Section</returns>
        public IList<tblEQIW_D_Section> GetRCodeBySTCode_NofldSTCode(string STCode, int fldYear, short Level, int include)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Section_GetRCodeBySTCode_NofldSTCode uspGetRCode = new usp_tblEQIW_D_Section_GetRCodeBySTCode_NofldSTCode();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                uspGetRCode.fldPLevel = Level;
                uspGetRCode.include = include;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_D_Section> listAll = new List<tblEQIW_D_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_D_Section objData = new tblEQIW_D_Section();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_D_Section", "GetRCodeBySTCode", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_D_Section", "GetRCodeBySTCode", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Section", "GetRCodeBySTCode", STCode);
            }
        }















        /// <summary>
        /// ��������    ��  ���ݳ��д�������ȡ�ĺ�������
        /// ������      ��  ������
        /// ��������    ��  2017-07-06
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="RCode">��������</param>
        /// <param name="Level">���漶��</param>
        /// <param name="include">�Ƿ�����ϼ�</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_D_Section> GetRSCodeandRCode(string STCode, short Level, string year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Section_GetRCodeandRSCodeBySTCode uspGetRSCode = new usp_tblEQIW_D_Section_GetRCodeandRSCodeBySTCode();
                uspGetRSCode.fldSTCode = STCode;
                uspGetRSCode.fldPLevel = Level;
                uspGetRSCode.fldYear = year;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_D_Section> listAll = new List<tblEQIW_D_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_D_Section objData = new tblEQIW_D_Section();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode);
            }

        }


        /// <summary>
        /// ��������    ��  ������ѡ���д���ȡ��[tblEQIW_D_Section]��ĺ�������
        /// ������      ��  ������
        /// ��������    ��  2017-09-13
        /// �޸���      ��  
        /// �޸�����    ��  
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <returns>tblEQIW_D_Section</returns>
        public IList<tblEQIW_D_Section> GetHMRCodeBySTCode(string STCode, int fldYear)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_D_Section_GetRCodeBySTCode_New uspGetRCode = new usp_tblEQIW_D_Section_GetRCodeBySTCode_New();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_D_Section> listAll = new List<tblEQIW_D_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_D_Section objData = new tblEQIW_D_Section();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_D_Section", "GetHMRCodeBySTCode", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_D_Section", "GetHMRCodeBySTCode", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Section", "GetHMRCodeBySTCode", STCode);
            }
        }



















    }
}
