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
	public class tblEQID_D_Point : BaseDataEntity
	{
		[AttributePK]
		private System.Int32 m_fldAutoID;

		private System.String m_fldSTCode;

		private System.String m_fldSTName;

		private System.Decimal m_fldYear;

		private System.String m_fldPCode;

		private System.String m_fldPName;

		private System.String m_fldLOD;

		private System.String m_fldLOM;

		private System.String m_fldLOS;

		private System.String m_fldLAD;

		private System.String m_fldLAM;

		private System.String m_fldLAS;

		private System.String m_fldAdminType;

		private System.String m_fldAttribute;

		private System.String m_fldManagedStation;

		private System.String m_fldPicPath;

		private System.String m_fldOperators;

		private System.String m_fldVideoPath;

		private System.Int32 m_fldSort;

		public tblEQID_D_Point()
		{
			base.InitMetaData();
		}

		/// <summary>
		/// ����ʵ���������
		/// </summary>
		/// <returns></returns>
		public tblEQID_D_Point Clone()
		{
			tblEQID_D_Point objNew = (tblEQID_D_Point)this.MemberwiseClone();
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

		public System.String fldLOD
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

		public System.String fldLOM
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

		public System.String fldLOS
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

		public System.String fldLAD
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

		public System.String fldLAM
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

		public System.String fldLAS
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

		public System.String fldAdminType
		{
			get
			{
				return this.m_fldAdminType;
			}
			set
			{
				this.m_fldAdminType=value;
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

		public System.String fldManagedStation
		{
			get
			{
				return this.m_fldManagedStation;
			}
			set
			{
				this.m_fldManagedStation=value;
			}
		}

		public System.String fldPicPath
		{
			get
			{
				return this.m_fldPicPath;
			}
			set
			{
				this.m_fldPicPath=value;
			}
		}

		public System.String fldOperators
		{
			get
			{
				return this.m_fldOperators;
			}
			set
			{
				this.m_fldOperators=value;
			}
		}

		public System.String fldVideoPath
		{
			get
			{
				return this.m_fldVideoPath;
			}
			set
			{
				this.m_fldVideoPath=value;
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