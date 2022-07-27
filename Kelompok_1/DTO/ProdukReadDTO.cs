namespace Kelompok_1.DTO
{
    public class ProdukReadDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
        public int Stock { get; set; }
        public KategoriReadDTO Kategori { get; set; }
        //public int Pages { get; set; }
        //public int CurrentPage { get; set; }
    }
}
