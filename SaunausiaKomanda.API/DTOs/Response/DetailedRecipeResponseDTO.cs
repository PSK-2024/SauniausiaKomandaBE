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
        public required string Image { get; set; }
        [JsonPropertyName("favorite")]
        public bool isFavorite { get; set; }
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
        public required string GroupName { get; set; }
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
        public required string Comment { get; set; }
        [JsonPropertyName("author")]
        public required DetailedRecipeAuthorDTO Author { get; set; }
        [JsonPropertyName("rating")]
        public int Stars { get; set; }
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

    public class DetailedRecipeAuthorDTO
    {
        [JsonPropertyName("userId")]
        public int Id { get; set; }
        [JsonPropertyName("email")]
        public required string Email { get; set; }
        [JsonPropertyName("firstName")]
        public required string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public required string LastName { get; set; }
        [JsonPropertyName("image")]
        public required string Image { get; set; }
    }
}
