using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(RecipeId), nameof(Sequence), IsUnique = true)]
    public class Step
    {
        public int Id { get; set; }
        public required int Sequence { get; set; }
        public required string Description { get; set; }
        public required int RecipeId { get; set; }
        public required Recipe Recipe { get; set; }
    }
}
