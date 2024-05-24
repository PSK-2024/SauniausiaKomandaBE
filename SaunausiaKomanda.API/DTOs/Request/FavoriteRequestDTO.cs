using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.DTOs.Request
{
    public class FavoriteRequestDTO
    {
        [Required]
        [JsonPropertyName("recipeId")]
        public int RecipeId {  get; set; }
    }
}
