using UwaziTech.Core.Models;
using UwaziTech.API.Model.Response;
using Microsoft.EntityFrameworkCore;
using UwaziTech.Core.Models.request;
using UwaziTech.Infrastructure.Context;
using UwaziTech.Core.Services.Interfaces;

namespace UwaziTech.Core.Services;

public class HospitalService : IHospitalService
{
    private readonly AppDbContext _appDbContext;
    public HospitalService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<ApiResponse<HospitalAdminDetails>> AddHospitalAdminAsync(HospitalAdminDetails request, CancellationToken token)
    {
        _appDbContext.HospitalAdminDetail.Add(request);
        
        var result = await _appDbContext.SaveChangesAsync(token) > 0;

        if (result)
        {
            return new ApiResponse<HospitalAdminDetails>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.DB_ADD_SUCCESSFUL,
                ResponseObject = request,
            };
        }
        else
        {
            return new ApiResponse<HospitalAdminDetails>
            {
                StatusCode = ResponseCode.FAILED,
                StatusMessage = StatusMessage.DB_ADD_UNSUCCESSFUL,
                ResponseObject = request,
            };
        }
    }

    public async Task<ApiResponse<HospitalDetails>> AddHospitalDetailsAsync(HospitalDetails request, CancellationToken token)
    {
        _appDbContext.HospitalDetail.Add(request);

        var result = await _appDbContext.SaveChangesAsync(token) > 0;

        if (result)
        {
            return new ApiResponse<HospitalDetails>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.DB_ADD_SUCCESSFUL,
                ResponseObject = request,
            };        
        }
        else
        {
            return new ApiResponse<HospitalDetails>
            {
                StatusCode = ResponseCode.FAILED,
                StatusMessage = StatusMessage.DB_ADD_UNSUCCESSFUL,
                ResponseObject = request,
            };
        }
    }

    public async Task<ApiResponse<FetchHospitalDetailsModel>> FetchHospitalDetailsAsync(string reference, CancellationToken token)
    {
        var result = await _appDbContext.HospitalDetail.Where(e => e.Reference == reference).FirstOrDefaultAsync(token);
        var result2 = await _appDbContext.HospitalAdminDetail.Where(e => e.Reference == reference).FirstOrDefaultAsync(token);


        var hospital_result = new List<HospitalModel>
        {
            new HospitalModel
            {
                Address = "the address",
                Branch = "nairobi branch",
                HospitalName = "Mp shah"
            },
            new HospitalModel
            {
                Address = "another address",
                Branch = "kisumu branch",
                HospitalName = "Aga Khan"
            },
            new HospitalModel
            {
                Address = "yet another address",
                Branch = "mombasa branch",
                HospitalName = "Coast General"
            }
        };

        var hospital_admin = new List<HospitalAdminModel>
        {
            new HospitalAdminModel
            {
                Hospital = "Mp Shah",
                Username = "Hosp Admin",
                Role = "Admin",
                Password = "****"
            },
            new HospitalAdminModel
            {
                Hospital = "Aga Khan",
                Username = "Admin1",
                Role = "Super Admin",
                Password = "****"
            },
            new HospitalAdminModel
            {
                Hospital = "Coast General",
                Username = "Manager",
                Role = "Manager",
                Password = "****"
            }
        };

        var stub_result = new FetchHospitalDetailsModel
        {
            HospitalAdmins = hospital_admin,
            HospitalModels = hospital_result
        };

        if (stub_result != null)
        {
            return new ApiResponse<FetchHospitalDetailsModel>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.RECORD_FOUND,
                ResponseObject = stub_result
            };
        }
        else
        {
            return new ApiResponse<FetchHospitalDetailsModel>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.RECORD_MISSING,
            };
        }        
    }

    public async Task<ApiResponse<InvoiceDetails>> UploadInvoiceAsync(InvoiceDetails request, CancellationToken token)
    {
        _appDbContext.InvoiceDetails.Add(request);
        var result = await _appDbContext.SaveChangesAsync(token) > 0;

        if (result)
        {
            return new ApiResponse<InvoiceDetails>
            {
                StatusCode = ResponseCode.OK,
                StatusMessage = StatusMessage.DB_ADD_SUCCESSFUL,
                ResponseObject = request
            };
        }
        else
        {
            return new ApiResponse<InvoiceDetails>
            {
                StatusCode = ResponseCode.FAILED,
                StatusMessage = StatusMessage.DB_ADD_UNSUCCESSFUL,
                ResponseObject = request
            };
        }
    }
}
