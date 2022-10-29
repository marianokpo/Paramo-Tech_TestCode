using Application.Commmon.Interfaces;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFilesServices, FilesServices>();

        services.AddScoped<IUsersServices, UsersServices>();

        return services;
    }
}