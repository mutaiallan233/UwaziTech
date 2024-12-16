using Microsoft.EntityFrameworkCore;
using UwaziTech.Core.Models;
using UwaziTech.Core.Models.request;
using UwaziTech.Core.Services.Interfaces;
using UwaziTech.Infrastructure.Context;

namespace UwaziTech.Core.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _appDbContext;
    private readonly ILogger _logger;

    public UserService(AppDbContext appDbContext, ILogger logger)
    {
        _logger = logger;
        _appDbContext = appDbContext;
    }

    public async Task<ApiResponse<UserDetails>> AddUserAsync(UserDetails request, CancellationToken token)
    {
        _appDbContext.UserDetail.Add(request);
        var result = await _appDbContext.SaveChangesAsync(token) > 0;

        if (result) 
        {
            return new ApiResponse<UserDetails>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.DB_ADD_SUCCESSFUL,
                ResponseObject = request,
            };
        }
        else
        {
            return new ApiResponse<UserDetails>
            {
                StatusCode = ResponseCode.FAILED,
                StatusMessage = StatusMessage.DB_ADD_UNSUCCESSFUL,
            };
        }        
    }

    public async Task<ApiResponse> PreRequestAsync(CancellationToken token)
    {
        return new ApiResponse
        {
            StatusCode = ResponseCode.OK,
            StatusMessage = StatusMessage.PENDING_IMPLEMENTATION,
        };
    }

    public async Task<ApiResponse<UserDetails>> UpdateUserDetailsAsync(UserDetails request, CancellationToken token)
    {
        try
        {
            var details = await _appDbContext.UserDetail
                                                     .FirstOrDefaultAsync(e => e.Reference == request.Reference);

            if (details == null)
            {
                return new ApiResponse<UserDetails>
                {
                    StatusCode = ResponseCode.FAILED,
                    StatusMessage = StatusMessage.RECORD_MISSING,
                    ResponseObject = null
                };
            }

            // Check for differences between the request and the existing entity (this can be done better)
            bool isUpdated = false;

            if (details.Username != request.Username)
            {
                details.Username = request.Username;
                isUpdated = true;
            }
            if (details.BranchName != request.BranchName)
            {
                details.BranchName = request.BranchName;
                isUpdated = true;
            }
            if (details.Password != request.Password)
            {
                details.Password = request.Password;
                isUpdated = true;
            }


            if (!isUpdated)
            {
                return new ApiResponse<UserDetails>
                {
                    StatusCode = ResponseCode.INVALIDREQUEST,
                    StatusMessage = StatusMessage.UPDATE_NOT_NEEDED,
                    ResponseObject = null
                };
            }

            await _appDbContext.SaveChangesAsync();

            return new ApiResponse<UserDetails>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.DB_ADD_SUCCESSFUL,
                ResponseObject = details
            };
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"An exception occured: {ex.ToString()}");
            _logger.LogError(ex.Message);

            return new ApiResponse<UserDetails>
            {
                StatusCode = ResponseCode.FAILED,
                StatusMessage = StatusMessage.ERROR,
                ResponseObject = null
            };
        }

    }
}
