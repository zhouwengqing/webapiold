//------------------------------------------------------------------------------
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

	public class usp_GetAllBusinessBaseDataByDateAndBusiness : BaseProcedure
	{
        private SqlParameter parameterstartdate;

        private SqlParameter parameterenddate;

        private SqlParameter parameterbusiness;

        public usp_GetAllBusinessBaseDataByDateAndBusiness()
		{
			base.InitCommand("usp_GetAllBusinessBaseDataByDateAndBusiness");
			ConfigParameter();
		}

        public System.String startdate
		{
			get
			{
				return (System.String)this.parameterstartdate.Value;
			}
			set
			{
				this.parameterstartdate.Value=value;
			}
		}

        public System.String enddate
        {
            get
            {
                return (System.String)this.parameterenddate.Value;
            }
            set
            {
                this.parameterenddate.Value = value;
            }
        }

		public System.String business
		{
			get
			{
				return (System.String)this.parameterbusiness.Value;
			}
			set
			{
				this.parameterbusiness.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterstartdate=new SqlParameter();
            this.parameterstartdate.ParameterName = "@startdate";
			this.parameterstartdate.SqlDbType=SqlDbType.VarChar;
			this.parameterstartdate.Size=20;
			this.parameterstartdate.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstartdate);
            //--------------------------------------------------------
            this.parameterenddate = new SqlParameter();
            this.parameterenddate.ParameterName = "@enddate";
            this.parameterenddate.SqlDbType = SqlDbType.VarChar;
            this.parameterenddate.Size = 20;
            this.parameterenddate.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterenddate);
			//--------------------------------------------------------
			this.parameterbusiness=new SqlParameter();
            this.parameterbusiness.ParameterName = "@business";
			this.parameterbusiness.SqlDbType=SqlDbType.VarChar;
			this.parameterbusiness.Size=20;
			this.parameterbusiness.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterbusiness);
		}
	}
}
