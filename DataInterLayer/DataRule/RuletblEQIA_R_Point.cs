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
    /// 功能描述    ：  对表[tblEQIA_R_Point]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIA_R_Point : BaseRule
    { 


        /// <summary>
        /// 功能描述    ：  根据表名查找表里的城市和类别
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-06-22
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="strTableName">表名</param>
        /// <param name="StrCode">城市代码</param> 
        /// <param name="strUserName">用户名</param>
        /// <param name="strType">类别("city"返回城市,否则返回类别)</param>
        public DataTable GetCityOrTypeName(string strTableName,string StrCode,string strUserName,string strType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_GetCityOrTypeName uspGetCityOrTypeName = new usp_GetCityOrTypeName();
                uspGetCityOrTypeName.name = strTableName;
                uspGetCityOrTypeName.stcode = StrCode;
                uspGetCityOrTypeName.username = strUserName;
                uspGetCityOrTypeName.type = strType;
                tblData = uspGetCityOrTypeName.ExecDataTable();
                if (tblData != null)
                    return tblData;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_R_Point", "GetCityOrTypeName", "STCode:" + StrCode + " TableName:" + strTableName);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetCityOrTypeName", "STCode:" + StrCode + " TableName:" + strTableName);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetCityOrTypeName", "STCode:" + StrCode + " TableName:" + strTableName);
            }
        }
         

        /// <summary>
        /// 功能描述    ：  根据当前年份获得[tblEQIA_R_Point]表的记录供GIS使用
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>List</returns>
        public List<tblEQIA_R_Point> GetPointInfoForGis(string SType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_ForGis uspGetAll = new usp_tblEQIA_R_Point_ForGis();
                uspGetAll.fldType = SType;
                tblData = uspGetAll.ExecDataTable();
                if (tblData != null)
                {
                    List<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_R_Point", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPointInfoForGis", "");
            }
        } 
        /// <summary>
        /// 功能描述    ：  根据当前年份获得[tblEQIA_R_Point]表的记录供GIS使用
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForPage(string STCode,string sType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_ForPage uspGetAll = new usp_tblEQIA_R_Point_ForPage();
                uspGetAll.Stcode = STCode;
                uspGetAll.Type = sType;
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_R_Point", "GetPointInfoForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetPointInfoForPage", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPointInfoForPage", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  根据年份、城市代码和测点类型获得[tblEQIA_R_Point]表的测点名称和测点代码
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-06-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_Point> GetPCodeByYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_GetPCodeByYear uspGetPCode = new usp_tblEQIA_R_Point_GetPCodeByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }


        /// <summary>
        /// 功能描述    ：  根据年份、城市代码和测点类型获得[tblEQIA_R_Point]表的测点名称和测点代码
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-06-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_Point> GetPCodeByYearHM(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_GetPCodeByYear_New uspGetPCode = new usp_tblEQIA_R_Point_GetPCodeByYear_New();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_R_Point", "GetPCodeByYearHM",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetPCodeByYearHM",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCodeByYearHM",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }


        /// <summary>
        /// 功能描述    ：  根据角色、年份、测点级别、城市代码和测点类型获得[tblEQIA_R_Point]表的测点名称和测点代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2011-12-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年度</param>
        /// <param name="Level">测点级别</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_Point> GetPCodeByRole(string STCode, int Year, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_GetPCodeByRole uspGetPCode = new usp_tblEQIA_R_Point_GetPCodeByRole();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                uspGetPCode.fldPLevel = Level;
                uspGetPCode.include = include;
                uspGetPCode.roleid = roleid;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_Point> listAll = new List<tblEQIA_R_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_Point objData = new tblEQIA_R_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_R_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }
    }
}
