namespace EMCControls_EMCMIS.EMCMIS.Model.Lap
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

        public virtual DbSet<tblFW_Dictionary> tblFW_Dictionary { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
