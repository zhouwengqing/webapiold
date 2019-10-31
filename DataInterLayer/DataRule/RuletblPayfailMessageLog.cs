using DDYZ.Ensis.DataSource.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Rule.DataRule
{
    /// <summary>
    /// 支付日志表
    /// </summary>
    public class RuletblPayfailMessageLog
    {
        /// <summary>
        /// 功能描述：插入支付日志表
        /// 创建  人：周文卿
        /// 创建时间：2019-03-09
        /// </summary>
        /// <param name="fldlChanneName">渠道名称</param>
        /// <param name="fldlChanneID">渠道ID</param>
        /// <param name="fldMess">提示信息</param>
        /// <param name="fldtransactionnum">流水号</param>
        /// <param name="fldOrderID">订单号</param>
        /// <param name="fldtime">时间</param>
        /// <param name="fldresult">返回结果</param>
        public void inserttblPayfailMessageLog(string fldlChanneName,string fldlChanneID,string fldMess,string fldtransactionnum,string fldOrderID,DateTime fldtime,string fldresult) {
            usp_inserttblPayfailMessageLog usp_Inserttbl = new usp_inserttblPayfailMessageLog();
            usp_Inserttbl.fldlChanneName = fldlChanneName;
            usp_Inserttbl.fldlChanneID = fldlChanneID;
            usp_Inserttbl.fldMess = fldMess;
            usp_Inserttbl.fldtransactionnum = fldtransactionnum;
            usp_Inserttbl.fldOrderID = fldOrderID;
            usp_Inserttbl.fldtime = fldtime;
            usp_Inserttbl.fldresult = fldresult;
            usp_Inserttbl.ExecDataTable();
        }

        public void inserttblPayfailMessageLog(string v1, string v2, object urlDecode, string ownresult1, string v3, string v4, DateTime now, string ownresult2)
        {
            throw new NotImplementedException();
        }
    }
}
