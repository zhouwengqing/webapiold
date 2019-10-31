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
    /// 功能描述    ：  对表[tblEQIN_T_Point]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIN_T_Point : BaseRule
    {

        /// <summary>
        /// 功能描述    ：  根据年份、城市代码获得[tblEQIN_T_Point]表的路段代码和路段名称
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>List</returns>
        public List<tblEQIN_T_Point> GetRDInfoForGis()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_T_Point_forGis uspGetRDCode = new usp_tblEQIN_T_Point_forGis();
                tblData = uspGetRDCode.ExecDataTable();
                if (tblData != null)
                {
                    List<tblEQIN_T_Point> listAll = new List<tblEQIN_T_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIN_T_Point objData = new tblEQIN_T_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIN_T_Point", "GetRDInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIN_T_Point", "GetRDInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIN_T_Point", "GetRDInfoForGis", "");
            }
        }






        /// <summary>
        /// 功能描述    ：  根据年份、城市代码获得[tblEQIN_T_Point]表的本城市和下级城市代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-08-20
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQIN_T_Point> GetSTCodeByYearandCode(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_T_Point_GetSTCodeByYearandCode uspGetRDCODE = new usp_tblEQIN_T_Point_GetSTCodeByYearandCode();
                uspGetRDCODE.fldSTCode = STCode;
                uspGetRDCODE.fldYear = Year;
                tblData = uspGetRDCODE.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIN_T_Point> listAll = new List<tblEQIN_T_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIN_T_Point objData = new tblEQIN_T_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIN_T_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIN_T_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIN_T_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }




















    }
}
