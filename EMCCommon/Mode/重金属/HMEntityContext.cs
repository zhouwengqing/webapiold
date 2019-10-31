namespace EMCCommon.Mode.重金属
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HMEntityContext : DbContext
    {
        public HMEntityContext()
            : base("name=HMEntityContext")
        {
        }

        public virtual DbSet<tblEQIA_RPI_Basedata_Pre> tblEQIA_RPI_Basedata_Pre { get; set; }
        public virtual DbSet<tblEQISO_Basedata_Pre> tblEQISO_Basedata_Pre { get; set; }
        public virtual DbSet<tblEQIW_D_Basedata_Pre> tblEQIW_D_Basedata_Pre { get; set; }
        public virtual DbSet<tblEQIW_R_Basedata_Pre> tblEQIW_R_Basedata_Pre { get; set; }
        public virtual DbSet<To_Setup> To_Setup { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldPCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldLCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldSYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldSMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldSDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldSHour)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldSMinute)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldEYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldEMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldEDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldEHour)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldEMinute)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldItemValue)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIA_RPI_Basedata_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldPCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldHour)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldMinute)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldItemValue)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldSamplingPerson)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldSamplingWeather)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQISO_Basedata_Pre>()
                .Property(e => e.fldEntCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldRCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldRSCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldSAMPH)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldSAMPR)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldRSC)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldHour)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldMinute)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldItemValue)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_D_Basedata_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldRCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldRSCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldSAMPH)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldSAMPR)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldRSC)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldYear)
                .HasPrecision(4, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldMonth)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldDay)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldHour)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldMinute)
                .HasPrecision(2, 0);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldItemCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldItemValue)
                .HasPrecision(30, 8);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldCityID_Submit)
                .IsUnicode(false);

            modelBuilder.Entity<tblEQIW_R_Basedata_Pre>()
                .Property(e => e.fldBatch)
                .IsUnicode(false);
        }
    }
}
