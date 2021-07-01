using Core.Models.Table;
using System.Threading.Tasks;

namespace Core.Repositories.Ef.Interfaces
{
    public interface ICustomerStaffRepository : IRepository<CustomerStaff, long>
    {
        Task<CustomerStaff> GetByCodeAsync(string customerCode, string shopCode);
    }
}
