using Kelompok_1.Domain;

namespace Kelompok_1.DTO
{
    public class TransaksiDetailDTO
    {
        public int Id { get; set; }
        //public int CartId { get; set; }
        public CartProdukReadDTO Cart { get; set; }
        public DateTime Tanggal { get; set; }
        //public int JumlahTransaksi { get; set; }
    }
}
