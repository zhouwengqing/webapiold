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

	public class usp_tblEQIA_R_ItemSTD_Insert : BaseProcedure
	{
		private SqlParameter parameterfldAutoID;

		private SqlParameter parameterfldStandardName;

		private SqlParameter parameterfldStandardNum;

		private SqlParameter parameterfldItemCode;

		private SqlParameter parameterfldHourSTG1;

		private SqlParameter parameterfldHourSTG2;

		private SqlParameter parameterfldHourSTG3;

		private SqlParameter parameterfldDaySTG1;

		private SqlParameter parameterfldDaySTG2;

		private SqlParameter parameterfldDaySTG3;

		private SqlParameter parameterfldYearSTG1;

		private SqlParameter parameterfldYearSTG2;

		private SqlParameter parameterfldYearSTG3;

		public usp_tblEQIA_R_ItemSTD_Insert()
		{
			base.InitCommand("usp_tblEQIA_R_ItemSTD_Insert");
			ConfigParameter();
		}

		public System.Int32 fldAutoID
		{
			get
			{
				return (System.Int32)this.parameterfldAutoID.Value;
			}
			set
			{
				this.parameterfldAutoID.Value=value;
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

		public System.String fldStandardNum
		{
			get
			{
				return (System.String)this.parameterfldStandardNum.Value;
			}
			set
			{
				this.parameterfldStandardNum.Value=value;
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

		public System.Decimal fldHourSTG1
		{
			get
			{
				return (System.Decimal)this.parameterfldHourSTG1.Value;
			}
			set
			{
				this.parameterfldHourSTG1.Value=value;
			}
		}

		public System.Decimal fldHourSTG2
		{
			get
			{
				return (System.Decimal)this.parameterfldHourSTG2.Value;
			}
			set
			{
				this.parameterfldHourSTG2.Value=value;
			}
		}

		public System.Decimal fldHourSTG3
		{
			get
			{
				return (System.Decimal)this.parameterfldHourSTG3.Value;
			}
			set
			{
				this.parameterfldHourSTG3.Value=value;
			}
		}

		public System.Decimal fldDaySTG1
		{
			get
			{
				return (System.Decimal)this.parameterfldDaySTG1.Value;
			}
			set
			{
				this.parameterfldDaySTG1.Value=value;
			}
		}

		public System.Decimal fldDaySTG2
		{
			get
			{
				return (System.Decimal)this.parameterfldDaySTG2.Value;
			}
			set
			{
				this.parameterfldDaySTG2.Value=value;
			}
		}

		public System.Decimal fldDaySTG3
		{
			get
			{
				return (System.Decimal)this.parameterfldDaySTG3.Value;
			}
			set
			{
				this.parameterfldDaySTG3.Value=value;
			}
		}

		public System.Decimal fldYearSTG1
		{
			get
			{
				return (System.Decimal)this.parameterfldYearSTG1.Value;
			}
			set
			{
				this.parameterfldYearSTG1.Value=value;
			}
		}

		public System.Decimal fldYearSTG2
		{
			get
			{
				return (System.Decimal)this.parameterfldYearSTG2.Value;
			}
			set
			{
				this.parameterfldYearSTG2.Value=value;
			}
		}

		public System.Decimal fldYearSTG3
		{
			get
			{
				return (System.Decimal)this.parameterfldYearSTG3.Value;
			}
			set
			{
				this.parameterfldYearSTG3.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldAutoID=new SqlParameter();
			this.parameterfldAutoID.ParameterName="@fldAutoID";
			this.parameterfldAutoID.SqlDbType=SqlDbType.Int;
			this.parameterfldAutoID.Size=4;
			this.parameterfldAutoID.Direction=ParameterDirection.InputOutput;
			base.m_cmd.Parameters.Add(this.parameterfldAutoID);
			//--------------------------------------------------------
			this.parameterfldStandardName=new SqlParameter();
			this.parameterfldStandardName.ParameterName="@fldStandardName";
			this.parameterfldStandardName.SqlDbType=SqlDbType.VarChar;
			this.parameterfldStandardName.Size=80;
			this.parameterfldStandardName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldStandardName);
			//--------------------------------------------------------
			this.parameterfldStandardNum=new SqlParameter();
			this.parameterfldStandardNum.ParameterName="@fldStandardNum";
			this.parameterfldStandardNum.SqlDbType=SqlDbType.VarChar;
			this.parameterfldStandardNum.Size=20;
			this.parameterfldStandardNum.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldStandardNum);
			//--------------------------------------------------------
			this.parameterfldItemCode=new SqlParameter();
			this.parameterfldItemCode.ParameterName="@fldItemCode";
			this.parameterfldItemCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldItemCode.Size=10;
			this.parameterfldItemCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldItemCode);
			//--------------------------------------------------------
			this.parameterfldHourSTG1=new SqlParameter();
			this.parameterfldHourSTG1.ParameterName="@fldHourSTG1";
			this.parameterfldHourSTG1.SqlDbType=SqlDbType.Decimal;
			this.parameterfldHourSTG1.Size=5;
			this.parameterfldHourSTG1.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldHourSTG1);
			//--------------------------------------------------------
			this.parameterfldHourSTG2=new SqlParameter();
			this.parameterfldHourSTG2.ParameterName="@fldHourSTG2";
			this.parameterfldHourSTG2.SqlDbType=SqlDbType.Decimal;
			this.parameterfldHourSTG2.Size=5;
			this.parameterfldHourSTG2.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldHourSTG2);
			//--------------------------------------------------------
			this.parameterfldHourSTG3=new SqlParameter();
			this.parameterfldHourSTG3.ParameterName="@fldHourSTG3";
			this.parameterfldHourSTG3.SqlDbType=SqlDbType.Decimal;
			this.parameterfldHourSTG3.Size=5;
			this.parameterfldHourSTG3.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldHourSTG3);
			//--------------------------------------------------------
			this.parameterfldDaySTG1=new SqlParameter();
			this.parameterfldDaySTG1.ParameterName="@fldDaySTG1";
			this.parameterfldDaySTG1.SqlDbType=SqlDbType.Decimal;
			this.parameterfldDaySTG1.Size=5;
			this.parameterfldDaySTG1.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldDaySTG1);
			//--------------------------------------------------------
			this.parameterfldDaySTG2=new SqlParameter();
			this.parameterfldDaySTG2.ParameterName="@fldDaySTG2";
			this.parameterfldDaySTG2.SqlDbType=SqlDbType.Decimal;
			this.parameterfldDaySTG2.Size=5;
			this.parameterfldDaySTG2.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldDaySTG2);
			//--------------------------------------------------------
			this.parameterfldDaySTG3=new SqlParameter();
			this.parameterfldDaySTG3.ParameterName="@fldDaySTG3";
			this.parameterfldDaySTG3.SqlDbType=SqlDbType.Decimal;
			this.parameterfldDaySTG3.Size=5;
			this.parameterfldDaySTG3.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldDaySTG3);
			//--------------------------------------------------------
			this.parameterfldYearSTG1=new SqlParameter();
			this.parameterfldYearSTG1.ParameterName="@fldYearSTG1";
			this.parameterfldYearSTG1.SqlDbType=SqlDbType.Decimal;
			this.parameterfldYearSTG1.Size=5;
			this.parameterfldYearSTG1.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldYearSTG1);
			//--------------------------------------------------------
			this.parameterfldYearSTG2=new SqlParameter();
			this.parameterfldYearSTG2.ParameterName="@fldYearSTG2";
			this.parameterfldYearSTG2.SqlDbType=SqlDbType.Decimal;
			this.parameterfldYearSTG2.Size=5;
			this.parameterfldYearSTG2.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldYearSTG2);
			//--------------------------------------------------------
			this.parameterfldYearSTG3=new SqlParameter();
			this.parameterfldYearSTG3.ParameterName="@fldYearSTG3";
			this.parameterfldYearSTG3.SqlDbType=SqlDbType.Decimal;
			this.parameterfldYearSTG3.Size=5;
			this.parameterfldYearSTG3.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldYearSTG3);
		}
	}
}
