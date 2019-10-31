using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblEQIW_D_Section_GetRSCode : BaseProcedure
    {
        private SqlParameter parameterfldSTCode;

        private SqlParameter parameterfldRCode;

        private SqlParameter parameterfldSLevel;

        private SqlParameter parameterinclude;

        private SqlParameter parameterfldYear;

        public usp_tblEQIW_D_Section_GetRSCode()
        {
            base.InitCommand("usp_tblEQIW_D_Section_GetRSCode");
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
                this.parameterfldSTCode.Value = value;
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


        public System.String fldRCode
        {
            get
            {
                return (System.String)this.parameterfldRCode.Value;
            }
            set
            {
                this.parameterfldRCode.Value = value;
            }
        }

        public System.Int16 fldSLevel
        {
            get
            {
                return (System.Int16)this.parameterfldSLevel.Value;
            }
            set
            {
                this.parameterfldSLevel.Value = value;
            }
        }

        public System.Int32 include
        {
            get
            {
                return (System.Int32)this.parameterinclude.Value;
            }
            set
            {
                this.parameterinclude.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterfldSTCode = new SqlParameter();
            this.parameterfldSTCode.ParameterName = "@fldSTCode";
            this.parameterfldSTCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldSTCode.Size = 12;
            this.parameterfldSTCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSTCode);
            //--------------------------------------------------------
            this.parameterfldRCode = new SqlParameter();
            this.parameterfldRCode.ParameterName = "@fldRCode";
            this.parameterfldRCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldRCode.Size = 12;
            this.parameterfldRCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldRCode);
            //--------------------------------------------------------
            this.parameterfldSLevel = new SqlParameter();
            this.parameterfldSLevel.ParameterName = "@fldSLevel";
            this.parameterfldSLevel.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldSLevel.Size = 2;
            this.parameterfldSLevel.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSLevel);
            //--------------------------------------------------------
            this.parameterinclude = new SqlParameter();
            this.parameterinclude.ParameterName = "@include";
            this.parameterinclude.SqlDbType = SqlDbType.Int;
            this.parameterinclude.Size = 4;
            this.parameterinclude.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterinclude);
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
