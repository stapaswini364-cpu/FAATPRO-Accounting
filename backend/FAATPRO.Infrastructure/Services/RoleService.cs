using FAATPRO.Application.Features.Roles.DTOs;
using FAATPRO.Application.Features.Roles.Interfaces;
using FAATPRO.Domain.Entities;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Services;

public class RoleService : IRoleService
{
    private readonly ApplicationDbContext _context;

    public RoleService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<RoleResponse>> GetAllAsync()
    {
        return await _context.Roles
            .Select(x => new RoleResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description ?? string.Empty
            })
            .ToListAsync();
    }


    public async Task<RoleResponse?> GetByIdAsync(Guid id)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(x => x.Id == id);

        if (role == null)
            return null;


        return new RoleResponse
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description ?? string.Empty
        };
    }


    public async Task<RoleResponse> CreateAsync(
        CreateRoleRequest request)
    {
        var exists = await _context.Roles
            .AnyAsync(x => x.Name == request.Name);


        if (exists)
            throw new Exception("Role already exists.");


        var role = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };


        _context.Roles.Add(role);

        await _context.SaveChangesAsync();


        return new RoleResponse
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description ?? string.Empty
        };
    }


    public async Task<bool> UpdateAsync(
        Guid id,
        CreateRoleRequest request)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(x => x.Id == id);


        if (role == null)
            return false;


        role.Name = request.Name;
        role.Description = request.Description;


        await _context.SaveChangesAsync();

        return true;
    }


    public async Task<bool> DeleteAsync(Guid id)
    {
        var role = await _context.Roles
            .FirstOrDefaultAsync(x => x.Id == id);


        if (role == null)
            return false;


        _context.Roles.Remove(role);

        await _context.SaveChangesAsync();

        return true;
    }
}