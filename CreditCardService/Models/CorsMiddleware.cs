using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CreditCardService.Models
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;
        public CorsMiddleware(RequestDelegate next)
        {
            _next = next
                   ;

        }
        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Accept");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,DELETE,OPTIONS");
            return _next(httpContext);
        }
    }
}
