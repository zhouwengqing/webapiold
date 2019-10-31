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
	public class tblEQIS_D_Item : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldItemCode;

		private System.String m_fldItemName;

		private System.String m_fldCharCode;

		private System.String m_fldChineseCode;

		private System.String m_fldUnit;

		private System.Decimal m_fldInt;

		private System.Decimal m_fldDec;

		private System.Decimal m_fldMinValue;

		private System.Decimal m_fldMaxValue;

		private System.String m_fldAnalyseWay;

		private System.Decimal m_fldSense;

		private System.Boolean m_fldRender;

		private System.Int16 m_fldSort;

		public tblEQIS_D_Item()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// 复制实体类的内容
		/// </summary>
		/// <returns></returns>
		public tblEQIS_D_Item Clone()
		{
			tblEQIS_D_Item objNew = (tblEQIS_D_Item)this.MemberwiseClone();
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

		public System.String fldItemName
		{
			get
			{
				return this.m_fldItemName;
			}
			set
			{
				this.m_fldItemName=value;
			}
		}

		public System.String fldCharCode
		{
			get
			{
				return this.m_fldCharCode;
			}
			set
			{
				this.m_fldCharCode=value;
			}
		}

		public System.String fldChineseCode
		{
			get
			{
				return this.m_fldChineseCode;
			}
			set
			{
				this.m_fldChineseCode=value;
			}
		}

		public System.String fldUnit
		{
			get
			{
				return this.m_fldUnit;
			}
			set
			{
				this.m_fldUnit=value;
			}
		}

		public System.Decimal fldInt
		{
			get
			{
				return this.m_fldInt;
			}
			set
			{
				this.m_fldInt=value;
			}
		}

		public System.Decimal fldDec
		{
			get
			{
				return this.m_fldDec;
			}
			set
			{
				this.m_fldDec=value;
			}
		}

		public System.Decimal fldMinValue
		{
			get
			{
				return this.m_fldMinValue;
			}
			set
			{
				this.m_fldMinValue=value;
			}
		}

		public System.Decimal fldMaxValue
		{
			get
			{
				return this.m_fldMaxValue;
			}
			set
			{
				this.m_fldMaxValue=value;
			}
		}

		public System.String fldAnalyseWay
		{
			get
			{
				return this.m_fldAnalyseWay;
			}
			set
			{
				this.m_fldAnalyseWay=value;
			}
		}

		public System.Decimal fldSense
		{
			get
			{
				return this.m_fldSense;
			}
			set
			{
				this.m_fldSense=value;
			}
		}

		public System.Boolean fldRender
		{
			get
			{
				return this.m_fldRender;
			}
			set
			{
				this.m_fldRender=value;
			}
		}

		public System.Int16 fldSort
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
