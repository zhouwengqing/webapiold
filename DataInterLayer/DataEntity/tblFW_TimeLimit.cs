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
    public class tblFW_TimeLimit : BaseDataEntity
    {
        [AttributePK]
        private System.Int32 m_fldAutoID;

        private System.Int32 m_fldCityID;

        private System.String m_fldModalType;

        private System.String m_fldModal;

        private System.Int32 m_fldTimeType;

        private System.Int32 m_fldTimeNum;

        private System.Int32 m_fldInAdvance;

        private System.Byte m_fldFinish;

        private System.DateTime m_fldDateline;

        public tblFW_TimeLimit()
        {
            base.InitMetaData();
        }

        /// <summary>
        /// 复制实体类的内容
        /// </summary>
        /// <returns></returns>
        public tblFW_TimeLimit Clone()
        {
            tblFW_TimeLimit objNew = (tblFW_TimeLimit)this.MemberwiseClone();
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

        public System.Int32 fldCityID
        {
            get
            {
                return this.m_fldCityID;
            }
            set
            {
                this.m_fldCityID = value;
            }
        }

        public System.String fldModalType
        {
            get
            {
                return this.m_fldModalType;
            }
            set
            {
                this.m_fldModalType = value;
            }
        }

        public System.String fldModal
        {
            get
            {
                return this.m_fldModal;
            }
            set
            {
                this.m_fldModal = value;
            }
        }

        public System.Int32 fldTimeType
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

        public System.Int32 fldTimeNum
        {
            get
            {
                return this.m_fldTimeNum;
            }
            set
            {
                this.m_fldTimeNum = value;
            }
        }

        public System.Int32 fldInAdvance
        {
            get
            {
                return this.m_fldInAdvance;
            }
            set
            {
                this.m_fldInAdvance = value;
            }
        }

        public System.Byte fldFinish
        {
            get
            {
                return this.m_fldFinish;
            }
            set
            {
                this.m_fldFinish = value;
            }
        }

        public System.DateTime fldDateline
        {
            get
            {
                return this.m_fldDateline;
            }
            set
            {
                this.m_fldDateline = value;
            }
        }

    }
}
