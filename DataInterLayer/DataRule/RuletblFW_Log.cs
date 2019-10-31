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
    /// ��������    ��  �Ա�[tblFW_Log]�����ݲ���
    /// ������      ��  Auto Generator
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblFW_Log : BaseRule
    {
        /// <summary>
        /// ��������    ��  ���[tblFW_Log]��ļ�¼
        /// ������      ��  Auto Generator
        /// ��������    ��  2009-04-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="objInsert">��Ҫ��ӵ�ʵ����</param>
        /// <returns>����������¼��PK������ֵ</returns>
        public long Insert(tblFW_Log objInsert)
        {
            try
            {
                usp_tblFW_Log_Insert uspInsert = new usp_tblFW_Log_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery(1);
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("�����¼�¼ʧ��");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("�����ݿ�����ʧ��", "RuletblFW_Log", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblFW_Log", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("ִ��Sql���ʧ��", "RuletblFW_Log", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblFW_Log", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// ��������    ��  ������־
        /// ������      ��  ������
        /// ��������    ��  2009-04-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="dateStart">���ݵĿ�ʼ���ڣ�ֻ�������ڲ��ּ��ɣ�</param>
        /// <param name="dateEnd">���ݵĽ������ڣ�ֻ�������ڲ��ּ��ɣ�</param>
        /// <returns>true / false</returns>
        public bool Backup(DateTime dateStart, DateTime dateEnd)
        {
            try
            {
                bool bResult = false;
                usp_tblFW_Log_Backup uspBack = new usp_tblFW_Log_Backup();
                uspBack.fldDate_Start = dateStart;
                uspBack.fldDate_End = dateEnd;
                uspBack.result = bResult;
                uspBack.ExecNoQuery(1);
                bResult = uspBack.result;
                return bResult;
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("�����ݿ�����ʧ��", "RuletblFW_Log", "Backup",
                    "dateStart��" + dateStart.ToString("yyyy-MM-dd") + "��dateEnd��" + dateEnd.ToString("yyyy-MM-dd"));
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("ִ��Sql���ʧ��", "RuletblFW_Log", "Backup",
                    "dateStart��" + dateStart.ToString("yyyy-MM-dd") + "��dateEnd��" + dateEnd.ToString("yyyy-MM-dd"));
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_Log", "Backup",
                    "dateStart��" + dateStart.ToString("yyyy-MM-dd") + "��dateEnd��" + dateEnd.ToString("yyyy-MM-dd"));
            }
        }















        /// <summary>
        /// ��������    ��  д�������־
        /// ������      ��  ������
        /// ��������    ��  2009-04-18
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="iModalID">����ģ��ID����CheckRight�������أ�0Ϊ�Ҳ�����</param>
        /// <param name="sContent">��������</param>
        public void WriteLog(int iModalID, string sContent, int UserID, int CityID, string UserHostAddress)
        {
            //if (this.userinfo.UserName == "yzadmin")
            //    return;



            //if (iModalID < 1)
            //    iModalID = 0;
            tblFW_Log objLog = new tblFW_Log();
            objLog.fldModalID = iModalID;
            objLog.fldUserID = UserID;
            objLog.fldCityID = CityID;
            objLog.fldContent = sContent;
            objLog.fldDate_operate = DateTime.Now;
            objLog.fldIPAddress = UserHostAddress;
            RuletblFW_Log ruleLog = new RuletblFW_Log();
            ruleLog.Insert(objLog);



        }



















    }
}
