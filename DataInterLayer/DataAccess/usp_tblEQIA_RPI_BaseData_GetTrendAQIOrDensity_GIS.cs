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

	public class usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_GIS : BaseProcedure
	{
		private SqlParameter parameterfldSTCode;

        private SqlParameter parameterisTrend; 

		public usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_GIS()
		{
			base.InitCommand("usp_tblEQIA_RPI_BaseData_GetTrendAQIOrDensity_GIS");
			ConfigParameter();
		}

		public System.String fldSTCode
		{
			get
			{
				return (System.String)this.parameterfldSTCode.Value;
			}
			set
			{
				this.parameterfldSTCode.Value=value;
			}
		}

        public System.Boolean isTrend
		{
			get
			{
                return (System.Boolean)this.parameterisTrend.Value;
			}
			set
			{
                this.parameterisTrend.Value = value;
			}
		}
         

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterfldSTCode=new SqlParameter();
			this.parameterfldSTCode.ParameterName="@fldSTCode";
			this.parameterfldSTCode.SqlDbType=SqlDbType.VarChar;
			this.parameterfldSTCode.Size=50;
			this.parameterfldSTCode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterfldSTCode);
			//--------------------------------------------------------
            this.parameterisTrend = new SqlParameter();
            this.parameterisTrend.ParameterName = "@isTrend";
            this.parameterisTrend.SqlDbType = SqlDbType.Bit;
            this.parameterisTrend.Size = 2;
            this.parameterisTrend.Direction = ParameterDirection.Input;
            base.m_cmd.Parameters.Add(this.parameterisTrend); 
		}
	}
}
