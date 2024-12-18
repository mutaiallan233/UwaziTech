using UwaziTech.API.Model.Response;
using UwaziTech.Core.Models;
using UwaziTech.Core.Models.request;
using UwaziTech.Core.Models.response;

namespace UwaziTech.Core.Services.Interfaces
{
    public interface IInsuranceService
    {
        ApiResponse GetInsuranceClaimsAsync(string reference, CancellationToken token);
        Task<ApiResponse<StatisticModel>> GetStatisticsAsync(CancellationToken token);
        Task<ApiResponse<AdminModel>> GetAdminDetailsAsync(string reference, CancellationToken token);
        Task<ApiResponse<InsuranceModel>> GetInsuranceDetailsAsync(string id, CancellationToken token);
        Task<ApiResponse<AdminDetails>> AddInsuranceAdminAsync(AdminDetails request, CancellationToken token);
        Task<ApiResponse<InsuranceDetails>> AddInsuranceDetailsAsync(InsuranceDetails request, CancellationToken token);
    }
}
