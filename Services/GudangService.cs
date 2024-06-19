using WarehouseManagement.Entities;
using WarehouseManagement.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using WarehouseManagement.Dto.Response;
using WarehouseManagement.Dto.Request;
using WarehouseManagement.Mapper;

namespace WarehouseManagement.Services
{
    public class GudangService : IGudangService
    {
        private readonly IRepository<Gudang> _repository;
        private readonly IPersistence _persistence;
        public GudangService(IRepository<Gudang> repository, IPersistence persistence)
        {
            _repository = repository;
            _persistence = persistence;
        }

        public async Task<GudangResponse> Create(CreateGudangRequest payload)
        {
            var request = payload.ToGudangFromCreateRequest();
            var gudang = await _repository.SaveAsync(request);
            await _persistence.SaveChangesAsync();
            return gudang.ToGudangResponse();
        }

        public async Task DeleteById(string id)
        {
            var gudang = await _repository.FindByIdAsync(Guid.Parse(id));
            if (gudang is null) throw new Exception("Gudang tidak ditemukan");
            _repository.Delete(gudang);
            await _persistence.SaveChangesAsync();
        }

        public async Task<List<GudangResponse>> GetAll()
        {
            var gudang = await _repository.FindAllAsync();
            var response = gudang.Select(g => g.ToGudangResponse()).ToList();
            return response;
        }

        public async Task<GudangResponse> GetById(string id)
        {
            try
            {
                var gudang = await _repository.FindByIdAsync(Guid.Parse(id));
                if (gudang is null) throw new Exception("Gudang tidak ditemukan");
                return gudang.ToGudangResponse();
            }
            catch (Exception ex)
            {
                throw new Exception("id harus berupa UUID");
            }
        }

        public async Task<GudangResponse> Update(UpdateGudangRequest payload)
        {
            var request = payload.ToGudangFromUpdateRequest();
            var gudang = _repository.Update(request);
            await _persistence.SaveChangesAsync();
            return gudang.ToGudangResponse();
        }
    }
}
