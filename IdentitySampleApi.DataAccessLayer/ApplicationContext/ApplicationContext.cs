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

        public DefaultDatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
