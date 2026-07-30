using FAATPRO.Application.Features.Permissions.DTOs;
using FAATPRO.Application.Features.Permissions.Interfaces;
using FAATPRO.Domain.Entities;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Services;

public class PermissionService : IPermissionService
{
    private readonly ApplicationDbContext _context;


    public PermissionService(ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<PermissionResponse>> GetAllAsync()
    {
        return await _context.Permissions
            .Select(x => new PermissionResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description ?? string.Empty
            })
            .ToListAsync();
    }



    public async Task<PermissionResponse?> GetByIdAsync(Guid id)
    {
        var permission = await _context.Permissions
            .FirstOrDefaultAsync(x => x.Id == id);


        if (permission == null)
            return null;


        return new PermissionResponse
        {
            Id = permission.Id,
            Name = permission.Name,
            Description = permission.Description ?? string.Empty
        };
    }




    public async Task<PermissionResponse> CreateAsync(
        CreatePermissionRequest request)
    {

        var exists = await _context.Permissions
            .AnyAsync(x => x.Name == request.Name);


        if (exists)
            throw new Exception(
                "Permission already exists.");



        var permission = new Permission
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };


        _context.Permissions.Add(permission);

        await _context.SaveChangesAsync();



        return new PermissionResponse
        {
            Id = permission.Id,
            Name = permission.Name,
            Description = permission.Description ?? string.Empty
        };
    }




    public async Task<bool> UpdateAsync(
        Guid id,
        CreatePermissionRequest request)
    {

        var permission = await _context.Permissions
            .FirstOrDefaultAsync(x => x.Id == id);


        if (permission == null)
            return false;



        permission.Name = request.Name;
        permission.Description = request.Description;


        await _context.SaveChangesAsync();


        return true;
    }





    public async Task<bool> DeleteAsync(Guid id)
    {

        var permission = await _context.Permissions
            .FirstOrDefaultAsync(x => x.Id == id);


        if (permission == null)
            return false;



        _context.Permissions.Remove(permission);

        await _context.SaveChangesAsync();


        return true;
    }
}