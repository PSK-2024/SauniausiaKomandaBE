using SaunausiaKomanda.API.Abstractions.Services;
using System.Text.RegularExpressions;

namespace SaunausiaKomanda.API.Services
{
    public class ImageToFileService : IImageWriter
    {
        private readonly IWebHostEnvironment _environment;

        public ImageToFileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveImageAsync(string base64image)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            var formRegex = new Regex("data:(?<mime>[\\w\\/.]+);(?<encoding>\\w+),(?<data>.*)");
            var match = formRegex.Match(base64image);
            var mime = match.Groups["mime"].Value;
            var encoding = match.Groups["encoding"].Value;
            var data = match.Groups["data"].Value;

            switch (mime)
            {
                case "image/jpeg":
                    uniqueFileName += ".jpeg";
                    break;
                case "image/jpg":
                    uniqueFileName += ".jpg";
                    break;
                case "image/png":
                    uniqueFileName += ".png";
                    break;
                default:
                    throw new Exception("Invalid image type");
            }

            var path = Path.Combine(_environment.WebRootPath, "images");
            Directory.CreateDirectory(path);
            path = Path.Combine(path, uniqueFileName);

            if (encoding != "base64")
            {
                throw new Exception("Invalid encoding of image");
            }

            var imgByteArray = Convert.FromBase64String(data);

            await File.WriteAllBytesAsync(path, imgByteArray);

            return uniqueFileName;
        }
    }
}
