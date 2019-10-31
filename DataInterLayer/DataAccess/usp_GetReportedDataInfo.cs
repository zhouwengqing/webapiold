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

	public class usp_GetReportedDataInfo : BaseProcedure
	{
		private SqlParameter parameterViewType;

		private SqlParameter parameterSTCode;

		private SqlParameter parameterSTypeView;

		private SqlParameter parameterstrWhere;

		private SqlParameter parameterstrYear;

		private SqlParameter parameterstrBegin;

		private SqlParameter parameterstrEnd;

		private SqlParameter parametertimetype;

		private SqlParameter parameterquerytype;

		public usp_GetReportedDataInfo()
		{
			base.InitCommand("usp_GetReportedDataInfo");
			ConfigParameter();
		}

		public System.String ViewType
		{
			get
			{
				return (System.String)this.parameterViewType.Value;
			}
			set
			{
				this.parameterViewType.Value=value;
			}
		}

		public System.String STCode
		{
			get
			{
				return (System.String)this.parameterSTCode.Value;
			}
			set
			{
				this.parameterSTCode.Value=value;
			}
		}

		public System.String STypeView
		{
			get
			{
				return (System.String)this.parameterSTypeView.Value;
			}
			set
			{
				this.parameterSTypeView.Value=value;
			}
		}

		public System.String strWhere
		{
			get
			{
				return (System.String)this.parameterstrWhere.Value;
			}
			set
			{
				this.parameterstrWhere.Value=value;
			}
		}

		public System.String strYear
		{
			get
			{
				return (System.String)this.parameterstrYear.Value;
			}
			set
			{
				this.parameterstrYear.Value=value;
			}
		}

		public System.String strBegin
		{
			get
			{
				return (System.String)this.parameterstrBegin.Value;
			}
			set
			{
				this.parameterstrBegin.Value=value;
			}
		}

		public System.String strEnd
		{
			get
			{
				return (System.String)this.parameterstrEnd.Value;
			}
			set
			{
				this.parameterstrEnd.Value=value;
			}
		}

		public System.Int32 timetype
		{
			get
			{
				return (System.Int32)this.parametertimetype.Value;
			}
			set
			{
				this.parametertimetype.Value=value;
			}
		}

		public System.Int32 querytype
		{
			get
			{
				return (System.Int32)this.parameterquerytype.Value;
			}
			set
			{
				this.parameterquerytype.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterViewType=new SqlParameter();
			this.parameterViewType.ParameterName="@ViewType";
			this.parameterViewType.SqlDbType=SqlDbType.VarChar;
			this.parameterViewType.Size=20;
			this.parameterViewType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterViewType);
			//--------------------------------------------------------
			this.parameterSTCode=new SqlParameter();
			this.parameterSTCode.ParameterName="@STCode";
			this.parameterSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterSTCode.Size=1000;
			this.parameterSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterSTCode);
			//--------------------------------------------------------
			this.parameterSTypeView=new SqlParameter();
			this.parameterSTypeView.ParameterName="@STypeView";
			this.parameterSTypeView.SqlDbType=SqlDbType.VarChar;
			this.parameterSTypeView.Size=1000;
			this.parameterSTypeView.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterSTypeView);
			//--------------------------------------------------------
			this.parameterstrWhere=new SqlParameter();
			this.parameterstrWhere.ParameterName="@strWhere";
			this.parameterstrWhere.SqlDbType=SqlDbType.VarChar;
			this.parameterstrWhere.Size=1000;
			this.parameterstrWhere.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrWhere);
			//--------------------------------------------------------
			this.parameterstrYear=new SqlParameter();
			this.parameterstrYear.ParameterName="@strYear";
			this.parameterstrYear.SqlDbType=SqlDbType.VarChar;
			this.parameterstrYear.Size=5;
			this.parameterstrYear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrYear);
			//--------------------------------------------------------
			this.parameterstrBegin=new SqlParameter();
			this.parameterstrBegin.ParameterName="@strBegin";
			this.parameterstrBegin.SqlDbType=SqlDbType.VarChar;
			this.parameterstrBegin.Size=10;
			this.parameterstrBegin.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrBegin);
			//--------------------------------------------------------
			this.parameterstrEnd=new SqlParameter();
			this.parameterstrEnd.ParameterName="@strEnd";
			this.parameterstrEnd.SqlDbType=SqlDbType.VarChar;
			this.parameterstrEnd.Size=10;
			this.parameterstrEnd.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrEnd);
			//--------------------------------------------------------
			this.parametertimetype=new SqlParameter();
			this.parametertimetype.ParameterName="@timetype";
			this.parametertimetype.SqlDbType=SqlDbType.Int;
			this.parametertimetype.Size=4;
			this.parametertimetype.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parametertimetype);
			//--------------------------------------------------------
			this.parameterquerytype=new SqlParameter();
			this.parameterquerytype.ParameterName="@querytype";
			this.parameterquerytype.SqlDbType=SqlDbType.Int;
			this.parameterquerytype.Size=4;
			this.parameterquerytype.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterquerytype);
		}
	}
}