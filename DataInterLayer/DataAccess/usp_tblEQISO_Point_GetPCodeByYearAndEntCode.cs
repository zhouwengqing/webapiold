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

    public class usp_tblEQISO_Point_GetPCodeByYearAndEntCode : BaseProcedure
    {
        private SqlParameter parameterfldSTCode;

        private SqlParameter parameterfldEntCode;

        private SqlParameter parameterfldYear;

        private SqlParameter parameterdatatype;

        public usp_tblEQISO_Point_GetPCodeByYearAndEntCode()
        {
            base.InitCommand("usp_tblEQISO_Point_GetPCodeByYearAndEntCode");
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

        public System.String fldEntCode
        {
            get
            {
                return (System.String)this.parameterfldEntCode.Value;
            }
            set
            {
                this.parameterfldEntCode.Value = value;
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

        public System.String datatype
        {
            get
            {
                return (System.String)this.parameterdatatype.Value;
            }
            set
            {
                this.parameterdatatype.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterfldSTCode = new SqlParameter();
            this.parameterfldSTCode.ParameterName = "@fldSTCode";
            this.parameterfldSTCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldSTCode.Size = -1;
            this.parameterfldSTCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSTCode);
            //--------------------------------------------------------
            this.parameterfldEntCode = new SqlParameter();
            this.parameterfldEntCode.ParameterName = "@fldEntCode";
            this.parameterfldEntCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldEntCode.Size = -1;
            this.parameterfldEntCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldEntCode);
            //--------------------------------------------------------
            this.parameterfldYear = new SqlParameter();
            this.parameterfldYear.ParameterName = "@fldYear";
            this.parameterfldYear.SqlDbType = SqlDbType.Int;
            this.parameterfldYear.Size = 4;
            this.parameterfldYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldYear);
            //--------------------------------------------------------
            this.parameterdatatype = new SqlParameter();
            this.parameterdatatype.ParameterName = "@datatype";
            this.parameterdatatype.SqlDbType = SqlDbType.VarChar;
            this.parameterdatatype.Size = -1;
            this.parameterdatatype.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterdatatype);
        }
    }
}
