using FAATPRO.Application.Features.Countries.DTOs;


namespace FAATPRO.Application.Features.Countries.Interfaces;


public interface ICountryService
{

    Task<List<CountryResponse>> GetAllAsync();


    Task<CountryResponse?> GetByIdAsync(Guid id);


    Task<CountryResponse> CreateAsync(
        CreateCountryRequest request);


    Task<bool> UpdateAsync(
        Guid id,
        CreateCountryRequest request);


    Task<bool> DeleteAsync(Guid id);

}