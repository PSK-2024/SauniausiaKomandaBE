using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(UserId), nameof(RecipeId), IsUnique = true)]
    public class Favorite
    {
        public required int Id { get; set; }
        public required int UserId { get; set; }
        public required User User { get; set; }
        public required int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
    }
}
