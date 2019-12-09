namespace Propostas.Infra.CrossCutting.Utils.Interfaces
{
    using System.Collections.Generic;

    public interface IDocumentService
    {
        void MergeFromLocal(ICollection<string> docsLocalPaths, string destinationPath);
        void MergeFromAzure(ICollection<string> docsAzurePaths, string destinationPath);

        /// <summary>
        /// Encontra todas as tags no documento solicitado.
        /// </summary>
        /// <param name="filePath">O path do azure do arquivo.</param>
        IEnumerable<string> GetTags(string filePath);

        void ReplaceTags(string filePath, Dictionary<string, string> keyValuePairs);
        void ConvertDocxToPdf(string docxPath, string pdfPath);
    }
}
