using Microsoft.EntityFrameworkCore;

namespace SaunausiaKomanda.API.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        // TODO: If remember me (refresh token) will be required for recieving valid tokens without entering password
        // additional fields/table will be required
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string About { get; set; } = string.Empty;
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public ICollection<Recipe> Recipes { get; } = new List<Recipe>();
        [DeleteBehavior(DeleteBehavior.ClientCascade)]
        public ICollection<Favorite> Favorites { get; } = new List<Favorite>();
        public ICollection<Review> Review { get; } = new List<Review>();
    }
}
