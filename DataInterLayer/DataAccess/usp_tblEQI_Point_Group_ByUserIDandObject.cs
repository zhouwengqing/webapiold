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

	public class usp_tblEQI_Point_Group_ByUserIDandObject : BaseProcedure
	{
		private SqlParameter parameterfldUserID;

		private SqlParameter parameterfldObject;

		public usp_tblEQI_Point_Group_ByUserIDandObject()
		{
			base.InitCommand("usp_tblEQI_Point_Group_ByUserIDandObject");
			ConfigParameter();
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

		public System.String fldObject
		{
			get
			{
				return (System.String)this.parameterfldObject.Value;
			}
			set
			{
				this.parameterfldObject.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldUserID=new SqlParameter();
			this.parameterfldUserID.ParameterName="@fldUserID";
			this.parameterfldUserID.SqlDbType=SqlDbType.Int;
			this.parameterfldUserID.Size=4;
			this.parameterfldUserID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldUserID);
			//--------------------------------------------------------
			this.parameterfldObject=new SqlParameter();
			this.parameterfldObject.ParameterName="@fldObject";
			this.parameterfldObject.SqlDbType=SqlDbType.VarChar;
			this.parameterfldObject.Size=20;
			this.parameterfldObject.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldObject);
		}
	}
}
