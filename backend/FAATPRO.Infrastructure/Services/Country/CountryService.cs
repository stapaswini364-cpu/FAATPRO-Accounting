using FAATPRO.Application.Features.Countries.DTOs;
using FAATPRO.Application.Features.Countries.Interfaces;

using CountryEntity = FAATPRO.Domain.Entities.Country;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Country;


public class CountryService : ICountryService
{

    private readonly ApplicationDbContext _context;


    public CountryService(
        ApplicationDbContext context)
    {
        _context = context;
    }





    public async Task<List<CountryResponse>> GetAllAsync()
    {

        return await _context.Countries

            .Select(x => new CountryResponse
            {

                Id = x.Id,

                Code = x.Code,

                Name = x.Name,

                IsActive = x.IsActive,

                CreatedAt = x.CreatedAt

            })

            .ToListAsync();

    }







    public async Task<CountryResponse?> GetByIdAsync(
        Guid id)
    {

        var country =
            await _context.Countries
            .FirstOrDefaultAsync(x => x.Id == id);


        if (country == null)
            return null;



        return new CountryResponse
        {

            Id = country.Id,

            Code = country.Code,

            Name = country.Name,

            IsActive = country.IsActive,

            CreatedAt = country.CreatedAt

        };

    }








    public async Task<CountryResponse> CreateAsync(
        CreateCountryRequest request)
    {

        var country = new CountryEntity
        {

            Id = Guid.NewGuid(),

            Code = request.Code,

            Name = request.Name,

            IsActive = request.IsActive

        };



        await _context.Countries.AddAsync(country);


        await _context.SaveChangesAsync();



        return await GetByIdAsync(country.Id)
            ?? throw new Exception(
                "Country creation failed");

    }








    public async Task<bool> UpdateAsync(
        Guid id,
        CreateCountryRequest request)
    {

        var country =
            await _context.Countries
            .FirstOrDefaultAsync(x => x.Id == id);



        if (country == null)
            return false;



        country.Code = request.Code;

        country.Name = request.Name;

        country.IsActive = request.IsActive;



        await _context.SaveChangesAsync();


        return true;

    }








    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var country =
            await _context.Countries
            .FirstOrDefaultAsync(x => x.Id == id);



        if (country == null)
            return false;



        _context.Countries.Remove(country);


        await _context.SaveChangesAsync();


        return true;

    }

}