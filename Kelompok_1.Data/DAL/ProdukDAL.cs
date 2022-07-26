using Kelompok_1.Data.Interface;
using Kelompok_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.DAL
{
    public class ProdukDAL : IProduk
    {
        private readonly DataContext _context;

        public ProdukDAL(DataContext context)
        {
            _context = context;
        }
        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produk>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Produk> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produk>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Produk> Insert(Produk obj)
        {
            throw new NotImplementedException();
        }

        public Task<Produk> Update(Produk obj)
        {
            throw new NotImplementedException();
        }
    }
}
