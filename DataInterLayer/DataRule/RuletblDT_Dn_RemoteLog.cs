using System;
using System.Data.SqlClient;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// ��������    ��  ��Զ�̵���־�����
    /// ������      ��  ������
    /// ��������    ��  2010-01-30
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuletblDT_Dn_RemoteLog : BaseRule
    {
        ///// <summary>
        ///// ��������    ��  ��ӻ�����Ϣ�����־��¼
        ///// ������      ��  ������
        ///// ��������    ��  2010-01-30
        ///// �޸���      ��
        ///// �޸�����    ��
        ///// �޸�ԭ��    ��
        ///// </summary>
        ///// <param name="objInsert">��Ҫ��ӵ�ʵ����</param>
        ///// <returns>����������¼��PK������ֵ</returns>
        //public int Insert(RemoteBaseLog objInsert, SqlConnection _conn, SqlTransaction _tran)
        //{
        //    try
        //    {
        //        usp_DT_Dn_InsertRemoteBaseLog uspInsert = new usp_DT_Dn_InsertRemoteBaseLog();
        //        uspInsert.ReceiveParameter(objInsert);
        //        return uspInsert.ExecNoQuery(_conn, _tran);
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new InsertException("�����ݿ�����ʧ��", "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //    catch (DBPKException e)
        //    {
        //        throw new InsertPKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new InsertException("ִ��Sql���ʧ��", "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        throw new InsertException(e.Message, "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //}
    }
}
