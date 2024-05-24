using System.Text.Json.Serialization;

namespace SauniausiaKomanda.BLL.DTOs.Response
{
    public class ShortRecipeResponseDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("rating")]
        public int Rating { get; set; }
        [JsonPropertyName("img")]
        public string? Image { get; set; }
        [JsonPropertyName("duration")]
        public int PreparationTimeInMinutes { get; set; }
        [JsonPropertyName("favorite")]
        public bool isFavorite { get; set; }
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; } = new List<string>();
    }
}
