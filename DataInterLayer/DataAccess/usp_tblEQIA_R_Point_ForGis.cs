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

	public class usp_tblEQIA_R_Point_ForGis : BaseProcedure
	{
		private SqlParameter parameterfldType;

		public usp_tblEQIA_R_Point_ForGis()
		{
			base.InitCommand("usp_tblEQIA_R_Point_ForGis");
			ConfigParameter();
		}

		public System.String fldType
		{
			get
			{
				return (System.String)this.parameterfldType.Value;
			}
			set
			{
				this.parameterfldType.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldType=new SqlParameter();
			this.parameterfldType.ParameterName="@fldType";
			this.parameterfldType.SqlDbType=SqlDbType.VarChar;
			this.parameterfldType.Size=20;
			this.parameterfldType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldType);
		}
	}
}