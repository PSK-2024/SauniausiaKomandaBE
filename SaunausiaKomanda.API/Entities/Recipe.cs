﻿namespace SaunausiaKomanda.API.Entities
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
    }
}
