namespace EMCCommon.Mode
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=LAP")
        {
        }

        public virtual DbSet<tblFW_User> tblFW_User { get; set; }

        public virtual DbSet<tblMerchantLog> tblMerchantLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblMerchantLog>()
                .Property(e => e.fldLoginCity)
                .IsUnicode(false);

            modelBuilder.Entity<tblMerchantLog>()
                .Property(e => e.fldLoginIP)
                .IsUnicode(false);

            modelBuilder.Entity<tblMerchantLog>()
                .Property(e => e.fldMerchant)
                .IsUnicode(false);
        }
    }
}
