using FAATPRO.Application.Features.Ledgers.DTOs;

namespace FAATPRO.Application.Features.Ledgers.Interfaces;

public interface ILedgerService
{
    Task<List<LedgerResponse>> GetAllAsync();

    Task<LedgerResponse?> GetByIdAsync(Guid id);

    Task<LedgerResponse> CreateAsync(
        CreateLedgerRequest request);

    Task<bool> UpdateAsync(
        Guid id,
        CreateLedgerRequest request);

    Task<bool> DeleteAsync(Guid id);
}