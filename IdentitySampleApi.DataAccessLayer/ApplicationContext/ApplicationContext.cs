using IdentitySample.EntityLayer.Entities;
using IdentitySample.EntityLayer.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentitySampleApi.DataAccessLayer.ApplicationContext
{
    public class DefaultDatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Thing> Thing { get; set; }
        public DbSet<SubThing> SubThing { get; set; }
        public DbSet<MultipleA> multipleAss { get; set; }
        public DbSet<MultipleB> multipleBss { get; set; }
        public DbSet<MultipleAInMultipleB> MultipleAInMultipleBs { get; set; }

        public DefaultDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MultipleAInMultipleB>().HasKey(bc => new { bc.AssId, bc.BssId });
            modelBuilder.Entity<MultipleAInMultipleB>().HasOne(bc => bc.Ass).WithMany(b => b.multipleAInMultipleBs).HasForeignKey(bc => bc.AssId);
            modelBuilder.Entity<MultipleAInMultipleB>().HasOne(bc => bc.Bss).WithMany(c => c.multipleAInMultipleBs).HasForeignKey(bc => bc.BssId);
        }
    }
}
