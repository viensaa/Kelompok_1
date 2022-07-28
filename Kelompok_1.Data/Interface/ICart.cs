using Kelompok_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.Interface
{
    public interface ICart : ICrud<Cart>
    {
        Task<Cart> AddExistingProdukToCart(Cart obj);
        Task<Cart> EditJumlah(Cart obj);
        Task<IEnumerable<Cart>> GetByUser();
    }
}
