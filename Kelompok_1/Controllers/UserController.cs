using AutoMapper;
using Kelompok_1.Data.Interface;
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
            if (result == null) throw new Exception($"Data Dengan Id = {id} Tidak Ditemukan");

            var ReadData = _mapper.Map<UserDTO>(result);
            return ReadData;
        }

    }
}
