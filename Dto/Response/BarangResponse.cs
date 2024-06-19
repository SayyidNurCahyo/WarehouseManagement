using System.ComponentModel.DataAnnotations;

namespace WarehouseManagement.Dto.Response
{
    public class BarangResponse
    {
        public string KodeBarang { get; set; }
        public string NamaBarang { get; set; }
        public long HargaBarang { get; set; }
        public int StokBarang { get; set; }
        public DateTime Expired { get; set; }
        public string NamaGudang { get; set; }
    }
}
