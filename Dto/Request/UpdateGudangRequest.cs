using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Dto.Request
{
    public class UpdateGudangRequest
    {
        [Required(ErrorMessage = "Kode gudang tidak boleh kosong")]
        public Guid KodeGudang { get; set; }
        [Required(ErrorMessage = "Nama gudang tidak tidak boleh kosong")]
        [MaxLength(100, ErrorMessage = "Nama gudang tidak boleh lebih dari 100 karakter")]
        public string NamaGudang { get; set; }
        [Required(ErrorMessage = "Alamat gudang tidak tidak boleh kosong")]
        public string AlamatGudang { get; set; }
    }
}
