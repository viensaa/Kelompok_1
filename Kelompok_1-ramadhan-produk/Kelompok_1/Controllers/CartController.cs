using System;
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
    public class CartController : ControllerBase
    {
        private readonly ICart _cartDAL;
        private readonly IMapper _mapper;

        public CartController(ICart cartDAL, IMapper mapper)
        {
            _cartDAL = ICart;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CartReadDTO>> Get()
        {
            var result = await _cartDAL.GetAll();
            var kate = _mapper.Map<IEnumerable<KategoriReadDTO>>(result);
            return kate;
        }

        [HttpGet("{id}")]
        public async Task<KategoriReadDTO> Get(int id)
        {
            var result = await _cartDAL.GetById(id);
            if (result == null)
                throw new Exception($"Data dengan id {id} tidak ditemukan");
            var kate = _mapper.Map<CartReadDTO>(result);
            return kate;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CartCreateDTO cartCreateDTO)
        {
            try
            {
                var kateMap = _mapper.Map<Cart>(cartCreateDTO);
                var result = await _cartDAL.Insert(kateMap);
                var kateRead = _mapper.Map<cartReadDTO>(result);

                return CreatedAtAction("Get", new { id = result.Id }, kateRead);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(CartReadDTO cartReadDTO)
        {
            try
            {
                var upKate = new Cart
                {
                    Id = cartReadDTO.Id,
                    Nama = cartReadDTO.Nama
                };
                var result = await _cartDAL.Update(upKate);
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
                await _cartDAL.DeleteById(id);
                return Ok($"Data Cart dengan id {id} berhasil didelete");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetByName")]
        public async Task<IEnumerable<CartReadDTO>> GetByName(string nama)
        {
            List<CartReadDTO> cartReadDTOs = new List<CartReadDTO>();
            var result = await _cartDAL.GetByName(nama);
            foreach (var re in result)
            {
                cartReadDTOs.Add(new CartReadDTO
                {
                    Id = re.Id,
                    Nama = re.Nama
                });
            }
            return cartReadDTOs;
        }
    }
}
