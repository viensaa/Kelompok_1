using System.Text.Json.Serialization;

namespace Kelompok_1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        

        [JsonIgnore]
        public string Password { get; set; }
    }
}
