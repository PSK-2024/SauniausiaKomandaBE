using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(RecipeId), nameof(Sequence), IsUnique = true)]
    public class Step
    {
        public int Id { get; set; }
        public int Sequence { get; set; }
        public string Description { get; set; } = null!;
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
