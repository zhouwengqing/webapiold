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
    /// 功能描述    ：  对表[tblEQI_Point_Group]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQI_Point_Group : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  添加[tblEQI_Point_Group]表的记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2016-06-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public int Insert(tblEQI_Point_Group objInsert)
        {
            try
            {
                usp_tblEQI_Point_Group_Insert uspInsert = new usp_tblEQI_Point_Group_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0 || uspInsert.fldAutoID == -1)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("插入新记录失败");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblEQI_Point_Group", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("相同的记录已经存在，违反表的唯一键约束", "RuletblEQI_Point_Group", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblEQI_Point_Group", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblEQI_Point_Group", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  删除[tblEQI_Point_Group]表的记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2016-06-27
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
                usp_tblEQI_Point_Group_Delete uspDelete = new usp_tblEQI_Point_Group_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("删除记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("打开数据库连接失败", "RuletblEQI_Point_Group", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("执行Sql语句失败", "RuletblEQI_Point_Group", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblEQI_Point_Group", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  更新[tblEQI_Point_Group]表的记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2016-06-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objUpdate_old">需要更新的实体类</param>
        /// <param name="objUpdate_new">更新后的实体类</param>
        /// <returns>true / false</returns>
        public bool Update(tblEQI_Point_Group objUpdate_old, tblEQI_Point_Group objUpdate_new)
        {
            try
            {
                usp_tblEQI_Point_Group_Update uspUpdate = new usp_tblEQI_Point_Group_Update();
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
                throw new UpdateException("打开数据库连接失败", "RuletblEQI_Point_Group", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (DBPKException e)
            {
                throw new UpdatePKException("相同的记录已经存在，违反表的唯一键约束", "RuletblEQI_Point_Group", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQI_Point_Group", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQI_Point_Group", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  根据主键取得[tblEQI_Point_Group]表的记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2016-06-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iPK">PK主键值</param>
        /// <returns>tblEQI_Point_Group</returns>
        public tblEQI_Point_Group ByPK(int iPK)
        {
            try
            {
                usp_tblEQI_Point_Group_ByPK uspByPK = new usp_tblEQI_Point_Group_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblEQI_Point_Group objData = new tblEQI_Point_Group();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQI_Point_Group", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQI_Point_Group", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQI_Point_Group", "ByPK", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  根据用户ID和分组所属模块获得[tblEQI_Point_Group]表的所有记录
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2016-06-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>IList</returns>
        public IList<tblEQI_Point_Group> GetByUserIDandObject(int UserID, string Object)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQI_Point_Group_ByUserIDandObject uspByUserIDandObject = new usp_tblEQI_Point_Group_ByUserIDandObject();
                uspByUserIDandObject.fldUserID = UserID;
                uspByUserIDandObject.fldObject = Object;
                tblData = uspByUserIDandObject.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQI_Point_Group> listAll = new List<tblEQI_Point_Group>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQI_Point_Group objData = new tblEQI_Point_Group();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQI_Point_Group", "GetByUserIDandObject", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_Point_Group", "GetByUserIDandObject", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Point_Group", "GetByUserIDandObject", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
        }

        /// <summary>
        /// 功能描述    ：  根据用户ID和分组所属模块获得[tblEQI_Point_Group]表的所有记录(录入时)
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2016-06-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>IList</returns>
        public IList<tblEQI_Point_Group> GetByUserIDandObject_Input(int UserID, string Object)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQI_Point_Group_ByUserIDandObject_input uspByUserIDandObject = new usp_tblEQI_Point_Group_ByUserIDandObject_input();
                uspByUserIDandObject.fldUserID = UserID;
                uspByUserIDandObject.fldObject = Object;
                tblData = uspByUserIDandObject.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQI_Point_Group> listAll = new List<tblEQI_Point_Group>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQI_Point_Group objData = new tblEQI_Point_Group();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQI_Point_Group", "GetByUserIDandObject_Input", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_Point_Group", "GetByUserIDandObject_Input", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Point_Group", "GetByUserIDandObject_Input", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
        }

        /// <summary>
        /// 功能描述    ：  根据用户ID,城市代码,所属年份以及分组所属模块获得[tblEQI_Point_Group]表的所有记录(录入时)
        /// 创建者      ：  周文卿
        /// 创建日期    ：  2016-06-27
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>IList</returns>
        public IList<tblEQI_Point_Group> GetByUserIDandSTCodeandYearandObject_Input(int UserID, int year, string STCode, string Object)
        {
            try
            {
                DataTable tblData = new DataTable();

                usp_tblEQI_Point_Group_ByUserIDandStcodeandYearandObject_input uspByUserIDandSTCodeandYearandObject = new usp_tblEQI_Point_Group_ByUserIDandStcodeandYearandObject_input();
                uspByUserIDandSTCodeandYearandObject.fldUserID = UserID;
                uspByUserIDandSTCodeandYearandObject.fldSTCode = STCode;
                uspByUserIDandSTCodeandYearandObject.year = year;
                uspByUserIDandSTCodeandYearandObject.fldObject = Object;
                tblData = uspByUserIDandSTCodeandYearandObject.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQI_Point_Group> listAll = new List<tblEQI_Point_Group>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQI_Point_Group objData = new tblEQI_Point_Group();
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
                throw new GetListException("打开数据库连接失败", "RuletblEQI_Point_Group", "GetByUserIDandObject_Input", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblEQI_Point_Group", "GetByUserIDandObject_Input", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
            catch (Exception e)
            {
                throw new GetListException(e.Message, "RuletblEQI_Point_Group", "GetByUserIDandObject_Input", "UserID:" + UserID.ToString() + ",Object:" + Object);
            }
        }
    }
}

