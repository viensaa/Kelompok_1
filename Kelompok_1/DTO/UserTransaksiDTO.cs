using Kelompok_1.Domain;

namespace Kelompok_1.DTO
{
    public class UserTransaksiDTO
    {
        public string Nama { get; set; }


        //public DateTime Tanggal { get; set; }
        public List<TransaksiDetailDTO> Transaksis { get; set; }

    }
}
