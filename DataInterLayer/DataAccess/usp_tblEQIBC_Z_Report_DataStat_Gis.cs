//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: v2.0.50727
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace DDYZ.Ensis.DataSource.DataAccess
{
	using System;
	using System.Data;
	using System.Data.SqlClient;
	using System.Data.SqlTypes;
	using System.Xml;
	using System.Reflection;

	public class usp_tblEQIBC_Z_Report_DataStat_Gis : BaseProcedure
	{
		private SqlParameter parameterfldYear;

		private SqlParameter parameterfldPhase;

		private SqlParameter parameterfldSTCode;

		private SqlParameter parameterfldRSCode;

		private SqlParameter parameterfldStatType;

		private SqlParameter parameterfldSpaceID;

		private SqlParameter parameterTableID;

		public usp_tblEQIBC_Z_Report_DataStat_Gis()
		{
			base.InitCommand("usp_tblEQIBC_Z_Report_DataStat_Gis");
			ConfigParameter();
		}

		public System.Int32 fldYear
		{
			get
			{
				return (System.Int32)this.parameterfldYear.Value;
			}
			set
			{
				this.parameterfldYear.Value=value;
			}
		}

		public System.Int32 fldPhase
		{
			get
			{
				return (System.Int32)this.parameterfldPhase.Value;
			}
			set
			{
				this.parameterfldPhase.Value=value;
			}
		}

		public System.String fldSTCode
		{
			get
			{
				return (System.String)this.parameterfldSTCode.Value;
			}
			set
			{
				this.parameterfldSTCode.Value=value;
			}
		}

		public System.String fldRSCode
		{
			get
			{
				return (System.String)this.parameterfldRSCode.Value;
			}
			set
			{
				this.parameterfldRSCode.Value=value;
			}
		}

		public System.Int32 fldStatType
		{
			get
			{
				return (System.Int32)this.parameterfldStatType.Value;
			}
			set
			{
				this.parameterfldStatType.Value=value;
			}
		}

		public System.Int32 fldSpaceID
		{
			get
			{
				return (System.Int32)this.parameterfldSpaceID.Value;
			}
			set
			{
				this.parameterfldSpaceID.Value=value;
			}
		}

		public System.Int16 TableID
		{
			get
			{
				return (System.Int16)this.parameterTableID.Value;
			}
			set
			{
				this.parameterTableID.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldYear=new SqlParameter();
			this.parameterfldYear.ParameterName="@fldYear";
			this.parameterfldYear.SqlDbType=SqlDbType.Int;
			this.parameterfldYear.Size=4;
			this.parameterfldYear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldYear);
			//--------------------------------------------------------
			this.parameterfldPhase=new SqlParameter();
			this.parameterfldPhase.ParameterName="@fldPhase";
			this.parameterfldPhase.SqlDbType=SqlDbType.Int;
			this.parameterfldPhase.Size=4;
			this.parameterfldPhase.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldPhase);
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=12;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
			//--------------------------------------------------------
			this.parameterfldRSCode=new SqlParameter();
			this.parameterfldRSCode.ParameterName="@fldRSCode";
			this.parameterfldRSCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRSCode.Size=20;
			this.parameterfldRSCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRSCode);
			//--------------------------------------------------------
			this.parameterfldStatType=new SqlParameter();
			this.parameterfldStatType.ParameterName="@fldStatType";
			this.parameterfldStatType.SqlDbType=SqlDbType.Int;
			this.parameterfldStatType.Size=4;
			this.parameterfldStatType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldStatType);
			//--------------------------------------------------------
			this.parameterfldSpaceID=new SqlParameter();
			this.parameterfldSpaceID.ParameterName="@fldSpaceID";
			this.parameterfldSpaceID.SqlDbType=SqlDbType.Int;
			this.parameterfldSpaceID.Size=4;
			this.parameterfldSpaceID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSpaceID);
			//--------------------------------------------------------
			this.parameterTableID=new SqlParameter();
			this.parameterTableID.ParameterName="@TableID";
			this.parameterTableID.SqlDbType=SqlDbType.SmallInt;
			this.parameterTableID.Size=2;
			this.parameterTableID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterTableID);
		}
	}
}
