using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Xml;
using System.Reflection;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblEQIA_RPI_Basedata_GetHumidityAndTemperature:BaseProcedure
    {

        private SqlParameter parameterfldStCode;

		private SqlParameter parameterfldPcode;
                                       
		private SqlParameter parameterfldYear;
                                       
		private SqlParameter parameterfldMonth;
                                       
		private SqlParameter parameterfldDay;
                                       
		private SqlParameter parameterfldHour;

        public usp_tblEQIA_RPI_Basedata_GetHumidityAndTemperature()
		{
            base.InitCommand("usp_tblEQIA_RPI_Basedata_GetHumidityAndTemperature");
			ConfigParameter();
		}

        public System.String fldStCode
		{
			get
			{
                return (System.String)this.parameterfldStCode.Value;
			}
			set
			{
                this.parameterfldStCode.Value = value;
			}
		}

        public System.String fldPcode
		{
			get
			{
                return (System.String)this.parameterfldPcode.Value;
			}
			set
			{
                this.parameterfldPcode.Value = value;
			}
		}

        public System.Int32 fldYear
		{
			get
			{
                return (System.Int32)this.parameterfldYear.Value;
			}
			set
			{
                this.parameterfldYear.Value = value;
			}
		}

        public System.Int32 fldMonth
		{
			get
			{
                return (System.Int32)this.parameterfldMonth.Value;
			}
			set
			{
                this.parameterfldMonth.Value = value;
			}
		}

        public System.Int32 fldDay
		{
			get
			{
				return (System.Int32)this.parameterfldDay.Value;
			}
			set
			{
                this.parameterfldDay.Value = value;
			}
		}
        public System.Int32 fldhour
		{
			get
			{
				return (System.Int32)this.parameterfldHour.Value;
			}
			set
			{
                this.parameterfldHour.Value = value;
			}
		}

		public void ConfigParameter()
		{ 
			//--------------------------------------------------------
			this.parameterfldStCode=new SqlParameter();
			this.parameterfldStCode.ParameterName="@fldStCode";
			this.parameterfldStCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldStCode.Size=20;
			this.parameterfldStCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldStCode);
			//--------------------------------------------------------
			this.parameterfldPcode=new SqlParameter();
			this.parameterfldPcode.ParameterName="@fldPcode";
			this.parameterfldPcode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldPcode.Size=20;
			this.parameterfldPcode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldPcode);
			//--------------------------------------------------------
			this.parameterfldYear=new SqlParameter();
            this.parameterfldYear.ParameterName = "@fldYear";
			this.parameterfldYear.SqlDbType=SqlDbType.Int;
			this.parameterfldYear.Size=4;
			this.parameterfldYear.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldYear);
			//--------------------------------------------------------
			this.parameterfldMonth=new SqlParameter();
			this.parameterfldMonth.ParameterName="@fldMonth";
			this.parameterfldMonth.SqlDbType=SqlDbType.Int;
			this.parameterfldMonth.Size=4;
			this.parameterfldMonth.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldMonth);
			//--------------------------------------------------------
			this.parameterfldDay=new SqlParameter();
			this.parameterfldDay.ParameterName="@fldDay";
			this.parameterfldDay.SqlDbType=SqlDbType.Int;
			this.parameterfldDay.Size=4;
			this.parameterfldDay.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldDay);
			//--------------------------------------------------------
			this.parameterfldHour=new SqlParameter();
			this.parameterfldHour.ParameterName="@fldHour";
			this.parameterfldHour.SqlDbType=SqlDbType.Int;
			this.parameterfldHour.Size=4;
			this.parameterfldHour.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldHour);
		}
    }
}
