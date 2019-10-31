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
    public class tblEQIW_DX_Section : BaseDataEntity
    {
        [AttributePK]
        private System.Int32 m_fldAutoID;

        private System.String m_fldSTCode;

        private System.String m_fldSTName;

        private System.Decimal m_fldYear;

        private System.String m_fldRCode;

        private System.String m_fldRName;

        private System.String m_fldRSCode;

        private System.String m_fldRSName;

        private System.String m_fldRSTown;

        private System.Int16 m_fldRSDWAF;

        private System.String m_fldRSWaterWork;

        private System.Int16 m_fldSCategory;

        private System.Int16 m_fldSType;

        private System.Int16 m_fldSLevel;

        private System.Decimal m_fldLOD;

        private System.Decimal m_fldLOM;

        private System.Decimal m_fldLOS;

        private System.Decimal m_fldLAD;

        private System.Decimal m_fldLAM;

        private System.Decimal m_fldLAS;

        private System.Boolean m_fldState;

        private System.Int32 m_fldSort;

        private System.String m_fldRiverBasin;

        public tblEQIW_DX_Section()
        {
            base.InitMetaData();
        }

        /// <summary>
        /// 复制实体类的内容
        /// </summary>
        /// <returns></returns>
        public tblEQIW_D_Section Clone()
        {
            tblEQIW_D_Section objNew = (tblEQIW_D_Section)this.MemberwiseClone();
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

        public System.String fldRName
        {
            get
            {
                return this.m_fldRName;
            }
            set
            {
                this.m_fldRName = value;
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

        public System.String fldRSName
        {
            get
            {
                return this.m_fldRSName;
            }
            set
            {
                this.m_fldRSName = value;
            }
        }

        public System.String fldRSTown
        {
            get
            {
                return this.m_fldRSTown;
            }
            set
            {
                this.m_fldRSTown = value;
            }
        }

        public System.Int16 fldRSDWAF
        {
            get
            {
                return this.m_fldRSDWAF;
            }
            set
            {
                this.m_fldRSDWAF = value;
            }
        }

        public System.String fldRSWaterWork
        {
            get
            {
                return this.m_fldRSWaterWork;
            }
            set
            {
                this.m_fldRSWaterWork = value;
            }
        }

        public System.Int16 fldSCategory
        {
            get
            {
                return this.m_fldSCategory;
            }
            set
            {
                this.m_fldSCategory = value;
            }
        }

        public System.Int16 fldSType
        {
            get
            {
                return this.m_fldSType;
            }
            set
            {
                this.m_fldSType = value;
            }
        }

        public System.Int16 fldSLevel
        {
            get
            {
                return this.m_fldSLevel;
            }
            set
            {
                this.m_fldSLevel = value;
            }
        }

        public System.Decimal fldLOD
        {
            get
            {
                return this.m_fldLOD;
            }
            set
            {
                this.m_fldLOD = value;
            }
        }

        public System.Decimal fldLOM
        {
            get
            {
                return this.m_fldLOM;
            }
            set
            {
                this.m_fldLOM = value;
            }
        }

        public System.Decimal fldLOS
        {
            get
            {
                return this.m_fldLOS;
            }
            set
            {
                this.m_fldLOS = value;
            }
        }

        public System.Decimal fldLAD
        {
            get
            {
                return this.m_fldLAD;
            }
            set
            {
                this.m_fldLAD = value;
            }
        }

        public System.Decimal fldLAM
        {
            get
            {
                return this.m_fldLAM;
            }
            set
            {
                this.m_fldLAM = value;
            }
        }

        public System.Decimal fldLAS
        {
            get
            {
                return this.m_fldLAS;
            }
            set
            {
                this.m_fldLAS = value;
            }
        }

        public System.Boolean fldState
        {
            get
            {
                return this.m_fldState;
            }
            set
            {
                this.m_fldState = value;
            }
        }

        public System.Int32 fldSort
        {
            get
            {
                return this.m_fldSort;
            }
            set
            {
                this.m_fldSort = value;
            }
        }

        public System.String fldRiverBasin
        {
            get
            {
                return this.m_fldRiverBasin;
            }
            set
            {
                this.m_fldRiverBasin = value;
            }
        }

    }
}
