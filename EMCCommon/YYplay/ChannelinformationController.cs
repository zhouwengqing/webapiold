using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.EMCCommon.AccountController.WebApiCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EMCCommon.YYplay
{
    /// <summary>
    /// 功能描述：渠道信息相关操作
    /// 创建  人：周文卿
    /// 创建时间：2019-04-03
    /// </summary>
    public class ChannelinformationController : ApiController
    {
        RuleCommon rule = new RuleCommon();

        /// <summary>
        /// 功能描述：获得路由信息
        /// 创建时间：2019-04-03
        /// 创建  人：周文卿  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage GetChannelinformation(parm reparm)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                string where = "";
               
                //查询分页的数据
                DataTable dt = rule.getpaging("tblChannelinformation", "*", "1=1" + where, reparm.page, reparm.limit, "fldUpstreamMerchantID desc", out count);

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
                throw new InsertException(e.Message, "tblChannelinformation", "GetChannelinformation", "");
            }
            return new HttpResponseMessage { Content = new StringContent(result, System.Text.Encoding.UTF8, "application/json") };
        }

        /// <summary>
        /// 功能描述：更新外扣
        /// 创建时间：2019-04-17
        /// 创建  人：周文卿  
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        [SupportFilter]
        public HttpResponseMessage UpdateChannelinformation(parm reparm)
        {
            string result = string.Empty;
            try
            {
                int count = 0;
                RuletblChannelinformation ruletbl = new RuletblChannelinformation();

                ruletbl.UpdateChannelinformation(reparm.fldbuckle, reparm.fldAutoID, out count);
                if (count > 0)
                {
                    result = rule.JsonStr("ok", "成功", "");
                }
                else
                {
                    result = rule.JsonStr("error", "失败", "");
                }
            }
            catch (Exception e)
            {
                //错误保存日志
                throw new InsertException(e.Message, "tblChannelinformation", "GetChannelinformation", "");
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
            /// 
            /// </summary>
            public string fldAutoID { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string fldbuckle { get; set; }

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
