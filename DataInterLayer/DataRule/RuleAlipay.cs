using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Library.Exception.Page.Input;
using System.Collections;

namespace DDYZ.Ensis.Rule.DataRule
{
    public class RuleAlipay
    {
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="OrderID"></param>
        /// <param name="transactionnum"></param>
        /// <param name="PayUrl"></param>
        /// <param name="Time"></param>
        /// <returns></returns>
        public int insertAlipay(string OrderID, string transactionnum, string PayUrl, DateTime Time)
        {
            try
            {
                int i = 0;
                inserttblAlipay inserttbl = new inserttblAlipay();
                inserttbl.fldOrderID = OrderID;
                inserttbl.fldtransactionnum = transactionnum;
                inserttbl.fldPayUrl = PayUrl;
                inserttbl.fldTime = Time;
                i = inserttbl.ExecNoQuery();
                return i;

            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "insertAlipay", "RuleAlipay", transactionnum);
            }

        }
    }
}
