using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Persistence.Repositories
{
    public class BeerRepository : GenericRepository<Beer>, IBeerRepository
    {
        private readonly BreweryAndWholeSaleManagementDbContext _dbContext;

        public BeerRepository(BreweryAndWholeSaleManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Beer>> GetBeerListByBrewery(int BreweryId)
        {
            return await _dbContext.Beers.Where(q => q.BreweryId == BreweryId).ToListAsync();
        }
    }
}
