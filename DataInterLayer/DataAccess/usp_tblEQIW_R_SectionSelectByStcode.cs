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

	public class usp_tblEQIW_R_SectionSelectByStcode : BaseProcedure
	{
		private SqlParameter parameterfldyear;

		private SqlParameter parameterfldstcode;

		private SqlParameter parameterfldtype;

		public usp_tblEQIW_R_SectionSelectByStcode()
		{
			base.InitCommand("usp_tblEQIW_R_SectionSelectByStcode");
			ConfigParameter();
		}

		public System.String fldyear
		{
			get
			{
				return (System.String)this.parameterfldyear.Value;
			}
			set
			{
				this.parameterfldyear.Value=value;
			}
		}

		public System.String fldstcode
		{
			get
			{
				return (System.String)this.parameterfldstcode.Value;
			}
			set
			{
				this.parameterfldstcode.Value=value;
			}
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
			this.parameterfldyear=new SqlParameter();
			this.parameterfldyear.ParameterName="@fldyear";
			this.parameterfldyear.SqlDbType=SqlDbType.NVarChar;
			this.parameterfldyear.Size=8;
			this.parameterfldyear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldyear);
			//--------------------------------------------------------
			this.parameterfldstcode=new SqlParameter();
			this.parameterfldstcode.ParameterName="@fldstcode";
			this.parameterfldstcode.SqlDbType=SqlDbType.NVarChar;
			this.parameterfldstcode.Size=20;
			this.parameterfldstcode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldstcode);
			//--------------------------------------------------------
			this.parameterfldtype=new SqlParameter();
			this.parameterfldtype.ParameterName="@fldtype";
			this.parameterfldtype.SqlDbType=SqlDbType.NVarChar;
			this.parameterfldtype.Size=20;
			this.parameterfldtype.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldtype);
		}
	}
}
