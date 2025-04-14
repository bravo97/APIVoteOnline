using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteOnline.Domain.Models;
using VoteOnline.Infratructure;

namespace VoteOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly SubAccountController _service;
        public HomeController(SubAccountController service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SubAccountModel acc)
        {
            if (acc == null) { return BadRequest(new { Message = "Vui lòng nhập thông tin" }); }

            
            return Ok(acc);
        }
    }
}
