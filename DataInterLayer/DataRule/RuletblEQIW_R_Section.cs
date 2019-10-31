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
    /// ��������    ��  �Ա�[tblEQIW_R_Section]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_R_Section : BaseRule
    {

        /// <summary>
        /// ��������    ��  ���ݵ�ǰ��ݻ��ˮ�ʶ����ļ�¼��GISʹ��
        /// ������      ��  �촺��
        /// ��������    ��  2012-03-30
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForGis(string sType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_ForGis uspGetAll = new usp_tblEQIW_R_Section_ForGis();
                uspGetAll.fldType = sType;
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetPointInfoForGis", "");
            }
        }
        /// <summary>
        /// ��������    ��  ȡ�������о�γ�ȵĶ���
        /// ������      ��  �촺��
        /// ��������    ��  2013-07-29
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <param name="STCode">���д���</param>
        /// <param name="Rcode">�������</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllSectionForPage(string STCode,string Rcode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_AllSectionFor_Page uspGetAll = new usp_tblEQIW_R_Section_AllSectionFor_Page();
                uspGetAll.fldStcode = STCode;
                uspGetAll.fldRcode = Rcode;
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetAllSectionForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetAllSectionForPage", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetAllSectionForPage", "");
            }
        }



        /// <summary>
        /// ȡ����Ҫˮϵ��Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetRiverSys(string SType)
        { 
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_RiverSystem_ByType uspGetAll = new usp_tblEQIW_R_RiverSystem_ByType();
                uspGetAll.fldType = SType;
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetRiverSys", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetRiverSys", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetRiverSys", "");
            }
        }


        /// <summary>
        /// ȡ�ø���/֧�� ������Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetSectionByRiverSystemType(string SType,int iYear)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_ByRiverSystemType uspGetAll = new usp_tblEQIW_R_Section_ByRiverSystemType();
                uspGetAll.fldType = SType;
                uspGetAll.fldYear = iYear;
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetSectionByRiverSystemType", "SType:" + SType);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetSectionByRiverSystemType", "SType:" + SType);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetSectionByRiverSystemType", "SType:" + SType);
            }
        }


        /// <summary>
        /// ȡ�ú���/ˮ�������Ϣ
        /// </summary>
        /// <returns></returns>
        public DataTable GetEQIW_L_SectionByRiverSystemType(string SType, int iYear)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_L_Section_ByRiverSystemType uspGetAll = new usp_tblEQIW_L_Section_ByRiverSystemType();
                uspGetAll.fldType = SType;
                uspGetAll.fldYear = iYear;
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetEQIW_L_SectionByRiverSystemType", "SType:" + SType);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetEQIW_L_SectionByRiverSystemType", "SType:" + SType);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetEQIW_L_SectionByRiverSystemType", "SType:" + SType);
            }
        }

        /// <summary>
        /// ��������    ��  ������ѡ���д���ȡ��[tblEQIW_R_Section]��ĺ�������
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-08-26
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <returns>tblEQIW_R_Section</returns>
        public IList<tblEQIW_R_Section> GetRCodeBySTCodeByRole(string STCode, int fldYear, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole uspGetRCode = new usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                uspGetRCode.fldPLevel = Level;
                uspGetRCode.include = include;
                uspGetRCode.roleid = roleid;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetRCodeBySTCodeByRole", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetRCodeBySTCodeByRole", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Section", "GetRCodeBySTCodeByRole", STCode);
            }
        }

        /// <summary>
        /// ��������    ��  ������ѡ���д���ȡ��[tblEQIW_R_Section]��ĺ�������
        /// ������      �� ������
        /// ��������    ��  2017-09-13
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <returns>tblEQIW_R_Section</returns>
        public IList<tblEQIW_R_Section> GetHMRCodeBySTCodeByRole(string STCode, int fldYear)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole_New uspGetRCode = new usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole_New();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetHMRCodeBySTCodeByRole", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetHMRCodeBySTCodeByRole", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Section", "GetHMRCodeBySTCodeByRole", STCode);
            }
        }
        /// <summary>
        /// ��������    ��  ������ѡ���д���ͺ�������ȡ��[tblEQIW_R_Section]��ĵر�ˮ����������
        /// ������      ��  Auto Generator
        /// ��������    ��   2009-12-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="stcode">���д���</param>
        /// <param name="rcode">��������</param>
        /// <returns>tblEQIW_R_Section</returns>
        public IList<tblEQIW_R_Section> GetRSCodeByRCode(string stcode, string rcode, int year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRSCodeByRCode uspGetRSCode = new usp_tblEQIW_R_Section_GetRSCodeByRCode();
                uspGetRSCode.fldSTCode = stcode;
                uspGetRSCode.fldRCode = rcode;
                uspGetRSCode.fldYear = year;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "��rcode:" + rcode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "��rcode:" + rcode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "��rcode:" + rcode);
            }
        }


        /// <summary>
        /// ��������    ��  ���ݶ��漶�𡢳��д���ͺ���������[tblEQIW_R_Section]��ĵر�ˮ�������ƺͶ������
        /// ������      ��  �ź�
        /// ��������    ��  2011-12-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="RCode">��������</param>
        /// <param name="Level">���漶��</param>
        /// <param name="include">�Ƿ�����ϼ�</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_R_Section> GetRSCode(string STCode, string RCode, short Level, int include, int year, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRSCodeByRole uspGetRSCode = new usp_tblEQIW_R_Section_GetRSCodeByRole();
                uspGetRSCode.fldSTCode = STCode;
                uspGetRSCode.fldRCode = RCode;
                uspGetRSCode.fldSLevel = Level;
                uspGetRSCode.include = include;
                uspGetRSCode.fldYear = year;
                uspGetRSCode.roleid = roleid;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
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
        public IList<tblEQIW_R_Section> GetRSCodeandRCode(string STCode, short  Level, string year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRCodeandRSCodeBySTCode uspGetRSCode = new usp_tblEQIW_R_Section_GetRCodeandRSCodeBySTCode();
                uspGetRSCode.fldSTCode = STCode;                
                uspGetRSCode.fldPLevel = Level;             
                uspGetRSCode.fldYear = year;               
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode );
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode);
            }
           
        }


        /// <summary>
        /// ��������    ��  ���ݳ��д�������ȡ�ĵر�ˮ������Ϣ
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2018-01-24
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="year">���</param>
        /// <param name="stcode">���д���</param>
        /// <returns></returns>
        public DataTable gettblEQIW_R_Sectionbystcode(string year, string stcode,string type)
        {
            DataTable dt = new DataTable();
            try
            {
                usp_tblEQIW_R_SectionSelectByStcode uspGetStcode = new usp_tblEQIW_R_SectionSelectByStcode();
                uspGetStcode.fldstcode = stcode;
                uspGetStcode.fldyear = year;
                uspGetStcode.fldtype = type;
                dt = uspGetStcode.ExecDataTable();
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_R_Section", "GetRSCode", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetRSCode", "");
            }

        }
    }
}
