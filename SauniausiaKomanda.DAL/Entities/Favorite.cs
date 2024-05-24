using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.DAL.Entities
{
    [Index(nameof(UserId), nameof(RecipeId), IsUnique = true)]
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; } = null!;
        public int RecipeId { get; set; }
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; } = null!;
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
