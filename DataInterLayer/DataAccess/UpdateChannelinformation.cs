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

	public class UpdateChannelinformation : BaseProcedure
	{
		private SqlParameter parameterfldbuckle;

		private SqlParameter parameterfldAutoID;

        private SqlParameter parameterIsOk;
        public UpdateChannelinformation()
		{
			base.InitCommand("UpdateChannelinformation");
			ConfigParameter();
		}

		public System.String fldbuckle
        {
			get
			{
				return (System.String)this.parameterfldbuckle.Value;
			}
			set
			{
				this.parameterfldbuckle.Value=value;
			}
		}

		public System.String fldAutoID
        {
			get
			{
				return (System.String)this.parameterfldAutoID.Value;
			}
			set
			{
				this.parameterfldAutoID.Value=value;
			}
		}

        public System.Int32 IsOk
        {
            get
            {
                return (System.Int16)this.parameterIsOk.Value;
            }
            set
            {
                this.parameterIsOk.Value = value;
            }
        }

        public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldbuckle = new SqlParameter();
			this.parameterfldbuckle.ParameterName= "@fldbuckle";
			this.parameterfldbuckle.SqlDbType=SqlDbType.VarChar;
			this.parameterfldbuckle.Size=500;
			this.parameterfldbuckle.Direction=ParameterDirection.Output;
			base.m_cmd.Parameters.Add(this.parameterfldbuckle);
			//--------------------------------------------------------
			this.parameterfldAutoID = new SqlParameter();
			this.parameterfldAutoID.ParameterName= "@fldAutoID";
			this.parameterfldAutoID.SqlDbType=SqlDbType.VarChar;
            this.parameterfldAutoID.Size = 500;
			this.parameterfldAutoID.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldAutoID);
            //--------------------------------------------------------
            this.parameterIsOk = new SqlParameter();
            this.parameterIsOk.ParameterName = "@IsOk";
            this.parameterIsOk.SqlDbType = SqlDbType.Int;
            this.parameterIsOk.Size = 500;
            this.parameterIsOk.Direction = ParameterDirection.Output;
            base.m_cmd.Parameters.Add(this.parameterIsOk);
        }
	}
}