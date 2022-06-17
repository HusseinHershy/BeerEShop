using BeerEShop.Services.Catalogs.Application.Contract.Persistance;
using BeerEShop.Services.Catalogs.Infrastracture.Persistance;
using BeerEShop.Services.Catalogs.Infrastracture.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Infrastracture.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BeerCatalogContext _context;


        public UnitOfWork(BeerCatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            BeerRepository = new BeerRepository(_context);
            BreweryRepository = new BreweryRepository(_context);

        }

        public IBeerRepository BeerRepository { get; private set; }
        public IBreweryRepository BreweryRepository { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }
        public Task<int> CompleteAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
