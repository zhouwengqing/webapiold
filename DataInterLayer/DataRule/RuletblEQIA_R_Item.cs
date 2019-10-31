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
    /// 功能描述    ：  对表[tblEQIA_R_Item]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIA_R_Item : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  获得[tblEQIA_R_Item]表的所有记录
        /// 创建者      ：  ZCH
        /// 创建日期    ：  2012-08-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllforGisData()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_getEQIA_R_ItemforGis uspByAll = new usp_getEQIA_R_ItemforGis();
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
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Item", "GetAllforGisData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Item", "GetAllforGisData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Item", "GetAllforGisData", "");
            }
        }



        /// <summary>
        /// 功能描述    ：  根据项目代码取得[tblEQIA_R_Item]表的部分记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-05-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iCode">项目代码</param>
        /// <returns>tblEQIA_R_Item</returns>
        public tblEQIA_R_Item ByItemCode(string iCode)
        {
            try
            {
                usp_tblEQIA_R_Item_ByItemCode uspByItemCode = new usp_tblEQIA_R_Item_ByItemCode();
                uspByItemCode.fldItemCode = iCode;
                DataTable tblData = uspByItemCode.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_Item objData = new tblEQIA_R_Item();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
        }


        /// <summary>
        /// 功能描述    ：  根据项目代码取得因子表的部分记录  这是个通用的方法
        /// 创建者      ：  熊瑞竹
        /// 创建日期    ：  2017-06-02
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iCode">项目代码</param>
        /// <returns>DataTable</returns>
        public tblEQIA_R_Item ByItemCodes(string iCode, string sbtype, string where)
        {
            try
            {
                usp_tblEQI_Com_Item_ByItemCode uspByItemCode = new usp_tblEQI_Com_Item_ByItemCode();
                uspByItemCode.fldItemCode = iCode;
                uspByItemCode.fldSbtype = sbtype;
                uspByItemCode.strsql = where;
                DataTable tblData = uspByItemCode.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_Item objData = new tblEQIA_R_Item();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_Item", "ByItemCode", iCode);
            }
        }

        /// <summary>
        /// 功能描述    ：  获得[tblEQIA_R_Item]表以及项目标准值记录
        /// 创建者      ：  姚磊
        /// 创建日期    ：  2017-03-13
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
        /// 功能描述    ：  获得[tblEQIA_R_Item]表的所有记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-28
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
                usp_tblEQIA_R_Item_ByAll uspByAll = new usp_tblEQIA_R_Item_ByAll();
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
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_Item", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_Item", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_Item", "GetAllData", "");
            }
        }
    }
}
