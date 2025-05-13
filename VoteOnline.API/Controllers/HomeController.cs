using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VoteOnline.Domain.Entities;
using VoteOnline.Infratructure;

namespace VoteOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private SubAccountResponsitory _subAccount;
        private VanDeResponsitory _vanDe;
        public HomeController(SubAccountResponsitory subAccount, VanDeResponsitory vanDe)
        {
            _subAccount = subAccount;
            _vanDe = vanDe;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] SubAccount acc)
        {
            if (acc == null) return BadRequest("Vui lòng nhập đủ thông tin");
            var subacc = await this._subAccount.AddSubAccountAsync(acc);
            return Ok(subacc);
        }

        [Authorize]
        [HttpPost("get")]
        public async Task<IActionResult> GetVanDe([FromBody] String vande)
        {
            if (vande == null) return BadRequest("Vui lòng nhập đủ thông tin");
            var lstVD = await this._vanDe.GetVanDeByCodeAsync(vande);
            return Ok(lstVD);
        }
    }
}
