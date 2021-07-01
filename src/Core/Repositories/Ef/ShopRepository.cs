using Core.EfModels;
using Core.Models.Table;
using Core.Repositories.Ef.Interfaces;

namespace Core.Repositories.Ef
{
    public class ShopRepository : Repository<Shop, string>, IShopRepository
    {
        public ShopRepository(ApiContext apiContext) : base(apiContext)
        {
        }
    }
}
