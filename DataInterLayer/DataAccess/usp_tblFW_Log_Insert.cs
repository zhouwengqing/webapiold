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

	public class usp_tblFW_Log_Insert : BaseProcedure
	{
		private SqlParameter parameterfldAutoID;

		private SqlParameter parameterfldUserID;

		private SqlParameter parameterfldCityID;

		private SqlParameter parameterfldModalID;

		private SqlParameter parameterfldContent;

		private SqlParameter parameterfldDate_operate;

		private SqlParameter parameterfldIPAddress;

		public usp_tblFW_Log_Insert()
		{
			base.InitCommand("usp_tblFW_Log_Insert");
			ConfigParameter();
		}

		public System.Int64 fldAutoID
		{
			get
			{
				return (System.Int64)this.parameterfldAutoID.Value;
			}
			set
			{
				this.parameterfldAutoID.Value=value;
			}
		}

		public System.Int32 fldUserID
		{
			get
			{
				return (System.Int32)this.parameterfldUserID.Value;
			}
			set
			{
				this.parameterfldUserID.Value=value;
			}
		}

		public System.Int32 fldCityID
		{
			get
			{
				return (System.Int32)this.parameterfldCityID.Value;
			}
			set
			{
				this.parameterfldCityID.Value=value;
			}
		}

		public System.Int32 fldModalID
		{
			get
			{
				return (System.Int32)this.parameterfldModalID.Value;
			}
			set
			{
				this.parameterfldModalID.Value=value;
			}
		}

		public System.String fldContent
		{
			get
			{
				return (System.String)this.parameterfldContent.Value;
			}
			set
			{
				this.parameterfldContent.Value=value;
			}
		}

		public System.DateTime fldDate_operate
		{
			get
			{
				return (System.DateTime)this.parameterfldDate_operate.Value;
			}
			set
			{
				this.parameterfldDate_operate.Value=value;
			}
		}

		public System.String fldIPAddress
		{
			get
			{
				return (System.String)this.parameterfldIPAddress.Value;
			}
			set
			{
				this.parameterfldIPAddress.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldAutoID=new SqlParameter();
			this.parameterfldAutoID.ParameterName="@fldAutoID";
			this.parameterfldAutoID.SqlDbType=SqlDbType.BigInt;
			this.parameterfldAutoID.Size=8;
			this.parameterfldAutoID.Direction=ParameterDirection.InputOutput;
			base.m_cmd.Parameters.Add(this.parameterfldAutoID);
			//--------------------------------------------------------
			this.parameterfldUserID=new SqlParameter();
			this.parameterfldUserID.ParameterName="@fldUserID";
			this.parameterfldUserID.SqlDbType=SqlDbType.Int;
			this.parameterfldUserID.Size=4;
			this.parameterfldUserID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldUserID);
			//--------------------------------------------------------
			this.parameterfldCityID=new SqlParameter();
			this.parameterfldCityID.ParameterName="@fldCityID";
			this.parameterfldCityID.SqlDbType=SqlDbType.Int;
			this.parameterfldCityID.Size=4;
			this.parameterfldCityID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldCityID);
			//--------------------------------------------------------
			this.parameterfldModalID=new SqlParameter();
			this.parameterfldModalID.ParameterName="@fldModalID";
			this.parameterfldModalID.SqlDbType=SqlDbType.Int;
			this.parameterfldModalID.Size=4;
			this.parameterfldModalID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldModalID);
			//--------------------------------------------------------
			this.parameterfldContent=new SqlParameter();
			this.parameterfldContent.ParameterName="@fldContent";
			this.parameterfldContent.SqlDbType=SqlDbType.VarChar;
			this.parameterfldContent.Size=5000;
			this.parameterfldContent.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldContent);
			//--------------------------------------------------------
			this.parameterfldDate_operate=new SqlParameter();
			this.parameterfldDate_operate.ParameterName="@fldDate_operate";
			this.parameterfldDate_operate.SqlDbType=SqlDbType.DateTime;
			this.parameterfldDate_operate.Size=8;
			this.parameterfldDate_operate.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldDate_operate);
			//--------------------------------------------------------
			this.parameterfldIPAddress=new SqlParameter();
			this.parameterfldIPAddress.ParameterName="@fldIPAddress";
			this.parameterfldIPAddress.SqlDbType=SqlDbType.VarChar;
			this.parameterfldIPAddress.Size=20;
			this.parameterfldIPAddress.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldIPAddress);
		}
	}
}
