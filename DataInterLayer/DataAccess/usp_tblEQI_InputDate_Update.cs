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

    public class usp_tblEQI_InputDate_Update : BaseProcedure
    {
        private SqlParameter parameterold_fldUserID;

        private SqlParameter parameterold_fldCityID;

        private SqlParameter parameterold_fldObject;

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

        private SqlParameter parameternew_fldUserID;

        private SqlParameter parameternew_fldCityID;

        private SqlParameter parameternew_fldObject;

        private SqlParameter parameternew_fldSYear;

        private SqlParameter parameternew_fldSMonth;

        private SqlParameter parameternew_fldSDay;

        private SqlParameter parameternew_fldSHour;

        private SqlParameter parameternew_fldSMinute;

        private SqlParameter parameternew_fldEYear;

        private SqlParameter parameternew_fldEMonth;

        private SqlParameter parameternew_fldEDay;

        private SqlParameter parameternew_fldEHour;

        private SqlParameter parameternew_fldEMinute;

        public usp_tblEQI_InputDate_Update()
        {
            base.InitCommand("usp_tblEQI_InputDate_Update");
            ConfigParameter();
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

        public System.Int32 old_fldCityID
        {
            get
            {
                return (System.Int32)this.parameterold_fldCityID.Value;
            }
            set
            {
                this.parameterold_fldCityID.Value = value;
            }
        }

        public System.String old_fldObject
        {
            get
            {
                return (System.String)this.parameterold_fldObject.Value;
            }
            set
            {
                this.parameterold_fldObject.Value = value;
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

        public System.Int32 new_fldUserID
        {
            get
            {
                return (System.Int32)this.parameternew_fldUserID.Value;
            }
            set
            {
                this.parameternew_fldUserID.Value = value;
            }
        }

        public System.Int32 new_fldCityID
        {
            get
            {
                return (System.Int32)this.parameternew_fldCityID.Value;
            }
            set
            {
                this.parameternew_fldCityID.Value = value;
            }
        }

        public System.String new_fldObject
        {
            get
            {
                return (System.String)this.parameternew_fldObject.Value;
            }
            set
            {
                this.parameternew_fldObject.Value = value;
            }
        }

        public System.Decimal new_fldSYear
        {
            get
            {
                return (System.Decimal)this.parameternew_fldSYear.Value;
            }
            set
            {
                this.parameternew_fldSYear.Value = value;
            }
        }

        public System.Decimal new_fldSMonth
        {
            get
            {
                return (System.Decimal)this.parameternew_fldSMonth.Value;
            }
            set
            {
                this.parameternew_fldSMonth.Value = value;
            }
        }

        public System.Decimal new_fldSDay
        {
            get
            {
                return (System.Decimal)this.parameternew_fldSDay.Value;
            }
            set
            {
                this.parameternew_fldSDay.Value = value;
            }
        }

        public System.Decimal new_fldSHour
        {
            get
            {
                return (System.Decimal)this.parameternew_fldSHour.Value;
            }
            set
            {
                this.parameternew_fldSHour.Value = value;
            }
        }

        public System.Decimal new_fldSMinute
        {
            get
            {
                return (System.Decimal)this.parameternew_fldSMinute.Value;
            }
            set
            {
                this.parameternew_fldSMinute.Value = value;
            }
        }

        public System.Decimal new_fldEYear
        {
            get
            {
                return (System.Decimal)this.parameternew_fldEYear.Value;
            }
            set
            {
                this.parameternew_fldEYear.Value = value;
            }
        }

        public System.Decimal new_fldEMonth
        {
            get
            {
                return (System.Decimal)this.parameternew_fldEMonth.Value;
            }
            set
            {
                this.parameternew_fldEMonth.Value = value;
            }
        }

        public System.Decimal new_fldEDay
        {
            get
            {
                return (System.Decimal)this.parameternew_fldEDay.Value;
            }
            set
            {
                this.parameternew_fldEDay.Value = value;
            }
        }

        public System.Decimal new_fldEHour
        {
            get
            {
                return (System.Decimal)this.parameternew_fldEHour.Value;
            }
            set
            {
                this.parameternew_fldEHour.Value = value;
            }
        }

        public System.Decimal new_fldEMinute
        {
            get
            {
                return (System.Decimal)this.parameternew_fldEMinute.Value;
            }
            set
            {
                this.parameternew_fldEMinute.Value = value;
            }
        }

        public void ConfigParameter()
        {
            //--------------------------------------------------------
            this.parameterold_fldUserID = new SqlParameter();
            this.parameterold_fldUserID.ParameterName = "@old_fldUserID";
            this.parameterold_fldUserID.SqlDbType = SqlDbType.Int;
            this.parameterold_fldUserID.Size = 4;
            this.parameterold_fldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldUserID);
            //--------------------------------------------------------
            this.parameterold_fldCityID = new SqlParameter();
            this.parameterold_fldCityID.ParameterName = "@old_fldCityID";
            this.parameterold_fldCityID.SqlDbType = SqlDbType.Int;
            this.parameterold_fldCityID.Size = 4;
            this.parameterold_fldCityID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldCityID);
            //--------------------------------------------------------
            this.parameterold_fldObject = new SqlParameter();
            this.parameterold_fldObject.ParameterName = "@old_fldObject";
            this.parameterold_fldObject.SqlDbType = SqlDbType.VarChar;
            this.parameterold_fldObject.Size = 20;
            this.parameterold_fldObject.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterold_fldObject);
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
            this.parameternew_fldUserID = new SqlParameter();
            this.parameternew_fldUserID.ParameterName = "@new_fldUserID";
            this.parameternew_fldUserID.SqlDbType = SqlDbType.Int;
            this.parameternew_fldUserID.Size = 4;
            this.parameternew_fldUserID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldUserID);
            //--------------------------------------------------------
            this.parameternew_fldCityID = new SqlParameter();
            this.parameternew_fldCityID.ParameterName = "@new_fldCityID";
            this.parameternew_fldCityID.SqlDbType = SqlDbType.Int;
            this.parameternew_fldCityID.Size = 4;
            this.parameternew_fldCityID.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldCityID);
            //--------------------------------------------------------
            this.parameternew_fldObject = new SqlParameter();
            this.parameternew_fldObject.ParameterName = "@new_fldObject";
            this.parameternew_fldObject.SqlDbType = SqlDbType.VarChar;
            this.parameternew_fldObject.Size = 20;
            this.parameternew_fldObject.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldObject);
            //--------------------------------------------------------
            this.parameternew_fldSYear = new SqlParameter();
            this.parameternew_fldSYear.ParameterName = "@new_fldSYear";
            this.parameternew_fldSYear.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldSYear.Size = 5;
            this.parameternew_fldSYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldSYear);
            //--------------------------------------------------------
            this.parameternew_fldSMonth = new SqlParameter();
            this.parameternew_fldSMonth.ParameterName = "@new_fldSMonth";
            this.parameternew_fldSMonth.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldSMonth.Size = 5;
            this.parameternew_fldSMonth.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldSMonth);
            //--------------------------------------------------------
            this.parameternew_fldSDay = new SqlParameter();
            this.parameternew_fldSDay.ParameterName = "@new_fldSDay";
            this.parameternew_fldSDay.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldSDay.Size = 5;
            this.parameternew_fldSDay.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldSDay);
            //--------------------------------------------------------
            this.parameternew_fldSHour = new SqlParameter();
            this.parameternew_fldSHour.ParameterName = "@new_fldSHour";
            this.parameternew_fldSHour.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldSHour.Size = 5;
            this.parameternew_fldSHour.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldSHour);
            //--------------------------------------------------------
            this.parameternew_fldSMinute = new SqlParameter();
            this.parameternew_fldSMinute.ParameterName = "@new_fldSMinute";
            this.parameternew_fldSMinute.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldSMinute.Size = 5;
            this.parameternew_fldSMinute.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldSMinute);
            //--------------------------------------------------------
            this.parameternew_fldEYear = new SqlParameter();
            this.parameternew_fldEYear.ParameterName = "@new_fldEYear";
            this.parameternew_fldEYear.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldEYear.Size = 5;
            this.parameternew_fldEYear.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldEYear);
            //--------------------------------------------------------
            this.parameternew_fldEMonth = new SqlParameter();
            this.parameternew_fldEMonth.ParameterName = "@new_fldEMonth";
            this.parameternew_fldEMonth.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldEMonth.Size = 5;
            this.parameternew_fldEMonth.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldEMonth);
            //--------------------------------------------------------
            this.parameternew_fldEDay = new SqlParameter();
            this.parameternew_fldEDay.ParameterName = "@new_fldEDay";
            this.parameternew_fldEDay.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldEDay.Size = 5;
            this.parameternew_fldEDay.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldEDay);
            //--------------------------------------------------------
            this.parameternew_fldEHour = new SqlParameter();
            this.parameternew_fldEHour.ParameterName = "@new_fldEHour";
            this.parameternew_fldEHour.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldEHour.Size = 5;
            this.parameternew_fldEHour.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldEHour);
            //--------------------------------------------------------
            this.parameternew_fldEMinute = new SqlParameter();
            this.parameternew_fldEMinute.ParameterName = "@new_fldEMinute";
            this.parameternew_fldEMinute.SqlDbType = SqlDbType.Decimal;
            this.parameternew_fldEMinute.Size = 5;
            this.parameternew_fldEMinute.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameternew_fldEMinute);
        }
    }
}
