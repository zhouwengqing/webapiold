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

	public class usp_tblEQIA_PPI_BaseData_GetItemAVGDataForGis : BaseProcedure
	{
		private SqlParameter parameterfldTimeType;

		private SqlParameter parameterfldSTCode;

		private SqlParameter parameterBeginDate;

		private SqlParameter parameterEndDate;

		private SqlParameter parameterfldItemCode;

		private SqlParameter parameterReportType;

		public usp_tblEQIA_PPI_BaseData_GetItemAVGDataForGis()
		{
			base.InitCommand("usp_tblEQIA_PPI_BaseData_GetItemAVGDataForGis");
			ConfigParameter();
		}

		public System.String fldTimeType
		{
			get
			{
				return (System.String)this.parameterfldTimeType.Value;
			}
			set
			{
				this.parameterfldTimeType.Value=value;
			}
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

		public System.String ReportType
		{
			get
			{
				return (System.String)this.parameterReportType.Value;
			}
			set
			{
				this.parameterReportType.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldTimeType=new SqlParameter();
			this.parameterfldTimeType.ParameterName="@fldTimeType";
			this.parameterfldTimeType.SqlDbType=SqlDbType.VarChar;
			this.parameterfldTimeType.Size=10;
			this.parameterfldTimeType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldTimeType);
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=10;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
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
			this.parameterfldItemCode=new SqlParameter();
			this.parameterfldItemCode.ParameterName="@fldItemCode";
			this.parameterfldItemCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldItemCode.Size=10;
			this.parameterfldItemCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldItemCode);
			//--------------------------------------------------------
			this.parameterReportType=new SqlParameter();
			this.parameterReportType.ParameterName="@ReportType";
			this.parameterReportType.SqlDbType=SqlDbType.VarChar;
			this.parameterReportType.Size=10;
			this.parameterReportType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterReportType);
		}
	}
}