using WarehouseManagement.Entities;
using WarehouseManagement.Repositories;
using WarehouseManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Dto.Request;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/gudang")]
    public class GudangController : ControllerBase
    {
        private readonly IGudangService _gudangService;
        public GudangController(IGudangService gudangService)
        {
            _gudangService = gudangService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewGudang([FromBody] CreateGudangRequest payload)
        {
            var gudang = await _gudangService.Create(payload);
            return Created("/api/gudang", gudang);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGudang([FromBody] UpdateGudangRequest payload)
        {
            var gudang = await _gudangService.Update(payload);
            return Ok(gudang);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGudang(string id)
        {
            await _gudangService.DeleteById(id);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGudangById(string id)
        {
            var gudang = await _gudangService.GetById(id);
            return Ok(gudang);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGudang()
        {
            var gudang = await _gudangService.GetAll();
            return Ok(gudang);
        }
    }
}
