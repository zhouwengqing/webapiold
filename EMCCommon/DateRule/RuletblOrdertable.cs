using DDYZ.Ensis.Presistence.DataEntity;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 功能描述：订单表的相关操作
    /// 创建时间：2018-12-03
    /// 创建  人：周文卿
    /// </summary>
    public class RuletblOrdertable
    {
        RuleCommon rule = new RuleCommon();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblOrdertable"></param>
        //public void Insert(tblOrdertable tblOrdertable)
        //{
        //    //SqlParameter[] sqlParas =
        //    //                        {
        //    //                            new SqlParameter("@fldAutoID","0"),
        //    //                            new SqlParameter("@fldCreatetime",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldtransactionnum",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldChannelnum",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldOrdernum",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldOrderAmount",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldRtefundAmount",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldMerchID",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldOrederdetailed",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldRateName",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldChannelType",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldChannelID",tblOrdertable.fldCreatetime),
        //    //                            new SqlParameter("@fldOrderInvalid",DateTime.Now),
        //    //                            new SqlParameter("@fldNotice","www.baidu.com"),
        //    //                            new SqlParameter("@fldLaunchIP",ip),
        //    //                            new SqlParameter("@fldStaute","支付中"),
        //    //                            new SqlParameter("@fldchangstautetime",DateTime.Now),
        //    //                            new SqlParameter("@fldtransactiontime",DateTime.Now),
        //    //                            new SqlParameter("@fldSettlement",amount),
        //    //                            new SqlParameter("@fldServiceCharge","0"),
        //    //                            };

        //    //            rule.RunProcedure_V2("usp_tblOrdertable_Insert", sqlParas.ToList(), "", "YYPlayContext");
        //}


    }
}