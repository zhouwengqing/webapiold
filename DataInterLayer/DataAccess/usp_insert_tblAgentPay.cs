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

    public class usp_insert_tblAgentPay : BaseProcedure
    {
        private SqlParameter parameterfldAutoID;

        private SqlParameter parameterfldCreateTime;

        private SqlParameter parameterfldtransactionnum;

        private SqlParameter parameterfldChannelnum;

        private SqlParameter parameterfldOrdernum;

        private SqlParameter parameterfldMerchID;

        private SqlParameter parameterfldPayAmount;

        private SqlParameter parameterfldPayState;

        private SqlParameter parameterfldServiceCharge;

        private SqlParameter parameterfldActualAmount;

        private SqlParameter parameterfldAccountname;

        private SqlParameter parameterfldBankCardId;

        private SqlParameter parameterfldBankName;

        private SqlParameter parameterfldChannelID;

        private SqlParameter parameterfldLaunchIP;

        private SqlParameter parameterfldNotice;

        private SqlParameter parameterfldchangstautetime;

        private SqlParameter parameterfldtransactiontime;

        private SqlParameter parameterfldRtefundAmount;

        private SqlParameter parameterfldBankType;

        private SqlParameter parameterfldSettlementAmount;

        private SqlParameter parameterfldBankcity;

        private SqlParameter parameterfldBankprovince;

        private SqlParameter parameterfldBankbranch;

        private SqlParameter parameterfldBankTelephoneNo;

        private SqlParameter parameterfldIdCard;

        private SqlParameter parameterfldCardType;

        public usp_insert_tblAgentPay()
        {
            base.InitCommand("usp_insert_tblAgentPay");
            ConfigParameter();
        }

        public System.Int32 fldAutoID
        {
            get
            {
                return (System.Int32)this.parameterfldAutoID.Value;
            }
            set
            {
                this.parameterfldAutoID.Value = value;
            }
        }

        public System.DateTime fldCreateTime
        {
            get
            {
                return (System.DateTime)this.parameterfldCreateTime.Value;
            }
            set
            {
                this.parameterfldCreateTime.Value = value;
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

        public System.String fldChannelnum
        {
            get
            {
                return (System.String)this.parameterfldChannelnum.Value;
            }
            set
            {
                this.parameterfldChannelnum.Value = value;
            }
        }

        public System.String fldOrdernum
        {
            get
            {
                return (System.String)this.parameterfldOrdernum.Value;
            }
            set
            {
                this.parameterfldOrdernum.Value = value;
            }
        }

        public System.String fldMerchID
        {
            get
            {
                return (System.String)this.parameterfldMerchID.Value;
            }
            set
            {
                this.parameterfldMerchID.Value = value;
            }
        }

        public System.Decimal fldPayAmount
        {
            get
            {
                return (System.Decimal)this.parameterfldPayAmount.Value;
            }
            set
            {
                this.parameterfldPayAmount.Value = value;
            }
        }

        public System.String fldPayState
        {
            get
            {
                return (System.String)this.parameterfldPayState.Value;
            }
            set
            {
                this.parameterfldPayState.Value = value;
            }
        }

        public System.Decimal fldServiceCharge
        {
            get
            {
                return (System.Decimal)this.parameterfldServiceCharge.Value;
            }
            set
            {
                this.parameterfldServiceCharge.Value = value;
            }
        }

        public System.Decimal fldActualAmount
        {
            get
            {
                return (System.Decimal)this.parameterfldActualAmount.Value;
            }
            set
            {
                this.parameterfldActualAmount.Value = value;
            }
        }

        public System.String fldAccountname
        {
            get
            {
                return (System.String)this.parameterfldAccountname.Value;
            }
            set
            {
                this.parameterfldAccountname.Value = value;
            }
        }

        public System.String fldBankCardId
        {
            get
            {
                return (System.String)this.parameterfldBankCardId.Value;
            }
            set
            {
                this.parameterfldBankCardId.Value = value;
            }
        }

        public System.String fldBankName
        {
            get
            {
                return (System.String)this.parameterfldBankName.Value;
            }
            set
            {
                this.parameterfldBankName.Value = value;
            }
        }

        public System.String fldChannelID
        {
            get
            {
                return (System.String)this.parameterfldChannelID.Value;
            }
            set
            {
                this.parameterfldChannelID.Value = value;
            }
        }

        public System.String fldLaunchIP
        {
            get
            {
                return (System.String)this.parameterfldLaunchIP.Value;
            }
            set
            {
                this.parameterfldLaunchIP.Value = value;
            }
        }

        public System.String fldNotice
        {
            get
            {
                return (System.String)this.parameterfldNotice.Value;
            }
            set
            {
                this.parameterfldNotice.Value = value;
            }
        }

        public System.DateTime fldchangstautetime
        {
            get
            {
                return (System.DateTime)this.parameterfldchangstautetime.Value;
            }
            set
            {
                this.parameterfldchangstautetime.Value = value;
            }
        }

        public System.DateTime fldtransactiontime
        {
            get
            {
                return (System.DateTime)this.parameterfldtransactiontime.Value;
            }
            set
            {
                this.parameterfldtransactiontime.Value = value;
            }
        }

        public System.Decimal fldRtefundAmount
        {
            get
            {
                return (System.Decimal)this.parameterfldRtefundAmount.Value;
            }
            set
            {
                this.parameterfldRtefundAmount.Value = value;
            }
        }

        public System.String fldBankType
        {
            get
            {
                return (System.String)this.parameterfldBankType.Value;
            }
            set
            {
                this.parameterfldBankType.Value = value;
            }
        }

        public System.Decimal fldSettlementAmount
        {
            get
            {
                return (System.Decimal)this.parameterfldSettlementAmount.Value;
            }
            set
            {
                this.parameterfldSettlementAmount.Value = value;
            }
        }

        public System.String fldBankcity
        {
            get
            {
                return (System.String)this.parameterfldBankcity.Value;
            }
            set
            {
                this.parameterfldBankcity.Value = value;
            }
        }

        public System.String fldBankprovince
        {
            get
            {
                return (System.String)this.parameterfldBankprovince.Value;
            }
            set
            {
                this.parameterfldBankprovince.Value = value;
            }
        }

        public System.String fldBankbranch
        {
            get
            {
                return (System.String)this.parameterfldBankbranch.Value;
            }
            set
            {
                this.parameterfldBankbranch.Value = value;
            }
        }

        public System.String fldBankTelephoneNo
        {
            get
            {
                return (System.String)this.parameterfldBankTelephoneNo.Value;
            }
            set
            {
                this.parameterfldBankTelephoneNo.Value = value;
            }
        }

        public System.String fldIdCard
        {
            get
            {
                return (System.String)this.parameterfldIdCard.Value;
            }
            set
            {
                this.parameterfldIdCard.Value = value;
            }
        }

        public System.String fldCardType
        {
            get
            {
                return (System.String)this.parameterfldCardType.Value;
            }
            set
            {
                this.parameterfldCardType.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterfldAutoID = new SqlParameter();
            this.parameterfldAutoID.ParameterName = "@fldAutoID";
            this.parameterfldAutoID.SqlDbType = SqlDbType.Int;
            this.parameterfldAutoID.Size = 4;
            this.parameterfldAutoID.Direction = ParameterDirection.InputOutput;
            base.m_cmd.Parameters.Add(this.parameterfldAutoID);
            //--------------------------------------------------------
            this.parameterfldCreateTime = new SqlParameter();
            this.parameterfldCreateTime.ParameterName = "@fldCreateTime";
            this.parameterfldCreateTime.SqlDbType = SqlDbType.DateTime;
            this.parameterfldCreateTime.Size = 8;
            this.parameterfldCreateTime.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldCreateTime);
            //--------------------------------------------------------
            this.parameterfldtransactionnum = new SqlParameter();
            this.parameterfldtransactionnum.ParameterName = "@fldtransactionnum";
            this.parameterfldtransactionnum.SqlDbType = SqlDbType.VarChar;
            this.parameterfldtransactionnum.Size = 50;
            this.parameterfldtransactionnum.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldtransactionnum);
            //--------------------------------------------------------
            this.parameterfldChannelnum = new SqlParameter();
            this.parameterfldChannelnum.ParameterName = "@fldChannelnum";
            this.parameterfldChannelnum.SqlDbType = SqlDbType.VarChar;
            this.parameterfldChannelnum.Size = 50;
            this.parameterfldChannelnum.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldChannelnum);
            //--------------------------------------------------------
            this.parameterfldOrdernum = new SqlParameter();
            this.parameterfldOrdernum.ParameterName = "@fldOrdernum";
            this.parameterfldOrdernum.SqlDbType = SqlDbType.VarChar;
            this.parameterfldOrdernum.Size = 50;
            this.parameterfldOrdernum.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldOrdernum);
            //--------------------------------------------------------
            this.parameterfldMerchID = new SqlParameter();
            this.parameterfldMerchID.ParameterName = "@fldMerchID";
            this.parameterfldMerchID.SqlDbType = SqlDbType.VarChar;
            this.parameterfldMerchID.Size = 50;
            this.parameterfldMerchID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldMerchID);
            //--------------------------------------------------------
            this.parameterfldPayAmount = new SqlParameter();
            this.parameterfldPayAmount.ParameterName = "@fldPayAmount";
            this.parameterfldPayAmount.SqlDbType = SqlDbType.Decimal;
            this.parameterfldPayAmount.Size = 17;
            this.parameterfldPayAmount.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldPayAmount);
            //--------------------------------------------------------
            this.parameterfldPayState = new SqlParameter();
            this.parameterfldPayState.ParameterName = "@fldPayState";
            this.parameterfldPayState.SqlDbType = SqlDbType.VarChar;
            this.parameterfldPayState.Size = 50;
            this.parameterfldPayState.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldPayState);
            //--------------------------------------------------------
            this.parameterfldServiceCharge = new SqlParameter();
            this.parameterfldServiceCharge.ParameterName = "@fldServiceCharge";
            this.parameterfldServiceCharge.SqlDbType = SqlDbType.Decimal;
            this.parameterfldServiceCharge.Size = 17;
            this.parameterfldServiceCharge.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldServiceCharge);
            //--------------------------------------------------------
            this.parameterfldActualAmount = new SqlParameter();
            this.parameterfldActualAmount.ParameterName = "@fldActualAmount";
            this.parameterfldActualAmount.SqlDbType = SqlDbType.Decimal;
            this.parameterfldActualAmount.Size = 17;
            this.parameterfldActualAmount.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldActualAmount);
            //--------------------------------------------------------
            this.parameterfldAccountname = new SqlParameter();
            this.parameterfldAccountname.ParameterName = "@fldAccountname";
            this.parameterfldAccountname.SqlDbType = SqlDbType.VarChar;
            this.parameterfldAccountname.Size = 50;
            this.parameterfldAccountname.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldAccountname);
            //--------------------------------------------------------
            this.parameterfldBankCardId = new SqlParameter();
            this.parameterfldBankCardId.ParameterName = "@fldBankCardId";
            this.parameterfldBankCardId.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBankCardId.Size = 50;
            this.parameterfldBankCardId.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBankCardId);
            //--------------------------------------------------------
            this.parameterfldBankName = new SqlParameter();
            this.parameterfldBankName.ParameterName = "@fldBankName";
            this.parameterfldBankName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBankName.Size = 50;
            this.parameterfldBankName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBankName);
            //--------------------------------------------------------
            this.parameterfldChannelID = new SqlParameter();
            this.parameterfldChannelID.ParameterName = "@fldChannelID";
            this.parameterfldChannelID.SqlDbType = SqlDbType.VarChar;
            this.parameterfldChannelID.Size = 50;
            this.parameterfldChannelID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldChannelID);
            //--------------------------------------------------------
            this.parameterfldLaunchIP = new SqlParameter();
            this.parameterfldLaunchIP.ParameterName = "@fldLaunchIP";
            this.parameterfldLaunchIP.SqlDbType = SqlDbType.VarChar;
            this.parameterfldLaunchIP.Size = 50;
            this.parameterfldLaunchIP.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldLaunchIP);
            //--------------------------------------------------------
            this.parameterfldNotice = new SqlParameter();
            this.parameterfldNotice.ParameterName = "@fldNotice";
            this.parameterfldNotice.SqlDbType = SqlDbType.VarChar;
            this.parameterfldNotice.Size = 50;
            this.parameterfldNotice.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldNotice);
            //--------------------------------------------------------
            this.parameterfldchangstautetime = new SqlParameter();
            this.parameterfldchangstautetime.ParameterName = "@fldchangstautetime";
            this.parameterfldchangstautetime.SqlDbType = SqlDbType.DateTime;
            this.parameterfldchangstautetime.Size = 8;
            this.parameterfldchangstautetime.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldchangstautetime);
            //--------------------------------------------------------
            this.parameterfldtransactiontime = new SqlParameter();
            this.parameterfldtransactiontime.ParameterName = "@fldtransactiontime";
            this.parameterfldtransactiontime.SqlDbType = SqlDbType.DateTime;
            this.parameterfldtransactiontime.Size = 8;
            this.parameterfldtransactiontime.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldtransactiontime);
            //--------------------------------------------------------
            this.parameterfldRtefundAmount = new SqlParameter();
            this.parameterfldRtefundAmount.ParameterName = "@fldRtefundAmount";
            this.parameterfldRtefundAmount.SqlDbType = SqlDbType.Decimal;
            this.parameterfldRtefundAmount.Size = 17;
            this.parameterfldRtefundAmount.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldRtefundAmount);
            //--------------------------------------------------------
            this.parameterfldBankType = new SqlParameter();
            this.parameterfldBankType.ParameterName = "@fldBankType";
            this.parameterfldBankType.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBankType.Size = 50;
            this.parameterfldBankType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBankType);
            //--------------------------------------------------------
            this.parameterfldSettlementAmount = new SqlParameter();
            this.parameterfldSettlementAmount.ParameterName = "@fldSettlementAmount";
            this.parameterfldSettlementAmount.SqlDbType = SqlDbType.Decimal;
            this.parameterfldSettlementAmount.Size = 17;
            this.parameterfldSettlementAmount.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSettlementAmount);
            //--------------------------------------------------------
            this.parameterfldBankcity = new SqlParameter();
            this.parameterfldBankcity.ParameterName = "@fldBankcity";
            this.parameterfldBankcity.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBankcity.Size = 50;
            this.parameterfldBankcity.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBankcity);
            //--------------------------------------------------------
            this.parameterfldBankprovince = new SqlParameter();
            this.parameterfldBankprovince.ParameterName = "@fldBankprovince";
            this.parameterfldBankprovince.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBankprovince.Size = 50;
            this.parameterfldBankprovince.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBankprovince);
            //--------------------------------------------------------
            this.parameterfldBankbranch = new SqlParameter();
            this.parameterfldBankbranch.ParameterName = "@fldBankbranch";
            this.parameterfldBankbranch.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBankbranch.Size = 50;
            this.parameterfldBankbranch.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBankbranch);
            //--------------------------------------------------------
            this.parameterfldBankTelephoneNo = new SqlParameter();
            this.parameterfldBankTelephoneNo.ParameterName = "@fldBankTelephoneNo";
            this.parameterfldBankTelephoneNo.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBankTelephoneNo.Size = 50;
            this.parameterfldBankTelephoneNo.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBankTelephoneNo);
            //--------------------------------------------------------
            this.parameterfldIdCard = new SqlParameter();
            this.parameterfldIdCard.ParameterName = "@fldIdCard";
            this.parameterfldIdCard.SqlDbType = SqlDbType.VarChar;
            this.parameterfldIdCard.Size = 50;
            this.parameterfldIdCard.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldIdCard);
            //--------------------------------------------------------
            this.parameterfldCardType = new SqlParameter();
            this.parameterfldCardType.ParameterName = "@fldCardType";
            this.parameterfldCardType.SqlDbType = SqlDbType.VarChar;
            this.parameterfldCardType.Size = 50;
            this.parameterfldCardType.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldCardType);
        }
    }
}
