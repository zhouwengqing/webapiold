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

    public class usp_tblDT_DN_TempletInfo_ByAll_Select : BaseProcedure
    {
        private SqlParameter parametertype;
        private SqlParameter parameterfldModule;

        public usp_tblDT_DN_TempletInfo_ByAll_Select()
        {
            base.InitCommand("usp_tblDT_DN_TempletInfo_ByAll_Select");
            ConfigParameter();
        }

        public System.Int16 type
        {
            get
            {
                return (System.Int16)this.parametertype.Value;
            }
            set
            {
                this.parametertype.Value = value;
            }
        }

        public System.String fldModule
        {
            get
            {
                return (System.String)this.parameterfldModule.Value;
            }
            set
            {
                this.parameterfldModule.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parametertype = new SqlParameter();
            this.parametertype.ParameterName = "@type";
            this.parametertype.SqlDbType = SqlDbType.SmallInt;
            this.parametertype.Size = 2;
            this.parametertype.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parametertype);

            //--------------------------------------------------------
            this.parameterfldModule = new SqlParameter();
            this.parameterfldModule.ParameterName = "@fldModule";
            this.parameterfldModule.SqlDbType = SqlDbType.VarChar;
            this.parameterfldModule.Size = 20;
            this.parameterfldModule.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldModule);
        }


    }
}
