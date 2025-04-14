using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteOnline.Domain.Models;
using VoteOnline.Domain.Models.Update;
using VoteOnline.Infratructure;

namespace VoteOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccountController : ControllerBase
    {
        private readonly SubAccountResponsitory _service;
        public SubAccountController(SubAccountResponsitory subAccount) {
            _service = subAccount;
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get(string text, int pageIndex, int pageSize, int IdAccount,int idvande)
        {
            if (IdAccount == 0) { return BadRequest("Không xác thực được tài khoản"); }
            var datas = await _service.GetAllSubAccountAsync(text,pageIndex, pageSize, IdAccount,idvande);
            if (datas == null) { return NotFound("Không tìm thấy dữ liệu"); }

            return Ok(datas);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] SubAccountRequest subacc)
        {
            if (subacc == null) { return BadRequest("Vui lòng nhập dữ liệu"); }

            var datas = await this._service.AddSubAccountAsync(subacc);

            if (datas == null) { return BadRequest("Không lưu được dữ liệu"); }

            return Ok(datas);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] SubAccountRequest subacc)
        {
            if (subacc == null) { return BadRequest("Vui lòng nhập dữ liệu"); }

            var datas = await this._service.UpdateSubAccountAsync(subacc);

            if (!datas) { return BadRequest("Không lưu được dữ liệu"); }

            return Ok(datas);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> RemoveAsync([FromBody] SubAccountModel subacc)
        {
            if (subacc == null) { return BadRequest("Vui lòng nhập dữ liệu"); }

            var datas = await this._service.DeleteSubAccountAsync(subacc);

            if (!datas) { return BadRequest("Không lưu được dữ liệu"); }

            return Ok(datas);
        }

    }
}
