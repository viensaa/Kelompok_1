namespace Kelompok_1.DTO
{
    public class TransaksiReadDTO
    {
        public string Id { get; set; }
        public UserCartDTO User { get; set; }
        //public ProdukCartDTO Cart { get; set; }
        public CartProdukReadDTO Cart { get; set; }
        public DateTime Tanggal { get; set; }
    }
}
