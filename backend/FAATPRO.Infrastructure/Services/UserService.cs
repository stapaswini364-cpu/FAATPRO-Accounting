using FAATPRO.Application.Features.Users.DTOs;
using FAATPRO.Application.Features.Users.Interfaces;
using FAATPRO.Domain.Entities;
using FAATPRO.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAATPRO.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<List<UserResponse>> GetAllAsync()
    {
        return await _context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .Select(x => new UserResponse
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                IsActive = x.IsActive,

                Roles = x.UserRoles
                    .Select(r => r.Role.Name)
                    .ToList()
            })
            .ToListAsync();
    }



    public async Task<UserResponse?> GetByIdAsync(Guid id)
    {
        var user = await _context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == id);


        if (user == null)
            return null;


        return new UserResponse
        {
            Id = user.Id,
            FullName = user.FullName,
            Email = user.Email,
            IsActive = user.IsActive,

            Roles = user.UserRoles
                .Select(x => x.Role.Name)
                .ToList()
        };
    }



    public async Task<UserResponse> CreateAsync(
        CreateUserRequest request)
    {
        var exists = await _context.Users
            .AnyAsync(x => x.Email == request.Email);


        if (exists)
            throw new Exception(
                "User already exists.");



        var user = new User
        {
            Id = Guid.NewGuid(),

            FullName = request.FullName,

            Email = request.Email,

            PasswordHash = BCrypt.Net.BCrypt
                .HashPassword(request.Password),

            IsActive = request.IsActive
        };


        _context.Users.Add(user);



        foreach (var roleId in request.RoleIds)
        {
            _context.UserRoles.Add(
                new UserRole
                {
                    UserId = user.Id,

                    RoleId = roleId
                });
        }



        await _context.SaveChangesAsync();



        return new UserResponse
        {
            Id = user.Id,

            FullName = user.FullName,

            Email = user.Email,

            IsActive = user.IsActive
        };
    }



    public async Task<bool> UpdateAsync(
        Guid id,
        UpdateUserRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);


        if (user == null)
            return false;



        user.FullName = request.FullName;

        user.Email = request.Email;

        user.IsActive = request.IsActive;



        await _context.SaveChangesAsync();


        return true;
    }




    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == id);



        if (user == null)
            return false;



        _context.Users.Remove(user);


        await _context.SaveChangesAsync();


        return true;
    }
}