using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
    }
}
