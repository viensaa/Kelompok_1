using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        //public Cart Cart { get; set; }
        public List<Transaksi> Transaksis { get; set; } = new List<Transaksi>();
       
    }
}
