using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.DTOs.Response
{
    public class MyUserProfileResponseDTO
    {
        [JsonPropertyName("name")]
        public string FullName { get; set; } = null!;
        [JsonPropertyName("profilePicture")]
        public string ProfilePicture { get; set; } = null!;
        [JsonPropertyName("bio")]
        public string About { get; set; } = null!;
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;
    }
}
