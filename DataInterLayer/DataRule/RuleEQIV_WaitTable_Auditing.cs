using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
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
    /// <summary>
    /// 功能描述：审核加载数据方法  
    /// 创建者：熊瑞竹
    /// 创建日期：2017-08-21
    /// 审核
    /// </summary>
    public class RuleEQIV_WaitTable_Auditing
    {
        /// <summary>
        /// 功能描述：生态、生物监测审核根据业务类型加载数据
        /// 创建者：熊瑞竹
        /// 创建日期：2017-08-21
        /// 修改者：
        /// 修改日期：
        /// </summary>
        /// <param name="viewname">查询数据的视图名称</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="sbtype">具体业务类型</param>
        /// <returns>查询到的数据，以DataTable数据类型返回</returns>
        public DataTable GetEqiv_AuditingData(string viewname,string strwhere,string sbtype)
        {
            try
            {

                DataTable dt = new DataTable();
                usp_EQIV_Common_Auditing param = new usp_EQIV_Common_Auditing();
                param.viewname = viewname;
                param.strwhere = strwhere;
                param.sbtype = sbtype;
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
                throw new GetAllException("打开数据库连接失败", "RuleEQIV_WaitTable_Auditing", "GetEqiv_AuditingData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuleEQIV_WaitTable_Auditing", "GetEqiv_AuditingData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuleEQIV_WaitTable_Auditing", "GetEqiv_AuditingData", "");
            }
        }


        /// <summary>
        /// 功能描述：查询监测数据审核中断面的水质类别以及同比和环比
        /// 创建者：熊瑞竹
        /// 创建日期：2018/03/02
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="edt">执行标准</param>
        /// <returns></returns>
        public DataTable Getsectionstage(string type, string edt)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        GetStagebySectItemval param = new GetStagebySectItemval();
                        param.btype = type;
                        param.edition = edt;
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
                        throw new UpdateException("打开数据库连接失败", "RuleEQIV_WaitTable_Auditing", "Getsectionstage", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new UpdatePKException("相同的记录已经存在，违反表的唯一键约束", "RuleEQIV_WaitTable_Auditing",
                            "Getsectionstage", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("执行Sql语句失败", "RuleEQIV_WaitTable_Auditing", "Getsectionstage", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new UpdateException(e.Message, "RuleEQIV_WaitTable_Auditing", "Getsectionstage", "");
                    }
                }
            }
        }


        /// <summary>
        /// 功能描述：给超三、四、五类及小于检出限的加颜色
        /// 创建者：熊瑞竹
        /// 创建日期：2018/03/13
        /// </summary>
        /// <param name="type">业务类型</param>
        /// <param name="edt">执行标准</param>
        /// <returns></returns>
        public DataTable GetStdColorData(string cond, string btime, string etime,string point,string ItemCode)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        usp_tblEQIW_StdColorData param = new usp_tblEQIW_StdColorData();
                        param.cond = cond;
                        param.btime = btime;
                        param.etime = etime;
                        param.point = point;
                        param.ItemCode = ItemCode;
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
                        throw new UpdateException("打开数据库连接失败", "RuleEQIV_WaitTable_Auditing", "GetStdColorData", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new UpdatePKException("相同的记录已经存在，违反表的唯一键约束", "RuleEQIV_WaitTable_Auditing",
                            "GetStdColorData", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("执行Sql语句失败", "RuleEQIV_WaitTable_Auditing", "GetStdColorData", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new UpdateException(e.Message, "RuleEQIV_WaitTable_Auditing", "GetStdColorData", "");
                    }
                }
            }
        }
    }
}
