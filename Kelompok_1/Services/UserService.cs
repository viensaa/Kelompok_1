using Kelompok_1.Data;
using Kelompok_1.Helpers;
using Kelompok_1.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kelompok_1.Services
{
    public interface IUserService
    {
        // AuthenticateResponse Authenticate(AuthenticateRequest model);
        //IEnumerable<User> GetAll();
        User GetById(int id);
        AuthenticateResponse Login(AuthenticateRequest model);
    }
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {

            new User { Id = 1, Email = "", Password = "" }
        };

        private readonly AppSettings _appSettings;
        private readonly DataContext _context;

        public UserService(IOptions<AppSettings> appSettings,DataContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }


        private string generateJwtToken(Domain.User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public AuthenticateResponse Login(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == model.Email && u.password == model.Password);
            if (user == null) return null;

            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
