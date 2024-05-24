namespace SauniausiaKomanda.BLL.DTOs.Response
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string About { get; set; } = "";
        public string Image { get; set; } = "";
    }
}
