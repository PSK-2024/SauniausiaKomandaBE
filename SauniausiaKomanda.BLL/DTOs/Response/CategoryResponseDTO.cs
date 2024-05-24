using System.Text.Json.Serialization;

namespace SauniausiaKomanda.BLL.DTOs.Response
{
    public class CategoryResponseDTO
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
