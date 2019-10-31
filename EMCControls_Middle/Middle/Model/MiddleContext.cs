namespace EMCControls_Middle.Middle.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MiddleContext : DbContext
    {
        public MiddleContext()
            : base("name=MiddleContext")
        {
        }
        public virtual DbSet<tblEQIA_R_WPI_ChangeRate_Midd> tblEQIA_R_WPI_ChangeRate_Midd { get; set; }
        public virtual DbSet<tblEQIN_A_City_AverageData_Midd> tblEQIN_A_City_AverageData_Midd { get; set; }
        public virtual DbSet<tblEQIN_A_City_ProvinceData_Midd> tblEQIN_A_City_ProvinceData_Midd { get; set; }
        public virtual DbSet<tblEQIN_A_City_TotalDateStat_Midd> tblEQIN_A_City_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblEQIN_A_Point_TotalDateStat_Midd> tblEQIN_A_Point_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblEQIN_A_Point_HourStat_Midd> tblEQIN_A_Point_HourStat_Midd { get; set; }

        public virtual DbSet<tblEQIN_F_City_TotalDateStat_Midd> tblEQIN_F_City_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblEQIN_F_Point_HourStat_Midd> tblEQIN_F_Point_HourStat_Midd { get; set; }
        public virtual DbSet<tblEQIN_F_Point_TotalDateStat_Midd> tblEQIN_F_Point_TotalDateStat_Midd { get; set; }

        public virtual DbSet<tblEQIN_T_City_TotalDateStat_Midd> tblEQIN_T_City_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblEQIN_T_Point_HourStat_Midd> tblEQIN_T_Point_HourStat_Midd { get; set; }
        public virtual DbSet<tblEQIN_T_Point_TotalDateStat_Midd> tblEQIN_T_Point_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblEQIN_T_City_Data_Midd> tblEQIN_T_City_Data_Midd { get; set; }

        public virtual DbSet<tblEQIW_D_BaseData_Midd> tblEQIW_D_BaseData_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_City_Midd> tblEQIW_D_City_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_CityItemOver_Midd> tblEQIW_D_CityItemOver_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_DayOfData_Midd> tblEQIW_D_DayOfData_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_ItemOver_Midd> tblEQIW_D_ItemOver_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_Section_Midd> tblEQIW_D_Section_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_YearBook_Midd> tblEQIW_D_YearBook_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_BaseData_Item_Midd> tblEQIW_D_BaseData_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_City_Item_Midd> tblEQIW_D_City_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_DayOfData_Item_Midd> tblEQIW_D_DayOfData_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_Section_Item_Midd> tblEQIW_D_Section_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_YearBook_Item_Midd> tblEQIW_D_YearBook_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_D_Info_Midd> tblEQIW_D_Info_Midd { get; set; }


        public virtual DbSet<tblEQIW_R_ItemOverStat_Midd> tblEQIW_R_ItemOverStat_Midd { get; set; }
        public virtual DbSet<tblEQIW_R_Point> tblEQIW_R_Point { get; set; }
        public virtual DbSet<tblEQIW_R_SectionStat_Item_Midd> tblEQIW_R_SectionStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_R_SectionStat_Midd> tblEQIW_R_SectionStat_Midd { get; set; }
        public virtual DbSet<tblEQIW_R_STAData_MIdd> tblEQIW_R_STAData_MIdd { get; set; }
        public virtual DbSet<tblEQIW_R_TatalSectStat_Item_Midd> tblEQIW_R_TatalSectStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_R_TatalSectStat_Midd> tblEQIW_R_TatalSectStat_Midd { get; set; }

        public virtual DbSet<tblEQIW_RL_ItemOverStat_Midd> tblEQIW_RL_ItemOverStat_Midd { get; set; }
        public virtual DbSet<tblEQIW_RL_SectionStat_Item_Midd> tblEQIW_RL_SectionStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_RL_SectionStat_Midd> tblEQIW_RL_SectionStat_Midd { get; set; }
        public virtual DbSet<tblEQIW_RL_TatalSectStat_Item_Midd> tblEQIW_RL_TatalSectStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_RL_TatalSectStat_Midd> tblEQIW_RL_TatalSectStat_Midd { get; set; }

        public virtual DbSet<tblEQIA_R_City_DayStat_Item_Midd> tblEQIA_R_City_DayStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIA_R_City_DayStat_Midd> tblEQIA_R_City_DayStat_Midd { get; set; }
        public virtual DbSet<tblEQIA_R_City_TotalDateStat_Item_Midd> tblEQIA_R_City_TotalDateStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIA_R_City_TotalDateStat_Midd> tblEQIA_R_City_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblEQIA_R_Point_DayStat_Item_Midd> tblEQIA_R_Point_DayStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIA_R_Point_DayStat_Midd> tblEQIA_R_Point_DayStat_Midd { get; set; }
        public virtual DbSet<tblEQIA_R_Point_TotalDateStat_Item_Midd> tblEQIA_R_Point_TotalDateStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIA_R_Point_TotalDateStat_Midd> tblEQIA_R_Point_TotalDateStat_Midd { get; set; }

        public virtual DbSet<tblEQIA_R_Info_Midd> tblEQIA_R_Info_Midd { get; set; }


        public virtual DbSet<tblEQIW_L_ItemOverStat_Midd> tblEQIW_L_ItemOverStat_Midd { get; set; }
        public virtual DbSet<tblEQIW_L_SectionStat_Item_Midd> tblEQIW_L_SectionStat_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_L_SectionStat_Midd> tblEQIW_L_SectionStat_Midd { get; set; }
        public virtual DbSet<tblEQIW_L_TatalSectStat_N_Item_Midd> tblEQIW_L_TatalSectStat_N_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_L_TatalSectStat_N_Midd> tblEQIW_L_TatalSectStat_N_Midd { get; set; }
        public virtual DbSet<tblEQIW_L_TatalSectStat_Z_Item_Midd> tblEQIW_L_TatalSectStat_Z_Item_Midd { get; set; }
        public virtual DbSet<tblEQIW_L_TatalSectStat_Z_Midd> tblEQIW_L_TatalSectStat_Z_Midd { get; set; }

        public virtual DbSet<tblEQIA_RD_ZHAppraise_Midd> tblEQIA_RD_ZHAppraise_Midd { get; set; }

        public virtual DbSet<tblEQIA_P_BaseData_Midd> tblEQIA_P_BaseData_Midd { get; set; }
        public virtual DbSet<tblEQIA_P_ResultStat_Midd> tblEQIA_P_ResultStat_Midd { get; set; }
        public virtual DbSet<tblEQIA_P_STatType2_Midd> tblEQIA_P_STatType2_Midd { get; set; }
        public virtual DbSet<tblEQIA_P_STatType3_Midd> tblEQIA_P_STatType3_Midd { get; set; }
        public virtual DbSet<tblEQIA_P_STatType4_Midd> tblEQIA_P_STatType4_Midd { get; set; }
        public virtual DbSet<tblEQIA_P_STatType5_Midd> tblEQIA_P_STatType5_Midd { get; set; }
        public virtual DbSet<tblEQIA_P_STatType6_Midd> tblEQIA_P_STatType6_Midd { get; set; }
        public virtual DbSet<tblEQIA_P_STatType7_Midd> tblEQIA_P_STatType7_Midd { get; set; }

        public virtual DbSet<tblEQISO_Info_Midd> tblEQISO_Info_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID0_Item_Midd> tblEQISO_SpaceID0_Item_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID0_Midd> tblEQISO_SpaceID0_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID1_Item_Midd> tblEQISO_SpaceID1_Item_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID1_Midd> tblEQISO_SpaceID1_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID2_Item_Midd> tblEQISO_SpaceID2_Item_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID2_Midd> tblEQISO_SpaceID2_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID3_Midd> tblEQISO_SpaceID3_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID4_Midd> tblEQISO_SpaceID4_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID5_Item_Midd> tblEQISO_SpaceID5_Item_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID5_Midd> tblEQISO_SpaceID5_Midd { get; set; }
        public virtual DbSet<tblEQISO_SpaceID6_Midd> tblEQISO_SpaceID6_Midd { get; set; }

        public virtual DbSet<tblHM_EQIW_RLD_Info_Midd> tblHM_EQIW_RLD_Info_Midd { get; set; }
        public virtual DbSet<tblHM_EQIW_RLD_STatType1_Item_Midd> tblHM_EQIW_RLD_STatType1_Item_Midd { get; set; }
        public virtual DbSet<tblHM_EQIW_RLD_STatType1_Midd> tblHM_EQIW_RLD_STatType1_Midd { get; set; }
        public virtual DbSet<tblHM_EQIW_RLD_STatType3_Item_Midd> tblHM_EQIW_RLD_STatType3_Item_Midd { get; set; }
        public virtual DbSet<tblHM_EQIW_RLD_STatType3_Midd> tblHM_EQIW_RLD_STatType3_Midd { get; set; }
        public virtual DbSet<tblHM_EQISO_Info_Midd> tblHM_EQISO_Info_Midd { get; set; }
        public virtual DbSet<tblHM_EQISO_Midd> tblHM_EQISO_Midd { get; set; }
        public virtual DbSet<tblHM_EQIA_R_Info_Midd> tblHM_EQIA_R_Info_Midd { get; set; }
        public virtual DbSet<tblHM_EQIA_R_Midd> tblHM_EQIA_R_Midd { get; set; }


        public virtual DbSet<tblV_EQIA_R_City_DayStat_Item_Midd> tblV_EQIA_R_City_DayStat_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIA_R_City_DayStat_Midd> tblV_EQIA_R_City_DayStat_Midd { get; set; }
        public virtual DbSet<tblV_EQIA_R_City_TotalDateStat_Item_Midd> tblV_EQIA_R_City_TotalDateStat_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIA_R_City_TotalDateStat_Midd> tblV_EQIA_R_City_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblV_EQIA_R_Point_DayStat_Item_Midd> tblV_EQIA_R_Point_DayStat_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIA_R_Point_DayStat_Midd> tblV_EQIA_R_Point_DayStat_Midd { get; set; }
        public virtual DbSet<tblV_EQIA_R_Point_TotalDateStat_Item_Midd> tblV_EQIA_R_Point_TotalDateStat_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIA_R_Point_TotalDateStat_Midd> tblV_EQIA_R_Point_TotalDateStat_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_RL_ItemOverStat_Midd> tblV_EQIW_RL_ItemOverStat_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_RL_SectionStat_Item_Midd> tblV_EQIW_RL_SectionStat_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_RL_SectionStat_Midd> tblV_EQIW_RL_SectionStat_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_RL_TatalSectStat_Item_Midd> tblV_EQIW_RL_TatalSectStat_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_RL_TatalSectStat_Midd> tblV_EQIW_RL_TatalSectStat_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_City_Item_Midd> tblV_EQIW_D_City_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_City_Midd> tblV_EQIW_D_City_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_CityItemOver_Midd> tblV_EQIW_D_CityItemOver_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_ItemOver_Midd> tblV_EQIW_D_ItemOver_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_Section_Item_Midd> tblV_EQIW_D_Section_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_Section_Midd> tblV_EQIW_D_Section_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_YearBook_Item_Midd> tblV_EQIW_D_YearBook_Item_Midd { get; set; }
        public virtual DbSet<tblV_EQIW_D_YearBook_Midd> tblV_EQIW_D_YearBook_Midd { get; set; }


        public virtual DbSet<tblEQI_Point_Group> tblEQI_Point_Group { get; set; }


        public virtual DbSet<tblEQIA_R_Item> tblEQIA_R_Item { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
