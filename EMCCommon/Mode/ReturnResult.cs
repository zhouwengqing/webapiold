using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCCommon.Mode
{
    /// <summary>
    /// 返回结果实体
    /// </summary>
    public class ReturnResult
    {
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string state { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string data { get; set; }
    }
}