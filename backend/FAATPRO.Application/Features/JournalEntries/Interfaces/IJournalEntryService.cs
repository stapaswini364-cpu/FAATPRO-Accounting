using FAATPRO.Application.Features.JournalEntries.DTOs;

namespace FAATPRO.Application.Features.JournalEntries.Interfaces;

public interface IJournalEntryService
{
    Task<List<JournalEntryResponse>> GetAllAsync();

    Task<JournalEntryResponse?> GetByIdAsync(Guid id);

    Task<JournalEntryResponse> CreateAsync(
        CreateJournalEntryRequest request);

    Task<JournalEntryResponse> UpdateAsync(
        Guid id,
        CreateJournalEntryRequest request);

    Task<bool> DeleteAsync(Guid id);
}