using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Test.Task.Service.Application.Automapper;

namespace Test.Task.Service.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddAutoMapper(typeof(AutoMapperConfiguration));
        return services;
    }
}