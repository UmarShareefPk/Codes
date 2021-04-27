using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helpers
{
    public class Umar
    {
        private readonly RequestDelegate _next;
        

        public Umar(RequestDelegate next)
        {
            _next = next;
         //  _appSettings = appSettings.Value;
        }
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null) ;
               // attachUserToContext(context, userService, token);

            await _next(context);
        }
    }
}
