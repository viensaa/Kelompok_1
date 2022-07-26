namespace Kelompok_1.DTO
{
    public class AddKateWithPr
    {
        public string Nama { get; set; }
        public List<ProdukCreateDTO> Produks { get; set; } = new List<ProdukCreateDTO>();
    }
}
