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
    public class RuletblEQIW_D_Basedata
    {

        //类别
        private string eqiType = "eqiw_d";
        private string TypeName = "饮用水监测";



        /// <summary>
        /// 功能描述    ：  批量添加[tblEQIW_D_Basedata]表的记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-12-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="lstData">要添加的tblEQIW_D_Basedata的实体数组</param>
        /// <param name="lstCurrentData">需要更新的本城市的实体类数组</param>
        /// <param name="lstJuniorData">需要更新的下级城市的实体类数组</param>
        /// <param name="lstAud">审核未通过原因的实体类数组</param>
        /// <param name="new_CityID_Operate">更新后的操作城市ID</param>
        /// <param name="new_CityID_Submit">更新后的提交城市ID</param>
        /// <returns>操作是否成功</returns>
        public bool InsertAllOrUpdateNoPassAll(List<tblEQIW_D_Basedata> lstData, List<tblEQIW_D_Basedata_Pre> lstCurrentData, List<tblEQIW_D_Basedata_Pre> lstJuniorData, List<tblEQIW_D_Auditing> lstAud, List<tblFW_AuditingLog> lstAudLog, string new_CityID_Operate, string new_CityID_Submit, int grade, string comment, string operID2, string submit2, string flag2)
        {
            int iRowIndex = 0;
            string isading = "";
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
                            usp_tblEQIW_D_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIW_D_Basedata_Pre_UpdateCity();
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
                                usp_tblEQIW_D_Basedata_Insert uspInsert = new usp_tblEQIW_D_Basedata_Insert();
                                uspInsert.ReceiveParameter(lstData[iRowIndex]);
                                int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("添加记录失败，未找到对应的记录");
                            }
                            //}
                            usp_tblEQIW_D_Basedata_Pre_Delete usp_pre_Delete = new usp_tblEQIW_D_Basedata_Pre_Delete();
                            usp_pre_Delete.fldAutoID = lstData[iRowIndex].fldAutoID;
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
                            usp_tblEQIW_D_Basedata_Pre_UpdateFlag uspUpdate = new usp_tblEQIW_D_Basedata_Pre_UpdateFlag();
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
                            int isb = this.selectWY(lstJuniorData[iRowIndex].fldSTCode, lstJuniorData[iRowIndex].fldRCode, lstJuniorData[iRowIndex].fldRSCode, lstJuniorData[iRowIndex].fldYear);
                            //如果是河流
                            if (isb == 0)
                            {
                                #region 给实体类赋值
                                tblEQIW_R_Basedata_Pre tblr = new tblEQIW_R_Basedata_Pre();
                                tblr.fldSTCode = lstJuniorData[iRowIndex].fldSTCode;
                                tblr.fldRCode = lstJuniorData[iRowIndex].fldRCode;
                                tblr.fldRSCode = lstJuniorData[iRowIndex].fldRSCode;
                                tblr.fldYear = lstJuniorData[iRowIndex].fldYear;
                                tblr.fldMonth = lstJuniorData[iRowIndex].fldMonth;
                                tblr.fldDay = lstJuniorData[iRowIndex].fldDay;
                                tblr.fldHour = lstJuniorData[iRowIndex].fldHour;
                                tblr.fldMinute = lstJuniorData[iRowIndex].fldMinute;
                                tblr.fldSAMPH = lstJuniorData[iRowIndex].fldSAMPH;
                                tblr.fldSAMPR = lstJuniorData[iRowIndex].fldSAMPR;
                                tblr.fldRSC = lstJuniorData[iRowIndex].fldRSC;
                                tblr.fldItemCode = lstJuniorData[iRowIndex].fldItemCode;
                                tblr.fldItemValue = lstJuniorData[iRowIndex].fldItemValue;
                                tblr.fldBatch = lstJuniorData[iRowIndex].fldBatch;
                                tblr.fldImport = lstJuniorData[iRowIndex].fldImport;
                                tblr.fldSource = lstJuniorData[iRowIndex].fldSource;
                                tblr.fldUserID = lstJuniorData[iRowIndex].fldUserID;
                                #endregion
                                tblr.fldFlag = -2;
                                tblr.fldDate_Operate = DateTime.Now;
                                tblr.fldCityID_Operate = Convert.ToInt32(new_CityID_Operate.Split(',')[iRowIndex]);
                                tblr.fldCityID_Submit = new_CityID_Submit.Split(',')[iRowIndex];

                                //新增河流的记录
                                usp_tblEQIW_R_Basedata_Pre_InsertD uspInsert = new usp_tblEQIW_R_Basedata_Pre_InsertD();
                                uspInsert.ReceiveParameter(tblr);
                                for (int i = 0; i < lstAud.Count; i++)
                                {
                                    if (lstAud[i].fldBaseDataID == lstJuniorData[iRowIndex].fldAutoID)
                                    {
                                        uspInsert.fldComment = lstAud[i].fldComment;
                                        isading += lstAud[i].fldBaseDataID + ",";
                                        break;
                                    }
                                }
                                int iResultInsertD = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsertD <= 0)
                                    throw new Exception("新增河流失败！");
                                //删除饮用水里面饮用水的记录
                                usp_tblEQIW_D_Basedata_Pre_Delete deleteR = new usp_tblEQIW_D_Basedata_Pre_Delete();
                                deleteR.fldAutoID = Convert.ToInt32(lstJuniorData[iRowIndex].fldAutoID);
                                int isr = deleteR.ExecNoQuery(conn, tran);
                                if (isr <= 0)
                                    throw new Exception("删除记录失败");

                            }
                            //如果是湖库
                            else if (isb == 1)
                            {
                                #region 给实体类赋值
                                tblEQIW_L_Basedata_Pre tbll = new tblEQIW_L_Basedata_Pre();
                                tbll.fldSTCode = lstJuniorData[iRowIndex].fldSTCode;
                                tbll.fldRCode = lstJuniorData[iRowIndex].fldRCode;
                                tbll.fldRSCode = lstJuniorData[iRowIndex].fldRSCode;
                                tbll.fldYear = lstJuniorData[iRowIndex].fldYear;
                                tbll.fldMonth = lstJuniorData[iRowIndex].fldMonth;
                                tbll.fldDay = lstJuniorData[iRowIndex].fldDay;
                                tbll.fldHour = lstJuniorData[iRowIndex].fldHour;
                                tbll.fldMinute = lstJuniorData[iRowIndex].fldMinute;
                                tbll.fldSAMPH = lstJuniorData[iRowIndex].fldSAMPH;
                                tbll.fldSAMPR = lstJuniorData[iRowIndex].fldSAMPR;
                                tbll.fldRSC = lstJuniorData[iRowIndex].fldRSC;
                                tbll.fldItemCode = lstJuniorData[iRowIndex].fldItemCode;
                                tbll.fldItemValue = lstJuniorData[iRowIndex].fldItemValue;
                                tbll.fldBatch = lstJuniorData[iRowIndex].fldBatch;

                                //tbll.fldImport = lstJuniorData[iRowIndex].fldImport;

                                tbll.fldSource = lstJuniorData[iRowIndex].fldSource;
                                tbll.fldUserID = lstJuniorData[iRowIndex].fldUserID;
                                #endregion
                                tbll.fldFlag = -2;
                                tbll.fldDate_Operate = DateTime.Now;
                                tbll.fldCityID_Operate = Convert.ToInt32(new_CityID_Operate.Split(',')[iRowIndex]);
                                tbll.fldCityID_Submit = new_CityID_Submit.Split(',')[iRowIndex];

                                //新增湖库的记录
                                usp_tblEQIW_L_Basedata_Pre_InsertD uspInsert = new usp_tblEQIW_L_Basedata_Pre_InsertD();
                                uspInsert.ReceiveParameter(tbll);
                                for (int i = 0; i < lstAud.Count; i++)
                                {
                                    if (lstAud[i].fldBaseDataID == lstJuniorData[iRowIndex].fldAutoID)
                                    {
                                        uspInsert.fldComment = lstAud[i].fldComment;
                                        isading += lstAud[i].fldBaseDataID + ",";
                                        break;
                                    }
                                }
                                int iResultInsertD = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsertD <= 0)
                                    throw new Exception("新增湖库失败！");

                                //删除饮用水里面饮用水的记录
                                usp_tblEQIW_D_Basedata_Pre_Delete deleteR = new usp_tblEQIW_D_Basedata_Pre_Delete();
                                deleteR.fldAutoID = Convert.ToInt32(lstJuniorData[iRowIndex].fldAutoID);
                                int isr = deleteR.ExecNoQuery(conn, tran);
                                if (isr <= 0)
                                    throw new Exception("删除记录失败");
                            }
                            else
                            {
                                usp_tblEQIW_D_Basedata_Pre_UpdateCity uspUpdate = new usp_tblEQIW_D_Basedata_Pre_UpdateCity();
                                uspUpdate.ReceiveParameter_Old(lstJuniorData[iRowIndex]);
                                uspUpdate.new_fldCityID_Operate = Convert.ToInt32(new_CityID_Operate.Split(',')[iRowIndex]);
                                uspUpdate.new_fldCityID_Submit = new_CityID_Submit.Split(',')[iRowIndex];
                                uspUpdate.new_fldFlag = -2;
                                uspUpdate.new_fldDate_Operate = DateTime.Now;
                                int iResultInsert = uspUpdate.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("修改记录失败，未找到对应的记录");
                            }
                        }
                        //审核未通过原因写入数据表
                        for (iRowIndex = 0; iRowIndex < lstAud.Count; iRowIndex++)
                        {
                            if (isading.IndexOf(lstAud[iRowIndex].fldBaseDataID.ToString()) == -1)
                            {
                                usp_tblEQIW_D_Auditing_Insert uspInsert = new usp_tblEQIW_D_Auditing_Insert();
                                uspInsert.ReceiveParameter(lstAud[iRowIndex]);
                                int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                                if (iResultInsert <= 0)
                                    throw new Exception("添加审核未通过原因失败，未找到对应的记录");
                            }
                        }
                        //审批操作记录保存到审核日志
                        for (iRowIndex = 0; iRowIndex < lstAudLog.Count; iRowIndex++)
                        {
                            usp_tblFW_AuditingLog_Insert uspInsert = new usp_tblFW_AuditingLog_Insert();
                            uspInsert.ReceiveParameter(lstAudLog[iRowIndex]);
                            int iResultInsert = uspInsert.ExecNoQuery(conn, tran);
                            if (iResultInsert <= 0)
                                throw new Exception("添加审核日志未通过原因失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new InsertException("打开数据库连接失败", "RuletblEQIW_D_Basedata", "InsertAllOrUpdateNoPassAll", "");
                    }
                    catch (DBPKException e)
                    {
                        throw new InputException(iRowIndex, "错误发生行号：" + (lstData[iRowIndex].fldErrorRowIndex) + "，错误原因：同一测点同一时间同一项目的数据已经存在",
                            "RuletblEQIW_D_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBQueryException e)
                    {
                        throw new InsertException("执行Sql语句失败", "RuletblEQIW_D_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (DBException e)
                    {
                        throw new InsertException("写入数据库失败", "RuletblEQIW_D_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new InsertException(e.Message, "RuletblEQIW_D_Basedata", "InsertAllOrUpdateNoPassAll", "new_CityID_Operate：" + new_CityID_Operate.ToString() + ",new_CityID_Submit：" + new_CityID_Submit);
                    }
                }
            }
        }












        /// <summary>
        /// 功能描述    ：  查询断面类型
        /// 创建者      ：  黄成
        /// 创建日期    ：   2011-11-02
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stcode">城市代码</param>
        /// <param name="rcode">河流代码</param>
        /// <param name="rscode">断面代码</param>
        /// <param name="year">年度</param>
        /// <returns>bool</returns>
        public int selectWY(string stcode, string rcode, string rscode, decimal year)
        {
            try
            {
                usp_tblEQIW_D_Section_GetStype usp_wy = new usp_tblEQIW_D_Section_GetStype();
                usp_wy.fldSTCode = stcode;
                usp_wy.fldRCode = rcode;
                usp_wy.fldRSCode = rscode;
                usp_wy.fldYear = year;
                DataTable dt = usp_wy.ExecDataTable();
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["fldSCategory"]);
                }
                else
                    throw new Exception("查询失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_D_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_D_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_D_Section", "GetRSCodeByRCode",
                    "stcode:" + stcode + "；rcode:" + rcode);
            }
        }

    }
}
