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

	public class usp_tblEQIW_StdColorData : BaseProcedure
	{
		private SqlParameter parametercond;

		private SqlParameter parameterbtime;

		private SqlParameter parameteretime;

		private SqlParameter parameterpoint;

		private SqlParameter parameterItemCode;

		public usp_tblEQIW_StdColorData()
		{
			base.InitCommand("usp_tblEQIW_StdColorData");
			ConfigParameter();
		}

		public System.String cond
		{
			get
			{
				return (System.String)this.parametercond.Value;
			}
			set
			{
				this.parametercond.Value=value;
			}
		}

		public System.String btime
		{
			get
			{
				return (System.String)this.parameterbtime.Value;
			}
			set
			{
				this.parameterbtime.Value=value;
			}
		}

		public System.String etime
		{
			get
			{
				return (System.String)this.parameteretime.Value;
			}
			set
			{
				this.parameteretime.Value=value;
			}
		}

		public System.String point
		{
			get
			{
				return (System.String)this.parameterpoint.Value;
			}
			set
			{
				this.parameterpoint.Value=value;
			}
		}

		public System.String ItemCode
		{
			get
			{
				return (System.String)this.parameterItemCode.Value;
			}
			set
			{
				this.parameterItemCode.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parametercond=new SqlParameter();
			this.parametercond.ParameterName="@cond";
			this.parametercond.SqlDbType=SqlDbType.VarChar;
			this.parametercond.Size=-1;
			this.parametercond.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parametercond);
			//--------------------------------------------------------
			this.parameterbtime=new SqlParameter();
			this.parameterbtime.ParameterName="@btime";
			this.parameterbtime.SqlDbType=SqlDbType.VarChar;
			this.parameterbtime.Size=100;
			this.parameterbtime.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterbtime);
			//--------------------------------------------------------
			this.parameteretime=new SqlParameter();
			this.parameteretime.ParameterName="@etime";
			this.parameteretime.SqlDbType=SqlDbType.VarChar;
			this.parameteretime.Size=100;
			this.parameteretime.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameteretime);
			//--------------------------------------------------------
			this.parameterpoint=new SqlParameter();
			this.parameterpoint.ParameterName="@point";
			this.parameterpoint.SqlDbType=SqlDbType.VarChar;
			this.parameterpoint.Size=-1;
			this.parameterpoint.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterpoint);
			//--------------------------------------------------------
			this.parameterItemCode=new SqlParameter();
			this.parameterItemCode.ParameterName="@ItemCode";
			this.parameterItemCode.SqlDbType=SqlDbType.VarChar;
			this.parameterItemCode.Size=-1;
			this.parameterItemCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterItemCode);
		}
	}
}
