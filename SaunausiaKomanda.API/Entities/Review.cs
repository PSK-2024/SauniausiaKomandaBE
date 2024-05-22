using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(UserId), nameof(RecipeId), IsUnique = true)]
    public class Review
    {
        // TODO: Not clear whether at the moment "Comments" stand for actual comments or reviews, because of the stars displayed above.
        // Will need to comeback to adjust index based on answers
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
    }
}
