using Microsoft.AspNetCore.Hosting;
using SauniausiaKomanda.BLL.Services.Abstractions;
using System.Text.RegularExpressions;

namespace SauniausiaKomanda.BLL.Services
{
    public class ImageToFileServerService : IImageWriter
    {
        private readonly IWebHostEnvironment _environment;

        public ImageToFileServerService(IWebHostEnvironment environment)
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

            string path = Path.Combine(GetImageDirPath(), uniqueFileName);

            if (encoding != "base64")
            {
                throw new Exception("Invalid encoding of image");
            }

            var imgByteArray = Convert.FromBase64String(data);

            await File.WriteAllBytesAsync(path, imgByteArray);

            return uniqueFileName;
        }

        public void DeleteImage(string image)
        {
            string path = Path.Combine(GetImageDirPath(), image);
            File.Delete(path);
        }

        private string GetImageDirPath()
        {
            string path;
            if (_environment.WebRootPath is not null)
            {
                path = _environment.WebRootPath;
                path = Path.Combine(path, "images");
            }
            else
            {
                path = Directory.GetCurrentDirectory();
            }
            Directory.CreateDirectory(path);

            return path;
        }
    }
}
