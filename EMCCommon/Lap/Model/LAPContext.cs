namespace EMCCommon.Lap.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using global::EMCCommon.Mode;

    public partial class LAPContext : DbContext
    {
        public LAPContext()
            : base("name=LAPContext")
        {
        }

        public virtual DbSet<tblFWContact> tblFWContact { get; set; }

        public virtual DbSet<tblFW_Log> tblFW_Log { get; set; }

        public virtual DbSet<tblFW_User> tblFW_User { get; set; }

        public virtual DbSet<tblFW_RegCity> tblFW_RegCity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
