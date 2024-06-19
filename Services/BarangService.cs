using WarehouseManagement.Entities;
using WarehouseManagement.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WarehouseManagement.Services
{
    public class BarangService : IBarangService
    {
        private readonly IRepository<Barang> _repository;
        private readonly IPersistence _persistence;
        public BarangService(IRepository<Barang> repository, IPersistence persistence)
        {
            _repository = repository;
            _persistence = persistence;
        }

        public async Task<Barang> Create(Barang payload)
        {
            var barang = await _repository.SaveAsync(payload);
            await _persistence.SaveChangesAsync();
            return barang;
        }

        public async Task DeleteById(string id)
        {
            var barang = await GetById(id);
            _repository.Delete(barang);
            await _persistence.SaveChangesAsync();
        }

        public async Task<List<Barang>> GetAll()
        {
            return await _repository.FindAllAsync();
        }

        public async Task<Barang> GetById(string id)
        {
            try
            {
                var barang = await _repository.FindByIdAsync(Guid.Parse(id));
                if (barang is null) throw new Exception("Barang tidak ditemukan");
                return barang;
            }catch (Exception ex)
            {
                throw new Exception("id harus berupa UUID");
            }
        }

        public async Task<Barang> Update(Barang payload)
        {
            var barang = _repository.Update(payload);
            await _persistence.SaveChangesAsync();
            return barang;
        }
    }
}
