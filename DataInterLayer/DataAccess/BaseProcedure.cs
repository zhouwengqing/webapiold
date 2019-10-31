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
    /// 所有的数据访问类的基类
    /// </summary>
    public abstract class BaseProcedure
    {
        #region 成员

        protected SqlParameter parameterReturnValue;
        /// <summary>
        /// 存储过程返回值的参数
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
        /// 数据库连接
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
        /// Sql事务
        /// </summary>
        public SqlTransaction ReturnTran
        {
            get
            {
                return m_tran;
            }
        }

        #endregion

        #region 构造函数和初始化

        public BaseProcedure()
        {
//#if DEBUG
//            //查找调用当前类的是不是DDYZ.Ensis.Rule.DataRule，如果不是抛出异常
//            StackTrace trace = new StackTrace();
//            if (trace.GetFrame(2).GetMethod().DeclaringType.FullName != "System.RuntimeTypeHandle" &&
//                (trace.GetFrame(2).GetMethod().DeclaringType.Namespace == null ||
//                !(
//                    trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.DataSource.DataAccess") >= 0 ||
//                    trace.GetFrame(2).GetMethod().DeclaringType.Namespace.IndexOf("DDYZ.Ensis.Rule.DataRule") >= 0)
//                )
//                )
//            {
//                throw new Exception("该组件只能被DataRule组件调用");
//            }
//#endif
        }

        /// <summary>
        /// 初始化参数
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
        /// 存储过程接受参数赋值。
        /// </summary>
        /// <param name="dtParameter">包含参数信息的 DataTable</param>
        public void ReceiveParameter(DataTable dtParameter)
        {
            try
            {
                // 枚举命令对象的参数集合
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    // 去掉参数名的前缀"@"
                    string columnName = pmtName.Substring(1, pmtName.Length - 1);
                    // 通过枚举参数化表格的列信息，如果找到统一名称的列
                    // 就把该列的值赋給参数的值
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
                throw new DBException("初始化存储过程参数发生错误",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter(DataTable dtParameter)", "");
            }
        }

        /// <summary>
        /// 存储过程接受参数赋值。
        /// </summary>
        /// <param name="objParameter">包含参数信息的实体对象Entity</param>
        public void ReceiveParameter(object objEntity)
        {
            try
            {
                // 得到该实体对象的具体类型信息
                Type objType = objEntity.GetType(); 
                string isb = "";
                // 枚举命令对象的参数集合
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    // 去掉参数名的前缀"@"
                    string columnName = pmtName.Substring(1, pmtName.Length - 1);

                    // 从实体对象中去检索是否具有相同名称的公有属性
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
                throw new DBException("初始化存储过程参数发生错误",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter(object objEntity)", "");
            }
        }

        /// <summary>
        /// 存储过程接受参数赋值-老（为更新存储过程用）
        /// </summary>
        /// <param name="objEntity">包含参数信息的实体对象Entity（老）</param>
        public void ReceiveParameter_Old(object objEntity)
        {
            try
            {
                // 得到该实体对象的具体类型信息
                Type objType = objEntity.GetType();
                string isb = "";
                // 枚举命令对象的参数集合
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    if (pmtName.ToLower().StartsWith("@old_"))
                    {
                        // 去掉参数名的前缀"@"
                        string columnName = pmtName.Substring(5);
                        // 从实体对象中去检索是否具有相同名称的公有属性
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
                throw new DBException("初始化存储过程参数发生错误",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter_Old(object objEntity)", "");
            }
        }

        /// <summary>
        /// 存储过程接受参数赋值-新（为更新存储过程用）
        /// </summary>
        /// <param name="objEntity">包含参数信息的实体对象Entity（新）</param>
        public void ReceiveParameter_New(object objEntity)
        {
            try
            {
                // 得到该实体对象的具体类型信息
                Type objType = objEntity.GetType();
                // 枚举命令对象的参数集合
                foreach (SqlParameter pmt in this.m_cmd.Parameters)
                {
                    string pmtName = pmt.ParameterName;
                    if (pmtName.ToLower().StartsWith("@new_"))
                    {
                        // 去掉参数名的前缀"@"
                        string columnName = pmtName.Substring(5);
                        // 从实体对象中去检索是否具有相同名称的公有属性
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
                throw new DBException("初始化存储过程参数发生错误",
                    trace.GetFrame(1).GetMethod().DeclaringType.FullName,
                    "ReceiveParameter_Old(object objEntity)", "");
            }
        }
        #endregion

        #region 方法

        #region 取得数据


        /// <summary>
        /// 取得连接字符串
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
        /// 取得数据
        /// </summary>
        /// <param name="iConn">连接字符串类型</param>
        /// <returns>DataTable</returns>
        public DataTable ExecDataTable( int iConn=0)
        {
           return ExecDataTable("", iConn);
            //return iConn.Length == 1 ? ExecDataTable("", iConn[0]) : ExecDataTable("");
        }

        /// <summary>
        /// 取得数据
        /// </summary>
        /// <param name="tableName">返回DataTable的名称</param>
        /// <param name="iConn">连接字符串类型</param>
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
        /// 取得数据
        /// </summary>
        /// <param name="iConn">连接字符串类型</param>
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
        /// 取得数据
        /// </summary>
        /// <param name="tableName">返回DataSet的表名称</param>
        /// <param name="iConn">连接字符串类型</param>
        /// <returns>DataSet</returns>
        public DataSet ExecDataSet(string tableName,int iConn=0)
        {  
            DataTable dtData = ExecDataTable(tableName, iConn);
            DataSet dsData = new DataSet();
            dsData.Tables.Add(dtData);
            return dsData;
        }

        /// <summary>
        /// 取得DataTable的第一行第一列
        /// </summary>
        /// <param name="iConn">连接字符串类型</param>
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
        /// 取得数据
        /// </summary>
        /// <param name="iConn">连接字符串类型</param>
        /// <returns></returns>
        public XmlDocument ExecXmlDom( int iConn=0)
        {
            return ExecXmlDom("ROOT", iConn);
        }

        /// <summary>
        /// 取得数据
        /// </summary>
        /// <param name="rootName">根节点名称</param>
        /// <param name="iConn">连接字符串类型</param>
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

        #region 执行查询

        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="iConn">连接字符串类型</param>
        /// <returns> 受影响的行数</returns>
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
        /// 执行查询(可选择连接的数据库)
        /// </summary>
        /// <param name="iConn">连接字符串类型</param>
        /// <returns> 受影响的行数</returns>
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

        #region 事务操作

        /// <summary>
        /// 执行查询-启用事物
        /// </summary>
        /// <param name="_conn">要执行事务的sqlconnection，如果是第一个执行则传入null</param>
        /// <param name="_tran">要执行事务的sqltransaction，如果是第一个执行则传入null</param>
        /// <param name="iConn">连接字符串类型</param>
        /// <returns>int 影响的行数(-1代表执行失败,-10代表违反PK约束)</returns>
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
                #region 新建连接和事物

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
        /// 事务提交
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
        /// 事务回滚
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


        #region 出错时的回滚和关闭连接

        /// <summary>
        /// 回滚数据库事务
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
        /// 关闭数据库连接
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

        #region 清理操作
        public void ClearParams()
        {
            this.m_cmd.Parameters.Clear();
        }
        #endregion

        #region 未使用的处理异常的方法
        /*
        /// <summary>
        /// 处理发生的异常
        /// </summary>
        private void HandlerException(System.Exception exception)
        {
            WriteDataLog(exception.Message);
            throw exception;
        }

        /// <summary>
        /// 写入错误日志
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
