namespace Propostas.Infra.CrossCutting.Utils.Services
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Propostas.Infra.CrossCutting.Utils.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class AzureBlobService : IAzureBlobService
    {
        private string AccountName { get; set; }
        private string AccountKey { get; set; }
        private StorageCredentials Credential { get; set; }

        public AzureBlobService(IConfiguration configuration)
        {
            this.AccountName = configuration["AzureBlobAccountName"];
            this.AccountKey = configuration["AzureBlobAccountKey"];

            this.Credential = new StorageCredentials(this.AccountName, this.AccountKey);
        }

        public void Download(string localPath, string azurePath, bool reseek)
        {
            if (File.Exists(localPath))
            {
                File.Delete(localPath);
            }

            using (var fileStream = new FileStream(localPath, FileMode.OpenOrCreate))
            {
                this.Download(fileStream, azurePath, false);
            }
        }

        public ICollection<string> Download(ICollection<string> azurePaths, bool reseek)
        {
            var localPaths = new List<string>();
            foreach (var azurePath in azurePaths)
            {
                var localPath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".docx";
                localPaths.Add(localPath);

                this.Download(localPath, azurePath, reseek);
            }

            return localPaths;
        }

        public void Download(FileStream fileStream, string azurePath, bool reseek)
        {
            var blob = new CloudBlockBlob(new Uri(azurePath), this.Credential);
            blob.DownloadToStreamAsync(fileStream).Wait();

            if (reseek)
            {
                fileStream.Position = 0;
            }
        }

        public void Upload(string filePath, string azurePath)
        {
            var blob = new CloudBlockBlob(new Uri(azurePath), this.Credential);
            blob.UploadFromFileAsync(filePath).Wait();
        }

        public void Upload(byte[] fileBytes, string azurePath)
        {
            var blob = new CloudBlockBlob(new Uri(azurePath), this.Credential);
            blob.UploadFromByteArrayAsync(fileBytes, 0, fileBytes.Length).Wait();
        }

        public void Remove(string azurePath)
        {
            var blob = new CloudBlockBlob(new Uri(azurePath), this.Credential);
            blob.DeleteIfExistsAsync().Wait();
        }


    }
}
