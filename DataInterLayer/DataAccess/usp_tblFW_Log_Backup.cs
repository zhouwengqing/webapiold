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

	public class usp_tblFW_Log_Backup : BaseProcedure
	{
		private SqlParameter parameterfldDate_Start;

		private SqlParameter parameterfldDate_End;

		private SqlParameter parameterresult;

		public usp_tblFW_Log_Backup()
		{
			base.InitCommand("usp_tblFW_Log_Backup");
			ConfigParameter();
		}

		public System.DateTime fldDate_Start
		{
			get
			{
				return (System.DateTime)this.parameterfldDate_Start.Value;
			}
			set
			{
				this.parameterfldDate_Start.Value=value;
			}
		}

		public System.DateTime fldDate_End
		{
			get
			{
				return (System.DateTime)this.parameterfldDate_End.Value;
			}
			set
			{
				this.parameterfldDate_End.Value=value;
			}
		}

		public System.Boolean result
		{
			get
			{
				return (System.Boolean)this.parameterresult.Value;
			}
			set
			{
				this.parameterresult.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldDate_Start=new SqlParameter();
			this.parameterfldDate_Start.ParameterName="@fldDate_Start";
			this.parameterfldDate_Start.SqlDbType=SqlDbType.DateTime;
			this.parameterfldDate_Start.Size=8;
			this.parameterfldDate_Start.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldDate_Start);
			//--------------------------------------------------------
			this.parameterfldDate_End=new SqlParameter();
			this.parameterfldDate_End.ParameterName="@fldDate_End";
			this.parameterfldDate_End.SqlDbType=SqlDbType.DateTime;
			this.parameterfldDate_End.Size=8;
			this.parameterfldDate_End.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldDate_End);
			//--------------------------------------------------------
			this.parameterresult=new SqlParameter();
			this.parameterresult.ParameterName="@result";
			this.parameterresult.SqlDbType=SqlDbType.Bit;
			this.parameterresult.Size=1;
			this.parameterresult.Direction=ParameterDirection.InputOutput;
			base.m_cmd.Parameters.Add(this.parameterresult);
		}
	}
}