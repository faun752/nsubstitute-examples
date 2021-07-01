using System;
using System.Collections.Generic;

namespace Core.Models.Response
{
    public class ListResponseModel<T> : BaseResponseModel where T : BaseResponseModel
    {
        public ListResponseModel(Exception e) : base(e) { }
        public ListResponseModel(string errCode) : base(errCode) { }

        public ListResponseModel(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
    }
}
