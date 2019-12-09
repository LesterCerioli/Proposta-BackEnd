namespace Propostas.Infra.CrossCutting.Utils.Extensions
{
    using System;
    using System.IO;

    public static class StreamExtensions
    {
        /// <summary>
        ///     Converts the file stream to PDF.
        /// </summary>
        /// <param name="file">
        ///     The file to be converted.
        /// </param>
        public static string ToPdf(this FileStream file)
        {
            throw new NotImplementedException();

            /*
                if (File.Exists(filePath))
                    File.Delete(filePath);

                var wordDocument = new Interop.Document();
                Interop.Application appWord = new Interop.Application();
                wordDocument = appWord.Documents.Open(filePath.Replace(".pdf", ".docx"));
                wordDocument.ExportAsFixedFormat(filePath, Interop.WdExportFormat.wdExportFormatPDF);
                wordDocument.Close();

                return true;

            if (!string.IsNullOrEmpty(str))
            {
                str.ToTitleCase();
                str = Regex.Replace(str, @"\s+", string.Empty);
            }

            return str;
            */
        }

    }
}
