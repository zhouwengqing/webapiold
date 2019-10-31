namespace EMCControls_EMCMIS.EMCMIS_HAINAN.Model
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

        public virtual DbSet<tbl_IF_EQIW_R_StatData> tbl_IF_EQIW_R_StatData { get; set; }
        public virtual DbSet<tblEQIW_R_Section> tblEQIW_R_Section { get; set; }

        public virtual DbSet<tbl_IF_EQIW_L_StatData> tbl_IF_EQIW_L_StatData { get; set; }
        public virtual DbSet<tblEQIW_L_Section> tblEQIW_L_Section { get; set; }

        public virtual DbSet<tbl_IF_EQIW_D_StatData> tbl_IF_EQIW_D_StatData { get; set; }
        public virtual DbSet<tblEQIW_D_Section> tblEQIW_D_Section { get; set; }

        public virtual DbSet<tbl_IF_EQIW_IR_StatData> tbl_IF_EQIW_IR_StatData { get; set; }
        public virtual DbSet<tblEQIW_IR_Section> tblEQIW_IR_Section { get; set; }
        public virtual DbSet<tblEQIS_W_Point> tblEQIS_W_Point { get; set; }

        public virtual DbSet<tbl_IF_EQIS_W_StatData> tbl_IF_EQIS_W_StatData { get; set; }

        public virtual DbSet<tbl_IF_EQIN_A_StatData> tbl_IF_EQIN_A_StatData { get; set; }
        public virtual DbSet<tbl_IF_EQIN_F_StatData> tbl_IF_EQIN_F_StatData { get; set; }
        public virtual DbSet<tbl_IF_EQIN_T_StatData> tbl_IF_EQIN_T_StatData { get; set; }

        public virtual DbSet<tblEQIA_R_Point> tblEQIA_R_Point { get; set; }

        public virtual DbSet<tbl_IF_EQIA_P_StatData> tbl_IF_EQIA_P_StatData { get; set; }
        public virtual DbSet<tblEQIA_P_Point> tblEQIA_P_Point { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
