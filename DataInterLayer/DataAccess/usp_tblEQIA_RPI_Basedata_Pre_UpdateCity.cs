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

    public class usp_tblEQIA_RPI_Basedata_Pre_UpdateCity : BaseProcedure
    {
        private SqlParameter parameterold_fldAutoID;

        private SqlParameter parameterold_fldSTCode;

        private SqlParameter parameterold_fldPCode;

        private SqlParameter parameterold_fldSYear;

        private SqlParameter parameterold_fldSMonth;

        private SqlParameter parameterold_fldSDay;

        private SqlParameter parameterold_fldSHour;

        private SqlParameter parameterold_fldSMinute;

        private SqlParameter parameterold_fldEYear;

        private SqlParameter parameterold_fldEMonth;

        private SqlParameter parameterold_fldEDay;

        private SqlParameter parameterold_fldEHour;

        private SqlParameter parameterold_fldEMinute;

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

        public usp_tblEQIA_RPI_Basedata_Pre_UpdateCity()
        {
            base.InitCommand("usp_tblEQIA_RPI_Basedata_Pre_UpdateCity");
            ConfigParameter();
        }

        public System.Int32 old_fldAutoID
        {
            get
            {
                return (System.Int32)this.parameterold_fldAutoID.Value;
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

        public System.String old_fldPCode
        {
            get
            {
                return (System.String)this.parameterold_fldPCode.Value;
            }
            set
            {
                this.parameterold_fldPCode.Value = value;
            }
        }

        public System.Decimal old_fldSYear
        {
            get
            {
                return (System.Decimal)this.parameterold_fldSYear.Value;
            }
            set
            {
                this.parameterold_fldSYear.Value = value;
            }
        }

        public System.Decimal old_fldSMonth
        {
            get
            {
                return (System.Decimal)this.parameterold_fldSMonth.Value;
            }
            set
            {
                this.parameterold_fldSMonth.Value = value;
            }
        }

        public System.Decimal old_fldSDay
        {
            get
            {
                return (System.Decimal)this.parameterold_fldSDay.Value;
            }
            set
            {
                this.parameterold_fldSDay.Value = value;
            }
        }

        public System.Decimal old_fldSHour
        {
            get
            {
                return (System.Decimal)this.parameterold_fldSHour.Value;
            }
            set
            {
                this.parameterold_fldSHour.Value = value;
            }
        }

        public System.Decimal old_fldSMinute
        {
            get
            {
                return (System.Decimal)this.parameterold_fldSMinute.Value;
            }
            set
            {
                this.parameterold_fldSMinute.Value = value;
            }
        }

        public System.Decimal old_fldEYear
        {
            get
            {
                return (System.Decimal)this.parameterold_fldEYear.Value;
            }
            set
            {
                this.parameterold_fldEYear.Value = value;
            }
        }

        public System.Decimal old_fldEMonth
        {
            get
            {
                return (System.Decimal)this.parameterold_fldEMonth.Value;
            }
            set
            {
                this.parameterold_fldEMonth.Value = value;
            }
        }

        public System.Decimal old_fldEDay
        {
            get
            {
                return (System.Decimal)this.parameterold_fldEDay.Value;
            }
            set
            {
                this.parameterold_fldEDay.Value = value;
            }
        }

        public System.Decimal old_fldEHour
        {
            get
            {
                return (System.Decimal)this.parameterold_fldEHour.Value;
            }
            set
            {
                this.parameterold_fldEHour.Value = value;
            }
        }

        public System.Decimal old_fldEMinute
        {
            get
            {
                return (System.Decimal)this.parameterold_fldEMinute.Value;
            }
            set
            {
                this.parameterold_fldEMinute.Value = value;
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
            this.parameterold_fldAutoID.SqlDbType = SqlDbType.Int;
            this.parameterold_fldAutoID.Size = 4;
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
            this.parameterold_fldPCode = new SqlParameter();
            this.parameterold_fldPCode.ParameterName = "@old_fldPCode";
            this.parameterold_fldPCode.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldPCode.Size = 12;
            this.parameterold_fldPCode.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldPCode);
            //--------------------------------------------------------
            this.parameterold_fldSYear = new SqlParameter();
            this.parameterold_fldSYear.ParameterName = "@old_fldSYear";
            this.parameterold_fldSYear.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldSYear.Size = 5;
            this.parameterold_fldSYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSYear);
            //--------------------------------------------------------
            this.parameterold_fldSMonth = new SqlParameter();
            this.parameterold_fldSMonth.ParameterName = "@old_fldSMonth";
            this.parameterold_fldSMonth.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldSMonth.Size = 5;
            this.parameterold_fldSMonth.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSMonth);
            //--------------------------------------------------------
            this.parameterold_fldSDay = new SqlParameter();
            this.parameterold_fldSDay.ParameterName = "@old_fldSDay";
            this.parameterold_fldSDay.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldSDay.Size = 5;
            this.parameterold_fldSDay.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSDay);
            //--------------------------------------------------------
            this.parameterold_fldSHour = new SqlParameter();
            this.parameterold_fldSHour.ParameterName = "@old_fldSHour";
            this.parameterold_fldSHour.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldSHour.Size = 5;
            this.parameterold_fldSHour.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSHour);
            //--------------------------------------------------------
            this.parameterold_fldSMinute = new SqlParameter();
            this.parameterold_fldSMinute.ParameterName = "@old_fldSMinute";
            this.parameterold_fldSMinute.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldSMinute.Size = 5;
            this.parameterold_fldSMinute.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldSMinute);
            //--------------------------------------------------------
            this.parameterold_fldEYear = new SqlParameter();
            this.parameterold_fldEYear.ParameterName = "@old_fldEYear";
            this.parameterold_fldEYear.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldEYear.Size = 5;
            this.parameterold_fldEYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldEYear);
            //--------------------------------------------------------
            this.parameterold_fldEMonth = new SqlParameter();
            this.parameterold_fldEMonth.ParameterName = "@old_fldEMonth";
            this.parameterold_fldEMonth.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldEMonth.Size = 5;
            this.parameterold_fldEMonth.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldEMonth);
            //--------------------------------------------------------
            this.parameterold_fldEDay = new SqlParameter();
            this.parameterold_fldEDay.ParameterName = "@old_fldEDay";
            this.parameterold_fldEDay.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldEDay.Size = 5;
            this.parameterold_fldEDay.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldEDay);
            //--------------------------------------------------------
            this.parameterold_fldEHour = new SqlParameter();
            this.parameterold_fldEHour.ParameterName = "@old_fldEHour";
            this.parameterold_fldEHour.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldEHour.Size = 5;
            this.parameterold_fldEHour.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldEHour);
            //--------------------------------------------------------
            this.parameterold_fldEMinute = new SqlParameter();
            this.parameterold_fldEMinute.ParameterName = "@old_fldEMinute";
            this.parameterold_fldEMinute.SqlDbType = SqlDbType.Decimal;
            this.parameterold_fldEMinute.Size = 5;
            this.parameterold_fldEMinute.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldEMinute);
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