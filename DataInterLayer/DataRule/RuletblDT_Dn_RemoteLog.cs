using System;
using System.Data.SqlClient;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  对远程的日志表操作
    /// 创建者      ：  马立军
    /// 创建日期    ：  2010-01-30
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblDT_Dn_RemoteLog : BaseRule
    {
        ///// <summary>
        ///// 功能描述    ：  添加基础信息表的日志记录
        ///// 创建者      ：  马立军
        ///// 创建日期    ：  2010-01-30
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="objInsert">需要添加的实体类</param>
        ///// <returns>返回新增记录的PK主键的值</returns>
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
        //        throw new InsertException("打开数据库连接失败", "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //    catch (DBPKException e)
        //    {
        //        throw new InsertPKException("相同的记录已经存在，违反表的唯一键约束", "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new InsertException("执行Sql语句失败", "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        throw new InsertException(e.Message, "RuletblDT_Dn_RemoteLog", "Insert", objInsert.ToString());
        //    }
        //}
    }
}
