using System.Text.Json.Serialization;

namespace SauniausiaKomanda.DAL.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = "";
        public string Endpoint { get; set; } = "";
        public DateTime LoggedAt { get; set; }
    }
}
