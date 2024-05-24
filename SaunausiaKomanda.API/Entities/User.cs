using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        // TODO: If remember me (refresh token) will be required for recieving valid tokens without entering password
        // additional fields/table will be required
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string About { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual Image? Image { get; set; }
        [JsonIgnore]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public virtual ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        [JsonIgnore]
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public virtual ICollection<Favorite> Favorites { get; } = new List<Favorite>();
        [JsonIgnore]
        public virtual ICollection<Review> Review { get; } = new List<Review>();
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
