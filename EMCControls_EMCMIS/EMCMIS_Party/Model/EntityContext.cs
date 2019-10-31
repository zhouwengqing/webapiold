namespace EMCControls_EMCMIS.EMCMIS_Party.Model
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

        public virtual DbSet<tblEQIW_R_Section> tblEQIW_R_Section { get; set; }

        public virtual DbSet<tblEQIW_R_Basedata_Pre> tblEQIW_R_Basedata_Pre { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
