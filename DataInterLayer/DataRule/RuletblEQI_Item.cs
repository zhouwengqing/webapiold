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
    /// 功能描述    ：  对表[RuletblEQI_Item]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2015-03-17
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQI_Item : BaseRule
    { 

        /// <summary>
        /// 功能描述    ：  根据业务类型获取相应的监测因子信息
        /// 创建者      ：  du
        /// 创建日期    ：  2015-03-11
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetItemInfo(string strType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblItemInfo_GIS usp = new usp_tblItemInfo_GIS();
                usp.Type = strType;
                tblData = usp.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_Item", "GetItemInfo", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_Item", "GetItemInfo", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Item", "GetItemInfo", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  根据业务类型获取相应的监测因子组信息
        /// 创建者      ：  du
        /// 创建日期    ：  2015-04-3
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetItemGroupInfo(string strType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblItemGroupInfo_GIS usp = new usp_tblItemGroupInfo_GIS();
                usp.Type = strType;
                tblData = usp.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQI_Item", "GetItemGroupInfo", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_Item", "GetItemGroupInfo", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Item", "GetItemGroupInfo", "");
            }
        }

    }
}
