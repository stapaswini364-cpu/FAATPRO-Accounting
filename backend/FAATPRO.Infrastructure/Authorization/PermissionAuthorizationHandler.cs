using System.Security.Claims;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Authorization;

public class PermissionAuthorizationHandler 
    : AuthorizationHandler<PermissionRequirement>
{

    private readonly ApplicationDbContext _context;


    public PermissionAuthorizationHandler(
        ApplicationDbContext context)
    {
        _context = context;
    }



    protected override async Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {

        var userIdClaim =
            context.User.FindFirst(
                ClaimTypes.NameIdentifier);


        if (userIdClaim == null)
            return;


        var userId =
            Guid.Parse(userIdClaim.Value);



        var hasPermission =
            await _context.UserRoles
                .Where(x => x.UserId == userId)
                .SelectMany(x => x.Role.RolePermissions)
                .AnyAsync(x =>
                    x.Permission.Name == requirement.Permission);



        if (hasPermission)
        {
            context.Succeed(requirement);
        }
    }
}