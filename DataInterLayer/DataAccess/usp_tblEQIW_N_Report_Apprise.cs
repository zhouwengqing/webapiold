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

	public class usp_tblEQIW_N_Report_Apprise : BaseProcedure
	{
		private SqlParameter parameterTimeType;

		private SqlParameter parameterBeginDate;

		private SqlParameter parameterEndDate;

		private SqlParameter parameterfldRSC;

		private SqlParameter parameterfldLSCode;

		private SqlParameter parameterfldLevel;

		private SqlParameter parameterfldItemCode;

		private SqlParameter parameterDecCarry;

		private SqlParameter parameterSTatType;

		private SqlParameter parameterReportFlag;

		public usp_tblEQIW_N_Report_Apprise()
		{
			base.InitCommand("usp_tblEQIW_N_Report_Apprise");
			ConfigParameter();
		}

		public System.String TimeType
		{
			get
			{
				return (System.String)this.parameterTimeType.Value;
			}
			set
			{
				this.parameterTimeType.Value=value;
			}
		}

		public System.String BeginDate
		{
			get
			{
				return (System.String)this.parameterBeginDate.Value;
			}
			set
			{
				this.parameterBeginDate.Value=value;
			}
		}

		public System.String EndDate
		{
			get
			{
				return (System.String)this.parameterEndDate.Value;
			}
			set
			{
				this.parameterEndDate.Value=value;
			}
		}

		public System.String fldRSC
		{
			get
			{
				return (System.String)this.parameterfldRSC.Value;
			}
			set
			{
				this.parameterfldRSC.Value=value;
			}
		}

		public System.String fldLSCode
		{
			get
			{
				return (System.String)this.parameterfldLSCode.Value;
			}
			set
			{
				this.parameterfldLSCode.Value=value;
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

		public System.String fldItemCode
		{
			get
			{
				return (System.String)this.parameterfldItemCode.Value;
			}
			set
			{
				this.parameterfldItemCode.Value=value;
			}
		}

		public System.String DecCarry
		{
			get
			{
				return (System.String)this.parameterDecCarry.Value;
			}
			set
			{
				this.parameterDecCarry.Value=value;
			}
		}

		public System.Int16 STatType
		{
			get
			{
				return (System.Int16)this.parameterSTatType.Value;
			}
			set
			{
				this.parameterSTatType.Value=value;
			}
		}

		public System.Int16 ReportFlag
		{
			get
			{
				return (System.Int16)this.parameterReportFlag.Value;
			}
			set
			{
				this.parameterReportFlag.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterTimeType=new SqlParameter();
			this.parameterTimeType.ParameterName="@TimeType";
			this.parameterTimeType.SqlDbType=SqlDbType.VarChar;
			this.parameterTimeType.Size=10;
			this.parameterTimeType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterTimeType);
			//--------------------------------------------------------
			this.parameterBeginDate=new SqlParameter();
			this.parameterBeginDate.ParameterName="@BeginDate";
			this.parameterBeginDate.SqlDbType=SqlDbType.VarChar;
			this.parameterBeginDate.Size=10;
			this.parameterBeginDate.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterBeginDate);
			//--------------------------------------------------------
			this.parameterEndDate=new SqlParameter();
			this.parameterEndDate.ParameterName="@EndDate";
			this.parameterEndDate.SqlDbType=SqlDbType.VarChar;
			this.parameterEndDate.Size=10;
			this.parameterEndDate.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterEndDate);
			//--------------------------------------------------------
			this.parameterfldRSC=new SqlParameter();
			this.parameterfldRSC.ParameterName="@fldRSC";
			this.parameterfldRSC.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRSC.Size=10;
			this.parameterfldRSC.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRSC);
			//--------------------------------------------------------
			this.parameterfldLSCode=new SqlParameter();
			this.parameterfldLSCode.ParameterName="@fldLSCode";
			this.parameterfldLSCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldLSCode.Size=-1;
			this.parameterfldLSCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldLSCode);
			//--------------------------------------------------------
			this.parameterfldLevel=new SqlParameter();
			this.parameterfldLevel.ParameterName="@fldLevel";
			this.parameterfldLevel.SqlDbType=SqlDbType.SmallInt;
			this.parameterfldLevel.Size=2;
			this.parameterfldLevel.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldLevel);
			//--------------------------------------------------------
			this.parameterfldItemCode=new SqlParameter();
			this.parameterfldItemCode.ParameterName="@fldItemCode";
			this.parameterfldItemCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldItemCode.Size=6000;
			this.parameterfldItemCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldItemCode);
			//--------------------------------------------------------
			this.parameterDecCarry=new SqlParameter();
			this.parameterDecCarry.ParameterName="@DecCarry";
			this.parameterDecCarry.SqlDbType=SqlDbType.VarChar;
			this.parameterDecCarry.Size=1;
			this.parameterDecCarry.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterDecCarry);
			//--------------------------------------------------------
			this.parameterSTatType=new SqlParameter();
			this.parameterSTatType.ParameterName="@STatType";
			this.parameterSTatType.SqlDbType=SqlDbType.SmallInt;
			this.parameterSTatType.Size=2;
			this.parameterSTatType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterSTatType);
			//--------------------------------------------------------
			this.parameterReportFlag=new SqlParameter();
			this.parameterReportFlag.ParameterName="@ReportFlag";
			this.parameterReportFlag.SqlDbType=SqlDbType.SmallInt;
			this.parameterReportFlag.Size=2;
			this.parameterReportFlag.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterReportFlag);
		}
	}
}
