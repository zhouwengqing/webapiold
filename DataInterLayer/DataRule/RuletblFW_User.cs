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
    /// 功能描述    ：  对表[tblFW_User]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblFW_User : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  添加[tblFW_User]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-03-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public int Insert(tblFW_User objInsert)
        {
            try
            {
                usp_tblFW_User_Insert uspInsert = new usp_tblFW_User_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("插入新记录失败");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblFW_User", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("相同的记录已经存在，违反表的唯一键约束", "RuletblFW_User", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblFW_User", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblFW_User", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  删除[tblFW_User]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-03-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iPK">需要删除的记录的PK主键值</param>
        /// <returns>true / false</returns>
        public bool Delete(int iPK)
        {
            try
            {
                usp_tblFW_User_Delete uspDelete = new usp_tblFW_User_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("删除记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("打开数据库连接失败", "RuletblFW_User", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("执行Sql语句失败", "RuletblFW_User", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblFW_User", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  更新[tblFW_User]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objUpdate_old">需要更新的实体类</param>
        /// <param name="objUpdate_new">更新后的实体类</param>
        /// <returns>true / false</returns>
        public bool Update(tblFW_User objUpdate_old, tblFW_User objUpdate_new)
        {
            try
            {
                usp_tblFW_User_Update uspUpdate = new usp_tblFW_User_Update();
                uspUpdate.ReceiveParameter_Old(objUpdate_old);
                uspUpdate.ReceiveParameter_New(objUpdate_new);
                int iResult = uspUpdate.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("更新记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblFW_User", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblFW_User", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblFW_User", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  更新[tblFW_User]表的密码
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-08
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objUpdate">需要更新的实体类</param>
        /// <returns>true / false</returns>
        public bool UpdatePassword(tblFW_User objUpdate)
        {
            try
            {
                usp_tblFW_User_UpdatePassword uspUpdate = new usp_tblFW_User_UpdatePassword();
                uspUpdate.ReceiveParameter(objUpdate);
                int iResult = uspUpdate.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("更新记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblFW_User", "UpdatePassword", objUpdate.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblFW_User", "UpdatePassword", objUpdate.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblFW_User", "UpdatePassword", objUpdate.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  获得[tblFW_User]表的所有记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-03-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllData()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_User_ByAll uspByAll = new usp_tblFW_User_ByAll();
                tblData = uspByAll.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblFW_User";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblFW_User", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblFW_User", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblFW_User", "GetAllData", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获得[tblFW_User]表的所有记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-03-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>IList<tblFW_User></returns>
        public IList<tblFW_User> GetAllList()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_User_ByAll uspByAll = new usp_tblFW_User_ByAll();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblFW_User> listAll = new List<tblFW_User>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblFW_User objData = new tblFW_User();
                        objData.MetaDataTable = tblTmp;
                        listAll.Add(objData);
                    }
                    return listAll;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblFW_User", "GetAllList", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblFW_User", "GetAllList", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_User", "GetAllList", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  根据主键取得[tblFW_User]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-03-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iPK">PK主键值</param>
        /// <returns>tblFW_User</returns>
        public tblFW_User ByPK(int iPK)
        {
            try
            {
                usp_tblFW_User_ByPK uspByPK = new usp_tblFW_User_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblFW_User objData = new tblFW_User();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblFW_User", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblFW_User", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_User", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  根据用户名取得[tblFW_User]表的记录
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-03-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sUserName">用户名</param>
        /// <param name="stcode">城市代码</param>
        /// <returns>tblFW_User</returns>
        public tblFW_User ByUserName(string sUserName, string stcode)
        {
            try
            {
                usp_tblFW_User_ByUserName uspByUserName = new usp_tblFW_User_ByUserName();
                uspByUserName.fldUserName = sUserName;
                uspByUserName.fldSTCode = stcode;
                DataTable tblData = uspByUserName.ExecDataTable(1);
                if (tblData != null)
                {
                    tblFW_User objData = new tblFW_User();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblFW_User", "ByUserName", sUserName);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblFW_User", "ByUserName", sUserName);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_User", "ByUserName", sUserName);
            }
        }

        /// <summary>
        /// 功能描述    ：  根据用户名和关键字检查是否拥有操作权限
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-04-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iUserPK">用户PK</param>
        /// <param name="sKeyword">权限关键字</param>
        /// <returns>权限对应的页面级别ID,如果没有权限则为0</returns>
        public int CheckKeyword(int iUserPK, string sKeyword)
        {
            try
            {
                usp_tblFW_User_CheckRight uspCheckRight = new usp_tblFW_User_CheckRight();
                uspCheckRight.UserAutoID = iUserPK;
                uspCheckRight.RightKeyword = sKeyword;
                object objResult = uspCheckRight.ExecScalar();
                return Convert.ToInt32(objResult == null || objResult.ToString().Trim()=="" ? "0" : objResult);
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblFW_User", "CheckKeyword", "iUserPK：" + iUserPK + "；sKeyword：" + sKeyword);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblFW_User", "CheckKeyword", "iUserPK：" + iUserPK + "；sKeyword：" + sKeyword);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_User", "CheckKeyword", "iUserPK：" + iUserPK + "；sKeyword：" + sKeyword);
            }
        }

        /// <summary>
        /// 功能描述    ：  获得用户拥有的权限的fldAutoID
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-04-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iUserPK">用户PK</param>
        /// <returns>IList</returns>
        public IList<int> GetAllRightID(int iUserPK)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_User_AllRight uspAllRight = new usp_tblFW_User_AllRight();
                uspAllRight.UserAutoID = iUserPK;
                tblData = uspAllRight.ExecDataTable();
                if (tblData != null)
                {
                    IList<int> listAll = new List<int>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        listAll.Add(Convert.ToInt32(tblData.Rows[i]["fldRightSetID"].ToString()));
                    }
                    return listAll;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblFW_User", "GetAllRightID", "iUserPK：" + iUserPK);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblFW_User", "GetAllRightID", "iUserPK：" + iUserPK);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_User", "GetAllRightID", "iUserPK：" + iUserPK);
            }
        }

        /// <summary>
        /// 功能描述    ：  获得用户拥有的数据库表的fldAutoID
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-04-28
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iUserPK">用户PK</param>
        /// <returns>IList<int></returns>
        public IList<int> GetAllMaintenanceID(int iUserPK)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_User_AllMaintenance uspAllMaintenance = new usp_tblFW_User_AllMaintenance();
                uspAllMaintenance.UserAutoID = iUserPK;
                tblData = uspAllMaintenance.ExecDataTable();
                if (tblData != null)
                {
                    IList<int> listAll = new List<int>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        if (tblData.Rows[i]["fldMaintenanceID"].ToString() == "") continue;
                        listAll.Add(Convert.ToInt32(tblData.Rows[i]["fldMaintenanceID"].ToString()));
                    }
                    return listAll;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblFW_User", "GetAllMaintenanceID", "iUserPK：" + iUserPK);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblFW_User", "GetAllMaintenanceID", "iUserPK：" + iUserPK);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_User", "GetAllMaintenanceID", "iUserPK：" + iUserPK);
            }
        }

        /// <summary>
        /// 功能描述    ：  同时删除[tblFW_User]表的多条记录
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-04-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="arrPK">要删除的用户ID列表</param>
        /// <returns></returns>
        public bool DeleteMany(List<int> arrPK)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < arrPK.Count; i++)
                        {
                            usp_tblFW_User_Delete uspDelete = new usp_tblFW_User_Delete();
                            uspDelete.fldAutoID = arrPK[i];
                            int iResult = uspDelete.ExecNoQuery(conn, tran);
                            if (iResult <= 0)
                                throw new Exception("删除记录失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new DeleteException("打开数据库连接失败", "RuletblFW_User", "DeleteMany", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new DeleteException("执行Sql语句失败", "RuletblFW_User", "DeleteMany", "");
                    }
                    catch (DBException e)
                    {
                        throw new DeleteException("执行Sql语句失败", "RuletblFW_User", "DeleteMany", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new DeleteException(e.Message, "RuletblFW_User", "DeleteMany", "");
                    }
                }
            }
        }

        /// <summary>
        /// 功能描述    ：  将选中的用户的启用状态改为否
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-04-14
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="arrPK">要停用的用户ID列表</param>
        /// <returns></returns>
        public bool StopMany(List<int> arrPK)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < arrPK.Count; i++)
                        {
                            usp_tblFW_User_UpdateActive uspUpdate = new usp_tblFW_User_UpdateActive();
                            uspUpdate.fldAutoID = arrPK[i];
                            int iResult = uspUpdate.ExecNoQuery(conn, tran);
                            if (iResult <= 0)
                                throw new Exception("停用记录失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new UpdateException("打开数据库连接失败", "RuletblFW_User", "StopMany", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new UpdateException("执行Sql语句失败", "RuletblFW_User", "StopMany", "");
                    }
                    catch (DBException e)
                    {
                        throw new UpdateException("执行Sql语句失败", "RuletblFW_User", "StopMany", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new UpdateException(e.Message, "RuletblFW_User", "StopMany", "");
                    }
                }
            }
        }
    }
}
