using System.Text.Json.Serialization;

namespace SauniausiaKomanda.BLL.DTOs.Response
{
    public class UserProfileResponseDTO
    {
        [JsonPropertyName("userId")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("firstName")]
        public required string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public required string LastName { get; set; }
        [JsonPropertyName("about")]
        public required string About { get; set; }
        [JsonPropertyName("image")]
        public required string Image { get; set; }
    }
}
