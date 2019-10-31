namespace EMCCommon.Mode
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VEntityContext : DbContext
    {
        public VEntityContext()
            : base("name=VEntityContext")
        {
        }

        public virtual DbSet<tbl_EQIB_BaseData_V_Pre> tbl_EQIB_BaseData_V_Pre { get; set; }
        public virtual DbSet<tblEQIA_RPI_Basedata_V_Pre> tblEQIA_RPI_Basedata_V_Pre { get; set; }
        public virtual DbSet<tblEQISO_Basedata_V_Pre> tblEQISO_Basedata_V_Pre { get; set; }
        public virtual DbSet<tblEQIW_D_Basedata_V_Pre> tblEQIW_D_Basedata_V_Pre { get; set; }
        public virtual DbSet<tblEQIW_R_Basedata_V_Pre> tblEQIW_R_Basedata_V_Pre { get; set; }
        public virtual DbSet<tblEQIW_WS_Basedata_V_Pre> tblEQIW_WS_Basedata_V_Pre { get; set; }
        public virtual DbSet<To_Setup> To_Setup { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldLons)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldLone)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldLats)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldLate)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldMon)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldSWFDvalue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldZBFGvalue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldSWMDvalue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldTDTHvalue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldRLGRvalue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldXYSTvalue)
                .HasPrecision(18, 5);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_EQIB_BaseData_V_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldCCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldVCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldLon)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldLat)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fld101)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fld141)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fld107)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fld105)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fld108)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fld106)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsName)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsValue)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_V_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldCCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldVCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldPCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldLon)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldLat)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldSampleType)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld100)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld116)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld106)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld108)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld103)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld120)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld113)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld186)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld111)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld112)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld105)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld109)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld121)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld118)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld522)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld104)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fld263)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsName1)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsValue1)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsName2)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsValue2)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsName3)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsValue3)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_V_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldCCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldVCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldRSCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldLon)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldLat)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld998)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld301)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld302)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld303)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld315)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld316)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld314)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld317)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld311)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld313)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld466)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld434)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld435)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld318)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld319)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld320)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld438)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld436)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld323)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld437)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld325)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld326)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld327)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld328)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld467)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld330)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld304)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld309)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld310)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld432)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld433)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld462)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fld329)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldWaterType)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsName)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldPollutantsValue)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_V_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldCCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldRSCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldLon)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldLat)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld301)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld302)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld315)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld316)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld314)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld317)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld311)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld313)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld466)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld434)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld435)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld318)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld319)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld320)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld438)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld436)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld325)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld323)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld437)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld326)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld327)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld328)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld467)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fld330)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldWaterType)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_V_Pre>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldCCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldVCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldRSCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldLon)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldLat)
                .HasPrecision(7, 4);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld997)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld998)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld316)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld311)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld302)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld317)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld461)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld313)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fld330)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_WS_Basedata_V_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);
        }
    }
}
