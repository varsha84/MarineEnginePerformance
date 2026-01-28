using Microsoft.EntityFrameworkCore;
using EnginePerformance.Model;

namespace EnginePerformance.Data
{
    public class EngineContext : DbContext
    {
        public EngineContext(DbContextOptions<EngineContext> options) : base(options) { }

        public DbSet<Engine> Engines { get; set; }
        public DbSet<Turbocharger> Turbochargers { get; set; }
        public DbSet<EngineTestParameter> EngineTestParameters { get; set; }
        public DbSet<TurboSelectionResult> TurboSelectionResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary keys
            modelBuilder.Entity<Engine>().HasKey(e => e.EngineId);
            modelBuilder.Entity<EngineTestParameter>().HasKey(e => e.Id);
            modelBuilder.Entity<Turbocharger>().HasKey(t => t.TurboId);
            modelBuilder.Entity<TurboSelectionResult>().HasKey(t => t.ResultId);

            // Relationships
            modelBuilder.Entity<Engine>()
                .HasMany(e => e.TestParameters)
                .WithOne(tp => tp.Engine)
                .HasForeignKey(tp => tp.EngineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Engine>()
                .HasMany(e => e.TurboSelectionResults)
                .WithOne(tr => tr.Engine)
                .HasForeignKey(tr => tr.EngineId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Turbocharger>()
                .HasMany(t => t.TurboSelectionResults)
                .WithOne(tr => tr.Turbocharger)
                .HasForeignKey(tr => tr.TurboId)
                .OnDelete(DeleteBehavior.Cascade);


        }

    }

}
