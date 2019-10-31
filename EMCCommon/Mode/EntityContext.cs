namespace EMCCommon.Mode
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityContext : DbContext
    {
        public EntityContext()
            : base("name=EntityContext")
        {
        }



        //public EntityContext(string conString)
        //    : base(conString)
        //{
        //}


      

        public virtual DbSet<tblEQIA_RPI_Basedata_Pre> tblEQIA_RPI_Basedata_Pre { get; set; }

        public virtual DbSet<tblEQIA_P_Point> tblEQIA_P_Point { get; set; }

        public virtual DbSet<tblEQIN_A_BaseData_Pre> tblEQIN_A_BaseData_Pre { get; set; }

        public virtual DbSet<tblEQIN_F_BaseData_Pre> tblEQIN_F_BaseData_Pre { get; set; }

        public virtual DbSet<tblEQIN_T_BaseData_Pre> tblEQIN_T_BaseData_Pre { get; set; }

        public virtual DbSet<tblEQIA_PPI_BaseData_Pre> tblEQIA_PPI_BaseData_Pre { get; set; }

        public virtual DbSet<tblEQIA_RDPI_Basedata_Pre> tblEQIA_RDPI_Basedata_Pre { get; set; }

        public virtual DbSet<tblEQIW_R_Basedata_Pre> tblEQIW_R_Basedata_Pre { get; set; }

        public virtual DbSet<tblEQIA_R_Point> tblEQIA_R_Point { get; set; }

        public virtual DbSet<tblEQIW_R_Section> tblEQIW_R_Section { get; set; }

        public virtual DbSet<tblDT_Dn_DataLog> tblDT_Dn_DataLog { get; set; }

        public virtual DbSet<tblEQIW_D_Basedata_Pre> tblEQIW_D_Basedata_Pre { get; set; }

        public virtual DbSet<tblEQIW_DT_Basedata_Pre> tblEQIW_DT_Basedata_Pre { get; set; }

        public virtual DbSet<tbleqiw_dx_Basedata_Pre> tbleqiw_dx_Basedata_Pre { get; set; }

        public virtual DbSet<tblEQIN_F_Point> tblEQIN_F_Point { get; set; }

        public virtual DbSet<tblEQISO_Basedata_Pre> tblEQISO_Basedata_Pre { get; set; }

        public virtual DbSet<tblEQISO_Point> tblEQISO_Point { get; set; }

        public virtual DbSet<tblEQIE_BaseData_Pre> tblEQIE_BaseData_Pre { get; set; }

        public virtual DbSet<tblEQIE_CityData_Pre> tblEQIE_CityData_Pre { get; set; }

        public virtual DbSet<tblEQIE_FunData_Pre> tblEQIE_FunData_Pre { get; set; }

        public virtual DbSet<tblEQIBCDBaseData_Pre> tblEQIBCDBaseData_Pre { get; set; }
        public virtual DbSet<tblEQIBCWCBaseData_Pre> tblEQIBCWCBaseData_Pre { get; set; }
        public virtual DbSet<tblEQIBCWPBaseData_Pre> tblEQIBCWPBaseData_Pre { get; set; }
        public virtual DbSet<tblEQIBCZCBaseData_Pre> tblEQIBCZCBaseData_Pre { get; set; }
        public virtual DbSet<tblEQIBCZPBaseData_Pre> tblEQIBCZPBaseData_Pre { get; set; }
        public virtual DbSet<tblEQIB_Species> tblEQIB_Species { get; set; }


        public virtual DbSet<tblEQIBCD_CategoryInfo> tblEQIBCD_CategoryInfo { get; set; }
        public virtual DbSet<tblEQIBCP_CategoryInfo> tblEQIBCP_CategoryInfo { get; set; }
        public virtual DbSet<tblEQIBCWC_CategoryInfo> tblEQIBCWC_CategoryInfo { get; set; }
        public virtual DbSet<tblEQIBCWP_CategoryInfo> tblEQIBCWP_CategoryInfo { get; set; }
        public virtual DbSet<tblEQIBCZC_CategoryInfo> tblEQIBCZC_CategoryInfo { get; set; }
        public virtual DbSet<tblEQIBCZP_CategoryInfo> tblEQIBCZP_CategoryInfo { get; set; }

        public virtual DbSet<tblEQIA_STS_Basedata_Pre> tblEQIA_STS_Basedata_Pre { get; set; }

        public virtual DbSet<tblEQIW_G_Basedata_Pre> tblEQIW_G_Basedata_Pre { get; set; }
        public virtual DbSet<tblEQIW_STS_Basedata_Pre> tblEQIW_STS_Basedata_Pre { get; set; }


        public virtual DbSet<tblEQID_D_BaseData_Pre> tblEQID_D_BaseData_Pre { get; set; }

        public virtual DbSet<tblEQIN_M_BaseData_Pre> tblEQIN_M_BaseData_Pre { get; set; }


        public virtual DbSet<To_Setup> To_Setup { get; set; }


        public virtual DbSet<tblEQI_DataImport_Remark> tblEQI_DataImport_Remark { get; set; }


        public virtual DbSet<tblEQIW_R_Item> tblEQIW_R_Item { get; set; }

        public virtual DbSet<tblEQIW_D_Section> tblEQIW_D_Section { get; set; }

        public virtual DbSet<tblEQIW_DT_Section> tblEQIW_DT_Section { get; set; }

        public virtual DbSet<tbleqiw_dx_Section> tbleqiw_dx_Section { get; set; }

        public virtual DbSet<tblCorrespond_Btype_ItemCode> tblCorrespond_Btype_ItemCode { get; set; }


        public virtual DbSet<tblEQI_DataImport_GobackSta> tblEQI_DataImport_GobackSta { get; set; }



        public virtual DbSet<tblEQIW_R_DevelopmentPace> tblEQIW_R_DevelopmentPace { get; set; }


        public virtual DbSet<tblEQIW_R_Auto_Remark> tblEQIW_R_Auto_Remark { get; set; }


        public virtual DbSet<tblEQIW_D_Basedata> tblEQIW_D_Basedata { get; set; }
        public virtual DbSet<tblEQIW_DT_Basedata> tblEQIW_DT_Basedata { get; set; }
        public virtual DbSet<tbleqiw_dx_Basedata> tbleqiw_dx_Basedata { get; set; }
        public virtual DbSet<tblEQIW_R_Basedata> tblEQIW_R_Basedata { get; set; }


        public virtual DbSet<tblEQIW_STS_Data> tblEQIW_STS_Data { get; set; }
        public virtual DbSet<tblEQIW_STS_Data_Item> tblEQIW_STS_Data_Item { get; set; }




        public virtual DbSet<tblEQI_Item_Group> tblEQI_Item_Group { get; set; }
        public virtual DbSet<tblEQI_Point_Group> tblEQI_Point_Group { get; set; }



        public virtual DbSet<Cache_Setup> Cache_Setup { get; set; }





        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region 重写扩展方法将decimal类型设置为精度30，小数位数8位

            // 重写扩展方法将decimal类型设置为精度30，小数位数8位
            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);
            modelBuilder.Entity<tblEQIW_DT_Basedata_Pre>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);
            modelBuilder.Entity<tbleqiw_dx_Basedata_Pre>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);
            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_STS_Data_Item>().Property(obj => obj.Value).HasPrecision(30, 8);


            #endregion

        }
    }
}
