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
    /// 功能描述    ：  对表[tblEQIW_L_DAQLTSTD]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIW_L_DAQLTSTD : BaseRule
    {
        /// <summary>
        /// 功能描述    ：  取得水质执行标准
        /// 创建者      ：  张浩
        /// 创建日期    ：  2009-12-26
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>
        /// <param name="stritemCode">项目代码</param>
        /// <param name="edition">标准版本</param>
        /// <returns>IList</returns>
        public IList<tblEQIW_L_DAQLTSTD> GetSTD(string stritemCode, string edition)
        {
            try
            {
                DataTable tblData = new DataTable();
                usp_tblEQIW_L_ItemSTD_GetSTD uspSTD = new usp_tblEQIW_L_ItemSTD_GetSTD();
                uspSTD.stritemCode = stritemCode;
                uspSTD.Edition = edition;
                tblData = uspSTD.ExecDataTable();
                if (tblData != null)
                {
                    IList<tblEQIW_L_DAQLTSTD> listAll = new List<tblEQIW_L_DAQLTSTD>();
                    for (int i = 0; i < tblData.Rows.Count; i++)
                    {
                        DataTable tblTmp = tblData.Clone();
                        tblTmp.Rows.Add(tblData.Rows[i].ItemArray);
                        tblEQIW_L_DAQLTSTD objData = new tblEQIW_L_DAQLTSTD();
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
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIW_L_DAQLTSTD", "GetSTD",
                    "stritemCode：" + stritemCode + ",edition:" + edition);
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIW_L_DAQLTSTD", "GetSTD",
                    "stritemCode：" + stritemCode + ",edition:" + edition);
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIW_L_DAQLTSTD", "GetSTD",
                    "stritemCode：" + stritemCode + ",edition:" + edition);
            }
        }
    }
}
