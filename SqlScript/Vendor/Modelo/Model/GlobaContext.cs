namespace Modelo.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GlobaContext : DbContext
    {
        public GlobaContext()
            : base("name=GlobaContext")
        {
        }

        public virtual DbSet<EN_AGENT_GP_COMMISSION> EN_AGENT_GP_COMMISSION { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EN_AGENT_GP_COMMISSION>()
                .Property(e => e.Vendor_Id)
                .IsUnicode(false);

            modelBuilder.Entity<EN_AGENT_GP_COMMISSION>()
                .Property(e => e.Hostname)
                .IsUnicode(false);
        }
    }
}
