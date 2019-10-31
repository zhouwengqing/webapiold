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

	public class usp_tblEQISO_Report_Apprise : BaseProcedure
	{
		private SqlParameter parameterTimeType;

		private SqlParameter parameterBeginDate;

		private SqlParameter parameterEndDate;

		private SqlParameter parameterfldRSCode;

		private SqlParameter parameterfldStandardName;

		private SqlParameter parameterfldLevel;

		private SqlParameter parameterfldItemCode;

		private SqlParameter parameterDecCarry;

		private SqlParameter parameterAppriseID;

		private SqlParameter parameterSpaceID;

		private SqlParameter parameterSTatType;

		public usp_tblEQISO_Report_Apprise()
		{
			base.InitCommand("usp_tblEQISO_Report_Apprise");
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

		public System.String fldRSCode
		{
			get
			{
				return (System.String)this.parameterfldRSCode.Value;
			}
			set
			{
				this.parameterfldRSCode.Value=value;
			}
		}

		public System.String fldStandardName
		{
			get
			{
				return (System.String)this.parameterfldStandardName.Value;
			}
			set
			{
				this.parameterfldStandardName.Value=value;
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

		public System.Int32 AppriseID
		{
			get
			{
				return (System.Int32)this.parameterAppriseID.Value;
			}
			set
			{
				this.parameterAppriseID.Value=value;
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
			this.parameterfldRSCode=new SqlParameter();
			this.parameterfldRSCode.ParameterName="@fldRSCode";
			this.parameterfldRSCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRSCode.Size=-1;
			this.parameterfldRSCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRSCode);
			//--------------------------------------------------------
			this.parameterfldStandardName=new SqlParameter();
			this.parameterfldStandardName.ParameterName="@fldStandardName";
			this.parameterfldStandardName.SqlDbType=SqlDbType.VarChar;
			this.parameterfldStandardName.Size=100;
			this.parameterfldStandardName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldStandardName);
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
			this.parameterAppriseID=new SqlParameter();
			this.parameterAppriseID.ParameterName="@AppriseID";
			this.parameterAppriseID.SqlDbType=SqlDbType.Int;
			this.parameterAppriseID.Size=4;
			this.parameterAppriseID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterAppriseID);
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
