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

	public class usp_tblEQIW_R_Basedata_GetTrendStageOrDensity_Page : BaseProcedure
	{
		private SqlParameter parameterfldSTCode;

		private SqlParameter parameterIDay;

		private SqlParameter parameterfldRScode;

		public usp_tblEQIW_R_Basedata_GetTrendStageOrDensity_Page()
		{
			base.InitCommand("usp_tblEQIW_R_Basedata_GetTrendStageOrDensity_Page");
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

		public System.Int32 IDay
		{
			get
			{
				return (System.Int32)this.parameterIDay.Value;
			}
			set
			{
				this.parameterIDay.Value=value;
			}
		}

		public System.String fldRScode
		{
			get
			{
				return (System.String)this.parameterfldRScode.Value;
			}
			set
			{
				this.parameterfldRScode.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=10;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
			//--------------------------------------------------------
			this.parameterIDay=new SqlParameter();
			this.parameterIDay.ParameterName="@IDay";
			this.parameterIDay.SqlDbType=SqlDbType.Int;
			this.parameterIDay.Size=4;
			this.parameterIDay.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterIDay);
			//--------------------------------------------------------
			this.parameterfldRScode=new SqlParameter();
			this.parameterfldRScode.ParameterName="@fldRScode";
			this.parameterfldRScode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRScode.Size=20;
			this.parameterfldRScode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRScode);
		}
	}
}
