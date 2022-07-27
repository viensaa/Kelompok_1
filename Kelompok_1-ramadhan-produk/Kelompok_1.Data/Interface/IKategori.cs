using Kelompok_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.Interface
{
    public interface IKategori : ICrud<Kategori>
    {
        Task<IEnumerable<Kategori>> GetByName(string name);
    }
}
