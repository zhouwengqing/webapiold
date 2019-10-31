using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Presistence.DataEntity
{
    public class tblFItem
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public string fldAutoID
        {
            get;
            set;
        }

        /// <summary>
        /// 因子代码
        /// </summary>
        public string fldItemCode
        {
            get;
            set;
        }

        /// <summary>
        /// 因子名称
        /// </summary>
        public string fldItemName
        {
            get;
            set;
        }

        /// <summary>
        /// 因子最小值
        /// </summary>
        public string fldMinValue
        {
            get;
            set;
        }

        /// <summary>
        /// 因子最大值
        /// </summary>
        public string fldMaxValue
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string fldSense
        {
            get;
            set;
        }

        /// <summary>
        /// 因子英文写法
        /// </summary>
        public string fldCharCode
        {
            get;
            set;
        }

        /// <summary>
        /// 因子单位
        /// </summary>
        public string fldUnit
        {
            get;
            set;
        }

        /// <summary>
        /// 因子保留小数位
        /// </summary>
        public string fldDec
        {
            get;
            set;
        }

        public string fldRender
        {
            get;
            set;
        }
    }
}
