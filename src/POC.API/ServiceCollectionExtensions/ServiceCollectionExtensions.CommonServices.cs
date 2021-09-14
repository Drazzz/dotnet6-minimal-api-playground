
namespace Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;
using NodaTime;

public static partial class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddCommonServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddCommonServices();

        return builder;
    }

    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddSingleton<IClock>(s => SystemClock.Instance);

        return services;
    }
}
