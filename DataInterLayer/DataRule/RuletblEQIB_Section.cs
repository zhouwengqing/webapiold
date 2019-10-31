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
    public class RuletblEQIB_Section
    {


        /// <summary>
        /// 功能描述    ：  根据城市代码查询测点代码和名称，如果为空查找所有城市代码和名称
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-09-03
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="strUserName">用户名</param>
        /// <param name="strPLevel">测点级别（－1为全部）</param>
        /// <returns>IList</returns>
        public IList<tblEQIB_Section> GetSTCodeOrPCode(string STCode, string strUserName, string strPLevel, int iInclude)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIB_Section_GetNameAndCode uspGetNameAndCode = new usp_tblEQIB_Section_GetNameAndCode();
                uspGetNameAndCode.STCode = STCode;
                uspGetNameAndCode.UserName = strUserName;
                uspGetNameAndCode.PLevel = strPLevel;
                uspGetNameAndCode.Include = (iInclude == 1 ? true : false);
                tblData = uspGetNameAndCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIB_Section> listAll = new List<tblEQIB_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIB_Section objData = new tblEQIB_Section();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIB_Section", "GetSTCodeOrPCode", "STCode:" + STCode + " UserName:" + strUserName);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIB_Section", "GetSTCodeOrPCode", "STCode:" + STCode + " UserName:" + strUserName);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIB_Section", "GetSTCodeOrPCode", "STCode:" + STCode + " UserName:" + strUserName);
            }
        }








        /// <summary>
        /// 功能描述    ：  根据所选城市代码取得[tblEQIB_Section]表的河流信息
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-01-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <returns>tblEQIB_Section</returns>
        public IList<tblEQIB_Section> GetDataAndSelfBySTCode(string STCode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIB_Section_GetDataAndSelfBySTCode uspGetRCode = new usp_tblEQIB_Section_GetDataAndSelfBySTCode();
                uspGetRCode.fldSTCode = STCode;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIB_Section> listAll = new List<tblEQIB_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIB_Section objData = new tblEQIB_Section();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIB_Section", "GetDataAndSelfBySTCode", STCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIB_Section", "GetDataAndSelfBySTCode", STCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIB_Section", "GetDataAndSelfBySTCode", STCode);
            }
        }








        /// <summary>
        /// 功能描述    ：  根据所选城市代码取得[tblEQIB_Section]表的断面信息
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-01-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="RCode">河流代码</param>
        /// <returns>tblEQIB_Section</returns>
        public IList<tblEQIB_Section> GetRSCodeAndName(string STCode, string RCode)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIB_Section_GetRSCodeAndName uspGetRCode = new usp_tblEQIB_Section_GetRSCodeAndName();
                uspGetRCode.sSTcode = STCode;
                uspGetRCode.sRCode = RCode;
                tblData = uspGetRCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIB_Section> listAll = new List<tblEQIB_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIB_Section objData = new tblEQIB_Section();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIB_Section", "GetRSCodeAndName", STCode + ";" + RCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIB_Section", "GetRSCodeAndName", STCode + ";" + RCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIB_Section", "GetRSCodeAndName", STCode + ";" + RCode);
            }
        }











        /// <summary>
        /// 功能描述    ：  根据城市代码和年度获取河流信息
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-11-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <returns>IList</returns>
        public IList<tblEQIB_Section> getRive(string stcode, string year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIB_Section_GetRive usp = new usp_tblEQIB_Section_GetRive();
                usp.fldSTCode = stcode;
                usp.fldYear = year;
                tblData = usp.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIB_Section> listAll = new List<tblEQIB_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIB_Section objData = new tblEQIB_Section();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIB_Section", "GetBySTAndRCodeAndRSCode", "stcode:" + stcode);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIB_Section", "GetBySTAndRCodeAndRSCode", "stcode:" + stcode);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIB_Section", "GetBySTAndRCodeAndRSCode", "stcode:" + stcode);
            }
        }






















        /// <summary>
        /// 功能描述    ：  根据所选城市代码和河流代码取得[tblEQIB_Section]表的地表水断面代码
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-08-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="rcode">河流代码</param>
        /// <returns>tblEQIB_Section</returns>
        public IList<tblEQIB_Section> GetRSCodeByRCode(string stcode, string rcode, int year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIB_Section_GetRSCodeByRCode uspGetRSCode = new usp_tblEQIB_Section_GetRSCodeByRCode();
                uspGetRSCode.fldSTCode = stcode;
                uspGetRSCode.fldRCode = rcode;
                uspGetRSCode.fldYear = year;
                tblData = uspGetRSCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIB_Section> listAll = new List<tblEQIB_Section>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIB_Section objData = new tblEQIB_Section();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIB_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIB_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIB_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
        }












        /// <summary>
        /// 功能描述    ：  根据城市代码、年份和断面级别获得[tblEQIB_Section]表的记录
        /// 创建者      ：  王国华
        /// 创建日期    ：  2010-07-19
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
                usp_tblEQIB_Section_GetbyYearAndLevel uspByYear = new usp_tblEQIB_Section_GetbyYearAndLevel();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIB_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIB_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIB_Section", "GetByYearAndLevel", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }



























    }
}
