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

	public class usp_EQIN_T_Auditing : BaseProcedure
	{
		private SqlParameter parametervwTableName;

		private SqlParameter parameterisItemBaseData;

		private SqlParameter parameterstrWhere;

		public usp_EQIN_T_Auditing()
		{
			base.InitCommand("usp_EQIN_T_Auditing");
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

		public System.Int32 isItemBaseData
		{
			get
			{
				return (System.Int32)this.parameterisItemBaseData.Value;
			}
			set
			{
				this.parameterisItemBaseData.Value=value;
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
			this.parametervwTableName=new SqlParameter();
			this.parametervwTableName.ParameterName="@vwTableName";
			this.parametervwTableName.SqlDbType=SqlDbType.VarChar;
			this.parametervwTableName.Size=50;
			this.parametervwTableName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parametervwTableName);
			//--------------------------------------------------------
			this.parameterisItemBaseData=new SqlParameter();
			this.parameterisItemBaseData.ParameterName="@isItemBaseData";
			this.parameterisItemBaseData.SqlDbType=SqlDbType.Int;
			this.parameterisItemBaseData.Size=4;
			this.parameterisItemBaseData.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterisItemBaseData);
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
