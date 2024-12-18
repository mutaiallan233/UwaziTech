using Microsoft.AspNetCore.Mvc;
using UwaziTech.API.Filters;
using UwaziTech.API.Model.Request;
using UwaziTech.Core.Services.Interfaces;

namespace UwaziTech.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) 
        {
            _service = service;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser(UserRequest request, CancellationToken token)
        {
            var result = await _service.AddUserAsync(request, token);
            return Ok(result);
        }

        [HttpGet("pre-request")]
        public async Task<IActionResult> PreRequest(CancellationToken token)
        {
            var result = await _service.PreRequestAsync(token);
            return Ok(result);
        }

        [HttpPatch("update-user-detail")]
        [RequiresFieldFromPayload("Reference")]
        public async Task<IActionResult> UpdateUserDetails(UserRequest request, CancellationToken token)
        {
            var result = await _service.UpdateUserDetailsAsync(request, token);
            return Ok(result);
        }
    }
}
