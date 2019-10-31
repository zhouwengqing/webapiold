using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using EMCCommon.Mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 路由配置的相关操作
    /// </summary>
    public class SubrouteController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得路由信息
        /// 创建时间：2018-12-11
        /// 创建  人：周文卿  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetSubroute(parm reparm)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                string where = "";
                if (reparm.Gatewaynumber != "")
                {
                    where += " and fldGatewaynumber='" + reparm.Gatewaynumber + "'";
                }
                //查询分页的数据
                DataTable dt = rule.getpaging("vwSubroute", "*", "1=1" + where, reparm.page, reparm.limit, "fldGatewaynumber,fldPayType desc", out count);

                getdata getdata = new getdata();
                getdata.Table = dt;
                getdata.total = count;

                if (dt.Rows.Count > 0)
                {
                    result = rule.JsonStr("ok", "成功", getdata);
                }
                else
                {
                    result = rule.JsonStr("error", "失败", getdata);
                }
            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, "Subroute", "GetSubroute", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：修改路由信息
        /// 创建时间：2018-12-11
        /// 创建  人：周文卿  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage UpdateSubroute(uppram reparm)
        {
            string result = string.Empty;
            try
            {
                using (YYPlayContext yYPlay = new YYPlayContext())
                {
                    tblSubroute tbls = (from x in yYPlay.tblSubroute
                                        where x.fldAutoID == reparm.fldAutoID
                                        select x).FirstOrDefault();
                 
                    tbls.fldState = reparm.fldState == "0" ? false : true;
                    tbls.fldWeight = reparm.fldWeight;
                    tbls.fldMinmoney = reparm.fldMinmoney;
                    tbls.fldMaxmoney = reparm.fldMaxmoney;
                    tbls.fldProhibitMerchant = reparm.fldProhibitMerchant;

                

                    int i = yYPlay.SaveChanges();

                       
                     
                    if (i > 0)
                    {
                        result = rule.JsonStr("ok", "成功", i);
                    }
                    else
                    {
                        result = rule.JsonStr("error", "失败", i);
                    }
                }
            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, "Subroute", "GetSubroute", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }



        /// <summary>
        /// 
        /// </summary>
        public class parm
        {

            /// <summary>
            /// 排序字段
            /// </summary>
            public string sort { get; set; }

            /// <summary>
            /// 页数
            /// </summary>
            public int page { get; set; }

            /// <summary>
            /// 每页显示数
            /// </summary>
            public int limit { get; set; }

            /// <summary>
            /// 账户编号
            /// </summary>
            public string Gatewaynumber { get; set; }

            /// <summary>
            /// 商户ID
            /// </summary>
            public string MerchID { get; set; }

        }

        /// <summary>
        /// 
        /// </summary>
        public class uppram
        {
            /// <summary>
            /// /
            /// </summary>
            public int fldAutoID { get; set; }

            /// <summary>
            /// 状态
            /// </summary>
            public string fldState { get; set; }

            /// <summary>
            /// 权重
            /// </summary>
            public string fldWeight { get; set; }

            /// <summary>
            /// 最小金额
            /// </summary>
            public int fldMinmoney { get; set; }

            /// <summary>
            /// 最大金额
            /// </summary>
            public int fldMaxmoney { get; set; }

            /// <summary>
            /// 禁止商户
            /// </summary>
            public string fldProhibitMerchant { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class getdata
        {
            /// <summary>
            /// 总数
            /// </summary>
            public int total { get; set; }

            /// <summary>
            /// 数据
            /// </summary>
            public DataTable Table { get; set; }


        }
    }
}
