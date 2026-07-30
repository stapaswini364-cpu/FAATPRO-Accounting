using BCrypt.Net;
using FAATPRO.Domain.Entities;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Persistence.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        await context.Database.MigrateAsync();

        // Create SuperAdmin Role
        var role = await context.Roles
            .FirstOrDefaultAsync(x => x.Name == "SuperAdmin");

        if (role == null)
        {
            role = new Role
            {
                Id = Guid.NewGuid(),
                Name = "SuperAdmin",
                Description = "System Administrator"
            };

            context.Roles.Add(role);
            await context.SaveChangesAsync();
        }

        // Create Admin User
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Email == "admin@faatpro.com");

        if (user == null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                FullName = "System Administrator",
                Email = "admin@faatpro.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                IsActive = true
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();

            context.UserRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = role.Id
            });

            await context.SaveChangesAsync();
        }
    }
}