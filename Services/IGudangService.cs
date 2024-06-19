using WarehouseManagement.Entities;

namespace WarehouseManagement.Services
{
    public interface IGudangService
    {
        Task<Gudang> Create(Gudang payload);
        Task<Gudang> GetById(string id);
        Task<List<Gudang>> GetAll();
        Task<Gudang> Update(Gudang payload);
        Task DeleteById(string id);
    }
}
