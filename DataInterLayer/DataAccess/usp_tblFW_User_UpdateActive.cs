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

	public class usp_tblFW_User_UpdateActive : BaseProcedure
	{
		private SqlParameter parameterfldAutoID;

		public usp_tblFW_User_UpdateActive()
		{
			base.InitCommand("usp_tblFW_User_UpdateActive");
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

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldAutoID=new SqlParameter();
			this.parameterfldAutoID.ParameterName="@fldAutoID";
			this.parameterfldAutoID.SqlDbType=SqlDbType.Int;
			this.parameterfldAutoID.Size=4;
			this.parameterfldAutoID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldAutoID);
		}
	}
}
