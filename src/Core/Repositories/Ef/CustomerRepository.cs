using Core.Models.Table;
using Core.Repositories.Ef.Interfaces;
using System.Linq;

namespace Core.Repositories.Ef
{
    public class CustomerRepository : Repository<Customer, long>, ICustomerRepository
    {
        public CustomerRepository(ApiContext apiContext)
            : base(apiContext)
        {
        }

        public IQueryable<Customer> GetQueryable()
        {
            return _apiContext.Customers;
        }
    }
}
