using DDYZ.Ensis.DataSource.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
   public class RuletblEQI_Auditing_COM_DeleteAll
    {
        /// <summary>
        /// 删除数据
        /// </summary> 
        /// <param name="oldflag">旧状态</param> 
        /// <param name="cityID">可操作城市ID</param>
        /// <returns></returns>
        public int DelAllData(Int16 oldflag, string where, int city, string table)
        {
            try
            {
                usp_tblEQIA_RDPI_Basedata_Pre_DelAllData uspAllData = new usp_tblEQIA_RDPI_Basedata_Pre_DelAllData();
                uspAllData.fldOldFage = oldflag;
                uspAllData.city = city;
                uspAllData.where = where;
                uspAllData.table = table;
                int iResult = uspAllData.ExecNoQuery();
                return iResult;
            }
            catch (Exception e)
            {
                throw new Exception("删除数据失败，" + e.Message.ToString());
            }
        }
    }
}
