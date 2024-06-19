using WarehouseManagement.Dto.Request;
using WarehouseManagement.Dto.Response;
using WarehouseManagement.Entities;

namespace WarehouseManagement.Services
{
    public interface IGudangService
    {
        Task<GudangResponse> Create(CreateGudangRequest payload);
        Task<GudangResponse> GetById(string id);
        Task<List<GudangResponse>> GetAll();
        Task<GudangResponse> Update(UpdateGudangRequest payload);
        Task DeleteById(string id);
    }
}
