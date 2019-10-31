using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  �Ա�[tblEQIA_RDPI_Basedata_Pre]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIA_RDPI_Basedata_Pre : BaseRule
    { 
        //���
        private string eqiType = "eqia_rd";

        /// <summary>
        /// ��������    ��  �������[tblEQIA_RDPI_Basedata_Pre]��ļ�¼
        /// ������      ��  �ź�
        /// ��������    ��  2009-06-03
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="lstData">Ҫ��ӵ�tblEQIA_RDPI_Basedata_Pre��ʵ������</param>
        /// <param name="input_new">Ҫ��¼��¼��ʱ��</param>
        /// <returns>�����Ƿ�ɹ�</returns>
        public bool InsertAll(List<tblEQIA_RDPI_Basedata_Pre> lstData, tblEQI_InputDate input_new)
        {
            int iRowIndex = 0;
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (iRowIndex = 0; iRowIndex < lstData.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RDPI_Basedata_Pre_Insert uspInsert = new usp_tblEQIA_RDPI_Basedata_Pre_Insert();
                            uspInsert.ReceiveParameter(lstData[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("��Ӽ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("�����ݿ�����ʧ��", "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "�������кţ�" + (iRowIndex + 1) + "������ԭ��ͬһ���ͬһʱ��ͬһ��Ŀ�������Ѿ�����",
                            "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("ִ��Sql���ʧ��", "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("д�����ݿ�ʧ��", "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                }
            }
        }



        /// <summary>
        /// ��������    ��  �������[tblEQIA_RDPI_Basedata_Pre]��ļ�¼
        /// ������      ��  ������
        /// ��������    ��  2017-07-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="lstData">Ҫ��ӵ�tblEQIA_RDPI_Basedata_Pre��ʵ������</param>
      
        /// <returns>�����Ƿ�ɹ�</returns>
        public bool InsertAll(List<tblEQIA_RDPI_Basedata_Pre> lstData)
        {
            int iRowIndex = 0;
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (iRowIndex = 0; iRowIndex < lstData.Count; iRowIndex++)
                        {
                            usp_tblEQIA_RDPI_Basedata_Pre_Insert uspInsert = new usp_tblEQIA_RDPI_Basedata_Pre_Insert();
                            uspInsert.ReceiveParameter(lstData[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("��Ӽ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("�����ݿ�����ʧ��", "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "�������кţ�" + (iRowIndex + 1) + "������ԭ��ͬһ���ͬһʱ��ͬһ��Ŀ�������Ѿ�����",
                            "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("ִ��Sql���ʧ��", "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("д�����ݿ�ʧ��", "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIA_RDPI_Basedata_Pre", "InsertAll", "");
                    }
                }
            }
        }
    }
}
