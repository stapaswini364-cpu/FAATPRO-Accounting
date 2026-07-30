using FAATPRO.Application.Features.FinancialYears.DTOs;
using FAATPRO.Application.Features.FinancialYears.Interfaces;

using FinancialYearEntity = FAATPRO.Domain.Entities.FinancialYear;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.FinancialYear;


public class FinancialYearService : IFinancialYearService
{

    private readonly ApplicationDbContext _context;


    public FinancialYearService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<FinancialYearResponse>> GetAllAsync()
    {
        return await _context.FinancialYears

            .Select(x => new FinancialYearResponse
            {
                Id = x.Id,

                CompanyId = x.CompanyId,

                YearName = x.YearName,

                StartDate = x.StartDate,

                EndDate = x.EndDate,

                IsCurrent = x.IsCurrent

            })

            .ToListAsync();
    }




    public async Task<FinancialYearResponse?> GetByIdAsync(
        Guid id)
    {

        var year =
            await _context.FinancialYears
            .FirstOrDefaultAsync(x => x.Id == id);


        if (year == null)
            return null;



        return new FinancialYearResponse
        {
            Id = year.Id,

            CompanyId = year.CompanyId,

            YearName = year.YearName,

            StartDate = year.StartDate,

            EndDate = year.EndDate,

            IsCurrent = year.IsCurrent
        };
    }





    public async Task<FinancialYearResponse> CreateAsync(
        CreateFinancialYearRequest request)
    {

        var year = new FinancialYearEntity
        {
            Id = Guid.NewGuid(),

            CompanyId = request.CompanyId,

            YearName = request.YearName,

            StartDate = request.StartDate,

            EndDate = request.EndDate,

            IsCurrent = request.IsCurrent
        };


        await _context.FinancialYears.AddAsync(year);

        await _context.SaveChangesAsync();


        return await GetByIdAsync(year.Id)
            ?? throw new Exception(
                "Financial year creation failed");
    }





    public async Task<bool> UpdateAsync(
        Guid id,
        CreateFinancialYearRequest request)
    {

        var year =
            await _context.FinancialYears
            .FirstOrDefaultAsync(x => x.Id == id);


        if (year == null)
            return false;



        year.CompanyId = request.CompanyId;

        year.YearName = request.YearName;

        year.StartDate = request.StartDate;

        year.EndDate = request.EndDate;

        year.IsCurrent = request.IsCurrent;



        await _context.SaveChangesAsync();


        return true;
    }





    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var year =
            await _context.FinancialYears
            .FirstOrDefaultAsync(x => x.Id == id);


        if (year == null)
            return false;



        _context.FinancialYears.Remove(year);


        await _context.SaveChangesAsync();


        return true;
    }

}