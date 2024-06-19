using WarehouseManagement.Dto.Request;
using WarehouseManagement.Dto.Response;
using WarehouseManagement.Entities;

namespace WarehouseManagement.Mapper
{
    public static class BarangMapper
    {
        public static BarangResponse ToBarangResponse(this Barang barang)
        {
            return new BarangResponse
            {
                KodeBarang = barang.Kode.ToString(),
                NamaBarang = barang.Nama,
                HargaBarang = barang.Harga,
                StokBarang = barang.Stok,
                Expired = barang.Expired,
                NamaGudang = barang.Gudang.Nama
            };
        }

        public static Barang ToBarangFromCreateRequest(this CreateBarangRequest request)
        {
            return new Barang
            {
                Kode = Guid.NewGuid(),
                Nama = request.NamaBarang,
                Harga = request.HargaBarang,
                Stok = request.StokBarang,
                Expired = request.Expired,
                GudangKode = request.KodeGudang
            };
        }

        public static Barang ToBarangFromUpdateRequest(this UpdateBarangRequest request)
        {
            return new Barang
            {
                Kode = request.KodeBarang,
                Nama = request.NamaBarang,
                Harga = request.HargaBarang,
                Stok = request.StokBarang,
                Expired = request.Expired,
                GudangKode = request.KodeGudang
            };
        }
    }
}
