using WarehouseManagement.Dto.Request;
using WarehouseManagement.Dto.Response;
using WarehouseManagement.Entities;

namespace WarehouseManagement.Mapper
{
    public static class GudangMapper
    {
        public static GudangResponse ToGudangResponse(this Gudang gudang)
        {
            return new GudangResponse
            {
                KodeGudang = gudang.Kode.ToString(),
                NamaGudang = gudang.Nama,
                AlamatGudang = gudang.Alamat
            };
        }

        public static Gudang ToGudangFromCreateRequest(this CreateGudangRequest request)
        {
            return new Gudang
            {
                Kode = Guid.NewGuid(),
                Nama = request.NamaGudang,
                Alamat = request.AlamatGudang
            };
        }

        public static Gudang ToGudangFromUpdateRequest(this UpdateGudangRequest request)
        {
            return new Gudang
            {
                Kode = request.KodeGudang,
                Nama = request.NamaGudang,
                Alamat = request.AlamatGudang
            };
        }
    }
}
