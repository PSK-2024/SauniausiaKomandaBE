using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using SauniausiaKomanda.BLL.Options;
using SauniausiaKomanda.BLL.Services.Abstractions;
using Azure.Storage.Blobs.Models;
using System.Text.RegularExpressions;

namespace SauniausiaKomanda.BLL.Services
{
    public class ImageToBlobStorageService : IImageWriter
    {
        private readonly BlobStorageConnectionOptions _blobOptions;
        private BlobServiceClient _blobServiceClient;
        private BlobContainerClient _blobContainerClient;

        public ImageToBlobStorageService(
            IOptions<BlobStorageConnectionOptions> blobOptions) 
        {
            _blobOptions = blobOptions.Value;
            _blobServiceClient = GetBlobServiceClient(_blobOptions.ConnectionString);
            _blobContainerClient = _blobServiceClient.GetBlobContainerClient(_blobOptions.ContainerName);
        }


        public void DeleteImage(string image)
        {
            BlobClient blobClient = _blobContainerClient.GetBlobClient(image);
            
            var response = blobClient.DeleteIfExists(DeleteSnapshotsOption.IncludeSnapshots);
        }

        public async Task<string> SaveImageAsync(string base64image)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            var formRegex = new Regex("data:(?<mime>[\\w\\/.]+);(?<encoding>\\w+),(?<data>.*)");
            var match = formRegex.Match(base64image);
            var mime = match.Groups["mime"].Value;
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

            BlobClient blobClient = _blobContainerClient.GetBlobClient(uniqueFileName);

            var bytes = Convert.FromBase64String(data);
            using (var stream = new MemoryStream(bytes))
            {
                await blobClient.UploadAsync(stream);
            }

            return uniqueFileName;
        }


        private BlobServiceClient GetBlobServiceClient(string connectionString)
        {
            return new BlobServiceClient(connectionString);
        }
    }
}
