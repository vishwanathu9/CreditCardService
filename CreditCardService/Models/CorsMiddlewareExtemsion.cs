using Microsoft.AspNetCore.Builder;

namespace CreditCardService.Models
{
    public static class CorsMiddlewareExtemsion
    {
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
}
