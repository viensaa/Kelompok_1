namespace Kelompok_1.DTO
{
    public class GetProdukByKategoriDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
        public int Stock { get; set; }
        public ReadProdukByKategori Kategori { get; set; }
    }
}
