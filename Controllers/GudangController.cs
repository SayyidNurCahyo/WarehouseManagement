using WarehouseManagement.Entities;
using WarehouseManagement.Repositories;
using WarehouseManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateNewGudang([FromBody] Gudang payload)
        {
            var gudang = await _gudangService.Create(payload);
            return Created("/api/gudang", gudang);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateGudang([FromBody] Gudang payload)
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
        [HttpGet]
        public async Task<IActionResult> GetAllGudang()
        {
            var gudang = await _gudangService.GetAll();
            return Ok(gudang);
        }
    }
}
