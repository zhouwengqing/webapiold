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
    public class RuletblEQIN_F_Point : BaseRule
    {

        /// <summary>
        /// 功能描述    ：  根据年份、城市代码获得[tblEQIN_F_Point]表的功能区
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="sType">类别('城市','测点')</param>
        /// <param name="STCode">城市代码</param>
        /// <param name="sYear">年份</param>
        /// <returns>DataTable</returns>
        public DataTable GetRDInfoForGis(int sYear,string STCode,string sType)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_F_Point_forPage uspGetRDCode = new usp_tblEQIN_F_Point_forPage();
                uspGetRDCode.fldYear = sYear;
                uspGetRDCode.Stcode = STCode;
                uspGetRDCode.Type = sType;
                tblData = uspGetRDCode.ExecDataTable();
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblEQIN_F_Point", "GetRDInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIN_F_Point", "GetRDInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIN_F_Point", "GetRDInfoForGis", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  根据年份、城市代码获得[tblEQIN_F_Point]表的测点代码和测点名称
        /// 创建者      ：  张浩
        /// 创建日期    ：  2011-12-30
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQIN_F_Point> GetPCodeByYear(string STCode, int Year, int roleid)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_F_Point_GetPCodeByYearandRole uspGetGDCODE = new usp_tblEQIN_F_Point_GetPCodeByYearandRole();
                uspGetGDCODE.fldSTCode = STCode;
                uspGetGDCODE.fldYear = Year;
                uspGetGDCODE.roleid = roleid;
                tblData = uspGetGDCODE.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIN_F_Point> listAll = new List<tblEQIN_F_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIN_F_Point objData = new tblEQIN_F_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIN_F_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIN_F_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIN_F_Point", "GetPCodeByYear",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }
    }
}
