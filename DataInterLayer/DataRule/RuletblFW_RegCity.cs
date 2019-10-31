using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Lib.account;
using DDYZ.Ensis.Library.Lib.str;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 功能描述    ：  对表[tblFW_RegCity]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblFW_RegCity : BaseRule
    {
        ///// <summary>
        ///// 功能描述    ：  添加注册城市并生成【系统管理员】角色和admin用户，并将admin赋予【系统管理员】角色
        ///// 创建者      ：  马立军
        ///// 创建日期    ：  2009-04-14
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="objInsert">要生成的注册城市实体</param>
        ///// <param name="sPassword">生成成功后的admin的密码</param>
        ///// <returns></returns>
        //public bool Insert(tblFW_RegCity objInsert, out string sPassword)
        //{
        //    using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString_LAP))
        //    {
        //        conn.Open();
        //        using (SqlTransaction tran = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                //生成注册城市
        //                usp_tblFW_RegCity_Insert uspInsert = new usp_tblFW_RegCity_Insert();
        //                uspInsert.ReceiveParameter(objInsert);
        //                uspInsert.ExecNoQuery(conn, tran);
        //                int iCityID = uspInsert.fldAutoID;
        //                if (iCityID < 1)
        //                    throw new InsertException("生成注册城市失败", "RuletblFW_RegCity", "Insert", "");
        //                //生成[系统管理员]角色
        //                tblFW_Role objRole = new tblFW_Role();
        //                objRole.fldName = "系统管理员";
        //                objRole.fldRoleDesc = "系统管理员";
        //                objRole.fldCityID = iCityID;
        //                usp_tblFW_Role_Insert uspRole = new usp_tblFW_Role_Insert();
        //                uspRole.ReceiveParameter(objRole);
        //                uspRole.ExecNoQuery(conn, tran);
        //                int iRoleID = uspRole.fldAutoID;
        //                if (iRoleID < 1)
        //                    throw new InsertException("生成[系统管理员]角色失败", "RuletblFW_RegCity", "Insert", "");
        //                //赋予[系统管理员]<=5的所有权限
        //                usp_tblFW_Role_RightSet_ResetAdmin uspRightReset = new usp_tblFW_Role_RightSet_ResetAdmin();
        //                uspRightReset.fldRoleID = iRoleID;
        //                uspRightReset.ExecNoQuery(conn, tran);
        //                //赋予[系统管理员]<=5的所有数据库表
        //                usp_tblFW_Role_Maintenance_ResetAdmin uspMaintReset = new usp_tblFW_Role_Maintenance_ResetAdmin();
        //                uspMaintReset.fldRoleID = iRoleID;
        //                uspMaintReset.ExecNoQuery(conn, tran);
        //                //生成admin用户
        //                sPassword = StringTools.GenerateRandomChar(8);
        //                tblFW_User objUser = new tblFW_User();
        //                objUser.fldUserName = "admin";
        //                objUser.fldPassword = PasswordTools.Md5(sPassword);
        //                objUser.fldUserDesc = "系统管理员";
        //                objUser.fldCityID = iCityID;
        //                objUser.fldActive = true;
        //                usp_tblFW_User_Insert uspUser = new usp_tblFW_User_Insert();
        //                uspUser.ReceiveParameter(objUser);
        //                uspUser.ExecNoQuery(conn, tran);
        //                int iUserID = uspUser.fldAutoID;
        //                if (iUserID < 1)
        //                    throw new InsertException("生成[admin]角色失败", "RuletblFW_RegCity", "Insert", "");
        //                //admin和[系统管理员]角色关联起来
        //                tblFW_User_Role objUserRole = new tblFW_User_Role();
        //                objUserRole.fldUserID = iUserID;
        //                objUserRole.fldRoleID = iRoleID;
        //                usp_tblFW_User_Role_Insert uspUserRole = new usp_tblFW_User_Role_Insert();
        //                uspUserRole.ReceiveParameter(objUserRole);
        //                uspUserRole.ExecNoQuery(conn, tran);
        //                int iUserRole = uspUserRole.fldAutoID;
        //                if (iUserRole < 1)
        //                    throw new InsertException("关联[admin]和[系统管理员]失败", "RuletblFW_RegCity", "Insert", "");
        //                tran.Commit();
        //                return true;
        //            }
        //            catch (DBOpenException e)
        //            {
        //                throw new InsertException("打开数据库连接失败", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (DBPKException e)
        //            {
        //                throw new InsertPKException("相同的记录已经存在，违反表的唯一键约束", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (DBQueryException e)
        //            {
        //                throw new InsertException("写入数据库失败", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (DBException e)
        //            {
        //                throw new InsertException("写入数据库失败", "RuletblFW_RegCity", "Insert", "");
        //            }
        //            catch (InsertException e)
        //            {
        //                tran.Rollback();
        //                throw e;
        //            }
        //            catch (Exception e)
        //            {
        //                tran.Rollback();
        //                throw new DataRuleException(e.Message, "RuletblFW_RegCity", "Insert", "");
        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 功能描述    ：  获得[tblFW_RegCity]表的所有记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-09
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
                usp_tblFW_RegCity_ByAll uspByAll = new usp_tblFW_RegCity_ByAll();
                tblData = uspByAll.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblFW_RegCity";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblFW_RegCity", "GetAllData", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblFW_RegCity", "GetAllData", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetAllData", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  获得[tblFW_RegCity]表的所有记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>IList<tblFW_RegCity></returns>
        public IList<tblFW_RegCity> GetAllList()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblFW_RegCity_ByAll uspByAll = new usp_tblFW_RegCity_ByAll();
                tblData = uspByAll.ExecDataTable(1);
                if (tblData != null)
                {
                    IList<tblFW_RegCity> listAll = new List<tblFW_RegCity>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblFW_RegCity objData = new tblFW_RegCity();
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
                throw new GetListException("打开数据库连接失败", "RuletblFW_RegCity", "GetAllList", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblFW_RegCity", "GetAllList", "");
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblFW_RegCity", "GetAllList", "");
            }
        }

        /// <summary>
        /// 功能描述    ：  根据主键取得[tblFW_RegCity]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-09
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iPK">PK主键值</param>
        /// <returns>tblFW_RegCity</returns>
        public tblFW_RegCity ByPK(int iPK)
        {
            try
            {
                usp_tblFW_RegCity_ByPK uspByPK = new usp_tblFW_RegCity_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable(1);
                if (tblData != null)
                {
                    tblFW_RegCity objData = new tblFW_RegCity();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblFW_RegCity", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblFW_RegCity", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_RegCity", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  根据城市代码取得[tblFW_RegCity]表的记录
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-04-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sSTCode">城市代码</param>
        /// <returns>tblFW_RegCity</returns>
        public tblFW_RegCity ByCode(string sSTCode)
        {
            try
            {
                usp_tblFW_RegCity_ByCode uspByCode = new usp_tblFW_RegCity_ByCode();
                uspByCode.fldSTCode = sSTCode;
                DataTable tblData = uspByCode.ExecDataTable(1);
                if (tblData != null)
                {
                    tblFW_RegCity objData = new tblFW_RegCity();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblFW_RegCity", "ByCode", sSTCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblFW_RegCity", "ByCode", sSTCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_RegCity", "ByCode", sSTCode);
            }
        }


        /// <summary>
        /// 功能描述    ：  根据城市代码取得[tblFW_RegCity]表的记录
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2010-08-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sSTCode">城市代码</param>
        /// <returns>tblFW_RegCity</returns>
        public IList<tblFW_RegCity> ByAllCode(string sSTCode)
        {
            try
            {
                usp_tblFW_RegCity_ByAllCode uspByCode = new usp_tblFW_RegCity_ByAllCode();
                uspByCode.fldSTCode = sSTCode;
                DataTable tblData = uspByCode.ExecDataTable(1);
                 if (tblData != null)
                {
                    IList<tblFW_RegCity> listAll = new List<tblFW_RegCity>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblFW_RegCity objData = new tblFW_RegCity();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblFW_RegCity", "ByAllCode", sSTCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblFW_RegCity", "ByAllCode", sSTCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblFW_RegCity", "ByAllCode", sSTCode);
            }
        }

        ///// <summary>
        ///// 功能描述    ：  根据角色ID和业务模块获取城市信息
        ///// 创建者      ：  张晓龙
        ///// 创建日期    ：  2012-02-07
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="roleID">角色ID</param>
        ///// <param name="moudle">业务模块</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetCityByRoleID(int roleID, int moudle)
        //{
        //    try
        //    {
        //        DataTable tblData = new DataTable();
        //        usp_GetCityByRoleID uspGetCity = new usp_GetCityByRoleID();
        //        uspGetCity.fldRoleID = roleID;
        //        uspGetCity.fldMoudle = moudle;
        //        tblData = uspGetCity.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("取得记录失败，未找到对应的记录");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("打开数据库连接失败", "RuletblFW_RegCity", "GetCityByRoleID", "roleID：" + roleID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("执行Sql语句失败", "RuletblFW_RegCity", "GetCityByRoleID", "roleID：" + roleID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetCityByRoleID", "roleID：" + roleID);
        //    }
        //}

        ///// <summary>
        ///// 功能描述    ：  获得[tblFW_RegCity]表的自己和下级城市的记录
        ///// 创建者      ：  马立军
        ///// 创建日期    ：  2009-04-13
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetSelfAndChildren(int iAutoID)
        //{
        //    try
        //    {
        //        DataTable tblData = new DataTable();
        //        usp_tblFW_RegCity_SelfAndChild uspByAll = new usp_tblFW_RegCity_SelfAndChild();
        //        uspByAll.fldAutoID = iAutoID;
        //        tblData = uspByAll.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("取得记录失败，未找到对应的记录");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("打开数据库连接失败", "RuletblFW_RegCity", "GetSelfAndChildren", "iAutoID：" + iAutoID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("执行Sql语句失败", "RuletblFW_RegCity", "GetSelfAndChildren", "iAutoID：" + iAutoID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetSelfAndChildren", "iAutoID：" + iAutoID);
        //    }
        //}

        ///// <summary>
        ///// 功能描述    ：  根据角色获得[tblFW_RegCity]表的记录
        ///// 创建者      ：  张浩
        ///// 创建日期    ：  2011-12-27
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetSelfAndChildrenByRoleID(int iAutoID,int roleID,int moudle)
        //{
        //    try
        //    {
        //        DataTable tblData = new DataTable();
        //        usp_tblFW_RegCity_SelfAndChildByRole uspByAll = new usp_tblFW_RegCity_SelfAndChildByRole();
        //        uspByAll.fldAutoID = iAutoID;
        //        uspByAll.Roleid = roleID;
        //        uspByAll.Moudle = moudle;
        //        tblData = uspByAll.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("取得记录失败，未找到对应的记录");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("打开数据库连接失败", "RuletblFW_RegCity", "GetSelfAndChildrenByRoleID", "iAutoID：" + iAutoID.ToString() + ",roleID：" + roleID.ToString() + ",moudle：" + moudle.ToString());
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("执行Sql语句失败", "RuletblFW_RegCity", "GetSelfAndChildrenByRoleID", "iAutoID：" + iAutoID.ToString() + ",roleID：" + roleID.ToString() + ",moudle：" + moudle.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetSelfAndChildrenByRoleID", "iAutoID："+iAutoID.ToString() + ",roleID：" + roleID.ToString() + ",moudle：" + moudle.ToString());
        //    }
        //}

        ///// <summary>
        ///// 功能描述    ：  更新[tblFW_RegCity]表的记录
        ///// 创建者      ：  Auto Generator
        ///// 创建日期    ：  2009-05-05
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="objUpdate_old">需要更新的实体类</param>
        ///// <param name="objUpdate_new">更新后的实体类</param>
        ///// <returns>true / false</returns>
        //public bool Update(tblFW_RegCity objUpdate_old, tblFW_RegCity objUpdate_new)
        //{
        //    try
        //    {
        //        usp_tblFW_RegCity_Update uspUpdate = new usp_tblFW_RegCity_Update();
        //        uspUpdate.ReceiveParameter_Old(objUpdate_old);
        //        uspUpdate.ReceiveParameter_New(objUpdate_new);
        //        int iResult = uspUpdate.ExecNoQuery(1);
        //        if (iResult > 0)
        //            return true;
        //        else
        //            throw new Exception("更新记录失败，未找到对应的记录");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new UpdateException("打开数据库连接失败", "RuletblFW_RegCity", "Update",
        //            "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new UpdateException("执行Sql语句失败", "RuletblFW_RegCity", "Update",
        //            "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
        //    }
        //    catch (Exception e)
        //    {
        //        throw new UpdateException(e.Message, "RuletblFW_RegCity", "Update",
        //            "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
        //    }
        //}

        ///// <summary>
        ///// 功能描述    ：  获得[tblFW_RegCity]表的上级城市的记录（不包含自己）
        ///// 创建者      ：  马立军
        ///// 创建日期    ：  2009-05-05
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>DataTable</returns>
        //public DataTable GetParent(int iAutoID)
        //{
        //    try
        //    {
        //        usp_tblFW_RegCity_Parent uspParent = new usp_tblFW_RegCity_Parent();
        //        uspParent.fldAutoID = iAutoID;
        //        DataTable tblData = uspParent.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblData.TableName = "tblFW_RegCity";
        //            return tblData;
        //        }
        //        else
        //            throw new Exception("取得记录失败，未找到对应的记录");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("打开数据库连接失败", "RuletblFW_RegCity", "GetParent", "iAutoID：" + iAutoID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("执行Sql语句失败", "RuletblFW_RegCity", "GetParent", "iAutoID：" + iAutoID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetParent", "iAutoID：" + iAutoID);
        //    }
        //}

        ///// <summary>
        ///// 功能描述    ：  获得[tblFW_RegCity]表的上级城市的ID
        ///// 创建者      ：  马立军
        ///// 创建日期    ：  2009-06-15
        ///// 修改者      ：
        ///// 修改日期    ：
        ///// 修改原因    ：
        ///// </summary>
        ///// <param name="iAutoID">PK</param>
        ///// <returns>父城市ID</returns>
        //public int GetParentCityID(int iAutoID)
        //{
        //    try
        //    {
        //        usp_tblFW_RegCity_ByPK uspByPK = new usp_tblFW_RegCity_ByPK();
        //        uspByPK.fldAutoID = iAutoID;
        //        DataTable tblData = uspByPK.ExecDataTable(1);
        //        if (tblData != null)
        //        {
        //            tblFW_RegCity objData = new tblFW_RegCity();
        //            objData.MetaDataTable = tblData;
        //            return objData.fldParentID;
        //        }
        //        else
        //            throw new Exception("取得单条记录失败，未找到对应的记录");
        //    }
        //    catch (DBOpenException e)
        //    {
        //        throw new GetAllException("打开数据库连接失败", "RuletblFW_RegCity", "GetParentCityID", "iAutoID：" + iAutoID);
        //    }
        //    catch (DBQueryException e)
        //    {
        //        throw new GetAllException("执行Sql语句失败", "RuletblFW_RegCity", "GetParentCityID", "iAutoID：" + iAutoID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new GetAllException(e.Message, "RuletblFW_RegCity", "GetParentCityID", "iAutoID：" + iAutoID);
        //    }
        //}
    }
}
