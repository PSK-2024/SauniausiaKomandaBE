using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.BLL.DTOs.Request
{
    public class UserProfileUpdateRequestDTO
    {
        [JsonPropertyName("firstName")]
        [Required]
        public string FirstName { get; set; } = null!;
        [JsonPropertyName("lastName")]
        [Required]
        public string LastName { get; set; } = null!;
        [JsonPropertyName("about")]
        [Required]
        public string About { get; set; } = null!;
        [JsonPropertyName("image")]
        [Required]
        public string Image { get; set; } = null!;
    }
}
