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
    public class tblEQIA_RD_ItemSTD : BaseDataEntity
    {
        [AttributePK]
        private System.Int32 m_fldAutoID;

        private System.String m_fldStandardName;

        private System.String m_fldStandardNum;

        private System.String m_fldItemCode;

        private System.Decimal m_fldHourSTG1;

        private System.Decimal m_fldHourSTG2;

        private System.Decimal m_fldHourSTG3;

        private System.Decimal m_fldDaySTG1;

        private System.Decimal m_fldDaySTG2;

        private System.Decimal m_fldDaySTG3;

        private System.Decimal m_fldYearSTG1;

        private System.Decimal m_fldYearSTG2;

        private System.Decimal m_fldYearSTG3;

        public tblEQIA_RD_ItemSTD()
        {
            base.InitMetaData();
        }

        /// <summary>
        /// 复制实体类的内容
        /// </summary>
        /// <returns></returns>
        public tblEQIA_RD_ItemSTD Clone()
        {
            tblEQIA_RD_ItemSTD objNew = (tblEQIA_RD_ItemSTD)this.MemberwiseClone();
            return objNew;
        }

        public System.Int32 fldAutoID
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

        public System.String fldStandardName
        {
            get
            {
                return this.m_fldStandardName;
            }
            set
            {
                this.m_fldStandardName = value;
            }
        }

        public System.String fldStandardNum
        {
            get
            {
                return this.m_fldStandardNum;
            }
            set
            {
                this.m_fldStandardNum = value;
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

        public System.Decimal fldHourSTG1
        {
            get
            {
                return this.m_fldHourSTG1;
            }
            set
            {
                this.m_fldHourSTG1 = value;
            }
        }

        public System.Decimal fldHourSTG2
        {
            get
            {
                return this.m_fldHourSTG2;
            }
            set
            {
                this.m_fldHourSTG2 = value;
            }
        }

        public System.Decimal fldHourSTG3
        {
            get
            {
                return this.m_fldHourSTG3;
            }
            set
            {
                this.m_fldHourSTG3 = value;
            }
        }

        public System.Decimal fldDaySTG1
        {
            get
            {
                return this.m_fldDaySTG1;
            }
            set
            {
                this.m_fldDaySTG1 = value;
            }
        }

        public System.Decimal fldDaySTG2
        {
            get
            {
                return this.m_fldDaySTG2;
            }
            set
            {
                this.m_fldDaySTG2 = value;
            }
        }

        public System.Decimal fldDaySTG3
        {
            get
            {
                return this.m_fldDaySTG3;
            }
            set
            {
                this.m_fldDaySTG3 = value;
            }
        }

        public System.Decimal fldYearSTG1
        {
            get
            {
                return this.m_fldYearSTG1;
            }
            set
            {
                this.m_fldYearSTG1 = value;
            }
        }

        public System.Decimal fldYearSTG2
        {
            get
            {
                return this.m_fldYearSTG2;
            }
            set
            {
                this.m_fldYearSTG2 = value;
            }
        }

        public System.Decimal fldYearSTG3
        {
            get
            {
                return this.m_fldYearSTG3;
            }
            set
            {
                this.m_fldYearSTG3 = value;
            }
        }

    }
}
