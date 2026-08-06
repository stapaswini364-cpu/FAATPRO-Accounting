using FAATPRO.Application.Features.Reports.TrialBalance.DTOs;


namespace FAATPRO.Application.Features.Reports.TrialBalance.Interfaces;


public interface ITrialBalanceService
{

    Task<List<TrialBalanceResponse>> GetAsync();

}