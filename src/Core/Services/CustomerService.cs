using Core.Common;
using Core.EfModels;
using Core.Models.Request;
using Core.Models.Response;
using Core.Models.Table;
using Core.Repositories.Ef.Interfaces;
using Core.Services.Interfaces;
using Core.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IShopRepository _shopRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerStaffRepository _customerStaffRepository;

        public CustomerService(
            IShopRepository shopRepository,
            ICustomerRepository customerRepository,
            ICustomerStaffRepository customerStaffRepository
            )
        {
            _shopRepository = shopRepository;
            _customerRepository = customerRepository;
            _customerStaffRepository = customerStaffRepository;
        }

        public async Task<ListResponseModel<CustomerResponseModel>> Search(CustomerRequestModel request)
        {
            var target = request.CustomerName?.Split(new char[] { ' ', '　'}).ToList();
            var customers = new List<Customer>().AsQueryable();
            if (target.Any())
            {
                target = target.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                customers = _customerRepository.GetQueryable();
                target.ForEach(x =>
                {
                    customers = customers.Where(y => y.CustomerName.Contains(x) || y.CustomerKana.Contains(x));
                });
            }

            if (customers.Any())
            {
                var shops = await _shopRepository.GetAll();
                var response = customers
                    .Where(x => x.ShopCode == request.ShopCode)
                    .OrderBy(x => x.ShopCode)
                    .ThenBy(x => x.CustomerKana)
                    .ThenBy(x => x.CustomerName)
                    .Select(x => new CustomerResponseModel
                    {
                        CustomerCode = x.CustomerCode,
                        CustomerName = x.CustomerName,
                        CustomerKana = x.CustomerKana,
                        ShopCode = x.ShopCode,
                        ShopName = GetShopName(shops, request.ShopCode)
                    }).ToList();

                await response.ForEachAsync(async x => {
                    var custStaff = await _customerStaffRepository.GetByCodeAsync(x.CustomerCode, request.ShopCode);
                    if (custStaff != null)
                    {
                        x.StaffName = custStaff.StaffName;
                        x.ShopCode = custStaff.ShopCode;
                        x.ShopName = GetShopName(shops, custStaff.ShopCode);
                    }
                });

                return new ListResponseModel<CustomerResponseModel>(response);
            }
            return new ListResponseModel<CustomerResponseModel>(Constants.ErrorCode.NoData);
        }

        private string GetShopName(IEnumerable<Shop> shops, string shopName)
        {
            return shops
                .Where(x => x.ShopCode == shopName)
                .Select(x => x.ShopName)
                .FirstOrDefault();
        }
    }
}
