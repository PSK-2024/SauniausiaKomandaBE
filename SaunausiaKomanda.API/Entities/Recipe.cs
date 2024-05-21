using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(Title), nameof(UserId), IsUnique = true)]
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int PreparationTimeInMinutes { get; set; }
        // TODO: TBD whether we create an integration to retrieve nutritional values
        // Nutrition { get; set; }
        // Also how we will get information about cuisines, allergies, diet shown on main landing page filters
        public virtual Image Image { get; set; } = null!;
        public virtual ICollection<Category> Categories { get; } = new List<Category>();
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
        public virtual ICollection<Review> Reviews { get; } = new List<Review>();
        public virtual ICollection<Step> Steps { get; } = new List<Step>();
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Calories { get; set; }
        [NotMapped]
        public double Rating => Reviews != null && Reviews.Any() ? Reviews.Average(x => x.Stars) : 0;
    }
}
