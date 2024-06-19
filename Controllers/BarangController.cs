using WarehouseManagement.Entities;
using WarehouseManagement.Repositories;
using WarehouseManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WarehouseManagement.Controllers
{
    [ApiController]
    [Route("api/barang")]
    public class BarangController : ControllerBase
    {
        private readonly IBarangService _barangService;
        public BarangController(IBarangService barangService)
        {
            _barangService = barangService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewBarang([FromBody] Barang payload)
        {
            var barang = await _barangService.Create(payload);
            return Created("/api/barang", barang);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBarang([FromBody] Barang payload)
        {
            var barang = await _barangService.Update(payload);
            return Ok(barang);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarang(string id)
        {
            await _barangService.DeleteById(id);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBarang()
        {
            var barang = await _barangService.GetAll();
            return Ok(barang);
        }
    }
}
