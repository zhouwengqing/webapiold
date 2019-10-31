using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblFW_IP_Power_GetIPPower:BaseProcedure
    { 
        private SqlParameter parameterfldIP1;

        private SqlParameter parameterfldIP2;

        private SqlParameter parameterfldIP3;

        private SqlParameter parameterfldIP4;
         

        public usp_tblFW_IP_Power_GetIPPower()
		{
            base.InitCommand("usp_tblFW_IP_Power_GetIPPower");
			ConfigParameter();
		}
         
        public System.Int32 fldIP1
		{
			get
			{
                return (System.Int32)this.parameterfldIP1.Value;
			}
			set
			{
                this.parameterfldIP1.Value = value;
			}
		}

        public System.Int32 fldIP2
		{
			get
			{
                return (System.Int32)this.parameterfldIP2.Value;
			}
			set
			{
                this.parameterfldIP2.Value = value;
			}
		}
        public System.Int32 fldIP3
		{
			get
			{
                return (System.Int32)this.parameterfldIP3.Value;
			}
			set
			{
                this.parameterfldIP3.Value = value;
			}
		}
        public System.Int32 fldIP4
		{
			get
			{
                return (System.Int32)this.parameterfldIP4.Value;
			}
			set
			{
                this.parameterfldIP4.Value = value;
			}
		} 
		public void ConfigParameter()
		{ 
			//--------------------------------------------------------
            this.parameterfldIP1 = new SqlParameter();
            this.parameterfldIP1.ParameterName = "@fldIP1";
            this.parameterfldIP1.SqlDbType = SqlDbType.Int;
            this.parameterfldIP1.Size =4;
            this.parameterfldIP1.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldIP1);
            //--------------------------------------------------------
            this.parameterfldIP2 = new SqlParameter();
            this.parameterfldIP2.ParameterName = "@fldIP2";
            this.parameterfldIP2.SqlDbType = SqlDbType.Int;
            this.parameterfldIP2.Size = 4;
            this.parameterfldIP2.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldIP2);
            //--------------------------------------------------------
            this.parameterfldIP3 = new SqlParameter();
            this.parameterfldIP3.ParameterName = "@fldIP3";
            this.parameterfldIP3.SqlDbType = SqlDbType.Int;
            this.parameterfldIP3.Size = 4;
            this.parameterfldIP3.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldIP3);
            //--------------------------------------------------------
            this.parameterfldIP4 = new SqlParameter();
            this.parameterfldIP4.ParameterName = "@fldIP4";
            this.parameterfldIP4.SqlDbType = SqlDbType.Int;
            this.parameterfldIP4.Size = 4;
            this.parameterfldIP4.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldIP4); 
		}
    }
}
