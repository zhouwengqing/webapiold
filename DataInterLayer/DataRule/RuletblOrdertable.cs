using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 
    /// </summary>
    public class RuletblOrdertable : BaseRule
    {
        

        /// <summary>
        /// 功能描述：请求是否合法判断
        /// 创建  人：周文卿
        /// 创建时间：2018-01-05
        /// </summary>
        /// <param name="OutInt">传出参数（用于判断）</param>
        /// <param name="MemberId">商户ID</param>
        /// <param name="Amount">金额</param>
        /// <param name="OrderID">商户请求订单ID</param>
        /// <param name="PayType">支付方式</param>
        /// <param name="SecretKey">秘钥</param>
        /// <param name="rateName">支付方式</param>
        /// <returns></returns>
        public List<newtblSubroute> IsRule(out int OutInt, string MemberId, decimal Amount, string OrderID, string PayType, out string SecretKey, out string rateName)
        {
            try
            {
                usp_IsRuleH5 uspInsert = new usp_IsRuleH5();
                OutInt = 0;
                SecretKey = "";
                rateName = "";
                uspInsert.MemberId = MemberId;
                uspInsert.Amount = Amount;
                uspInsert.OrderID = OrderID;
                uspInsert.PayType = PayType;
                uspInsert.SecretKey = SecretKey;
                DataTable table = uspInsert.ExecDataTable();
                List<newtblSubroute> listAll = new List<newtblSubroute>();
                if (table != null)
                {

                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        DataTable tblTmp = table.Clone();
                        tblTmp.Rows.Add(table.Rows[i].ItemArray);
                        newtblSubroute objData = new newtblSubroute();
                        objData.MetaDataTable = tblTmp;
                        listAll.Add(objData);
                    }

                }
                OutInt = uspInsert.ReturnValue;
                SecretKey = uspInsert.SecretKey;
                rateName = uspInsert.RateName;
                return listAll;
            }
            catch (DBQueryException e)
            {
                throw new InsertException("执行Sql语句失败", "RuletblOrdertable", "IsRule", MemberId);
            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblOrdertable", "IsRule", MemberId);
            }
        }




    }
}
