using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using SauniausiaKomanda.BLL.Options;
using SauniausiaKomanda.BLL.Services.Abstractions;
using SauniausiaKomanda.DAL.Enums;

namespace SauniausiaKomanda.BLL.Services
{
    public class ImageService : IImageWriter
    {
        private IImageWriter _imageWriter;

        public ImageService(
            IWebHostEnvironment webHostEnvironment,
            IOptionsSnapshot<ImageServiceOptions> imageServiceOptions,
            IOptions<BlobStorageConnectionOptions> blobOptions)
        {
            _imageWriter = GetImageServiceImplementation(imageServiceOptions.Value.ImageLocation, webHostEnvironment, blobOptions);
        }

        public void DeleteImage(string image)
        {
            _imageWriter.DeleteImage(image);
        }

        public async Task<string> SaveImageAsync(string base64image)
        {
            return await _imageWriter.SaveImageAsync(base64image);
        }

        private IImageWriter GetImageServiceImplementation(ImageLocation imageLocation, IWebHostEnvironment webHostEnvironment, IOptions<BlobStorageConnectionOptions> blobOptions) 
            => imageLocation switch
            {
                ImageLocation.Blobstorage => new ImageToBlobStorageService(blobOptions),
                ImageLocation.Fileserver => new ImageToFileServerService(webHostEnvironment),
                _ => new ImageToFileServerService(webHostEnvironment)
            };
    }
}
