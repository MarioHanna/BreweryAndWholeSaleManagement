using BreweryAndWholeSaleManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Persistence.Contracts
{
    public interface IWholesalerStockRepository : IGenericRepository<WholesalerStock>
    {
        Task<WholesalerStock> GetWholesalerStockDetails(int BeerId, int wholesalerId);
    }
}
