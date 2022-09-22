using BreweryAndWholeSaleManagement.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryAndWholeSaleManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BreweryAndWholeSaleManagementDbContext _context;
        private IBreweryRepository _breweryRepository;
        private IBeerRepository _beerRepository;
        private IWholesalerRepository _wholesalerRepository;
        private IWholesalerStockRepository _wholesalerStockRepository;

        public UnitOfWork(BreweryAndWholeSaleManagementDbContext context)
        {
            _context = context;
        }

        public IBreweryRepository BreweryRepository =>
            _breweryRepository ??= new BreweryRepository(_context);

        public IBeerRepository BeerRepository =>
            _beerRepository ??= new BeerRepository(_context);

        public IWholesalerRepository wholesalerRepository =>
            _wholesalerRepository ??= new WholesalerRepository(_context);

        public IWholesalerStockRepository wholesalerStockRepository =>
            _wholesalerStockRepository ??= new WholesalerStockRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
