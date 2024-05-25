using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.DAL.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
