using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDYZ.Ensis.DataSource.DataAccess
{
    public class usp_tblEQIA_RDPI_Basedata_Pre_DelAllData : BaseProcedure
    {
        private SqlParameter parameterfldOldFage; 

        private SqlParameter parameterwhere; 

        private SqlParameter parametercity;

        private SqlParameter parametertable;

        public usp_tblEQIA_RDPI_Basedata_Pre_DelAllData()
		{
            base.InitCommand("usp_tblEQIA_RDPI_Basedata_Pre_DelAllData");
			ConfigParameter();
		}
         
        public System.Int16 fldOldFage
		{
			get
			{
                return (System.Int16)this.parameterfldOldFage.Value;
			}
			set
			{
                this.parameterfldOldFage.Value = value;
			}
		}
         
        public System.String where
		{
			get
			{
                return (System.String)this.parameterwhere.Value;
			}
			set
			{
                this.parameterwhere.Value = value;
			}
		}
        public System.Int32 city
		{
			get
			{
                return (System.Int32)this.parametercity.Value;
			}
			set
			{
                this.parametercity.Value = value;
			}
		}

        public System.String table
        {
            get
            {
                return (System.String)this.parametertable.Value;
            }
            set
            {
                this.parametertable.Value = value;
            }
        }
        public void ConfigParameter()
        { 
            //--------------------------------------------------------
            this.parameterfldOldFage = new SqlParameter();
            this.parameterfldOldFage.ParameterName = "@fldOldFage";
            this.parameterfldOldFage.SqlDbType = SqlDbType.SmallInt;
            this.parameterfldOldFage.Size = 2;
            this.parameterfldOldFage.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterfldOldFage); 
            //--------------------------------------------------------
            this.parameterwhere = new SqlParameter();
            this.parameterwhere.ParameterName = "@where";
            this.parameterwhere.SqlDbType = SqlDbType.VarChar;
            this.parameterwhere.Size = 8000;
            this.parameterwhere.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterwhere); 
            //--------------------------------------------------------
            this.parametercity = new SqlParameter();
            this.parametercity.ParameterName = "@city";
            this.parametercity.SqlDbType = SqlDbType.Int;
            this.parametercity.Size = 4;
            this.parametercity.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parametercity);
            //--------------------------------------------------------
            this.parametertable = new SqlParameter();
            this.parametertable.ParameterName = "@table";
            this.parametertable.SqlDbType = SqlDbType.VarChar;
            this.parametertable.Size = 50;
            this.parametertable.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parametertable); 
        }
    }
}
