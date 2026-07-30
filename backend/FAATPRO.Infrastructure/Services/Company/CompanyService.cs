using FAATPRO.Application.Features.Companies.DTOs;
using FAATPRO.Application.Features.Companies.Interfaces;

using CompanyEntity = FAATPRO.Domain.Entities.Company;

using FAATPRO.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;


namespace FAATPRO.Infrastructure.Services.Company;


public class CompanyService : ICompanyService
{

    private readonly ApplicationDbContext _context;


    public CompanyService(
        ApplicationDbContext context)
    {
        _context = context;
    }



    public async Task<List<CompanyResponse>> GetAllAsync()
    {

        return await _context.Companies

            .Select(x => new CompanyResponse
            {
                Id = x.Id,

                CompanyCode = x.CompanyCode,

                CompanyName = x.CompanyName,

                LegalName = x.LegalName,

                GSTNumber = x.GSTNumber,

                PANNumber = x.PANNumber,

                CINNumber = x.CINNumber,

                Email = x.Email,

                Phone = x.Phone,

                Website = x.Website,

                AddressLine1 = x.AddressLine1,

                AddressLine2 = x.AddressLine2,

                City = x.City,

                State = x.State,

                Country = x.Country,

                PostalCode = x.PostalCode,

                CurrencyCode = x.CurrencyCode,

                FinancialYearStartMonth =
                    x.FinancialYearStartMonth,

                IsActive = x.IsActive,

                CreatedAt = x.CreatedAt

            })

            .ToListAsync();

    }





    public async Task<CompanyResponse?> GetByIdAsync(
        Guid id)
    {

        var company =
            await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == id);



        if (company == null)
            return null;



        return new CompanyResponse
        {
            Id = company.Id,

            CompanyCode = company.CompanyCode,

            CompanyName = company.CompanyName,

            LegalName = company.LegalName,

            GSTNumber = company.GSTNumber,

            PANNumber = company.PANNumber,

            CINNumber = company.CINNumber,

            Email = company.Email,

            Phone = company.Phone,

            Website = company.Website,

            AddressLine1 = company.AddressLine1,

            AddressLine2 = company.AddressLine2,

            City = company.City,

            State = company.State,

            Country = company.Country,

            PostalCode = company.PostalCode,

            CurrencyCode = company.CurrencyCode,

            FinancialYearStartMonth =
                company.FinancialYearStartMonth,

            IsActive = company.IsActive,

            CreatedAt = company.CreatedAt
        };

    }





    public async Task<CompanyResponse> CreateAsync(
        CreateCompanyRequest request)
    {


        var company = new CompanyEntity
        {
            Id = Guid.NewGuid(),

            CompanyCode = request.CompanyCode,

            CompanyName = request.CompanyName,

            LegalName = request.LegalName,


            GSTNumber = request.GSTNumber,

            PANNumber = request.PANNumber,

            CINNumber = request.CINNumber,


            Email = request.Email,

            Phone = request.Phone,

            Website = request.Website,


            AddressLine1 = request.AddressLine1,

            AddressLine2 = request.AddressLine2,

            City = request.City,

            State = request.State,

            Country = request.Country,

            PostalCode = request.PostalCode,


            CurrencyCode = request.CurrencyCode,

            FinancialYearStartMonth =
                request.FinancialYearStartMonth
        };



        await _context.Companies.AddAsync(company);


        await _context.SaveChangesAsync();



        return await GetByIdAsync(company.Id)
            ?? throw new Exception(
                "Company creation failed");

    }





    public async Task<bool> UpdateAsync(
        Guid id,
        CreateCompanyRequest request)
    {

        var company =
            await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == id);



        if (company == null)
            return false;



        company.CompanyCode = request.CompanyCode;

        company.CompanyName = request.CompanyName;

        company.LegalName = request.LegalName;


        company.GSTNumber = request.GSTNumber;

        company.PANNumber = request.PANNumber;

        company.CINNumber = request.CINNumber;


        company.Email = request.Email;

        company.Phone = request.Phone;

        company.Website = request.Website;


        company.AddressLine1 = request.AddressLine1;

        company.AddressLine2 = request.AddressLine2;

        company.City = request.City;

        company.State = request.State;

        company.Country = request.Country;

        company.PostalCode = request.PostalCode;


        company.CurrencyCode = request.CurrencyCode;

        company.FinancialYearStartMonth =
            request.FinancialYearStartMonth;



        await _context.SaveChangesAsync();


        return true;

    }





    public async Task<bool> DeleteAsync(
        Guid id)
    {

        var company =
            await _context.Companies
            .FirstOrDefaultAsync(x => x.Id == id);



        if (company == null)
            return false;



        _context.Companies.Remove(company);


        await _context.SaveChangesAsync();


        return true;

    }

}