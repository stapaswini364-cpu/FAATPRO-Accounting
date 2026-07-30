using FAATPRO.Application.Features.Cities.DTOs;
using FAATPRO.Application.Features.Cities.Interfaces;

using CityEntity = FAATPRO.Domain.Entities.City;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.City;


public class CityService : ICityService
{

    private readonly ApplicationDbContext _context;


    public CityService(
        ApplicationDbContext context)
    {
        _context = context;
    }







    public async Task<List<CityResponse>> GetAllAsync()
    {

        return await _context.Cities

            .Select(x => new CityResponse
            {

                Id = x.Id,

                StateId = x.StateId,

                Code = x.Code,

                Name = x.Name,

                IsActive = x.IsActive,

                CreatedAt = x.CreatedAt

            })

            .ToListAsync();

    }









    public async Task<CityResponse?> GetByIdAsync(
        Guid id)
    {

        var city =
            await _context.Cities
            .FirstOrDefaultAsync(x => x.Id == id);



        if (city == null)
            return null;




        return new CityResponse
        {

            Id = city.Id,

            StateId = city.StateId,

            Code = city.Code,

            Name = city.Name,

            IsActive = city.IsActive,

            CreatedAt = city.CreatedAt

        };

    }









    public async Task<CityResponse> CreateAsync(
        CreateCityRequest request)
    {

        var city = new CityEntity
        {

            Id = Guid.NewGuid(),

            StateId = request.StateId,

            Code = request.Code,

            Name = request.Name,

            IsActive = request.IsActive

        };




        await _context.Cities.AddAsync(city);


        await _context.SaveChangesAsync();




        return await GetByIdAsync(city.Id)

            ?? throw new Exception(
                "City creation failed");

    }









    public async Task<bool> UpdateAsync(
        Guid id,
        CreateCityRequest request)
    {

        var city =
            await _context.Cities
            .FirstOrDefaultAsync(x => x.Id == id);




        if (city == null)
            return false;





        city.StateId = request.StateId;

        city.Code = request.Code;

        city.Name = request.Name;

        city.IsActive = request.IsActive;





        await _context.SaveChangesAsync();



        return true;

    }









    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var city =
            await _context.Cities
            .FirstOrDefaultAsync(x => x.Id == id);




        if (city == null)
            return false;





        _context.Cities.Remove(city);


        await _context.SaveChangesAsync();




        return true;

    }

}