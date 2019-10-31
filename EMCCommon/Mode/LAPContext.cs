namespace EMCCommon.Mode
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LAPContext : DbContext
    {
        public LAPContext()
            : base("name=LAPContext")
        {
        }

        public virtual DbSet<tblFW_RegCity> tblFW_RegCity { get; set; }
        public virtual DbSet<tblFW_User> tblFW_User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblFW_RegCity>()
                .Property(e => e.fldSTCode)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_RegCity>()
                .Property(e => e.fldSTName)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_RegCity>()
                .Property(e => e.fldSTCodeGA)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_RegCity>()
                .Property(e => e.fldLatitude)
                .HasPrecision(18, 9);

            modelBuilder.Entity<tblFW_RegCity>()
                .Property(e => e.fldLongitude)
                .HasPrecision(18, 9);
        }
    }
}
