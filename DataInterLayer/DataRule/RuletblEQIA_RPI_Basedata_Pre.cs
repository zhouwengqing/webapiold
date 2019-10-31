using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIA_RPI_Basedata_Pre : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  根据表名删除数据
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-04-06
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstDelID">删除的id</param> 
        /// <param name="table">表名</param> 
        /// <returns>true / false</returns>
        /// 
        public bool delById(List<long> lstDelID, string table)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < lstDelID.Count; i++)
                        {
                            deletebytable usp_del = new deletebytable();
                            usp_del.table = table;
                            usp_del.fldAutoID = lstDelID[i];
                            if (usp_del.ExecNoQuery(conn, tran) <= 0)
                                throw new Exception("删除记录失败");
                        }
                        tran.Commit();
                        return true;

                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata_Pre", "UpdateFlagandDel"
                            , "lstDelID：" + lstDelID.ToString());
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata_Pre", "UpdateFlagandDel"
                            , "lstDelID：" + lstDelID.ToString());
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata_Pre", "UpdateFlagandDel",
                            "lstDelID：" + lstDelID.ToString());
                    }
                }

            }
        }

        #region 根据表名修改
        /// <summary>
        /// 根据表名修改flag
        /// </summary>
        /// <param name="lstDelID"></param>
        /// <param name="Import"></param>
        /// <returns></returns>
        public bool delBytable(List<long> lstDelID, string table,string NewFlag)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < lstDelID.Count; i++)
                        {
                            usp_tblEQI_Common_Basedata_Pre_Updatetable usp_up = new usp_tblEQI_Common_Basedata_Pre_Updatetable();
                            usp_up.fldAutoID = lstDelID[i];
                            usp_up.table = table;
                            usp_up.NewFlag = NewFlag;
                            if (usp_up.ExecNoQuery(conn, tran) <= 0)
                                throw new Exception("更新记录失败");
                        }
                        tran.Commit();
                        return true;

                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("打开数据库连接失败", "usp_tblEQI_Common_Basedata_Pre_Updatetable", "UpdateFlagandDel"
                            , "lstDelID：");
                    }

                }

            }
        }
        #endregion

        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIA_RPI_Basedata_Pre]表的记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-04-30
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIA_RPI_Basedata_Pre的实体数组</param>
        /// <param name="input_new">要记录的录入时间</param>
        /// <param name="input_old">要修改的原来的录入时间</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAll(List<tblEQIA_RPI_Basedata_Pre> lstData, tblEQI_InputDate input_new)
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
                            usp_tblEQIA_RPI_Basedata_Pre_Insert uspInsert = new usp_tblEQIA_RPI_Basedata_Pre_Insert();
                            uspInsert.ReceiveParameter(lstData[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("添加记录失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (iRowIndex + 1) + "，错误原因：同一测点同一时间同一项目的数据已经存在",
                            "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIA_RPI_Basedata_Pre]表的记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-07-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIA_RPI_Basedata_Pre的实体数组</param>
        /// <param name="input_new">要记录的录入时间</param>
        /// <param name="input_old">要修改的原来的录入时间</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAll(List<tblEQIA_RPI_Basedata_Pre> lstData)
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
                            usp_tblEQIA_RPI_Basedata_Pre_Insert uspInsert = new usp_tblEQIA_RPI_Basedata_Pre_Insert();
                            uspInsert.ReceiveParameter(lstData[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("添加记录失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (iRowIndex + 1) + "，错误原因：同一测点同一时间同一项目的数据已经存在",
                            "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIA_RPI_Basedata_Pre", "InsertAll", "lstData:" + lstData.ToString());
                    }
                }
            }
        }





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


















    }
}
