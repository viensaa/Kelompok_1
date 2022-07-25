namespace Kelompok_1.Models
{
    public class AuthenticateResponse
    {
        private Domain.User user;

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }        
        public string Token { get; set; }


        public AuthenticateResponse(Domain.User user, string token)
        {
            Id = user.Id;
            Nama = user.Nama;
            Email = user.Email;       
            Token = token;
        }

       
    }
}
