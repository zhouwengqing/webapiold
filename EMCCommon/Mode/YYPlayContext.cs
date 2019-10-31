namespace EMCCommon.Mode
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class YYPlayContext : DbContext
    {
        public YYPlayContext()
            : base("name=YYPlayContext")
        {
        }

       
        public virtual DbSet<vwtblAccountingSystem> vwtblAccountingSystem { get; set; }
        public virtual DbSet<tblAgentPay> tblAgentPay { get; set; }
        public virtual DbSet<vwOrdertable> vwOrdertable { get; set; }

        public virtual DbSet<tblGatewaynumber> tblGatewaynumber { get; set; }
        public virtual DbSet<tblOrdertable> tblOrdertable { get; set; }
        public virtual DbSet<tblSubroute> tblSubroute { get; set; }

        public virtual DbSet<tbleMerchant> tbleMerchant { get; set; }

        public virtual DbSet<tbleRate> tbleRate { get; set; }
        public virtual DbSet<tblMerchantRate> tblMerchantRate { get; set; }

        public virtual DbSet<tblFW_User> tblFW_User { get; set; }

        public virtual DbSet<tblChannelinformation> tblChannelinformation { get; set; }

        public virtual DbSet<vwtblAgentPaySystem> vwtblAgentPaySystem { get; set; }

        public virtual DbSet<tblAccounting> tblAccounting { get; set; }
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
                .Property(e => e.fldMaPass)
                .IsUnicode(false);

            modelBuilder.Entity<tbleMerchant>()
                .Property(e => e.fldRemark)
                .IsUnicode(false);

            modelBuilder.Entity<tblMerchantRate>().Property(p => p.fldRate).HasPrecision(18,4);
        }
    }
}
