#nullable disable

using Core.Repositories;

namespace Core.Models.Table
{
    public partial class Customer : ITableObject<long>
    {
        public long CustomerId { get; set; }
        public string ShopCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerKana { get; set; }
        public string StaffName { get; set; }
        public string Gender { get; set; }
        public int? CardPoint { get; set; }
    }
}
