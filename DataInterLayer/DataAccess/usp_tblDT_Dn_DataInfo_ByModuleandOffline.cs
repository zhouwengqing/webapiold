using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblDT_Dn_DataInfo_ByModuleandOffline : BaseProcedure
    {
        private SqlParameter parameteroffline;

        public usp_tblDT_Dn_DataInfo_ByModuleandOffline()
		{
            base.InitCommand("usp_tblDT_Dn_DataInfo_ByModuleandOffline");
			ConfigParameter();
		}

        public System.Int16 offline
		{
			get
			{
                return (System.Int16)this.parameteroffline.Value;
			}
			set
			{
                this.parameteroffline.Value = value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
            this.parameteroffline = new SqlParameter();
            this.parameteroffline.ParameterName = "@offline";
            this.parameteroffline.SqlDbType = SqlDbType.SmallInt;
            this.parameteroffline.Size = 2;
            this.parameteroffline.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameteroffline);
		}
    }
}
