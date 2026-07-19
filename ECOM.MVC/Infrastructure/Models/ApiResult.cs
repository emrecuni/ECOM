using System.Net;

namespace ECOM.MVC.Infrastructure.Models
{
    public class ApiResult<T>
    {
        public bool IsSuccess { get; init; }
        public T? Data { get; init; }
        public string? ErrorMessage { get; init; }
        public HttpStatusCode StatusCode { get; init; }

        public static ApiResult<T> Ok(T data, HttpStatusCode code = HttpStatusCode.OK)
            => new() { IsSuccess = true, Data = data, StatusCode = code };

        public static ApiResult<T> Fail(string message, HttpStatusCode code)
            => new() { IsSuccess = false, ErrorMessage = message, StatusCode = code };
    }
}
