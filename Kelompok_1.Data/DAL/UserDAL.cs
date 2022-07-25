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
    public class UserDAL : IUser
    {
        private readonly DataContext _context;

        public UserDAL(DataContext context)
        {
            _context = context;
        }

        public async Task DeleteById(int id)
        {
            try
            {
                var DeleteUser = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
                if (DeleteUser == null)
                    throw new Exception($"Data dengan ID {id} tidak di temukan");

                _context.Users.Remove(DeleteUser);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var results = await _context.Users.OrderBy(u => u.Nama).ToListAsync();
            return results;
        }

        public async Task<User> GetById(int id)
        {
            var result = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (result == null) throw new Exception($"Data Dengan Id:{id} Tidak Ditemukan");

            
            return result;
        }

        public async Task<IEnumerable<User>> GetByName(string name)
        {
            var results = await _context.Users.Where(u => u.Nama.Contains(name)).ToListAsync();           
            if (results == null) throw new Exception($"Data Dengan Nama:{name} Tidak Ditemukan");

            return results;
        }

        public async Task<User> Insert(User obj)
        {
            try
            {
                _context.Users.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Update(User obj)
        {
            try
            {
                var FindData = await _context.Users.FirstOrDefaultAsync(u => u.Id == obj.Id);
                if (FindData == null)
                    throw new Exception("Data Tidak Ditemukan");

                FindData.Nama = obj.Nama;
                FindData.Alamat = obj.Alamat;
                FindData.Telepon = obj.Telepon;
                FindData.Email = obj.Email;
                FindData.password = obj.password;
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
