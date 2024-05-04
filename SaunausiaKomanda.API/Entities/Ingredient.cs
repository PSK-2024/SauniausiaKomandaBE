namespace SaunausiaKomanda.API.Entities
{
    public class Ingredient
    {
        // TODO: If nutrients will be retrieved from integration, will likely need to split up ingredient -> unit, measurement, item
        public required int Id { get; set; }
        public string Group { get; set; } = "";
        public required string Description { get; set; }
        public required Recipe Recipe { get; set; }
    }
}
