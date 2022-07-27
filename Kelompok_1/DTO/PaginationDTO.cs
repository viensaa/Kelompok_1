using Kelompok_1.Domain;

namespace Kelompok_1.DTO
{
    public class PaginationDTO
    {
        List<ProdukReadDTO> Produks { get; set; } = new List<ProdukReadDTO>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
