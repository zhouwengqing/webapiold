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
    public class tblEQIA_RD_Point : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldSTCode;

		private System.String m_fldSTName;

		private System.Decimal m_fldYear;

		private System.String m_fldPCode;

		private System.String m_fldPName;

		private System.Int16 m_fldPLevel;

		private System.String m_fldAttribute;

		private System.Int32 m_fldSort;

		public tblEQIA_RD_Point()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// 复制实体类的内容
		/// </summary>
		/// <returns></returns>
		public tblEQIA_RD_Point Clone()
		{
			tblEQIA_RD_Point objNew = (tblEQIA_RD_Point)this.MemberwiseClone();
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
        [JsonProperty]
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
        [JsonProperty]
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
