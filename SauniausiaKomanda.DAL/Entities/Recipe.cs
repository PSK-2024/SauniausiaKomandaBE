using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SauniausiaKomanda.DAL.Entities
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
        [JsonIgnore]
        public virtual Image Image { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Category> Categories { get; } = new List<Category>();
        [JsonIgnore]
        public virtual ICollection<Ingredient> Ingredients { get; } = new List<Ingredient>();
        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; } = new List<Review>();
        [JsonIgnore]
        public virtual ICollection<Step> Steps { get; } = new List<Step>();
        [JsonIgnore]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();
        public int UserId { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; } = null!;
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? Calories { get; set; }
        [NotMapped]
        public double Rating => Reviews != null && Reviews.Any() ? Reviews.Average(x => x.Stars) : 0;
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
