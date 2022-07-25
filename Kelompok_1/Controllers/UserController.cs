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
        [HttpGet("MenampilkanSeluruhData")]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            var results = await _userDAL.GetAll();
            var ReadData = _mapper.Map<IEnumerable<UserDTO>>(results);
            return ReadData;
        }

    }
}
