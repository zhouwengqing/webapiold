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
    /// 功能描述    ：  对表[tblEQIN_T_BaseData_Living]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIN_T_BaseData_Living : BaseRule
    { 

        /// <summary>
        /// 功能描述    ：  取得所有测点最后的监测值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIN_T_Value_ByAllForGis()
        {
            try
            {
                usp_getEQIN_T_Value_ByAllForGis uspDel = new usp_getEQIN_T_Value_ByAllForGis();
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIN_T_BaseData_Living", "GetEQIN_T_Value_ByAllForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIN_T_BaseData_Living", "GetEQIN_T_Value_ByAllForGis", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIN_T_BaseData_Living", "GetEQIN_T_Value_ByAllForGis", "");
            }
        }
    }
}
