using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.DTOs.Response
{
    public class UserProfileResponseDTO
    {
        [JsonPropertyName("name")]
        public string FullName { get; set; } = null!;
        [JsonPropertyName("profilePicture")]
        public string ProfilePicture { get; set; } = null!;
        [JsonPropertyName("bio")]
        public string About { get; set; } = null!;
    }
}
