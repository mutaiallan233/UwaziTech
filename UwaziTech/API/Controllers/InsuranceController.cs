using Microsoft.AspNetCore.Mvc;
using UwaziTech.API.Model.Request;
using UwaziTech.Core.Services.Interfaces;

namespace UwaziTech.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsuranceService _insuranceService;

        public InsuranceController(IInsuranceService insuranceService)
        {
            _insuranceService = insuranceService;
        }

        [HttpPost("add-insurance-details")]
        public async Task<IActionResult> AddInsuranceDetails([FromBody] InsuranceRequest request, CancellationToken token)
        {
            var result = await _insuranceService.AddInsuranceDetailsAsync(request, token);
            return Ok(result);
        }

        [HttpPost("add-insurance-admin")]
        public async Task<IActionResult> AddInsuranceAdmin([FromBody] AdminRequest request, CancellationToken token)
        {
            var result = await _insuranceService.AddInsuranceAdminAsync(request, token);
            return Ok(result);
        }

        [HttpGet("get-insurance-details")]
        public async Task<IActionResult> GetInsuranceDetails(string reference, CancellationToken token) 
        {
            var result = await _insuranceService.GetInsuranceDetailsAsync(reference, token);
            return Ok(result);
        }

        [HttpGet("get-insurance-admin")]
        public async Task<IActionResult> GetAdminDetails(string reference, CancellationToken token) 
        {
            var result = await _insuranceService.GetAdminDetailsAsync(reference, token);
            return Ok(result);
        }

        [HttpGet("get-insurance-claims")]
        public async Task<IActionResult> GetInsuranceClaims(string reference, CancellationToken token)
        {
            var result =  _insuranceService.GetInsuranceClaimsAsync(reference, token);
            return Ok(result);
        }

        [HttpGet("fetch-statistics")]
        public async Task<IActionResult> GetStatistics(CancellationToken token)
        {
            var result = await _insuranceService.GetStatisticsAsync(token);
            return Ok(result);
        }
    }
}
