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

	public class usp_tblEQIA_RPI_AQI_CityHour_Midd_SelectTrend : BaseProcedure
	{
		private SqlParameter parameterstcode;

		private SqlParameter parameteriday;

		public usp_tblEQIA_RPI_AQI_CityHour_Midd_SelectTrend()
		{
			base.InitCommand("usp_tblEQIA_RPI_AQI_CityHour_Midd_SelectTrend");
			ConfigParameter();
		}

		public System.String stcode
		{
			get
			{
				return (System.String)this.parameterstcode.Value;
			}
			set
			{
				this.parameterstcode.Value=value;
			}
		}

		public System.Int32 iday
		{
			get
			{
				return (System.Int32)this.parameteriday.Value;
			}
			set
			{
				this.parameteriday.Value=value;
			}
		}

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterstcode=new SqlParameter();
			this.parameterstcode.ParameterName="@stcode";
			this.parameterstcode.SqlDbType=SqlDbType.NVarChar;
			this.parameterstcode.Size=20;
			this.parameterstcode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstcode);
			//--------------------------------------------------------
			this.parameteriday=new SqlParameter();
			this.parameteriday.ParameterName="@iday";
			this.parameteriday.SqlDbType=SqlDbType.Int;
			this.parameteriday.Size=4;
			this.parameteriday.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameteriday);
		}
	}
}
