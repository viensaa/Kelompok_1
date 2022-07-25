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
    public class KategoriDAL : IKategori
    {
        private readonly DataContext _context;

        public KategoriDAL(DataContext context)
        {
            _context = context;
        }
        public async Task DeleteById(int id)
        {
            try
            {
                var element = await _context.Kategoris.FirstOrDefaultAsync(e => e.Id == id);
                if (element == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Kategoris.Remove(element);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Kategori>> GetAll()
        {
            var kate = await _context.Kategoris.OrderBy(k=>k.Nama).ToListAsync();
            return kate;

        }

        public async Task<Kategori> GetById(int id)
        {
            var kate = await _context.Kategoris.FirstOrDefaultAsync(k => k.Id ==id);
            if (kate == null)
                throw new Exception($"Data Kategori dengan id {id} tidak ditemukan");
            return kate;
        }

        public async Task<IEnumerable<Kategori>> GetByName(string name)
        {
            var kate = await _context.Kategoris.Where(e => e.Nama.Contains(name))
                .OrderBy(s => s.Nama).ToListAsync();
            return kate;
        }

        public async Task<Kategori> Insert(Kategori obj)
        {
            _context.Kategoris.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Kategori> Update(Kategori obj)
        {
            var kate = await _context.Kategoris.FirstOrDefaultAsync(e => e.Id == obj.Id);
            if (kate == null)
                throw new Exception($"Data Kategori dengan id {obj.Id} tidak bisa ditemukan");
            kate.Nama = obj.Nama;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
