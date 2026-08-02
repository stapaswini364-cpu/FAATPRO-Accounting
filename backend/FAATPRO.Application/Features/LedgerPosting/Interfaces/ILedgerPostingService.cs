using FAATPRO.Application.Features.LedgerPosting.DTOs;

namespace FAATPRO.Application.Features.LedgerPosting.Interfaces;


public interface ILedgerPostingService
{

    Task CreatePostingAsync(
        Guid journalEntryId
    );


    Task<List<LedgerPostingResponse>> GetLedgerStatementAsync(
        Guid ledgerId
    );

}