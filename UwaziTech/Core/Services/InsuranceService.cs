using Microsoft.EntityFrameworkCore;
using UwaziTech.API.Model.Response;
using UwaziTech.Core.Models;
using UwaziTech.Core.Models.request;
using UwaziTech.Core.Models.response;
using UwaziTech.Core.Services.Interfaces;
using UwaziTech.Infrastructure.Context;

namespace UwaziTech.Core.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly AppDbContext _appDbContext;

        public InsuranceService(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<ApiResponse<AdminDetails>> AddInsuranceAdminAsync(AdminDetails request, CancellationToken token)
        {
            await _appDbContext.AdminDetail.AddAsync(request);
            var result = await _appDbContext.SaveChangesAsync(token) > 0;

            if (result) 
            {
                return new ApiResponse<AdminDetails>
                {
                    StatusCode = ResponseCode.OK,
                    StatusMessage = StatusMessage.DB_ADD_SUCCESSFUL,
                    ResponseObject = request
                };
            }
            else
            {
                return new ApiResponse<AdminDetails>
                {
                    StatusCode = ResponseCode.FAILED,
                    StatusMessage = StatusMessage.DB_ADD_UNSUCCESSFUL,
                    ResponseObject = request
                };
            }
        }

        public async Task<ApiResponse<InsuranceDetails>> AddInsuranceDetailsAsync(InsuranceDetails request, CancellationToken token)
        {
            _appDbContext.InsuranceDetail.Add(request);
            var result = await _appDbContext.SaveChangesAsync(token) > 0;

            if (result)
            {
                return new ApiResponse<InsuranceDetails>
                {
                    StatusCode = ResponseCode.OK,
                    StatusMessage = StatusMessage.DB_ADD_SUCCESSFUL,
                    ResponseObject = request
                };
            }
            else
            {
                return new ApiResponse<InsuranceDetails>
                {
                    StatusCode = ResponseCode.FAILED,
                    StatusMessage = StatusMessage.DB_ADD_UNSUCCESSFUL,
                    ResponseObject = request
                };
            }          
            
        }

        public async Task<ApiResponse<AdminModel>> GetAdminDetailsAsync(string reference, CancellationToken token)
        {
            var details = await _appDbContext.AdminDetail.Where(e => e.Reference == reference).FirstOrDefaultAsync();

            if (details != null)
            {
                return new ApiResponse<AdminModel>
                {
                    StatusCode = ResponseCode.OK,
                    StatusMessage = StatusMessage.RECORD_FOUND,
                    ResponseObject = details
                };
            }
            else
            {
                return new ApiResponse<AdminModel>
                {
                    StatusCode = ResponseCode.FAILED,
                    StatusMessage = StatusMessage.RECORD_MISSING
                };
            }
        }

        public ApiResponse GetInsuranceClaimsAsync(string reference, CancellationToken token)
        {
            return new ApiResponse
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.PENDING_IMPLEMENTATION
            };
        }

        public async Task<ApiResponse<InsuranceModel>> GetInsuranceDetailsAsync(string reference, CancellationToken token)
        {
            var details = await _appDbContext.InsuranceDetail.Where(e => e.Reference == reference).FirstOrDefaultAsync();

            if (details != null)
            {
                return new ApiResponse<InsuranceModel>
                {
                    StatusCode = ResponseCode.OK,
                    StatusMessage = StatusMessage.RECORD_FOUND,
                    ResponseObject = details
                };
            }
            else 
            {
                return new ApiResponse<InsuranceModel> 
                {
                    StatusCode = ResponseCode.FAILED,
                    StatusMessage = StatusMessage.RECORD_MISSING
                };
            }
        }

        public async Task<ApiResponse<StatisticModel>> GetStatisticsAsync(CancellationToken token)
        {
            var results = new StatisticModel
            {
                FlaggedConfirmations = 10,
                FraudReports = 10,
                InvoicesUploadedNumber = 10,
                NumberOfHospital = 10,
                NumberOfInsurance = 10,
            };

            return new ApiResponse<StatisticModel>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.PENDING_IMPLEMENTATION,
                ResponseObject = results
            };
        }

    }
}
