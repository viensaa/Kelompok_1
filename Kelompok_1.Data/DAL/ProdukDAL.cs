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
    public class ProdukDAL : IProduk
    {
        private readonly DataContext _context;

        public ProdukDAL(DataContext context)
        {
            _context = context;
        }   
        public async Task DeleteById(int id)
        {
            try
            {
                var deleteProduk = await _context.Produks.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteProduk == null)
                    throw new Exception($"Data samurai dengan id {id} tidak ditemukan");
                _context.Produks.Remove(deleteProduk);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Produk>> GetAll(int page)
        {
            var pageResults = 3f;
            var pageCount = Math.Ceiling(_context.Produks.Count() / pageResults);

            var results = await _context.Produks.Include(k => k.Kategori).OrderBy(s => s.Id)
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            return results; ;
   
        }

        public Task<IEnumerable<Produk>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produk>> GetByHarga(int harga)
        {
            var produks = await _context.Produks.Include(k => k.Kategori).Where(s => s.Harga == harga)
                .OrderBy(s => s.Nama).ToListAsync();
            return produks;
        }

        public async Task<Produk> GetById(int id)
        {
            var result = await _context.Produks.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data Produk dengan id {id} tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Produk>> GetByKategori(string kategori)
        {
            var produks = await _context.Produks.Include(k => k.Kategori).Where(s => s.Kategori.Nama.Contains(kategori))
                .OrderBy(s => s.Nama).ToListAsync();
            return produks;
        }

        public async Task<IEnumerable<Produk>> GetByName(string name)
        {
            var produks = await _context.Produks.Include(k => k.Kategori).Where(s => s.Nama.Contains(name))
                .OrderBy(s => s.Nama).ToListAsync();
            return produks;
        }

        public async Task<Produk> Insert(Produk obj)
        {
            try
            {
                _context.Produks.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Produk> Update(Produk obj)
        {
            try
            {
                var updateProduk = await _context.Produks.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateProduk == null)
                    throw new Exception($"Data produk dengan id {obj.Id} tidak ditemukan");

                updateProduk.Nama= obj.Nama;
                updateProduk.Harga = obj.Harga;
                updateProduk.Stock = obj.Stock;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


    }
}
