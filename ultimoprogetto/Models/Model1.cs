using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ultimoprogetto.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<amministatori> amministatori { get; set; }
        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<ordini> ordini { get; set; }
        public virtual DbSet<pizeeoridnate> pizeeoridnate { get; set; }
        public virtual DbSet<pizza> pizza { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<pizza>()
                .Property(e => e.costo)
                .HasPrecision(19, 4);
        }
    }
}
