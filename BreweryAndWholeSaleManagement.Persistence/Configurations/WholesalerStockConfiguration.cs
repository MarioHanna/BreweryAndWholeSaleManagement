using BreweryAndWholeSaleManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Persistence.Configurations
{
    public class WholesalerStockConfiguration : IEntityTypeConfiguration<WholesalerStock>
    {
        public void Configure(EntityTypeBuilder<WholesalerStock> builder)
        {
            builder.HasData(
                new WholesalerStock
                {
                    Id = 1,
                    WholesalerId = 1,
                    BeerId = 1,
                    Quantity = 10
                }
            );
        }
    }
}
