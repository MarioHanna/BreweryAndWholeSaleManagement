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
    public class WholesalerStockRepository : GenericRepository<WholesalerStock>, IWholesalerStockRepository
    {
        private readonly BreweryAndWholeSaleManagementDbContext _dbContext;

        public WholesalerStockRepository(BreweryAndWholeSaleManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<WholesalerStock> GetWholesalerStockDetails(int beerId, int wholesalerId)
        {
            return await _dbContext.WholesalerStocks
                .Include(q => q.Wholesaler)
                .Include(q => q.Beer)
                .FirstOrDefaultAsync(q => q.BeerId == beerId && q.WholesalerId == wholesalerId)
                ;
        }
    }
}
