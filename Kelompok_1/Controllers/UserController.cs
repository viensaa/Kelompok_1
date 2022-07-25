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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _userDAL;

        public UserController(IMapper mapper,IUser UserDAL)
        {
            _mapper = mapper;
            _userDAL = UserDAL;
        }

        //menampilakn seluruh data
        [HttpGet("Menampilkan Seluruh Data User")]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            var results = await _userDAL.GetAll();
            var ReadData = _mapper.Map<IEnumerable<UserDTO>>(results);
            return ReadData;
        }

        //pencarian data berdasarkan Id
        [HttpGet("Pencarian By Id")]
        public async Task<UserDTO> GetById(int id)
        {
            var result = await _userDAL.GetById(id);
            if (result == null) throw new Exception($"Data Dengan Id : {id} Tidak Ditemukan");

            var ReadData = _mapper.Map<UserDTO>(result);
            return ReadData;
        }

        //pencarian data berdasarkan Nama
        [HttpGet("Pencarian By Name")]
        public async Task<IEnumerable<UserDTO>> GetByName(string name)
        {
            var results = await _userDAL.GetByName(name);
            if (results == null) throw new Exception($"Data Dengan Nama: {name} Tidak Ditemukan");

            var ReadData = _mapper.Map<IEnumerable<UserDTO>>(results);
            return ReadData;
        }

        //Fitur Untuk Menambahkan User
        [HttpPost("Register")]
        public async Task<ActionResult>Post(UserCreateDTO userCreateDTO)
        {
            try
            {
                var NewUser = _mapper.Map<User>(userCreateDTO);
                var result = await _userDAL.Insert(NewUser);
                var ReadData = _mapper.Map<UserDTO>(result);
                return CreatedAtAction("Get", new { Id = result.Id }, ReadData);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

    }
}
