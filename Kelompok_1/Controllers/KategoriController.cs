using AutoMapper;
using Kelompok_1.Data.DAL;
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
    public class KategoriController : ControllerBase
    {
        private readonly IKategori _kategoriDAL;
        private readonly IMapper _mapper;

        public KategoriController(IKategori kategoriDAL, IMapper mapper)
        {
            _kategoriDAL = kategoriDAL;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<KategoriReadDTO>> Get()
        {
            var result = await _kategoriDAL.GetAll();
            var kate = _mapper.Map<IEnumerable<KategoriReadDTO>>(result);
            return kate;
        }

        [HttpGet("{id}")]
        public async Task<KategoriReadDTO> Get(int id)
        {
            var result = await _kategoriDAL.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            var kate = _mapper.Map<KategoriReadDTO>(result);
            return kate;
        }

        [HttpPost]
        public async Task<ActionResult> Post(KategoriCreateDTO kategoriCreateDTO)
        {
            try
            {
                var kateMap = _mapper.Map<Kategori>(kategoriCreateDTO);
                var result = await _kategoriDAL.Insert(kateMap);
                var kateRead = _mapper.Map<KategoriReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, kateRead);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(KategoriReadDTO kategoriReadDTO)
        {
            try
            {
                var upKate = new Kategori
                {
                    Id = kategoriReadDTO.Id,
                    Nama = kategoriReadDTO.Nama
                };
                var result = await _kategoriDAL.Update(upKate);
                return Ok(result);
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
                await _kategoriDAL.DeleteById(id);
                return Ok($"Data Kategori dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetByName")]
        public async Task<IEnumerable<KategoriReadDTO>> GetByName(string nama)
        {
            List<KategoriReadDTO> kategoriReadDTOs = new List<KategoriReadDTO>();
            var result = await _kategoriDAL.GetByName(nama);
            foreach (var re in result)
            {
                kategoriReadDTOs.Add(new KategoriReadDTO
                {
                    Id = re.Id,
                    Nama = re.Nama
                });
            }
            return kategoriReadDTOs;
        }

        [HttpPost("KategoriWithProduk")]
        public async Task<ActionResult> AddKategoriWithProduk(AddKateWithPr addKateWithPr)
        {
            try
            {
                var newSword = _mapper.Map<Kategori>(addKateWithPr);
                var result = await _kategoriDAL.AddKategoriWithProduk(newSword);
                var readDto = _mapper.Map<KatePrRead>(result);

                return CreatedAtAction("Get", new { id = result.Id }, readDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpGet("KategoriProduk")]

        public async Task<IEnumerable<KatePrRead>> GetKategoriProduk(int page)
        {
            var result = await _kategoriDAL.GetKategoriProduk();
            var kateDTO = _mapper.Map<IEnumerable<KatePrRead>>(result);
            var pagination = kateDTO.Skip((page - 1) * 10).Take(10).ToList();
            return pagination;
        }
        /*[HttpPost("Add Produk To Existing Kate")]
        public async Task<ActionResult> AddKategoriExistingProduk(KategoriCreateToExistProdukDTO kategoriCreateToExistProdukDTO)
        {
            try
            {

                var newKate = _mapper.Map<Kategori>(kategoriCreateToExistProdukDTO);
                var result = await _kategoriDAL.AddKategoriExistingProduk(newKate);
                var readDTO = _mapper.Map<ProdukReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, readDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
    }
}
