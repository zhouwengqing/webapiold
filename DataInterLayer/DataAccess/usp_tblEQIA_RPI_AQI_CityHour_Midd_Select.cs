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

	public class usp_tblEQIA_RPI_AQI_CityHour_Midd_Select : BaseProcedure
	{
		private SqlParameter parameterstcode;

		public usp_tblEQIA_RPI_AQI_CityHour_Midd_Select()
		{
			base.InitCommand("usp_tblEQIA_RPI_AQI_CityHour_Midd_Select");
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

		public void ConfigParameter()
		{
			//--------------------------------------------------------
			this.parameterstcode=new SqlParameter();
			this.parameterstcode.ParameterName="@stcode";
			this.parameterstcode.SqlDbType=SqlDbType.NVarChar;
			this.parameterstcode.Size=20;
			this.parameterstcode.Direction=ParameterDirection.Input;
			base.m_cmd.Parameters.Add(this.parameterstcode);
		}
	}
}
