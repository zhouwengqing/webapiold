﻿//------------------------------------------------------------------------------
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
    public class tblEQIW_STS_Basedata_Pre : BaseDataEntity
    {
        [AttributePK]
        private System.Int64 m_fldAutoID;

        private System.String m_fldSTCode;

        private System.String m_fldRCode;

        private System.String m_fldRSCode;

        private System.String m_fldSAMPH;

        private System.String m_fldSAMPR;

        private System.String m_fldRSC;

        private System.Decimal m_fldYear;

        private System.Decimal m_fldMonth;

        private System.Decimal m_fldDay;

        private System.Decimal m_fldHour;

        private System.Decimal m_fldMinute;

        private System.String m_fldItemCode;

        private System.Decimal m_fldItemValue;

        private System.Int16 m_fldFlag;

        private System.Int16 m_fldImport;

        private System.Int32 m_fldCityID_Operate;

        private System.String m_fldCityID_Submit;

        private System.DateTime m_fldDate_Operate;

        private System.Int32 m_fldUserID;

        private System.Int16 m_fldSource;

        private System.String m_fldBatch;

        public tblEQIW_STS_Basedata_Pre()
        {
            base.InitMetaData();
        }

        /// <summary>
        /// 复制实体类的内容
        /// </summary>
        /// <returns></returns>
        public tblEQIW_STS_Basedata_Pre Clone()
        {
            tblEQIW_STS_Basedata_Pre objNew = (tblEQIW_STS_Basedata_Pre)this.MemberwiseClone();
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

        public System.String fldRCode
        {
            get
            {
                return this.m_fldRCode;
            }
            set
            {
                this.m_fldRCode = value;
            }
        }

        public System.String fldRSCode
        {
            get
            {
                return this.m_fldRSCode;
            }
            set
            {
                this.m_fldRSCode = value;
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

        public System.Int16 fldImport
        {
            get
            {
                return this.m_fldImport;
            }
            set
            {
                this.m_fldImport = value;
            }
        }

        public System.Int32 fldCityID_Operate
        {
            get
            {
                return this.m_fldCityID_Operate;
            }
            set
            {
                this.m_fldCityID_Operate = value;
            }
        }

        public System.String fldCityID_Submit
        {
            get
            {
                return this.m_fldCityID_Submit;
            }
            set
            {
                this.m_fldCityID_Submit = value;
            }
        }

        public System.DateTime fldDate_Operate
        {
            get
            {
                return this.m_fldDate_Operate;
            }
            set
            {
                this.m_fldDate_Operate = value;
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

        public System.String fldBatch
        {
            get
            {
                return this.m_fldBatch;
            }
            set
            {
                this.m_fldBatch = value;
            }
        }

    }
}
