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

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var results = await _context.Users.OrderBy(u => u.Nama).ToListAsync();
            return results;
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produk>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> Insert(User obj)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
