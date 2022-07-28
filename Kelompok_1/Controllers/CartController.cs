﻿using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ICart _cartDAL;

        public CartController(IMapper mapper,ICart CartDAL)
        {
            _mapper = mapper;
            _cartDAL = CartDAL;
        }

        //menambahkan existing produk ke cart
        [HttpPost("Menambahkan produk kedalam keranjang")]
        public async Task<ActionResult>AddExistingProdukTocart(AddExistingProdukToCartDTO existingProdukCartDTO)
        {
            var InserData = _mapper.Map<Cart>(existingProdukCartDTO);
            var result = await _cartDAL.AddExistingProdukToCart(InserData);
            return Ok("Berhasil menambah Barang ke Cart");
        }

        [HttpGet("Melihat Seluruh Cart")]
        public async Task<IEnumerable<CartProdukReadDTO>> GetAllData()
        {
            var result = await _cartDAL.GetAll();
            var dataRead = _mapper.Map<IEnumerable<CartProdukReadDTO>>(result);
            return dataRead;
        }


    }
}
