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

	public class usp_tblEQIW_R_Section_GetRSCodeByRCode : BaseProcedure
	{
		private SqlParameter parameterfldSTCode;

		private SqlParameter parameterfldRCode;

        private SqlParameter parameterfldYear;


		public usp_tblEQIW_R_Section_GetRSCodeByRCode()
		{
			base.InitCommand("usp_tblEQIW_R_Section_GetRSCodeByRCode");
			ConfigParameter();
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

        public System.Int32 fldYear
        {
            get
            {
                return (System.Int32)this.parameterfldYear.Value;
            }
            set
            {
                this.parameterfldYear.Value = value;
            }
        }

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=12;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
			//--------------------------------------------------------
			this.parameterfldRCode=new SqlParameter();
			this.parameterfldRCode.ParameterName="@fldRCode";
			this.parameterfldRCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldRCode.Size=12;
			this.parameterfldRCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldRCode);
            //--------------------------------------------------------
            this.parameterfldYear = new SqlParameter();
            this.parameterfldYear.ParameterName = "@fldYear";
            this.parameterfldYear.SqlDbType = SqlDbType.Int;
            this.parameterfldYear.Size = 4;
            this.parameterfldYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldYear);
		}
	}
}
