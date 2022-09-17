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
    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasData(
                new Beer
                {
                    Id = 1,
                    Name = "Leffe Blonde",
                    AlcoholContent = 6.6,
                    Price = 2.2,
                    BreweryId = 1
                }
            );
        }
    }
}
