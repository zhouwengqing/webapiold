using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  对表[tblEQIN_A_Basedata_Pre]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-08-03
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIN_A_Basedata_Pre : BaseRule
    {
        //类别
        private string eqiType = "eqin_a";


        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIN_A_BaseData_Pre]表的记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-08-03
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIN_A_BaseData_Pre的实体数组</param>
        /// <param name="input_new">要记录的录入时间</param>
        /// <param name="input_old">要修改的原来的录入时间</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAll(List<tblEQIN_A_BaseData_Pre> lstData, tblEQI_InputDate input_new, tblEQI_InputDate input_old)
        {
            int iRowIndex = 0;
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (iRowIndex = lstData.Count - 1; iRowIndex >= 0; iRowIndex--)
                        {
                            usp_tblEQIN_A_Basedata_Pre_Insert uspInsert = new usp_tblEQIN_A_Basedata_Pre_Insert();
                            uspInsert.ReceiveParameter(lstData[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("添加记录失败，未找到对应的记录");
                        }
                        RuletblEQI_InputDate Rule_inputdate = new RuletblEQI_InputDate();                    
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("打开数据库连接失败", "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (iRowIndex + 1) + "，错误原因：同一城市同一网格同一时间的数据已经存在",
                            "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIN_A_Basedata_Pre", "InsertAll", "");
                    }
                }
            }
        }


    }
}
