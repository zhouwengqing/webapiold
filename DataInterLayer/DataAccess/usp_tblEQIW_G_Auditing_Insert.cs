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

    public class usp_tblEQIW_G_Auditing_Insert : BaseProcedure
    {
        private SqlParameter parameterfldAutoID;

        private SqlParameter parameterfldBaseDataID;

        private SqlParameter parameterfldComment;

        public usp_tblEQIW_G_Auditing_Insert()
        {
            base.InitCommand("usp_tblEQIW_G_Auditing_Insert");
            ConfigParameter();
        }

        public System.Int64 fldAutoID
        {
            get
            {
                return (System.Int64)this.parameterfldAutoID.Value;
            }
            set
            {
                this.parameterfldAutoID.Value = value;
            }
        }

        public System.Int64 fldBaseDataID
        {
            get
            {
                return (System.Int64)this.parameterfldBaseDataID.Value;
            }
            set
            {
                this.parameterfldBaseDataID.Value = value;
            }
        }

        public System.String fldComment
        {
            get
            {
                return (System.String)this.parameterfldComment.Value;
            }
            set
            {
                this.parameterfldComment.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterfldAutoID = new SqlParameter();
            this.parameterfldAutoID.ParameterName = "@fldAutoID";
            this.parameterfldAutoID.SqlDbType = SqlDbType.BigInt;
            this.parameterfldAutoID.Size = 8;
            this.parameterfldAutoID.Direction = ParameterDirection.InputOutput;
            base.m_cmd.Parameters.Add(this.parameterfldAutoID);
            //--------------------------------------------------------
            this.parameterfldBaseDataID = new SqlParameter();
            this.parameterfldBaseDataID.ParameterName = "@fldBaseDataID";
            this.parameterfldBaseDataID.SqlDbType = SqlDbType.BigInt;
            this.parameterfldBaseDataID.Size = 8;
            this.parameterfldBaseDataID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBaseDataID);
            //--------------------------------------------------------
            this.parameterfldComment = new SqlParameter();
            this.parameterfldComment.ParameterName = "@fldComment";
            this.parameterfldComment.SqlDbType = SqlDbType.VarChar;
            this.parameterfldComment.Size = 1000;
            this.parameterfldComment.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldComment);
        }
    }
}