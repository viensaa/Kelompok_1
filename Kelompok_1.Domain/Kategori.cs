using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Domain
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public List<Produk> Produks { get; set; }
    }
}
