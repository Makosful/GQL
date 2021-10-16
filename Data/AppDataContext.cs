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

        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(c => c.Platform)
                .HasForeignKey(c => c.PlatformId);
            modelBuilder.Entity<Command>()
                .HasOne(c => c.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(c => c.PlatformId);
        }
    }
}