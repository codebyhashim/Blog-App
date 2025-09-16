using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.model.ResponseWrapper
{
    public class ErrorResult
    {
        public List<ErrorDto> Error { get; set; } = default;

        public ErrorResult()
        {
            Error = new List<ErrorDto>();
        }

        public static ErrorResult Failure(string message,int statusCode)
        {
            return new ErrorResult()
            {
                Error = new List<ErrorDto>()
                {
                   new ErrorDto()
                   {
                       Message=message,
                       StatusCode=statusCode
                   }
                }

            };
        }
    }

    public class ErrorDto
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
