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

	public class usp_tblEQIA_R_ItemSTD_GetAQL : BaseProcedure
	{
		private SqlParameter parameternAVG;

		private SqlParameter parameterstrFlag;

		private SqlParameter parameterstrSTDName;

		private SqlParameter parameterstrItemCode;

		public usp_tblEQIA_R_ItemSTD_GetAQL()
		{
			base.InitCommand("usp_tblEQIA_R_ItemSTD_GetAQL");
			ConfigParameter();
		}

		public System.Decimal nAVG
		{
			get
			{
				return (System.Decimal)this.parameternAVG.Value;
			}
			set
			{
				this.parameternAVG.Value=value;
			}
		}

		public System.String strFlag
		{
			get
			{
				return (System.String)this.parameterstrFlag.Value;
			}
			set
			{
				this.parameterstrFlag.Value=value;
			}
		}

		public System.String strSTDName
		{
			get
			{
				return (System.String)this.parameterstrSTDName.Value;
			}
			set
			{
				this.parameterstrSTDName.Value=value;
			}
		}

		public System.String strItemCode
		{
			get
			{
				return (System.String)this.parameterstrItemCode.Value;
			}
			set
			{
				this.parameterstrItemCode.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameternAVG=new SqlParameter();
			this.parameternAVG.ParameterName="@nAVG";
			this.parameternAVG.SqlDbType=SqlDbType.Decimal;
			this.parameternAVG.Size=5;
			this.parameternAVG.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameternAVG);
			//--------------------------------------------------------
			this.parameterstrFlag=new SqlParameter();
			this.parameterstrFlag.ParameterName="@strFlag";
			this.parameterstrFlag.SqlDbType=SqlDbType.VarChar;
			this.parameterstrFlag.Size=10;
			this.parameterstrFlag.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrFlag);
			//--------------------------------------------------------
			this.parameterstrSTDName=new SqlParameter();
			this.parameterstrSTDName.ParameterName="@strSTDName";
			this.parameterstrSTDName.SqlDbType=SqlDbType.VarChar;
			this.parameterstrSTDName.Size=80;
			this.parameterstrSTDName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrSTDName);
			//--------------------------------------------------------
			this.parameterstrItemCode=new SqlParameter();
			this.parameterstrItemCode.ParameterName="@strItemCode";
			this.parameterstrItemCode.SqlDbType=SqlDbType.VarChar;
			this.parameterstrItemCode.Size=10;
			this.parameterstrItemCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrItemCode);
		}
	}
}
