using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EMCCommon.Mode;
using DDYZ.Ensis.Rule.DataRule;
using System.Data.SqlClient;
using DDYZ.Ensis.Library.Exception.DataRule;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 功能描述：账务系统
    /// 创建时间：2018-12-03
    /// 创建  人：周文卿
    /// </summary>
    public class RuleAccounting
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 功能描述：插入
        /// 创建时间：2018-14-4
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="tblAccounting"></param>
        /// <returns></returns>
        public DataTable InsertAccounting(tblAccounting tblAccounting)
        {
            try {
                DataTable table = new DataTable();

                SqlParameter[] sqlParas =
                                       {
                                        new SqlParameter("@fldAutoID","0"),
                                        new SqlParameter("@fldAccountingnum",tblAccounting.fldAccountingnum),
                                        new SqlParameter("@fldMerchID",tblAccounting.fldMerchID),
                                        new SqlParameter("@fldTotalAmount",tblAccounting.fldTotalAmount),
                                        new SqlParameter("@fldWithdraw",tblAccounting.fldWithdraw),
                                        new SqlParameter("@fldFrozenAmount",tblAccounting.fldFrozenAmount),
                                        new SqlParameter("@fldUnsettledAmoun",tblAccounting.fldUnsettledAmoun),
                                        new SqlParameter("@fldState",tblAccounting.fldState),

                                        };

                table = rule.RunProcedure_V2("usp_tblOrdertable_Insert", sqlParas.ToList(), "", "YYPlayContext");
                return table;
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuleAccounting", "InsertAccounting", "插入失败");
            }
           
        }
    }
}