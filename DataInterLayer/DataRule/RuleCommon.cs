using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Lib.sql;
using System.Reflection;
using System.Text.RegularExpressions;
using DDYZ.Ensis.Presistence.DataEntity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Configuration;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  通用的数据操作
    /// 创建者      ：  马立军
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuleCommon : BaseRule
    {
        public RuleCommon()
        {
        }

        /// <summary>
        /// 功能描述    ：  获得连接字符串
        /// 创建者      ：  马立军
        /// 创建日期    ：  2010-02-03
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns></returns>
        public string GetConnectString()
        {
            return DataAccessConfig.ConnString;
        }






        /// <summary>
        /// 根据特定数据库，执行SQL语句，返回DataTable，用于独立的API
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable SqlQueryForDataTatable(string dbName, string sql)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString.ToString();

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            conn.Close();
            conn.Dispose();
            return table;
        }







        /// <summary>
        /// 插入上传文件
        /// </summary>
        /// <param name="prdName">存储过程名</param>
        /// <param name="lstParameters">存储过程用到的参数</param>
        public int Upload_IstallorUpdate(string fldReport_Name,string fldReport_Type,string fldRName,string fldUserID,string fldTime,string fldPath,string fldFileName)
        {
            try
            {
                updatetblReportArchive uspProcess = new updatetblReportArchive();
                uspProcess.fldReport_Name = fldReport_Name;
                uspProcess.fldReport_Type = fldReport_Type;
                uspProcess.fldRName = fldRName;
                uspProcess.fldUserID = fldUserID;
                uspProcess.fldTime = fldTime;
                uspProcess.fldPath = fldPath;
                uspProcess.fldFileName = fldFileName;
                int index =uspProcess.ExecNoQuery();
                return index;
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + fldReport_Name + "；lstParameters:" + fldReport_Name.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("执行sql语句出错", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + fldReport_Name);
            }
            catch (Exception e)
            {
                throw new DataRuleException(e.Message, "CommonRule", "ExecProcessPrd",
                                            "prdName: " + fldReport_Name);
            }
        }









        /// <summary>
        /// 执行指定的存储过程
        /// </summary>
        /// <param name="prdName">存储过程名</param>
        /// <param name="lstParameters">存储过程用到的参数</param>
        public void ExecProcessPrd(string prdName, List<SqlParameter> lstParameters)
        {
            try
            {
                usp_ExecProcess uspProcess = new usp_ExecProcess(prdName, lstParameters);
                uspProcess.ExecNoQuery();
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName + "；lstParameters:" + lstParameters.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("执行sql语句出错", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
            catch (Exception e)
            {
                throw new DataRuleException(e.Message, "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
        }

        /// <summary>
        /// 执行指定的存储过程
        /// </summary>
        /// <param name="prdName">存储过程名</param>
        /// <param name="lstParameters">存储过程用到的参数</param>
        public int ExecProcessPrd(string prdName, List<SqlParameter> lstParameters, SqlConnection conn, SqlTransaction tran)
        {
            usp_ExecProcess uspProcess = new usp_ExecProcess(prdName, lstParameters, false);
            try
            {
                int iresult = uspProcess.ExecNoQuery(conn, tran);
                return iresult;
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName + "；lstParameters:" + lstParameters.ToString());
            }
            catch (DBPKException e)
            {
                throw new DataRuleException("数据库中已存在相同的数据", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("执行sql语句出错", "CommonRule", "ExecProcessPrd",
                            "prdName: " + prdName);
            }
            catch (Exception e)
            {
                throw new DataRuleException(e.Message, "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
            finally
            {
                uspProcess.ClearParams();
            }
        }

        /// <summary>
        /// 执行指定的存储过程
        /// </summary>
        /// <param name="prdName">存储过程名</param>
        /// <param name="lstParameters">存储过程用到的参数</param>
        /// <param name="strTableName">表名称</param>
        public DataTable ExecProcessPrd(string prdName, List<SqlParameter> lstParameters, string strTableName)
        {
            try
            {
                usp_ExecProcess uspProcess = new usp_ExecProcess(prdName, lstParameters, false);
                return uspProcess.ExecDataTable(strTableName);
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("打开数据库连接出错", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName + "；lstParameters:" + lstParameters.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("执行sql语句出错", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
            catch (Exception e)
            {
                throw new DataRuleException(e.Message, "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
        }





        
 




        public DataTable RunProcedure_V2(string storedProcName, List<SqlParameter> parameters, string tableName, string dbName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dt = new DataTable();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = 3600;
                sqlDA.Fill(dt);
                connection.Close();
                return dt;
            }
        }



       /// <summary>
       /// 功能描述：异步执行sql
       /// 创建  人：周文卿
       /// 创建时间：2018-11-30
       /// </summary>
       /// <param name="callBack">回调</param>
       /// <param name="dbName">链接字符串</param>
       /// <param name="parameters">参数</param>
       /// <param name="storedProcName">存储过程名称</param>

        public  void AsyncExecuteNonQuery(AsyncCallback callBack, string dbName, List<SqlParameter> parameters, string storedProcName)
        {
            //关闭数据库连接要在callback中关闭，因为是异步操作
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection();
                string connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString.ToString();
               

                SqlCommand command = new SqlCommand(storedProcName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    if (parameter != null)
                    {
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                            (parameter.Value == null))
                        {
                            parameter.Value = DBNull.Value;
                        }
                        command.Parameters.Add(parameter);
                    }
                }


                connection.Open();
                command.ExecuteNonQuery(); //开始执行SQL语句
            }
            catch (Exception ex)
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

        }


        public DataTable RunProcedure(string storedProcName, List<SqlParameter> parameters, string tableName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["dbReport"].ConnectionString.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataSet = new DataTable();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = 3600;
                sqlDA.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
        }

        public DataTable RunProcedureSIS(string storedProcName, List<SqlParameter> parameters, string tableName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EMCSIS"].ConnectionString.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataSet = new DataTable();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = 3600;
                sqlDA.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
        }



        public DataSet RunProcedure_DS(string storedProcName, List<SqlParameter> parameters, string tableName, string dbName)
        {
            string connectionString = null;

            if (dbName == "dbReport")
            {
                connectionString = ConfigurationManager.ConnectionStrings["dbReport"].ConnectionString.ToString();
            }
            else
            {
                connectionString = ConfigurationManager.ConnectionStrings["EntityContext"].ConnectionString.ToString();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = 3600;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }






        private static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, List<SqlParameter> parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }







        /// <summary>
        /// 获取存储过程参数列表
        /// </summary>
        /// <param name="prdName"></param>
        /// <returns></returns>
        //public List<SqlParameter> GetProcedureParameters(string prdName)
        //{
        //    //usp_GetTOrPFrame uspFrame = new usp_GetTOrPFrame();
        //    //uspFrame.tablename = prdName;
        //    //uspFrame.type = "P";
        //    //DataTable tblFrame = uspFrame.ExecDataTable();
        //    //if (tblFrame != null)
        //    //{
        //    //    List<SqlParameter> lstParams = new List<SqlParameter>();
        //    //    for (int i = 0; i < tblFrame.Rows.Count; i++)
        //    //    {
        //    //        SqlParameter sqlparam = new SqlParameter();
        //    //        sqlparam.ParameterName = tblFrame.Rows[i]["name"].ToString();
        //    //        sqlparam.SqlDbType = SQLTools.GetSqlDbTypeFromType(tblFrame.Rows[i]["type"].ToString().Trim());
        //    //        sqlparam.Size = int.Parse(tblFrame.Rows[i]["length"].ToString());
        //    //        sqlparam.Direction = (tblFrame.Rows[i]["isoutput"].ToString() == "1" ? ParameterDirection.InputOutput : ParameterDirection.Input);
        //    //        lstParams.Add(sqlparam);
        //    //    }
        //    //    return lstParams;
        //    //}
        //    //return null;
        //}

        /// <summary>
        /// 根据年、业务类型获取所有测点
        /// </summary>
        /// <param name="business"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetAllPointsByBusinessAndYear(string business, string year)
        {
            usp_GetAllBusinessPointsByYearAndBusiness uspFrame = new usp_GetAllBusinessPointsByYearAndBusiness();
            uspFrame.year = year;
            uspFrame.business = business;
            DataTable tblFrame = uspFrame.ExecDataTable();
            if (tblFrame != null)
            {
                return tblFrame;
            }
            return null;
        }

        /// <summary>
        /// 根据日期、业务类型获取所有基础数据
        /// </summary>
        /// <param name="business"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable GetAllBaseDataByBusinessAndDate(string business, string startdate, string enddate)
        {
            usp_GetAllBusinessBaseDataByDateAndBusiness uspFrame = new usp_GetAllBusinessBaseDataByDateAndBusiness();
            uspFrame.enddate = enddate;
            uspFrame.startdate = startdate;
            uspFrame.business = business;
            DataTable tblFrame = uspFrame.ExecDataTable();
            if (tblFrame != null)
            {
                return tblFrame;
            }
            return null;
        }

        /// <summary>
        /// 功能描述    ：  取得报表列表
        /// 创建者      ：  夏天
        /// 创建日期    ：  2014-07-11
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllReport(int UserID, string businessName)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_Reports_ByNameList uspSelect = new usp_tblFW_Reports_ByNameList();
                uspSelect.fldUserID = UserID;
                uspSelect.fldName = businessName;
                tblData = uspSelect.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "GetItemData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "GetItemData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetItemData", "");
            }
        }

        public DataTable OperationReport(string fldaction, int fldAutoId, int fldFlag=0, string fldName="", string fldType = "", string fldTableName = "", int fldParentID=0, int fldSort=0, string fldDefaultSortFld = "", string fldUserID = "")
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_Operation_LAPtblFW_Report uspSelect = new usp_Operation_LAPtblFW_Report();
                uspSelect.fldaction = fldaction;
                uspSelect.fldAutoId = fldAutoId;
                uspSelect.fldFlag = fldFlag;
                uspSelect.fldName = fldName;
                uspSelect.fldType = fldType;
                uspSelect.fldTableName = fldTableName;
                uspSelect.fldParentID = fldParentID;
                uspSelect.fldSort = fldSort;
                uspSelect.fldDefaultSortFld = fldDefaultSortFld;
                uspSelect.fldUserID = fldUserID;
                tblData = uspSelect.ExecDataTable(1);
                return tblData;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "OperationReport", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "OperationReport", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "OperationReport", "");
            }
        }

        public DataTable OperationReport_Doc(string fldaction, int fldAutoId, int fldFlag = 0, string fldName = "", string fldType = "", string fldTableName = "", int fldParentID = 0, int fldSort = 0, string fldDefaultSortFld = "", string fldUserID = "")
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_Operation_LAPtblFW_Report_Doc uspSelect = new usp_Operation_LAPtblFW_Report_Doc();
                uspSelect.fldaction = fldaction;
                uspSelect.fldAutoId = fldAutoId;
                uspSelect.fldFlag = fldFlag;
                uspSelect.fldName = fldName;
                uspSelect.fldType = fldType;
                uspSelect.fldTableName = fldTableName;
                uspSelect.fldParentID = fldParentID;
                uspSelect.fldSort = fldSort;
                uspSelect.fldDefaultSortFld = fldDefaultSortFld;
                uspSelect.fldUserID = fldUserID;
                tblData = uspSelect.ExecDataTable(1);
                return tblData;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "OperationReport", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "OperationReport", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "OperationReport", "");
            }
        }

        public DataTable tblFW_Role_Report_Doc_Action(int fldRoleID,string fldReportID,string fldaction)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_Role_Report_Doc uspSelect = new usp_tblFW_Role_Report_Doc();
                uspSelect.fldaction = fldaction;
                uspSelect.fldRoleID = fldRoleID;
                uspSelect.fldReportID = fldReportID;
                tblData = uspSelect.ExecDataTable(1);
                return tblData;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "tblFW_Role_Report_Doc_Action", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "tblFW_Role_Report_Doc_Action", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "tblFW_Role_Report_Doc_Action", "");
            }
        }


        public DataTable tblFW_Role_Report_Action(int fldRoleID, string fldReportID, string fldaction)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_Role_Report uspSelect = new usp_tblFW_Role_Report();
                uspSelect.fldaction = fldaction;
                uspSelect.fldRoleID = fldRoleID;
                uspSelect.fldReportID = fldReportID;
                tblData = uspSelect.ExecDataTable(1);
                return tblData;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "tblFW_Role_Report_Action", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "tblFW_Role_Report_Action", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "tblFW_Role_Report_Action", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  验证请求报表的字符串是否正确
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-07
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="str">报表的字符串</param>
        /// <returns></returns>
        public bool VerificationReportString(string str)
        {
            bool tt = true;
            if (str != null && str != "")
            {
                string[] restr = str.Split(',');
                if (restr.Length == 0)
                {
                    tt = false;
                }
                else
                {
                    for (int i = 0; i < restr.Length; i++)
                    {
                        if (restr[i].Split('_').Length == 0 || restr[i].Split('_').Length == 1)
                        {
                            tt = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                tt = false;
            }

            return tt;
        }

        /// <summary>
        /// 功能描述    ：  验证是否为纯数字
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-07
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="str">需要验证的字符串</param>
        /// <returns></returns>
        public bool IsNmmber(string str)
        {
            bool tt = true;
            if (str != "" && str != null)
            {
                Regex numRegex = new Regex(@"^\d+$");
                if (numRegex.IsMatch(str))
                {
                    // id 为纯数字。。
                }
                else
                {
                    tt = false; // id 包含数字以外的字符。。
                }
            }
            else
            {
                tt = false; // id 包含数字以外的字符。。
            }

            return tt;
        }

        /// <summary>
        /// 功能描述    ：  json输出格式
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-07
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="status">状态</param>
        /// <param name="msg">提示消息</param>
        /// <param name="data">数据</param>
        /// <param name="isFilterNullValues">输出时是否过滤Null值字符段 默认不过滤</param>
        /// <returns></returns>
        public string JsonStr(string status, string msg, object data, bool isFilterNullValues = false)
        {
            string json = string.Empty;
            jsonHelp help = new jsonHelp();
            help.data = data;
            help.status = status;
            help.msg = msg;

            if (isFilterNullValues)
            {
                var jSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd HH:mm:ss" };
                json = JsonConvert.SerializeObject(help, Formatting.Indented, jSetting);
            }
            else
            {
                var jSetting = new JsonSerializerSettings { DateFormatString = "yyyy-MM-dd HH:mm:ss" };
                json = JsonConvert.SerializeObject(help, jSetting);
            }
            return json;
        }

        public string JsonStrCode(string status, string msg, object data, string urlcode)
        {
            string json = string.Empty;
            jsonHelpCode help = new jsonHelpCode();
            help.data = data;
            help.status = status;
            help.msg = msg;
            help.urlCode = urlcode;
            json = JsonConvert.SerializeObject(help);
            return json;
        }

        /// <summary>
        /// 功能描述    ：  根据业务查找因子
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-05-17
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="itemcode">因子代码</param>
        /// <returns></returns>
        public DataTable GetItem(string type, string itemcode = "")
        {
            try
            {
                DataTable dt = new DataTable();
                usp_GetItem_Select item = new usp_GetItem_Select();
                item.fldtype = type;
                item.flditem = itemcode;
                dt = item.ExecDataTable();
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "GetItem", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "GetItem", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetItem", "");
            }

        }


        /// <summary>
        /// 功能描述    ：  获取系统链接地址
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-12-04
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <returns></returns>
        public DataTable GetSysUrl()
        {
            try
            {
                DataTable dt = new DataTable();
                usp_GettblFW_SystemUrl item = new usp_GettblFW_SystemUrl();
                dt = item.ExecDataTable(6);
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "GetSysUrl", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "GetSysUrl", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetSysUrl", "");
            }

        }


        /// <summary>
        /// 功能描述    ：  根据业务查找因子
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-07-19
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="type">业务类型</param>

        /// <returns></returns>
        public DataTable GetItembytype(string type)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_GetItemByteye_Select item = new usp_GetItemByteye_Select();
                item.fldtype = type;

                dt = item.ExecDataTable();
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "GetItem", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "GetItem", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetItem", "");
            }

        }

        /// <summary>
        /// 功能描述    ：  得到点位筛选的条件
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-06-14
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ： 
        /// </summary>
        /// <param name="tablename">表名称</param>
        /// <param name="field">字段</param>
        /// <param name="DName">字典名称</param>
        /// <returns></returns>
        public DataTable GetFiled(string tablename, string field, string DName)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_GetField item = new usp_GetField();
                item.DName = DName;
                item.field = field;
                item.TableName = tablename;
                dt = item.ExecDataTable();
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "GetFiled", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "GetFiled", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetFiled", "");
            }

        }

        /// <summary>
        /// 功能描述    ：  根据业务查找对应的执行标准名称
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2017-06-05
        /// 修改者      ：   
        /// 修改日期    ：   
        /// 修改原因    ：
        /// </summary>
        /// <param name="modeltype">业务名称</param>
        /// <returns></returns>
        public DataTable GetSTDName(string modeltype)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_ByStandardName stdname = new usp_ByStandardName();
                stdname.fldmodeltype = modeltype;
                dt = stdname.ExecDataTable();
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "GetSTDName", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "GetSTDName", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetSTDName", "");
            }
        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable getdt(string sql)
        {
            try
            {
                usp_execSqlText usp = new usp_execSqlText();
                usp.sqlText = sql;
                DataTable dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
        }


        /// <summary>
        ///  获得河流通用存储过程数据
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="DecCarry">修约的方式</param>
        /// <param name="AppriseID">--0:针对单个断面评价、1：针对空间评价</param>
        /// <param name="fldItemCode">项目ID</param>
        /// <param name="fldLevel">级别</param>
        /// <param name="fldRSC">水期</param>
        /// <param name="fldRSCode">点位代码</param>
        /// <param name="fldStandardName">标准名称</param>
        /// <param name="IsDetail">是否统计明细</param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="Para1ID">-河流均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="Para2ID">--断面属性信息，0：默认属性、1,91：江西增加信息、2：湖南项目信息、3：太原、4：内蒙、5：湖北超标情况</param>
        /// <param name="SpaceID">--0:流域-fldWaterArea、1:水系-fldRSWaterWork、2：河流-fldRCode、3：区县-fldRWTwon、4：设区市-fldSTCode、--5:流域+河流、6：城市+河流、7：流域+水系、8：干支流-fldRiverStream、9：河流+fldAttribute、99：全省</param>
        /// <param name="STatType">--0:数据导出格式、1:年鉴格式、2：因子超标评价、3:断面或者河流综合评价、4：数据市站上报省站格式1  --90:综合指数秩相关、91：浓度秩相关、92：达标率秩相关、93：因子污染指数秩相关、94：各类达标率秩相关、95：各空间各级达标率数秩相关--96：平均综合指数秩相关、--97：因子断面达标率秩相关</param>
        /// <param name="TimeType">时间类型</param>
        /// <param name="IsTotal">是否求平均</param>
        /// <returns></returns>
        public DataTable getreportdt(string BeginDate, string EndDate, string DecCarry, int AppriseID, string fldItemCode, short fldLevel
                                , string fldRSC, string fldRSCode, string fldStandardName, int IsDetail, int IsPre, int IsYear, int Para1ID, int Para2ID, int Source
                                , int SpaceID, short STatType, string TimeType, int IsTotal)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIW_R_Report_Apprise_WUHAN usp = new usp_tblEQIW_R_Report_Apprise_WUHAN();
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.DecCarry = DecCarry;
                usp.AppriseID = AppriseID;
                usp.fldItemCode = fldItemCode;
                usp.fldLevel = fldLevel;
                usp.fldRSC = fldRSC;
                usp.fldRSCode = fldRSCode;
                usp.fldStandardName = fldStandardName;
                usp.IsDetail = IsDetail;
                usp.IsTotal = IsTotal;
                usp.IsPre = IsPre;
                usp.IsYear = IsYear;
                usp.Para1ID = Para1ID;
                usp.Para2ID = Para2ID;
                usp.SpaceID = SpaceID;
                usp.STatType = STatType;
                usp.TimeType = TimeType;
                dt = usp.ExecDataTable(3);
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }
        }


        /// <summary>
        /// 获得湖库数据通用存储过程
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>       
        /// <param name="DecCarry">平均值取值方法:0:四舍六入五单一、1:四舍五入、2:直接截断、5：对武汉项目特殊处理，氨氮和总磷按照有效位数修约</param>
        /// <param name="AppriseID">0:针对单个断面评价、1：针对空间评价</param>
        /// <param name="fldItemCode">因子代码</param>
        /// <param name="fldLevel">级别</param>
        /// <param name="fldRSC">水期</param>
        /// <param name="fldLSCode">湖库+垂线代码</param>
        /// <param name="fldStandardName">级别名称</param>
        /// <param name="IsDetail">是否统计明细  </param>
        /// <param name="IsPre">是否统计前期数据</param>
        /// <param name="IsYear">是否统计同期数据</param>
        /// <param name="Para1ID">湖库均值处理，0:默认值按行政区、1：按行政区前4位处理</param>
        /// <param name="Para2ID">备用参数 </param>  
        /// <param name="STatType">1:年鉴表、2：项目超标情况表、3：综合评价表</param>
        /// <param name="TimeType">时间类型</param>
        /// <param name="IsTotal">是否统计平均值</param>
        /// <param name="IsTLI">是否统计富营养化指数</param>
        /// <param name="TLIType">富营养化计算时叶绿素a和透明度单位：0-mg/L,cm；1-mg/m^3,m</param>
        /// <returns></returns>
        public DataTable getreportdtlake(string BeginDate, string EndDate, string DecCarry, int AppriseID, string fldItemCode, short fldLevel
                                , string fldRSC, string fldLSCode, string fldStandardName, int IsDetail, int IsPre, int IsYear, int Para1ID, int Para2ID, int Source
                                , short STatType, string TimeType, int IsTotal, int IsTLI, int TLIType)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIW_L_Report_Apprise_WUHAN usp = new usp_tblEQIW_L_Report_Apprise_WUHAN();
                usp.TimeType = TimeType;
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.fldRSC = fldRSC;
                usp.fldLSCode = fldLSCode;
                usp.fldStandardName = fldStandardName;
                usp.fldLevel = fldLevel;
                usp.fldItemCode = fldItemCode;
                usp.DecCarry = DecCarry;
                usp.IsPre = IsPre;
                usp.IsYear = IsYear;
                usp.IsTotal = IsTotal;
                usp.IsDetail = IsDetail;
                usp.IsTLI = IsTLI;
                usp.TLIType = TLIType;
                usp.AppriseID = AppriseID;
                usp.STatType = STatType;
                usp.Para1ID = Para1ID;
                usp.Para2ID = Para2ID;
                dt = usp.ExecDataTable(3);
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }
        }

        /// <summary>
        /// 功能描述：获得排污口的数据
        /// 创建时间：2017/11/09
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="DecCarry">修约方式</param>
        /// <param name="fldItemCode">因子代码</param>
        /// <param name="fldLevel">河流级别</param>
        /// <param name="fldLSCode">测点代码</param>
        /// <param name="fldRSC">水期</param>
        /// <param name="ReportFlag">0：报表显示；1：图形分析</param>
        /// <param name="STatType">1按断面平级；0按区域评价</param>
        /// <param name="TimeType">时间类型</param>
        /// <returns></returns>

        public DataTable getreportdtw_n(string BeginDate, string EndDate, string DecCarry, string fldItemCode, short fldLevel, string fldLSCode, string fldRSC, short ReportFlag, short STatType, string TimeType)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_tblEQIW_N_Report_Apprise usp = new usp_tblEQIW_N_Report_Apprise();
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                usp.DecCarry = DecCarry;
                usp.fldItemCode = fldItemCode;
                usp.fldLevel = fldLevel;
                usp.fldLSCode = fldLSCode;
                usp.fldRSC = fldRSC;
                usp.ReportFlag = ReportFlag;
                usp.STatType = STatType;
                usp.TimeType = TimeType;
                dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }

        }

        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        ///  <param name="linktype">数据库连接地址</param>
        /// <returns></returns>
        public DataTable GetMiddleData(string sql,int linktype=5)
        {
            try
            {
                usp_execSqlText usp = new usp_execSqlText();
                usp.sqlText = sql;
                DataTable dt = usp.ExecDataTable(linktype);
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
        }


        /// <summary>
        /// 功能描述：得到分页数据和总记录数
        /// </summary>
        /// <param name="table">要查询的表名称</param>
        /// <param name="strFld">要查询的字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="PageIndex">页码数</param>
        /// <param name="PageSize">每页显示的数量</param>
        /// <param name="Sort">排序的字段，不用加order by</param>
        /// <param name="intTotal">总记录数</param>
        /// <returns></returns>
        public DataTable getpaging(string table, string strFld, string strWhere, int PageIndex, int PageSize, string Sort, out int intTotal)
        {
            try
            {
                int cont = 0;
                Common_PageList_New usp = new Common_PageList_New();
                usp.tab = table;
                usp.strFld = strFld;
                usp.strWhere = strWhere;
                usp.PageIndex = PageIndex;
                usp.PageSize = PageSize;
                usp.Sort = Sort;
                usp.intTotal = cont;
                DataTable dt = usp.ExecDataTable();
                intTotal = usp.intTotal;
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getpaging", "table:" + table);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "table:" + table);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "table:" + table);
            }
        }

        /// <summary>
        /// 功能描述：得到分页数据和总记录数和 汇总
        /// </summary>
        /// <param name="table">要查询的表名称</param>
        /// <param name="strFld">要查询的字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="PageIndex">页码数</param>
        /// <param name="PageSize">每页显示的数量</param>
        /// <param name="Sort">排序的字段，不用加order by</param>
        /// <param name="intTotal">总记录数</param>
        /// <param name="sumwhere">汇总的字段</param>
        /// <returns></returns>
        public DataSet getpaging(string table, string strFld, string strWhere, int PageIndex, int PageSize, string Sort, out int intTotal,string sumwhere)
        {
            try
            {
                int cont = 0;
                Common_PageList_New_SUM usp = new Common_PageList_New_SUM();
                usp.tab = table;
                usp.strFld = strFld;
                usp.strWhere = strWhere;
                usp.PageIndex = PageIndex;
                usp.PageSize = PageSize;
                usp.Sort = Sort;
                usp.intTotal = cont;
                usp.sumwhere = sumwhere;
                DataSet dt = usp.ExecDataSet();
                intTotal = usp.intTotal;
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "getpaging", "table:" + table);
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "getdt", "table:" + table);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "table:" + table);
            }
        }

        /// <summary>
        /// 功能描述：得到查询结果
        /// 创建时间：2017/06/16
        /// 创建人：周文卿 
        /// </summary>
        /// <param name="type">业务类别</param>
        /// <param name="vwTableName">试图</param>
        /// <param name="where">查询条件</param>
        /// <returns></returns>
        public DataTable GetQueryDate(string type, string vwTableName, string where)
        {
            try
            {
                usp_EQI_Comm_CreteQueryTable usp = new usp_EQI_Comm_CreteQueryTable();
                usp.type = type;
                usp.vwTableName = vwTableName;
                usp.strWhere = where;
                DataTable dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "GetQueryDate:" + where);
            }
        }


        /// <summary>
        /// 功能描述：得到查询结果
        /// 创建时间：2017/06/16
        /// 创建人：周文卿 
        /// </summary>
        /// <param name="type">业务类别</param>
        /// <param name="vwTableName">试图</param>
        /// <param name="where">查询条件</param>
        /// <param name="file">要查询的字段</param>
        /// <returns></returns>
        public DataTable GetQueryDate(string type, string vwTableName, string where,string file)
        {
            try
            {
                usp_EQI_Comm_CreteQueryTableFile usp = new usp_EQI_Comm_CreteQueryTableFile();
                usp.type = type;
                usp.vwTableName = vwTableName;
                usp.strWhere = where;
                usp.file = file;
                DataTable dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "GetQueryDate:" + where);
            }
        }

        /// <summary>
        /// 功能描述：根据json文件路径得到json数据
        /// 创建人：周文卿
        /// 创建时间：2017/06/06
        /// 修改时间：
        /// 修改人：
        /// </summary>
        /// <param name="strLocalpath">文件路径</param>
        /// <returns></returns>
        public string GetJson(string strLocalpath)
        {
            FileStream mytxt = File.OpenRead(strLocalpath);//拿到流的方法
            Byte[] FileBuffer = new byte[(int)mytxt.Length];//构建一个缓冲池
            int ReadFileLenght = mytxt.Read(FileBuffer, 0, (int)mytxt.Length);//把拿到的流文件读到缓冲池中去
            string HaveRead = System.Text.Encoding.UTF8.GetString(FileBuffer);
            mytxt.Close();
            return HaveRead;
        }


        /// <summary>
        /// 功能描述：处理当前请求者用户ID
        /// 创建人：徐雍文
        /// 创建时间：2017-06-26
        /// 修改时间：
        /// 修改人：
        /// </summary>
        /// <param name="Userid">用户ID</param>
        /// <returns></returns>
        public string ConductUserinfo(object Userid)
        {
            if (string.IsNullOrEmpty(Userid.ToString()))
            {
                Userid = "-1";
            }
            return Userid.ToString();
        }

        /// <summary>
        /// 功能描述：根据视图名称来汉化标题
        /// 创建者：熊瑞竹
        /// 创建日期：2017-06-29
        /// 修改者：
        /// 修改日期
        /// 修改原因：
        /// </summary>
        /// <param name="viewName">视图名称</param>
        /// <param name="ncTitle">需要汉化的字段</param>
        /// <returns>一条含有你需要的汉化字段的dt</returns>
        public DataTable ChinesizeTitleNamebyViewName(string viewName, string ncTitle)
        {
            try
            {
                DataTable dt = new DataTable();
                usp_Auditing_DatadtTitle_Chinesize param = new usp_Auditing_DatadtTitle_Chinesize();
                param.viewname = viewName;
                param.titlename = ncTitle;
                dt = param.ExecDataTable();
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    throw new Exception("取得记录失败，未找到对应的记录");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuleCommon", "ChinesizeTitleNamebyViewName", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleCommon", "ChinesizeTitleNamebyViewName", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "ChinesizeTitleNamebyViewName", "");
            }
        }

        /// <summary>
        /// 功能描述：判读参数为null，空和-1,不是返回True,是的返回false
        /// 创建时间：2017/09/24
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Judge(string p)
        {
            if (p == null)
                return false;
            if (p == "")
                return false;
            if (p == "-1")
                return false;
            return true;
        }


        /// <summary>
        /// 功能描述：判读参数为null，空,不是返回True,是的返回false
        /// 创建时间：2017/09/24
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool JudgeLevel(string p)
        {
            if (p == null)
                return false;
            if (p == "")
                return false;
            return true;
        }


        /// <summary>
        /// 功能描述：获得时间字符
        /// 创建时间：2017/09/25
        /// 创建  人：周文卿
        /// </summary>
        /// <returns></returns>
        public string gettime(string strtime, string endtime, string timetype)
        {
            string time = "";
            DateTime dtime = DateTime.Parse(strtime);
            time = " and fldMonth='" + dtime.Month + "' and fldYear='" + (dtime.Year) + "'";

            return time;
        }

        /// <summary>
        /// 功能描述：获得上一年时间字符
        /// 创建时间：2017/09/25
        /// 创建  人：周文卿
        /// </summary>
        /// <returns></returns>
        public string gettimetq(string strtime, string endtime, string timetype)
        {
            string time = "";
            DateTime dtime = DateTime.Parse(strtime);
            time = " and fldMonth='" + dtime.Month + "' and fldYear='" + (dtime.Year - 1) + "'";

            return time;
        }


        /// <summary>
        /// 功能描述：获得累计的时间
        /// 创建时间：2017/09/27
        /// 创建  人：周文卿
        /// </summary>
        /// <returns></returns>
        public string strtime(string strtime, string timetype)
        {
            string str = " and (";
            DateTime dtime = DateTime.Parse(strtime + "01");
            for (int i = 1; i <= dtime.Month; i++)
            {
                if (i == dtime.Month)
                {
                    if (i < 10)
                    {
                        str += "  fldDate='" + dtime.Year + "年" + "0" + i + "月" + timetype + "')";
                    }
                    else
                    {
                        str += "  fldDate='" + dtime.Year + "年" + "0" + i + "月" + timetype + "')";
                    }
                }
                else
                {
                    if (i < 10)
                    {
                        str += " fldDate='" + dtime.Year + "年" + "0" + i + "月" + timetype + "' or ";
                    }
                    else
                    {
                        str += " fldDate='" + dtime.Year + "年" + "0" + i + "月" + timetype + "' or ";
                    }
                }
            }

            return str;
        }

        /// <summary>
        /// 功能描述：获得累计的时间
        /// 创建时间：2017/09/27
        /// 创建  人：周文卿
        /// </summary>
        /// <returns></returns>
        public string strtime(string strtime, string endtime, string timetype)
        {
            string str = "";
            DateTime dtime = DateTime.Parse(strtime);
            str = " and fldMonth='1' and fldYear='" + dtime.Year + "' and fldLJ='1～" + dtime.Month + "'";
            return str;
        }
        /// <summary>
        /// 功能描述：是否为正确的时间格式(正确的为true，错误为false)
        /// 创建时间：2017/09/25
        /// 创建  人：周文卿 
        /// </summary>
        /// <returns></returns>
        public bool istime(string time)
        {
            try
            {
                DateTime dt = DateTime.Parse(time);
                return true;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 功能描述：是否为正确的数字(正确的为true，错误为false)
        /// 创建时间：2017/10/03
        /// 创建  人：周文卿 
        /// </summary>
        /// <returns></returns>
        public bool ismtch(string macth)
        {
            try
            {
                decimal dt = decimal.Parse(macth);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 功能描述    ：  修改Pre表的fldItemValue值
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-04-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>true / false</returns>
        public bool Updateitem(string fldAutoid, string flditemcode, string fldItemValue, string table)
        {

            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        usp_tblEQIA_RPI_Basedata_Pre_UpdateItemValueBytable uspUpdate = new usp_tblEQIA_RPI_Basedata_Pre_UpdateItemValueBytable();
                        uspUpdate.fldAutoID = fldAutoid;
                        uspUpdate.fldItemCode = flditemcode;
                        uspUpdate.fldItemValue = fldItemValue;
                        uspUpdate.table = table;
                        int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                        if (iResultInsert <= 0)
                            throw new Exception("修改记录失败，未找到对应的记录");

                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new UpdatePKException("相同的记录已经存在，违反表的唯一键约束", "RuletblEQIA_RPI_Basedata_Pre",
                            "UpdateAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                }
            }
        }


        /// <summary>
        /// 功能描述    ：  修改Pre表的fldItemValue值和remark表里的备注
        /// 创建者      ：  熊瑞竹
        /// 创建日期    ：  2018-01-22
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>true / false</returns>
        public bool UpdateitemAndRemark(string fldAutoid, string flditemcode, string fldItemValue, string table, string source, string rsinfo, string date, string remark, string obj)
        {

            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        usp_tblEQI_Basedata_Pre_UpdateItemValueAndRemarkBytable uspUpdate = new usp_tblEQI_Basedata_Pre_UpdateItemValueAndRemarkBytable();
                        uspUpdate.fldAutoID = fldAutoid;
                        uspUpdate.fldItemCode = flditemcode;
                        uspUpdate.fldItemValue = fldItemValue;
                        uspUpdate.table = table;
                        uspUpdate.source = source;
                        uspUpdate.rsinfo = rsinfo;
                        uspUpdate.date = date;
                        uspUpdate.remark = remark;
                        uspUpdate.obj = obj;
                        int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                        if (iResultInsert <= 0)
                            throw new Exception("修改记录失败，未找到对应的记录");

                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new UpdatePKException("相同的记录已经存在，违反表的唯一键约束", "RuletblEQIA_RPI_Basedata_Pre",
                            "UpdateAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                }
            }
        }


        /// <summary>
        /// 功能描述    ：  获得水自动发布数据
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-03-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <returns></returns>
        public DataTable GetWaterAutoPublish(string TableName,string BeginDate, string EndDate)
        {
            try
            {
                usp_tblEQIW_R_Report_Auto_SectionStageApprise usp = new usp_tblEQIW_R_Report_Auto_SectionStageApprise();
                usp.fldTableName = TableName;
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                DataTable dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:" + TableName);
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:" + TableName);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "GetWaterAutoPublish:" + TableName);
            }
        }


        /// <summary>
        /// 功能描述    ：  获得自动发布数据
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2018-06-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <returns></returns>
        public DataTable GetWaterAutoPublishGis(string BeginDate, string EndDate)
        {
            try
            {
                usp_tblEQIW_R_Report_Gis usp = new usp_tblEQIW_R_Report_Gis();
                usp.BeginDate = BeginDate;
                usp.EndDate = EndDate;
                DataTable dt = usp.ExecDataTable();
                return dt;
            }
            catch (DBOpenException)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:");
            }
           
        }




















    }
}
