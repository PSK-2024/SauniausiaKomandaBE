namespace SauniausiaKomanda.BLL.Services.Abstractions
{
    public interface IImageWriter
    {
        public Task<string> SaveImageAsync(string base64image);
        public void DeleteImage(string image);

    }
}
