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
    /// ��������    ��  ͨ�õ����ݲ���
    /// ������      ��  ������
    /// ��������    ��  2009-03-27
    /// �޸���      ��
    /// �޸�����    ��
    /// �޸�ԭ��    ��
    /// </summary>
    public class RuleCommon : BaseRule
    {
        public RuleCommon()
        {
        }

        /// <summary>
        /// ��������    ��  ��������ַ���
        /// ������      ��  ������
        /// ��������    ��  2010-02-03
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <returns></returns>
        public string GetConnectString()
        {
            return DataAccessConfig.ConnString;
        }






        /// <summary>
        /// �����ض����ݿ⣬ִ��SQL��䣬����DataTable�����ڶ�����API
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
        /// �����ϴ��ļ�
        /// </summary>
        /// <param name="prdName">�洢������</param>
        /// <param name="lstParameters">�洢�����õ��Ĳ���</param>
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
                throw new DataRuleException("�����ݿ����ӳ���", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + fldReport_Name + "��lstParameters:" + fldReport_Name.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("ִ��sql������", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + fldReport_Name);
            }
            catch (Exception e)
            {
                throw new DataRuleException(e.Message, "CommonRule", "ExecProcessPrd",
                                            "prdName: " + fldReport_Name);
            }
        }









        /// <summary>
        /// ִ��ָ���Ĵ洢����
        /// </summary>
        /// <param name="prdName">�洢������</param>
        /// <param name="lstParameters">�洢�����õ��Ĳ���</param>
        public void ExecProcessPrd(string prdName, List<SqlParameter> lstParameters)
        {
            try
            {
                usp_ExecProcess uspProcess = new usp_ExecProcess(prdName, lstParameters);
                uspProcess.ExecNoQuery();
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("�����ݿ����ӳ���", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName + "��lstParameters:" + lstParameters.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("ִ��sql������", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
            catch (Exception e)
            {
                throw new DataRuleException(e.Message, "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
        }

        /// <summary>
        /// ִ��ָ���Ĵ洢����
        /// </summary>
        /// <param name="prdName">�洢������</param>
        /// <param name="lstParameters">�洢�����õ��Ĳ���</param>
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
                throw new DataRuleException("�����ݿ����ӳ���", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName + "��lstParameters:" + lstParameters.ToString());
            }
            catch (DBPKException e)
            {
                throw new DataRuleException("���ݿ����Ѵ�����ͬ������", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName);
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("ִ��sql������", "CommonRule", "ExecProcessPrd",
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
        /// ִ��ָ���Ĵ洢����
        /// </summary>
        /// <param name="prdName">�洢������</param>
        /// <param name="lstParameters">�洢�����õ��Ĳ���</param>
        /// <param name="strTableName">������</param>
        public DataTable ExecProcessPrd(string prdName, List<SqlParameter> lstParameters, string strTableName)
        {
            try
            {
                usp_ExecProcess uspProcess = new usp_ExecProcess(prdName, lstParameters, false);
                return uspProcess.ExecDataTable(strTableName);
            }
            catch (DBOpenException e)
            {
                throw new DataRuleException("�����ݿ����ӳ���", "CommonRule", "ExecProcessPrd",
                                            "prdName: " + prdName + "��lstParameters:" + lstParameters.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DataRuleException("ִ��sql������", "CommonRule", "ExecProcessPrd",
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
       /// �����������첽ִ��sql
       /// ����  �ˣ�������
       /// ����ʱ�䣺2018-11-30
       /// </summary>
       /// <param name="callBack">�ص�</param>
       /// <param name="dbName">�����ַ���</param>
       /// <param name="parameters">����</param>
       /// <param name="storedProcName">�洢��������</param>

        public  void AsyncExecuteNonQuery(AsyncCallback callBack, string dbName, List<SqlParameter> parameters, string storedProcName)
        {
            //�ر����ݿ�����Ҫ��callback�йرգ���Ϊ���첽����
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
                command.ExecuteNonQuery(); //��ʼִ��SQL���
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
        /// ��ȡ�洢���̲����б�
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
        /// �����ꡢҵ�����ͻ�ȡ���в��
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
        /// �������ڡ�ҵ�����ͻ�ȡ���л�������
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
        /// ��������    ��  ȡ�ñ����б�
        /// ������      ��  ����
        /// ��������    ��  2014-07-11
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "GetItemData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "GetItemData", "");
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "OperationReport", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "OperationReport", "");
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "OperationReport", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "OperationReport", "");
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "tblFW_Role_Report_Doc_Action", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "tblFW_Role_Report_Doc_Action", "");
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "tblFW_Role_Report_Action", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "tblFW_Role_Report_Action", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "tblFW_Role_Report_Action", "");
            }
        }

        /// <summary>
        /// ��������    ��  ��֤���󱨱���ַ����Ƿ���ȷ
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2017-05-07
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="str">������ַ���</param>
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
        /// ��������    ��  ��֤�Ƿ�Ϊ������
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2017-05-07
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="str">��Ҫ��֤���ַ���</param>
        /// <returns></returns>
        public bool IsNmmber(string str)
        {
            bool tt = true;
            if (str != "" && str != null)
            {
                Regex numRegex = new Regex(@"^\d+$");
                if (numRegex.IsMatch(str))
                {
                    // id Ϊ�����֡���
                }
                else
                {
                    tt = false; // id ��������������ַ�����
                }
            }
            else
            {
                tt = false; // id ��������������ַ�����
            }

            return tt;
        }

        /// <summary>
        /// ��������    ��  json�����ʽ
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2017-05-07
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="status">״̬</param>
        /// <param name="msg">��ʾ��Ϣ</param>
        /// <param name="data">����</param>
        /// <param name="isFilterNullValues">���ʱ�Ƿ����Nullֵ�ַ��� Ĭ�ϲ�����</param>
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
        /// ��������    ��  ����ҵ���������
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2017-05-17
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="type">ҵ������</param>
        /// <param name="itemcode">���Ӵ���</param>
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "GetItem", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "GetItem", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetItem", "");
            }

        }


        /// <summary>
        /// ��������    ��  ��ȡϵͳ���ӵ�ַ
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2017-12-04
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    �� 
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "GetSysUrl", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "GetSysUrl", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetSysUrl", "");
            }

        }


        /// <summary>
        /// ��������    ��  ����ҵ���������
        /// ������      ��  ������
        /// ��������    ��  2017-07-19
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="type">ҵ������</param>

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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "GetItem", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "GetItem", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetItem", "");
            }

        }

        /// <summary>
        /// ��������    ��  �õ���λɸѡ������
        /// ������      ��  ������
        /// ��������    ��  2017-06-14
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    �� 
        /// </summary>
        /// <param name="tablename">������</param>
        /// <param name="field">�ֶ�</param>
        /// <param name="DName">�ֵ�����</param>
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "GetFiled", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "GetFiled", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetFiled", "");
            }

        }

        /// <summary>
        /// ��������    ��  ����ҵ����Ҷ�Ӧ��ִ�б�׼����
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2017-06-05
        /// �޸���      ��   
        /// �޸�����    ��   
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="modeltype">ҵ������</param>
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
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "GetSTDName", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "GetSTDName", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "GetSTDName", "");
            }
        }

        /// <summary>
        /// ִ��sql���
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
        }


        /// <summary>
        ///  ��ú���ͨ�ô洢��������
        /// </summary>
        /// <param name="BeginDate">��ʼʱ��</param>
        /// <param name="EndDate">����ʱ��</param>
        /// <param name="DecCarry">��Լ�ķ�ʽ</param>
        /// <param name="AppriseID">--0:��Ե����������ۡ�1����Կռ�����</param>
        /// <param name="fldItemCode">��ĿID</param>
        /// <param name="fldLevel">����</param>
        /// <param name="fldRSC">ˮ��</param>
        /// <param name="fldRSCode">��λ����</param>
        /// <param name="fldStandardName">��׼����</param>
        /// <param name="IsDetail">�Ƿ�ͳ����ϸ</param>
        /// <param name="IsPre">�Ƿ�ͳ��ǰ������</param>
        /// <param name="IsYear">�Ƿ�ͳ��ͬ������</param>
        /// <param name="Para1ID">-������ֵ����0:Ĭ��ֵ����������1����������ǰ4λ����</param>
        /// <param name="Para2ID">--����������Ϣ��0��Ĭ�����ԡ�1,91������������Ϣ��2��������Ŀ��Ϣ��3��̫ԭ��4�����ɡ�5�������������</param>
        /// <param name="SpaceID">--0:����-fldWaterArea��1:ˮϵ-fldRSWaterWork��2������-fldRCode��3������-fldRWTwon��4��������-fldSTCode��--5:����+������6������+������7������+ˮϵ��8����֧��-fldRiverStream��9������+fldAttribute��99��ȫʡ</param>
        /// <param name="STatType">--0:���ݵ�����ʽ��1:�����ʽ��2�����ӳ������ۡ�3:������ߺ����ۺ����ۡ�4��������վ�ϱ�ʡվ��ʽ1  --90:�ۺ�ָ������ء�91��Ũ������ء�92�����������ء�93��������Ⱦָ������ء�94��������������ء�95�����ռ����������������--96��ƽ���ۺ�ָ������ء�--97�����Ӷ������������</param>
        /// <param name="TimeType">ʱ������</param>
        /// <param name="IsTotal">�Ƿ���ƽ��</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }
        }


        /// <summary>
        /// ��ú�������ͨ�ô洢����
        /// </summary>
        /// <param name="BeginDate">��ʼʱ��</param>
        /// <param name="EndDate">����ʱ��</param>       
        /// <param name="DecCarry">ƽ��ֵȡֵ����:0:���������嵥һ��1:�������롢2:ֱ�ӽضϡ�5�����人��Ŀ���⴦�����������װ�����Чλ����Լ</param>
        /// <param name="AppriseID">0:��Ե����������ۡ�1����Կռ�����</param>
        /// <param name="fldItemCode">���Ӵ���</param>
        /// <param name="fldLevel">����</param>
        /// <param name="fldRSC">ˮ��</param>
        /// <param name="fldLSCode">����+���ߴ���</param>
        /// <param name="fldStandardName">��������</param>
        /// <param name="IsDetail">�Ƿ�ͳ����ϸ  </param>
        /// <param name="IsPre">�Ƿ�ͳ��ǰ������</param>
        /// <param name="IsYear">�Ƿ�ͳ��ͬ������</param>
        /// <param name="Para1ID">�����ֵ����0:Ĭ��ֵ����������1����������ǰ4λ����</param>
        /// <param name="Para2ID">���ò��� </param>  
        /// <param name="STatType">1:�����2����Ŀ���������3���ۺ����۱�</param>
        /// <param name="TimeType">ʱ������</param>
        /// <param name="IsTotal">�Ƿ�ͳ��ƽ��ֵ</param>
        /// <param name="IsTLI">�Ƿ�ͳ�Ƹ�Ӫ����ָ��</param>
        /// <param name="TLIType">��Ӫ��������ʱҶ����a��͸���ȵ�λ��0-mg/L,cm��1-mg/m^3,m</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }
        }

        /// <summary>
        /// ����������������ۿڵ�����
        /// ����ʱ�䣺2017/11/09
        /// ����  �ˣ�������
        /// </summary>
        /// <param name="BeginDate">��ʼʱ��</param>
        /// <param name="EndDate">����ʱ��</param>
        /// <param name="DecCarry">��Լ��ʽ</param>
        /// <param name="fldItemCode">���Ӵ���</param>
        /// <param name="fldLevel">��������</param>
        /// <param name="fldLSCode">������</param>
        /// <param name="fldRSC">ˮ��</param>
        /// <param name="ReportFlag">0��������ʾ��1��ͼ�η���</param>
        /// <param name="STatType">1������ƽ����0����������</param>
        /// <param name="TimeType">ʱ������</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "getdt", "sql:");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:");
            }

        }

        /// <summary>
        /// ִ��sql���
        /// </summary>
        /// <param name="sql">Ҫִ�е�sql���</param>
        ///  <param name="linktype">���ݿ����ӵ�ַ</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "sql:" + sql);
            }
        }


        /// <summary>
        /// �����������õ���ҳ���ݺ��ܼ�¼��
        /// </summary>
        /// <param name="table">Ҫ��ѯ�ı�����</param>
        /// <param name="strFld">Ҫ��ѯ���ֶ�</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="PageIndex">ҳ����</param>
        /// <param name="PageSize">ÿҳ��ʾ������</param>
        /// <param name="Sort">������ֶΣ����ü�order by</param>
        /// <param name="intTotal">�ܼ�¼��</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "getpaging", "table:" + table);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "getdt", "table:" + table);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "table:" + table);
            }
        }

        /// <summary>
        /// �����������õ���ҳ���ݺ��ܼ�¼���� ����
        /// </summary>
        /// <param name="table">Ҫ��ѯ�ı�����</param>
        /// <param name="strFld">Ҫ��ѯ���ֶ�</param>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="PageIndex">ҳ����</param>
        /// <param name="PageSize">ÿҳ��ʾ������</param>
        /// <param name="Sort">������ֶΣ����ü�order by</param>
        /// <param name="intTotal">�ܼ�¼��</param>
        /// <param name="sumwhere">���ܵ��ֶ�</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "getpaging", "table:" + table);
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "getdt", "table:" + table);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "table:" + table);
            }
        }

        /// <summary>
        /// �����������õ���ѯ���
        /// ����ʱ�䣺2017/06/16
        /// �����ˣ������� 
        /// </summary>
        /// <param name="type">ҵ�����</param>
        /// <param name="vwTableName">��ͼ</param>
        /// <param name="where">��ѯ����</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "GetQueryDate:" + where);
            }
        }


        /// <summary>
        /// �����������õ���ѯ���
        /// ����ʱ�䣺2017/06/16
        /// �����ˣ������� 
        /// </summary>
        /// <param name="type">ҵ�����</param>
        /// <param name="vwTableName">��ͼ</param>
        /// <param name="where">��ѯ����</param>
        /// <param name="file">Ҫ��ѯ���ֶ�</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "GetQueryDate", "sql:" + where);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "GetQueryDate:" + where);
            }
        }

        /// <summary>
        /// ��������������json�ļ�·���õ�json����
        /// �����ˣ�������
        /// ����ʱ�䣺2017/06/06
        /// �޸�ʱ�䣺
        /// �޸��ˣ�
        /// </summary>
        /// <param name="strLocalpath">�ļ�·��</param>
        /// <returns></returns>
        public string GetJson(string strLocalpath)
        {
            FileStream mytxt = File.OpenRead(strLocalpath);//�õ����ķ���
            Byte[] FileBuffer = new byte[(int)mytxt.Length];//����һ�������
            int ReadFileLenght = mytxt.Read(FileBuffer, 0, (int)mytxt.Length);//���õ������ļ������������ȥ
            string HaveRead = System.Text.Encoding.UTF8.GetString(FileBuffer);
            mytxt.Close();
            return HaveRead;
        }


        /// <summary>
        /// ��������������ǰ�������û�ID
        /// �����ˣ���Ӻ��
        /// ����ʱ�䣺2017-06-26
        /// �޸�ʱ�䣺
        /// �޸��ˣ�
        /// </summary>
        /// <param name="Userid">�û�ID</param>
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
        /// ����������������ͼ��������������
        /// �����ߣ�������
        /// �������ڣ�2017-06-29
        /// �޸��ߣ�
        /// �޸�����
        /// �޸�ԭ��
        /// </summary>
        /// <param name="viewName">��ͼ����</param>
        /// <param name="ncTitle">��Ҫ�������ֶ�</param>
        /// <returns>һ����������Ҫ�ĺ����ֶε�dt</returns>
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
                    throw new Exception("ȡ�ü�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");
                }
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("�����ݿ�����ʧ��", "RuleCommon", "ChinesizeTitleNamebyViewName", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("ִ��Sql���ʧ��", "RuleCommon", "ChinesizeTitleNamebyViewName", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleCommon", "ChinesizeTitleNamebyViewName", "");
            }
        }

        /// <summary>
        /// �����������ж�����Ϊnull���պ�-1,���Ƿ���True,�ǵķ���false
        /// ����ʱ�䣺2017/09/24
        /// ����  �ˣ�������
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
        /// �����������ж�����Ϊnull����,���Ƿ���True,�ǵķ���false
        /// ����ʱ�䣺2017/09/24
        /// ����  �ˣ�������
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
        /// �������������ʱ���ַ�
        /// ����ʱ�䣺2017/09/25
        /// ����  �ˣ�������
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
        /// ���������������һ��ʱ���ַ�
        /// ����ʱ�䣺2017/09/25
        /// ����  �ˣ�������
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
        /// ��������������ۼƵ�ʱ��
        /// ����ʱ�䣺2017/09/27
        /// ����  �ˣ�������
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
                        str += "  fldDate='" + dtime.Year + "��" + "0" + i + "��" + timetype + "')";
                    }
                    else
                    {
                        str += "  fldDate='" + dtime.Year + "��" + "0" + i + "��" + timetype + "')";
                    }
                }
                else
                {
                    if (i < 10)
                    {
                        str += " fldDate='" + dtime.Year + "��" + "0" + i + "��" + timetype + "' or ";
                    }
                    else
                    {
                        str += " fldDate='" + dtime.Year + "��" + "0" + i + "��" + timetype + "' or ";
                    }
                }
            }

            return str;
        }

        /// <summary>
        /// ��������������ۼƵ�ʱ��
        /// ����ʱ�䣺2017/09/27
        /// ����  �ˣ�������
        /// </summary>
        /// <returns></returns>
        public string strtime(string strtime, string endtime, string timetype)
        {
            string str = "";
            DateTime dtime = DateTime.Parse(strtime);
            str = " and fldMonth='1' and fldYear='" + dtime.Year + "' and fldLJ='1��" + dtime.Month + "'";
            return str;
        }
        /// <summary>
        /// �����������Ƿ�Ϊ��ȷ��ʱ���ʽ(��ȷ��Ϊtrue������Ϊfalse)
        /// ����ʱ�䣺2017/09/25
        /// ����  �ˣ������� 
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
        /// �����������Ƿ�Ϊ��ȷ������(��ȷ��Ϊtrue������Ϊfalse)
        /// ����ʱ�䣺2017/10/03
        /// ����  �ˣ������� 
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
        /// ��������    ��  �޸�Pre���fldItemValueֵ
        /// ������      ��  ������
        /// ��������    ��  2017-04-14
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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
                            throw new Exception("�޸ļ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");

                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new UpdatePKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblEQIA_RPI_Basedata_Pre",
                            "UpdateAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
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
        /// ��������    ��  �޸�Pre���fldItemValueֵ��remark����ı�ע
        /// ������      ��  ������
        /// ��������    ��  2018-01-22
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
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
                            throw new Exception("�޸ļ�¼ʧ�ܣ�δ�ҵ���Ӧ�ļ�¼");

                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("�����ݿ�����ʧ��", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new UpdatePKException("��ͬ�ļ�¼�Ѿ����ڣ�Υ�����Ψһ��Լ��", "RuletblEQIA_RPI_Basedata_Pre",
                            "UpdateAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("ִ��Sql���ʧ��", "RuletblEQIA_RPI_Basedata_Pre", "UpdateAll", "");
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
        /// ��������    ��  ���ˮ�Զ���������
        /// ������      ��  ��Ӻ��
        /// ��������    ��  2018-03-15
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="TableName">���ݱ�����</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:" + TableName);
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:" + TableName);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_publi", "getdt", "GetWaterAutoPublish:" + TableName);
            }
        }


        /// <summary>
        /// ��������    ��  ����Զ���������
        /// ������      ��  ������
        /// ��������    ��  2018-06-12
        /// �޸���      ��
        /// �޸�����    ��
        /// �޸�ԭ��    ��
        /// </summary>
        /// <param name="TableName">���ݱ�����</param>
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
                throw new GetListException("�����ݿ�����ʧ��", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:");
            }
            catch (DBQueryException)
            {
                throw new GetListException("ִ��Sql���ʧ��", "RuletblEQI_publi", "GetWaterAutoPublish", "sql:");
            }
           
        }




















    }
}
