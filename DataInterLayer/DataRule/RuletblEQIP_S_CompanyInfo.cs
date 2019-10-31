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
    /// 功能描述    ：  对表[tblEQIP_S_CompanyInfo]的数据操作
    /// 创建者      ：  Auto Generator
    /// 创建日期    ：  2009-03-27
    /// 修改者      ：
    /// 修改日期    ：
    /// 修改原因    ：
    /// </summary>
    public class RuletblEQIP_S_CompanyInfo : BaseRule
    {  
        /// <summary>
        /// 功能描述    ：  取得当年企业的GIS信息
        /// 创建者      ：  朱春华
        /// 创建日期    ：  2012-04-15
        /// 修改者      ：
        /// 修改日期    ：
        /// 修改原因    ：
        /// </summary>  
        /// <returns>DataTable</returns>
        public DataTable GetCompanyInfoForGis(string sType)
        {
            try
            {
                usp_tblEQIP_S_WaterCompanyInfo_forGis GetCompany = new usp_tblEQIP_S_WaterCompanyInfo_forGis();
                GetCompany.EType = sType;
                DataTable tblData = GetCompany.ExecDataTable(2);
                if (tblData != null)
                {
                    return tblData;
                }
                else
                    throw new Exception("取得记录失败，未找到对应的记录");
            }
            catch (DBOpenException e)
            {
                throw new GetByPKException("打开数据库连接失败", "RuletblEQIP_S_CompanyInfo", "GetCompanyInfoForGis", "");
            }
            catch (DBQueryException e)
            {
                throw new GetByPKException("执行Sql语句失败", "RuletblEQIP_S_CompanyInfo", "GetCompanyInfoForGis", "");
            }
            catch (Exception e)
            {
                throw new GetByPKException(e.Message, "RuletblEQIP_S_CompanyInfo", "GetCompanyInfoForGis", "");
            }
        }
    }
}
