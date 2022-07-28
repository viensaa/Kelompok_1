using Kelompok_1.Data.Interface;
using Kelompok_1.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.DAL
{
    public class CartDAL : ICart
    {
        private readonly DataContext _context;

        public CartDAL(DataContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddExistingProdukToCart(Cart obj)
        {            
            try
            {
                _context.Carts.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }

        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> EditJumlah(Cart obj)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cart>> GetAll()
        {
            var results = await _context.Carts.Include(p=> p.Produk).ToListAsync();
            var groupby = results.GroupBy(p => p.UserId).ToList();
            return results;
        }

        public Task<Cart> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart>> GetByUser()
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Insert(Cart obj)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Update(Cart obj)
        {
            throw new NotImplementedException();
        }
    }
}
