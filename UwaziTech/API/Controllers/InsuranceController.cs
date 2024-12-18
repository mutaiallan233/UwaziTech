using Microsoft.AspNetCore.Mvc;
using UwaziTech.API.Model.Request;
using UwaziTech.Core.Services.Interfaces;

namespace UwaziTech.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _service;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _service = insuranceService;
        }

        [HttpPost("add-insurance-details")]
        public async Task<IActionResult> AddInsuranceDetails([FromBody] InsuranceRequest request, CancellationToken token)
        {
            var result = await _service.AddInsuranceDetailsAsync(request, token);
            return Ok(result);
        }

        [HttpPost("add-insurance-admin")]
        public async Task<IActionResult> AddInsuranceAdmin([FromBody] AdminRequest request, CancellationToken token)
        {
            var result = await _service.AddInsuranceAdminAsync(request, token);
            return Ok(result);
        }

        [HttpGet("get-insurance-details")]
        public async Task<IActionResult> GetInsuranceDetails(string reference, CancellationToken token) 
        {
            var result = await _service.GetInsuranceDetailsAsync(reference, token);
            return Ok(result);
        }

        [HttpGet("get-insurance-admin")]
        public async Task<IActionResult> GetAdminDetails(string reference, CancellationToken token) 
        {
            var result = await _service.GetAdminDetailsAsync(reference, token);
            return Ok(result);
        }

        [HttpGet("get-insurance-claims")]
        public async Task<IActionResult> GetInsuranceClaims(string reference, CancellationToken token)
        {
            var result =  _service.GetInsuranceClaimsAsync(reference, token);
            return Ok(result);
        }

        [HttpGet("fetch-statistics")]
        public async Task<IActionResult> GetStatistics(CancellationToken token)
        {
            var result = await _service.GetStatisticsAsync(token);
            return Ok(result);
        }
    }
}
