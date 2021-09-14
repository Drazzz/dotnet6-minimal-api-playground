namespace Microsoft.AspNetCore.Builder;

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

internal static partial class ApplicationBuilderExtensions
{
    /// <summary>
    ///     Register exception handling.
    /// </summary>
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        ArgumentNullException.ThrowIfNull(nameof(app));

        if (environment.IsDevelopment())
            app.UseDeveloperExceptionPage();

        return app;
    }

    /// <summary>
    ///     Enforce HTTPS on non-DEV environments
    /// </summary>
    public static IApplicationBuilder UseHttpsOnlyOnNonDevelopmentEnvironments(this IApplicationBuilder app, IWebHostEnvironment environment)
    {
        // Require use of HTTPS in production
        if (!environment.IsDevelopment())
        {
            app.UseHsts();
            app.UseHttpsRedirection();
        }

        return app;
    }

    ///<summary>
    ///     Register CORS   
    ///</summary>
    public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
    {
        ArgumentNullException.ThrowIfNull(nameof(app));

        app.UseCors(p =>
        {
            p.AllowAnyHeader();
            p.AllowAnyOrigin();
        });

        return app;
    }    
}