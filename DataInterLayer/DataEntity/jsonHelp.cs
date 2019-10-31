using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Presistence.DataEntity
{
    public class jsonHelp
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string status
        {
            get;
            set;
        }

        /// <summary>
        /// 数据
        /// </summary>
        public object data
        {
            get;
            set;
        }

        /// <summary>
        /// 提示消息
        /// </summary>
        public string msg
        {
            get;
            set;
        }
    }
}
