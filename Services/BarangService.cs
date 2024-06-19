using WarehouseManagement.Entities;
using WarehouseManagement.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using WarehouseManagement.Dto.Response;
using WarehouseManagement.Dto.Request;
using WarehouseManagement.Mapper;

namespace WarehouseManagement.Services
{
    public class BarangService : IBarangService
    {
        private readonly IRepository<Barang> _repository;
        private readonly IPersistence _persistence;
        private readonly IGudangService _gudangService;
        public BarangService(IRepository<Barang> repository, IPersistence persistence, IGudangService gudangService)
        {
            _repository = repository;
            _persistence = persistence;
            _gudangService = gudangService;
        }

        public async Task<BarangResponse> Create(CreateBarangRequest payload)
        {
            var request = payload.ToBarangFromCreateRequest();
            await _gudangService.GetById(request.GudangKode.ToString());
            var barang = await _repository.SaveAsync(request);
            await _persistence.SaveChangesAsync();
            return barang.ToBarangResponse();
        }

        public async Task DeleteById(string id)
        {
            var barang = await _repository.FindByIdAsync(Guid.Parse(id));
            if (barang is null) throw new Exception("Barang tidak ditemukan");
            _repository.Delete(barang);
            await _persistence.SaveChangesAsync();
        }

        public async Task<List<BarangResponse>> GetAll()
        {
            var barang = await _repository.FindAllAsync();
            var response = barang.Select(g => g.ToBarangResponse()).ToList();
            return response;
        }

        public async Task<BarangResponse> GetById(string id)
        {
            try
            {
                var barang = await _repository.FindByIdAsync(Guid.Parse(id));
                if (barang is null) throw new Exception("Barang tidak ditemukan");
                return barang.ToBarangResponse();
            }
            catch (Exception ex)
            {
                throw new Exception("id harus berupa UUID");
            }
        }

        public async Task<BarangResponse> Update(UpdateBarangRequest payload)
        {
            var request = payload.ToBarangFromUpdateRequest();
            await _gudangService.GetById(request.GudangKode.ToString());
            var barang = _repository.Update(request);
            await _persistence.SaveChangesAsync();
            return barang.ToBarangResponse();
        }
    }
}
