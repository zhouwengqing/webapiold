using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
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
    /// 功能描述    ：  对表[RuletblEQIW_R_HourData_Auto]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIW_R_HourData_Auto: BaseRule
    {
        /// <summary>
        /// 功能描述：获取近一小时的数据
        /// 创建者：熊瑞竹
        /// 创建日期：2018-03-17
        /// </summary>
        /// <param name="viewname">对应视图名称</param>
        /// <returns></returns>
        public DataTable getOneHour_Data(string viewname,string strwhere )
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        usp_EQIW_R_HourData_Auto_ohd param = new usp_EQIW_R_HourData_Auto_ohd();
                        param.vwTableName = viewname;
                        param.strsear = strwhere;
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


        /// <summary>
        /// 功能描述：根据各个时间类型获得均值
        /// 创建  人：周文卿
        /// 创建时间：20180531
        /// 修改  人：
        /// 修改时间：
        /// </summary>
        /// <param name="Timetype">时间类型</param>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="PointCode">点位</param>
        /// <param name="ItemCode">因子</param>
        /// <returns></returns>

        public DataTable GetAutoAvg(string Timetype,string BeginDate,string EndDate,string PointCode,string ItemCode)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        usp_eqiw_r_autodataAvg param = new usp_eqiw_r_autodataAvg();
                        param.timetype = Timetype;
                        param.bdate = BeginDate;
                        param.edate = EndDate;
                        param.rscode = PointCode;
                        param.itemcode = ItemCode;
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

        /// <summary>
        /// 功能描述：获得小时值
        /// 创建  人：周文卿
        /// 创建时间：20180531
        /// 修改  人：
        /// 修改时间：
        /// 修改原因：
        /// </summary>
        /// <param name="BeginDate">开始时间</param>
        /// <param name="EndDate">结束时间</param>
        /// <param name="PointCode">点位代码</param>
        /// <param name="ItemCode">因子代码</param>
        /// <returns></returns>
        public DataTable GetHourData(string BeginDate, string EndDate, string PointCode, string ItemCode)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        DataTable dt = new DataTable();
                        usp_eqiw_r_autodataHour param = new usp_eqiw_r_autodataHour();                      
                        param.bdate = BeginDate;
                        param.edate = EndDate;
                        param.rscode = PointCode;
                        param.itemcode = ItemCode;
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
