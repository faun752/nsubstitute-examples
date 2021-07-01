using Core.EfModels;
using Core.Models.Request;
using Core.Models.Table;
using Core.Repositories.Ef.Interfaces;
using Core.Services;
using MockQueryable.NSubstitute;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Core.Test.Services
{
    public class CustomerServiceTest
    {
        private readonly CustomerService _customerService;

        private readonly IShopRepository _shopRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerStaffRepository _customerStaffRepository;

        public CustomerServiceTest()
        {
            _shopRepository = Substitute.For<IShopRepository>();
            _customerRepository = Substitute.For<ICustomerRepository>();
            _customerStaffRepository = Substitute.For<ICustomerStaffRepository>();

            _customerService = new CustomerService(
                _shopRepository,
                _customerRepository,
                _customerStaffRepository
                );
        }

        [Fact]
        public async Task Search_現店舗の担当スタッフが存在する場合は店舗スタッフ情報を更新して返却する()
        {
            var request = new CustomerRequestModel()
            {
                ShopCode = "10",
                CustomerName = "上泉 信綱",
            };

            var customers = new List<Customer>()
            {
                new Customer()
                {
                    ShopCode = "10",
                    CustomerCode = "0000010001",
                    CustomerName = "上泉 信綱",
                    CustomerKana = "カミイヅミ ノブツナ",
                    StaffName = "宮本"
                },
            };
            var shops = new List<Shop>()
            {
                new Shop() { ShopCode = "10", ShopName = "出雲店" },
                new Shop() { ShopCode = "20", ShopName = "伊勢店" }
            };
            var customerStaff = new CustomerStaff() { StaffName = "山本", ShopCode = "20" };

            _shopRepository.GetAll().Returns(shops);
            _customerStaffRepository.GetByCodeAsync("0000010001", request.ShopCode).Returns(customerStaff);
            var customerMock = customers.AsQueryable().BuildMock();
            _customerRepository.GetQueryable().Returns(customerMock);

            var result = await _customerService.Search(request);
            Assert.Equal("山本", result.Data.ToList()[0].StaffName);
            Assert.Equal("20", result.Data.ToList()[0].ShopCode);
            Assert.Equal("伊勢店", result.Data.ToList()[0].ShopName);
        }
    }
}
