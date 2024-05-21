using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(UserId), nameof(RecipeId), IsUnique = true)]
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
