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

	public class usp_tblEQIW_R_Report_DataStat_Gis : BaseProcedure
	{
		private SqlParameter parameterTimeType;

		private SqlParameter parameterBeginDate;

		private SqlParameter parameterEndDate;

		private SqlParameter parameterfldSTCode;

		private SqlParameter parameterfldSRName;

		private SqlParameter parameterfldRCode;

		private SqlParameter parameterfldRSCode;

		private SqlParameter parameterfldRStandardName;

		private SqlParameter parameterfldRLevel;

		private SqlParameter parameterfldLStandardName;

		private SqlParameter parameterfldLLevel;

		private SqlParameter parameterfldItemCode;

		private SqlParameter parameterDecCarry;

		public usp_tblEQIW_R_Report_DataStat_Gis()
		{
			base.InitCommand("usp_tblEQIW_R_Report_DataStat_Gis");
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
        public System.String fldSRName
		{
			get
			{
                return (System.String)this.parameterfldSRName.Value;
			}
			set
			{
                this.parameterfldSRName.Value = value;
			}
		}

		public System.String fldRCode
		{
			get
			{
				return (System.String)this.parameterfldRCode.Value;
			}
			set
			{
				this.parameterfldRCode.Value=value;
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
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=10;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
			//--------------------------------------------------------
            this.parameterfldSRName = new SqlParameter();
            this.parameterfldSRName.ParameterName = "@fldSRName";
            this.parameterfldSRName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldSRName.Size = 50;
            this.parameterfldSRName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSRName);
			//--------------------------------------------------------
			this.parameterfldRCode=new SqlParameter();
			this.parameterfldRCode.ParameterName="@fldRCode";
			this.parameterfldRCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRCode.Size=20;
			this.parameterfldRCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRCode);
			//--------------------------------------------------------
			this.parameterfldRSCode=new SqlParameter();
			this.parameterfldRSCode.ParameterName="@fldRSCode";
			this.parameterfldRSCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRSCode.Size=12;
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
		}
	}
}
