using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Entities
{
    [Table(name:"gudang")]
    public class Gudang
    {
        [Key, Column(name:"kode")] public Guid Kode { get; set; }
        [Column(name:"nama")] public string Nama { get; set; }
        [Column(name:"alamat")] public string Alamat { get; set; }
    }
}
