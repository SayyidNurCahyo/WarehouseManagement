using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Entities
{
    [Table(name:"gudang")]
    public class Gudang
    {
        [Key, Column(name:"kode")] public Guid Kode { get; set; }
        [Required(ErrorMessage ="Nama gudang tidak tidak boleh kosong")]
        [MaxLength(100,ErrorMessage ="Nama gudang tidak boleh lebih dari 100 karakter")]
        [Column(name:"nama")] public string Nama { get; set; }
        [Required(ErrorMessage = "Alamat gudang tidak tidak boleh kosong")]
        [Column(name:"alamat")] public string Alamat { get; set; }
    }
}
