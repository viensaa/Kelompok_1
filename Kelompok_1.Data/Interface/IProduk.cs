using Kelompok_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.Interface
{
    public interface IProduk : ICrud<Produk>
    {
        Task<IEnumerable<Produk>> GetByName(string name);
        Task<IEnumerable<Produk>> GetByHarga(int harga);
        Task<IEnumerable<Produk>> GetByKategori(string kategori);
        Task<IEnumerable<Produk>> GetAll(int page);
    }
}
