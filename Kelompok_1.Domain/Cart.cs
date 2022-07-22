using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Domain
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Produk> Produks { get; set; }
        public int ProdukId { get; set; }
        public int Jumlah { get; set; }
        public int UserId { get; set; }

        public Transaksi Transaksi { get; set; }
    }
}
