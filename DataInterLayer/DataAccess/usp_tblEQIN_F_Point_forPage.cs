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

	public class usp_tblEQIN_F_Point_forPage : BaseProcedure
	{
		private SqlParameter parameterfldYear;

		private SqlParameter parameterStcode;

		private SqlParameter parameterType;

		public usp_tblEQIN_F_Point_forPage()
		{
			base.InitCommand("usp_tblEQIN_F_Point_forPage");
			ConfigParameter();
		}

		public System.Int32 fldYear
		{
			get
			{
				return (System.Int32)this.parameterfldYear.Value;
			}
			set
			{
				this.parameterfldYear.Value=value;
			}
		}

		public System.String Stcode
		{
			get
			{
				return (System.String)this.parameterStcode.Value;
			}
			set
			{
				this.parameterStcode.Value=value;
			}
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
			this.parameterfldYear=new SqlParameter();
			this.parameterfldYear.ParameterName="@fldYear";
			this.parameterfldYear.SqlDbType=SqlDbType.Int;
			this.parameterfldYear.Size=4;
			this.parameterfldYear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldYear);
			//--------------------------------------------------------
			this.parameterStcode=new SqlParameter();
			this.parameterStcode.ParameterName="@Stcode";
			this.parameterStcode.SqlDbType=SqlDbType.VarChar;
			this.parameterStcode.Size=10;
			this.parameterStcode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterStcode);
			//--------------------------------------------------------
			this.parameterType=new SqlParameter();
			this.parameterType.ParameterName="@Type";
			this.parameterType.SqlDbType=SqlDbType.VarChar;
			this.parameterType.Size=10;
			this.parameterType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterType);
		}
	}
}
