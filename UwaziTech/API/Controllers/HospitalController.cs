using Microsoft.AspNetCore.Mvc;
using UwaziTech.API.Model.Request;
using UwaziTech.API.Model.Response;
using UwaziTech.Core.Services;
using UwaziTech.Core.Services.Interfaces;

namespace UwaziTech.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _service;
        public HospitalController(IHospitalService service) 
        {
            _service = service;
        }

        [HttpPost("add-hospital")]
        public async Task<IActionResult> AddHospitalDetails([FromBody] HospitalRequest request, CancellationToken token)
        {
            var result = await _service.AddHospitalDetailsAsync(request, token);

            return Ok(result);
        }

        [HttpPost("add-hospital-admin")]
        public async Task<IActionResult> AddHospitalAdmin([FromBody] HospitalAdminRequest request, CancellationToken token)
        {
            var result = await _service.AddHospitalAdminAsync(request, token);

            return Ok(result);
        }

        [HttpGet("fetch-hospital-details")]
        public async Task<IActionResult> FetchHospitalDetails(string reference, CancellationToken token)
        {
            var result = await _service.FetchHospitalDetailsAsync(reference, token);

            return Ok(result);
        }

        [HttpPost("upload-invoice")]
        public async Task<IActionResult> UploadInvoice([FromBody] InvoiceRequest request, CancellationToken token)
        {
            var result = _insuranceService.UploadInvoiceAsync(request, token);
            return Ok(result);
        }
    }
}
