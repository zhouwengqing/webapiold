using System;
using System.Data;
using System.Xml;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using DDYZ.Ensis.Library.Exception.DataBase;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    /// <summary>
    /// ���е����ݷ�����Ļ���
    /// </summary>
    public abstract class BaseProcedure
    {
        #region ��Ա

        protected SqlParameter parameterReturnValue;
        /// <summary>
        /// �洢���̷���ֵ�Ĳ���
        /// </summary>
        public int ReturnValue
        {
            get
            {
                return (System.Int32)this.parameterReturnValue.Value;
            }
        }

        protected SqlCommand m_cmd;

        protected SqlConnection m_conn;
        /// <summary>
        /// ���ݿ�����
        /// </summary>
        public SqlConnection ReturnConn
        {
            get
            {
                return m_conn;
            }
        }

        protected SqlTransaction m_tran;
        /// <summary>
        /// Sql����
        /// </summary>
        public SqlTransaction ReturnTran
        {
            get
            {
                return m_tran;
            }
        }

        #endregion

        #region ���캯���ͳ�ʼ��

        public BaseProcedure()
        {
//#if DEBUG
//            //���ҵ��õ�ǰ����ǲ���DDYZ.Ensis.Rule.DataRule����������׳��쳣
//            StackTrace trace = new StackTrace();
//            if (trace.GetFrame(2).GetMethod().DeclaringType.FullName != "System.RuntimeTypeHandle" &&
//                (trace.GetFrame(2).GetMethod().DeclaringType.Namespace == null ||
//                !(
//                    trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.DataSource.DataAccess") >= 0 ||
//                    trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Rule.DataRule") >= 0)
//                )
//                )
//            {
//                throw new Exception("�����ֻ�ܱ�DataRule�������");
//            }
//#endif
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        /// <param name="spName"></param>
        protected void InitCommand(string spName)
        {
            this.m_cmd = new SqlCommand();
            this.m_cmd.CommandText = spName;
            this.m_cmd.CommandType = CommandType.StoredProcedure;
            this.m_cmd.Parameters.Clear();
            //--------------------------------------------------------
            this.parameterReturnValue = new SqlParameter();
            this.parameterReturnValue.ParameterName = "@ReturnValue";
            this.parameterReturnValue.SqlDbType = SqlDbType.Int;
            this.parameterReturnValue.Size = 4;
            this.parameterReturnValue.Direction = ParameterDirection.ReturnValue;
            this.m_cmd.Parameters.Add(this.parameterReturnValue);
            //--------------------------------------------------------
        }

        /// <summary>
        /// �洢���̽��ܲ�����ֵ��
        /// </summary>
        /// <param name="dtParameter">����������Ϣ�� DataTable</param>
        public void ReceiveParameter(DataTable dtParameter)
        {
            try
            {
                // ö���������Ĳ�������
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    // ȥ����������ǰ׺"@"
                    string columnName = pmtName.Substring(1, pmtName.Length - 1);
                    // ͨ��ö�ٲ�������������Ϣ������ҵ�ͳһ���Ƶ���
                    // �ͰѸ��е�ֵ���o������ֵ
                    foreach (DataColumn column in dtParameter.Columns)
                    {
                        if (columnName.ToLower() == column.ColumnName.ToLower())
                        {
                            pmt.Value = dtParameter.Rows[0][columnName];
                            break;
                        }
                    } // foreach(DataColumn column in dtParameter.Columns)
                } // foreach(SqlParameter pmt in this.m_cmd.Parameters)
            }
            catch (Exception e)
            {
                StackTrace trace = new StackTrace();
                throw new DBException("��ʼ���洢���̲�����������",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter(DataTable dtParameter)", "");
            }
        }

        /// <summary>
        /// �洢���̽��ܲ�����ֵ��
        /// </summary>
        /// <param name="objParameter">����������Ϣ��ʵ�����Entity</param>
        public void ReceiveParameter(object objEntity)
        {
            try
            {
                // �õ���ʵ�����ľ���������Ϣ
                Type objType = objEntity.GetType(); 
                string isb = "";
                // ö���������Ĳ�������
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    // ȥ����������ǰ׺"@"
                    string columnName = pmtName.Substring(1, pmtName.Length - 1);

                    // ��ʵ�������ȥ�����Ƿ������ͬ���ƵĹ�������
                    PropertyInfo property = objType.GetProperty(columnName);
                    if (property != null)
                    {
                        pmt.Value = property.GetValue(objEntity, null);
                        isb += columnName + "='" + pmt.Value + "' and ";
                    }
                } // foreach(SqlParameter pmt in this.m_cmd.Parameters)
            }
            catch (Exception e)
            {
                StackTrace trace = new StackTrace();
                throw new DBException("��ʼ���洢���̲�����������",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter(object objEntity)", "");
            }
        }

        /// <summary>
        /// �洢���̽��ܲ�����ֵ-�ϣ�Ϊ���´洢�����ã�
        /// </summary>
        /// <param name="objEntity">����������Ϣ��ʵ�����Entity���ϣ�</param>
        public void ReceiveParameter_Old(object objEntity)
        {
            try
            {
                // �õ���ʵ�����ľ���������Ϣ
                Type objType = objEntity.GetType();
                string isb = "";
                // ö���������Ĳ�������
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    if (pmtName.ToLower().StartsWith("@old_"))
                    {
                        // ȥ����������ǰ׺"@"
                        string columnName = pmtName.Substring(5);
                        // ��ʵ�������ȥ�����Ƿ������ͬ���ƵĹ�������
                        PropertyInfo property = objType.GetProperty(columnName);
                        if (property != null)
                        {
                            pmt.Value = property.GetValue(objEntity, null);
                            isb += columnName + "='" + pmt.Value + "' and ";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                StackTrace trace = new StackTrace();
                throw new DBException("��ʼ���洢���̲�����������",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter_Old(object objEntity)", "");
            }
        }

        /// <summary>
        /// �洢���̽��ܲ�����ֵ-�£�Ϊ���´洢�����ã�
        /// </summary>
        /// <param name="objEntity">����������Ϣ��ʵ�����Entity���£�</param>
        public void ReceiveParameter_New(object objEntity)
        {
            try
            {
                // �õ���ʵ�����ľ���������Ϣ
                Type objType = objEntity.GetType();
                // ö���������Ĳ�������
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    if (pmtName.ToLower().StartsWith("@new_"))
                    {
                        // ȥ����������ǰ׺"@"
                        string columnName = pmtName.Substring(5);
                        // ��ʵ�������ȥ�����Ƿ������ͬ���ƵĹ�������
                        PropertyInfo property = objType.GetProperty(columnName);
                        if (property != null)
                        {
                            pmt.Value = property.GetValue(objEntity, null);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                StackTrace trace = new StackTrace();
                throw new DBException("��ʼ���洢���̲�����������",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter_Old(object objEntity)", "");
            }
        }
        #endregion

        #region ����

        #region ȡ������


        /// <summary>
        /// ȡ�������ַ���
        /// </summary>
        /// <param name="ICon"></param>
        /// <returns></returns>
        public string GetConnString(int ICon)
        {
            switch (ICon)
            {
                case 1:
                    return DataAccessConfig.ConnString_LAP;
                case 2:
                    return DataAccessConfig.ConnString_PIS;
                case 3:
                    return DataAccessConfig.ConnString_Report;
                case 4:
                    return DataAccessConfig.ConnString_Middle;
                case 5:
                    return DataAccessConfig.ConnString_Temporary_Middle;
                case 6:
                    return DataAccessConfig.ConnString_PORTAL4;
                default:
                    return DataAccessConfig.ConnString;
            }

        }


        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns>DataTable</returns>
        public DataTable ExecDataTable( int iConn=0)
        {
           return ExecDataTable("", iConn);
            //return iConn.Length == 1 ? ExecDataTable("", iConn[0]) : ExecDataTable("");
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="tableName">����DataTable������</param>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns>DataTable</returns>
        public DataTable ExecDataTable(string tableName,int iConn=0)
        {

            string sConnStr = GetConnString(iConn); 

            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                DataTable dtData = new DataTable();
                try
                {
                    this.m_cmd.Connection = conn;
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(m_cmd);
                    sqlAdapter.SelectCommand.CommandTimeout = 3600;
                    sqlAdapter.Fill(dtData);
                    if (tableName != "")
                        dtData.TableName = tableName;
                     
                }
                catch (InvalidOperationException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBOpenException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecDataTable(string tableName)", tableName);
                }
                catch (SqlException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBQueryException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecDataTable(string tableName)", tableName);
                }
                catch (System.Exception e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecDataTable(string tableName)", tableName);
                }
                return dtData;
            }
        }
        
        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns>DataSet</returns>
        public DataSet ExecDataSet(int iConn=0)
        { 
            string sConnStr = GetConnString(iConn); 
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                DataSet dsData = new DataSet();
                try
                {
                    this.m_cmd.Connection = conn;
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(m_cmd);
                    sqlAdapter.SelectCommand.CommandTimeout = 3600;
                    sqlAdapter.Fill(dsData);

                }
                catch (InvalidOperationException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBOpenException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecDataTable(string tableName)", "");
                }
                catch (SqlException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBQueryException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecDataTable(string tableName)", "");
                }
                catch (System.Exception e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecDataTable(string tableName)", "");
                }
                return dsData;
            }
        }
        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="tableName">����DataSet�ı�����</param>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns>DataSet</returns>
        public DataSet ExecDataSet(string tableName,int iConn=0)
        {  
            DataTable dtData = ExecDataTable(tableName, iConn);
            DataSet dsData = new DataSet();
            dsData.Tables.Add(dtData);
            return dsData;
        }

        /// <summary>
        /// ȡ��DataTable�ĵ�һ�е�һ��
        /// </summary>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns>object</returns>
        public object ExecScalar(  int  iConn=0)
        { 
            string sConnStr = GetConnString(iConn); 
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                object oResult = null;
                try
                {
                    conn.Open();
                    this.m_cmd.Connection = conn;
                    oResult = this.m_cmd.ExecuteScalar();

                }

                catch (InvalidOperationException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBOpenException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecScalar()", "");
                }
                catch (SqlException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBQueryException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecScalar()", "");
                }
                catch (System.Exception e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecScalar()", "");
                }
                return oResult;
            }
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns></returns>
        public XmlDocument ExecXmlDom( int iConn=0)
        {
            return ExecXmlDom("ROOT", iConn);
        }

        /// <summary>
        /// ȡ������
        /// </summary>
        /// <param name="rootName">���ڵ�����</param>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns>Xml</returns>
        public XmlDocument ExecXmlDom(string rootName, int iConn=0)
        { 
            string sConnStr = GetConnString(iConn); 
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                string strXml = "";
                try
                {
                    m_cmd.Connection = conn;
                    conn.Open();
                    XmlReader read = m_cmd.ExecuteXmlReader();
                    while (read.ReadState != ReadState.EndOfFile)
                    {
                        read.MoveToContent();
                        strXml += read.ReadOuterXml();
                    }

                }
                catch (InvalidOperationException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBOpenException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecXmlDom(string rootName)", "");
                }
                catch (SqlException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBQueryException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecXmlDom(string rootName)", "");
                }
                catch (System.Exception e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecXmlDom(string rootName)", "");
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml("<" + rootName + ">" + strXml + "</" + rootName + ">");
                return xmlDoc;
            }
        }

        #endregion

        #region ִ�в�ѯ

        /// <summary>
        /// ִ�в�ѯ
        /// </summary>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns> ��Ӱ�������</returns>
        public int ExecNoQuery(  int iConn=0)
        { 
            string sConnStr = GetConnString(iConn); 
            using (SqlConnection conn = new SqlConnection(sConnStr))
            {
                int iResult = 0;
                try
                {
                    conn.Open();
                    this.m_cmd.Connection = conn;
                    iResult = this.m_cmd.ExecuteNonQuery();

                }

                catch (InvalidOperationException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBOpenException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery()", "");
                }
                catch (SqlException e)
                {
                    if (e.Number == 2627 || e.Number == 2601)
                    {
                        StackTrace trace = new StackTrace();
                        throw new DBPKException(e.Message,
                            trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                            "ExecNoQuery()", "");
                    }
                    else
                    {
                        StackTrace trace = new StackTrace();
                        throw new DBQueryException(e.Message,
                            trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                            "ExecNoQuery()", "");
                    }
                }
                catch (System.Exception e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery()", "");
                }
                return iResult;
            }
        }


        /// <summary>
        /// ִ�в�ѯ(��ѡ�����ӵ����ݿ�)
        /// </summary>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns> ��Ӱ�������</returns>
        protected int ExecNoQuery(string sDataBase )
        { 
            string sConnStr = DataAccessConfig.ConnStringConfig;
            using (SqlConnection conn = new SqlConnection(sConnStr.Replace("[database]", sDataBase)))
            {
                int iResult = 0;
                try
                {
                    conn.Open();
                    this.m_cmd.Connection = conn;
                    iResult = this.m_cmd.ExecuteNonQuery();

                }

                catch (InvalidOperationException e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBOpenException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery()", "");
                }
                catch (SqlException e)
                {
                    if (e.Number == 2627)
                    {
                        StackTrace trace = new StackTrace();
                        throw new DBPKException(e.Message,
                            trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                            "ExecNoQuery()", "");
                    }
                    else
                    {
                        StackTrace trace = new StackTrace();
                        throw new DBQueryException(e.Message,
                            trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                            "ExecNoQuery()", "");
                    }
                }
                catch (System.Exception e)
                {
                    StackTrace trace = new StackTrace();
                    throw new DBException(e.Message,
                        trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery()", "");
                }
                return iResult;
            }
        }
        #endregion

        #region �������

        /// <summary>
        /// ִ�в�ѯ-��������
        /// </summary>
        /// <param name="_conn">Ҫִ�������sqlconnection������ǵ�һ��ִ������null</param>
        /// <param name="_tran">Ҫִ�������sqltransaction������ǵ�һ��ִ������null</param>
        /// <param name="iConn">�����ַ�������</param>
        /// <returns>int Ӱ�������(-1����ִ��ʧ��,-10����Υ��PKԼ��)</returns>
        public int ExecNoQuery(SqlConnection _conn, SqlTransaction _tran, int iConn=0)
        {
            int iResult = 0;
            if (_conn != null && _conn.State != ConnectionState.Closed && _tran != null)
            {
                m_conn = _conn;
                m_tran = _tran;
            }
            else
            {
                #region �½����Ӻ�����

                string sConnStr = GetConnString(iConn);
                //string sConnStr = iConn.Length == 1 ? DataAccessConfig.ConnString_LAP : DataAccessConfig.ConnString;
                SqlConnection conn = new SqlConnection(sConnStr);
                try
                {
                    conn.Open();
                    m_conn = conn;
                    m_tran = m_conn.BeginTransaction();
                }
                catch (InvalidOperationException e)
                {
                    this.RollBackOnError();
                    this.Close();
                    StackTrace trace = new StackTrace();
                    throw new DBOpenException(e.Message, trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery(SqlConnection _conn, SqlTransaction _tran)", "");
                }
                catch (SqlException e)
                {
                    this.RollBackOnError();
                    this.Close();
                    StackTrace trace = new StackTrace();
                    throw new DBQueryException(e.Message, trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery(SqlConnection _conn, SqlTransaction _tran)", "");
                }
                #endregion
            }
            try
            {
                m_cmd.Connection = m_conn;
                m_cmd.Transaction = m_tran;
                iResult = m_cmd.ExecuteNonQuery();

            }
            catch (InvalidOperationException e)
            {
                this.RollBackOnError();
                this.Close();
                StackTrace trace = new StackTrace();
                throw new DBOpenException(e.Message, trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ExecNoQuery(SqlConnection _conn, SqlTransaction _tran)", "");
            }
            catch (SqlException e)
            {
                this.RollBackOnError();
                this.Close();
                StackTrace trace = new StackTrace();
                if (e.Number == 2627)
                    throw new DBPKException(e.Message, trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery(SqlConnection _conn, SqlTransaction _tran)", "");
                else
                    throw new DBQueryException(e.Message, trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                        "ExecNoQuery(SqlConnection _conn, SqlTransaction _tran)", "");
            }
            catch (System.Exception e)
            {
                this.RollBackOnError();
                this.Close();
                StackTrace trace = new StackTrace();
                throw new DBException(e.Message, trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ExecNoQuery(SqlConnection _conn, SqlTransaction _tran)", "");
            }
            return iResult;
        }

        /// <summary>
        /// �����ύ
        /// </summary>
        /// <returns>true/false</returns>
        public bool Commit()
        {
            bool bResult = true;
            try
            {
                if (m_conn != null && m_conn.State != ConnectionState.Closed && m_tran != null)
                {
                    m_cmd.Connection = m_conn;
                    m_cmd.Transaction = m_tran;
                    m_cmd.Transaction.Commit();
                }
                else
                {
                    bResult = false;
                }
            }
            catch (InvalidOperationException e)
            {
                this.RollBackOnError();
                StackTrace trace = new StackTrace();
                throw new DBOpenException(e.Message,
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "Commit()", "");
            }
            catch (SqlException e)
            {
                this.RollBackOnError();
                bResult = false;
                StackTrace trace = new StackTrace();
                throw new DBQueryException(e.Message,
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "Commit()", "");
            }
            catch (System.Exception e)
            {
                this.RollBackOnError();
                bResult = false;
                StackTrace trace = new StackTrace();
                throw new DBException(e.Message,
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "Commit()", "");
            }
            finally
            {
                if (m_conn.State != ConnectionState.Closed)
                    m_conn.Close();
            }
            return bResult;
        }

        /// <summary>
        /// ����ع�
        /// </summary>
        /// <returns>true/false</returns>
        public bool RollBack()
        {
            bool bResult = true;
            try
            {
                if (m_conn != null && m_conn.State != ConnectionState.Closed && m_tran != null)
                {
                    m_cmd.Connection = m_conn;
                    m_cmd.Transaction = m_tran;
                    m_cmd.Transaction.Rollback();
                }
                else
                {
                    bResult = false;
                }
            }
            catch (InvalidOperationException e)
            {
                this.RollBackOnError();
                bResult = false;
                StackTrace trace = new StackTrace();
                throw new DBOpenException(e.Message,
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "RollBack()", "");
            }
            catch (SqlException e)
            {
                this.RollBackOnError();
                bResult = false;
                StackTrace trace = new StackTrace();
                throw new DBQueryException(e.Message,
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "RollBack()", "");
            }
            catch (System.Exception e)
            {
                this.RollBackOnError();
                bResult = false;
                StackTrace trace = new StackTrace();
                throw new DBException(e.Message,
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "RollBack()", "");
            }
            finally
            {
                if (m_conn.State != ConnectionState.Closed)
                    m_conn.Close();
            }
            return bResult;
        }


        #region ����ʱ�Ļع��͹ر�����

        /// <summary>
        /// �ع����ݿ�����
        /// </summary>
        protected void RollBackOnError()
        {
            try
            {
                this.m_cmd.Transaction.Rollback();
            }
            catch (Exception e)
            {
                /*
                StackTrace trace = new StackTrace();
                throw new DBException(e.Message,
                    trace.GetFrame(2).GetMethod().DeclaringType.FullName,
                    "RollBackAndCloseConnection()",""); */
            }
        }

        /// <summary>
        /// �ر����ݿ�����
        /// </summary>
        protected void Close()
        {
            try
            {
                if (this.m_conn.State != ConnectionState.Closed)
                    m_conn.Close();
            }
            catch (Exception e)
            {
                /*
                StackTrace trace = new StackTrace();
                throw new DBException(e.Message,
                    trace.GetFrame(2).GetMethod().DeclaringType.FullName,
                    "RollBackAndCloseConnection()",""); */
            }
        }

        #endregion

        #endregion

        #region �������
        public void ClearParams()
        {
            this.m_cmd.Parameters.Clear();
        }
        #endregion

        #region δʹ�õĴ����쳣�ķ���
        /*
        /// <summary>
        /// ���������쳣
        /// </summary>
        private void HandlerException(System.Exception exception)
        {
            WriteDataLog(exception.Message);
            throw exception;
        }

        /// <summary>
        /// д�������־
        /// </summary>
        /// <param name="sError"></param>
        private void WriteDataLog(string sError)
        {
            try
            {
                string sFile = System.Configuration.ConfigurationManager.AppSettings["DbLogFile"] + "sqllog.txt";
                if (System.IO.File.Exists(sFile) == false)
                    System.IO.File.Create(sFile);
                using (System.IO.FileStream fs = System.IO.File.Open(sFile, System.IO.FileMode.Append, System.IO.FileAccess.Write))
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(fs);
                    sw.WriteLine("Sql Error occured at " + System.DateTime.Now.ToString());
                    sw.WriteLine(sError);
                    sw.Close();
                }
            }
            catch { }
        }
        */
        #endregion

        #endregion
    }
}
