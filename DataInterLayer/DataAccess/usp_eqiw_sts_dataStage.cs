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

	public class usp_eqiw_sts_dataStage : BaseProcedure
	{
		private SqlParameter parameterbdate;

		private SqlParameter parameteredate;

		private SqlParameter parameterrscode;

		private SqlParameter parameteritemcode;

		private SqlParameter parameterfldstandardname;

		private SqlParameter parameterfldLevel;

		public usp_eqiw_sts_dataStage()
		{
			base.InitCommand("usp_eqiw_sts_dataStage");
			ConfigParameter();
		}

		public System.DateTime bdate
		{
			get
			{
				return (System.DateTime)this.parameterbdate.Value;
			}
			set
			{
				this.parameterbdate.Value=value;
			}
		}

		public System.DateTime edate
		{
			get
			{
				return (System.DateTime)this.parameteredate.Value;
			}
			set
			{
				this.parameteredate.Value=value;
			}
		}

		public System.String rscode
		{
			get
			{
				return (System.String)this.parameterrscode.Value;
			}
			set
			{
				this.parameterrscode.Value=value;
			}
		}

		public System.String itemcode
		{
			get
			{
				return (System.String)this.parameteritemcode.Value;
			}
			set
			{
				this.parameteritemcode.Value=value;
			}
		}

		public System.String fldstandardname
		{
			get
			{
				return (System.String)this.parameterfldstandardname.Value;
			}
			set
			{
				this.parameterfldstandardname.Value=value;
			}
		}

		public System.Int16 fldLevel
		{
			get
			{
				return (System.Int16)this.parameterfldLevel.Value;
			}
			set
			{
				this.parameterfldLevel.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterbdate=new SqlParameter();
			this.parameterbdate.ParameterName="@bdate";
			this.parameterbdate.SqlDbType=SqlDbType.DateTime;
			this.parameterbdate.Size=8;
			this.parameterbdate.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterbdate);
			//--------------------------------------------------------
			this.parameteredate=new SqlParameter();
			this.parameteredate.ParameterName="@edate";
			this.parameteredate.SqlDbType=SqlDbType.DateTime;
			this.parameteredate.Size=8;
			this.parameteredate.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameteredate);
			//--------------------------------------------------------
			this.parameterrscode=new SqlParameter();
			this.parameterrscode.ParameterName="@rscode";
			this.parameterrscode.SqlDbType=SqlDbType.VarChar;
			this.parameterrscode.Size=-1;
			this.parameterrscode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterrscode);
			//--------------------------------------------------------
			this.parameteritemcode=new SqlParameter();
			this.parameteritemcode.ParameterName="@itemcode";
			this.parameteritemcode.SqlDbType=SqlDbType.VarChar;
			this.parameteritemcode.Size=-1;
			this.parameteritemcode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameteritemcode);
			//--------------------------------------------------------
			this.parameterfldstandardname=new SqlParameter();
			this.parameterfldstandardname.ParameterName="@fldstandardname";
			this.parameterfldstandardname.SqlDbType=SqlDbType.VarChar;
			this.parameterfldstandardname.Size=50;
			this.parameterfldstandardname.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldstandardname);
			//--------------------------------------------------------
			this.parameterfldLevel=new SqlParameter();
			this.parameterfldLevel.ParameterName="@fldLevel";
			this.parameterfldLevel.SqlDbType=SqlDbType.SmallInt;
			this.parameterfldLevel.Size=2;
			this.parameterfldLevel.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldLevel);
		}
	}
}