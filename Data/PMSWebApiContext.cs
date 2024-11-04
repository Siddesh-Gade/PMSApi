using Microsoft.EntityFrameworkCore;
using PMSWebApi.Models;
using PMSWebApi.ViewModels;

namespace PMSWebApi.Data
{
    public class PMSWebApiContext : DbContext
    {
        public PMSWebApiContext (DbContextOptions<PMSWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<PMSWebApi.Models.Employees> Employees { get; set; } = default!;
        public DbSet<PMSWebApi.Models.Cycle> Cycle { get; set; } = default!;
        public DbSet<PMSWebApi.Models.Ratings> Ratings { get; set; } = default!;
        public DbSet<PMSWebApi.Models.KPIs> kPs { get; set; } = default!;
        public DbSet<PMSWebApi.Models.Rounds> Rounds { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the one-to-many relationship (Employee to Projects)
            modelBuilder.Entity<KPIs>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.KPIs)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rounds>()
               .HasOne(p => p.Employee)
               .WithMany(e => e.Rounds)
               .HasForeignKey(p => p.EmployeeId)
               .OnDelete(DeleteBehavior.Restrict);
            
        }   
    }
}
