namespace Propostas.Infra.CrossCutting.Utils.Interfaces
{
    using System.Collections.Generic;
    using System.IO;

    public interface IAzureBlobService
    {
        void Download(string localPath, string azurePath, bool reseek);
        ICollection<string> Download(ICollection<string> azurePath, bool reseek);
        void Download(FileStream fileStream, string azurePath, bool reseek);
        void Upload(string filePath, string azurePath);
        void Upload(byte[] fileBytes, string azurePath);
        void Remove(string azurePath);
    }
}
