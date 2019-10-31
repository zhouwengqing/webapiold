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
    public class RuletblEQIA_STS_Point
    {

        /// <summary>
        /// 功能描述    ：  根据年份、测点级别、城市代码和测点类型获得[tblEQIA_R_Point]表的测点名称和测点代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-04-30
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年度</param>
        /// <param name="Level">测点级别</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_Point> GetPCode(string STCode, int Year, short Level, int include)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_Point_GetPCode uspGetPCode = new usp_tblEQIA_R_Point_GetPCode();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                uspGetPCode.fldPLevel = Level;
                uspGetPCode.include = include;
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIA_R_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIA_R_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIA_R_Point", "GetPCode", "STCode:" + STCode + ",Year:" + Year.ToString() + ",Level:" + Level.ToString());
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
        public IList<tblEQIA_STS_Point> GetPCodeByYear(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_STS_Point_GetPCodeByYear uspGetPCode = new usp_tblEQIA_STS_Point_GetPCodeByYear();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_STS_Point> listAll = new List<tblEQIA_STS_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_STS_Point objData = new tblEQIA_STS_Point();
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
        public IList<tblEQIA_STS_Point> GetPCodeByRole(string STCode, int Year, short Level, int include, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_STS_Point_GetPCodeByRole uspGetPCode = new usp_tblEQIA_STS_Point_GetPCodeByRole();
                uspGetPCode.fldSTCode = STCode;
                uspGetPCode.fldYear = Year;
                uspGetPCode.fldPLevel = Level;
                uspGetPCode.include = include;
                uspGetPCode.roleid = roleid;
                tblData = uspGetPCode.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_STS_Point> listAll = new List<tblEQIA_STS_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_STS_Point objData = new tblEQIA_STS_Point();
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
