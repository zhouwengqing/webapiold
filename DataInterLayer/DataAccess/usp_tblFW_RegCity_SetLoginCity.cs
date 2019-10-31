using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;
using System.Reflection;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblFW_RegCity_SetLoginCity : BaseProcedure
    {
        private SqlParameter parameter_fldSTCode;

        public usp_tblFW_RegCity_SetLoginCity()
        {
            base.InitCommand("usp_tblFW_RegCity_SetLoginCity");
            ConfigParameter();
        }

        public System.String fldSTCode
        {
            get
            {
                return (System.String)this.parameter_fldSTCode.Value;
            }
            set
            {
                this.parameter_fldSTCode.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameter_fldSTCode = new SqlParameter();
            this.parameter_fldSTCode.ParameterName = "@fldSTCode";
            this.parameter_fldSTCode.SqlDbType = SqlDbType.VarChar;
            this.parameter_fldSTCode.Size = 12;
            this.parameter_fldSTCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameter_fldSTCode);
        }
    }
}
