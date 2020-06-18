using EShopAPI.Contracts;
using EShopAPI.Models;
using EShopAPI.Context;
using Microsoft.Extensions.Caching.Memory;

namespace EShopAPI.Repositories
{
    public class ProductRepository : AsyncGenericRepository<Product>, IProductRepository
    {
        public ProductRepository(EShopAPI_DBContext context, IMemoryCache cache) : base(context, cache) { }
    }
}
