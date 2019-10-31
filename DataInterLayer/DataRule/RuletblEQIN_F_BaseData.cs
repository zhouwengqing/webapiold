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
    public class RuletblEQIN_F_BaseData : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  取得功能区噪声统计
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-09-10
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable </returns>
        public DataTable GetEQIN_F_Value_NoiseStat(string STCode, string BeginDate, string EndDate)
        {
            try
            {
                usp_tblEQIN_F_Report_NoiseStat_Page uspDel = new usp_tblEQIN_F_Report_NoiseStat_Page();
                uspDel.BeginDate = BeginDate;
                uspDel.EndDate = EndDate;
                uspDel.fldSTCode = STCode;
                DataTable dt = uspDel.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIN_F_BaseData", "GetEQIN_F_Value_NoiseStat", "");
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIN_F_BaseData", "GetEQIN_F_Value_NoiseStat", "");
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIN_F_BaseData", "GetEQIN_F_Value_NoiseStat", "");
            }
        }
    }
}
