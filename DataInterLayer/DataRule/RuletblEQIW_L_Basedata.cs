using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIW_L_Basedata
    {


        //类别
        private string eqiType = "eqiw_l";


        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIW_L_Basedata]表的记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-12-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIW_L_Basedata的实体数组</param>
        /// <param name="lstCurrentData">需要更新的本城市的实体类数组</param>
        /// <param name="lstJuniorData">需要更新的下级城市的实体类数组</param>
        /// <param name="lstAud">审核未通过原因的实体类数组</param>
        /// <param name="new_CityID_Operate">更新后的操作城市ID</param>
        /// <param name="new_CityID_Submit">更新后的提交城市ID</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAllOrUpdateNoPassAll(List<tblEQIW_L_Basedata> lstData, List<tblEQIW_L_Basedata_Pre> lstCurrentData, List<tblEQIW_L_Basedata_Pre> lstJuniorData, List<tblEQIW_L_Auditing> lstAud, List<tblFW_AuditingLog> lstAudLog, string new_CityID_Operate, string new_CityID_Submit, int grade, string comment, string operID2, string submit2, string flag2)
        {
            int iRowIndex = 0;
            string dateAll = "", date = "";
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        //更新
                        for (iRowIndex = 0; iRowIndex < lstCurrentData.Count; iRowIndex++)
                        {
                            usp_tblEQIW_L_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIW_L_Basedata_Pre_UpdateCity();
                            uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                            uspUpdate.new_fldFlag = Int16.Parse(flag2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Operate = Int32.Parse(operID2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Submit = submit2.Split(',')[iRowIndex];
                            uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("修改记录失败，未找到对应的记录");

                            date = lstCurrentData[iRowIndex].fldYear.ToString() + lstCurrentData[iRowIndex].fldMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstCurrentData[iRowIndex].fldYear;
                                usp_upin.fldMonth = lstCurrentData[iRowIndex].fldMonth;
                                usp_upin.fldDay = lstCurrentData[iRowIndex].fldDay;
                                usp_upin.fldComment = comment;
                                int iResultUpIn = usp_upin.ExecNoQuery(conn, tran);
                                if (iResultUpIn <= 0)
                                    throw new Exception("修改或添加失败");
                            }
                            dateAll += date + ",";
                        }
                        //数据录入到原始表
                        for (iRowIndex = 0; iRowIndex < lstData.Count; iRowIndex++)
                        {
                            //if (lstData[iRowIndex].fldItemValue != -1)
                            //{
                            //把数据录入到_RAW 表中
                            usp_tblEQI_InsertByType usp_ins = new usp_tblEQI_InsertByType();
                            usp_ins.autoid = lstData[iRowIndex].fldAutoID;
                            usp_ins.type = eqiType;
                            int iResultInsertByType = usp_ins.ExecNoQuery(conn, tran);
                            if (iResultInsertByType <= 0)
                                throw new Exception("添加记录失败，未找到对应的记录");

                            //判断是否是删除数据， 把没有删除的数据录入到原始表里面去
                            usp_tblEQI_GetByType usp_get = new usp_tblEQI_GetByType();
                            usp_get.autoid = lstData[iRowIndex].fldAutoID;
                            usp_get.type = eqiType;
                            DataTable dt = usp_get.ExecDataTable();
                            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "0")
                            {
                                usp_tblEQIW_L_Basedata_Insert_byR uspInsert = new usp_tblEQIW_L_Basedata_Insert_byR();
                                uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("添加记录失败，未找到对应的记录");
                            }
                            //}
                            usp_tblEQIW_L_Basedata_Pre_Delete usp_pre_Delete = new usp_tblEQIW_L_Basedata_Pre_Delete();
                            usp_pre_Delete.fldAutoID = Int32.Parse(lstData[iRowIndex].fldAutoID.ToString());
                            int iResultdelete = usp_pre_Delete.ExecNoQuery(conn, tran);
                            if (iResultdelete <= 0)
                                throw new Exception("删除临时表记录失败，未找到对应的记录");

                            date = lstData[iRowIndex].fldYear.ToString() + lstData[iRowIndex].fldMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstData[iRowIndex].fldYear;
                                usp_upin.fldMonth = lstData[iRowIndex].fldMonth;
                                usp_upin.fldDay = lstData[iRowIndex].fldDay;
                                usp_upin.fldComment = comment;
                                int iResultUpIn = usp_upin.ExecNoQuery(conn, tran);
                                if (iResultUpIn <= 0)
                                    throw new Exception("修改或添加失败");
                            }
                            dateAll += date + ",";

                        }
                        //数据改为本级城市审核未通过状态
                        for (iRowIndex = 0; iRowIndex < lstCurrentData.Count; iRowIndex++)
                        {
                            usp_tblEQIW_L_Basedata_Pre_UpdateFlag uspUpdate = new usp_tblEQIW_L_Basedata_Pre_UpdateFlag();
                            uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                            uspUpdate.new_fldFlag = 12;
                            uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            //if (iResultInsert <= 0)
                            //    throw new Exception("修改记录失败，未找到对应的记录");
                        }
                        //数据改为下级城市审核未通过状态
                        for (iRowIndex = 0; iRowIndex < lstJuniorData.Count; iRowIndex++)
                        {
                            usp_tblEQIW_L_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIW_L_Basedata_Pre_UpdateCity();
                            uspUpdate.ReceiveParameter_Old(lstJuniorData[iRowIndex]);
                            uspUpdate.new_fldCityID_Operate = Convert.ToInt32(new_CityID_Operate.Split(',')[iRowIndex]);
                            uspUpdate.new_fldCityID_Submit = new_CityID_Submit.Split(',')[iRowIndex];
                            uspUpdate.new_fldFlag = -2;
                            uspUpdate.new_fldDate_Operate = DateTime.Now;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("修改记录失败，未找到对应的记录");
                        }
                        //审核未通过原因写入数据表
                        for (iRowIndex = 0; iRowIndex < lstAud.Count; iRowIndex++)
                        {
                            usp_tblEQIW_L_Auditing_Insert uspInsert = new usp_tblEQIW_L_Auditing_Insert();
                            uspInsert.ReceiveParameter(lstAud[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery();
                            if (iResultInsert <= 0)
                                throw new Exception("添加审核未通过原因失败，未找到对应的记录");
                        }
                        //审批操作记录保存到审核日志
                        for (iRowIndex = 0; iRowIndex < lstAudLog.Count; iRowIndex++)
                        {
                            usp_tblFW_AuditingLog_Insert uspInsert = new usp_tblFW_AuditingLog_Insert();
                            uspInsert.ReceiveParameter(lstAudLog[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery();
                            if (iResultInsert <= 0)
                                throw new Exception("添加审核日志未通过原因失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("打开数据库连接失败", "RuletblEQIW_L_Basedata", "InsertAllOrUpdateNoPassAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (lstData[iRowIndex].fldErrorRowIndex) + "，错误原因：同一测点同一时间同一项目的数据已经存在",
                            "RuletblEQIW_L_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIW_L_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIW_L_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIW_L_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                }
            }
        }












    }
}
