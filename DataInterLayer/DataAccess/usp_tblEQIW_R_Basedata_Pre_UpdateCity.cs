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

    public class usp_tblEQIW_R_Basedata_Pre_UpdateCity : BaseProcedure
    {
        private SqlParameter parameterold_fldAutoID;

        private SqlParameter parameterold_fldSTCode;

        private SqlParameter parameterold_fldRCode;

        private SqlParameter parameterold_fldRSCode;

        private SqlParameter parameterold_fldSAMPH;

        private SqlParameter parameterold_fldSAMPR;

        private SqlParameter parameterold_fldRSC;

        private SqlParameter parameterold_fldYear;

        private SqlParameter parameterold_fldMonth;

        private SqlParameter parameterold_fldDay;

        private SqlParameter parameterold_fldHour;

        private SqlParameter parameterold_fldMinute;

        private SqlParameter parameterold_fldItemCode;

        private SqlParameter parameterold_fldItemValue;

        private SqlParameter parameterold_fldSource;

        private SqlParameter parameterold_fldFlag;

        private SqlParameter parameterold_fldCityID_Operate;

        private SqlParameter parameterold_fldCityID_Submit;

        private SqlParameter parameterold_fldUserID;

        private SqlParameter parameternew_fldCityID_Operate;

        private SqlParameter parameternew_fldCityID_Submit;

        private SqlParameter parameternew_fldFlag;

        private SqlParameter parameternew_fldDate_Operate;

        public usp_tblEQIW_R_Basedata_Pre_UpdateCity()
        {
            base.InitCommand("usp_tblEQIW_R_Basedata_Pre_UpdateCity");
            ConfigParameter();
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

        public System.String old_fldSTCode
        {
            get
            {
                return (System.String)this.parameterold_fldSTCode.Value;
            }
            set
            {
                this.parameterold_fldSTCode.Value = value;
            }
        }

        public System.String old_fldRCode
        {
            get
            {
                return (System.String)this.parameterold_fldRCode.Value;
            }
            set
            {
                this.parameterold_fldRCode.Value = value;
            }
        }

        public System.String old_fldRSCode
        {
            get
            {
                return (System.String)this.parameterold_fldRSCode.Value;
            }
            set
            {
                this.parameterold_fldRSCode.Value = value;
            }
        }

        public System.String old_fldSAMPH
        {
            get
            {
                return (System.String)this.parameterold_fldSAMPH.Value;
            }
            set
            {
                this.parameterold_fldSAMPH.Value = value;
            }
        }

        public System.String old_fldSAMPR
        {
            get
            {
                return (System.String)this.parameterold_fldSAMPR.Value;
            }
            set
            {
                this.parameterold_fldSAMPR.Value = value;
            }
        }

        public System.String old_fldRSC
        {
            get
            {
                return (System.String)this.parameterold_fldRSC.Value;
            }
            set
            {
                this.parameterold_fldRSC.Value = value;
            }
        }

        public System.Decimal old_fldYear
        {
            get
            {
                return (System.Decimal)this.parameterold_fldYear.Value;
            }
            set
            {
                this.parameterold_fldYear.Value = value;
            }
        }

        public System.Decimal old_fldMonth
        {
            get
            {
                return (System.Decimal)this.parameterold_fldMonth.Value;
            }
            set
            {
                this.parameterold_fldMonth.Value = value;
            }
        }

        public System.Decimal old_fldDay
        {
            get
            {
                return (System.Decimal)this.parameterold_fldDay.Value;
            }
            set
            {
                this.parameterold_fldDay.Value = value;
            }
        }

        public System.Decimal old_fldHour
        {
            get
            {
                return (System.Decimal)this.parameterold_fldHour.Value;
            }
            set
            {
                this.parameterold_fldHour.Value = value;
            }
        }

        public System.Decimal old_fldMinute
        {
            get
            {
                return (System.Decimal)this.parameterold_fldMinute.Value;
            }
            set
            {
                this.parameterold_fldMinute.Value = value;
            }
        }

        public System.String old_fldItemCode
        {
            get
            {
                return (System.String)this.parameterold_fldItemCode.Value;
            }
            set
            {
                this.parameterold_fldItemCode.Value = value;
            }
        }

        public System.Decimal old_fldItemValue
        {
            get
            {
                return (System.Decimal)this.parameterold_fldItemValue.Value;
            }
            set
            {
                this.parameterold_fldItemValue.Value = value;
            }
        }

        public System.Int16 old_fldSource
        {
            get
            {
                return (System.Int16)this.parameterold_fldSource.Value;
            }
            set
            {
                this.parameterold_fldSource.Value = value;
            }
        }

        public System.Int16 old_fldFlag
        {
            get
            {
                return (System.Int16)this.parameterold_fldFlag.Value;
            }
            set
            {
                this.parameterold_fldFlag.Value = value;
            }
        }

        public System.Int32 old_fldCityID_Operate
        {
            get
            {
                return (System.Int32)this.parameterold_fldCityID_Operate.Value;
            }
            set
            {
                this.parameterold_fldCityID_Operate.Value = value;
            }
        }

        public System.String old_fldCityID_Submit
        {
            get
            {
                return (System.String)this.parameterold_fldCityID_Submit.Value;
            }
            set
            {
                this.parameterold_fldCityID_Submit.Value = value;
            }
        }

        public System.Int32 old_fldUserID
        {
            get
            {
                return (System.Int32)this.parameterold_fldUserID.Value;
            }
            set
            {
                this.parameterold_fldUserID.Value = value;
            }
        }

        public System.Int32 new_fldCityID_Operate
        {
            get
            {
                return (System.Int32)this.parameternew_fldCityID_Operate.Value;
            }
            set
            {
                this.parameternew_fldCityID_Operate.Value = value;
            }
        }

        public System.String new_fldCityID_Submit
        {
            get
            {
                return (System.String)this.parameternew_fldCityID_Submit.Value;
            }
            set
            {
                this.parameternew_fldCityID_Submit.Value = value;
            }
        }

        public System.Int16 new_fldFlag
        {
            get
            {
                return (System.Int16)this.parameternew_fldFlag.Value;
            }
            set
            {
                this.parameternew_fldFlag.Value = value;
            }
        }

        public System.DateTime new_fldDate_Operate
        {
            get
            {
                return (System.DateTime)this.parameternew_fldDate_Operate.Value;
            }
            set
            {
                this.parameternew_fldDate_Operate.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterold_fldAutoID = new SqlParameter();
            this.parameterold_fldAutoID.ParameterName = "@old_fldAutoID";
            this.parameterold_fldAutoID.SqlDbType = SqlDbType.BigInt;
            this.parameterold_fldAutoID.Size = 8;
            this.parameterold_fldAutoID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldAutoID);
            //--------------------------------------------------------
            this.parameterold_fldSTCode = new SqlParameter();
            this.parameterold_fldSTCode.ParameterName = "@old_fldSTCode";
            this.parameterold_fldSTCode.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldSTCode.Size = 12;
            this.parameterold_fldSTCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSTCode);
            //--------------------------------------------------------
            this.parameterold_fldRCode = new SqlParameter();
            this.parameterold_fldRCode.ParameterName = "@old_fldRCode";
            this.parameterold_fldRCode.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldRCode.Size = 12;
            this.parameterold_fldRCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldRCode);
            //--------------------------------------------------------
            this.parameterold_fldRSCode = new SqlParameter();
            this.parameterold_fldRSCode.ParameterName = "@old_fldRSCode";
            this.parameterold_fldRSCode.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldRSCode.Size = 20;
            this.parameterold_fldRSCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldRSCode);
            //--------------------------------------------------------
            this.parameterold_fldSAMPH = new SqlParameter();
            this.parameterold_fldSAMPH.ParameterName = "@old_fldSAMPH";
            this.parameterold_fldSAMPH.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldSAMPH.Size = 12;
            this.parameterold_fldSAMPH.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSAMPH);
            //--------------------------------------------------------
            this.parameterold_fldSAMPR = new SqlParameter();
            this.parameterold_fldSAMPR.ParameterName = "@old_fldSAMPR";
            this.parameterold_fldSAMPR.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldSAMPR.Size = 12;
            this.parameterold_fldSAMPR.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSAMPR);
            //--------------------------------------------------------
            this.parameterold_fldRSC = new SqlParameter();
            this.parameterold_fldRSC.ParameterName = "@old_fldRSC";
            this.parameterold_fldRSC.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldRSC.Size = 10;
            this.parameterold_fldRSC.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldRSC);
            //--------------------------------------------------------
            this.parameterold_fldYear = new SqlParameter();
            this.parameterold_fldYear.ParameterName = "@old_fldYear";
            this.parameterold_fldYear.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldYear.Size = 5;
            this.parameterold_fldYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldYear);
            //--------------------------------------------------------
            this.parameterold_fldMonth = new SqlParameter();
            this.parameterold_fldMonth.ParameterName = "@old_fldMonth";
            this.parameterold_fldMonth.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldMonth.Size = 5;
            this.parameterold_fldMonth.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldMonth);
            //--------------------------------------------------------
            this.parameterold_fldDay = new SqlParameter();
            this.parameterold_fldDay.ParameterName = "@old_fldDay";
            this.parameterold_fldDay.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldDay.Size = 5;
            this.parameterold_fldDay.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldDay);
            //--------------------------------------------------------
            this.parameterold_fldHour = new SqlParameter();
            this.parameterold_fldHour.ParameterName = "@old_fldHour";
            this.parameterold_fldHour.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldHour.Size = 5;
            this.parameterold_fldHour.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldHour);
            //--------------------------------------------------------
            this.parameterold_fldMinute = new SqlParameter();
            this.parameterold_fldMinute.ParameterName = "@old_fldMinute";
            this.parameterold_fldMinute.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldMinute.Size = 5;
            this.parameterold_fldMinute.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldMinute);
            //--------------------------------------------------------
            this.parameterold_fldItemCode = new SqlParameter();
            this.parameterold_fldItemCode.ParameterName = "@old_fldItemCode";
            this.parameterold_fldItemCode.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldItemCode.Size = 10;
            this.parameterold_fldItemCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldItemCode);
            //--------------------------------------------------------
            this.parameterold_fldItemValue = new SqlParameter();
            this.parameterold_fldItemValue.ParameterName = "@old_fldItemValue";
            this.parameterold_fldItemValue.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldItemValue.Size = 17;
            this.parameterold_fldItemValue.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldItemValue);
            //--------------------------------------------------------
            this.parameterold_fldSource = new SqlParameter();
            this.parameterold_fldSource.ParameterName = "@old_fldSource";
            this.parameterold_fldSource.SqlDbType = SqlDbType.SmallInt;
            this.parameterold_fldSource.Size = 2;
            this.parameterold_fldSource.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSource);
            //--------------------------------------------------------
            this.parameterold_fldFlag = new SqlParameter();
            this.parameterold_fldFlag.ParameterName = "@old_fldFlag";
            this.parameterold_fldFlag.SqlDbType = SqlDbType.SmallInt;
            this.parameterold_fldFlag.Size = 2;
            this.parameterold_fldFlag.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldFlag);
            //--------------------------------------------------------
            this.parameterold_fldCityID_Operate = new SqlParameter();
            this.parameterold_fldCityID_Operate.ParameterName = "@old_fldCityID_Operate";
            this.parameterold_fldCityID_Operate.SqlDbType = SqlDbType.Int;
            this.parameterold_fldCityID_Operate.Size = 4;
            this.parameterold_fldCityID_Operate.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldCityID_Operate);
            //--------------------------------------------------------
            this.parameterold_fldCityID_Submit = new SqlParameter();
            this.parameterold_fldCityID_Submit.ParameterName = "@old_fldCityID_Submit";
            this.parameterold_fldCityID_Submit.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldCityID_Submit.Size = 100;
            this.parameterold_fldCityID_Submit.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldCityID_Submit);
            //--------------------------------------------------------
            this.parameterold_fldUserID = new SqlParameter();
            this.parameterold_fldUserID.ParameterName = "@old_fldUserID";
            this.parameterold_fldUserID.SqlDbType = SqlDbType.Int;
            this.parameterold_fldUserID.Size = 4;
            this.parameterold_fldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldUserID);
            //--------------------------------------------------------
            this.parameternew_fldCityID_Operate = new SqlParameter();
            this.parameternew_fldCityID_Operate.ParameterName = "@new_fldCityID_Operate";
            this.parameternew_fldCityID_Operate.SqlDbType = SqlDbType.Int;
            this.parameternew_fldCityID_Operate.Size = 4;
            this.parameternew_fldCityID_Operate.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldCityID_Operate);
            //--------------------------------------------------------
            this.parameternew_fldCityID_Submit = new SqlParameter();
            this.parameternew_fldCityID_Submit.ParameterName = "@new_fldCityID_Submit";
            this.parameternew_fldCityID_Submit.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldCityID_Submit.Size = 100;
            this.parameternew_fldCityID_Submit.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldCityID_Submit);
            //--------------------------------------------------------
            this.parameternew_fldFlag = new SqlParameter();
            this.parameternew_fldFlag.ParameterName = "@new_fldFlag";
            this.parameternew_fldFlag.SqlDbType = SqlDbType.SmallInt;
            this.parameternew_fldFlag.Size = 2;
            this.parameternew_fldFlag.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldFlag);
            //--------------------------------------------------------
            this.parameternew_fldDate_Operate = new SqlParameter();
            this.parameternew_fldDate_Operate.ParameterName = "@new_fldDate_Operate";
            this.parameternew_fldDate_Operate.SqlDbType = SqlDbType.DateTime;
            this.parameternew_fldDate_Operate.Size = 8;
            this.parameternew_fldDate_Operate.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldDate_Operate);
        }
    }
}