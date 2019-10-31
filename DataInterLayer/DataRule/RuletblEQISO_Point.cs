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
    public class RuletblEQISO_Point
    {


        /// <summary>
        /// 功能描述    ：  根据年份、测点级别、城市代码和测点类型获得[tblEQISO_Point]表的测点名称和测点代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2010-01-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年度</param>
        /// <param name="Level">测点级别</param>
        /// <returns>IList</returns>
        public IList<tblEQISO_Point> GetPCode(string STCode, int Year, short Level, int include, string datatype)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQISO_Point_GetPCode uspGetPCode = new usp_tblEQISO_Point_GetPCode();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                uspGetPCode.fldPLevel = -1;
                uspGetPCode.include = include;
                uspGetPCode.datatype = datatype;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQISO_Point> listAll = new List<tblEQISO_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQISO_Point objData = new tblEQISO_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQISO_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQISO_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQISO_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
        }



        /// <summary>
        /// 功能描述    ：  根据年份、测点级别、城市代码和测点类型获得[tblEQISO_Point]表的测点名称和测点代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2010-01-19
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年度</param>
        /// <returns>IList</returns>
        public IList<tblEQISO_Point> GetCountyPCode(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQISO_Point_GetCountyPCode uspGetPCode = new usp_tblEQISO_Point_GetCountyPCode();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQISO_Point> listAll = new List<tblEQISO_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQISO_Point objData = new tblEQISO_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQISO_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQISO_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQISO_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }



        /// <summary>
        /// 功能描述    ：  根据年份、城市代码、企业代码获得[tblEQISO_Point]表的测点名称和测点代码
        /// 创建者      ：  黄成
        /// 创建日期    ：  2011-11-22
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="entcode">企业代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQISO_Point> GetPCodeByYearAndEntCode(string STCode, string entcode, int Year, string datatype)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQISO_Point_GetPCodeByYearAndEntCode uspGetPCode = new usp_tblEQISO_Point_GetPCodeByYearAndEntCode();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldEntCode = entcode == "" || entcode == "undefined" || entcode == null ? "-1" : "'" + entcode + "'";
                uspGetPCode.fldYear = Year;
                uspGetPCode.datatype = datatype;

                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQISO_Point> listAll = new List<tblEQISO_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQISO_Point objData = new tblEQISO_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQISO_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQISO_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQISO_Point", "GetPCodeByYear",
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
        public IList<tblEQISO_Point> Getyearbystcodeandpcode(string pcode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQISO_Point_GetPCodeBystcodeandpcode uspGetPCode = new usp_tblEQISO_Point_GetPCodeBystcodeandpcode();
                uspGetPCode.fldPName = pcode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQISO_Point> listAll = new List<tblEQISO_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQISO_Point objData = new tblEQISO_Point();
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
                    "STCode:" + pcode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + pcode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCodeByYear",
                    "STCode:" + pcode + ",Year:" + Year.ToString());
            }
        }




    }
}
