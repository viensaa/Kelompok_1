using Kelompok_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.Interface
{
    public interface IUser : ICrud<User>
    {
        Task<IEnumerable<Produk>> GetByName(string name);
    }
}
