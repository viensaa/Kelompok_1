using Kelompok_1.Domain;

namespace Kelompok_1.DTO
{
    public class KategoriCreateToExistProdukDTO
    {
        public int Id { get; set; }
        public List<ProdukCreateDTO> Produks { get; set; } = new List<ProdukCreateDTO>();

    }
}
