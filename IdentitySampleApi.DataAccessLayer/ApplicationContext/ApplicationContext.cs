using IdentitySample.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentitySampleApi.DataAccessLayer.ApplicationContext
{
    public class DefaultDatabaseContext : DbContext
    {
        public DbSet<Thing> Thing { get; set; }
        public DbSet<SubThing> SubThing { get; set; }

        public DefaultDatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
