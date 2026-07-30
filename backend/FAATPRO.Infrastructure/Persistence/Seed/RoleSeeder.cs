using FAATPRO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Persistence.Seed;

public static class RoleSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (await context.Roles.AnyAsync())
            return;

        var roles = new List<Role>
        {
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "SuperAdmin",
                Description = "Full system access"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                Description = "Administrator access"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "Accountant",
                Description = "Accounting access"
            },
            new Role
            {
                Id = Guid.NewGuid(),
                Name = "User",
                Description = "Basic user access"
            }
        };

        await context.Roles.AddRangeAsync(roles);

        await context.SaveChangesAsync();
    }
}