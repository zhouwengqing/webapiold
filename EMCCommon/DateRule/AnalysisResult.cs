using DDYZ.Ensis.Library.Exception.DataBase;
using DDYZ.Ensis.Library.Exception.DataRule;
using DDYZ.Ensis.Rule.DataRule;
using EMCCommon.Mode;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using static ThreadCallback.Program;
using DDYZ.Ensis.Presistence.DataEntity;

namespace EMCCommon.DateRule
{
    /// <summary>
    /// 功能描述： 对于返回结果 分别进行解析
    /// 创建时间：2018-11-30
    /// 创建  人：周文卿
    /// </summary>
    /// 
    public class AnalysisResult
    {
        /// <summary>
        /// 功能描述：根据类型解析不同的结果
        /// </summary>
        /// <param name="type">类型(渠道名称_)</param>
        /// <param name="rest">返回结果</param>
        /// <returns></returns>
        public ReturnResult GetResult(string type, string rest)
        {
            ReturnResult returnResult = new ReturnResult();
            switch (type)
            {
                case "YF_001_H5支付":
                    returnResult = Analy_YF_H5(rest);
                    break;
            }
            return returnResult;
        }

        /// <summary>
        /// 功能描述：悦付H5结果解析
        /// 创建时间：2018-12-12
        /// 创建  人：周文卿
        /// </summary>
        /// <param name="rest"></param>
        /// <returns></returns>
        public ReturnResult Analy_YF_H5(string rest)
        {
            ReturnResult returnResult = new ReturnResult();
            JToken jToken = JToken.Parse(rest);
            JToken order_rsp=jToken["order_rsp"].ToString();
            return returnResult;
        }
    }

}