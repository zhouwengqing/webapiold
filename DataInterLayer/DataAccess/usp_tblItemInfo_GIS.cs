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

	public class usp_tblItemInfo_GIS : BaseProcedure
	{
		private SqlParameter parameterType;

		public usp_tblItemInfo_GIS()
		{
			base.InitCommand("usp_tblItemInfo_GIS");
			ConfigParameter();
		}

		public System.String Type
		{
			get
			{
				return (System.String)this.parameterType.Value;
			}
			set
			{
				this.parameterType.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterType=new SqlParameter();
			this.parameterType.ParameterName="@Type";
			this.parameterType.SqlDbType=SqlDbType.VarChar;
			this.parameterType.Size=30;
			this.parameterType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterType);
		}
	}
}
