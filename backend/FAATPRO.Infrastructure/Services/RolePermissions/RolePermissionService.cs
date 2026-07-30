using FAATPRO.Application.Features.RolePermissions.DTOs;
using FAATPRO.Application.Features.RolePermissions.Interfaces;
using FAATPRO.Domain.Entities;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Services.RolePermissions;

public class RolePermissionService : IRolePermissionService
{
    private readonly ApplicationDbContext _context;


    public RolePermissionService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<RolePermissionResponse?> GetByRoleIdAsync(
        Guid roleId)
    {
        var role = await _context.Roles
            .Include(x => x.RolePermissions)
            .ThenInclude(x => x.Permission)
            .FirstOrDefaultAsync(x => x.Id == roleId);


        if (role == null)
            return null;


        return new RolePermissionResponse
        {
            RoleId = role.Id,

            RoleName = role.Name,

            Permissions = role.RolePermissions
                .Select(x => x.Permission.Name)
                .ToList()
        };
    }




    public async Task<bool> AssignPermissionAsync(
        AssignPermissionRequest request)
    {

        var exists = await _context.RolePermissions
            .AnyAsync(x =>
                x.RoleId == request.RoleId &&
                x.PermissionId == request.PermissionId);


        if (exists)
            return false;



        var rolePermission = new RolePermission
        {
            RoleId = request.RoleId,

            PermissionId = request.PermissionId
        };


        _context.RolePermissions.Add(rolePermission);


        await _context.SaveChangesAsync();


        return true;
    }





    public async Task<bool> RemovePermissionAsync(
        Guid roleId,
        Guid permissionId)
    {

        var rolePermission = await _context.RolePermissions
            .FirstOrDefaultAsync(x =>
                x.RoleId == roleId &&
                x.PermissionId == permissionId);



        if (rolePermission == null)
            return false;



        _context.RolePermissions.Remove(rolePermission);


        await _context.SaveChangesAsync();


        return true;
    }
}