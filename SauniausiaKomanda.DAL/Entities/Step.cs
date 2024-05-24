using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.DAL.Entities
{
    [Index(nameof(RecipeId), nameof(Sequence), IsUnique = true)]
    public class Step
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; } = null!;
        public int RecipeId { get; set; }
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; } = null!;
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
