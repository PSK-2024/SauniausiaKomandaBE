using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.BLL.DTOs.Request
{
    public class FavoriteRequestDTO
    {
        [Required]
        [JsonPropertyName("recipeId")]
        public int RecipeId {  get; set; }
    }
}
