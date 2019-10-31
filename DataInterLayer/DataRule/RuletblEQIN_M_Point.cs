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
    public class RuletblEQIN_M_Point
    {



        /// <summary>
        /// 功能描述    ：  根据年份、城市代码获得[tblEQIN_M_Point]表的本城市和下级城市代码
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-08-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="STCode">城市代码</param>
        /// <param name="Year">年份</param>
        /// <returns>IList</returns>
        public IList<tblEQIN_M_Point> GetSTCodeByYearandCode(string STCode, int Year)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIN_M_Point_GetSTCodeByYearandCode uspGetGDCODE = new usp_tblEQIN_M_Point_GetSTCodeByYearandCode();
                uspGetGDCODE.fldSTCode = STCode;
                uspGetGDCODE.fldYear = Year;
                tblData = uspGetGDCODE.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIN_M_Point> listAll = new List<tblEQIN_M_Point>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIN_M_Point objData = new tblEQIN_M_Point();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQIN_M_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQIN_M_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQIN_M_Point", "GetSTCodeByYearandCode",
                    "STCode:" + STCode + ",Year:" + Year.ToString());
            }
        }






















    }
}
