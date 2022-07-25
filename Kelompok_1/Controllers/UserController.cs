using AutoMapper;
using Kelompok_1.Data.Interface;
using Kelompok_1.Domain;
using Kelompok_1.DTO;
using Kelompok_1.Helpers;
using Kelompok_1.Models;
using Kelompok_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User = Kelompok_1.Domain.User;

namespace Kelompok_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _userDAL;
        private readonly IUserService _userService;

        public UserController(IUserService userService,IMapper mapper,IUser UserDAL)
        {
            _mapper = mapper;
            _userDAL = UserDAL;
            _userService = userService;
        }

        //menampilakn seluruh data
        [Authorize]
        [HttpGet("Menampilkan Seluruh Data User")]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            var results = await _userDAL.GetAll();
            var ReadData = _mapper.Map<IEnumerable<UserDTO>>(results);
            return ReadData;
        }

        //pencarian data berdasarkan Id
        //[Authorize]
        [HttpGet("Pencarian By Id")]
        public async Task<UserDTO> GetById(int id)
        {
            var result = await _userDAL.GetById(id);
            if (result == null) throw new Exception($"Data Dengan Id : {id} Tidak Ditemukan");

            var ReadData = _mapper.Map<UserDTO>(result);
            return ReadData;
        }

        //pencarian data berdasarkan Nama
        //[Authorize]
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

        //fitur untuk mengubah Data Pengguna
        [HttpPut("Mengubah Data Pengguna")]
        //[Authorize]
        public async Task<ActionResult>Put(UserDTO userDTO)
        {
            try
            {
                var updateUser = _mapper.Map<User>(userDTO);
                var result = await _userDAL.Update(updateUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("Menghapus User")]
        //[Authorize]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userDAL.DeleteById(id);
                return Ok("Data Berhasil di Hapus");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //menampilan seluruh transaksi user(belum seusai harapan)
        [HttpGet("Menampilkan Transaksi User")]
        //[Authorize]
        public async Task<IEnumerable<UserTransaksiDTO>> GetAllTraksaksiByUser()
        {
            var results = await _userDAL.GetTransaksiAll();
            var ReadData = _mapper.Map<IEnumerable<UserTransaksiDTO>>(results);
            return ReadData;
        }

        //LOGIN
        [HttpPost("Login")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Login(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

    }
}
