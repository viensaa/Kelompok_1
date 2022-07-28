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
    public class TransaksiDAL : ITransaksi
    {
        private readonly DataContext _context;

        public TransaksiDAL(DataContext context)
        {
            _context = context;
        }
        public async Task<Transaksi> AddExistingCartToTransaki(Transaksi obj)
        {
            try
            {
                _context.Transaksis.Add(obj);
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

        public Task<IEnumerable<Transaksi>> GetAll()
        {
            throw new NotImplementedException();
        }


        //menampilakn by Nota
        public async Task<Transaksi> GetById(int id)
        {
            var result = await _context.Transaksis.Include(u=> u.User).Include(c=> c.Cart)
                .ThenInclude(p=> p.Produk)
                .SingleOrDefaultAsync(u => u.Id == id);
            if (result == null) throw new Exception($"Data Dengan Id:{id} Tidak Ditemukan");


            return result;
        }

        public Task<Transaksi> Insert(Transaksi obj)
        {
            throw new NotImplementedException();
        }

        public Task<Transaksi> Update(Transaksi obj)
        {
            throw new NotImplementedException();
        }

    }
}
