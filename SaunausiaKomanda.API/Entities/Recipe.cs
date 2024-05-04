using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(Title), nameof(UserId), IsUnique = true)]
    public class Recipe
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int PreparationTimeInMinutes { get; set; }
        // TODO: TBD whether we create an integration to retrieve nutritional values
        // Nutrition { get; set; }
        // Also how we will get information about cuisines, allergies, diet shown on main landing page filters
        public required Image Image { get; set; }
        public ICollection<Category> Categories { get; } = new List<Category>();
        public ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
        public ICollection<Review> Reviews { get; } = new List<Review>();
        public ICollection<Step> Steps { get; } = new List<Step>();
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public ICollection<Tag> Tags { get; } = new List<Tag>();
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public ICollection<Favorite> Favorites { get; } = new List<Favorite>();
        public required int UserId { get; set; }
        public required User User { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
