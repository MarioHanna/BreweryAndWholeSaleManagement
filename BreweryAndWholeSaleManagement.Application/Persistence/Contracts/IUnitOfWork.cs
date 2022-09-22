using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Application.Persistence.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IBreweryRepository BreweryRepository { get; }
        IBeerRepository BeerRepository { get; }
        IWholesalerRepository wholesalerRepository { get; }
        IWholesalerStockRepository wholesalerStockRepository { get; }
    }
}
