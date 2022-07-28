using AutoMapper;
using Kelompok_1.Data.Interface;
using Kelompok_1.Domain;
using Kelompok_1.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kelompok_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITransaksi _transaksiDAL;

        public TransaksiController(IMapper mapper,ITransaksi transaksiDAL)
        {
            _mapper = mapper;
            _transaksiDAL = transaksiDAL;
        }
        [HttpGet("TampilanByNota")]
        public async Task<TransaksiReadDTO> Get(int id)
        {

            var result = await _transaksiDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var produkDTO = _mapper.Map<TransaksiReadDTO>(result);

            return produkDTO;
        }

        //menambahkan cart ke transaksi
        [HttpGet("MenambahTransaksi")]
        public async Task<ActionResult> AddExistingCartToTransaksi(AddExistingCartToTransaksiDTO existingCartToTransaksi)
        {
            var InserData = _mapper.Map<Transaksi>(existingCartToTransaksi);
            var result = await _transaksiDAL.AddExistingCartToTransaki(InserData);
            return Ok("Berhasil menambah Barang ke Transaksi");
        }
    }
}
