﻿using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.DTOs.Response
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
    }
}
