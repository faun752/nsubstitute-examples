using Core.EfModels;
using Core.Repositories;

#nullable disable

namespace Core.Models.Table
{
    public partial class CustomerStaff : ITableObject<long>
    {
        public long CustomerStaffId { get; set; }
        public string CustomerCode { get; set; }
        public string ShopCode { get; set; }
        public string StaffName { get; set; }

        public virtual Shop ShopCodeNavigation { get; set; }
    }
}
