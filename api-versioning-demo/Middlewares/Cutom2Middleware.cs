using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace api_versioning_demo.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Cutom2Middleware
    {
        private readonly RequestDelegate _next;

        public Cutom2Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            await httpContext.Response.WriteAsync("Called custom2 middleware (before)");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Called custom2 middleware (after)");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Cutom2MiddlewareExtensions
    {
        public static IApplicationBuilder UseCutom2Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Cutom2Middleware>();
        }
    }
}
