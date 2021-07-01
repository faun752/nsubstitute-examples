using System;

namespace Core.Models.Response
{
    public class CustomerResponseModel : BaseResponseModel
    {
        public CustomerResponseModel() : base() { }
        public CustomerResponseModel(Exception e) : base(e) { }
        public CustomerResponseModel(string errCode) : base(errCode) { }

        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string CustomerKana { get; set; }
        public string ShopCode { get; set; }
        public string ShopName { get; set; }
        public string StaffName { get; set; }
    }
}
