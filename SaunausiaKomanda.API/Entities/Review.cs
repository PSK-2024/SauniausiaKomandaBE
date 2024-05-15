using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(UserId), nameof(RecipeId), IsUnique = true)]
    public class Review
    {
        // TODO: Not clear whether at the moment "Comments" stand for actual comments or reviews, because of the stars displayed above.
        // Will need to comeback to adjust index based on answers
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }
        public required int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
        [Range(1,5)]
        public required int Stars { get; set;}
        public string Comment { get; set; } = string.Empty;
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
