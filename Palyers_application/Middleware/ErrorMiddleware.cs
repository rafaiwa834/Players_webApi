using Microsoft.AspNetCore.Http;
using Pilkarze.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pilkarze.Middleware
{
    public class ErrorMiddleware : IMiddleware
    {
        private int counter = 0;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next.Invoke(context);
            }
            catch (NotFound e)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(e.Message);
            }
        }


    }
}
