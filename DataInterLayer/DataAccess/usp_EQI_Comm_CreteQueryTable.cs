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

	public class usp_EQI_Comm_CreteQueryTable : BaseProcedure
	{
		private SqlParameter parametertype;

		private SqlParameter parametervwTableName;

		private SqlParameter parameterstrWhere;

		public usp_EQI_Comm_CreteQueryTable()
		{
			base.InitCommand("usp_EQI_Comm_CreteQueryTable");
			ConfigParameter();
		}

		public System.String type
		{
			get
			{
				return (System.String)this.parametertype.Value;
			}
			set
			{
				this.parametertype.Value=value;
			}
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

		public System.String strWhere
		{
			get
			{
				return (System.String)this.parameterstrWhere.Value;
			}
			set
			{
				this.parameterstrWhere.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parametertype=new SqlParameter();
			this.parametertype.ParameterName="@type";
			this.parametertype.SqlDbType=SqlDbType.VarChar;
			this.parametertype.Size=50;
			this.parametertype.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parametertype);
			//--------------------------------------------------------
			this.parametervwTableName=new SqlParameter();
			this.parametervwTableName.ParameterName="@vwTableName";
			this.parametervwTableName.SqlDbType=SqlDbType.VarChar;
			this.parametervwTableName.Size=50;
			this.parametervwTableName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parametervwTableName);
			//--------------------------------------------------------
			this.parameterstrWhere=new SqlParameter();
			this.parameterstrWhere.ParameterName="@strWhere";
			this.parameterstrWhere.SqlDbType=SqlDbType.VarChar;
			this.parameterstrWhere.Size=-1;
			this.parameterstrWhere.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrWhere);
		}
	}
}
