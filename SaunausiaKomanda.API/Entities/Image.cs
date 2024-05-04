using SaunausiaKomanda.API.Enums;

namespace SaunausiaKomanda.API.Entities
{
    public class Image
    {
        public required int Id { get; set; }
        public required string Value { get; set; }
        public required ImageLocation ImageLocation { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
