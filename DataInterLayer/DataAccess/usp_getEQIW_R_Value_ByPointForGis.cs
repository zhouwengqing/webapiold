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

	public class usp_getEQIW_R_Value_ByPointForGis : BaseProcedure
	{
		private SqlParameter parameterfldPcode;

		public usp_getEQIW_R_Value_ByPointForGis()
		{
			base.InitCommand("usp_getEQIW_R_Value_ByPointForGis");
			ConfigParameter();
		}

		public System.String fldPcode
		{
			get
			{
				return (System.String)this.parameterfldPcode.Value;
			}
			set
			{
				this.parameterfldPcode.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldPcode=new SqlParameter();
			this.parameterfldPcode.ParameterName="@fldPcode";
			this.parameterfldPcode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldPcode.Size=12;
			this.parameterfldPcode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldPcode);
		}
	}
}
