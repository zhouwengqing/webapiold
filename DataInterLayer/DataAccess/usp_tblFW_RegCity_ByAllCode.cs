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

	public class usp_tblFW_RegCity_ByAllCode : BaseProcedure
	{
		private SqlParameter parameterfldSTCode;

		public usp_tblFW_RegCity_ByAllCode()
		{
			base.InitCommand("usp_tblFW_RegCity_ByAllCode");
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

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=20;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
		}
	}
}