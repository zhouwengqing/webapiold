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

    public class usp_tbleqi_ThreeVerifyIfUpdateOrInsert : BaseProcedure
    {
        private SqlParameter parameterfldAutoID;

        private SqlParameter parameterfldType;

        private SqlParameter parameterfldTypeID;

        private SqlParameter parameterfldComment;

        private SqlParameter parameterfldAudType;

        private SqlParameter parameterfldDataTime;

        private SqlParameter parameterfldPName;

        private SqlParameter parameterthreelevel;

        public usp_tbleqi_ThreeVerifyIfUpdateOrInsert()
        {
            base.InitCommand("usp_tbleqi_ThreeVerifyIfUpdateOrInsert");
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

        public System.String fldType
        {
            get
            {
                return (System.String)this.parameterfldType.Value;
            }
            set
            {
                this.parameterfldType.Value = value;
            }
        }

        public System.Int64 fldTypeID
        {
            get
            {
                return (System.Int64)this.parameterfldTypeID.Value;
            }
            set
            {
                this.parameterfldTypeID.Value = value;
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

        public System.String fldAudType
        {
            get
            {
                return (System.String)this.parameterfldAudType.Value;
            }
            set
            {
                this.parameterfldAudType.Value = value;
            }
        }

        public System.String fldDataTime
        {
            get
            {
                return (System.String)this.parameterfldDataTime.Value;
            }
            set
            {
                this.parameterfldDataTime.Value = value;
            }
        }

        public System.String fldPName
        {
            get
            {
                return (System.String)this.parameterfldPName.Value;
            }
            set
            {
                this.parameterfldPName.Value = value;
            }
        }

        public System.String threelevel
        {
            get
            {
                return (System.String)this.parameterthreelevel.Value;
            }
            set
            {
                this.parameterthreelevel.Value = value;
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
            this.parameterfldType = new SqlParameter();
            this.parameterfldType.ParameterName = "@fldType";
            this.parameterfldType.SqlDbType = SqlDbType.VarChar;
            this.parameterfldType.Size = 50;
            this.parameterfldType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldType);
            //--------------------------------------------------------
            this.parameterfldTypeID = new SqlParameter();
            this.parameterfldTypeID.ParameterName = "@fldTypeID";
            this.parameterfldTypeID.SqlDbType = SqlDbType.BigInt;
            this.parameterfldTypeID.Size = 8;
            this.parameterfldTypeID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldTypeID);
            //--------------------------------------------------------
            this.parameterfldComment = new SqlParameter();
            this.parameterfldComment.ParameterName = "@fldComment";
            this.parameterfldComment.SqlDbType = SqlDbType.VarChar;
            this.parameterfldComment.Size = 500;
            this.parameterfldComment.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldComment);
            //--------------------------------------------------------
            this.parameterfldAudType = new SqlParameter();
            this.parameterfldAudType.ParameterName = "@fldAudType";
            this.parameterfldAudType.SqlDbType = SqlDbType.VarChar;
            this.parameterfldAudType.Size = 50;
            this.parameterfldAudType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldAudType);
            //--------------------------------------------------------
            this.parameterfldDataTime = new SqlParameter();
            this.parameterfldDataTime.ParameterName = "@fldDataTime";
            this.parameterfldDataTime.SqlDbType = SqlDbType.VarChar;
            this.parameterfldDataTime.Size = 50;
            this.parameterfldDataTime.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldDataTime);
            //--------------------------------------------------------
            this.parameterfldPName = new SqlParameter();
            this.parameterfldPName.ParameterName = "@fldPName";
            this.parameterfldPName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldPName.Size = 100;
            this.parameterfldPName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldPName);
            //--------------------------------------------------------
            this.parameterthreelevel = new SqlParameter();
            this.parameterthreelevel.ParameterName = "@threelevel";
            this.parameterthreelevel.SqlDbType = SqlDbType.VarChar;
            this.parameterthreelevel.Size = 50;
            this.parameterthreelevel.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterthreelevel);
        }
    }
}