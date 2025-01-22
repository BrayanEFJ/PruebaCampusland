using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using NuGet.Protocol;

namespace PruebaBrayanFigueroa.Errors
{
    public class CustomErrors : Exception
    {

        public int StatusCode { get; set; }

        public CustomErrors(int status_code, string message) : base(message)
        {
            StatusCode = status_code;
        }


        public ContentResult TocontentError()
        {
            var response = new
            {
                Message = Message,
                Code = StatusCode
            };
            var bodyresponse = response.ToJson();

            return new ContentResult
            {
                Content = bodyresponse,
                ContentType = "application/json",
                StatusCode = StatusCode,
            };
        }


    }
}
