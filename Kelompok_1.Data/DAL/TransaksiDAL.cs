using Kelompok_1.Data.Interface;
using Kelompok_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.DAL
{
    public class TransaksiDAL : ITransaksi
    {
        public Task<Transaksi> AddExistingCartToTransaki(Transaksi obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaksi>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Transaksi> GetById(int id)
        {
            throw new NotImplementedException();
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
