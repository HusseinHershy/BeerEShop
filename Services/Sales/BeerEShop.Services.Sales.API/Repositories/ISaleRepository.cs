using BeerEShop.Services.Sales.API.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerEShop.Services.Sales.API.Repositories
{
    public interface ISaleRepository
    {
        Task<Boolean> CreateSaleOrder(SaleOrder saleOrder);
    }
}
