namespace SauniausiaKomanda.BLL.Options
{
    public sealed class BlobStorageConnectionOptions
    {
        public string ConnectionString { get; set; } = "";
        public string ContainerName { get; set; } = "";
    }
}
