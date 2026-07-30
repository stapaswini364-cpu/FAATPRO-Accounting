using FAATPRO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Persistence.Seed;

public static class SuperAdminSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var existingUser = await context.Users
            .FirstOrDefaultAsync(x => x.Email == "superadmin@faatpro.com");

        if (existingUser != null)
            return;


        var superAdminRole = await context.Roles
            .FirstOrDefaultAsync(x => x.Name == "SuperAdmin");


        if (superAdminRole == null)
            return;


        var user = new User
        {
            Id = Guid.NewGuid(),

            FullName = "Super Admin",

            Email = "superadmin@faatpro.com",

            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),

            IsActive = true,

            CreatedAt = DateTime.UtcNow
        };


        var userRole = new UserRole
        {
            UserId = user.Id,

            RoleId = superAdminRole.Id
        };


        user.UserRoles.Add(userRole);


        await context.Users.AddAsync(user);

        await context.SaveChangesAsync();
    }
}