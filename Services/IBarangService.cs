using WarehouseManagement.Dto.Request;
using WarehouseManagement.Dto.Response;
using WarehouseManagement.Entities;

namespace WarehouseManagement.Services
{
    public interface IBarangService
    {
        Task<BarangResponse> Create(CreateBarangRequest payload);
        Task<BarangResponse> GetById(string id);
        Task<List<BarangResponse>> GetAll();
        Task<BarangResponse> Update(UpdateBarangRequest payload);
        Task DeleteById(string id);
    }
}
