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
	public class tblFW_ItemCorresp : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.Int16 m_fldObjType;

		private System.String m_fldGBCode;

		private System.String m_fldDBCode;

		private System.String m_fldOldItemName;

        private System.String m_fldVocsType;

        private System.Int16 m_fldSort;

		public tblFW_ItemCorresp()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// 复制实体类的内容
		/// </summary>
		/// <returns></returns>
		public tblFW_ItemCorresp Clone()
		{
			tblFW_ItemCorresp objNew = (tblFW_ItemCorresp)this.MemberwiseClone();
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

		public System.String fldGBCode
		{
			get
			{
				return this.m_fldGBCode;
			}
			set
			{
				this.m_fldGBCode=value;
			}
		}

		public System.String fldDBCode
		{
			get
			{
				return this.m_fldDBCode;
			}
			set
			{
				this.m_fldDBCode=value;
			}
		}

		public System.String fldOldItemName
		{
			get
			{
				return this.m_fldOldItemName;
			}
			set
			{
				this.m_fldOldItemName=value;
			}
        }

        public System.String fldVocsType
        {
            get
            {
                return this.m_fldVocsType;
            }
            set
            {
                this.m_fldVocsType = value;
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
                this.m_fldSort = value;
            }
        }

	}
}
