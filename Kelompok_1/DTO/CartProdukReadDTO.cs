namespace Kelompok_1.DTO
{
    public class CartProdukReadDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ProdukCartDTO Produk { get; set; }
        public int Jumlah { get; set; }

    }
}
