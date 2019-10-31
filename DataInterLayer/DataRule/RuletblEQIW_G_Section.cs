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
    /// ��������    ��  �Ա�[tblEQIW_G_Section]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIW_G_Section : BaseRule
    {
        /// <summary>
        /// ��������    ��  ������ѡ���д���ȡ��[tblEQIW_G_Section]��ĺ�������
        /// ������      ��  �Ƴ�
        /// ��������    ��  2011-10-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="year">���</param>
        /// <returns>tblEQIW_G_Section</returns>
        public IList<tblEQIW_G_Section> GetRCodeBySTCode(string STCode, string year, string Level, string include)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_G_Section_GetRCodeBySTCode uspGetRCode = new usp_tblEQIW_G_Section_GetRCodeBySTCode();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.year = year;
                uspGetRCode.Level = Convert.ToInt32(Level);
                uspGetRCode.include = Convert.ToInt32(include);
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_G_Section> listAll = new List<tblEQIW_G_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_G_Section objData = new tblEQIW_G_Section();
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
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIW_G_Section", "GetRCodeBySTCode", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIW_G_Section", "GetRCodeBySTCode", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_G_Section", "GetRCodeBySTCode", STCode);
            }
        }



























        /// <summary>
        /// ��������    ��  ���ݳ��д��롢��ݺͶ��漶����[tblEQIW_L_Section]��ļ�¼
        /// ������      ��  ������
        /// ��������    ��  2012-10-23
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="STCode">���д���</param>
        /// <param name="Year">���</param>
        /// <param name="Level">���漶��</param>
        /// <returns>DataTable</returns>
        public DataTable GetByYearAndLevel(string STCode, int Year, short Level)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_G_Section_GetbyYearAndLevel uspByYear = new usp_tblEQIW_G_Section_GetbyYearAndLevel();
                uspByYear.fldSTCode = STCode;
                uspByYear.fldYear = Year;
                uspByYear.fldSLevel = Level;
                tblData = uspByYear.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQIW_G_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQIW_G_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_G_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }
























    }
}
