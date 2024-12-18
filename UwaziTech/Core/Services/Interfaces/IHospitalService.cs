using Microsoft.AspNetCore.Mvc;
using UwaziTech.API.Model.Request;
using UwaziTech.API.Model.Response;
using UwaziTech.Core.Models;
using UwaziTech.Core.Models.request;

namespace UwaziTech.Core.Services.Interfaces;

public interface IHospitalService
{
    Task<ApiResponse<InvoiceDetails>> UploadInvoiceAsync(InvoiceDetails request, CancellationToken token);
    Task<ApiResponse<HospitalDetails>> AddHospitalDetailsAsync(HospitalDetails request, CancellationToken token);
    Task<ApiResponse<FetchHospitalDetailsModel>> FetchHospitalDetailsAsync(string reference, CancellationToken token);
    Task<ApiResponse<HospitalAdminDetails>> AddHospitalAdminAsync(HospitalAdminDetails request, CancellationToken token);


}
