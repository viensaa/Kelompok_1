using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Domain
{
    public class Transaksi
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public DateTime Tanggal { get; set; }






    }
}
