namespace EMCControls_EMCMIS.EMCMIS.Model
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


        public virtual DbSet<vwtblEQIW_R_Basedata_Pre_Month_QC> vwtblEQIW_R_Basedata_Pre_Month_QC { get; set; }
        public virtual DbSet<tblEQIW_R_Section> tblEQIW_R_Section { get; set; }

        public virtual DbSet<tblEQIW_R_Section_Auto> tblEQIW_R_Section_Auto { get; set; }

        public virtual DbSet<vwtblEQIW_R_WaterWorks_Pre> vwtblEQIW_R_WaterWorks_Pre { get; set; }

        public virtual DbSet<tblEQIW_R_Item_Auto> tblEQIW_R_Item_Auto { get; set; }

        public virtual DbSet<tblEQIW_R_Basedata_Pre_Month_QC> tblEQIW_R_Basedata_Pre_Month_QC { get; set; }
        public virtual DbSet<tblEQIW_R_Basedata_Pre_Week_QC> tblEQIW_R_Basedata_Pre_Week_QC { get; set; }


        public virtual DbSet<tblEQIW_R_Basedata_Pre_Auto> tblEQIW_R_Basedata_Pre_Auto { get; set; }

        public virtual DbSet<tblEQIW_R_Basedata_Auto> tblEQIW_R_Basedata_Auto { get; set; }

        public virtual DbSet<vwtblEQIW_R_Basedata_Pre_Week_QC> vwtblEQIW_R_Basedata_Pre_Week_QC { get; set; }


        public virtual DbSet<tblEQIW_R_Auto_Remark> tblEQIW_R_Auto_Remark { get; set; }

        public virtual DbSet<tblEQIW_R_Item> tblEQIW_R_Item { get; set; }

        public virtual DbSet<tblEQIW_R_StagePropTar> tblEQIW_R_StagePropTar { get; set; }


        public virtual DbSet<tblEQIW_R_HourData_Auto> tblEQIW_R_HourData_Auto { get; set; }


        public virtual DbSet<tblEQIW_R_DAQLTSTD> tblEQIW_R_DAQLTSTD { get; set; }

        public virtual DbSet<tblReportArchive> tblReportArchive { get; set; }

        public virtual DbSet<tblEQIW_D_Section> tblEQIW_D_Section { get; set; }


        public virtual DbSet<tblEQI_Point_Group> tblEQI_Point_Group { get; set; }

        public virtual DbSet<tbleqiw_dx_Section> tbleqiw_dx_Section { get; set; }


        public virtual DbSet<ElectronicFile> ElectronicFile { get; set; }


        public virtual DbSet<ElectronicFile_Point> ElectronicFile_Point { get; set; }


        public virtual DbSet<tblEQIA_P_Item> tblEQIA_P_Item { get; set; }
        public virtual DbSet<tblEQIA_R_Item> tblEQIA_R_Item { get; set; }
        public virtual DbSet<tblEQIA_R_ItemSTD> tblEQIA_R_ItemSTD { get; set; }

        public virtual DbSet<tblEQIA_RPI_Basedata> tblEQIA_RPI_Basedata { get; set; }
        public virtual DbSet<tblEQIA_RPI_Basedata_Auto> tblEQIA_RPI_Basedata_Auto { get; set; }

        public virtual DbSet<tblEQIW_R_Basedata> tblEQIW_R_Basedata { get; set; }

        public virtual DbSet<tblEQIW_R_Auto_Itemstarget> tblEQIW_R_Auto_Itemstarget { get; set; }


        public virtual DbSet<tblEQIW_STS_Data> tblEQIW_STS_Data { get; set; }
        public virtual DbSet<tblEQIW_STS_Data_Item> tblEQIW_STS_Data_Item { get; set; }
        public virtual DbSet<tblEQIW_STS_Data_Log> tblEQIW_STS_Data_Log { get; set; }



        public virtual DbSet<tblEQIW_D_Point_Details> tblEQIW_D_Point_Details { get; set; }
        public virtual DbSet<tblEQIW_D_Point_Manage> tblEQIW_D_Point_Manage { get; set; }

        public virtual DbSet<tblEQIW_D_MonitorSection> tblEQIW_D_MonitorSection { get; set; }


        public virtual DbSet<tblEQIW_D_WaterIntake> tblEQIW_D_WaterIntake { get; set; }
        public virtual DbSet<tblEQIW_D_Waterworks> tblEQIW_D_Waterworks { get; set; }


        public virtual DbSet<tblEQIW_D_Billboard> tblEQIW_D_Billboard { get; set; }
        public virtual DbSet<tblEQIW_D_BoundaryMarkers> tblEQIW_D_BoundaryMarkers { get; set; }
        public virtual DbSet<tblEQIW_D_EarlyWarningSection> tblEQIW_D_EarlyWarningSection { get; set; }
        public virtual DbSet<tblEQIW_D_FirstProtectionZones> tblEQIW_D_FirstProtectionZones { get; set; }
        public virtual DbSet<tblEQIW_D_ReadyProtectionZones> tblEQIW_D_ReadyProtectionZones { get; set; }
        public virtual DbSet<tblEQIW_D_RiskSource> tblEQIW_D_RiskSource { get; set; }
        public virtual DbSet<tblEQIW_D_SecondProtectionZones> tblEQIW_D_SecondProtectionZones { get; set; }
        public virtual DbSet<tblEQIW_D_SeineFence> tblEQIW_D_SeineFence { get; set; }
        public virtual DbSet<tblEQIW_D_VideoSurveillance> tblEQIW_D_VideoSurveillance { get; set; }
        public virtual DbSet<tblEQIW_D_WarningSign> tblEQIW_D_WarningSign { get; set; }


        public virtual DbSet<tblEQIW_D_Point_Annex> tblEQIW_D_Point_Annex { get; set; }
        public virtual DbSet<tblEQIW_D_Point_Emergency> tblEQIW_D_Point_Emergency { get; set; }
        public virtual DbSet<tblEQIW_D_TrafficPoint> tblEQIW_D_TrafficPoint { get; set; }


        public virtual DbSet<tblEQIW_D_Point_Imgs> tblEQIW_D_Point_Imgs { get; set; }
        public virtual DbSet<tblEQIW_D_Point_Stage> tblEQIW_D_Point_Stage { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // 重写扩展方法将decimal类型设置为精度30，小数位数8位
            modelBuilder.Entity<tblEQIW_R_Basedata_Pre_Month_QC>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);
            modelBuilder.Entity<tblEQIW_R_Basedata_Pre_Month_QC>().Property(obj => obj.fldActualValue).HasPrecision(30, 8);


            modelBuilder.Entity<tblEQIW_R_Basedata_Pre_Week_QC>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);
            modelBuilder.Entity<tblEQIW_R_Basedata_Pre_Week_QC>().Property(obj => obj.fldActualValue).HasPrecision(30, 8);




            modelBuilder.Entity<tblEQIW_R_Basedata_Pre_Auto>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_STS_Data_Item>().Property(obj => obj.Value).HasPrecision(30, 8);



            modelBuilder.Entity<tblEQIW_R_Auto_Remark>().Property(obj => obj.fldItemValue).HasPrecision(30, 8);
        }
    }
}
