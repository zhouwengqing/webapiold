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
    /// ��������    ��  �Ա�[tblEQIN_A_Basedata_Pre]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-08-03
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblEQIN_A_Basedata_Pre : BaseRule
    {
        //���
        private string eqiType = "eqin_a";


        /// <summary>
        /// ��������    ��  �������[tblEQIN_A_BaseData_Pre]��ļ�¼
        /// ������      ��  �ź�
        /// ��������    ��  2009-08-03
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="lstData">Ҫ��ӵ�tblEQIN_A_BaseData_Pre��ʵ������</param>
        /// <param name="input_new">Ҫ��¼��¼��ʱ��</param>
        /// <param name="input_old">Ҫ�޸ĵ�ԭ����¼��ʱ��</param>
        /// <returns>�����Ƿ�ɹ�</returns>
        public bool InsertAll(List<tblEQIN_A_BaseData_Pre> lstData, tblEQI_InputDate input_new, tblEQI_InputDate input_old)
        {
            int iRowIndex = 0;
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (iRowIndex = lstData.Count - 1; iRowIndex >= 0; iRowIndex--)
                        {
                            usp_tblEQIN_A_Basedata_Pre_Insert uspInsert = new usp_tblEQIN_A_Basedata_Pre_Insert();
                            uspInsert.ReceiveParameter(lstData[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("��Ӽ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                        }
                        RuletblEQI_InputDate Rule_inputdate = new RuletblEQI_InputDate();                    
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("�����ݿ�����ʧ��", "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "�������кţ�" + (iRowIndex + 1) + "������ԭ��ͬһ����ͬһ����ͬһʱ��������Ѿ�����",
                            "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("ִ��Sql���ʧ��", "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("д�����ݿ�ʧ��", "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                }
            }
        }


    }
}
