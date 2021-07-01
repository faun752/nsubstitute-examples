using System;

namespace Core.Models.Response
{
    public abstract class BaseResponseModel
    {
        protected BaseResponseModel()
        {
        }

        protected BaseResponseModel(Exception e)
        {
            Message = e?.Message;
            StackTrace = e?.StackTrace;
        }

        protected BaseResponseModel(string errorCode)
        {
            ErrorCode = errorCode;
        }

        protected string Message { get; set; }
        protected string StackTrace { get; set; }
        protected string ErrorCode { get; set; }
    }
}
