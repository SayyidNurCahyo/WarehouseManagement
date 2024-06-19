using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseManagement.Entities
{
    [Table(name:"barang")]
    public class Barang
    {
        [Key, Column(name:"kode")] public Guid Kode { get; set; }
        [Column(name:"nama")] public string Nama { get; set; }
        [Column(name:"harga")] public long Harga { get; set; }
        [Column(name: "stok")] public int Stok { get; set; }
        [Column(name: "expired")] public DateTime Expired { get; set; }
        [Column(name: "kode_gudang")] public Guid GudangKode { get; set; }
        public virtual Gudang? Gudang { get; set; }
    }
}
