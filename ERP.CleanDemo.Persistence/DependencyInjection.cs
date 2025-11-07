using ERP.CleanDemo.Application.Interfaces;
using ERP.CleanDemo.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ERP.CleanDemo.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}