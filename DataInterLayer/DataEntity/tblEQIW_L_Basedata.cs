//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: v2.0.50727
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace DDYZ.Ensis.Presistence.DataEntity
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SqlTypes;
    using System.Xml;
    using System.Reflection;

    [Serializable]
    public class tblEQIW_L_Basedata : BaseDataEntity
    {
        [AttributePK]
        private System.Int64 m_fldAutoID;

        private System.String m_fldSTCode;

        private System.String m_fldSTName;

        private System.String m_fldLCode;

        private System.String m_fldLName;

        private System.String m_fldLSCode;

        private System.String m_fldLSName;

        private System.String m_fldSAMPH;

        private System.String m_fldSAMPR;

        private System.String m_fldRSC;

        private System.Decimal m_fldYear;

        private System.Decimal m_fldMonth;

        private System.Decimal m_fldDay;

        private System.Decimal m_fldHour;

        private System.Decimal m_fldMinute;

        private System.String m_fldItemCode;

        private System.String m_fldItemName;

        private System.Decimal m_fldItemValue;

        private System.Int16 m_fldSource;

        private System.Int32 m_fldUserID;

        private System.Int16 m_fldFlag;

        private System.Boolean m_fldBReport;

        private System.Int32 m_fldErrorRowIndex;

        public tblEQIW_L_Basedata()
        {
            base.InitMetaData();
        }

        /// <summary>
        /// 复制实体类的内容
        /// </summary>
        /// <returns></returns>
        public tblEQIW_L_Basedata Clone()
        {
            tblEQIW_L_Basedata objNew = (tblEQIW_L_Basedata)this.MemberwiseClone();
            return objNew;
        }

        public System.Int64 fldAutoID
        {
            get
            {
                return this.m_fldAutoID;
            }
            set
            {
                this.m_fldAutoID = value;
            }
        }

        public System.String fldSTCode
        {
            get
            {
                return this.m_fldSTCode;
            }
            set
            {
                this.m_fldSTCode = value;
            }
        }

        public System.String fldSTName
        {
            get
            {
                return this.m_fldSTName;
            }
            set
            {
                this.m_fldSTName = value;
            }
        }

        public System.String fldLCode
        {
            get
            {
                return this.m_fldLCode;
            }
            set
            {
                this.m_fldLCode = value;
            }
        }

        public System.String fldLName
        {
            get
            {
                return this.m_fldLName;
            }
            set
            {
                this.m_fldLName = value;
            }
        }

        public System.String fldLSCode
        {
            get
            {
                return this.m_fldLSCode;
            }
            set
            {
                this.m_fldLSCode = value;
            }
        }

        public System.String fldLSName
        {
            get
            {
                return this.m_fldLSName;
            }
            set
            {
                this.m_fldLSName = value;
            }
        }

        public System.String fldSAMPH
        {
            get
            {
                return this.m_fldSAMPH;
            }
            set
            {
                this.m_fldSAMPH = value;
            }
        }

        public System.String fldSAMPR
        {
            get
            {
                return this.m_fldSAMPR;
            }
            set
            {
                this.m_fldSAMPR = value;
            }
        }

        public System.String fldRSC
        {
            get
            {
                return this.m_fldRSC;
            }
            set
            {
                this.m_fldRSC = value;
            }
        }

        public System.Decimal fldYear
        {
            get
            {
                return this.m_fldYear;
            }
            set
            {
                this.m_fldYear = value;
            }
        }

        public System.Decimal fldMonth
        {
            get
            {
                return this.m_fldMonth;
            }
            set
            {
                this.m_fldMonth = value;
            }
        }

        public System.Decimal fldDay
        {
            get
            {
                return this.m_fldDay;
            }
            set
            {
                this.m_fldDay = value;
            }
        }

        public System.Decimal fldHour
        {
            get
            {
                return this.m_fldHour;
            }
            set
            {
                this.m_fldHour = value;
            }
        }

        public System.Decimal fldMinute
        {
            get
            {
                return this.m_fldMinute;
            }
            set
            {
                this.m_fldMinute = value;
            }
        }

        public System.String fldItemCode
        {
            get
            {
                return this.m_fldItemCode;
            }
            set
            {
                this.m_fldItemCode = value;
            }
        }

        public System.String fldItemName
        {
            get
            {
                return this.m_fldItemName;
            }
            set
            {
                this.m_fldItemName = value;
            }
        }

        public System.Decimal fldItemValue
        {
            get
            {
                return this.m_fldItemValue;
            }
            set
            {
                this.m_fldItemValue = value;
            }
        }

        public System.Int16 fldSource
        {
            get
            {
                return this.m_fldSource;
            }
            set
            {
                this.m_fldSource = value;
            }
        }

        public System.Int32 fldUserID
        {
            get
            {
                return this.m_fldUserID;
            }
            set
            {
                this.m_fldUserID = value;
            }
        }

        public System.Int16 fldFlag
        {
            get
            {
                return this.m_fldFlag;
            }
            set
            {
                this.m_fldFlag = value;
            }
        }

        public System.Boolean fldBReport
        {
            get
            {
                return this.m_fldBReport;
            }
            set
            {
                this.m_fldBReport = value;
            }
        }

        public System.Int32 fldErrorRowIndex
        {
            get
            {
                return this.m_fldErrorRowIndex;
            }
            set
            {
                this.m_fldErrorRowIndex = value;
            }
        }

    }
}
