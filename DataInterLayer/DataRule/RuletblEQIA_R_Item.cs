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
    /// ��������    ��  �Ա�[tblEQIA_R_Item]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_R_Item : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblEQIA_R_Item]������м�¼
        /// ������      ��  ZCH
        /// ��������    ��  2012-08-20
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllforGisData()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_getEQIA_R_ItemforGis uspByAll = new usp_getEQIA_R_ItemforGis();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_Item";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIA_R_Item", "GetAllforGisData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIA_R_Item", "GetAllforGisData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Item", "GetAllforGisData", "");
            }
        }



        /// <summary>
        /// ��������    ��  ������Ŀ����ȡ��[tblEQIA_R_Item]��Ĳ��ּ�¼
        /// ������      ��  �ź�
        /// ��������    ��  2009-05-27
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iCode">��Ŀ����</param>
        /// <returns>tblEQIA_R_Item</returns>
        public tblEQIA_R_Item ByItemCode(string iCode)
        {
            try
            {
                usp_tblEQIA_R_Item_ByItemCode uspByItemCode = new usp_tblEQIA_R_Item_ByItemCode();
                uspByItemCode.fldItemCode = iCode;
                DataTable tblData = uspByItemCode.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_Item objData = new tblEQIA_R_Item();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
        }


        /// <summary>
        /// ��������    ��  ������Ŀ����ȡ�����ӱ�Ĳ��ּ�¼  ���Ǹ�ͨ�õķ���
        /// ������      ��  ������
        /// ��������    ��  2017-06-02
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iCode">��Ŀ����</param>
        /// <returns>DataTable</returns>
        public tblEQIA_R_Item ByItemCodes(string iCode, string sbtype, string where)
        {
            try
            {
                usp_tblEQI_Com_Item_ByItemCode uspByItemCode = new usp_tblEQI_Com_Item_ByItemCode();
                uspByItemCode.fldItemCode = iCode;
                uspByItemCode.fldSbtype = sbtype;
                uspByItemCode.strsql = where;
                DataTable tblData = uspByItemCode.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_Item objData = new tblEQIA_R_Item();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("ȡ�õ�����¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
        }

        /// <summary>
        /// ��������    ��  ���[tblEQIA_R_Item]���Լ���Ŀ��׼ֵ��¼
        /// ������      ��  Ҧ��
        /// ��������    ��  2017-03-13
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetItemAndSTDDataByItemCode(string itemCode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Item_GetDaySTDValueByItemCode uspByAll = new usp_tblEQIA_R_Item_GetDaySTDValueByItemCode();
                uspByAll.fldItemCode = itemCode;
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_Item";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
        }


        /// <summary>
        /// ��������    ��  ���[tblEQIA_R_Item]������м�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-28
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllData()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Item_ByAll uspByAll = new usp_tblEQIA_R_Item_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_Item";
                    return tblData;
                }
                else
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuletblEQIA_R_Item", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuletblEQIA_R_Item", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Item", "GetAllData", "");
            }
        }
    }
}
