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
    public class tblEQI_Query_Group : BaseDataEntity
    {
        [AttributePK]
        private System.Int32 m_fldAutoID;

        private System.String m_fldObject;

        private System.String m_fldName;

        private System.String m_fldUserID;

        private System.String m_fldTimeType;

        private System.String m_fldTimeRange;

        private System.String m_fldItemGroup;

        private System.String m_fldItemCode;

        private System.String m_fldPointGroup;

        private System.String m_fldPointCode;

        private System.String m_fldSource;

        private System.String m_fldDataType;

        private System.String m_fldSampleType;

        public tblEQI_Query_Group()
        {
            base.InitMetaData();
        }

        /// <summary>
        /// ����ʵ���������
        /// </summary>
        /// <returns></returns>
        public tblEQI_Query_Group Clone()
        {
            tblEQI_Query_Group objNew = (tblEQI_Query_Group)this.MemberwiseClone();
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

        public System.String fldObject
        {
            get
            {
                return this.m_fldObject;
            }
            set
            {
                this.m_fldObject = value;
            }
        }

        public System.String fldName
        {
            get
            {
                return this.m_fldName;
            }
            set
            {
                this.m_fldName = value;
            }
        }

        public System.String fldUserID
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

        public System.String fldTimeType
        {
            get
            {
                return this.m_fldTimeType;
            }
            set
            {
                this.m_fldTimeType = value;
            }
        }

        public System.String fldTimeRange
        {
            get
            {
                return this.m_fldTimeRange;
            }
            set
            {
                this.m_fldTimeRange = value;
            }
        }

        public System.String fldItemGroup
        {
            get
            {
                return this.m_fldItemGroup;
            }
            set
            {
                this.m_fldItemGroup = value;
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

        public System.String fldPointGroup
        {
            get
            {
                return this.m_fldPointGroup;
            }
            set
            {
                this.m_fldPointGroup = value;
            }
        }

        public System.String fldPointCode
        {
            get
            {
                return this.m_fldPointCode;
            }
            set
            {
                this.m_fldPointCode = value;
            }
        }

        public System.String fldSource
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

        public System.String fldDataType
        {
            get
            {
                return this.m_fldDataType;
            }
            set
            {
                this.m_fldDataType = value;
            }
        }

        public System.String fldSampleType
        {
            get
            {
                return this.m_fldSampleType;
            }
            set
            {
                this.m_fldSampleType = value;
            }
        }

    }
}