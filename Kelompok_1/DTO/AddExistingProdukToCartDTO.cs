using Kelompok_1.Domain;

namespace Kelompok_1.DTO
{
    public class AddExistingProdukToCartDTO
    {
        public int UserId { get; set; }
        //public int Produk { get; set; }
        public int ProdukId { get; set; }
        public int Jumlah { get; set; }
    }
}
