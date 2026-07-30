using FAATPRO.Application.Features.FinancialYears.DTOs;

namespace FAATPRO.Application.Features.FinancialYears.Interfaces;


public interface IFinancialYearService
{

    Task<List<FinancialYearResponse>> GetAllAsync();


    Task<FinancialYearResponse?> GetByIdAsync(
        Guid id);



    Task<FinancialYearResponse> CreateAsync(
        CreateFinancialYearRequest request);



    Task<bool> UpdateAsync(
        Guid id,
        CreateFinancialYearRequest request);



    Task<bool> DeleteAsync(
        Guid id);

}