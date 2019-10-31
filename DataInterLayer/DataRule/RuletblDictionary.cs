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
    /// 功能描述    ：  对表[tblDictionary]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblDictionary : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  添加[tblDictionary]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public int Insert(tblDictionary objInsert)
        {
            try
            {
                usp_tblDictionary_Insert uspInsert = new usp_tblDictionary_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery(1);
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("插入新记录失败");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblDictionary", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("相同的记录已经存在，违反表的唯一键约束", "RuletblDictionary", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblDictionary", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblDictionary", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  删除[tblDictionary]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-29
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
                usp_tblDictionary_Delete uspDelete = new usp_tblDictionary_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery(1);
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("删除记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("打开数据库连接失败", "RuletblDictionary", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("执行Sql语句失败", "RuletblDictionary", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblDictionary", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  更新[tblDictionary]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objUpdate_old">需要更新的实体类</param>
        /// <param name="objUpdate_new">更新后的实体类</param>
        /// <returns>true / false</returns>
        public bool Update(tblDictionary objUpdate_old, tblDictionary objUpdate_new)
        {
            try
            {
                usp_tblDictionary_Update uspUpdate = new usp_tblDictionary_Update();
                uspUpdate.ReceiveParameter_Old(objUpdate_old);
                uspUpdate.ReceiveParameter_New(objUpdate_new);
                int iResult = uspUpdate.ExecNoQuery(1);
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("更新记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new UpdateException("打开数据库连接失败", "RuletblDictionary", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (DBPKException e)
            {
                throw new UpdatePKException("相同的记录已经存在，违反表的唯一键约束", "RuletblFW_Dept", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblDictionary", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblDictionary", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  根据主键取得[tblDictionary]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-04-29
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iPK">PK主键值</param>
        /// <returns>tblDictionary</returns>
        public tblDictionary ByPK(int iPK)
        {
            try
            {
                usp_tblDictionary_ByPK uspByPK = new usp_tblDictionary_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable(1);
                if (tblData != null)
                {
                    tblDictionary objData = new tblDictionary();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblDictionary", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblDictionary", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  同时删除[tblDictionary]表的多条记录
        /// 创建者      ：  张春
        /// 创建日期    ：  2009-04-30
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="arrPK">要删除的主键ID列表</param>
        /// <returns></returns>
        public bool DeleteMany(List<int> arrPK)
        {
            using (SqlConnection conn = new SqlConnection(DataAccessConfig.ConnString_LAP))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < arrPK.Count; i++)
                        {
                            usp_tblDictionary_Delete_ParentID dicPDelete = new usp_tblDictionary_Delete_ParentID();
                            dicPDelete.fldParentID = arrPK[i];
                            dicPDelete.ExecNoQuery(conn, tran);
                            usp_tblDictionary_Delete dicDelete = new usp_tblDictionary_Delete();
                            dicDelete.fldAutoID = arrPK[i];
                            int iResult = dicDelete.ExecNoQuery(conn, tran);
                            if (iResult <= 0)
                                throw new Exception("删除记录失败，未找到对应的记录");
                        }
                        tran.Commit();
                        return true;
                    }
                    catch (DBOpenException e)
                    {
                        throw new DeleteException("打开数据库连接失败", "RuletblDictionary", "DeleteMany", "");
                    }
                    catch (DBQueryException e)
                    {
                        throw new DeleteException("执行Sql语句失败", "RuletblDictionary", "DeleteMany", "");
                    }
                    catch (DBException e)
                    {
                        throw new DeleteException("写入数据库失败", "RuletblDictionary", "DeleteMany", "");
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        throw new DeleteException(e.Message, "RuletblDictionary", "DeleteMany", "");
                    }
                }
            }
        }

        /// <summary>
        /// 功能描述    ：  查找父字典下的所有子项目字典
        /// 创建者      ：  张春
        /// 创建日期    ：  2009-05-04
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="pid">要查找的父字典</param>
        /// <returns></returns>
        public DataTable ByParentID(int pid)
        {
            try
            {
                usp_tblDictionary_Select_ByParentID selectByParentID = new usp_tblDictionary_Select_ByParentID();
                selectByParentID.fldAutoID = pid;
                DataTable tblData = selectByParentID.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblDictionary";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblDictionary", "ByParentID", pid.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblDictionary", "ByParentID", pid.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentID", pid.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  查找父字典下的所有子项目字典
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-12
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sParentName">要查找的父字典名称</param>
        /// <returns></returns>
        public DataTable ByParentName(string sParentName)
        {
            try
            {
                usp_tblDictionary_Select_ByParentName selectByParentName = new usp_tblDictionary_Select_ByParentName();
                selectByParentName.fldName = sParentName;
                DataTable tblData = selectByParentName.ExecDataTable(1);
                if (tblData != null)
                {
                    tblData.TableName = "tblDictionary";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblDictionary", "ByParentName", sParentName);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblDictionary", "ByParentName", sParentName);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentName", sParentName);
            }
        }

        /// <summary>
        /// 功能描述    ：  查找某个父字典中是否存在某个子字典名称
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-11
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="fldpid">父字典ID</param>
        /// <param name="fldname">子字典名称</param>
        /// <returns></returns>
        public bool CheckDBHave(int fldpid, string fldname)
        {
            try
            {
                usp_tblDictionary_Select_ByNameAndParentID selectByNameAndParentID = new usp_tblDictionary_Select_ByNameAndParentID();
                selectByNameAndParentID.fldParentID = fldpid;
                selectByNameAndParentID.fldName = fldname;
                int icount = int.Parse(selectByNameAndParentID.ExecScalar(1).ToString());
                if (icount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblDictionary", "CheckDBHave", 
                        "fldpid：" + fldpid.ToString() + "；fldname：" + fldname);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblDictionary", "CheckDBHave", 
                        "fldpid：" + fldpid.ToString() + "；fldname：" + fldname);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "CheckDBHave", 
                        "fldpid：" + fldpid.ToString() + "；fldname：" + fldname);
            }
        }

        /// <summary>
        /// 功能描述    ：  根据父字典ID和字典值取得字典名称
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-05-11
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sParentName">父字典的名称</param>
        /// <param name="sValue">字典值</param>
        /// <returns>tblDictionary</returns>
        public string ByParentIDAndValue(string sParentName, string sValue)
        {
            try
            {
                usp_tblDictionary_GetNameByParentIDAndValue uspGetName = new usp_tblDictionary_GetNameByParentIDAndValue();
                uspGetName.fldParentName = sParentName;
                uspGetName.fldKey = sValue;
                object objResult = uspGetName.ExecScalar(1);
                return objResult == null ? "" : objResult.ToString().Trim();
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName：" + sParentName+ "；sValue：" + sValue);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName：" + sParentName + "；sValue：" + sValue);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName：" + sParentName+ "；sValue：" + sValue);
            }
        }

        /// <summary>
        /// 功能描述    ：  根据父字典ID和字典名称取得字典值
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-12-23
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sParentName">父字典的名称</param>
        /// <param name="sName">字典名称</param>
        /// <returns>tblDictionary</returns>
        public string ByParentIDAndName(string sParentName, string sName)
        {
            try
            {
                usp_tblDictionary_GetValueByParentIDAndName uspGetName = new usp_tblDictionary_GetValueByParentIDAndName();
                uspGetName.fldParentName = sParentName;
                uspGetName.fldName = sName;
                object objResult = uspGetName.ExecScalar(1);
                return objResult == null ? "" : objResult.ToString().Trim();
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblDictionary", "ByParentIDAndValue",
                    "sParentName：" + sParentName + "；sName：" + sName);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblDictionary", "ByParentIDAndName",
                    "sParentName：" + sParentName + "；sName：" + sName);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblDictionary", "ByParentIDAndName",
                    "sParentName：" + sParentName + "；sName：" + sName);
            }
        }
    }
}
