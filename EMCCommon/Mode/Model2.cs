namespace EMCCommon.Mode
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model2")
        {
        }

        public virtual DbSet<tbleMerchant> tbleMerchant { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldMerchID)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldMerchName)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldContacts)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldPhone)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldIPaddress)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldIdCare)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldAgent)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldPayPass)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldMaPass)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldSecretKey)
                .IsUnicode(false);
        }
    }
}
