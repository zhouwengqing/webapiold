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
    /// 功能描述    ：  对表[tblEQIS_P_Point]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIS_P_Point : BaseRule
    {
   

        /// <summary>
        /// 功能描述    ：  根据当前年份获得海洋生物残毒断面表的记录供GIS使用
        /// 创建者      ：  du
        /// 创建日期    ：  2015-03-21
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForGis()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIS_P_Point_ForGis uspGetAll = new usp_tblEQIS_P_Point_ForGis();
                tblData = uspGetAll.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQIS_P_Point", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIS_P_Point", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIS_P_Point", "GetPointInfoForGis", "");
            }
        }
       

    }
}


