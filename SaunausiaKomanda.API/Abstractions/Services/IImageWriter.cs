namespace SaunausiaKomanda.API.Abstractions.Services
{
    public interface IImageWriter
    {
        public Task<string> SaveImageAsync(string base64image);
    }
}
