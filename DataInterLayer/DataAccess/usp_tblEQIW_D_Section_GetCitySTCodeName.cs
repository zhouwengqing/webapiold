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

	public class usp_tblEQIW_D_Section_GetCitySTCodeName : BaseProcedure
	{
		private SqlParameter parameterfldSTCode;

		private SqlParameter parameterfldRiver;

		private SqlParameter parameterfldYear;

		public usp_tblEQIW_D_Section_GetCitySTCodeName()
		{
			base.InitCommand("usp_tblEQIW_D_Section_GetCitySTCodeName");
			ConfigParameter();
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

		public System.String fldRiver
		{
			get
			{
				return (System.String)this.parameterfldRiver.Value;
			}
			set
			{
				this.parameterfldRiver.Value=value;
			}
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

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=30;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
			//--------------------------------------------------------
			this.parameterfldRiver=new SqlParameter();
			this.parameterfldRiver.ParameterName="@fldRiver";
			this.parameterfldRiver.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRiver.Size=6;
			this.parameterfldRiver.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRiver);
			//--------------------------------------------------------
			this.parameterfldYear=new SqlParameter();
			this.parameterfldYear.ParameterName="@fldYear";
			this.parameterfldYear.SqlDbType=SqlDbType.Int;
			this.parameterfldYear.Size=4;
			this.parameterfldYear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldYear);
		}
	}
}
