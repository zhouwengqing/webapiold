using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDYZ.Ensis.Presistence.DataEntity
{
    public class tblFW_ReportDataList
    {
        /// <summary>
        /// 分类标题
        /// </summary>
        public string title
        {
            get;
            set;
        }

        /// <summary>
        /// 报表数据
        /// </summary>
        public List<tblFW_Report> data
        {
            get;
            set;
        }
    }
}
