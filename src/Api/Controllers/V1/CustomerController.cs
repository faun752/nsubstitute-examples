using Core.Models.Request;
using Core.Models.Response;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.Controllers.V1
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("search")]
        public async Task<ListResponseModel<CustomerResponseModel>> Get(CustomerRequestModel req)
        {
            try
            {
                // TODO: DB接続のパスワードは変更する
                var responses = await _customerService.Search(req);
                return responses;
            }
            catch (Exception e)
            {
                return new ListResponseModel<CustomerResponseModel>(e);
            }
        }
    }
}
