using FAATPRO.Application.Features.Customers.DTOs;

namespace FAATPRO.Application.Features.Customers.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync();

    Task<CustomerDto?> GetByIdAsync(Guid id);

    Task<CustomerDto> CreateAsync(
        CreateCustomerRequest request);

    Task<bool> DeleteAsync(Guid id);
}