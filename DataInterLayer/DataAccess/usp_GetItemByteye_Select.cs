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

	public class usp_GetItemByteye_Select : BaseProcedure
	{
		private SqlParameter parameterfldtype;

		public usp_GetItemByteye_Select()
		{
			base.InitCommand("usp_GetItemByteye_Select");
			ConfigParameter();
		}

		public System.String fldtype
		{
			get
			{
				return (System.String)this.parameterfldtype.Value;
			}
			set
			{
				this.parameterfldtype.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldtype=new SqlParameter();
			this.parameterfldtype.ParameterName="@fldtype";
			this.parameterfldtype.SqlDbType=SqlDbType.VarChar;
			this.parameterfldtype.Size=100;
			this.parameterfldtype.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldtype);
		}
	}
}