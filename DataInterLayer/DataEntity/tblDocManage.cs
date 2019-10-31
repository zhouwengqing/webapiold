using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDYZ.Ensis.Presistence.DataEntity
{
    /// <summary>
    /// 描述数据库表中的编码和名称对
    /// </summary>
    public class tblDocManage
    {
        public Int64 fldAutoID { get; set; } // 编码
        public string fldBusinessType { get; set; } // 业务类型
        public string fldSTCode { get; set; }
        public string fldSTName { get; set; }
        public string fldDocName { get; set; }
        public string fldDocPath { get; set; }
        public string fldUpLoadDate { get; set; }
        public string fldReportingDate { get; set; }
        public bool fldisReport { get; set; }
        public string fldOperate_UserID { get; set; }
        public string fldDocDate { get; set; }
        public string fldFileClassify { get; set; }
    }
}
