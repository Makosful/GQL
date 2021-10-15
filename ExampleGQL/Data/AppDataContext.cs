using ExampleGQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleGQL.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}