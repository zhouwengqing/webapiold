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

	public class usp_tblEQIW_G_Section_GetRCodeBySTCode : BaseProcedure
	{
		private SqlParameter parameterfldSTCode;

		private SqlParameter parameteryear;

		private SqlParameter parameterLevel;

		private SqlParameter parameterinclude;

		public usp_tblEQIW_G_Section_GetRCodeBySTCode()
		{
			base.InitCommand("usp_tblEQIW_G_Section_GetRCodeBySTCode");
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

		public System.String year
		{
			get
			{
				return (System.String)this.parameteryear.Value;
			}
			set
			{
				this.parameteryear.Value=value;
			}
		}

		public System.Int32 Level
		{
			get
			{
				return (System.Int32)this.parameterLevel.Value;
			}
			set
			{
				this.parameterLevel.Value=value;
			}
		}

		public System.Int32 include
		{
			get
			{
				return (System.Int32)this.parameterinclude.Value;
			}
			set
			{
				this.parameterinclude.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=12;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
			//--------------------------------------------------------
			this.parameteryear=new SqlParameter();
			this.parameteryear.ParameterName="@year";
			this.parameteryear.SqlDbType=SqlDbType.VarChar;
			this.parameteryear.Size=4;
			this.parameteryear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameteryear);
			//--------------------------------------------------------
			this.parameterLevel=new SqlParameter();
			this.parameterLevel.ParameterName="@Level";
			this.parameterLevel.SqlDbType=SqlDbType.Int;
			this.parameterLevel.Size=4;
			this.parameterLevel.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterLevel);
			//--------------------------------------------------------
			this.parameterinclude=new SqlParameter();
			this.parameterinclude.ParameterName="@include";
			this.parameterinclude.SqlDbType=SqlDbType.Int;
			this.parameterinclude.Size=4;
			this.parameterinclude.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterinclude);
		}
	}
}