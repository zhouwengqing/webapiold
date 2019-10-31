using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using DDYZ.Ensis.Presistence.DataEntity;
using System.Data.SqlClient;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuletblEQIA_PPI_Basedata : BaseRule
    {



        //类别
        private string eqiType = "eqia_p";
        private string TypeName = "降水监测";

        /// <summary> 
        /// 功能描述    ：  降水项目的均值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-09-05
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="TimeType">时间类别(年,月,日)</param>
        /// <param name="iSource">数据来源(手工:0 自动:1)</param>
        /// <param name="strBeginDate">开始时间</param>
        /// <param name="strEndDate">结束时间</param>
        /// <param name="strItemCode">监测因子代码</param>
        /// <param name="strSTCode">城市代码</param>
        /// <param name="sReportType">空间类别</param>
        /// <returns>DataTable </returns>
        public DataTable GetAcidRainAVGData(string TimeType, string strBeginDate, string strEndDate, string strSTCode, string strItemCode, string sReportType)
        {
            try
            {
                usp_tblEQIA_PPI_BaseData_GetItemAVGDataForGis uspAVGData = new usp_tblEQIA_PPI_BaseData_GetItemAVGDataForGis();
                uspAVGData.fldTimeType = TimeType;
                uspAVGData.BeginDate = strBeginDate;
                uspAVGData.EndDate = strEndDate;
                uspAVGData.fldSTCode = strSTCode;
                uspAVGData.fldItemCode = strItemCode;
                uspAVGData.ReportType = sReportType;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + TimeType + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode);
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + TimeType + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode);
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetItemAVGData", "type:" + TimeType + "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode);
            }
        }



        /// <summary> 
        /// 功能描述    ：  城市酸雨情况
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2013-09-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary> 
        /// <param name="iSource">数据来源(手工:0 自动:1)</param>
        /// <param name="strBeginDate">开始时间</param>
        /// <param name="strEndDate">结束时间</param>
        /// <param name="strItemCode">监测因子代码</param>
        /// <param name="strSTCode">城市代码</param> 
        /// <param name="pHStand">酸雨标准</param>
        /// <returns>DataTable </returns>
        public DataTable GetCityAcidRain(string strBeginDate, string strEndDate, string strSTCode, string strItemCode, decimal pHStand)
        {
            try
            {
                usp_tblEQIA_P_Report_CityAcidRain_Page uspAVGData = new usp_tblEQIA_P_Report_CityAcidRain_Page();
                uspAVGData.BeginDate = strBeginDate;
                uspAVGData.EndDate = strEndDate;
                uspAVGData.fldSTCode = strSTCode;
                uspAVGData.fldItemCode = strItemCode;
                uspAVGData.pHStand = pHStand;
                DataTable dt = uspAVGData.ExecDataTable();
                if (dt != null)
                    return dt;
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_RPI_Basedata", "GetCityAcidRain", "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode);
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_RPI_Basedata", "GetCityAcidRain", "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode);
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_RPI_Basedata", "GetCityAcidRain", "sBeginDate:" + strBeginDate + ",sEndDate:" + strEndDate +
                    ",strItemCode:" + strItemCode);
            }
        }




















        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIA_PPI_BaseData]表的记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-12-08
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIA_PPI_BaseData的实体数组</param>
        /// <param name="lstCurrentData">需要更新的本城市的实体类数组</param>
        /// <param name="lstJuniorData">需要更新的下级城市的实体类数组</param>
        /// <param name="lstAud">审核未通过原因的实体类数组</param>
        /// <param name="new_CityID_Operate">更新后的操作城市ID</param>
        /// <param name="new_CityID_Submit">更新后的提交城市ID</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAllOrUpdateNoPassAll(List<tblEQIA_PPI_BaseData> lstData, List<tblEQIA_PPI_BaseData_Pre> lstCurrentData, List<tblEQIA_PPI_BaseData_Pre> lstJuniorData, List<tblEQIA_PPI_Auditing> lstAud, List<tblFW_AuditingLog> lstAudLog, string new_CityID_Operate, string new_CityID_Submit, int grade, string comment, string operID2, string submit2, string flag2)
        {
            int iRowIndex = 0;
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                string dateAll = "", date = "";
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        //更新
                        for (iRowIndex = 0; iRowIndex < lstCurrentData.Count; iRowIndex++)
                        {
                            usp_tblEQIA_PPI_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIA_PPI_Basedata_Pre_UpdateCity();
                            uspUpdate.ReceiveParameter_Old(lstCurrentData[iRowIndex]);
                            uspUpdate.new_fldFlag = Int16.Parse(flag2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Operate = Int32.Parse(operID2.Split(',')[iRowIndex].ToString());
                            uspUpdate.new_fldCityID_Submit = submit2.Split(',')[iRowIndex];
                            uspUpdate.new_fldDate_Operate = lstCurrentData[iRowIndex].fldDate_Operate;
                            int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("修改记录失败，未找到对应的记录");

                            date = lstCurrentData[iRowIndex].fldSYear.ToString() + lstCurrentData[iRowIndex].fldSMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstCurrentData[iRowIndex].fldSYear;
                                usp_upin.fldMonth = lstCurrentData[iRowIndex].fldSMonth;
                                usp_upin.fldDay = lstCurrentData[iRowIndex].fldSDay;
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
                            if (lstData[iRowIndex].fldItemValue != -1)
                            {
                                //把数据录入到_RAW 表中
                                //usp_tblEQI_InsertByType usp_ins = new usp_tblEQI_InsertByType();
                                //usp_ins.autoid = lstData[iRowIndex].fldAutoID;
                                //usp_ins.type = eqiType;
                                //int iResultInsertByType = usp_ins.ExecNoQuery(conn, tran);
                                //if (iResultInsertByType <= 0)
                                //    throw new Exception("添加记录失败，未找到对应的记录");

                                //判断是否是删除数据， 把没有删除的数据录入到原始表里面去
                                usp_tblEQI_GetByType usp_get = new usp_tblEQI_GetByType();
                                usp_get.autoid = lstData[iRowIndex].fldAutoID;
                                usp_get.type = eqiType;
                                DataTable dt = usp_get.ExecDataTable();
                                if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0].ToString() == "0")
                                {
                                    usp_tblEQIA_PPI_BaseData_Insert uspInsert = new usp_tblEQIA_PPI_BaseData_Insert();
                                    uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                    int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                    if (iResultInsert <= 0)
                                        throw new Exception("添加记录失败，未找到对应的记录");
                                    //usp_tblEQIA_PPI_Basedata_select uspSelect = new usp_tblEQIA_PPI_Basedata_select();
                                    //uspSelect.ReceiveParameter(lstData[iRowIndex]);
                                    //int iResultSelect = uspSelect.ExecNoQuery2(conn,tran);
                                    //if(iResultSelect>=1)
                                    //{

                                    //}
                                    //else
                                    //{
                                    //    usp_tblEQIA_PPI_BaseData_Insert uspInsert = new usp_tblEQIA_PPI_BaseData_Insert();
                                    //    uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                    //    int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                    //    if (iResultInsert <= 0)
                                    //        throw new Exception("添加记录失败，未找到对应的记录");
                                    //}                                    
                                }
                            }
                            usp_tblEQIA_PPI_Basedata_Pre_Delete usp_pre_Delete = new usp_tblEQIA_PPI_Basedata_Pre_Delete();
                            usp_pre_Delete.fldAutoID = lstData[iRowIndex].fldAutoID;
                            int iResultdelete = usp_pre_Delete.ExecNoQuery(conn, tran);
                            if (iResultdelete <= 0)
                                throw new Exception("删除临时表记录失败，未找到对应的记录");

                            date = lstData[iRowIndex].fldSYear.ToString() + lstData[iRowIndex].fldSMonth.ToString();
                            if (dateAll.IndexOf(date) == -1)
                            {
                                usp_tblEQI_VerifyIdea_UpdateOrInsert usp_upin = new usp_tblEQI_VerifyIdea_UpdateOrInsert();
                                usp_upin.fldType = eqiType;
                                usp_upin.fldGrade = grade;
                                usp_upin.fldYear = lstData[iRowIndex].fldSYear;
                                usp_upin.fldMonth = lstData[iRowIndex].fldSMonth;
                                usp_upin.fldDay = lstData[iRowIndex].fldSDay;
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
                            usp_tblEQIA_PPI_Basedata_Pre_UpdateFlag uspUpdate = new usp_tblEQIA_PPI_Basedata_Pre_UpdateFlag();
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
                            usp_tblEQIA_PPI_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIA_PPI_Basedata_Pre_UpdateCity();
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
                            usp_tblEQIA_PPI_Auditing_Insert uspInsert = new usp_tblEQIA_PPI_Auditing_Insert();
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
                        throw new InsertException("打开数据库连接失败", "RuletblEQIA_PPI_Basedata", "InsertAllOrUpdateNoPassAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (lstData[iRowIndex].fldErrorRowIndex) + "，错误原因：同一测点同一时间同一项目的数据已经存在",
                            "RuletblEQIA_PPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIA_PPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIA_PPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIA_PPI_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                }
            }
        }


    }
}
