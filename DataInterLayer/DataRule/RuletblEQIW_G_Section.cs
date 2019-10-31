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
    /// 功能描述    ：  对表[tblEQIW_G_Section]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIW_G_Section : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  根据所选城市代码取得[tblEQIW_G_Section]表的河流代码
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-10-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="year">年度</param>
        /// <returns>tblEQIW_G_Section</returns>
        public IList<tblEQIW_G_Section> GetRCodeBySTCode(string STCode, string year, string Level, string include)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_G_Section_GetRCodeBySTCode uspGetRCode = new usp_tblEQIW_G_Section_GetRCodeBySTCode();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.year = year;
                uspGetRCode.Level = Convert.ToInt32(Level);
                uspGetRCode.include = Convert.ToInt32(include);
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_G_Section> listAll = new List<tblEQIW_G_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_G_Section objData = new tblEQIW_G_Section();
                        objData.MetaDataTable = tblTmp;
                        listAll.Add(objData);
                    }
                    tblData.Dispose();
                    return listAll;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_G_Section", "GetRCodeBySTCode", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_G_Section", "GetRCodeBySTCode", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_G_Section", "GetRCodeBySTCode", STCode);
            }
        }



























        /// <summary>
        /// 功能描述    ：  根据城市代码、年份和断面级别获得[tblEQIW_L_Section]表的记录
        /// 创建者      ：  顾兴明
        /// 创建日期    ：  2012-10-23
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <param name="Level">断面级别</param>
        /// <returns>DataTable</returns>
        public DataTable GetByYearAndLevel(string STCode, int Year, short Level)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_G_Section_GetbyYearAndLevel uspByYear = new usp_tblEQIW_G_Section_GetbyYearAndLevel();
                uspByYear.fldSTCode = STCode;
                uspByYear.fldYear = Year;
                uspByYear.fldSLevel = Level;
                tblData = uspByYear.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_G_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_G_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_G_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }
























    }
}
