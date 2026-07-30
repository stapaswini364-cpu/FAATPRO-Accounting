using FAATPRO.Application.Features.Currencies.DTOs;
using FAATPRO.Application.Features.Currencies.Interfaces;

using CurrencyEntity = FAATPRO.Domain.Entities.Currency;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Currency;


public class CurrencyService : ICurrencyService
{

    private readonly ApplicationDbContext _context;


    public CurrencyService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<CurrencyResponse>> GetAllAsync()
    {

        return await _context.Currencies

            .Select(x => new CurrencyResponse
            {
                Id = x.Id,

                Code = x.Code,

                Name = x.Name,

                Symbol = x.Symbol,

                IsActive = x.IsActive,

                CreatedAt = x.CreatedAt

            })

            .ToListAsync();

    }






    public async Task<CurrencyResponse?> GetByIdAsync(
        Guid id)
    {

        var currency =
            await _context.Currencies
            .FirstOrDefaultAsync(x => x.Id == id);



        if(currency == null)
            return null;




        return new CurrencyResponse
        {
            Id = currency.Id,

            Code = currency.Code,

            Name = currency.Name,

            Symbol = currency.Symbol,

            IsActive = currency.IsActive,

            CreatedAt = currency.CreatedAt
        };

    }







    public async Task<CurrencyResponse> CreateAsync(
        CreateCurrencyRequest request)
    {


        var currency = new CurrencyEntity
        {

            Id = Guid.NewGuid(),


            Code = request.Code,


            Name = request.Name,


            Symbol = request.Symbol,


            IsActive = true,


            CreatedAt = DateTime.UtcNow

        };



        await _context.Currencies.AddAsync(currency);


        await _context.SaveChangesAsync();




        return await GetByIdAsync(currency.Id)
            ?? throw new Exception(
                "Currency creation failed");

    }








    public async Task<bool> UpdateAsync(
        Guid id,
        CreateCurrencyRequest request)
    {

        var currency =
            await _context.Currencies
            .FirstOrDefaultAsync(x => x.Id == id);



        if(currency == null)
            return false;



        currency.Code = request.Code;


        currency.Name = request.Name;


        currency.Symbol = request.Symbol;




        await _context.SaveChangesAsync();



        return true;

    }








    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var currency =
            await _context.Currencies
            .FirstOrDefaultAsync(x => x.Id == id);



        if(currency == null)
            return false;




        _context.Currencies.Remove(currency);



        await _context.SaveChangesAsync();



        return true;

    }

}