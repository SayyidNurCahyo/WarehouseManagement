using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Dto.Request
{
    public class CreateBarangRequest
    {
        [Required(ErrorMessage = "Nama barang tidak boleh kosong")]
        [MaxLength(100, ErrorMessage = "Nama barang tidak boleh lebih dari 100 karakter")]
        public string NamaBarang { get; set; }
        [Required(ErrorMessage = "Harga barang tidak boleh kosong")]
        [Range(0, long.MaxValue, ErrorMessage = "Harga barang tidak boleh kurang dari 0")]
        public long HargaBarang { get; set; }
        [Required(ErrorMessage = "Stok barang tidak boleh kosong")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok barang tidak boleh kurang dari 0")]
        public int StokBarang { get; set; }
        [Required(ErrorMessage = "Tanggal kadaluarsa barang tidak boleh kosong")]
        public DateTime Expired { get; set; }
        [Required(ErrorMessage = "Kode gudang tidak boleh kosong")]
        public Guid KodeGudang { get; set; }
    }
}
