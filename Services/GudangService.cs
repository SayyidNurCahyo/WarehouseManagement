using WarehouseManagement.Entities;
using WarehouseManagement.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<Gudang> Create(Gudang payload)
        {
            var gudang = await _repository.SaveAsync(payload);
            await _persistence.SaveChangesAsync();
            return gudang;
        }

        public async Task DeleteById(string id)
        {
            var gudang = await GetById(id);
            _repository.Delete(gudang);
            await _persistence.SaveChangesAsync();
        }

        public async Task<List<Gudang>> GetAll()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Gudang> GetById(string id)
        {
            try
            {
                var gudang = await _repository.FindByIdAsync(Guid.Parse(id));
                if (gudang is null) throw new Exception("Gudang tidak ditemukan");
                return gudang;
            }catch (Exception ex)
            {
                throw new Exception("id harus berupa UUID");
            }
        }

        public async Task<Gudang> Update(Gudang payload)
        {
            var gudang = _repository.Update(payload);
            await _persistence.SaveChangesAsync();
            return gudang;
        }
    }
}
