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
	public class tblFW_PointCorresp : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.Int16 m_fldObjType;

		private System.String m_fldPCode;

		private System.String m_fldYPCode;

		private System.String m_fldYPName;

		public tblFW_PointCorresp()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// 复制实体类的内容
		/// </summary>
		/// <returns></returns>
		public tblFW_PointCorresp Clone()
		{
			tblFW_PointCorresp objNew = (tblFW_PointCorresp)this.MemberwiseClone();
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

		public System.Int16 fldObjType
		{
			get
			{
				return this.m_fldObjType;
			}
			set
			{
				this.m_fldObjType=value;
			}
		}

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

		public System.String fldYPCode
		{
			get
			{
				return this.m_fldYPCode;
			}
			set
			{
				this.m_fldYPCode=value;
			}
		}

		public System.String fldYPName
		{
			get
			{
				return this.m_fldYPName;
			}
			set
			{
				this.m_fldYPName=value;
			}
		}

	}
}
