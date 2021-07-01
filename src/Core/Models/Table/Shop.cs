#nullable disable

using Core.Repositories;

namespace Core.EfModels
{
    public partial class Shop : ITableObject<string>
    {
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
    }
}
