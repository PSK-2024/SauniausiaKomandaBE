using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.DAL.Entities
{
    [Index(nameof(UserId), nameof(RecipeId), IsUnique = true)]
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; } = null!;
        public int RecipeId { get; set; }
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; } = null!;
        [Range(1,5)]
        public int Stars { get; set;}
        public string Comment { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
