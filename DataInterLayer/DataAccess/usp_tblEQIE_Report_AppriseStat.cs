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

	public class usp_tblEQIE_Report_AppriseStat : BaseProcedure
	{
		private SqlParameter parameterBeginDate;

		private SqlParameter parameterEndDate;

		private SqlParameter parameterfldPCode;

		private SqlParameter parameterDecCarry;

		private SqlParameter parameterSpaceID;

		private SqlParameter parameterSTatType;

		public usp_tblEQIE_Report_AppriseStat()
		{
			base.InitCommand("usp_tblEQIE_Report_AppriseStat");
			ConfigParameter();
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

		public System.String fldPCode
		{
			get
			{
				return (System.String)this.parameterfldPCode.Value;
			}
			set
			{
				this.parameterfldPCode.Value=value;
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

		public System.Int32 SpaceID
		{
			get
			{
				return (System.Int32)this.parameterSpaceID.Value;
			}
			set
			{
				this.parameterSpaceID.Value=value;
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

		public void ConfigParameter()
		{
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
			this.parameterfldPCode=new SqlParameter();
			this.parameterfldPCode.ParameterName="@fldPCode";
			this.parameterfldPCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldPCode.Size=-1;
			this.parameterfldPCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldPCode);
			//--------------------------------------------------------
			this.parameterDecCarry=new SqlParameter();
			this.parameterDecCarry.ParameterName="@DecCarry";
			this.parameterDecCarry.SqlDbType=SqlDbType.VarChar;
			this.parameterDecCarry.Size=1;
			this.parameterDecCarry.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterDecCarry);
			//--------------------------------------------------------
			this.parameterSpaceID=new SqlParameter();
			this.parameterSpaceID.ParameterName="@SpaceID";
			this.parameterSpaceID.SqlDbType=SqlDbType.Int;
			this.parameterSpaceID.Size=4;
			this.parameterSpaceID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterSpaceID);
			//--------------------------------------------------------
			this.parameterSTatType=new SqlParameter();
			this.parameterSTatType.ParameterName="@STatType";
			this.parameterSTatType.SqlDbType=SqlDbType.SmallInt;
			this.parameterSTatType.Size=2;
			this.parameterSTatType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterSTatType);
		}
	}
}