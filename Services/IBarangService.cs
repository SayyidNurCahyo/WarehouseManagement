using WarehouseManagement.Entities;

namespace WarehouseManagement.Services
{
    public interface IBarangService
    {
        Task<Barang> Create(Barang payload);
        Task<Barang> GetById(string id);
        Task<List<Barang>> GetAll();
        Task<Barang> Update(Barang payload);
        Task DeleteById(string id);
    }
}
