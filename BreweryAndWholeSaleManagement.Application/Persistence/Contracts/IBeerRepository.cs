using BreweryAndWholeSaleManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Persistence.Contracts
{
    public interface IBeerRepository : IGenericRepository<Beer>
    {
        Task<List<Beer>> GetBeerListByBrewery(int BreweryId);
    }
}
