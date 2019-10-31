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

	public class usp_tblEQIA_P_Report_AppriseStat : BaseProcedure
	{
		private SqlParameter parameterTimeType;

		private SqlParameter parameterBeginDate;

		private SqlParameter parameterEndDate;

		private SqlParameter parameterfldPCode;

		private SqlParameter parameterpHStand;

		private SqlParameter parameterfldItemCode;

		private SqlParameter parameterDecCarry;

		private SqlParameter parameterIsPre;

		private SqlParameter parameterIsYear;

		private SqlParameter parameterIsTotal;

		private SqlParameter parameterIsDetail;

		private SqlParameter parameterAppriseID;

		private SqlParameter parameterSTatType;

		private SqlParameter parameterSpaceID;

		private SqlParameter parameterCalculateID;

		public usp_tblEQIA_P_Report_AppriseStat()
		{
			base.InitCommand("usp_tblEQIA_P_Report_AppriseStat");
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

		public System.Decimal pHStand
		{
			get
			{
				return (System.Decimal)this.parameterpHStand.Value;
			}
			set
			{
				this.parameterpHStand.Value=value;
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

		public System.Int32 IsPre
		{
			get
			{
				return (System.Int32)this.parameterIsPre.Value;
			}
			set
			{
				this.parameterIsPre.Value=value;
			}
		}

		public System.Int32 IsYear
		{
			get
			{
				return (System.Int32)this.parameterIsYear.Value;
			}
			set
			{
				this.parameterIsYear.Value=value;
			}
		}

		public System.Int32 IsTotal
		{
			get
			{
				return (System.Int32)this.parameterIsTotal.Value;
			}
			set
			{
				this.parameterIsTotal.Value=value;
			}
		}

		public System.Int32 IsDetail
		{
			get
			{
				return (System.Int32)this.parameterIsDetail.Value;
			}
			set
			{
				this.parameterIsDetail.Value=value;
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

		public System.Int32 CalculateID
		{
			get
			{
				return (System.Int32)this.parameterCalculateID.Value;
			}
			set
			{
				this.parameterCalculateID.Value=value;
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
			this.parameterfldPCode=new SqlParameter();
			this.parameterfldPCode.ParameterName="@fldPCode";
			this.parameterfldPCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldPCode.Size=-1;
			this.parameterfldPCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldPCode);
			//--------------------------------------------------------
			this.parameterpHStand=new SqlParameter();
			this.parameterpHStand.ParameterName="@pHStand";
			this.parameterpHStand.SqlDbType=SqlDbType.Decimal;
			this.parameterpHStand.Size=9;
			this.parameterpHStand.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterpHStand);
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
			this.parameterIsPre=new SqlParameter();
			this.parameterIsPre.ParameterName="@IsPre";
			this.parameterIsPre.SqlDbType=SqlDbType.Int;
			this.parameterIsPre.Size=4;
			this.parameterIsPre.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterIsPre);
			//--------------------------------------------------------
			this.parameterIsYear=new SqlParameter();
			this.parameterIsYear.ParameterName="@IsYear";
			this.parameterIsYear.SqlDbType=SqlDbType.Int;
			this.parameterIsYear.Size=4;
			this.parameterIsYear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterIsYear);
			//--------------------------------------------------------
			this.parameterIsTotal=new SqlParameter();
			this.parameterIsTotal.ParameterName="@IsTotal";
			this.parameterIsTotal.SqlDbType=SqlDbType.Int;
			this.parameterIsTotal.Size=4;
			this.parameterIsTotal.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterIsTotal);
			//--------------------------------------------------------
			this.parameterIsDetail=new SqlParameter();
			this.parameterIsDetail.ParameterName="@IsDetail";
			this.parameterIsDetail.SqlDbType=SqlDbType.Int;
			this.parameterIsDetail.Size=4;
			this.parameterIsDetail.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterIsDetail);
			//--------------------------------------------------------
			this.parameterAppriseID=new SqlParameter();
			this.parameterAppriseID.ParameterName="@AppriseID";
			this.parameterAppriseID.SqlDbType=SqlDbType.Int;
			this.parameterAppriseID.Size=4;
			this.parameterAppriseID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterAppriseID);
			//--------------------------------------------------------
			this.parameterSTatType=new SqlParameter();
			this.parameterSTatType.ParameterName="@STatType";
			this.parameterSTatType.SqlDbType=SqlDbType.SmallInt;
			this.parameterSTatType.Size=2;
			this.parameterSTatType.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterSTatType);
			//--------------------------------------------------------
			this.parameterSpaceID=new SqlParameter();
			this.parameterSpaceID.ParameterName="@SpaceID";
			this.parameterSpaceID.SqlDbType=SqlDbType.Int;
			this.parameterSpaceID.Size=4;
			this.parameterSpaceID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterSpaceID);
			//--------------------------------------------------------
			this.parameterCalculateID=new SqlParameter();
			this.parameterCalculateID.ParameterName="@CalculateID";
			this.parameterCalculateID.SqlDbType=SqlDbType.Int;
			this.parameterCalculateID.Size=4;
			this.parameterCalculateID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterCalculateID);
		}
	}
}