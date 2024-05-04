using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(Value), IsUnique = true)]
    public class Tag
    {
        public required int Id { get; set; }
        public required string Value { get; set; }
        public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
    }
}
