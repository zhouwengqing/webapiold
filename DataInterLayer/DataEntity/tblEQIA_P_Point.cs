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
    using Newtonsoft.Json;

    [Serializable]
    [JsonObject(MemberSerialization.OptIn)]
    public class tblEQIA_P_Point : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldSTCode;

		private System.String m_fldSTName;

		private System.Decimal m_fldYear;

		private System.String m_fldPCode;

		private System.String m_fldPName;

		private System.Int16 m_fldPLevel;

		private System.String m_fldDisc;

		private System.String m_fldLName;

		private System.String m_fldLCode;

		private System.Int16 m_fldRLevel;

		private System.Int16 m_fldAcidP;

		private System.Int16 m_fldSO2Level;

		private System.Int16 m_fldAcidLevel;

		private System.Decimal m_fldLOD;

		private System.Decimal m_fldLOM;

		private System.Decimal m_fldLOS;

		private System.Decimal m_fldLAD;

		private System.Decimal m_fldLAM;

		private System.Decimal m_fldLAS;

		private System.String m_fldAttribute;

		private System.Int32 m_fldSort;

		public tblEQIA_P_Point()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// 复制实体类的内容
		/// </summary>
		/// <returns></returns>
		public tblEQIA_P_Point Clone()
		{
			tblEQIA_P_Point objNew = (tblEQIA_P_Point)this.MemberwiseClone();
			return objNew;
		}

        [JsonProperty]
        public System.Int32 fldAutoID
		{
			get
			{
				return this.m_fldAutoID;
			}
			set
			{
				this.m_fldAutoID=value;
			}
		}

        [JsonProperty]
        public System.String fldSTCode
		{
			get
			{
				return this.m_fldSTCode;
			}
			set
			{
				this.m_fldSTCode=value;
			}
		}

        [JsonProperty]
        public System.String fldSTName
		{
			get
			{
				return this.m_fldSTName;
			}
			set
			{
				this.m_fldSTName=value;
			}
		}

        [JsonProperty]
        public System.Decimal fldYear
		{
			get
			{
				return this.m_fldYear;
			}
			set
			{
				this.m_fldYear=value;
			}
		}

        [JsonProperty]
        public System.String fldPCode
		{
			get
			{
				return this.m_fldPCode;
			}
			set
			{
				this.m_fldPCode=value;
			}
		}

        [JsonProperty]
        public System.String fldPName
		{
			get
			{
				return this.m_fldPName;
			}
			set
			{
				this.m_fldPName=value;
			}
		}

        [JsonProperty]
        public System.Int16 fldPLevel
		{
			get
			{
				return this.m_fldPLevel;
			}
			set
			{
				this.m_fldPLevel=value;
			}
		}

		public System.String fldDisc
		{
			get
			{
				return this.m_fldDisc;
			}
			set
			{
				this.m_fldDisc=value;
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
				this.m_fldLName=value;
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
				this.m_fldLCode=value;
			}
		}

		public System.Int16 fldRLevel
		{
			get
			{
				return this.m_fldRLevel;
			}
			set
			{
				this.m_fldRLevel=value;
			}
		}

		public System.Int16 fldAcidP
		{
			get
			{
				return this.m_fldAcidP;
			}
			set
			{
				this.m_fldAcidP=value;
			}
		}

		public System.Int16 fldSO2Level
		{
			get
			{
				return this.m_fldSO2Level;
			}
			set
			{
				this.m_fldSO2Level=value;
			}
		}

		public System.Int16 fldAcidLevel
		{
			get
			{
				return this.m_fldAcidLevel;
			}
			set
			{
				this.m_fldAcidLevel=value;
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
				this.m_fldLOD=value;
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
				this.m_fldLOM=value;
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
				this.m_fldLOS=value;
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
				this.m_fldLAD=value;
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
				this.m_fldLAM=value;
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
				this.m_fldLAS=value;
			}
		}

		public System.String fldAttribute
		{
			get
			{
				return this.m_fldAttribute;
			}
			set
			{
				this.m_fldAttribute=value;
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
				this.m_fldSort=value;
			}
		}

	}
}
