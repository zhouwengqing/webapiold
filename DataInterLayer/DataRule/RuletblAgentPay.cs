using DDYZ.Ensis.DataSource.DataAccess;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Presistence.DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DDYZ.Ensis.Library.Exception.DataBase;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 代付表的相关操作
    /// </summary>
    public class RuletblAgentPay
    {
        /// <summary>
        /// 功能描述：代付表插入，修改账户表 冻结金额，减少总额（请求代付）
        /// 创建时间：2018-12-7
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="tblAgentPay"></param>
        /// <returns></returns>
        public DataTable InserttblAgentPayUptblAcc(tblAgentPay tblAgentPay)
        {
            try
            {
                usp_insert_tblAgentPay tbl = new usp_insert_tblAgentPay();
                tbl.fldAutoID = tblAgentPay.fldAutoID;
                tbl.fldCreateTime = tblAgentPay.fldCreateTime;
                tbl.fldtransactionnum = tblAgentPay.fldtransactionnum;
                tbl.fldChannelnum = tblAgentPay.fldChannelnum;
                tbl.fldOrdernum = tblAgentPay.fldOrdernum;
                tbl.fldMerchID = tblAgentPay.fldMerchID;
                tbl.fldPayAmount = tblAgentPay.fldPayAmount;
                tbl.fldPayState = tblAgentPay.fldPayState;
                tbl.fldServiceCharge = tblAgentPay.fldServiceCharge;
                tbl.fldActualAmount = tblAgentPay.fldActualAmount;
                tbl.fldAccountname = tblAgentPay.fldAccountname;
                tbl.fldBankCardId = tblAgentPay.fldBankCardId;
                tbl.fldBankName = tblAgentPay.fldBankName;
                tbl.fldChannelID = tblAgentPay.fldChannelID;
                tbl.fldLaunchIP = tblAgentPay.fldLaunchIP;
                tbl.fldNotice = tblAgentPay.fldNotice;
                tbl.fldchangstautetime = tblAgentPay.fldchangstautetime;
                tbl.fldtransactiontime = tblAgentPay.fldtransactiontime;
                tbl.fldRtefundAmount = tblAgentPay.fldRtefundAmount;
                tbl.fldBankType = tblAgentPay.fldBankType;
                tbl.fldSettlementAmount = tblAgentPay.fldSettlementAmount;
                tbl.fldBankcity = tblAgentPay.fldBankcity;
                tbl.fldBankprovince = tblAgentPay.fldBankprovince;
                tbl.fldBankTelephoneNo = tblAgentPay.fldBankTelephoneNo;
                tbl.fldIdCard = tblAgentPay.fldIdCard;
                tbl.fldCardType = tblAgentPay.fldCardType;
                tbl.fldBankbranch = tblAgentPay.fldBankbranch;
                //tbl.ReceiveParameter(tblAgentPay);
                DataTable tb = tbl.ExecDataTable();
                int j = tbl.fldAutoID;
                if (j == 0)
                {
                    return InserttblAgentPayUptblAcc(tblAgentPay);
                }
                else
                {
                    return tb;
                }

            }
            catch (Exception e)
            {
                throw new InsertException(e.Message, "RuletblAgentPay", "InserttblAgentPayUptblAcc", "插入失败");
            }

        }


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
        /// <param name="rateName">手续费</param>
        ///  <param name="rateName">手续费</param>
        /// <returns></returns>
        public List<newtblSubroute> IsRuleSub(out int OutInt, string MemberId, decimal Amount, string OrderID, string PayType, out string SecretKey, out string rateName, string ip)
        {
            try
            {
                usp_IsRulePaySub uspInsert = new usp_IsRulePaySub();
                OutInt = 0;
                SecretKey = "";
                rateName = "";
                uspInsert.MemberId = MemberId;
                uspInsert.Amount = Amount;
                uspInsert.OrderID = OrderID;
                uspInsert.IPAddress = ip;
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

        /// <summary>
        /// 功能描述：根据商户和订单号  减少冻结金额和总额（代付成功）
        /// 创建时间：2018-02-22
        /// 创建 人：周文卿
        /// </summary>
        /// <param name="fldMerchID">商户ID</param>
        /// <param name="fldChannelnum">发往渠道订单号</param>
        /// <param name="fldStaute">状态</param>
        /// <param name="IsSuccess">是否成功</param>
        /// <param name="fldTotalAmount">金额</param>
        /// <returns></returns>
        public DataTable updatestate(string fldMerchID, string fldChannelnum, string fldStaute, out bool IsSuccess, decimal fldTotalAmount)
        {
            try
            {

                usp_updatetblAgentPay usp = new usp_updatetblAgentPay();
                usp.fldMerchID = fldMerchID;
                usp.fldChannelnum = fldChannelnum;
                usp.fldStaute = fldStaute;
                usp.IsSuccess = false;
                usp.fldTotalAmount = fldTotalAmount;
                DataTable dt = usp.ExecDataTable();
                IsSuccess = usp.IsSuccess;
                if (IsSuccess)
                {
                    return dt;
                }
                else
                {
                    return updatestate(fldMerchID, fldChannelnum, fldStaute, out IsSuccess, fldTotalAmount);
                }


            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblAgentPay", "updatestate", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblAgentPay", "updatestate", "");
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "RuletblAgentPay", "updatestate", "更新");
            }

        }



        /// <summary>
        /// 功能描述：根据商户和订单号  减少冻结金额，可提现金额增加，余额不变（代付失败）
        /// 创建时间：2018-02-22
        /// 创建 人：周文卿
        /// </summary>
        /// <param name="fldMerchID">商户ID</param>
        /// <param name="fldChannelnum">发往渠道订单号</param>
        /// <param name="fldStaute">状态</param>
        /// <param name="IsSuccess">是否成功</param>
        /// <param name="fldTotalAmount">金额</param>
        /// <returns></returns>
        public DataTable updatestatefail(string fldMerchID, string fldChannelnum, string fldStaute, out bool IsSuccess, decimal fldTotalAmount)
        {
            try
            {

                usp_updatetblAgentPayfail usp = new usp_updatetblAgentPayfail();
                usp.fldMerchID = fldMerchID;
                usp.fldChannelnum = fldChannelnum;
                usp.fldStaute = fldStaute;
                usp.IsSuccess = false;
                usp.fldTotalAmount = fldTotalAmount;
                DataTable dt = usp.ExecDataTable();
                IsSuccess = usp.IsSuccess;
                if (IsSuccess)
                {
                    return dt;
                }
                else
                {
                    return updatestatefail(fldMerchID, fldChannelnum, fldStaute, out IsSuccess, fldTotalAmount);
                }


            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblAgentPay", "updatestate", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblAgentPay", "updatestate", "");
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "RuletblAgentPay", "updatestate", "更新");
            }

        }

        /// <summary>
        /// 修改状态 金额不变 异常状态 等待手工确认
        /// </summary>
        /// <param name="fldMerchID"></param>
        /// <param name="fldChannelnum"></param>
        /// <param name="fldStaute"></param>
        /// <param name="IsSuccess"></param>
        /// <returns></returns>
        public DataTable updatestate(string fldMerchID, string fldChannelnum, string fldStaute, out bool IsSuccess)
        {
            try
            {

                usp_updatetblAgentPayState usp = new usp_updatetblAgentPayState();
                usp.fldMerchID = fldMerchID;
                usp.fldChannelnum = fldChannelnum;
                usp.fldStaute = fldStaute;
                usp.IsSuccess = false;
                DataTable dt = usp.ExecDataTable();
                IsSuccess = usp.IsSuccess;
                return dt;
            }
            catch (DBOpenException e)
            {
                throw new GetListException("打开数据库连接失败", "RuletblAgentPay", "updatestate", "");
            }
            catch (DBQueryException e)
            {
                throw new GetListException("执行Sql语句失败", "RuletblAgentPay", "updatestate", "");
            }
            catch (Exception e)
            {

                throw new InsertException(e.Message, "RuletblAgentPay", "updatestate", "更新");
            }

        }
    }
}
