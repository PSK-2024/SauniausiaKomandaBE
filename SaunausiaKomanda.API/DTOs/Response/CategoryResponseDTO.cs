using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.DTOs.Response
{
    public class CategoryResponseDTO
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
