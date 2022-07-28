using AutoMapper;
using Kelompok_1.Data.Interface;
using Kelompok_1.Domain;
using Kelompok_1.DTO;
using Kelompok_1.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kelompok_1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdukController : ControllerBase
    {
        private readonly IProduk _produkDAL;
        private readonly IMapper _mapper;
        private readonly IKategori _kategoriDAL;

        public ProdukController(IProduk produkDAL,IMapper mapper, IKategori kategoriDAL)
        {
            _produkDAL = produkDAL;
            _mapper = mapper;
            _kategoriDAL = kategoriDAL;

        }

        [HttpGet]

        public async Task<IEnumerable<ProdukReadDTO>> GetAll(int page)
        {
            var results = await _produkDAL.GetAll(page);
            var produkDTO = _mapper.Map<IEnumerable<ProdukReadDTO>>(results);



            return produkDTO;
        }

        [HttpGet("{id}")]
        public async Task<ProdukReadDTO> Get(int id)
        {
    
            var result = await _produkDAL.GetById(id);
            if (result == null) throw new Exception($"data {id} tidak ditemukan");
            var produkDTO = _mapper.Map<ProdukReadDTO>(result);

            return produkDTO;
        }

        [HttpGet("ByName")]
        public async Task<IEnumerable<ProdukReadDTO>> GetByName(string name)
        {
            var results = await _produkDAL.GetByName(name);
            if (results == null) throw new Exception($"data {name} tidak ditemukan");
            var produkDtos = _mapper.Map<IEnumerable<ProdukReadDTO>>(results);
   
            return produkDtos;
        }

        [HttpGet("ByKategori")]
        public async Task<IEnumerable<GetProdukByKategoriDTO>> GetByKategori(string kategori)
        {
            var results = await _produkDAL.GetByKategori(kategori);
            if (results == null) throw new Exception($"data kategori {kategori} tidak ditemukan");
            var produkDTO = _mapper.Map<IEnumerable<GetProdukByKategoriDTO>>(results);

            return produkDTO;
        }

        [HttpGet("ByHarga")]
        public async Task<IEnumerable<ProdukReadDTO>> GetByHarga(int harga)
        {
            List<ProdukReadDTO> produkDtos = new List<ProdukReadDTO>();
            var results = await _produkDAL.GetByHarga(harga);
            foreach (var result in results)
            {
                produkDtos.Add(new ProdukReadDTO
                {
                    Id = result.Id,
                    Nama = result.Nama
                });
            }
            return produkDtos;
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProdukCreateDTO produkCreateDto)
        {
            try
            {
                var newProduk = _mapper.Map<Produk>(produkCreateDto);
                var result = await _produkDAL.Insert(newProduk);
                var produkReadDto = _mapper.Map<ProdukCreateDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, produkReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _produkDAL.DeleteById(id);
                return Ok($"Data Kategori dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(ProdukReadDTO produkReadDTO)
        {
            try
            {
                var updateProduk = new Produk
                {
                    Id = produkReadDTO.Id,
                    Nama = produkReadDTO.Nama,
                    Harga = produkReadDTO.Harga,
                    Stock = produkReadDTO.Stock
                };
                var result = await _produkDAL.Update(updateProduk);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
