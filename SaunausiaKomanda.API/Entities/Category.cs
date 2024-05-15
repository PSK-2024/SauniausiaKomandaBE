using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
    }
}
