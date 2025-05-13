using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VoteOnline.Domain.Entities;
using VoteOnline.Domain.Models.DTO;
using VoteOnline.Domain.Models.Update;
using VoteOnline.Infratructure;

namespace VoteOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VanDeController : ControllerBase
    {
        private readonly VanDeResponsitory _service;
        public VanDeController(VanDeResponsitory service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string text, int pageIndex, int pageSize, int IdAccount)
        {
            if(IdAccount == 0) { return BadRequest("Không xác thực được tài khoản"); }
            var datas = await _service.GetAllVanDeAsync( pageIndex, pageSize, IdAccount);
            if (datas == null) { return NotFound("Không tìm thấy dữ liệu"); }

            return Ok(datas);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] VanDeDTO vanDe)
        {
            if (vanDe == null) { return BadRequest("Vui lòng nhập dữ liệu"); }

            var datas = await this._service.AddVanDeAsync(vanDe);

            if (datas == null) { return BadRequest("Không lưu được dữ liệu"); }

            return Ok(datas);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] VanDeDTO vanDe)
        {
            if (vanDe == null) { return BadRequest("Vui lòng nhập dữ liệu"); }

            var datas = await this._service.UpdateVanDeAsync(vanDe);

            if (!datas) { return BadRequest("Không lưu được dữ liệu"); }

            return Ok(datas);
        }

        [HttpPut("createlink")]
        public async Task<IActionResult> CreateLink([FromBody] VanDeID listID)
        {
            if (listID == null) { return BadRequest("Vui lòng nhập dữ liệu"); }

            var datas = await this._service.CreateLinkAsync(listID);
            return Ok(datas);
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> RemoveAsync([FromBody] VanDeDTO vanDe)
        {
            if (vanDe == null) { return BadRequest("Vui lòng nhập dữ liệu"); }

            var datas = await this._service.DeleteVanDeAsync(vanDe);

            if (!datas) { return BadRequest("Không lưu được dữ liệu"); }

            return Ok(datas);
        }
    }
}
