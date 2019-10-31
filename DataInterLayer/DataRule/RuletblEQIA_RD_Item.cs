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
    /// 功能描述    ：  对表[tblEQIA_RD_Item]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIA_RD_Item : BaseRule
    {



        /// <summary>
        /// 功能描述    ：  获得[tblEQIA_RD_Item]表的所有记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-07-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="code">项目代码</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_RD_Item> GetAllListBycode(string code)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_RD_Item_ByCode uspBycode = new usp_tblEQIA_RD_Item_ByCode();
                uspBycode.code = code;
                tblData = uspBycode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_RD_Item> listAll = new List<tblEQIA_RD_Item>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_RD_Item objData = new tblEQIA_RD_Item();
                        objData.MetaDataTable = tblTmp;
                        listAll.Add(objData);
                    }
                    return listAll;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_RD_Item", "GetAllListBycode", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_RD_Item", "GetAllListBycode", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_RD_Item", "GetAllListBycode", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获得[tblEQIA_R_Item]表以及项目标准值记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-07-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetItemAndSTDDataByItemCode(string itemCode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Item_GetDaySTDValueByItemCode uspByAll = new usp_tblEQIA_R_Item_GetDaySTDValueByItemCode();
                uspByAll.fldItemCode = itemCode;
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_Item";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Item", "GetItemAndSTDData", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  获得[tblEQIA_RD_Item]表的所有记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-06-03
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllData()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_RD_Item_ByAll uspByAll = new usp_tblEQIA_RD_Item_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_RD_Item";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_RD_Item", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_RD_Item", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_RD_Item", "GetAllData", "");
            }
        }










    }
}
