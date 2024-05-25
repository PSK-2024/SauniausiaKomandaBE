using System.Text.Json.Serialization;

namespace SauniausiaKomanda.BLL.DTOs.Request
{
    public class CreateRecipeRequestDTO
    {
        [JsonPropertyName("recipeName")]
        public required string Title { get; set; }
        [JsonPropertyName("time")]
        public int PreparationTimeInMinutes { get; set; }
        [JsonPropertyName("calories")]
        public int Calories { get; set; }
        [JsonPropertyName("imageBase64")]
        public required string Image { get; set; }
        [JsonPropertyName("instructions")]
        public List<string> Steps { get; set; } = new List<string>();
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; } = new List<string>();
        [JsonPropertyName("ingredients")]
        public List<CreateRecipeIngredientsDTO> IngredientGroups { get; set; } = new List<CreateRecipeIngredientsDTO>();
    }

    public class CreateRecipeIngredientsDTO
    {
        [JsonPropertyName("header")]
        public required string Group { get; set; }
        [JsonPropertyName("steps")]
        public List<string> Ingredients { get; set; } = new List<string>();
    }
}
