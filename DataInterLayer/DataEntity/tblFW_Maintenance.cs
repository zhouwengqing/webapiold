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
	public class tblFW_Maintenance : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldName;

		private System.Int16 m_fldFlag;

		private System.String m_fldTableName;

		private System.Int32 m_fldParentID;

		private System.Int16 m_fldSort;

		private System.Int16 m_fldLevel;

		private System.Boolean m_fldEnableEdit;

		private System.String m_fldDefaultSortFld;

		private System.Boolean m_fldCommonTable;

		public tblFW_Maintenance()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// 复制实体类的内容
		/// </summary>
		/// <returns></returns>
		public tblFW_Maintenance Clone()
		{
			tblFW_Maintenance objNew = (tblFW_Maintenance)this.MemberwiseClone();
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

		public System.String fldName
		{
			get
			{
				return this.m_fldName;
			}
			set
			{
				this.m_fldName=value;
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
				this.m_fldFlag=value;
			}
		}

		public System.String fldTableName
		{
			get
			{
				return this.m_fldTableName;
			}
			set
			{
				this.m_fldTableName=value;
			}
		}

		public System.Int32 fldParentID
		{
			get
			{
				return this.m_fldParentID;
			}
			set
			{
				this.m_fldParentID=value;
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

		public System.Int16 fldLevel
		{
			get
			{
				return this.m_fldLevel;
			}
			set
			{
				this.m_fldLevel=value;
			}
		}

		public System.Boolean fldEnableEdit
		{
			get
			{
				return this.m_fldEnableEdit;
			}
			set
			{
				this.m_fldEnableEdit=value;
			}
		}

		public System.String fldDefaultSortFld
		{
			get
			{
				return this.m_fldDefaultSortFld;
			}
			set
			{
				this.m_fldDefaultSortFld=value;
			}
		}

		public System.Boolean fldCommonTable
		{
			get
			{
				return this.m_fldCommonTable;
			}
			set
			{
				this.m_fldCommonTable=value;
			}
		}

	}
}
