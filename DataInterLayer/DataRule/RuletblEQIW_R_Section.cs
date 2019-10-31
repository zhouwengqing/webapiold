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
    /// 功能描述    ：  对表[tblEQIW_R_Section]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIW_R_Section : BaseRule
    {

        /// <summary>
        /// 功能描述    ：  根据当前年份获得水质断面表的记录供GIS使用
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-03-30
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>DataTable</returns>
        public DataTable GetPointInfoForGis(string sType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_ForGis uspGetAll = new usp_tblEQIW_R_Section_ForGis();
                uspGetAll.fldType = sType;
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetPointInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetPointInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetPointInfoForGis", "");
            }
        }
        /// <summary>
        /// 功能描述    ：  取得所有有经纬度的断面
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-07-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="STCode">城市代码</param>
        /// <param name="Rcode">断面代码</param>
        /// <returns>DataTable</returns>
        public DataTable GetAllSectionForPage(string STCode,string Rcode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_AllSectionFor_Page uspGetAll = new usp_tblEQIW_R_Section_AllSectionFor_Page();
                uspGetAll.fldStcode = STCode;
                uspGetAll.fldRcode = Rcode;
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetAllSectionForPage", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetAllSectionForPage", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetAllSectionForPage", "");
            }
        }



        /// <summary>
        /// 取得主要水系信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetRiverSys(string SType)
        { 
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_RiverSystem_ByType uspGetAll = new usp_tblEQIW_R_RiverSystem_ByType();
                uspGetAll.fldType = SType;
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetRiverSys", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetRiverSys", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetRiverSys", "");
            }
        }


        /// <summary>
        /// 取得干流/支流 断面信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetSectionByRiverSystemType(string SType,int iYear)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_ByRiverSystemType uspGetAll = new usp_tblEQIW_R_Section_ByRiverSystemType();
                uspGetAll.fldType = SType;
                uspGetAll.fldYear = iYear;
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetSectionByRiverSystemType", "SType:" + SType);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetSectionByRiverSystemType", "SType:" + SType);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetSectionByRiverSystemType", "SType:" + SType);
            }
        }


        /// <summary>
        /// 取得湖泊/水库断面信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetEQIW_L_SectionByRiverSystemType(string SType, int iYear)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_L_Section_ByRiverSystemType uspGetAll = new usp_tblEQIW_L_Section_ByRiverSystemType();
                uspGetAll.fldType = SType;
                uspGetAll.fldYear = iYear;
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetEQIW_L_SectionByRiverSystemType", "SType:" + SType);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetEQIW_L_SectionByRiverSystemType", "SType:" + SType);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetEQIW_L_SectionByRiverSystemType", "SType:" + SType);
            }
        }

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
        public IList<tblEQIW_R_Section> GetRCodeBySTCodeByRole(string STCode, int fldYear, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole uspGetRCode = new usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                uspGetRCode.fldPLevel = Level;
                uspGetRCode.include = include;
                uspGetRCode.roleid = roleid;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetRCodeBySTCodeByRole", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetRCodeBySTCodeByRole", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Section", "GetRCodeBySTCodeByRole", STCode);
            }
        }

        /// <summary>
        /// 功能描述    ：  根据所选城市代码取得[tblEQIW_R_Section]表的河流代码
        /// 创建者      ： 熊瑞竹
        /// 创建日期    ：  2017-09-13
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <returns>tblEQIW_R_Section</returns>
        public IList<tblEQIW_R_Section> GetHMRCodeBySTCodeByRole(string STCode, int fldYear)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole_New uspGetRCode = new usp_tblEQIW_R_Section_GetRCodeBySTCodeByRole_New();
                uspGetRCode.fldSTCode = STCode;
                uspGetRCode.fldYear = fldYear;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetHMRCodeBySTCodeByRole", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetHMRCodeBySTCodeByRole", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Section", "GetHMRCodeBySTCodeByRole", STCode);
            }
        }
        /// <summary>
        /// 功能描述    ：  根据所选城市代码和河流代码取得[tblEQIW_R_Section]表的地表水交界断面代码
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：   2009-12-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="rcode">河流代码</param>
        /// <returns>tblEQIW_R_Section</returns>
        public IList<tblEQIW_R_Section> GetRSCodeByRCode(string stcode, string rcode, int year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRSCodeByRCode uspGetRSCode = new usp_tblEQIW_R_Section_GetRSCodeByRCode();
                uspGetRSCode.fldSTCode = stcode;
                uspGetRSCode.fldRCode = rcode;
                uspGetRSCode.fldYear = year;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_R_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
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
        public IList<tblEQIW_R_Section> GetRSCode(string STCode, string RCode, short Level, int include, int year, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRSCodeByRole uspGetRSCode = new usp_tblEQIW_R_Section_GetRSCodeByRole();
                uspGetRSCode.fldSTCode = STCode;
                uspGetRSCode.fldRCode = RCode;
                uspGetRSCode.fldSLevel = Level;
                uspGetRSCode.include = include;
                uspGetRSCode.fldYear = year;
                uspGetRSCode.roleid = roleid;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode + ",RCode:" + RCode + ",Level:" + Level.ToString() + ",include:" + include.ToString());
            }
        }


        /// <summary>
        /// 功能描述    ：  根据城市代码和年份取的河流断面
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2017-07-06
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="RCode">河流代码</param>
        /// <param name="Level">断面级别</param>
        /// <param name="include">是否包含上级</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_R_Section> GetRSCodeandRCode(string STCode, short  Level, string year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_R_Section_GetRCodeandRSCodeBySTCode uspGetRSCode = new usp_tblEQIW_R_Section_GetRCodeandRSCodeBySTCode();
                uspGetRSCode.fldSTCode = STCode;                
                uspGetRSCode.fldPLevel = Level;             
                uspGetRSCode.fldYear = year;               
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_R_Section> listAll = new List<tblEQIW_R_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_R_Section objData = new tblEQIW_R_Section();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode );
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetRSCode", "STCode:" + STCode);
            }
           
        }


        /// <summary>
        /// 功能描述    ：  根据城市代码和年份取的地表水基本信息
        /// 创建者      ：  徐雍文
        /// 创建日期    ：  2018-01-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="year">年份</param>
        /// <param name="stcode">城市代码</param>
        /// <returns></returns>
        public DataTable gettblEQIW_R_Sectionbystcode(string year, string stcode,string type)
        {
            DataTable dt = new DataTable();
            try
            {
                usp_tblEQIW_R_SectionSelectByStcode uspGetStcode = new usp_tblEQIW_R_SectionSelectByStcode();
                uspGetStcode.fldstcode = stcode;
                uspGetStcode.fldyear = year;
                uspGetStcode.fldtype = type;
                dt = uspGetStcode.ExecDataTable();
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQIW_R_Section", "GetRSCode", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIW_R_Section", "GetRSCode", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIW_R_Section", "GetRSCode", "");
            }

        }
    }
}
