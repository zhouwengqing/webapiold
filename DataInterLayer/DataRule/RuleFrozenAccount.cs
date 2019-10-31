using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.DataSource.DataAccess;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuleFrozenAccount: BaseRule
    {
        /// <summary>
        /// 功能描述：冻结金额 
        /// 创建  人：周文卿
        /// 创建时间：2018-12-28
        /// </summary>
        /// <param name="mid">商户ID</param>
        /// <param name="account">金额</param>
        /// <param name="fldAutoID">判断成功 失败 余额</param>
        /// <returns></returns>
        public DataTable FrozenAccount(string mid, string account, out int fldAutoID)
        {
            try {
                DataTable table = new DataTable();
                usp_FrozentblAccounting usp = new usp_FrozentblAccounting();
                usp.Accoun = account;
                usp.MerchID = mid;
                usp.fldAutoID = 1;
                table = usp.ExecDataTable();
                fldAutoID = usp.fldAutoID;
                return table;
            }
            catch (Exception e) {
                throw new InsertException(e.Message, " RuleFrozenAccount", "FrozenAccount", mid);
            }
        }

        /// <summary>
        /// 功能描述：解冻金额 
        /// 创建  人：周文卿
        /// 创建时间：2018-12-28
        /// </summary>
        /// <param name="mid">商户ID</param>
        /// <param name="account">金额</param>
        /// <param name="fldAutoID">判断成功 失败 余额</param>
        /// <returns></returns>
        public DataTable ThawAccount(string mid, string account, out int fldAutoID)
        {
            try
            {
                DataTable table = new DataTable();
                usp_ThawtblAccounting usp = new usp_ThawtblAccounting();
                usp.Accoun = account;
                usp.MerchID = mid;
                usp.fldAutoID = 1;
                table = usp.ExecDataTable();
                fldAutoID = usp.fldAutoID;
                return table;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, " RuleFrozenAccount", "FrozenAccount", mid);
            }
        }
    }
}
