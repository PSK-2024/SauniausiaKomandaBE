using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.BLL.DTOs.Request
{
    public class AddReviewRequestDTO
    {
        [JsonPropertyName("recipeId")]
        [Required]
        public int RecipeId { get; set; }
        [JsonPropertyName("text")]
        [Required]
        public required string Comment { get; set; }
        [JsonPropertyName("rating")]
        [Required]
        public int Stars { get; set; }
    }
}
