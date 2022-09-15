using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using BreweryAndWholeSaleManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Persistence.Repositories
{
    public class BreweryRepository : GenericRepository<Brewery>, IBreweryRepository
    {
        private readonly BreweryAndWholeSaleManagementDbContext _dbContext;

        public BreweryRepository(BreweryAndWholeSaleManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
