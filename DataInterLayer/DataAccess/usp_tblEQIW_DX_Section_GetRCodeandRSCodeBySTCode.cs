﻿//------------------------------------------------------------------------------
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

    public class usp_tblEQIW_DX_Section_GetRCodeandRSCodeBySTCode : BaseProcedure
    {
        private SqlParameter parameterfldSTCode;

        private SqlParameter parameterfldPLevel;

        private SqlParameter parameterfldYear;

        public usp_tblEQIW_DX_Section_GetRCodeandRSCodeBySTCode()
        {
            base.InitCommand("usp_tblEQIW_DX_Section_GetRCodeandRSCodeBySTCode");
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

        public System.String fldYear
        {
            get
            {
                return (System.String)this.parameterfldYear.Value;
            }
            set
            {
                this.parameterfldYear.Value = value;
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
            this.parameterfldPLevel = new SqlParameter();
            this.parameterfldPLevel.ParameterName = "@fldPLevel";
            this.parameterfldPLevel.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldPLevel.Size = 2;
            this.parameterfldPLevel.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldPLevel);
            //--------------------------------------------------------
            this.parameterfldYear = new SqlParameter();
            this.parameterfldYear.ParameterName = "@fldYear";
            this.parameterfldYear.SqlDbType = SqlDbType.VarChar;
            this.parameterfldYear.Size = 50;
            this.parameterfldYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldYear);
        }
    }
}
