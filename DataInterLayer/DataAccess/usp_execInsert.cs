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

	public class usp_execInsert : BaseProcedure
	{
		private SqlParameter parameterinsertsql;

		public usp_execInsert()
		{
			base.InitCommand("usp_execInsert");
			ConfigParameter();
		}

		public System.String insertsql
		{
			get
			{
				return (System.String)this.parameterinsertsql.Value;
			}
			set
			{
				this.parameterinsertsql.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterinsertsql=new SqlParameter();
			this.parameterinsertsql.ParameterName="@insertsql";
			this.parameterinsertsql.SqlDbType=SqlDbType.VarChar;
			this.parameterinsertsql.Size=-1;
			this.parameterinsertsql.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterinsertsql);
		}
	}
}