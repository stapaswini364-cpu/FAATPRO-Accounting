using FAATPRO.Application.Features.Cities.DTOs;


namespace FAATPRO.Application.Features.Cities.Interfaces;


public interface ICityService
{

    Task<List<CityResponse>> GetAllAsync();


    Task<CityResponse?> GetByIdAsync(Guid id);


    Task<CityResponse> CreateAsync(
        CreateCityRequest request);


    Task<bool> UpdateAsync(
        Guid id,
        CreateCityRequest request);


    Task<bool> DeleteAsync(
        Guid id);

}