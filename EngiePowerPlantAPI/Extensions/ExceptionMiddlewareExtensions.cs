using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace EngiePowerPlantAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Extension method to configure handling of all the exceptions.
        /// </summary>
        /// <param name="app"> The web application object.</param>
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler(
                    options =>
                    {
                        options.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                var exep = context.Features.Get<IExceptionHandlerFeature>();
                                if (exep != null)
                                {
                                    await context.Response.WriteAsync(exep.Error.Message);
                                }
                            }
                            );
                    });
            }
        }
    }
}
