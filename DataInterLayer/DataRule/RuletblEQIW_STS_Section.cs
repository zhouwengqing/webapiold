using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIW_STS_Section
    {




        /// <summary>
        /// 功能描述    ：  根据所选城市代码取得[tblEQIW_R_Section]表的河流代码
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-08-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <returns>tblEQIW_R_Section</returns>
        public IList<tblEQIW_STS_Section> GetRCodeBySTCodeByRole(string STCode, int fldYear, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_STS_Section_GetRCodeBySTCodeByRole uspGetRCode = new usp_tblEQIW_STS_Section_GetRCodeBySTCodeByRole();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                uspGetRCode.fldPLevel = Level;
                uspGetRCode.include = include;
                uspGetRCode.roleid = roleid;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_STS_Section> listAll = new List<tblEQIW_STS_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_STS_Section objData = new tblEQIW_STS_Section();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_STS_Section", "GetRCodeBySTCodeByRole", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_STS_Section", "GetRCodeBySTCodeByRole", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_STS_Section", "GetRCodeBySTCodeByRole", STCode);
            }
        }










        /// <summary>
        /// 功能描述    ：  根据断面级别、城市代码和河流代码获得[tblEQIW_R_Section]表的地表水断面名称和断面代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2011-12-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="RCode">河流代码</param>
        /// <param name="Level">断面级别</param>
        /// <param name="include">是否包含上级</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_STS_Section> GetRSCode(string STCode, string RCode, short Level, int include, int year, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_STS_Section_GetRSCodeByRole uspGetRSCode = new usp_tblEQIW_STS_Section_GetRSCodeByRole();
                uspGetRSCode.fldSTCode = STCode;
                uspGetRSCode.fldRCode = RCode;
                uspGetRSCode.fldSLevel = Level;
                uspGetRSCode.include = include;
                uspGetRSCode.fldYear = year;
                uspGetRSCode.roleid = roleid;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_STS_Section> listAll = new List<tblEQIW_STS_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_STS_Section objData = new tblEQIW_STS_Section();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_STS_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_STS_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_STS_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
        }















        /// <summary>
        /// 功能描述    ：  根据年份、城市代码和测点类型获得[tblEQIW_R_Session]表的河流代码和河流名称
        /// 创建者      ：  江帅
        /// 创建日期    ：  2011-03-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_STS_Section> GetRCodeByYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_STS_Session_GetRCodeByYear uspGetPCode = new usp_tblEQIW_STS_Session_GetRCodeByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_STS_Section> listAll = new List<tblEQIW_STS_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_STS_Section objData = new tblEQIW_STS_Section();
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
                throw new GetListException("打开数据库连接失败", "tblEQIW_R_Section", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "tblEQIW_R_Section", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "tblEQIW_R_Section", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }

        }






















    }
}
