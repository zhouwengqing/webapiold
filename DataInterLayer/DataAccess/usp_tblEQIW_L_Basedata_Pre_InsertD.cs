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

    public class usp_tblEQIW_L_Basedata_Pre_InsertD : BaseProcedure
    {
        private SqlParameter parameterfldAutoID;

        private SqlParameter parameterfldSTCode;

        private SqlParameter parameterfldRCode;

        private SqlParameter parameterfldRSCode;

        private SqlParameter parameterfldSAMPH;

        private SqlParameter parameterfldSAMPR;

        private SqlParameter parameterfldRSC;

        private SqlParameter parameterfldYear;

        private SqlParameter parameterfldMonth;

        private SqlParameter parameterfldDay;

        private SqlParameter parameterfldHour;

        private SqlParameter parameterfldMinute;

        private SqlParameter parameterfldItemCode;

        private SqlParameter parameterfldItemValue;

        private SqlParameter parameterfldSource;

        private SqlParameter parameterfldFlag;

        private SqlParameter parameterfldImport;

        private SqlParameter parameterfldCityID_Operate;

        private SqlParameter parameterfldCityID_Submit;

        private SqlParameter parameterfldUserID;

        private SqlParameter parameterfldDate_Operate;

        private SqlParameter parameterfldBatch;

        private SqlParameter parameterfldComment;

        private SqlParameter parameterold_fldAutoID;

        public usp_tblEQIW_L_Basedata_Pre_InsertD()
        {
            base.InitCommand("usp_tblEQIW_L_Basedata_Pre_InsertD");
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

        public System.String fldRSCode
        {
            get
            {
                return (System.String)this.parameterfldRSCode.Value;
            }
            set
            {
                this.parameterfldRSCode.Value = value;
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

        public System.Int16 fldImport
        {
            get
            {
                return (System.Int16)this.parameterfldImport.Value;
            }
            set
            {
                this.parameterfldImport.Value = value;
            }
        }

        public System.Int32 fldCityID_Operate
        {
            get
            {
                return (System.Int32)this.parameterfldCityID_Operate.Value;
            }
            set
            {
                this.parameterfldCityID_Operate.Value = value;
            }
        }

        public System.String fldCityID_Submit
        {
            get
            {
                return (System.String)this.parameterfldCityID_Submit.Value;
            }
            set
            {
                this.parameterfldCityID_Submit.Value = value;
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

        public System.DateTime fldDate_Operate
        {
            get
            {
                return (System.DateTime)this.parameterfldDate_Operate.Value;
            }
            set
            {
                this.parameterfldDate_Operate.Value = value;
            }
        }

        public System.String fldBatch
        {
            get
            {
                return (System.String)this.parameterfldBatch.Value;
            }
            set
            {
                this.parameterfldBatch.Value = value;
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

        public System.Int64 old_fldAutoID
        {
            get
            {
                return (System.Int64)this.parameterold_fldAutoID.Value;
            }
            set
            {
                this.parameterold_fldAutoID.Value = value;
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
            this.parameterfldRCode = new SqlParameter();
            this.parameterfldRCode.ParameterName = "@fldRCode";
            this.parameterfldRCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldRCode.Size = 12;
            this.parameterfldRCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldRCode);
            //--------------------------------------------------------
            this.parameterfldRSCode = new SqlParameter();
            this.parameterfldRSCode.ParameterName = "@fldRSCode";
            this.parameterfldRSCode.SqlDbType = SqlDbType.VarChar;
            this.parameterfldRSCode.Size = 12;
            this.parameterfldRSCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldRSCode);
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
            this.parameterfldFlag = new SqlParameter();
            this.parameterfldFlag.ParameterName = "@fldFlag";
            this.parameterfldFlag.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldFlag.Size = 2;
            this.parameterfldFlag.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldFlag);
            //--------------------------------------------------------
            this.parameterfldImport = new SqlParameter();
            this.parameterfldImport.ParameterName = "@fldImport";
            this.parameterfldImport.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldImport.Size = 2;
            this.parameterfldImport.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldImport);
            //--------------------------------------------------------
            this.parameterfldCityID_Operate = new SqlParameter();
            this.parameterfldCityID_Operate.ParameterName = "@fldCityID_Operate";
            this.parameterfldCityID_Operate.SqlDbType = SqlDbType.Int;
            this.parameterfldCityID_Operate.Size = 4;
            this.parameterfldCityID_Operate.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldCityID_Operate);
            //--------------------------------------------------------
            this.parameterfldCityID_Submit = new SqlParameter();
            this.parameterfldCityID_Submit.ParameterName = "@fldCityID_Submit";
            this.parameterfldCityID_Submit.SqlDbType = SqlDbType.VarChar;
            this.parameterfldCityID_Submit.Size = 100;
            this.parameterfldCityID_Submit.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldCityID_Submit);
            //--------------------------------------------------------
            this.parameterfldUserID = new SqlParameter();
            this.parameterfldUserID.ParameterName = "@fldUserID";
            this.parameterfldUserID.SqlDbType = SqlDbType.Int;
            this.parameterfldUserID.Size = 4;
            this.parameterfldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldUserID);
            //--------------------------------------------------------
            this.parameterfldDate_Operate = new SqlParameter();
            this.parameterfldDate_Operate.ParameterName = "@fldDate_Operate";
            this.parameterfldDate_Operate.SqlDbType = SqlDbType.DateTime;
            this.parameterfldDate_Operate.Size = 8;
            this.parameterfldDate_Operate.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldDate_Operate);
            //--------------------------------------------------------
            this.parameterfldBatch = new SqlParameter();
            this.parameterfldBatch.ParameterName = "@fldBatch";
            this.parameterfldBatch.SqlDbType = SqlDbType.VarChar;
            this.parameterfldBatch.Size = 50;
            this.parameterfldBatch.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldBatch);
            //--------------------------------------------------------
            this.parameterfldComment = new SqlParameter();
            this.parameterfldComment.ParameterName = "@fldComment";
            this.parameterfldComment.SqlDbType = SqlDbType.VarChar;
            this.parameterfldComment.Size = 1000;
            this.parameterfldComment.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldComment);
            //--------------------------------------------------------
            this.parameterold_fldAutoID = new SqlParameter();
            this.parameterold_fldAutoID.ParameterName = "@old_fldAutoID";
            this.parameterold_fldAutoID.SqlDbType = SqlDbType.BigInt;
            this.parameterold_fldAutoID.Size = 8;
            this.parameterold_fldAutoID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldAutoID);
        }
    }
}
