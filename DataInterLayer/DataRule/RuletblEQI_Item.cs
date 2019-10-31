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
    /// ��������    ��  �Ա�[RuletblEQI_Item]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2015-03-17
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQI_Item : BaseRule
    { 

        /// <summary>
        /// ��������    ��  ����ҵ�����ͻ�ȡ��Ӧ�ļ��������Ϣ
        /// ������      ��  du
        /// ��������    ��  2015-03-11
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetItemInfo(string strType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblItemInfo_GIS usp = new usp_tblItemInfo_GIS();
                usp.Type = strType;
                tblData = usp.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_Item", "GetItemInfo", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_Item", "GetItemInfo", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Item", "GetItemInfo", "");
            }
        }

        /// <summary>
        /// ��������    ��  ����ҵ�����ͻ�ȡ��Ӧ�ļ����������Ϣ
        /// ������      ��  du
        /// ��������    ��  2015-04-3
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetItemGroupInfo(string strType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblItemGroupInfo_GIS usp = new usp_tblItemGroupInfo_GIS();
                usp.Type = strType;
                tblData = usp.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_Item", "GetItemGroupInfo", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_Item", "GetItemGroupInfo", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Item", "GetItemGroupInfo", "");
            }
        }

    }
}
