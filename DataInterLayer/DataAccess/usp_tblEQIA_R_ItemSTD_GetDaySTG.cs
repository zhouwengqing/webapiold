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

	public class usp_tblEQIA_R_ItemSTD_GetDaySTG : BaseProcedure
	{
		private SqlParameter parameterstritemCode;

		private SqlParameter parameterStandardNum;

		public usp_tblEQIA_R_ItemSTD_GetDaySTG()
		{
			base.InitCommand("usp_tblEQIA_R_ItemSTD_GetDaySTG");
			ConfigParameter();
		}

		public System.String stritemCode
		{
			get
			{
				return (System.String)this.parameterstritemCode.Value;
			}
			set
			{
				this.parameterstritemCode.Value=value;
			}
		}

		public System.String StandardNum
		{
			get
			{
				return (System.String)this.parameterStandardNum.Value;
			}
			set
			{
				this.parameterStandardNum.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterstritemCode=new SqlParameter();
			this.parameterstritemCode.ParameterName="@stritemCode";
			this.parameterstritemCode.SqlDbType=SqlDbType.NVarChar;
			this.parameterstritemCode.Size=-1;
			this.parameterstritemCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstritemCode);
			//--------------------------------------------------------
			this.parameterStandardNum=new SqlParameter();
			this.parameterStandardNum.ParameterName="@StandardNum";
			this.parameterStandardNum.SqlDbType=SqlDbType.VarChar;
			this.parameterStandardNum.Size=20;
			this.parameterStandardNum.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterStandardNum);
		}
	}
}
