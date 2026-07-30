using Microsoft.Extensions.DependencyInjection;

namespace FAATPRO.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // AutoMapper
        // MediatR
        // FluentValidation registrations
        // Future application services

        return services;
    }
}