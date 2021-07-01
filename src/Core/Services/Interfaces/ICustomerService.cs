using Core.Models.Request;
using Core.Models.Response;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<ListResponseModel<CustomerResponseModel>> Search(CustomerRequestModel request);
    }
}
