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

    public class usp_tblEQIW_L_Basedata_Insert_byR : BaseProcedure
    {
        private SqlParameter parameterfldAutoID;

        private SqlParameter parameterfldSTCode;

        private SqlParameter parameterfldSTName;

        private SqlParameter parameterfldLCode;

        private SqlParameter parameterfldLName;

        private SqlParameter parameterfldLSCode;

        private SqlParameter parameterfldLSName;

        private SqlParameter parameterfldSAMPH;

        private SqlParameter parameterfldSAMPR;

        private SqlParameter parameterfldRSC;

        private SqlParameter parameterfldYear;

        private SqlParameter parameterfldMonth;

        private SqlParameter parameterfldDay;

        private SqlParameter parameterfldHour;

        private SqlParameter parameterfldMinute;

        private SqlParameter parameterfldItemCode;

        private SqlParameter parameterfldItemName;

        private SqlParameter parameterfldItemValue;

        private SqlParameter parameterfldSource;

        private SqlParameter parameterfldUserID;

        private SqlParameter parameterfldFlag;

        private SqlParameter parameterfldBReport;

        public usp_tblEQIW_L_Basedata_Insert_byR()
        {
            base.InitCommand("usp_tblEQIW_L_Basedata_Insert_byR");
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

        public System.String fldSTName
        {
            get
            {
                return (System.String)this.parameterfldSTName.Value;
            }
            set
            {
                this.parameterfldSTName.Value = value;
            }
        }

        public System.String fldLCode
        {
            get
            {
                return (System.String)this.parameterfldLCode.Value;
            }
            set
            {
                this.parameterfldLCode.Value = value;
            }
        }

        public System.String fldLName
        {
            get
            {
                return (System.String)this.parameterfldLName.Value;
            }
            set
            {
                this.parameterfldLName.Value = value;
            }
        }

        public System.String fldLSCode
        {
            get
            {
                return (System.String)this.parameterfldLSCode.Value;
            }
            set
            {
                this.parameterfldLSCode.Value = value;
            }
        }

        public System.String fldLSName
        {
            get
            {
                return (System.String)this.parameterfldLSName.Value;
            }
            set
            {
                this.parameterfldLSName.Value = value;
            }
        }

        public System.String fldSAMPH
        {
            get
            {
                return (System.String)this.parameterfldSAMPH.Value;
            }
            set
            {
                this.parameterfldSAMPH.Value = value;
            }
        }

        public System.String fldSAMPR
        {
            get
            {
                return (System.String)this.parameterfldSAMPR.Value;
            }
            set
            {
                this.parameterfldSAMPR.Value = value;
            }
        }

        public System.String fldRSC
        {
            get
            {
                return (System.String)this.parameterfldRSC.Value;
            }
            set
            {
                this.parameterfldRSC.Value = value;
            }
        }

        public System.Decimal fldYear
        {
            get
            {
                return (System.Decimal)this.parameterfldYear.Value;
            }
            set
            {
                this.parameterfldYear.Value = value;
            }
        }

        public System.Decimal fldMonth
        {
            get
            {
                return (System.Decimal)this.parameterfldMonth.Value;
            }
            set
            {
                this.parameterfldMonth.Value = value;
            }
        }

        public System.Decimal fldDay
        {
            get
            {
                return (System.Decimal)this.parameterfldDay.Value;
            }
            set
            {
                this.parameterfldDay.Value = value;
            }
        }

        public System.Decimal fldHour
        {
            get
            {
                return (System.Decimal)this.parameterfldHour.Value;
            }
            set
            {
                this.parameterfldHour.Value = value;
            }
        }

        public System.Decimal fldMinute
        {
            get
            {
                return (System.Decimal)this.parameterfldMinute.Value;
            }
            set
            {
                this.parameterfldMinute.Value = value;
            }
        }

        public System.String fldItemCode
        {
            get
            {
                return (System.String)this.parameterfldItemCode.Value;
            }
            set
            {
                this.parameterfldItemCode.Value = value;
            }
        }

        public System.String fldItemName
        {
            get
            {
                return (System.String)this.parameterfldItemName.Value;
            }
            set
            {
                this.parameterfldItemName.Value = value;
            }
        }

        public System.Decimal fldItemValue
        {
            get
            {
                return (System.Decimal)this.parameterfldItemValue.Value;
            }
            set
            {
                this.parameterfldItemValue.Value = value;
            }
        }

        public System.Int16 fldSource
        {
            get
            {
                return (System.Int16)this.parameterfldSource.Value;
            }
            set
            {
                this.parameterfldSource.Value = value;
            }
        }

        public System.Int32 fldUserID
        {
            get
            {
                return (System.Int32)this.parameterfldUserID.Value;
            }
            set
            {
                this.parameterfldUserID.Value = value;
            }
        }

        public System.Int16 fldFlag
        {
            get
            {
                return (System.Int16)this.parameterfldFlag.Value;
            }
            set
            {
                this.parameterfldFlag.Value = value;
            }
        }

        public System.Boolean fldBReport
        {
            get
            {
                return (System.Boolean)this.parameterfldBReport.Value;
            }
            set
            {
                this.parameterfldBReport.Value = value;
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
            this.parameterfldSTCode = new SqlParameter();
            this.parameterfldSTCode.ParameterName = "@fldSTCode";
            this.parameterfldSTCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldSTCode.Size = 12;
            this.parameterfldSTCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSTCode);
            //--------------------------------------------------------
            this.parameterfldSTName = new SqlParameter();
            this.parameterfldSTName.ParameterName = "@fldSTName";
            this.parameterfldSTName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldSTName.Size = 30;
            this.parameterfldSTName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSTName);
            //--------------------------------------------------------
            this.parameterfldLCode = new SqlParameter();
            this.parameterfldLCode.ParameterName = "@fldLCode";
            this.parameterfldLCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldLCode.Size = 12;
            this.parameterfldLCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldLCode);
            //--------------------------------------------------------
            this.parameterfldLName = new SqlParameter();
            this.parameterfldLName.ParameterName = "@fldLName";
            this.parameterfldLName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldLName.Size = 100;
            this.parameterfldLName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldLName);
            //--------------------------------------------------------
            this.parameterfldLSCode = new SqlParameter();
            this.parameterfldLSCode.ParameterName = "@fldLSCode";
            this.parameterfldLSCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldLSCode.Size = 12;
            this.parameterfldLSCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldLSCode);
            //--------------------------------------------------------
            this.parameterfldLSName = new SqlParameter();
            this.parameterfldLSName.ParameterName = "@fldLSName";
            this.parameterfldLSName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldLSName.Size = 100;
            this.parameterfldLSName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldLSName);
            //--------------------------------------------------------
            this.parameterfldSAMPH = new SqlParameter();
            this.parameterfldSAMPH.ParameterName = "@fldSAMPH";
            this.parameterfldSAMPH.SqlDbType = SqlDbType.VarChar;
            this.parameterfldSAMPH.Size = 12;
            this.parameterfldSAMPH.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSAMPH);
            //--------------------------------------------------------
            this.parameterfldSAMPR = new SqlParameter();
            this.parameterfldSAMPR.ParameterName = "@fldSAMPR";
            this.parameterfldSAMPR.SqlDbType = SqlDbType.VarChar;
            this.parameterfldSAMPR.Size = 12;
            this.parameterfldSAMPR.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSAMPR);
            //--------------------------------------------------------
            this.parameterfldRSC = new SqlParameter();
            this.parameterfldRSC.ParameterName = "@fldRSC";
            this.parameterfldRSC.SqlDbType = SqlDbType.VarChar;
            this.parameterfldRSC.Size = 10;
            this.parameterfldRSC.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldRSC);
            //--------------------------------------------------------
            this.parameterfldYear = new SqlParameter();
            this.parameterfldYear.ParameterName = "@fldYear";
            this.parameterfldYear.SqlDbType = SqlDbType.Decimal;
            this.parameterfldYear.Size = 5;
            this.parameterfldYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldYear);
            //--------------------------------------------------------
            this.parameterfldMonth = new SqlParameter();
            this.parameterfldMonth.ParameterName = "@fldMonth";
            this.parameterfldMonth.SqlDbType = SqlDbType.Decimal;
            this.parameterfldMonth.Size = 5;
            this.parameterfldMonth.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldMonth);
            //--------------------------------------------------------
            this.parameterfldDay = new SqlParameter();
            this.parameterfldDay.ParameterName = "@fldDay";
            this.parameterfldDay.SqlDbType = SqlDbType.Decimal;
            this.parameterfldDay.Size = 5;
            this.parameterfldDay.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldDay);
            //--------------------------------------------------------
            this.parameterfldHour = new SqlParameter();
            this.parameterfldHour.ParameterName = "@fldHour";
            this.parameterfldHour.SqlDbType = SqlDbType.Decimal;
            this.parameterfldHour.Size = 5;
            this.parameterfldHour.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldHour);
            //--------------------------------------------------------
            this.parameterfldMinute = new SqlParameter();
            this.parameterfldMinute.ParameterName = "@fldMinute";
            this.parameterfldMinute.SqlDbType = SqlDbType.Decimal;
            this.parameterfldMinute.Size = 5;
            this.parameterfldMinute.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldMinute);
            //--------------------------------------------------------
            this.parameterfldItemCode = new SqlParameter();
            this.parameterfldItemCode.ParameterName = "@fldItemCode";
            this.parameterfldItemCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldItemCode.Size = 10;
            this.parameterfldItemCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldItemCode);
            //--------------------------------------------------------
            this.parameterfldItemName = new SqlParameter();
            this.parameterfldItemName.ParameterName = "@fldItemName";
            this.parameterfldItemName.SqlDbType = SqlDbType.VarChar;
            this.parameterfldItemName.Size = 50;
            this.parameterfldItemName.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldItemName);
            //--------------------------------------------------------
            this.parameterfldItemValue = new SqlParameter();
            this.parameterfldItemValue.ParameterName = "@fldItemValue";
            this.parameterfldItemValue.SqlDbType = SqlDbType.Decimal;
            this.parameterfldItemValue.Size = 17;
            this.parameterfldItemValue.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldItemValue);
            //--------------------------------------------------------
            this.parameterfldSource = new SqlParameter();
            this.parameterfldSource.ParameterName = "@fldSource";
            this.parameterfldSource.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldSource.Size = 2;
            this.parameterfldSource.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldSource);
            //--------------------------------------------------------
            this.parameterfldUserID = new SqlParameter();
            this.parameterfldUserID.ParameterName = "@fldUserID";
            this.parameterfldUserID.SqlDbType = SqlDbType.Int;
            this.parameterfldUserID.Size = 4;
            this.parameterfldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldUserID);
            //--------------------------------------------------------
            this.parameterfldFlag = new SqlParameter();
            this.parameterfldFlag.ParameterName = "@fldFlag";
            this.parameterfldFlag.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldFlag.Size = 2;
            this.parameterfldFlag.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldFlag);
            //--------------------------------------------------------
            this.parameterfldBReport = new SqlParameter();
            this.parameterfldBReport.ParameterName = "@fldBReport";
            this.parameterfldBReport.SqlDbType = SqlDbType.Bit;
            this.parameterfldBReport.Size = 1;
            this.parameterfldBReport.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBReport);
        }
    }
}