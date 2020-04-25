using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace IMS_2019.Util
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Helpers : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly RequestDelegate _next;

        public Helpers(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HelpersExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Helpers>();
        }
    }
}
