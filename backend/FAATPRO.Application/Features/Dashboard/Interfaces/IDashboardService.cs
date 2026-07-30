using FAATPRO.Application.Features.Dashboard.DTOs;

namespace FAATPRO.Application.Features.Dashboard.Interfaces;

public interface IDashboardService
{
    Task<DashboardSummaryDto> GetSummaryAsync();
}