﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblEQIW_D_Section_GetRCodeBySTCode : BaseProcedure
    {
        private SqlParameter parameterfldSTCode;
        private SqlParameter parameterfldYear;
        private SqlParameter parameterfldPLevel;
        private SqlParameter parameterinclude;


        public usp_tblEQIW_D_Section_GetRCodeBySTCode()
        {
            base.InitCommand("usp_tblEQIW_D_Section_GetRCodeBySTCode");
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

        public System.Int16 fldPLevel
        {
            get
            {
                return (System.Int16)this.parameterfldPLevel.Value;
            }
            set
            {
                this.parameterfldPLevel.Value = value;
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
            this.parameterfldYear = new SqlParameter();
            this.parameterfldYear.ParameterName = "@fldYear";
            this.parameterfldYear.SqlDbType = SqlDbType.Int;
            this.parameterfldYear.Size = 4;
            this.parameterfldYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldYear);

            //--------------------------------------------------------
            this.parameterfldPLevel = new SqlParameter();
            this.parameterfldPLevel.ParameterName = "@fldPLevel";
            this.parameterfldPLevel.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldPLevel.Size = 2;
            this.parameterfldPLevel.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldPLevel);
            //--------------------------------------------------------
            this.parameterinclude = new SqlParameter();
            this.parameterinclude.ParameterName = "@include";
            this.parameterinclude.SqlDbType = SqlDbType.Int;
            this.parameterinclude.Size = 4;
            this.parameterinclude.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterinclude);
        }
    }
}
