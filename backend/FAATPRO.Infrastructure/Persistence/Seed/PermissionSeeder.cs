using FAATPRO.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Persistence.Seed;

public static class PermissionSeeder
{
    public static async Task SeedAsync(
        ApplicationDbContext context)
    {

        var permissions = new List<string>
        {
            // ==========================
            // Company
            // ==========================

            "Company.View",
            "Company.Create",
            "Company.Update",
            "Company.Delete",


            // ==========================
            // User
            // ==========================

            "User.View",
            "User.Create",
            "User.Update",
            "User.Delete",


            // ==========================
            // Role
            // ==========================

            "Role.View",
            "Role.Create",
            "Role.Update",
            "Role.Delete",


            // ==========================
            // Permission
            // ==========================

            "Permission.View",
            "Permission.Create",
            "Permission.Update",
            "Permission.Delete",


            // ==========================
            // Role Permission
            // ==========================

            "RolePermission.View",
            "RolePermission.Assign",
            "RolePermission.Remove",


            // ==========================
            // Accounting
            // ==========================

            "Voucher.View",
            "Voucher.Create",
            "Voucher.Update",
            "Voucher.Delete",


            // ==========================
            // Reports
            // ==========================

            "Report.View",
            "Report.Export"
        };



        // ==========================
        // Insert Permissions
        // ==========================

        foreach (var permissionName in permissions)
        {
            var exists =
                await context.Permissions
                .AnyAsync(x => x.Name == permissionName);


            if (!exists)
            {
                await context.Permissions.AddAsync(
                    new Permission
                    {
                        Id = Guid.NewGuid(),

                        Name = permissionName
                    });
            }
        }


        await context.SaveChangesAsync();



        // ==========================
        // Assign Permissions
        // To SuperAdmin Role
        // ==========================

        var superAdmin =
            await context.Roles
            .FirstOrDefaultAsync(
                x => x.Name == "SuperAdmin");



        if (superAdmin == null)
            return;



        var allPermissions =
            await context.Permissions
            .ToListAsync();



        foreach (var permission in allPermissions)
        {

            var exists =
                await context.RolePermissions
                .AnyAsync(x =>
                    x.RoleId == superAdmin.Id &&
                    x.PermissionId == permission.Id);



            if (!exists)
            {
                await context.RolePermissions.AddAsync(
                    new RolePermission
                    {
                        RoleId = superAdmin.Id,

                        PermissionId = permission.Id
                    });
            }
        }



        await context.SaveChangesAsync();
    }
}