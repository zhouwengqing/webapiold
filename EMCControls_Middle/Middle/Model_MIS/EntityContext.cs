namespace EMCControls_Middle.Middle.Model_MIS
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

        public virtual DbSet<tblEQI_Point_Group> tblEQI_Point_Group { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
