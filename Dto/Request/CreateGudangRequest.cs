using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Dto.Request
{
    public class CreateGudangRequest
    {
        [Required(ErrorMessage = "Nama gudang tidak tidak boleh kosong")]
        [MaxLength(100, ErrorMessage = "Nama gudang tidak boleh lebih dari 100 karakter")]
        public string NamaGudang { get; set; }
        [Required(ErrorMessage = "Alamat gudang tidak tidak boleh kosong")]
        public string AlamatGudang { get; set;}
    }
}
