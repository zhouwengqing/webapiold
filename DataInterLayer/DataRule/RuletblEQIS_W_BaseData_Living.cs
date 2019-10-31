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
    /// 功能描述    ：  对表[tblEQIS_W_BaseData_Living]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIS_W_BaseData_Living : BaseRule
    { 

        /// <summary>
        /// 功能描述    ：  获取水质所有点最新监测值及超标项
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>   
        /// <returns>DataTable </returns>
        public DataTable GetEQIS_W_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIS_W_Value_ByAllForGis uspDel = new usp_getEQIS_W_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIS_W_BaseData_Living", "GetEQIS_W_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIS_W_BaseData_Living", "GetEQIS_W_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIS_W_BaseData_Living", "GetEQIS_W_Value_ByAllForGis", "");
            }
        }
    }
}
