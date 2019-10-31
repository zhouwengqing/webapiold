using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  对表[tblItem_Recording ]的数据操作
    /// 创建者      ：  周文卿
    /// 创建日期    ：  2018-01-29
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblItem_Recording : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  添加[tblItem_Recording]表的记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2018-01-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public long Insert(tblItem_Recording objInsert)
        {
            try
            {
                usp_tblItem_Recording_Insert uspInsert = new usp_tblItem_Recording_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("插入新记录失败");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblItem_Recording", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertException("相同的记录已经存在，违反表的唯一键约束", "RuletblItem_Recording", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblItem_Recording", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblItem_Recording", "Insert", objInsert.ToString());
            }
        }


        /// <summary>
        /// 功能描述    ：  根据业务类别查询因子修改数据
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2018-01-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="type">业务类别</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public DataTable getbytype(string type)
        {
            try
            {
                getitembytype it = new getitembytype();
                it.fldType = type;
                DataTable dt = it.ExecDataTable();
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblItem_Recording", "getbytype", type);
            }
            catch (DBPKException e)
            {
                throw new InsertException("相同的记录已经存在，违反表的唯一键约束", "RuletblItem_Recording", "getbytype", type);
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblItem_Recording", "getbytype", type);
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblItem_Recording", "getbytype", type);
            }
        }
    }
}
