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

    public class inserttbljdpay : BaseProcedure
    {
        private SqlParameter parameterfldOrderID;

        private SqlParameter parameterfldtransactionnum;

        private SqlParameter parameterfldPayUrl;

        private SqlParameter parameterfldTime;

        public inserttbljdpay()
        {
            base.InitCommand("inserttbljdpay");
            ConfigParameter();
        }

        public System.String fldOrderID
        {
            get
            {
                return (System.String)this.parameterfldOrderID.Value;
            }
            set
            {
                this.parameterfldOrderID.Value = value;
            }
        }

        public System.String fldtransactionnum
        {
            get
            {
                return (System.String)this.parameterfldtransactionnum.Value;
            }
            set
            {
                this.parameterfldtransactionnum.Value = value;
            }
        }

        public System.String fldPayUrl
        {
            get
            {
                return (System.String)this.parameterfldPayUrl.Value;
            }
            set
            {
                this.parameterfldPayUrl.Value = value;
            }
        }

        public System.DateTime fldTime
        {
            get
            {
                return (System.DateTime)this.parameterfldTime.Value;
            }
            set
            {
                this.parameterfldTime.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterfldOrderID = new SqlParameter();
            this.parameterfldOrderID.ParameterName = "@fldOrderID";
            this.parameterfldOrderID.SqlDbType = SqlDbType.VarChar;
            this.parameterfldOrderID.Size = -1;
            this.parameterfldOrderID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldOrderID);
            //--------------------------------------------------------
            this.parameterfldtransactionnum = new SqlParameter();
            this.parameterfldtransactionnum.ParameterName = "@fldtransactionnum";
            this.parameterfldtransactionnum.SqlDbType = SqlDbType.VarChar;
            this.parameterfldtransactionnum.Size = -1;
            this.parameterfldtransactionnum.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldtransactionnum);
            //--------------------------------------------------------
            this.parameterfldPayUrl = new SqlParameter();
            this.parameterfldPayUrl.ParameterName = "@fldPayUrl";
            this.parameterfldPayUrl.SqlDbType = SqlDbType.VarChar;
            this.parameterfldPayUrl.Size = -1;
            this.parameterfldPayUrl.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldPayUrl);
            //--------------------------------------------------------
            this.parameterfldTime = new SqlParameter();
            this.parameterfldTime.ParameterName = "@fldTime";
            this.parameterfldTime.SqlDbType = SqlDbType.DateTime;
            this.parameterfldTime.Size = 8;
            this.parameterfldTime.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldTime);
        }
    }
}
