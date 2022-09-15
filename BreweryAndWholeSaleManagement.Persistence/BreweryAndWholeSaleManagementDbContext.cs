using BreweryAndWholeSaleManagement.Domain;
using BreweryAndWholeSaleManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Persistence
{
    public class BreweryAndWholeSaleManagementDbContext : DbContext
    {
        public BreweryAndWholeSaleManagementDbContext(DbContextOptions<BreweryAndWholeSaleManagementDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BreweryAndWholeSaleManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModificationDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Brewerys { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<WholesalerStock> WholesalerStocks { get; set; }

    }
}
