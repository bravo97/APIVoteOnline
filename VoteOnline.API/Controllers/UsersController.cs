using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteOnline.Application;
using VoteOnline.Domain.Models;
using VoteOnline.Infratructure;

namespace VoteOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserResponsitory userResponsitory;
        public UsersController(UserResponsitory responsitory) {
            this.userResponsitory = responsitory;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserModel user)
        {
            if (user == null) { return BadRequest() ; }
            var token = await userResponsitory.AuthenticateAsync(user);
            if (token == null) { 
                return NotFound("Đăng nhập thất bại");
            }

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] MainAccountModel mainAccount)
        {
            if (mainAccount == null) { return BadRequest(new { Message  = "Vui lòng nhập thông tin"}); }

            if ((bool)await userResponsitory.CheckEmailExists(mainAccount.Email)) {
                return BadRequest(new { Message = "Email đã được đăng ký" }); 
                    }

            var _user = await userResponsitory.Register(mainAccount);
            return Ok(_user);
        }
    }
}
