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

	public class usp_EQIW_R_HourData_Auto_ohd : BaseProcedure
	{
		private SqlParameter parametervwTableName;

		private SqlParameter parameterstrsear;

		public usp_EQIW_R_HourData_Auto_ohd()
		{
			base.InitCommand("usp_EQIW_R_HourData_Auto_ohd");
			ConfigParameter();
		}

		public System.String vwTableName
		{
			get
			{
				return (System.String)this.parametervwTableName.Value;
			}
			set
			{
				this.parametervwTableName.Value=value;
			}
		}

		public System.String strsear
		{
			get
			{
				return (System.String)this.parameterstrsear.Value;
			}
			set
			{
				this.parameterstrsear.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parametervwTableName=new SqlParameter();
			this.parametervwTableName.ParameterName="@vwTableName";
			this.parametervwTableName.SqlDbType=SqlDbType.VarChar;
			this.parametervwTableName.Size=50;
			this.parametervwTableName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parametervwTableName);
			//--------------------------------------------------------
			this.parameterstrsear=new SqlParameter();
			this.parameterstrsear.ParameterName="@strsear";
			this.parameterstrsear.SqlDbType=SqlDbType.VarChar;
			this.parameterstrsear.Size=-1;
			this.parameterstrsear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrsear);
		}
	}
}
