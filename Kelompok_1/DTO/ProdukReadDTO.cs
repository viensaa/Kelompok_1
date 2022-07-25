using Kelompok_1.Domain;

namespace Kelompok_1.DTO
{
    public class ProdukReadDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
        public int Stock { get; set; }
        //public Kategori KategoriId{ get; set; }
    }
}
