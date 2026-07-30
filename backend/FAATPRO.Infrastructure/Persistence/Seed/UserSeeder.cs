using FAATPRO.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace FAATPRO.Infrastructure.Persistence.Seed;

public static class UserSeeder
{
    public static async Task SeedAsync(
        ApplicationDbContext context)
    {

        // ==========================
        // SuperAdmin Role
        // ==========================

        var superAdminRole =
            await context.Roles
            .FirstOrDefaultAsync(x =>
                x.Name == "SuperAdmin");


        if (superAdminRole == null)
        {
            superAdminRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = "SuperAdmin",
                Description = "System Administrator"
            };

            await context.Roles.AddAsync(
                superAdminRole);

            await context.SaveChangesAsync();
        }



        // ==========================
        // Admin User
        // ==========================

        var admin =
            await context.Users
            .FirstOrDefaultAsync(x =>
                x.Email == "admin@faatpro.com");



        if (admin == null)
        {
            admin = new User
            {
                Id = Guid.NewGuid(),

                FullName =
                    "System Administrator",

                Email =
                    "admin@faatpro.com",

                PasswordHash =
                    BCrypt.Net.BCrypt
                    .HashPassword("Admin@123"),

                IsActive = true
            };


            await context.Users.AddAsync(admin);

            await context.SaveChangesAsync();
        }
        else
        {
            // Reset password for testing
            admin.PasswordHash =
                BCrypt.Net.BCrypt
                .HashPassword("Admin@123");


            await context.SaveChangesAsync();
        }



        // ==========================
        // Assign SuperAdmin Role
        // ==========================


        var userRoleExists =
            await context.UserRoles
            .AnyAsync(x =>
                x.UserId == admin.Id &&
                x.RoleId == superAdminRole.Id);



        if (!userRoleExists)
        {
            await context.UserRoles.AddAsync(
                new UserRole
                {
                    UserId = admin.Id,

                    RoleId = superAdminRole.Id
                });


            await context.SaveChangesAsync();
        }

    }
}