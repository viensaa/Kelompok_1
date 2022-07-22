using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Domain
{
    public class Produk
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
        public int Stock { get; set; }
        public Kategori Kategori { get; set; }
        public int KategoriId{ get; set; }
        List<Cart> Carts { get; set; }

    }
}
