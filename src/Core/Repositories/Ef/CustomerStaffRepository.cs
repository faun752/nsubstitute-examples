using Core.Models.Table;
using Core.Repositories.Ef.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repositories.Ef
{
    public class CustomerStaffRepository : Repository<CustomerStaff, long>, ICustomerStaffRepository
    {
        public CustomerStaffRepository(ApiContext apiContext) : base(apiContext)
        {
        }

        public async Task<CustomerStaff> GetByCodeAsync(string customerCode, string shopCode)
        {
            var response = await _apiContext.CustomerStaffs
                .Where(x => x.CustomerCode == customerCode)
                .Where(x => x.ShopCode == shopCode)
                .OrderBy(x => x.ShopCode)
                .FirstOrDefaultAsync();

            return response;
        }
    }
}
