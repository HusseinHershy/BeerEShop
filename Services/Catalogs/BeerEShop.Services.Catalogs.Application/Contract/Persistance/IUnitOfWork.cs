using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerEShop.Services.Catalogs.Application.Contract.Persistance
{
    public interface IUnitOfWork : IDisposable
    {
        IBeerRepository BeerRepository { get; }
        IBreweryRepository BreweryRepository { get; }
        int Complete();
        Task<int> CompleteAsync();


    }
}
