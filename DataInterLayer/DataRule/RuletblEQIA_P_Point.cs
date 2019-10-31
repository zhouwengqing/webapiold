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
    public class RuletblEQIA_P_Point : BaseRule
    {
        
        /// <summary>
        /// 功能描述    ：  根据当前年份获得[tblEQIA_R_Point]表的记录供GIS使用
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>List</returns>
        public List<tblEQIA_P_Point> GetPointInfoForGis()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_P_Point_ForGis uspGetAll = new usp_tblEQIA_P_Point_ForGis(); 
                tblData = uspGetAll.ExecDataTable();
                if (tblData != null)
                {
                    List<tblEQIA_P_Point> listAll = new List<tblEQIA_P_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_P_Point objData = new tblEQIA_P_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_P_Point", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_P_Point", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_P_Point", "GetPointInfoForGis", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  根据当前年份获得[tblEQIA_P_Point]表的记录供GIS使用
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForPage(string STCode, string sType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_P_Point_ForPage uspGetAll = new usp_tblEQIA_P_Point_ForPage();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_P_Point", "GetPointInfoForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_P_Point", "GetPointInfoForPage", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_P_Point", "GetPointInfoForPage", "");
            }
        }


        /// <summary>
        /// 功能描述    ：  根据年份、城市代码获得[tblEQIA_P_Point]表的测点名称和测点代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-07-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_P_Point> GetPCodeByYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_P_Point_GetPCodeByYear uspGetPCode = new usp_tblEQIA_P_Point_GetPCodeByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_P_Point> listAll = new List<tblEQIA_P_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_P_Point objData = new tblEQIA_P_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_P_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_P_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_P_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  根据年份、测点级别、城市代码和测点类型获得[tblEQIA_P_Point]表的测点名称和测点代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2011-12-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年度</param>
        /// <param name="Level">测点级别</param>
        /// <param name="roleid">角色ID</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_P_Point> GetPCodeByRole(string STCode, int Year, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_P_Point_GetPCodeByRole uspGetPCode = new usp_tblEQIA_P_Point_GetPCodeByRole();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                uspGetPCode.fldPLevel = Level;
                uspGetPCode.include = include;
                uspGetPCode.roleid = roleid;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_P_Point> listAll = new List<tblEQIA_P_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_P_Point objData = new tblEQIA_P_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_P_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_P_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_P_Point", "GetPCodeByRole", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }
    }
}
