using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMCCommon.Mode
{
    /// <summary>
    /// 
    /// </summary>
    public class rerurnpram
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public string statecode { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public string data
        {
            get; set;
        }

        /// <summary>
        /// 二维码地址
        /// </summary>
        public string urlcode
        {
            get; set;
        }
    }
}