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
	public class tblDictionary : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldName;

		private System.String m_fldKey;

		private System.Int32 m_fldParentID;

		public tblDictionary()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// ����ʵ���������
		/// </summary>
		/// <returns></returns>
		public tblDictionary Clone()
		{
			tblDictionary objNew = (tblDictionary)this.MemberwiseClone();
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

		public System.String fldKey
		{
			get
			{
				return this.m_fldKey;
			}
			set
			{
				this.m_fldKey=value;
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

	}
}