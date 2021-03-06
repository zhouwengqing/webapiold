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

	public class usp_tblEQIW_D_Report_Apprise_V : BaseProcedure
	{
		private SqlParameter parameterTimeType;

		private SqlParameter parameterBeginDate;

		private SqlParameter parameterEndDate;

		private SqlParameter parameterfldRSCode;

		private SqlParameter parameterfldRStandardName;

		private SqlParameter parameterfldRLevel;

		private SqlParameter parameterfldLStandardName;

		private SqlParameter parameterfldLLevel;

		private SqlParameter parameterfldItemCode;

		private SqlParameter parameterDecCarry;

		private SqlParameter parameterAppriseID;

		private SqlParameter parameterSpaceID;

		private SqlParameter parameterSTatType;

		private SqlParameter parameterfldIsYear;

		private SqlParameter parameterfldSource;

		private SqlParameter parameterPointType;

		public usp_tblEQIW_D_Report_Apprise_V()
		{
			base.InitCommand("usp_tblEQIW_D_Report_Apprise_V");
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

		public System.String fldRStandardName
		{
			get
			{
				return (System.String)this.parameterfldRStandardName.Value;
			}
			set
			{
				this.parameterfldRStandardName.Value=value;
			}
		}

		public System.Int16 fldRLevel
		{
			get
			{
				return (System.Int16)this.parameterfldRLevel.Value;
			}
			set
			{
				this.parameterfldRLevel.Value=value;
			}
		}

		public System.String fldLStandardName
		{
			get
			{
				return (System.String)this.parameterfldLStandardName.Value;
			}
			set
			{
				this.parameterfldLStandardName.Value=value;
			}
		}

		public System.Int16 fldLLevel
		{
			get
			{
				return (System.Int16)this.parameterfldLLevel.Value;
			}
			set
			{
				this.parameterfldLLevel.Value=value;
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

		public System.Int32 fldIsYear
		{
			get
			{
				return (System.Int32)this.parameterfldIsYear.Value;
			}
			set
			{
				this.parameterfldIsYear.Value=value;
			}
		}

		public System.String fldSource
		{
			get
			{
				return (System.String)this.parameterfldSource.Value;
			}
			set
			{
				this.parameterfldSource.Value=value;
			}
		}

		public System.Int32 PointType
		{
			get
			{
				return (System.Int32)this.parameterPointType.Value;
			}
			set
			{
				this.parameterPointType.Value=value;
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
			this.parameterfldRStandardName=new SqlParameter();
			this.parameterfldRStandardName.ParameterName="@fldRStandardName";
			this.parameterfldRStandardName.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRStandardName.Size=100;
			this.parameterfldRStandardName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRStandardName);
			//--------------------------------------------------------
			this.parameterfldRLevel=new SqlParameter();
			this.parameterfldRLevel.ParameterName="@fldRLevel";
			this.parameterfldRLevel.SqlDbType=SqlDbType.SmallInt;
			this.parameterfldRLevel.Size=2;
			this.parameterfldRLevel.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRLevel);
			//--------------------------------------------------------
			this.parameterfldLStandardName=new SqlParameter();
			this.parameterfldLStandardName.ParameterName="@fldLStandardName";
			this.parameterfldLStandardName.SqlDbType=SqlDbType.VarChar;
			this.parameterfldLStandardName.Size=100;
			this.parameterfldLStandardName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldLStandardName);
			//--------------------------------------------------------
			this.parameterfldLLevel=new SqlParameter();
			this.parameterfldLLevel.ParameterName="@fldLLevel";
			this.parameterfldLLevel.SqlDbType=SqlDbType.SmallInt;
			this.parameterfldLLevel.Size=2;
			this.parameterfldLLevel.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldLLevel);
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
			//--------------------------------------------------------
			this.parameterfldIsYear=new SqlParameter();
			this.parameterfldIsYear.ParameterName="@fldIsYear";
			this.parameterfldIsYear.SqlDbType=SqlDbType.Int;
			this.parameterfldIsYear.Size=4;
			this.parameterfldIsYear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldIsYear);
			//--------------------------------------------------------
			this.parameterfldSource=new SqlParameter();
			this.parameterfldSource.ParameterName="@fldSource";
			this.parameterfldSource.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSource.Size=10;
			this.parameterfldSource.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSource);
			//--------------------------------------------------------
			this.parameterPointType=new SqlParameter();
			this.parameterPointType.ParameterName="@PointType";
			this.parameterPointType.SqlDbType=SqlDbType.Int;
			this.parameterPointType.Size=4;
			this.parameterPointType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterPointType);
		}
	}
}
