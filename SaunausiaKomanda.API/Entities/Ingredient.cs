using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SaunausiaKomanda.API.Entities
{
    public class Ingredient
    {
        // TODO: If nutrients will be retrieved from integration, will likely need to split up ingredient -> unit, measurement, item
        public int Id { get; set; }
        public string Group { get; set; } = "";
        public string Description { get; set; } = null!;
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; } = null!;
        [Timestamp]
        public byte[] Version { get; set; } = null!;
    }
}
