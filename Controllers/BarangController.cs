using WarehouseManagement.Repositories;
using WarehouseManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WarehouseManagement.Dto.Request;

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
        public async Task<IActionResult> CreateNewBarang([FromBody] CreateBarangRequest payload)
        {
            var barang = await _barangService.Create(payload);
            return Created("/api/barang", barang);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBarang([FromBody] UpdateBarangRequest payload)
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
        [HttpGet("{id}")]

        public async Task<IActionResult> GetBarangById(string id)
        {
            var barang = await _barangService.GetById(id);
            return Ok(barang);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBarang()
        {
            var barang = await _barangService.GetAll();
            return Ok(barang);
        }
    }
}
