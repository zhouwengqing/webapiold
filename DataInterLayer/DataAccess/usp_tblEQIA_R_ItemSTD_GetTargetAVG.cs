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

	public class usp_tblEQIA_R_ItemSTD_GetTargetAVG : BaseProcedure
	{
		private SqlParameter parameternumValue;

		private SqlParameter parameterstrItemCode;

		private SqlParameter parameterstrSTDName;

		private SqlParameter parameterstrSTDLevel;

		private SqlParameter parameterstrFlag;

		public usp_tblEQIA_R_ItemSTD_GetTargetAVG()
		{
			base.InitCommand("usp_tblEQIA_R_ItemSTD_GetTargetAVG");
			ConfigParameter();
		}

		public System.Decimal numValue
		{
			get
			{
				return (System.Decimal)this.parameternumValue.Value;
			}
			set
			{
				this.parameternumValue.Value=value;
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

		public System.String strSTDLevel
		{
			get
			{
				return (System.String)this.parameterstrSTDLevel.Value;
			}
			set
			{
				this.parameterstrSTDLevel.Value=value;
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

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameternumValue=new SqlParameter();
			this.parameternumValue.ParameterName="@numValue";
			this.parameternumValue.SqlDbType=SqlDbType.Decimal;
			this.parameternumValue.Size=13;
			this.parameternumValue.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameternumValue);
			//--------------------------------------------------------
			this.parameterstrItemCode=new SqlParameter();
			this.parameterstrItemCode.ParameterName="@strItemCode";
			this.parameterstrItemCode.SqlDbType=SqlDbType.VarChar;
			this.parameterstrItemCode.Size=10;
			this.parameterstrItemCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrItemCode);
			//--------------------------------------------------------
			this.parameterstrSTDName=new SqlParameter();
			this.parameterstrSTDName.ParameterName="@strSTDName";
			this.parameterstrSTDName.SqlDbType=SqlDbType.VarChar;
			this.parameterstrSTDName.Size=80;
			this.parameterstrSTDName.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrSTDName);
			//--------------------------------------------------------
			this.parameterstrSTDLevel=new SqlParameter();
			this.parameterstrSTDLevel.ParameterName="@strSTDLevel";
			this.parameterstrSTDLevel.SqlDbType=SqlDbType.VarChar;
			this.parameterstrSTDLevel.Size=10;
			this.parameterstrSTDLevel.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrSTDLevel);
			//--------------------------------------------------------
			this.parameterstrFlag=new SqlParameter();
			this.parameterstrFlag.ParameterName="@strFlag";
			this.parameterstrFlag.SqlDbType=SqlDbType.VarChar;
			this.parameterstrFlag.Size=10;
			this.parameterstrFlag.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstrFlag);
		}
	}
}