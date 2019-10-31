using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.Common
{

    /// <summary>
    /// 应用程序服务
    /// 创建者：吕荣誉
    /// </summary>
    public class ApplicationServerController : ApiController
    {
        /// <summary>
        /// Sql服务，执行Sql操作统一API
        /// 创建者：吕荣誉
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        // Post: api/ApplicationServer/SqlServer
        [HttpPost]
        public IHttpActionResult SqlServer(SqlServer_Info info)
        {
            SqlServer_Return rt = new SqlServer_Return();

            string Sql = null;

            try
            {
                if (info.SqlType == "Select")
                {
                    if (!string.IsNullOrEmpty(info.Select))
                    {
                        Sql += "select " + info.Select;
                    }

                    if (!string.IsNullOrEmpty(info.From))
                    {
                        Sql += " from " + info.From;
                    }

                    if (!string.IsNullOrEmpty(info.Where))
                    {
                        Sql += " where " + info.Where;
                    }

                    if (Sql == null)
                    {
                        Sql = info.Sql;
                    }

                    rt.Sql = Sql;
                    rt.Select_Data = SqlQueryForDataTable(info.dbName, Sql);
                }



                if (info.SqlType == "Insert")
                {
                    Sql = "insert into " + info.InsertInto + " values " + info.Values;

                    rt.Sql = Sql;
                    rt.InfluenceCount = ExecuteSqlCommand(info.dbName, Sql);
                }



                if (info.SqlType == "Update")
                {
                    Sql = "update " + info.Update + " set " + info.Set + " where " + info.Where;

                    rt.Sql = Sql;
                    rt.InfluenceCount = ExecuteSqlCommand(info.dbName, Sql);
                }



                if (info.SqlType == "Delete")
                {
                    Sql = "delete from " + info.From + " where " + info.Where;

                    rt.Sql = Sql;
                    rt.InfluenceCount = ExecuteSqlCommand(info.dbName, Sql);
                }



                if (info.SqlType == "NoQuery")
                {
                    Sql = info.Sql;

                    rt.Sql = Sql;
                    rt.InfluenceCount = ExecuteSqlCommand(info.dbName, Sql);
                }



            }
            catch (Exception e)
            {
                rt.Sql = Sql;
                rt.Error = e.Message;
                if (e.InnerException != null)
                {
                    rt.InnerException = e.InnerException.InnerException.Message;
                }
                return Ok(rt);
            }



            return Ok(rt);
        }



        public class SqlServer_Info
        {
            /// <summary>
            /// 需要连接的数据库名称
            /// </summary>
            public string dbName { get; set; }


            /// <summary>
            /// Sql语句的类型
            /// “Select”=查询操作
            /// “Insert”=新增操作
            /// “Update”=更新操作
            /// “Delete”=删除操作
            /// “NoQuery”=非查询操作，跟Sql参数配合使用
            /// </summary>
            public string SqlType { get; set; }



            /// <summary>
            /// Sql语句
            /// </summary>
            public string Sql { get; set; }



            /// <summary>
            /// Select关键字所跟的宾语
            /// </summary>
            public string Select { get; set; }


            /// <summary>
            /// From关键字所跟的宾语
            /// </summary>
            public string From { get; set; }



            /// <summary>
            /// Where关键字所跟的宾语
            /// </summary>
            public string Where { get; set; }


            /// <summary>
            /// InsertInto关键字后所跟的宾语
            /// 示例“tblEQIW_R_Section”
            /// 或者“tblEQIW_R_Section (fldSTCode,fldSTName,...)”这里是给出具体的字段
            /// </summary>
            public string InsertInto { get; set; }


            /// <summary>
            /// Values关键字所跟的宾语
            /// 示例：('你好',1,...)
            /// </summary>
            public string Values { get; set; }


            /// <summary>
            /// Update关键字后跟的宾语
            /// </summary>
            public string Update { get; set; }



            /// <summary>
            /// Set关键字后跟的宾语
            /// </summary>
            public string Set { get; set; }

        }



        public class SqlServer_Return
        {
            /// <summary>
            /// 基本查询返回的结果
            /// </summary>
            public DataTable Select_Data { get; set; }


            /// <summary>
            /// 影响记录数，为0说明没有任何行受影响
            /// 用于新增，更新，删除返回
            /// </summary>
            public int InfluenceCount { get; set; }


            /// <summary>
            /// 异常信息
            /// </summary>
            public string Error { get; set; }


            /// <summary>
            /// 内部异常
            /// </summary>
            public string InnerException { get; set; }


            /// <summary>
            /// 将Sql语句返回
            /// </summary>
            public string Sql { get; set; }
        }










        /// <summary>
        /// 执行Sql返回DataTable
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        private DataTable SqlQueryForDataTable(string dbName, string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings[dbName].ConnectionString);
            adapter.Fill(dt);
            return dt;
        }




        /// <summary>
        /// 执行Sql返回受影响行数
        /// </summary>
        /// <param name="dbName"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        private int ExecuteSqlCommand(string dbName, string sql)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[dbName].ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;
        }






    }
}
