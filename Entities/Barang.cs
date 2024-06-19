using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Entities
{
    [Table(name:"barang")]
    public class Barang
    {
        [Key, Column(name:"kode")] public Guid Kode { get; set; }
        [Required(ErrorMessage ="Nama barang tidak boleh kosong")]
        [MaxLength(100,ErrorMessage ="Nama barang tidak boleh lebih dari 100 karakter")]
        [Column(name:"nama")] public string Nama { get; set; }
        [Required(ErrorMessage = "Harga barang tidak boleh kosong")]
        [Range(0,long.MaxValue, ErrorMessage ="Harga barang tidak boleh kurang dari 0")]
        [Column(name:"harga")] public long Harga { get; set; }
        [Required(ErrorMessage = "Stok barang tidak boleh kosong")]
        [Range(0, int.MaxValue, ErrorMessage = "Stok barang tidak boleh kurang dari 0")]
        [Column(name: "stok")] public long Stok { get; set; }
        [Required(ErrorMessage = "Tanggal kadaluarsa barang tidak boleh kosong")]
        [Column(name: "expired")] public long Expired { get; set; }
        [Required(ErrorMessage = "Kode gudang tidak boleh kosong")]
        [Column(name: "kode_gudang")] public Guid KodeGudang { get; set; }
    }
}
