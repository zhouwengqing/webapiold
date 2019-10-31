namespace EMCCommon.Portal.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PortalEntity : DbContext
    {
        public PortalEntity()
            : base("name=PortalEntity")
        {
        }

        public virtual DbSet<tblFW_Log> tblFW_Log { get; set; }
        public virtual DbSet<tblFW_RegCity> tblFW_RegCity { get; set; }
        public virtual DbSet<tblFW_RightSet> tblFW_RightSet { get; set; }
        public virtual DbSet<tblFW_Role> tblFW_Role { get; set; }
        public virtual DbSet<tblFW_Role_RightSet> tblFW_Role_RightSet { get; set; }
        public virtual DbSet<tblFW_User> tblFW_User { get; set; }
        public virtual DbSet<tblFW_User_Role> tblFW_User_Role { get; set; }
        public virtual DbSet<tblFW_Dept> tblFW_Dept { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblFW_Log>()
                .Property(e => e.fldContent)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_Log>()
                .Property(e => e.fldIPAddress)
                .IsUnicode(false);

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

            modelBuilder.Entity<tblFW_RightSet>()
                .Property(e => e.fldName)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_RightSet>()
                .Property(e => e.fldKeyword)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_RightSet>()
                .Property(e => e.fldImage)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_Role>()
                .Property(e => e.fldName)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_Role>()
                .Property(e => e.fldRoleDesc)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldUserName)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldUserDesc)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldPassword)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldDuty)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldHeaderShip)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldEmail)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldPhone)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldMobile)
                .IsUnicode(false);

            modelBuilder.Entity<tblFW_User>()
                .Property(e => e.fldMemo)
                .IsUnicode(false);
        }
    }
}
