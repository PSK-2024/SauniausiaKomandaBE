using SaunausiaKomanda.API.Entities;
using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.DTOs.Response
{
    public class DetailedRecipeResponseDTO
    {
        [JsonPropertyName("title")]
        public required string Title { get; set; }
        [JsonPropertyName("rating")]
        public double Rating { get; set; }
        [JsonPropertyName("duration")]
        public int PreparationTimeInMinutes { get; set; }
        [JsonPropertyName("calories")]
        public int Calories { get; set; }
        [JsonPropertyName("image")]
        public string? Image { get; set; }
        [JsonPropertyName("ingredients")]
        public List<DetailedRecipeIngredientsResponseDTO> Ingredients { get; set; } = new List<DetailedRecipeIngredientsResponseDTO>();
        [JsonPropertyName("instructions")]
        public List<DetailedRecipeInstructionResponseDTO> Steps { get; set; } = new List<DetailedRecipeInstructionResponseDTO>();
        [JsonPropertyName("reviews")]
        public List<DetailedRecipeReviewResponseDTO> Reviews { get; set; } = new List<DetailedRecipeReviewResponseDTO>();
        [JsonPropertyName("categories")]
        public List<DetailedRecipeCategoryDTO> Categories { get; set; } = new List<DetailedRecipeCategoryDTO>();
    }

    public class DetailedRecipeIngredientsResponseDTO
    {
        [JsonPropertyName("groupName")]
        public string? GroupName { get; set; }
        [JsonPropertyName("items")]
        public List<DetailedRecipeIngredientItemsDTO> Items { get; set; } = new List<DetailedRecipeIngredientItemsDTO>();
    }

    public class DetailedRecipeInstructionResponseDTO
    {
        [JsonPropertyName("step")]
        public required string Description { get; set; }
    }

    public class DetailedRecipeReviewResponseDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("text")]
        public string? Comment { get; set; }
        [JsonPropertyName("author")]
        public string? Author { get; set; }
        [JsonPropertyName("rating")]
        public int Stars { get; set; }
        [JsonPropertyName("creatorId")]
        public int UserId { get; set; }
    }

    public class DetailedRecipeIngredientItemsDTO
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }

    public class DetailedRecipeCategoryDTO
    {
        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}
