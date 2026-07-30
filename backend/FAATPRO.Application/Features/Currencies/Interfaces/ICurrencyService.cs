using FAATPRO.Application.Features.Currencies.DTOs;

namespace FAATPRO.Application.Features.Currencies.Interfaces;

public interface ICurrencyService
{
    Task<List<CurrencyResponse>> GetAllAsync();

    Task<CurrencyResponse?> GetByIdAsync(Guid id);

    Task<CurrencyResponse> CreateAsync(
        CreateCurrencyRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        CreateCurrencyRequest request);

    Task<bool> DeleteAsync(Guid id);
}