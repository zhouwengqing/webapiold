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
    /// 功能描述    ：  对表[tblEQIA_R_ItemSTD]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIA_R_ItemSTD : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  添加[tblEQIA_R_ItemSTD]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-05-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objInsert">需要添加的实体类</param>
        /// <returns>返回新增记录的PK主键的值</returns>
        public int Insert(tblEQIA_R_ItemSTD objInsert)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_Insert uspInsert = new usp_tblEQIA_R_ItemSTD_Insert();
                uspInsert.ReceiveParameter(objInsert);
                uspInsert.ExecNoQuery();
                if (uspInsert.fldAutoID > 0)
                    return uspInsert.fldAutoID;
                else
                    throw new Exception("插入新记录失败");
            }
            catch (DBOpenException e)
            {
                throw new InsertException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (DBPKException e)
            {
                throw new InsertPKException("相同的记录已经存在，违反表的唯一键约束", "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblEQIA_R_ItemSTD", "Insert", objInsert.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  删除[tblEQIA_R_ItemSTD]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-05-26
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
                usp_tblEQIA_R_ItemSTD_Delete uspDelete = new usp_tblEQIA_R_ItemSTD_Delete();
                uspDelete.fldAutoID = iPK;
                int iResult = uspDelete.ExecNoQuery();
                if (iResult > 0)
                    return true;
                else
                    throw new Exception("删除记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new DeleteException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "Delete", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new DeleteException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "Delete", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new DeleteException(e.Message, "RuletblEQIA_R_ItemSTD", "Delete", iPK.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  更新[tblEQIA_R_ItemSTD]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-05-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="objUpdate_old">需要更新的实体类</param>
        /// <param name="objUpdate_new">更新后的实体类</param>
        /// <returns>true / false</returns>
        public bool Update(tblEQIA_R_ItemSTD objUpdate_old, tblEQIA_R_ItemSTD objUpdate_new)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_Update uspUpdate = new usp_tblEQIA_R_ItemSTD_Update();
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
                throw new UpdateException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "Update", 
					"objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (DBPKException e)
            {
                throw new UpdatePKException("相同的记录已经存在，违反表的唯一键约束", "RuletblEQIA_R_ItemSTD", "Update",
                    "objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (DBQueryException e)
            {
                throw new UpdateException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "Update", 
					"objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
            catch (Exception e)
            {
                throw new UpdateException(e.Message, "RuletblEQIA_R_ItemSTD", "Update", 
					"objUpdate_old：" + objUpdate_old.ToString() + "；objUpdate_new：" + objUpdate_new.ToString());
            }
        }

        /// <summary>
        /// 功能描述    ：  根据主键取得[tblEQIA_R_ItemSTD]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-05-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="iPK">PK主键值</param>
        /// <returns>tblEQIA_R_ItemSTD</returns>
        public tblEQIA_R_ItemSTD ByPK(int iPK)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_ByPK uspByPK = new usp_tblEQIA_R_ItemSTD_ByPK();
                uspByPK.fldAutoID = iPK;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_ItemSTD objData = new tblEQIA_R_ItemSTD();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "ByPK", iPK.ToString());
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "ByPK", iPK.ToString());
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "ByPK", iPK.ToString());
            }
        }



        /// <summary>
        /// 功能描述    ：  获得[tblEQIA_R_ItemSTD]表的所有标准名称
        /// 创建者      ：  马立军
        /// 创建日期    ：  2009-07-08
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetAllStandardName()
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_ItemSTD_GetAllStandardName uspByAll = new usp_tblEQIA_R_ItemSTD_GetAllStandardName();
                tblData = uspByAll.ExecDataTable();
                if (tblData != null)
                {
                    tblData.TableName = "tblEQIA_R_ItemSTD";
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetAllException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "GetAllStandardName", "");
            }
            catch (DBQueryException e)
            {
                throw new GetAllException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "GetAllStandardName", "");
            }
            catch (Exception e)
            {
                throw new GetAllException(e.Message, "RuletblEQIA_R_ItemSTD", "GetAllStandardName", "");
            }
        }
        
        /// <summary>
        /// 功能描述    ：  根据标准名称和项目代码取得[tblEQIA_R_ItemSTD]表的记录
        /// 创建者      ：  Auto Generator
        /// 创建日期    ：  2009-05-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sStandardName">标准名称</param>
        /// <param name="sItemCode">项目代码</param>
        /// <returns>tblEQIA_R_ItemSTD</returns>
        public tblEQIA_R_ItemSTD ByStandardNameAndItemCode(string sStandardName,string sItemCode)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_ByStandardNameAndItemCode uspByPK = new usp_tblEQIA_R_ItemSTD_ByStandardNameAndItemCode();
                uspByPK.fldStandardName = sStandardName;
                uspByPK.fldItemCode = sItemCode;
                DataTable tblData = uspByPK.ExecDataTable();
                if (tblData != null)
                {
                    tblEQIA_R_ItemSTD objData = new tblEQIA_R_ItemSTD();
                    objData.MetaDataTable = tblData;
                    return objData;
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "ByStandardNameAndItemCode",
                    "sStandardName：" + sStandardName + "；sItemCode：" + sItemCode);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "ByStandardNameAndItemCode",
                    "sStandardName：" + sStandardName + "；sItemCode：" + sItemCode);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "ByStandardNameAndItemCode",
                    "sStandardName：" + sStandardName + "；sItemCode：" + sItemCode);
            }
        }

        /// <summary>
        /// 功能描述    ：  根据标准名称,项目代码和级别取得标准值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-31
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="sStandardName">标准名称</param>
        /// <param name="sItemCode">项目代码</param>
        /// <param name="strSTDLevel">级别(一级,二级..)</param>
        /// <param name="strFlag">类别(month,sea..)</param>
        /// <returns>decimal</returns>
        public decimal GetItemStandard(string sStandardName, string sItemCode, string strSTDLevel, string strFlag)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_GetSTG uspSTG= new usp_tblEQIA_R_ItemSTD_GetSTG();
                uspSTG.strItemCode = sItemCode;
                uspSTG.strSTDName = sStandardName;
                uspSTG.strSTDLevel = strSTDLevel;
                uspSTG.strFlag = strFlag;
                DataTable tblData = uspSTG.ExecDataTable();
                if (tblData != null)
                {
                    return decimal.Parse(tblData.Rows[0]["STG"].ToString());
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "GetItemStandard",
                    "sStandardName：" + sStandardName + "；sItemCode：" + sItemCode + "; strSTDLevel:" + strSTDLevel+"; strFlag:"+strFlag);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "GetItemStandard",
                    "sStandardName：" + sStandardName + "；sItemCode：" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetItemStandard",
                    "sStandardName：" + sStandardName + "；sItemCode：" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
        }


        /// <summary>
        /// 功能描述    ：  取得指标平均值
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-07-31
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="dNumValue">对比值</param>
        /// <param name="sStandardName">标准名称</param>
        /// <param name="sItemCode">项目代码</param>
        /// <param name="strSTDLevel">级别(一级,二级..)</param>
        /// <param name="strFlag">类别(month,sea..)</param>
        /// <returns>decimal</returns>
        public decimal GetTargetAVG(decimal dNumValue, string sStandardName, string sItemCode, string strSTDLevel, string strFlag)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_GetTargetAVG uspTargetAVG = new usp_tblEQIA_R_ItemSTD_GetTargetAVG();
                uspTargetAVG.numValue = dNumValue;
                uspTargetAVG.strItemCode = sItemCode;
                uspTargetAVG.strSTDName = sStandardName;
                uspTargetAVG.strSTDLevel = strSTDLevel;
                uspTargetAVG.strFlag = strFlag;
                DataTable tblData = uspTargetAVG.ExecDataTable();
                if (tblData != null)
                {
                    if (tblData.Rows[0]["TargetAVG"].ToString() == "")
                        return 0;
                    else
                        return decimal.Parse(tblData.Rows[0]["TargetAVG"].ToString());
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "GetTargetAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName：" + sStandardName + ";sItemCode：" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "GetTargetAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName：" + sStandardName + ";sItemCode：" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetTargetAVG",
                    "dNumValue:"+dNumValue.ToString()+";sStandardName：" + sStandardName + ";sItemCode：" + sItemCode + "; strSTDLevel:" + strSTDLevel + "; strFlag:" + strFlag);
            }
        }


        /// <summary>
        /// 功能描述    ：  取空气质量级别
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2009-08-03
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="dNumValue">平均值</param>
        /// <param name="sStandardName">标准名称</param>
        /// <param name="sItemCode">项目代码</param> 
        /// <param name="strFlag">类别(month,sea..)</param>
        /// <returns>int</returns>
        public int GetAQLAVG(decimal dNumValue, string sStandardName, string sItemCode,  string strFlag)
        {
            try
            {
                usp_tblEQIA_R_ItemSTD_GetAQL uspAQLAVG = new usp_tblEQIA_R_ItemSTD_GetAQL();
                uspAQLAVG.nAVG = dNumValue;
                uspAQLAVG.strItemCode = sItemCode;
                uspAQLAVG.strSTDName = sStandardName;
                uspAQLAVG.strFlag = strFlag;
                DataTable tblData = uspAQLAVG.ExecDataTable();
                if (tblData != null)
                {
                    return int.Parse(tblData.Rows[0]["AQLLevel"].ToString());
                }
                else
                    throw new Exception("取得单条记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "GetAQLAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName：" + sStandardName + "；sItemCode：" + sItemCode + "; strFlag:" + strFlag);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "GetAQLAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName：" + sStandardName + "；sItemCode：" + sItemCode + "; strFlag:" + strFlag);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetAQLAVG",
                    "dNumValue:" + dNumValue.ToString() + ";sStandardName：" + sStandardName + "；sItemCode：" + sItemCode + "; strFlag:" + strFlag);
            }
        }

        /// <summary>
        /// 功能描述    ：  取得日均值标准
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-11-24
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stritemCode">项目代码</param>
        /// <param name="standardNum">标准号</param>
        /// <returns>IList</returns>
        public IList<tblEQIA_R_ItemSTD> GetDaySTG(string stritemCode,string standardNum)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIA_R_ItemSTD_GetDaySTG uspSTG = new usp_tblEQIA_R_ItemSTD_GetDaySTG();
                uspSTG.stritemCode = stritemCode;
                uspSTG.StandardNum = standardNum;
                tblData = uspSTG.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIA_R_ItemSTD> listAll = new List<tblEQIA_R_ItemSTD>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIA_R_ItemSTD objData = new tblEQIA_R_ItemSTD();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIA_R_ItemSTD", "GetDaySTG",
"stritemCode：" + stritemCode + ",standardNum:" + standardNum);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIA_R_ItemSTD", "GetDaySTG", "stritemCode：" + stritemCode + ",standardNum:" + standardNum);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIA_R_ItemSTD", "GetDaySTG", "stritemCode：" + stritemCode + ",standardNum:" + standardNum);
            }
        }
    }
}
