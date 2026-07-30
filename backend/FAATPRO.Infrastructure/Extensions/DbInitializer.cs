using FAATPRO.Infrastructure.Persistence;
using FAATPRO.Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FAATPRO.Infrastructure.Extensions;

public static class DbInitializer
{
    public static async Task InitialiseDatabaseAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var context = scope.ServiceProvider
            .GetRequiredService<ApplicationDbContext>();

        await context.Database.MigrateAsync();

        await DatabaseSeeder.SeedAsync(context);
    }
}