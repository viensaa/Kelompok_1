﻿using Kelompok_1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelompok_1.Data.Interface
{
    public interface ITransaksi : ICrud<Transaksi>
    {
        Task<Transaksi> AddExistingCartToTransaki(Transaksi obj);

    }
}
