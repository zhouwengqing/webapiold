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
	public class tblEQISO_ItemSTD : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldEdition;

		private System.String m_fldItemCode;

		private System.Int16 m_fldSampleType;

		private System.Decimal m_fldST10;

		private System.Decimal m_fldST30;

		private System.Decimal m_fldST23;

		private System.Decimal m_fldST22;

		private System.Decimal m_fldST21;

		public tblEQISO_ItemSTD()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// ����ʵ���������
		/// </summary>
		/// <returns></returns>
		public tblEQISO_ItemSTD Clone()
		{
			tblEQISO_ItemSTD objNew = (tblEQISO_ItemSTD)this.MemberwiseClone();
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
				this.m_fldAutoID=value;
			}
		}

		public System.String fldEdition
		{
			get
			{
				return this.m_fldEdition;
			}
			set
			{
				this.m_fldEdition=value;
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
				this.m_fldItemCode=value;
			}
		}

		public System.Int16 fldSampleType
		{
			get
			{
				return this.m_fldSampleType;
			}
			set
			{
				this.m_fldSampleType=value;
			}
		}

		public System.Decimal fldST10
		{
			get
			{
				return this.m_fldST10;
			}
			set
			{
				this.m_fldST10=value;
			}
		}

		public System.Decimal fldST30
		{
			get
			{
				return this.m_fldST30;
			}
			set
			{
				this.m_fldST30=value;
			}
		}

		public System.Decimal fldST23
		{
			get
			{
				return this.m_fldST23;
			}
			set
			{
				this.m_fldST23=value;
			}
		}

		public System.Decimal fldST22
		{
			get
			{
				return this.m_fldST22;
			}
			set
			{
				this.m_fldST22=value;
			}
		}

		public System.Decimal fldST21
		{
			get
			{
				return this.m_fldST21;
			}
			set
			{
				this.m_fldST21=value;
			}
		}

	}
}